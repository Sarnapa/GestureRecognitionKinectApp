using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kinect;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Utilities;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.Kinect;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;
using GestureRecognition.Processing.GestureRecognitionProcUnit;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class BodyTrackingModel
	{
		#region Private / protected fields
		/// <summary>
		/// Render skeleton data
		/// </summary>
		private readonly RenderBodyFrameManager renderBodyFrameManager;

		/// <summary>
		/// Render color frame
		/// </summary>
		private readonly RenderColorFrameManager renderColorFrameManager;

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
		/// Active Kinect sensor
		/// </summary>
		private KinectSensor kinectSensor;

		/// <summary>
		/// Reader for frames from multiple sources
		/// </summary>
		private MultiSourceFrameReader multiSourceReader;

		/// <summary>
		/// Coordinate mapper to map one type of point to another
		/// </summary>
		private CoordinateMapper coordinateMapper;

		/// <summary>
		/// Records gesture (color and skeleton data)
		/// </summary>
		private KinectRecorder gestureRecorder;

		/// <summary>
		/// Access to file containing gesture record
		/// </summary>
		private FileStream gestureRecordFile;

		/// <summary>
		/// Access to tracked user skeleton data
		/// </summary>
		private Body currentTrackedBody;

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
		#endregion

		#region Public properties
		/// <summary>
		/// Is Kinect sensor available?
		/// </summary>
		public bool IsKinectAvailable
		{
			get
			{
				return this.kinectSensor != null && this.kinectSensor.IsAvailable;
			}
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
			this.renderColorFrameManager = new RenderColorFrameManager();
			this.renderBodyFrameManager = new RenderBodyFrameManager();
			this.gestureRecognitionManager = SimpleIoc.Default.GetInstance<GestureRecognitionManager>();
			this.gestureRecognitionFeaturesManager = SimpleIoc.Default.GetInstance<GestureRecognitionFeaturesManager>();

			this.gestureToRecognizeBodyFrames = new List<BodyData>();
		}
		#endregion

		#region Public methods
		public void Start()
		{
			// One sensor is currently supported
			this.kinectSensor = KinectSensor.GetDefault();
			this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;

			// Open the reader for the body frames
			this.multiSourceReader = this.kinectSensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Body);

			// Get the coordinate mapper
			this.coordinateMapper = this.kinectSensor.CoordinateMapper;

			var colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Bgra);
			this.displayImageWidth = colorFrameDescription.Width;
			this.displayImageHeight = colorFrameDescription.Height;

			// Create the color image
			this.colorImage = new WriteableBitmap(this.displayImageWidth, this.displayImageHeight, 96.0, 96.0, PixelFormats.Bgra32, null);

			// Create the drawing group we'll use for drawing body data
			this.bodyImageDrawingGroup = new DrawingGroup();
			// Create the image with body data
			this.bodyImage = new DrawingImage(this.bodyImageDrawingGroup);

			Messenger.Default.Send(new DisplayImageChangedMessage() { ChangedDisplayImage = ImageKind.All });

			// Open the sensor
			this.kinectSensor.Open();

			// Set the status text
			string statusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
																											: Properties.Resources.NoSensorStatusText;
			Messenger.Default.Send(new KinectStatusMessage() { Text = statusText });

			if (this.multiSourceReader != null)
				this.multiSourceReader.MultiSourceFrameArrived += this.Reader_FrameArrived;
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
						return await this.gestureRecognitionManager.RecognizeGesture(new RecognizeGestureParameters(gestureFeatures, CancellationToken.None));
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

		public void Cleanup(bool deleteGestureRecordFile = true)
		{
			CleanGestureRecorder(deleteGestureRecordFile);
			CleanGestureToRecognizeBodyFrames();

			if (this.multiSourceReader != null)
			{
				this.multiSourceReader.Dispose();
				this.multiSourceReader = null;
			}

			if (this.kinectSensor != null)
			{
				this.kinectSensor.IsAvailableChanged -= this.Sensor_IsAvailableChanged;
				this.kinectSensor.Close();
				this.kinectSensor = null;
			}

			if (this.currentTrackedBody != null)
				this.currentTrackedBody = null;

		}
		#endregion

		#region Private / protected methods

		#region Events handlers
		/// <summary>
		/// Handles the data arriving from the sensor
		/// </summary>
		/// <param name="sender">Object sending the event</param>
		/// <param name="e">Event arguments</param>
		private void Reader_FrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
		{
			var multiSourceFrame = e.FrameReference.AcquireFrame();

			// If the Frame has expired by the time we process this event, return.
			if (multiSourceFrame == null)
				return;

			bool colorImageLocked = false;
			ColorFrame colorFrame = null;
			BodyFrame bodyFrame = null;
			Body prevTrackedBody = this.currentTrackedBody;
			BodyJointsColorSpacePointsDict prevTrackedBodyJointsColorSpacePointsDict = this.currentTrackedBodyJointsColorSpacePointsDict;
			int trackedBodiesCount = 0;

			try
			{
				colorFrame = multiSourceFrame.ColorFrameReference.AcquireFrame();
				bodyFrame = multiSourceFrame.BodyFrameReference.AcquireFrame();

				if (colorFrame != null)
				{
					this.colorImage.Lock();
					colorImageLocked = true;

					this.renderColorFrameManager.ProcessColorFrame(colorFrame, this.displayImageWidth, this.displayImageHeight,
						ref this.colorImage);
				}

				if (colorFrame != null && bodyFrame != null && bodyFrame.BodyCount > 0 && !this.IsBodyTrackingStoppedYet)
				{
					this.bodyTrackingStoppedTime = null;
					var bodies = new Body[bodyFrame.BodyCount];
					// The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
					// As long as those body objects are not disposed and not set to null in the array,
					// those body objects will be re-used.
					bodyFrame.GetAndRefreshBodyData(bodies);

					var trackedBodies = bodies.Where(b => b != null && b.IsTracked);
					trackedBodiesCount = trackedBodies.Count();
					this.currentTrackedBody = trackedBodiesCount == 1 ? trackedBodies.FirstOrDefault() : null;
				}
				else
					this.currentTrackedBody = null;

				using (var dc = this.bodyImageDrawingGroup.Open())
				{
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

						this.currentTrackedBodyJointsColorSpacePointsDict = ConvertToColorSpace(this.currentTrackedBody);
						var trackedBodyColorSpacePoints = this.currentTrackedBodyJointsColorSpacePointsDict?.ToDictionary(
							kv => kv.Key, kv => new Point(kv.Value.X, kv.Value.Y));

						// Draw a transparent background to set the render size
						dc.DrawRectangle(Brushes.Transparent, null, new Rect(0.0, 0.0, this.displayImageWidth, this.displayImageHeight));

						// Process body data
						if (trackedBodyColorSpacePoints != null)
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
				}

				switch (this.TrackingState)
				{
					case BodyTrackingState.Standard:
						if (!CheckIfColorFrameIsNull(colorFrame, false) && !CheckIfNoneTrackedUsers(trackedBodiesCount, false))
							CheckIfMoreTrackedUsers(trackedBodiesCount);
						break;
					case BodyTrackingState.GestureToStartGestureRecording:
					case BodyTrackingState.GestureToStartGestureRecognizing:
						if (!CheckIfColorFrameIsNull(colorFrame, false) && !CheckIfNoneTrackedUsers(trackedBodiesCount, false))
							CheckIfMoreTrackedUsers(trackedBodiesCount);
						break;
					case BodyTrackingState.WaitingToStartGestureRecording:
					case BodyTrackingState.WaitingToStartGestureRecognizing:
						if (!CheckIfColorFrameIsNull(colorFrame) && !CheckIfNoneTrackedUsers(trackedBodiesCount))
							CheckIfMoreTrackedUsers(trackedBodiesCount);
						break;
					case BodyTrackingState.GestureRecording:
						if (CheckIfColorFrameIsNull(colorFrame) || CheckIfNoneTrackedUsers(trackedBodiesCount) || CheckIfMoreTrackedUsers(trackedBodiesCount))
						{
							StopGestureRecording(true);
						}
						else if (!CheckIfStopGestureRecording(prevTrackedBodyJointsColorSpacePointsDict))
						{
							if ((this.gestureRecorder.Options & KinectRecordOptions.Color) != 0)
								this.gestureRecorder.Record(colorFrame);
							if ((this.gestureRecorder.Options & KinectRecordOptions.Bodies) != 0)
								this.gestureRecorder.Record(bodyFrame, new[] { (this.currentTrackedBody, this.currentTrackedBodyJointsColorSpacePointsDict) });
						}
						break;
					case BodyTrackingState.GestureToRecognizeRecording:
						if (!CheckIfColorFrameIsNull(colorFrame) && !CheckIfNoneTrackedUsers(trackedBodiesCount) && !CheckIfMoreTrackedUsers(trackedBodiesCount))
						{
							if (!CheckIfStopGestureRecording(prevTrackedBodyJointsColorSpacePointsDict))
								this.gestureToRecognizeBodyFrames.Add(new BodyData(this.currentTrackedBody));
						}
						else
							CleanGestureToRecognizeBodyFrames();
						break;
				}

				SendTrackedUsersCountChangedMessage(trackedBodiesCount);
				UpdateLastDisplayedColorFrameTimeAndSendMessage(colorFrame != null);
			}
			finally
			{
				if (colorImageLocked)
					this.colorImage.Unlock();
				if (colorFrame != null)
					colorFrame.Dispose();
				if (bodyFrame != null)
					bodyFrame.Dispose();
			}
		}

		/// <summary>
		/// Handles the event which the sensor becomes unavailable (E.g. paused, closed, unplugged)
		/// </summary>
		/// <param name="sender">Object sending the event</param>
		/// <param name="e">Event arguments</param>
		private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
		{
			// On failure, set the status text
			if (this.kinectSensor != null)
			{
				string statusText = this.IsKinectAvailable ? Properties.Resources.RunningStatusText : Properties.Resources.NoSensorStatusText;
				Messenger.Default.Send(new KinectStatusMessage() 
				{ 
					PrevState = this.TrackingState,
					Text = statusText 
				});

				if (!this.IsKinectAvailable)
				{
					if (this.TrackingState == BodyTrackingState.GestureRecording)
						StopGestureRecording(true);
					UpdateBodyTrackingStoppedStatusAndSendMessage(true, Properties.Resources.LostKinectConnection);
				}
				else
					SetStandardState();
			}
		}
		#endregion

		#region Convert body joints coordinations to color coordinations methods
		private BodyJointsColorSpacePointsDict ConvertToColorSpace(Body body)
		{
			return ConvertToColorSpace(new[] { body }).FirstOrDefault().Item2;
		}

		private IEnumerable<(Body, BodyJointsColorSpacePointsDict)> ConvertToColorSpace(IEnumerable<Body> bodies)
		{
			if (bodies == null || !bodies.Any())
				return Enumerable.Empty<(Body, BodyJointsColorSpacePointsDict)>();

			return bodies.Select(b => (b, ConvertToColorSpace(b?.Joints)));
		}

		private BodyJointsColorSpacePointsDict ConvertToColorSpace(IReadOnlyDictionary<JointType, Joint> joints)
		{
			var jointsPoints = new BodyJointsColorSpacePointsDict();

			if (joints != null)
			{
				foreach (var jointType in joints.Keys)
				{
					var position = joints[jointType].Position;
					jointsPoints[jointType] = this.coordinateMapper.MapCameraPointToColorSpace(position);
				}
			}

			return jointsPoints;
		}
		#endregion

		#region Detecting gestures to start recording / recognizing given gesture
		private bool UpdateGestureToStartRecordingDetectionState(Body trackedBody)
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
						Messenger.Default.Send(new TemporaryStateStartedMessage());
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

		private bool UpdateGestureToStartRecognizingDetectionState(Body trackedBody)
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
						Messenger.Default.Send(new TemporaryStateStartedMessage());
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
			this.gestureRecorder = new KinectRecorder(isGestureToRecognize ? KinectRecordOptions.Bodies : KinectRecordOptions.All,
				this.gestureRecordFile, Consts.GestureRecordResizingCoef);
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
					Messenger.Default.Send(new GestureRecordingFinishedMessage());
					this.gestureRecordUserWithoutMovementStartTime = null;
					return true;
				}

				if (CompareBodyJointsColorSpacePointsDict(prevDict))
				{
					if (this.gestureRecordUserWithoutMovementStartTime.HasValue)
					{
						if (DateTime.Now - this.gestureRecordUserWithoutMovementStartTime >= gestureRecordUserWithoutMovementTimeLimit)
						{
							Messenger.Default.Send(new GestureRecordingFinishedMessage());
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

				if (!this.currentTrackedBodyJointsColorSpacePointsDict.TryGetValue(joint, out ColorSpacePoint currentPosition))
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
			Messenger.Default.Send(new TrackedUsersCountChangedMessage()
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

				Messenger.Default.Send(new BodyTrackingStoppedMessage()
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
				Messenger.Default.Send(new FPSValueMessage() { Value = 1 / (now - this.lastDisplayedColorFrameTime).TotalSeconds });
				this.lastDisplayedColorFrameTime = now;
			}
			else
				Messenger.Default.Send(new FPSValueMessage() { Value = 0d });
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
