using MessagePack;
using GestureRecognition.Applications.GestureRecordsServiceConsoleApp.Serialization;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Serialization.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;
using GestureRecognition.Processing.MediaPipeBodyTrackingWebSocketClientProcUnit;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureRecognitionFeatures
{
	internal class GestureFeaturesManager
	{
		#region Private fields
		private readonly FileProcessMode mode;
		private readonly MessagePackSerializerOptions serializerOptions;
		private readonly MediaPipeBodyTrackingWebSocketClient mediaPipeBodyTrackingWebSocketClient;
		private readonly float trackedJointScoreThreshold = 0.6f;
		private readonly float inferredJointScoreThreshold = 0.5f;
		private readonly int numHands = 2;
		private readonly float minHandDetectionConfidence = 0.6f;
		private readonly float minHandPresenceConfidence = 0.6f;
		private readonly float handLandmarksMinTrackingConfidence = 0.6f;
		private string inputFilePath;
		private string outputFilePath;
		private BodyTrackingMode? outputTrackingMode;
		private DateTime previousFlushDate;
		#endregion

		#region Constructors
		public GestureFeaturesManager(FileProcessMode mode, string inputFilePath, string outputFilePath, BodyTrackingMode? outputTrackingMode)
		{
			this.mode = mode;
			this.serializerOptions = MessagePackSerializerOptions.Standard.WithResolver(BodyDataResolver.Instance);
			this.mediaPipeBodyTrackingWebSocketClient = new MediaPipeBodyTrackingWebSocketClient("ws://localhost:5555");
			this.inputFilePath = inputFilePath;
			this.outputFilePath = string.IsNullOrEmpty(outputFilePath) ? inputFilePath : outputFilePath;
			this.outputTrackingMode = outputTrackingMode;
		}
		#endregion

		#region Public methods
		public async Task ExecuteCalculationFeaturesProcess()
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(ExecuteCalculationFeaturesProcess)}";

			if (string.IsNullOrEmpty(this.inputFilePath) ||
				(this.mode == FileProcessMode.File && !File.Exists(this.inputFilePath)) ||
				(this.mode == FileProcessMode.Directory && !Directory.Exists(this.inputFilePath)))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Input file path is empty or file does not exist: {this.inputFilePath}.\n");
				return;
			}

			this.inputFilePath = Path.GetFullPath(this.inputFilePath);

			if (string.IsNullOrEmpty(this.outputFilePath) ||
				(this.mode == FileProcessMode.File && !this.outputFilePath.EndsWith(".record")))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Output file path is empty or invalid format: {this.outputFilePath}.\n");
				return;
			}

			this.outputFilePath = Path.GetFullPath(this.outputFilePath);

			if (string.Equals(this.inputFilePath, this.outputFilePath, StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] The input and output paths are the same. This method does not support overwriting input files.\n");
				return;
			}

			try
			{
				var connectResult = await ConnectToMediaPipeBodyTrackingWebSocketServer(CancellationToken.None);
				if (connectResult.IsSuccess)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Connected to MediaPipeBodyTrackingWebSocketServer.\n");

					var loadModelResponse = await LoadHandLandmarksModel(CancellationToken.None).ConfigureAwait(false);
					if (loadModelResponse.Status == LoadHandLandmarksModelResponseStatus.OK)
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] MediaPipe hand landmarks model loaded.\n");

						int allFilesCount = 0, successFilesCount = 0;
						if (this.mode == FileProcessMode.File)
						{
							allFilesCount = 1;
							bool processFileRes = await ProcessFile(this.inputFilePath, this.outputFilePath, CancellationToken.None).ConfigureAwait(false);
							if (processFileRes)
								successFilesCount++;
						}
						else if (this.mode == FileProcessMode.Directory)
						{
							Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing directory started - input directory: {this.inputFilePath}, output directory: {this.outputFilePath}.\n");
							string[] inputFiles = Directory.GetFiles(this.inputFilePath, "*.record");

							allFilesCount = inputFiles.Length;
							foreach (string inputFile in inputFiles)
							{
								string outputFile = Path.Combine(this.outputFilePath, Path.GetFileName(inputFile));
								bool processFileRes = await ProcessFile(inputFile, outputFile, CancellationToken.None).ConfigureAwait(false);
								if (processFileRes)
									successFilesCount++;
							}
							Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing directory finished - input directory: {this.inputFilePath}, output directory: {this.outputFilePath}.\n");
						}

						Console.WriteLine($"[{methodName}][{DateTime.Now}] All files processed: {allFilesCount}, files processed successfully: {successFilesCount}.\n");
					}
					else
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Loading MediaPipe hand landmarks model failed - reason: {loadModelResponse?.Message ?? string.Empty}.\n");
					}

					var disconnectResult = await DisconnectFromMediaPipeBodyTrackingWebSocketServer(CancellationToken.None).ConfigureAwait(false);
					if (disconnectResult.IsSuccess)
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Disconnected from MediaPipeBodyTrackingWebSocketServer.\n");
					else
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Disconnecting from MediaPipeBodyTrackingWebSocketServer failed - reason: {disconnectResult?.ErrorMessage ?? string.Empty}.\n");
				}
				else
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Connecting to MediaPipeBodyTrackingWebSocketServer failed - reason: {connectResult?.ErrorMessage ?? string.Empty}.\n");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
			}

		}
		#endregion

		#region Private methods
		private async Task<bool> ProcessFile(string inputFilePath, string outputFilePath, CancellationToken token)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(ProcessFile)}";

			bool result = false;
			try
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing file started - input file: {inputFilePath}, output file: {outputFilePath}.\n");
				var (options, trackingMode) = GetRecordInfoFromFile(inputFilePath);
				if (options.HasValue && trackingMode.HasValue)
				{
					if (trackingMode.Value == BodyTrackingMode.Kinect || trackingMode.Value == BodyTrackingMode.MediaPipeHandLandmarks)
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Record options: {options}, record tracking mode: {trackingMode.Value}.\n");
						if (!this.outputTrackingMode.HasValue || trackingMode.Value == this.outputTrackingMode.Value)
						{
							File.Copy(inputFilePath, outputFilePath, true);
							result = await CalculateGestureFeaturesAndExportGestureDataFile(inputFilePath, outputFilePath, trackingMode.Value, trackingMode.Value).ConfigureAwait(false);
						}
						else if (this.outputTrackingMode == BodyTrackingMode.MediaPipeHandLandmarks)
						{
							var (success, colorFrames) = GetColorFramesFromFile(inputFilePath);
							if (success)
							{
								var frames = await GetGestureBodyData(colorFrames, token).ConfigureAwait(false);
								if (frames != null && frames.Length == colorFrames.Length)
								{
									bool writeSuccess = false;
									using (var outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
									using (var writer = new BinaryWriter(outputStream))
									{
										this.previousFlushDate = DateTime.Now;
										writeSuccess = WriteToGestureRecordFile(writer, frames, this.outputTrackingMode.Value);
									}

									if (writeSuccess)
									{
										result = await CalculateGestureFeaturesAndExportGestureDataFile(inputFilePath, outputFilePath, trackingMode.Value, this.outputTrackingMode.Value).ConfigureAwait(false);
									}
									else
									{
										Console.WriteLine($"[{methodName}][{DateTime.Now}] Writing frames to new gesture record file failed.\n");
									}
								}
								else
								{
									Console.WriteLine($"[{methodName}][{DateTime.Now}] Getting bodies data from MediaPipe hand landmarks model failed.\n");
								}
							}
							else
							{
								Console.WriteLine($"[{methodName}][{DateTime.Now}] Getting color frames from file failed - file path: {inputFilePath}.\n");
							}
						}
					}
					else
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Unsupported tracking mode: {trackingMode.Value}, expected: [{BodyTrackingMode.Kinect}, {BodyTrackingMode.MediaPipeHandLandmarks}].\n");
					}
				}

				Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing file finished - input file: {inputFilePath}, output file: {outputFilePath}.\n");
				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return false;
			}
		}

		private async Task<bool> CalculateGestureFeaturesAndExportGestureDataFile(string inputFilePath, string outputFilePath, BodyTrackingMode inputTrackingMode,
			BodyTrackingMode outputTrackingMode)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(CalculateGestureFeaturesAndExportGestureDataFile)}";

			var (getBodyFramesSuccess, bodyFrames) = GetBodyFramesFromFile(outputFilePath);
			if (getBodyFramesSuccess)
			{
				var (getGestureLabel, gestureLabel) = GetGestureLabelFromGestureDataFile(inputFilePath, inputTrackingMode);
				if (getGestureLabel)
				{
					var gestureFeatures = await CalculateGestureFeatures(bodyFrames, outputTrackingMode).ConfigureAwait(false);
					if (gestureFeatures != null && gestureFeatures.IsValid)
					{
						var (exportGestureDataFileSuccess, gestureDataFilePath) = ExportGestureDataFile(gestureFeatures, outputFilePath, gestureLabel, outputTrackingMode);
						if (exportGestureDataFileSuccess)
						{
							Console.WriteLine($"[{methodName}][{DateTime.Now}] New gesture data file exported - file path: {gestureDataFilePath}.\n");
							return true;
						}
						else
						{
							Console.WriteLine($"[{methodName}][{DateTime.Now}] Exporting gesture data file failed - file path: {outputFilePath}.\n");
						}
					}
					else
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Calculating gesture features failed - file path: {outputFilePath}.\n");
					}
				}
				else
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Getting gesture label from file failed - file path: {inputFilePath}.\n");
				}
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Getting body frames from file failed - file path: {outputFilePath}.\n");
			}

			return false;
		}

		#region Reading from record file methods
		private static (RecordOptions? options, BodyTrackingMode? trackingMode) GetRecordInfoFromFile(string filePath)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(GetRecordInfoFromFile)}";
			
			RecordOptions? options = null;
			BodyTrackingMode? trackingMode = null;
			try
			{
				using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				using (var reader = new BinaryReader(stream))
				{
					options = (RecordOptions)reader.ReadInt32();
					trackingMode = (BodyTrackingMode)reader.ReadByte();
					return (options, trackingMode);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return (null, null);
			}
		}

		private (bool success, ColorFrame[] colorFrames) GetColorFramesFromFile(string filePath)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(GetColorFramesFromFile)}";

			var result = new List<ColorFrame>();
			try
			{
				using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				using (var reader = new BinaryReader(stream))
				{
					// Skipping RecordOptions and BodyTrackingMode.
					reader.BaseStream.Position += 5;

					RecordOptions? options = null;
					while (reader.BaseStream.Position != reader.BaseStream.Length)
					{
						options = (RecordOptions)reader.ReadInt32();
						switch (options)
						{
							case RecordOptions.Color:
								var colorFrame = SerializationUtils.ReadColorFrame(reader);
								if (colorFrame == null)
									return (false, []);

								result.Add(colorFrame);
								break;
							case RecordOptions.Bodies:
								// Skipping body frame.
								SerializationUtils.ReadBodyFrame(reader, this.serializerOptions);
								break;
						}
					}
				}

				return (true, result.ToArray());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return (false, []);
			}
		}

		private (bool success, BodyFrame[] bodyFrames) GetBodyFramesFromFile(string filePath)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(GetBodyFramesFromFile)}";

			var result = new List<BodyFrame>();
			try
			{
				using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				using (var reader = new BinaryReader(stream))
				{
					// Skipping RecordOptions and BodyTrackingMode.
					reader.BaseStream.Position += 5;

					RecordOptions? options = null;
					while (reader.BaseStream.Position != reader.BaseStream.Length)
					{
						options = (RecordOptions)reader.ReadInt32();
						switch (options)
						{
							case RecordOptions.Color:
								SerializationUtils.SkipColorFrame(reader);
								break;
							case RecordOptions.Bodies:
								var bodyFrame = SerializationUtils.ReadBodyFrame(reader, this.serializerOptions);
								if (bodyFrame == null)
									return (false, []);

								result.Add(bodyFrame);
								break;
						}
					}
				}

				return (true, result.ToArray());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return (false, []);
			}
		}
		#endregion

		#region Writing to record file methods
		private bool WriteToGestureRecordFile(BinaryWriter writer, (ColorFrame colorFrame, BodyFrame bodyFrame)[] frames, BodyTrackingMode trackingMode)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(WriteToGestureRecordFile)}";

			try
			{
				writer.Write((int)RecordOptions.All);
				writer.Write((byte)trackingMode);

				foreach (var (colorFrame, bodyFrame) in frames)
				{
					SerializationUtils.WriteColorFrame(writer, colorFrame);
					Flush(writer);
					SerializationUtils.WriteBodyFrame(writer, bodyFrame, this.serializerOptions);
					Flush(writer);
				}

				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return false;
			}
		}

		private void Flush(BinaryWriter writer)
		{
			var now = DateTime.Now;

			if (now.Subtract(this.previousFlushDate).TotalSeconds > 60)
			{
				this.previousFlushDate = now;
				writer.Flush();
			}
		}
		#endregion

		#region Getting bodies data from MediaPipeBodyTrackingWebSocketServer
		private async Task<ConnectAsyncResult> ConnectToMediaPipeBodyTrackingWebSocketServer(CancellationToken token)
		{
			return await this.mediaPipeBodyTrackingWebSocketClient.ConnectAsync(token).ConfigureAwait(false);
		}

		private async Task<LoadHandLandmarksModelResponse> LoadHandLandmarksModel(CancellationToken token)
		{
			var loadModelRequest = new LoadHandLandmarksModelRequest()
			{
				ForceReload = true,
				NumHands = this.numHands,
				MinHandDetectionConfidence = this.minHandDetectionConfidence,
				MinHandPresenceConfidence = this.minHandPresenceConfidence,
				MinTrackingConfidence = this.handLandmarksMinTrackingConfidence
			};

			return await this.mediaPipeBodyTrackingWebSocketClient.LoadHandLandmarksModelAsync(loadModelRequest, token).ConfigureAwait(false);
		}

		private async Task<(ColorFrame colorFrame, BodyFrame bodyFrame)[]> GetGestureBodyData(ColorFrame[] colorFrames, CancellationToken token)
		{
			var result = new List<(ColorFrame, BodyFrame)>();

			foreach (var colorFrame in colorFrames)
			{
				byte[] colorData = colorFrame.ColorData;
				if (colorFrame.Width != ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH || colorFrame.Height != ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT)
				{
					colorData = ColorImageUtils.PrepareBgraImageForMediaPipeModel(colorFrame.ColorData, colorFrame.Width, colorFrame.Height,
						ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH, ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT);
				}

				var response = await DetectHandLandmark(colorData, colorFrame.Width, colorFrame.Height, token).ConfigureAwait(false);

				if (response.Status == DetectHandLandmarksResponseStatus.OK)
				{
					var bodyData = response.Map(this.trackedJointScoreThreshold, this.inferredJointScoreThreshold);
					if (bodyData != null)
					{
						result.Add((colorFrame, new BodyFrame(colorFrame.RelativeTime, [bodyData])));
					}
					else
					{
						result.Add((colorFrame, new BodyFrame(colorFrame.RelativeTime, [])));
					}
				}
				else
				{
					result.Add((colorFrame, new BodyFrame(colorFrame.RelativeTime, [])));
				}
			}

			return result.ToArray();
		}

		private async Task<DetectHandLandmarksResponse> DetectHandLandmark(byte[] image, int imageWidth, int imageHeight,
			CancellationToken token)
		{
			var request = new DetectHandLandmarksRequest()
			{
				Image = image,
				ImageWidth = ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH,
				ImageHeight = ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT,
				ImageTargetWidth = imageWidth,
				ImageTargetHeight = imageHeight,
				IsOneBodyTrackingEnabled = true
			};
			return await this.mediaPipeBodyTrackingWebSocketClient.DetectHandLandmarksAsync(request, token).ConfigureAwait(false);
		}

		private async Task<DisconnectAsyncResult> DisconnectFromMediaPipeBodyTrackingWebSocketServer(CancellationToken token)
		{
			return await this.mediaPipeBodyTrackingWebSocketClient.DisconnectAsync(token).ConfigureAwait(false);
		}
		#endregion

		#region Gesture features calculation methods
		private static async Task<GestureFeatures> CalculateGestureFeatures(BodyFrame[] bodyFrames, BodyTrackingMode trackingMode)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(CalculateGestureFeatures)}";

			var (joints, bones) = GetJointsAndBones(trackingMode);

			var bodiesData = bodyFrames.Select(f => f.Bodies.FirstOrDefault()).Where(b => b != null && b.IsTracked).ToArray();
			if (bodiesData.Length == 0)
				return new GestureFeatures(joints, bones);

			var gestureRecognitionFeaturesManager = new GestureRecognitionFeaturesManager(trackingMode);
			return await gestureRecognitionFeaturesManager.CalculateFeatures(bodiesData).ConfigureAwait(false);
		}
		#endregion

		#region Gesture data file methods
		private static (bool success, string label) GetGestureLabelFromGestureDataFile(string filePath, BodyTrackingMode trackingMode)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(GetGestureLabelFromGestureDataFile)}";

			string gestureDataFilePath = filePath.Replace(".record", CsvHelperUtils.CsvFileExtension);
			try
			{
				string gestureLabel = string.Empty;
				if (trackingMode == BodyTrackingMode.Kinect)
				{
					var gestureDataView = CsvHelperUtils.GetGesturesFromFile<KinectGestureDataView>(gestureDataFilePath)?.FirstOrDefault();
					if (gestureDataView != null)
					{
						var gesturePair = gestureDataView.MapFromKinectGestureDataView();
						gestureLabel = gesturePair.label;
					}
				}
				else
				{
					var gestureDataView = CsvHelperUtils.GetGesturesFromFile<MediaPipeHandLandmarksGestureDataView>(gestureDataFilePath)?.FirstOrDefault();
					if (gestureDataView != null)
					{
						var gesturePair = gestureDataView.MapFromMediaPipeHandLandmarksGestureDataView();
						gestureLabel = gesturePair.label;
					}
				}

				return (true, gestureLabel);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return (false, string.Empty);
			}
		}

		private static (bool success, string gestureDataFilePath) ExportGestureDataFile(GestureFeatures gestureFeatures, string filePath, string gestureLabel, BodyTrackingMode trackingMode)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(CalculateGestureFeatures)}";

			string gestureDataFilePath = filePath.Replace(".record", CsvHelperUtils.CsvFileExtension);
			try
			{
				if (trackingMode == BodyTrackingMode.Kinect)
				{
					var gestureDataView = gestureFeatures.MapToKinectGestureDataView(gestureLabel);
					CsvHelperUtils.WriteGesturesToFile([gestureDataView], gestureDataFilePath);
				}
				else
				{
					var gestureDataView = gestureFeatures.MapToMediaPipeHandLandmarksGestureDataView(gestureLabel);
					CsvHelperUtils.WriteGesturesToFile([gestureDataView], gestureDataFilePath);
				}
				return (true, gestureDataFilePath);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}\n");
				return (false, string.Empty);
			}
		}
		#endregion

		#region Other private methods
		private static (JointType[] joints, Bone[] bones) GetJointsAndBones(BodyTrackingMode trackingMode)
		{
			switch (trackingMode)
			{
				case BodyTrackingMode.Kinect:
					return (KinectGestureRecognitionDefinitions.GestureRecognitionJoints, KinectGestureRecognitionDefinitions.GestureRecognitionBones);
				case BodyTrackingMode.MediaPipeHandLandmarks:
					return (MediaPipeHandLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints,
						MediaPipeHandLandmarksGestureRecognitionDefinitions.GestureRecognitionBones);
			}

			return default;
		}
		#endregion

		#endregion
	}
}
