using MessagePack;
using GestureRecognition.Applications.GestureRecordsServiceConsoleApp.Serialization;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Serialization.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureRecognitionFeatures
{
	internal class GestureFeaturesManager
	{
		#region Private fields
		private readonly FileProcessMode mode;
		private readonly MessagePackSerializerOptions serializerOptions;
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
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Input file path is empty or file does not exist: {this.inputFilePath}.");
				return;
			}

			this.inputFilePath = Path.GetFullPath(this.inputFilePath);

			if (string.IsNullOrEmpty(this.outputFilePath) ||
				(this.mode == FileProcessMode.File && !this.outputFilePath.EndsWith(".record")))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Output file path is empty or invalid format: {this.outputFilePath}.");
				return;
			}

			this.outputFilePath = Path.GetFullPath(this.outputFilePath);

			if (string.Equals(this.inputFilePath, this.outputFilePath, StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] The input and output paths are the same. This method does not support overwriting input files.");
				return;
			}

			try
			{
				if (this.mode == FileProcessMode.File)
				{
					await ProcessFile(this.inputFilePath, this.outputFilePath).ConfigureAwait(false);
				}
				else if (this.mode == FileProcessMode.Directory)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing directory started - input directory: {this.inputFilePath}, output directory: {this.outputFilePath}.");
					string[] inputFiles = Directory.GetFiles(this.inputFilePath, "*.record");

					foreach (string inputFile in inputFiles)
					{
						string outputFile = Path.Combine(this.outputFilePath, Path.GetFileName(inputFile));
						await ProcessFile(inputFile, outputFile).ConfigureAwait(false);
					}
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing directory finished - input directory: {this.inputFilePath}, output directory: {this.outputFilePath}.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
			}

		}
		#endregion

		#region Private methods
		private async Task ProcessFile(string inputFilePath, string outputFilePath)
		{
			string methodName = $"{nameof(GestureFeaturesManager)}.{nameof(ProcessFile)}";
			try
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing file started - input file: {inputFilePath}, output file: {outputFilePath}.");
				var (options, trackingMode) = GetRecordInfoFromFile(inputFilePath);
				if (options.HasValue && trackingMode.HasValue)
				{
					if (trackingMode.Value == BodyTrackingMode.Kinect || trackingMode.Value == BodyTrackingMode.MediaPipeHandLandmarks)
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Record options: {options}, record tracking mode: {trackingMode.Value}.");
						if (!this.outputTrackingMode.HasValue || trackingMode.Value == this.outputTrackingMode.Value)
						{
							File.Copy(inputFilePath, outputFilePath, true);
							var (gettingBodyFramesSuccess, bodyFrames) = GetBodyFramesFromFile(outputFilePath);
							if (gettingBodyFramesSuccess)
							{
								var (gettingGestureLabel, gestureLabel) = GetGestureLabelFromGestureDataFile(inputFilePath, trackingMode.Value);
								if (gettingGestureLabel)
								{
									var gestureFeatures = await CalculateGestureFeatures(bodyFrames, trackingMode.Value).ConfigureAwait(false);
									if (gestureFeatures != null && gestureFeatures.IsValid)
									{
										var (exportingGestureDataFileSuccess, gestureDataFilePath) = ExportGestureDataFile(gestureFeatures, outputFilePath, gestureLabel, trackingMode.Value);
										if (exportingGestureDataFileSuccess)
										{
											Console.WriteLine($"[{methodName}][{DateTime.Now}] New gesture data file exported - file path: {gestureDataFilePath}.");
										}
										else
										{
											Console.WriteLine($"[{methodName}][{DateTime.Now}] Exporting gesture data file failed - file path: {outputFilePath}.");
										}
									}
									else
									{
										Console.WriteLine($"[{methodName}][{DateTime.Now}] Calculating gesture features failed - file path: {outputFilePath}.");
									}
								}
								else
								{
									Console.WriteLine($"[{methodName}][{DateTime.Now}] Getting gesture label from file failed - file path: {inputFilePath}.");
								}
							}
							else
							{
								Console.WriteLine($"[{methodName}][{DateTime.Now}] Getting body frames from file failed - file path: {outputFilePath}.");
							}
						}
						else
						{
							//using (var outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
							//using (var writer = new BinaryWriter(outputStream))
							//{
							//	this.previousFlushDate = DateTime.Now;
							//	ProcessFile(reader, writer);
							//}
						}
					}
					else
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Unsupported tracking mode: {trackingMode.Value}, expected: [{BodyTrackingMode.Kinect}, {BodyTrackingMode.MediaPipeHandLandmarks}].");
					}
				}
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing file finished - input file: {inputFilePath}, output file: {outputFilePath}.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
			}
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
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
				return (null, null);
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
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
				return (false, []);
			}
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
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
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
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
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
