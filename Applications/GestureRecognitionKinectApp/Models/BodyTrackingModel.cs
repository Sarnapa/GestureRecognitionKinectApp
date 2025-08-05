using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Structures.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Utilities;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Kinect;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Utilities;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Events;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;
using GestureRecognition.Processing.GestureRecognitionProcUnit;
using GestureRecognition.Processing.MediaPipeBodyTrackingWebSocketClientProcUnit;
using GestureRecognition.Processing.StreamRecordReplayProcUnit.Record;
using Consts = GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures.Consts;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class BodyTrackingModel
	{
		#region Private / protected consts
		// TODO: To consider cancelling frames with big delay
		// private const int NEXT_FRAME_MAX_DELAY_MILLISECONDS = 500;
		#endregion

		#region Private / protected fields
		/// <summary>
		/// Render skeleton data
		/// </summary>
		private RenderBodyFrameManager renderBodyFrameManager;

		/// <summary>
		/// Render color frame
		/// </summary>
		private RenderColorFrameManager renderColorFrameManager;

		/// <summary>
		/// Client for communication with Kinect server
		/// </summary>
		private readonly KinectClient kinectClient;

		/// <summary>
		/// Executes gesture recognition process
		/// </summary>
		private GestureRecognitionManager gestureRecognitionManager;

		/// <summary>
		/// Calculates features for gesture recognition process
		/// </summary>
		private GestureRecognitionFeaturesManager gestureRecognitionFeaturesManager;

		/// <summary>
		/// RGB image that will be displayed
		/// </summary>
		private WriteableBitmap colorImage;

		/// <summary>
		/// Drawing group for body rendering output
		/// </summary>
		private DrawingGroup bodyImageDrawingGroup;

		/// <summary>
		/// Drawing image that will contain body data
		/// </summary>
		private DrawingImage bodyImage;

		/// <summary>
		/// Drawing images width
		/// </summary>
		private int displayImageWidth;

		/// <summary>
		/// Drawing images height
		/// </summary>
		private int displayImageHeight;

		/// <summary>
		/// To queue received frames in chronological order
		/// </summary>
		private Channel<FrameData> framesQueue;

		/// <summary>
		/// Is the task that passes frames for processing running?
		/// </summary>
		private bool isProcessingFramesTaskRunning;

		/// <summary>
		/// To cancel frame processing
		/// </summary>
		private CancellationTokenSource processingFramesTaskTokenSource;

		private TimeSpan lastProcessingFramesRelativeTime;

		private SemaphoreSlim processingFramesSemaphore;

		/// <summary>
		/// Records gesture (color and skeleton data)
		/// </summary>
		private Recorder gestureRecorder;

		/// <summary>
		/// Access to file containing gesture record
		/// </summary>
		private FileStream gestureRecordFile;

		/// <summary>
		/// Access to tracked user skeleton data
		/// </summary>
		private BodyData currentTrackedBody;

		/// <summary>
		/// Current count of tracked users movement
		/// </summary>
		private int currentTrackedBodiesCount;

		/// <summary>
		/// Dictionary: current tracked body joint -> joint localization in color space
		/// </summary>
		private BodyJointsColorSpacePointsDict currentTrackedBodyJointsColorSpacePointsDict;

		/// <summary>
		/// Determines time when body tracking process has been stopped
		/// </summary>
		private DateTime? bodyTrackingStoppedTime;

		/// <summary>
		/// Determines time when user has shown gesture to start recording / detection process
		/// </summary>
		private DateTime? gestureToStartProcessStartTime;

		/// <summary>
		/// Determines time when gesture recording has started (including recording concerning detection process)
		/// </summary>
		private DateTime? gestureRecordStartTime;

		/// <summary>
		/// Determines time when user has stopped making a gesture during recording (including recording concerning detection process)
		/// </summary>
		private DateTime? gestureRecordUserWithoutMovementStartTime;

		/// <summary>
		/// To calculate FPS value
		/// </summary>
		private DateTime lastDisplayedColorFrameTime;

		/// <summary>
		/// Loaded gesture frames for gesture recognizing process
		/// </summary>
		private List<BodyData> gestureToRecognizeBodyFrames;

		/// <summary>
		/// Responsible for communicating with the server that provides user traffic tracking data obtained through the use of an external model
		/// </summary>
		private MediaPipeBodyTrackingWebSocketClient externalBodyTrackingModelClient;

		/// <summary>
		/// Frame counter, essential for skipping frames when we have an external model loaded to track user movement
		/// </summary>
		private int framesCounter = 0;

		/// <summary>
		/// Specifies which frame is to be analyzed by the external model for tracking user movement.
		/// </summary>
		private int frameSkipFactor = 1;

		#region MediaPipe models fields
		private bool isPoseLandmarksModelLoaded = false;
		private float minPoseDetectionConfidence = 0.6f;
		private float minPosePresenceConfidence = 0.6f;
		private float poseLandmarksMinTrackingConfidence = 0.6f;

		private bool isHandLandmarksModelLoaded = false;
		private int numHands = 2;
		private float minHandDetectionConfidence = 0.6f;
		private float minHandPresenceConfidence = 0.6f;
		private float handLandmarksMinTrackingConfidence = 0.6f;
		#endregion

		#region Code archived - failed attempt with mediapipe model in ONNX format
		// Code archived - failed attempt with mediapipe model in ONNX format
		/// <summary>
		/// Wrapper for external model to detect the number of users in an image
		/// </summary>
		//private IModelWrapper poseDetectionModelWrapper;

		/// <summary>
		/// Wrapper for external model to track user movement in an image
		/// </summary>
		//private IModelWrapper poseLandmarksDetectionModelWrapper;
		#endregion

		#region Capturing color frames for testing
		//private int capturedColorFramesCounter = 0;
		//private int capturedColorFramesCount = 0;
		#endregion

		#endregion

		#region Private properties
		private bool IsBodyTrackingStoppedYet
		{
			get
			{
				return this.bodyTrackingStoppedTime.HasValue
					&& DateTime.Now - this.bodyTrackingStoppedTime.Value < Consts.DefaultBodyTrackingStoppedTime;
			}
		}

		/// <summary>
		/// Indicates which model is currently used to track user movement
		/// </summary>
		private BodyTrackingMode TrackingMode
		{
			get
			{
				return ConfigService.TrackingMode;
			}
		}

		private bool IsMediaPipeBodyTrackingMode
		{
			get
			{
				return this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks || this.TrackingMode == BodyTrackingMode.MediaPipeHandLandmarks;
			}
		}

		private MainSettings MainSettings
		{
			get
			{
				return ConfigService.MainSettings;
			}
		}

		// TODO: To consider cancelling frames with big delay
		//private TimeSpan Now
		//{
		//	get
		//	{
		//		return TimeSpan.FromTicks(DateTime.UtcNow.Ticks);
		//	}
		//}

		// Code archived - failed attempt with mediapipe model in ONNX format
		//private bool IsExternalBodyTrackingModelLoaded
		//{
		//	get
		//	{
		//		return this.poseDetectionModelWrapper != null && this.poseDetectionModelWrapper.IsLoaded
		//			&& this.poseLandmarksDetectionModelWrapper != null && this.poseLandmarksDetectionModelWrapper.IsLoaded;
		//	}
		//}
		#endregion

		#region Public properties
		/// <summary>
		/// Is Kinect sensor available?
		/// </summary>
		public bool IsKinectAvailable
		{
			get;
			private set;
		}

		/// <summary>
		/// RGB image that will be displayed
		/// </summary>
		public ImageSource ColorImage
		{
			get
			{
				return this.colorImage;
			}
		}

		/// <summary>
		/// Drawing image that will contain body data
		/// </summary>
		public ImageSource BodyImage
		{
			get
			{
				return this.bodyImage;
			}
		}

		/// <summary>
		/// Is the external model for tracking user movement ready for use?
		/// </summary>
		public bool IsExternalBodyTrackingModelClientReadyToUseToTrackUserMovement
		{
			get
			{
				return this.externalBodyTrackingModelClient != null && this.externalBodyTrackingModelClient.IsConnected
					&& ((this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks && this.isPoseLandmarksModelLoaded)
					|| (this.TrackingMode == BodyTrackingMode.MediaPipeHandLandmarks && this.isHandLandmarksModelLoaded));
			}
		}

		/// <summary>
		/// Represent state of body tracking process
		/// </summary>
		public BodyTrackingState TrackingState
		{
			get;
			set;
		}

		/// <summary>
		/// Is user skeleton detected?
		/// </summary>
		public bool IsUserTracked
		{
			get
			{
				return this.currentTrackedBody != null && this.currentTrackedBody.IsTracked;
			}
		}

		/// <summary>
		/// Path to file containing gesture record
		/// </summary>
		public string GestureRecordFilePath
		{
			get
			{
				return this.gestureRecordFile?.Name ?? string.Empty;
			}
		}

		/// <summary>
		/// Executes gesture recognition process
		/// </summary>
		public GestureRecognitionManager GestureRecognitionManager
		{
			get
			{
				return this.gestureRecognitionManager;
			}
		}
		#endregion

		#region Constructors
		public BodyTrackingModel()
		{
			this.kinectClient = new KinectClient();
			this.gestureToRecognizeBodyFrames = new List<BodyData>();
		}
		#endregion

		#region Public methods
		public async Task Start()
		{
			Application.Current?.Dispatcher.Invoke(() =>
			{
				this.renderColorFrameManager = new RenderColorFrameManager();
				this.renderBodyFrameManager = new RenderBodyFrameManager(RenderBodyFrameManagerParameters.GetParameters(this.TrackingMode));
			});

			if (this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks)
				this.frameSkipFactor = 2;
			else if (this.TrackingMode == BodyTrackingMode.MediaPipeHandLandmarks)
				this.frameSkipFactor = 2;

			this.gestureRecognitionManager = new GestureRecognitionManager();
			this.gestureRecognitionFeaturesManager = new GestureRecognitionFeaturesManager(this.TrackingMode);

			bool isKinectServerStarted = this.kinectClient.StartKinectServer();
			if (isKinectServerStarted)
			{
				bool isConnected = await this.kinectClient.Connect().ConfigureAwait(false);
				if (isConnected)
				{
					this.kinectClient.OnFrameArrived += this.KinectClient_OnFrameArrived;
					this.kinectClient.OnKinectIsAvailableChanged += this.KinectClient_OnKinectIsAvailableChanged;

					var startRequest = new StartRequestParams()
					{
						FrameSourceTypes = this.IsMediaPipeBodyTrackingMode ? FrameSourceTypes.Color : (FrameSourceTypes.Color | FrameSourceTypes.Body),
						ColorImageFormat = ColorImageFormat.Bgra,
						IsOneBodyTrackingEnabled = true,
					};

					var startResponse = await this.kinectClient.SendStartRequest(startRequest).ConfigureAwait(false);
					if (startResponse != null && startResponse.IsSuccess)
					{
						this.displayImageWidth = startResponse.ColorFrameWidth;
						this.displayImageHeight = startResponse.ColorFrameHeight;
						this.IsKinectAvailable = startResponse.KinectSensorIsAvailable;

						if (this.IsMediaPipeBodyTrackingMode)
							await TryToLoadExternalBodyTrackingModels(CancellationToken.None).ConfigureAwait(false);

						StartProcessingFramesTask();

						// Code archived - failed attempt with mediapipe model in ONNX format
						//if (isExternalBodyTrackingModel)
						//	TryToLoadExternalBodyTrackingModels();
						//else
						//	CleanExternalBodyTrackingModels();

						Application.Current?.Dispatcher.Invoke(() =>
						{
							// Create the color image
							this.colorImage = new WriteableBitmap(this.displayImageWidth, this.displayImageHeight, 96.0, 96.0, PixelFormats.Bgra32, null);

							// Create the drawing group we'll use for drawing body data
							this.bodyImageDrawingGroup = new DrawingGroup();
							// Create the image with body data
							this.bodyImage = new DrawingImage(this.bodyImageDrawingGroup);
						});

						MessengerUtils.SendMessage(new DisplayImageChangedMessage() { ChangedDisplayImage = ImageKind.All });
					}
					else
					{
						MessageBoxUtils.ShowMessage($"Starting communication with KinectServer failed.", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				else
				{
					MessageBoxUtils.ShowMessage($"Connecting to KinectServer failed.", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBoxUtils.ShowMessage($"Starting KinectServer failed.", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			// Set the status text
			string statusText = this.IsKinectAvailable ? Properties.Resources.RunningStatusText : Properties.Resources.NoSensorStatusText;
			MessengerUtils.SendMessage(new KinectStatusMessage() { Text = statusText });
		}

		public void StartStopGestureRecording()
		{
			if (this.TrackingState == BodyTrackingState.Standard || this.TrackingState == BodyTrackingState.WaitingToStartGestureRecording)
				StartGestureRecording();
			else if (this.TrackingState == BodyTrackingState.GestureRecording)
				StopGestureRecording();
		}

		public void StartGestureToRecognizeRecording()
		{
			if (this.TrackingState == BodyTrackingState.WaitingToStartGestureRecognizing)
			{
				this.gestureToStartProcessStartTime = null;
				this.gestureRecordStartTime = DateTime.Now;
				this.TrackingState = BodyTrackingState.GestureToRecognizeRecording;
			}
		}

		public async Task<RecognizeGestureResult> ExecuteGestureRecognitionProcess()
		{
			try
			{
				if (this.gestureToRecognizeBodyFrames.Any())
				{
					this.TrackingState = BodyTrackingState.WaitingForGestureRecognizingResult;
					var gestureFeatures = await this.gestureRecognitionFeaturesManager.CalculateFeatures(this.gestureToRecognizeBodyFrames.ToArray());
					if (gestureFeatures != null && gestureFeatures.IsValid)
					{
						return await this.gestureRecognitionManager.RecognizeGestureAsync(new RecognizeGestureParameters(gestureFeatures, CancellationToken.None));
					}
					else
						return new RecognizeGestureResult(false, "Error during calculating features for gesture.");
				}

				return new RecognizeGestureResult(false, "No frames for gesture to recognize.");
			}
			finally
			{
				CleanGestureToRecognizeBodyFrames();
				this.TrackingState = BodyTrackingState.Standard;
			}
		}

		public async Task Cleanup(bool appFinished)
		{
			CleanGestureRecorder(appFinished);
			CleanGestureToRecognizeBodyFrames();
			await DisconnectFromExternalBodyTrackingModelProviderServer(CancellationToken.None).ConfigureAwait(false);

			// Code archived - failed attempt with mediapipe model in ONNX format
			//if (appFinished)
			//	CleanExternalBodyTrackingModels();

			this.kinectClient.OnFrameArrived -= this.KinectClient_OnFrameArrived;
			this.kinectClient.OnKinectIsAvailableChanged -= this.KinectClient_OnKinectIsAvailableChanged;

			var parameters = new StopRequestParams()
			{
				StopServerRunning = appFinished
			};
			await this.kinectClient.SendStopRequest(parameters).ConfigureAwait(false);

			this.kinectClient.Disconnect();

			ChangeKinectIsAvailableStatus(false);

			if (this.currentTrackedBody != null)
				this.currentTrackedBody = null;
		}
		#endregion

		#region Private / protected methods

		#region Events handlers

		#region Frame Arriving handling
		/// <summary>
		/// Handles the data arriving from the KinectServer.
		/// </summary>
		/// <param name="sender">Object sending the event</param>
		/// <param name="e">Event arguments</param>
		private Task KinectClient_OnFrameArrived(object sender, FrameArrivedEventArgs e)
		{
			if (e.Data == null)
				return Task.CompletedTask;

			if (this.colorImage == null || this.bodyImage == null)
				return Task.CompletedTask;

			if (!this.isProcessingFramesTaskRunning)
				return Task.CompletedTask;

			Task.Run(() => StartProcessFrameData(e.Data, this.processingFramesTaskTokenSource.Token));

			return Task.CompletedTask;
		}

		private void StartProcessingFramesTask()
		{
			if (!this.isProcessingFramesTaskRunning && ((this.TrackingMode == BodyTrackingMode.Kinect && this.IsKinectAvailable)
				|| (this.IsMediaPipeBodyTrackingMode && this.IsExternalBodyTrackingModelClientReadyToUseToTrackUserMovement)))
			{
				this.processingFramesTaskTokenSource = new CancellationTokenSource();
				this.processingFramesSemaphore = new SemaphoreSlim(1, 1);
				this.framesQueue = Channel.CreateUnboundedPrioritized(new UnboundedPrioritizedChannelOptions<FrameData>()
				{
					SingleReader = true,
					SingleWriter = false,
					Comparer = new FrameDataRelativeTimeComparer()
				});

				try
				{
					Task.Run(async () =>
					{
						try
						{
							this.isProcessingFramesTaskRunning = true;
							while (this.framesQueue != null && await this.framesQueue.Reader.WaitToReadAsync(this.processingFramesTaskTokenSource?.Token ?? default))
							{
								var frameData = await this.framesQueue.Reader.ReadAsync(this.processingFramesTaskTokenSource?.Token ?? default);
								ProcessFrameData(frameData, this.processingFramesTaskTokenSource?.Token ?? default);
							}
						}
						catch (OperationCanceledException)
						{
						}
						finally
						{
							this.isProcessingFramesTaskRunning = false;
						}
					}, this.processingFramesTaskTokenSource?.Token ?? default);
				}
				catch (Exception)
				{
				}
			}
		}

		private void StopProcessingFrames()
		{
			this.processingFramesTaskTokenSource?.Cancel();

			this.framesQueue?.Writer.TryComplete();

			this.processingFramesSemaphore?.Dispose();

			this.lastProcessingFramesRelativeTime = default;
			this.isProcessingFramesTaskRunning = false;
		}

		private async Task StartProcessFrameData(FrameData frameData, CancellationToken token)
		{
			if (frameData?.ColorFrame == null || token.IsCancellationRequested)
				return;

			// TODO: To consider cancelling frames with big delay
			//if ((this.Now - frameData.ColorFrame.RelativeTime).Milliseconds > NEXT_FRAME_MAX_DELAY_MILLISECONDS)
			//	return;

			if (this.IsMediaPipeBodyTrackingMode)
			{
				bool isNewBodyData = false;
				await this.processingFramesSemaphore.WaitAsync(token).ConfigureAwait(false);
				this.framesCounter++;
				isNewBodyData = this.framesCounter == frameSkipFactor;
				if (isNewBodyData)
					this.framesCounter = 0;
				frameData = await GetFrameData(frameData.ColorFrame, isNewBodyData, token).ConfigureAwait(false);
				this.processingFramesSemaphore.Release();
			}

			// TODO: To consider cancelling frames with big delay
			//if ((this.Now - frameData.ColorFrame.RelativeTime).Milliseconds > NEXT_FRAME_MAX_DELAY_MILLISECONDS)
			//	return;

			if (token.IsCancellationRequested)
				return;

			if (this.framesQueue != null)
				await this.framesQueue.Writer.WriteAsync(frameData, token).ConfigureAwait(false);
		}

		private void ProcessFrameData(FrameData frameData, CancellationToken token)
		{
			if (frameData?.ColorFrame == null || token.IsCancellationRequested)
				return;

			if (frameData.ColorFrame.RelativeTime < this.lastProcessingFramesRelativeTime)
				return;

			// TODO: To consider cancelling frames with big delay
			//if ((this.Now - frameData.ColorFrame.RelativeTime).Milliseconds > NEXT_FRAME_MAX_DELAY_MILLISECONDS)
			//	return;

			var colorFrame = frameData.ColorFrame;
			var bodyFrame = frameData.BodyFrame;
			var bodiesJointsColorSpacePointsDict = frameData.BodiesJointsColorSpacePointsDict;
			bool isNewBodyData = frameData.IsNewBodyData;

			bool colorImageLocked = false;
			BodyData prevTrackedBody = this.currentTrackedBody;
			BodyJointsColorSpacePointsDict prevTrackedBodyJointsColorSpacePointsDict = this.currentTrackedBodyJointsColorSpacePointsDict;

			try
			{
				#region Processing color frame
				Application.Current?.Dispatcher.Invoke(() =>
				{
					this.colorImage.Lock();
					colorImageLocked = true;
					this.renderColorFrameManager.ProcessColorFrame(colorFrame, this.displayImageWidth, this.displayImageHeight, ref this.colorImage);
					this.colorImage.Unlock();
					colorImageLocked = false;
				});
				this.lastProcessingFramesRelativeTime = colorFrame.RelativeTime;
				#endregion

				#region Capturing color frames for testing
				//if (capturedColorFramesCount < 50 && capturedColorFramesCounter != 0 && capturedColorFramesCounter % 24 == 0)
				//{
				//	string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"./ColorFrame_{capturedColorFramesCount}.png");
				//	ColorImageUtils.SaveBgraAsPng(colorFrame.ColorData, colorFrame.Width, colorFrame.Height, imagePath);
				//	capturedColorFramesCount++;
				//	capturedColorFramesCounter = 0;
				//}
				//capturedColorFramesCounter++;
				#endregion

				#region Getting bodies data
				if (isNewBodyData)
				{
					if (colorFrame != null && !this.IsBodyTrackingStoppedYet)
					{
						#region Code archived - failed attempt with mediapipe model in ONNX format
						// 	Code archived - failed attempt with mediapipe model in ONNX format
						//if (this.IsExternalBodyTrackingModelLoaded)
						//{
						//	var colorFrameInput = MLNetMapper.Map(colorFrame, ResolutionType.FullHD);

						//	var poseDetectionPredictParams = new PoseDetectionModelPredictParameters()
						//	{
						//		ColorFrame = colorFrameInput,
						//		// TODO: To be completed
						//		// ConfidenceScoreThreshold =
						//	};
						//	var basePoseDetectionPredictResult = await this.poseDetectionModelWrapper.Predict(poseDetectionPredictParams).ConfigureAwait(false);
						//	if (basePoseDetectionPredictResult.IsSuccess && basePoseDetectionPredictResult is PoseDetectionModelPredictResult poseDetectionPredictResult
						//		&& poseDetectionPredictResult.DetectedPoseCount > 0)
						//	{
						//		this.bodyTrackingStoppedTime = null;
						//		if (poseDetectionPredictResult.DetectedPoseCount > 1)
						//		{
						//			trackedBodiesCount = bodyFrame.BodiesCount;
						//			this.currentTrackedBody = null;
						//		}
						//		else
						//		{
						//			var poseLandmarksDetectionPredictParams = new PoseLandmarksDetectionModelPredictParameters()
						//			{
						//				ColorFrame = colorFrameInput,
						//				// TODO: To be completed
						//				//ConfidenceScoreThreshold = ,
						//				//InferredJointVisibilityThreshold = ,
						//				//NotTrackedJointVisibilityThreshold = ,
						//			};
						//			var basePoseLandmarksDetectionPredictResult = await this.poseLandmarksDetectionModelWrapper.Predict(poseLandmarksDetectionPredictParams).ConfigureAwait(false);
						//			if (basePoseLandmarksDetectionPredictResult.IsSuccess && basePoseLandmarksDetectionPredictResult is PoseLandmarksDetectionModelPredictResult
						//				poseLandmarksDetectionPredictResult)
						//			{
						//				var bodyData = poseLandmarksDetectionPredictResult.BodyData;
						//				var trackedBodies = bodyData != null && bodyData.IsTracked ? new BodyData[] { bodyData } : [];
						//				trackedBodiesCount = trackedBodies.Length;
						//				if (trackedBodiesCount == 1)
						//				{
						//					this.currentTrackedBody = bodyData;
						//					if (bodiesJointsColorSpacePointsDict == null)
						//						bodiesJointsColorSpacePointsDict = new Dictionary<ulong, BodyJointsColorSpacePointsDict>();

						//					bodiesJointsColorSpacePointsDict.Add(bodyData.TrackingId, bodyData.JointsColorSpacePoints);
						//				}
						//				else
						//				{
						//					this.currentTrackedBody = null;
						//				}
						//			}
						//			else
						//			{
						//				trackedBodiesCount = 0;
						//				this.currentTrackedBody = null;
						//			}
						//		}
						//	}
						//	else
						//	{
						//		this.currentTrackedBody = null;
						//	}
						//}
						#endregion

						if (bodyFrame != null && bodyFrame.BodiesCount > 0)
						{
							this.bodyTrackingStoppedTime = null;

							if (bodyFrame.TooMuchUsersForOneBodyTracking)
							{
								this.currentTrackedBodiesCount = bodyFrame.BodiesCount;
								this.currentTrackedBody = null;
							}
							else
							{
								var trackedBodies = bodyFrame.Bodies.Where(b => b != null && b.IsTracked);
								this.currentTrackedBodiesCount = trackedBodies.Count();
								this.currentTrackedBody = this.currentTrackedBodiesCount == 1 ? trackedBodies.FirstOrDefault() : null;
							}
						}
						else
						{
							this.currentTrackedBodiesCount = 0;
							this.currentTrackedBody = null;
						}
					}
				}
				#endregion

				#region Handling and rendering bodies data
				Dictionary<JointType, Point> trackedBodyColorSpacePoints = null;
				if (this.currentTrackedBody != null)
				{
					UpdateBodyTrackingStoppedStatusAndSendMessage(false);

					switch (this.TrackingState)
					{
						case BodyTrackingState.Standard:
							if (!UpdateGestureToStartRecordingDetectionState(this.currentTrackedBody))
								UpdateGestureToStartRecognizingDetectionState(this.currentTrackedBody);
							break;
						case BodyTrackingState.GestureToStartGestureRecording:
							UpdateGestureToStartRecordingDetectionState(this.currentTrackedBody);
							break;
						case BodyTrackingState.GestureToStartGestureRecognizing:
							UpdateGestureToStartRecognizingDetectionState(this.currentTrackedBody);
							break;
					}

					if (isNewBodyData && bodiesJointsColorSpacePointsDict != null
						&& bodiesJointsColorSpacePointsDict.ContainsKey(this.currentTrackedBody.TrackingId))
					{
						this.currentTrackedBodyJointsColorSpacePointsDict = bodiesJointsColorSpacePointsDict[this.currentTrackedBody.TrackingId];
					}

					trackedBodyColorSpacePoints = this.currentTrackedBodyJointsColorSpacePointsDict?.ToDictionary(
						kv => kv.Key, kv => new Point(kv.Value.X, kv.Value.Y));
				}


				if (isNewBodyData)
				{
					Application.Current?.Dispatcher.Invoke(() =>
					{
						using (var dc = this.bodyImageDrawingGroup.Open())
						{
							// Draw a transparent background to set the render size
							dc.DrawRectangle(Brushes.Transparent, null, new Rect(0.0, 0.0, this.displayImageWidth, this.displayImageHeight));

							// Process body data
							if (this.currentTrackedBody != null && trackedBodyColorSpacePoints != null)
							{
								this.renderBodyFrameManager.DrawBody(this.currentTrackedBody.Joints, trackedBodyColorSpacePoints, dc, 0);

								if (trackedBodyColorSpacePoints.ContainsKey(JointType.HandLeft))
									this.renderBodyFrameManager.DrawHand(this.currentTrackedBody.HandLeftState, trackedBodyColorSpacePoints[JointType.HandLeft], dc);
								if (trackedBodyColorSpacePoints.ContainsKey(JointType.HandRight))
									this.renderBodyFrameManager.DrawHand(this.currentTrackedBody.HandRightState, trackedBodyColorSpacePoints[JointType.HandRight], dc);

								// prevent drawing outside of our render area
								this.bodyImageDrawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, this.displayImageWidth, this.displayImageHeight));
							}
						}
					});
				}

				switch (this.TrackingState)
				{
					case BodyTrackingState.Standard:
						if (!CheckIfColorFrameIsNull(colorFrame, false) && !CheckIfNoneTrackedUsers(this.currentTrackedBodiesCount, false))
							CheckIfMoreTrackedUsers(this.currentTrackedBodiesCount);
						break;
					case BodyTrackingState.GestureToStartGestureRecording:
					case BodyTrackingState.GestureToStartGestureRecognizing:
						if (!CheckIfColorFrameIsNull(colorFrame, false) && !CheckIfNoneTrackedUsers(this.currentTrackedBodiesCount, false))
							CheckIfMoreTrackedUsers(this.currentTrackedBodiesCount);
						break;
					case BodyTrackingState.WaitingToStartGestureRecording:
					case BodyTrackingState.WaitingToStartGestureRecognizing:
						if (!CheckIfColorFrameIsNull(colorFrame) && !CheckIfNoneTrackedUsers(this.currentTrackedBodiesCount))
							CheckIfMoreTrackedUsers(this.currentTrackedBodiesCount);
						break;
					case BodyTrackingState.GestureRecording:
						if (CheckIfColorFrameIsNull(colorFrame) || CheckIfNoneTrackedUsers(this.currentTrackedBodiesCount) || CheckIfMoreTrackedUsers(this.currentTrackedBodiesCount))
						{
							StopGestureRecording(true);
						}
						else if (!CheckIfStopGestureRecording(prevTrackedBodyJointsColorSpacePointsDict))
						{
							if ((this.gestureRecorder.Options & RecordOptions.Color) != 0)
								this.gestureRecorder.Record(colorFrame);
							if ((this.gestureRecorder.Options & RecordOptions.Bodies) != 0)
								this.gestureRecorder.Record(bodyFrame, new[] { (this.currentTrackedBody, this.currentTrackedBodyJointsColorSpacePointsDict) });
						}
						break;
					case BodyTrackingState.GestureToRecognizeRecording:
						if (!CheckIfColorFrameIsNull(colorFrame) && !CheckIfNoneTrackedUsers(this.currentTrackedBodiesCount) && !CheckIfMoreTrackedUsers(this.currentTrackedBodiesCount))
						{
							if (!CheckIfStopGestureRecording(prevTrackedBodyJointsColorSpacePointsDict))
								this.gestureToRecognizeBodyFrames.Add(new BodyData(this.currentTrackedBody));
						}
						else
							CleanGestureToRecognizeBodyFrames();
						break;
				}

				SendTrackedUsersCountChangedMessage(this.currentTrackedBodiesCount);
				#endregion

				UpdateLastDisplayedColorFrameTimeAndSendMessage(colorFrame != null);
			}
			finally
			{
				if (colorImageLocked)
				{
					Application.Current?.Dispatcher.Invoke(() =>
					{
						this.colorImage.Unlock();
					});
				}
			}
		}
		#endregion

		/// <summary>
		/// Handles the event which the sensor becomes unavailable (E.g. paused, closed, unplugged)
		/// </summary>
		/// <param name="sender">Object sending the event</param>
		/// <param name="e">Event arguments</param>
		private Task KinectClient_OnKinectIsAvailableChanged(object sender, KinectIsAvailableChangedEventArgs e)
		{
			ChangeKinectIsAvailableStatus(e.Data?.IsAvailable ?? false);
			return Task.CompletedTask;
		}

		private void ChangeKinectIsAvailableStatus(bool isAvailable)
		{
			this.IsKinectAvailable = isAvailable;
			string statusText = this.IsKinectAvailable ? Properties.Resources.RunningStatusText : Properties.Resources.NoSensorStatusText;
			MessengerUtils.SendMessage(new KinectStatusMessage()
			{
				PrevState = this.TrackingState,
				Text = statusText
			});

			if (this.IsKinectAvailable)
			{
				StartProcessingFramesTask();
				SetStandardState();
			}
			else
			{
				StopProcessingFrames();
				if (this.TrackingState == BodyTrackingState.GestureRecording)
					StopGestureRecording(true);
				UpdateBodyTrackingStoppedStatusAndSendMessage(true, Properties.Resources.LostKinectConnection);
			}
		}
		#endregion

		#region External body tracking model methods
		// TODO: Launching REST service from app
		// TODO: Support for multiple resolutions
		// TODO: Problem with closing connection to MediaPipeBodyTrackingWebSocketServer, therefore constantly reconnecting
		private async Task TryToLoadExternalBodyTrackingModels(CancellationToken token)
		{
			var connectResult = await ConnectToExternalBodyTrackingModelProviderServer(token).ConfigureAwait(false);
			if (connectResult.IsSuccess)
			{
				bool isModelChanged = UpdateMediaPipeModelsParametersAndCheckIfNecessaryToReloadModel();
				//if (isModelChanged || !this.IsExternalBodyTrackingModelClientReadyToUseToTrackUserMovement)
				if (isModelChanged || (this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks && !this.isPoseLandmarksModelLoaded)
					|| (this.TrackingMode == BodyTrackingMode.MediaPipeHandLandmarks && !this.isHandLandmarksModelLoaded))
				{
					bool success = false;
					string message = string.Empty;
					if (this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks)
					{
						var response = await LoadPoseLandmarksModel(isModelChanged,
							ModelKind.PoseLandmarksLite,
							1,
							this.minPoseDetectionConfidence,
							this.minPosePresenceConfidence,
							this.poseLandmarksMinTrackingConfidence, token).ConfigureAwait(false);
						success = this.isPoseLandmarksModelLoaded = response.Status == LoadPoseLandmarksModelResponseStatus.OK;
						message = response.Message;
					}
					else
					{
						var response = await LoadHandLandmarksModel(isModelChanged,
							this.numHands,
							this.minHandDetectionConfidence,
							this.minHandPresenceConfidence,
							this.handLandmarksMinTrackingConfidence, token).ConfigureAwait(false);
						success = this.isHandLandmarksModelLoaded = response.Status == LoadHandLandmarksModelResponseStatus.OK;
						message = response.Message;
					}

					if (!success)
						MessageBoxUtils.ShowMessage(message, MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBoxUtils.ShowMessage(connectResult.ErrorMessage, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private bool UpdateMediaPipeModelsParametersAndCheckIfNecessaryToReloadModel()
		{
			bool isChanged = false;
			if (this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks)
			{
				if (this.minPoseDetectionConfidence != ConfigService.MediaPipePoseLandmarksSettings.MinPoseDetectionConfidence)
				{
					this.minPoseDetectionConfidence = ConfigService.MediaPipePoseLandmarksSettings.MinPoseDetectionConfidence;
					isChanged = true;
				}
				if (this.minPosePresenceConfidence != ConfigService.MediaPipePoseLandmarksSettings.MinPosePresenceConfidence)
				{
					this.minPosePresenceConfidence = ConfigService.MediaPipePoseLandmarksSettings.MinPosePresenceConfidence;
					isChanged = true;
				}
				if (this.poseLandmarksMinTrackingConfidence != ConfigService.MediaPipePoseLandmarksSettings.MinTrackingConfidence)
				{
					this.poseLandmarksMinTrackingConfidence = ConfigService.MediaPipePoseLandmarksSettings.MinTrackingConfidence;
					isChanged = true;
				}
			}
			else if (this.TrackingMode == BodyTrackingMode.MediaPipeHandLandmarks)
			{
				if (this.numHands != ConfigService.MediaPipeHandLandmarksSettings.NumHands)
				{
					this.numHands = ConfigService.MediaPipeHandLandmarksSettings.NumHands;
					isChanged = true;
				}
				if (this.minHandDetectionConfidence != ConfigService.MediaPipeHandLandmarksSettings.MinHandDetectionConfidence)
				{
					this.minHandDetectionConfidence = ConfigService.MediaPipeHandLandmarksSettings.MinHandDetectionConfidence;
					isChanged = true;
				}
				if (this.minHandPresenceConfidence != ConfigService.MediaPipeHandLandmarksSettings.MinHandPresenceConfidence)
				{
					this.minHandPresenceConfidence = ConfigService.MediaPipeHandLandmarksSettings.MinHandPresenceConfidence;
					isChanged = true;
				}
				if (this.handLandmarksMinTrackingConfidence != ConfigService.MediaPipeHandLandmarksSettings.MinTrackingConfidence)
				{
					this.handLandmarksMinTrackingConfidence = ConfigService.MediaPipeHandLandmarksSettings.MinTrackingConfidence;
					isChanged = true;
				}
			}

			return isChanged;
		}

		private async Task<ConnectAsyncResult> ConnectToExternalBodyTrackingModelProviderServer(CancellationToken token)
		{
			if (this.externalBodyTrackingModelClient == null)
				this.externalBodyTrackingModelClient = new MediaPipeBodyTrackingWebSocketClient("ws://localhost:5555");

			var result = new ConnectAsyncResult() { Status = ConnectAsyncResultStatus.OK };
			if (!this.externalBodyTrackingModelClient.IsConnected)
			{
				result = await this.externalBodyTrackingModelClient.ConnectAsync(token).ConfigureAwait(false);
			}

			return result;
		}

		private async Task<DisconnectAsyncResult> DisconnectFromExternalBodyTrackingModelProviderServer(CancellationToken token)
		{
			var result = new DisconnectAsyncResult() { Status = DisconnectAsyncResultStatus.OK };
			if (this.externalBodyTrackingModelClient != null)
			{
				result = await this.externalBodyTrackingModelClient.DisconnectAsync(token).ConfigureAwait(false);
				if (result.IsSuccess)
					this.externalBodyTrackingModelClient = null;
			}

			return result;			
		}

		private async Task<LoadPoseLandmarksModelResponse> LoadPoseLandmarksModel(bool forceReload, ModelKind kind, int numPoses,
			float minPoseDetectionConfidence, float minPosePresenceConfidence, float minTrackingConfidence, CancellationToken token)
		{
			var request = new LoadPoseLandmarksModelRequest()
			{
				ForceReload = forceReload,
				Kind = kind,
				NumPoses = numPoses,
				MinPoseDetectionConfidence = minPoseDetectionConfidence,
				MinPosePresenceConfidence = minPosePresenceConfidence,
				MinTrackingConfidence = minTrackingConfidence,
			};
			return await this.externalBodyTrackingModelClient.LoadPoseLandmarksModelAsync(request, token).ConfigureAwait(false);
		}

		private async Task<LoadHandLandmarksModelResponse> LoadHandLandmarksModel(bool forceReload, int numHands, 
			float minHandDetectionConfidence, float minHandPresenceConfidence, float minTrackingConfidence, CancellationToken token)
		{
			var request = new LoadHandLandmarksModelRequest()
			{
				ForceReload = forceReload,
				NumHands = numHands,
				MinHandDetectionConfidence = minHandDetectionConfidence,
				MinHandPresenceConfidence = minHandPresenceConfidence,
				MinTrackingConfidence = minTrackingConfidence,
			};
			return await this.externalBodyTrackingModelClient.LoadHandLandmarksModelAsync(request, token).ConfigureAwait(false);
		}

		private async Task<FrameData> GetFrameData(ColorFrame colorFrame, bool isNewBodyData, CancellationToken token)
		{
			var bodyFrame = new BodyFrame();
			var bodiesJointsColorSpacePointsDict = new Dictionary<ulong, BodyJointsColorSpacePointsDict>();
			if (this.IsExternalBodyTrackingModelClientReadyToUseToTrackUserMovement && isNewBodyData)
			{
				var (bodiesData, bodiesCount) = await GetBodiesData(colorFrame, token).ConfigureAwait(false);
				if (bodiesCount > 1)
				{
					bodyFrame = new BodyFrame(colorFrame.RelativeTime, bodiesCount, true);
					isNewBodyData = false;
				}
				else
				{
					bodyFrame = new BodyFrame(colorFrame.RelativeTime, bodiesData);
					bodiesJointsColorSpacePointsDict = bodiesData.ToDictionary(b => b.TrackingId, b => b.JointsColorSpacePoints);
				}
			}

			return new FrameData()
			{
				ColorFrame = colorFrame,
				BodyFrame = bodyFrame,
				BodiesJointsColorSpacePointsDict = bodiesJointsColorSpacePointsDict,
				IsNewBodyData = isNewBodyData,
			};
		}

		private async Task<(BodyDataWithColorSpacePoints[] bodiesData, int bodiesCount)> GetBodiesData(ColorFrame colorFrame, CancellationToken token)
		{
			bool isMediaPipePoseLandmark = this.TrackingMode == BodyTrackingMode.MediaPipePoseLandmarks; 

			int scaledImageWidth = isMediaPipePoseLandmark ? ModelConsts.POSE_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH : ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH;
			int scaledImageHeight = isMediaPipePoseLandmark ? ModelConsts.POSE_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT : ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT;
			byte[] colorData = colorFrame.ColorData;
			if (colorFrame.Width != scaledImageWidth || colorFrame.Height != scaledImageHeight)
				colorData = ColorImageUtils.PrepareBgraImageForMediaPipeModel(colorFrame.ColorData, colorFrame.Width, colorFrame.Height, scaledImageWidth, scaledImageHeight);

			if (isMediaPipePoseLandmark)
			{
				var response = await DetectPoseLandmark(colorData, scaledImageWidth, scaledImageHeight, colorFrame.Width, colorFrame.Height, token).ConfigureAwait(false);
				
				if (response.Status == DetectPoseLandmarksResponseStatus.TooMuchUsersForOneBodyTracking)
					return ([], response.BodiesCount);

				var bodyData = await response.Map(this.MainSettings.TrackedJointScoreThreshold, this.MainSettings.InferredJointScoreThreshold).ConfigureAwait(false);
				return (bodyData, 1);
			}
			else
			{
				var response = await DetectHandLandmark(colorData, scaledImageWidth, scaledImageHeight, colorFrame.Width, colorFrame.Height, token).ConfigureAwait(false);

				if (response.Status == DetectHandLandmarksResponseStatus.TooMuchUsersForOneBodyTracking)
					return ([], response.BodiesCount);

				var bodyData = response.Map(this.MainSettings.TrackedJointScoreThreshold, this.MainSettings.InferredJointScoreThreshold);
				return ([bodyData], 1);
			}
		}

		private async Task<DetectPoseLandmarksResponse> DetectPoseLandmark(byte[] image, int imageWidth, int imageHeight,
			int imageTargetWidth, int imageTargetHeight, CancellationToken token)
		{
			var request = new DetectPoseLandmarksRequest()
			{
				Image = image,
				ImageWidth = imageWidth,
				ImageHeight = imageHeight,
				ImageTargetWidth = imageTargetWidth,
				ImageTargetHeight = imageTargetHeight,
				IsOneBodyTrackingEnabled = true
			};
			return await this.externalBodyTrackingModelClient.DetectPoseLandmarksAsync(request, token).ConfigureAwait(false);
		}

		private async Task<DetectHandLandmarksResponse> DetectHandLandmark(byte[] image, int imageWidth, int imageHeight,
			int imageTargetWidth, int imageTargetHeight, CancellationToken token)
		{
			var request = new DetectHandLandmarksRequest()
			{
				Image = image,
				ImageWidth = imageWidth,
				ImageHeight = imageHeight,
				ImageTargetWidth = imageTargetWidth,
				ImageTargetHeight = imageTargetHeight,
				IsOneBodyTrackingEnabled = true
			};
			return await this.externalBodyTrackingModelClient.DetectHandLandmarksAsync(request, token).ConfigureAwait(false);
		}

		// Code archived - failed attempt with mediapipe model in ONNX format
		//private void TryToLoadExternalBodyTrackingModels()
		//{
		//	if (!this.IsExternalBodyTrackingModelLoaded)
		//	{
		//		// TODO: Support for multiple resolutions
		//		var modelWrapperParameters = new ModelWrapperParameters()
		//		{
		//			Seed = 42
		//		};
		//		this.poseDetectionModelWrapper = new PoseDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);
		//		this.poseLandmarksDetectionModelWrapper = new PoseLandmarksDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);

		//		var poseDetectionModelLoadParams = new LoadBodyTrackingModelParameters();
		//		var poseDetectionModelLoadResult = this.poseDetectionModelWrapper.LoadModel(poseDetectionModelLoadParams);
		//		if (poseDetectionModelLoadResult.IsSuccess)
		//		{
		//			var poseLandmarksDetectionModelLoadParams = new LoadBodyTrackingModelParameters();
		//			var poseLandMarksDetectionModelLoadResult = this.poseLandmarksDetectionModelWrapper.LoadModel(poseLandmarksDetectionModelLoadParams);
		//			if (!poseLandMarksDetectionModelLoadResult.IsSuccess)
		//				MessageBoxUtils.ShowMessage(poseLandMarksDetectionModelLoadResult.ErrorMessage, MessageBoxButton.OK, MessageBoxImage.Error);
		//		}
		//		else
		//		{
		//			MessageBoxUtils.ShowMessage(poseDetectionModelLoadResult.ErrorMessage, MessageBoxButton.OK, MessageBoxImage.Error);
		//		}

		//		if (!this.IsExternalBodyTrackingModelLoaded)
		//			CleanExternalBodyTrackingModels();
		//	}
		//}

		// Code archived - failed attempt with mediapipe model in ONNX format
		//private void CleanExternalBodyTrackingModels()
		//{
		//	if (this.poseDetectionModelWrapper != null)
		//	{
		//		this.poseDetectionModelWrapper.Cleanup();
		//		this.poseDetectionModelWrapper = null;
		//	}

		//	if (this.poseLandmarksDetectionModelWrapper != null)
		//	{
		//		this.poseLandmarksDetectionModelWrapper.Cleanup();
		//		this.poseLandmarksDetectionModelWrapper = null;
		//	}
		//}
		#endregion

		#region Convert body joints coordinations to color coordinations methods
		// TODO: Unnecessary for now, to be removed
		//private BodyJointsColorSpacePointsDict ConvertToColorSpace(BodyData body)
		//{
		//	return ConvertToColorSpace(new[] { body }).FirstOrDefault().Item2;
		//}

		//private (BodyData, BodyJointsColorSpacePointsDict)[] ConvertToColorSpace(IEnumerable<BodyData> bodies)
		//{
		//	if (bodies == null || !bodies.Any())
		//		return new (BodyData, BodyJointsColorSpacePointsDict)[] { };

		//	return bodies.Select(b => (b, ConvertToColorSpace(b?.Joints))).ToArray();
		//}

		//private BodyJointsColorSpacePointsDict ConvertToColorSpace(IReadOnlyDictionary<JointType, Joint> joints)
		//{
		//	var jointsPoints = new BodyJointsColorSpacePointsDict();

		//	if (joints != null)
		//	{
		//		foreach (var jointType in joints.Keys)
		//		{
		//			var position = joints[jointType].Position;
		//			var kinectPosition = new Kinect.CameraSpacePoint() { X = position.X, Y = position.Y, Z = position.Z };
		//			var kinectColorSpacePosition = this.coordinateMapper.MapCameraPointToColorSpace(kinectPosition);
		//			jointsPoints[jointType] = kinectColorSpacePosition.Map();
		//		}
		//	}

		//	return jointsPoints;
		//}
		#endregion

		#region Detecting gestures to start recording / recognizing given gesture
		private bool UpdateGestureToStartRecordingDetectionState(BodyData trackedBody)
		{
			bool isRightHandClosed = trackedBody.HandRightState == HandState.Closed && trackedBody.HandRightConfidence == TrackingConfidence.High;
			if (isRightHandClosed)
			{
				if (this.gestureToStartProcessStartTime.HasValue && this.TrackingState == BodyTrackingState.GestureToStartGestureRecording)
				{
					TimeSpan duration = DateTime.Now - this.gestureToStartProcessStartTime.Value;
					if (duration >= Consts.GestureToStartRecordingTimeLimit)
					{
						this.gestureToStartProcessStartTime = null;
						this.TrackingState = BodyTrackingState.WaitingToStartGestureRecording;
						MessengerUtils.SendMessage(new TemporaryStateStartedMessage());
					}
				}
				else
				{
					this.gestureToStartProcessStartTime = DateTime.Now;
					this.TrackingState = BodyTrackingState.GestureToStartGestureRecording;
				}
			}
			else if (this.TrackingState == BodyTrackingState.GestureToStartGestureRecording)
			{
				this.gestureToStartProcessStartTime = null;
				this.TrackingState = BodyTrackingState.Standard;
			}

			return isRightHandClosed;
		}

		private bool UpdateGestureToStartRecognizingDetectionState(BodyData trackedBody)
		{
			bool isRightHandOpen = trackedBody.HandRightState == HandState.Open && trackedBody.HandRightConfidence == TrackingConfidence.High;
			if (isRightHandOpen)
			{
				if (this.gestureToStartProcessStartTime.HasValue && this.TrackingState == BodyTrackingState.GestureToStartGestureRecognizing)
				{
					TimeSpan duration = DateTime.Now - this.gestureToStartProcessStartTime.Value;
					if (duration >= Consts.GestureToStartRecognizingTimeLimit)
					{
						this.gestureToStartProcessStartTime = null;
						this.TrackingState = BodyTrackingState.WaitingToStartGestureRecognizing;
						MessengerUtils.SendMessage(new TemporaryStateStartedMessage());
					}
				}
				else
				{
					this.gestureToStartProcessStartTime = DateTime.Now;
					this.TrackingState = BodyTrackingState.GestureToStartGestureRecognizing;
				}
			}
			else if (this.TrackingState == BodyTrackingState.GestureToStartGestureRecognizing)
			{
				this.gestureToStartProcessStartTime = null;
				this.TrackingState = BodyTrackingState.Standard;
			}

			return isRightHandOpen;
		}
		#endregion

		#region Gesture recording methods
		private void CreateTemporaryRecordFile()
		{
			string fileName = $"{Utils.RandomString(32)}{Consts.GestureRecordFileExtension}";
			this.gestureRecordFile = File.Create(fileName);
			File.SetAttributes(fileName, File.GetAttributes(fileName) | FileAttributes.Hidden);
		}

		private void StartGestureRecording(bool isGestureToRecognize = false)
		{
			CreateTemporaryRecordFile();
			this.gestureRecorder = new Recorder(isGestureToRecognize ? RecordOptions.Bodies : RecordOptions.All,
				this.TrackingMode, this.gestureRecordFile, Consts.GestureRecordResizingCoef);
			this.gestureToStartProcessStartTime = null;
			this.gestureRecordStartTime = DateTime.Now;
			this.TrackingState = BodyTrackingState.GestureRecording;
		}

		private bool CheckIfStopGestureRecording(BodyJointsColorSpacePointsDict prevDict)
		{
			bool isGestureRecording = this.TrackingState == BodyTrackingState.GestureRecording;
			bool isGestureToRecognizeRecording = this.TrackingState == BodyTrackingState.GestureToRecognizeRecording;
			if ((isGestureRecording || isGestureToRecognizeRecording) && this.gestureRecordStartTime.HasValue)
			{
				TimeSpan gestureRecordTimeLimit = isGestureRecording ? Consts.GestureRecordTimeLimit : Consts.GestureToRecognizeRecordTimeLimit;
				TimeSpan gestureRecordUserWithoutMovementTimeLimit = isGestureRecording ? Consts.GestureRecordUserWithoutMovementTimeLimit
					: Consts.GestureToRecognizeRecordUserWithoutMovementTimeLimit;

				TimeSpan duration = DateTime.Now - this.gestureRecordStartTime.Value;
				if (duration >= gestureRecordTimeLimit)
				{
					MessengerUtils.SendMessage(new GestureRecordingFinishedMessage());
					this.gestureRecordUserWithoutMovementStartTime = null;
					return true;
				}

				if (CompareBodyJointsColorSpacePointsDict(prevDict))
				{
					if (this.gestureRecordUserWithoutMovementStartTime.HasValue)
					{
						if (DateTime.Now - this.gestureRecordUserWithoutMovementStartTime >= gestureRecordUserWithoutMovementTimeLimit)
						{
							MessengerUtils.SendMessage(new GestureRecordingFinishedMessage());
							this.gestureRecordUserWithoutMovementStartTime = null;
							return true;
						}
					}
					else
						this.gestureRecordUserWithoutMovementStartTime = DateTime.Now;
				}
				else
					this.gestureRecordUserWithoutMovementStartTime = null;
			}

			return false;
		}

		private bool CompareBodyJointsColorSpacePointsDict(BodyJointsColorSpacePointsDict prevDict)
		{
			if (this.currentTrackedBodyJointsColorSpacePointsDict == null && prevDict == null)
				return true;

			if (this.currentTrackedBodyJointsColorSpacePointsDict == null || prevDict == null)
				return false;

			if (this.currentTrackedBodyJointsColorSpacePointsDict.Count != prevDict.Count)
				return false;

			foreach (var pair in prevDict)
			{
				var joint = pair.Key;
				var prevPosition = pair.Value;

				// Tracking thumbs positions is unstable.
				if (joint == JointType.ThumbLeft || joint == JointType.ThumbRight)
					continue;

				if (!this.currentTrackedBodyJointsColorSpacePointsDict.TryGetValue(joint, out Vector2 currentPosition))
					return false;

				if (Math.Abs(currentPosition.X - prevPosition.X) > Consts.ColorSpaceBodyJointDisplacementPositionLimit 
					|| Math.Abs(currentPosition.Y - prevPosition.Y) > Consts.ColorSpaceBodyJointDisplacementPositionLimit)
					return false;
			}

			return true;
		}

		private void StopGestureRecording(bool deleteGestureRecordFile = false)
		{
			this.gestureRecorder.Stop();
			CleanGestureRecorder(deleteGestureRecordFile);
		}

		private void CleanGestureRecorder(bool deleteGestureRecordFile = true)
		{
			SetStandardState();
			if (this.gestureRecorder != null)
			{
				this.gestureRecorder.Dispose();
				this.gestureRecorder = null;
			}
			if (this.gestureRecordFile != null)
			{
				this.gestureRecordFile.Close();
				if (deleteGestureRecordFile)
					File.Delete(this.gestureRecordFile.Name);
				this.gestureRecordFile.Dispose();
				this.gestureRecordFile = null;
			}
		}
		#endregion

		#region Others methods
		private void SetStandardState()
		{
			this.TrackingState = BodyTrackingState.Standard;
			if (this.gestureRecordStartTime != null)
				this.gestureRecordStartTime = null;
			if (this.gestureToStartProcessStartTime != null)
				this.gestureToStartProcessStartTime = null;
			if (this.gestureRecordUserWithoutMovementStartTime != null)
				this.gestureRecordUserWithoutMovementStartTime = null;
			if (this.currentTrackedBody != null)
				this.currentTrackedBody = null;
			if (this.currentTrackedBodyJointsColorSpacePointsDict != null)
				this.currentTrackedBodyJointsColorSpacePointsDict = null;
		}

		private bool CheckIfColorFrameIsNull(ColorFrame colorFrame, bool showMessage = true)
		{
			if (colorFrame == null)
			{
				UpdateBodyTrackingStoppedStatusAndSendMessage(true, showMessage ? Properties.Resources.NoColorFrame : null);
				SetStandardState();
				return true;
			}

			return false;
		}

		private bool CheckIfNoneTrackedUsers(int trackedBodiesCount, bool showMessage = true)
		{
			if (trackedBodiesCount == 0)
			{
				UpdateBodyTrackingStoppedStatusAndSendMessage(true, showMessage ? Properties.Resources.LostUserBodyTracking : null);
				SetStandardState();
				return true;
			}

			return false;
		}

		private bool CheckIfMoreTrackedUsers(int trackedBodiesCount)
		{
			if (trackedBodiesCount > 1)
			{
				UpdateBodyTrackingStoppedStatusAndSendMessage(true, string.Format(Properties.Resources.DetectedMoreUsers, trackedBodiesCount));
				SetStandardState();
				return true;
			}

			return false;
		}

		private void SendTrackedUsersCountChangedMessage(int trackedBodiesCount)
		{
			MessengerUtils.SendMessage(new TrackedUsersCountChangedMessage()
			{
				Count = trackedBodiesCount
			});
		}

		private void UpdateBodyTrackingStoppedStatusAndSendMessage(bool isStopped, string text = null)
		{
			if (!this.IsBodyTrackingStoppedYet)
			{
				// Time to show message
				if (isStopped && !string.IsNullOrEmpty(text))
					this.bodyTrackingStoppedTime = DateTime.Now;

				MessengerUtils.SendMessage(new BodyTrackingStoppedMessage()
				{
					IsStopped = isStopped,
					PrevState = this.TrackingState,
					Text = text,
				});
			}
		}

		private void UpdateLastDisplayedColorFrameTimeAndSendMessage(bool isColorFrame)
		{
			if (isColorFrame)
			{
				var now = DateTime.Now;
				MessengerUtils.SendMessage(new FPSValueMessage() { Value = 1 / (now - this.lastDisplayedColorFrameTime).TotalSeconds });
				this.lastDisplayedColorFrameTime = now;
			}
			else
			{
				MessengerUtils.SendMessage(new FPSValueMessage() { Value = 0d });
			}
		}

		private void CleanGestureToRecognizeBodyFrames()
		{
			if (this.gestureToRecognizeBodyFrames.Any())
				this.gestureToRecognizeBodyFrames.Clear();
		}
		#endregion

		#endregion
	}
}
