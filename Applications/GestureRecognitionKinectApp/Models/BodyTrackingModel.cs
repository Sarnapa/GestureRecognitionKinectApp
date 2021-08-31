using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Utilities;
using GestureRecognition.Processing.BaseClassLib.Structures.Kinect;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record;

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
		/// Determines time when body tracking process has been stopped
		/// </summary>
		private DateTime? bodyTrackingStoppedTime;

		/// <summary>
		/// Determines time when gesture recording has started
		/// </summary>
		private DateTime? gestureRecordStartTime;

		/// <summary>
		/// Determines time when user has shown gesture to start recording
		/// </summary>
		private DateTime? gestureToStartRecordingStartTime;

		/// <summary>
		/// To calculate FPS value
		/// </summary>
		private DateTime lastDisplayedColorFrameTime;
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
			get; set;
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
		#endregion

		#region Constructors
		public BodyTrackingModel()
		{
			this.renderColorFrameManager = new RenderColorFrameManager();
			this.renderBodyFrameManager = new RenderBodyFrameManager();
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
			if (this.TrackingState == BodyTrackingState.Standard || this.TrackingState == BodyTrackingState.WaitingToStartRecordingGesture)
				StartGestureRecording();
			else if (this.TrackingState == BodyTrackingState.RecordingGesture)
				StopGestureRecording();
		}

		public void Cleanup(bool deleteGestureRecordFile = true)
		{
			CleanGestureRecorder(deleteGestureRecordFile);

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
			BodyJointsColorSpacePointsDict trackedBodyJointsColorSpacePointsDict = null;
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

						if (this.TrackingState == BodyTrackingState.Standard || this.TrackingState == BodyTrackingState.GestureToStartRecording)
							UpdateGestureToStartRecordingDetectionState(this.currentTrackedBody);

						trackedBodyJointsColorSpacePointsDict = ConvertToColorSpace(this.currentTrackedBody);
						var trackedBodyColorSpacePoints = trackedBodyJointsColorSpacePointsDict?.ToDictionary(
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
					case BodyTrackingState.GestureToStartRecording:
						if (!CheckIfColorFrameIsNull(colorFrame, false) && !CheckIfNoneTrackedUsers(trackedBodiesCount, false))
							CheckIfMoreTrackedUsers(trackedBodiesCount);
						break;
					case BodyTrackingState.WaitingToStartRecordingGesture:
						if (!CheckIfColorFrameIsNull(colorFrame) && !CheckIfNoneTrackedUsers(trackedBodiesCount))
							CheckIfMoreTrackedUsers(trackedBodiesCount);
						break;
					case BodyTrackingState.RecordingGesture:
						if (CheckIfColorFrameIsNull(colorFrame) || CheckIfNoneTrackedUsers(trackedBodiesCount) || CheckIfMoreTrackedUsers(trackedBodiesCount))
						{
							StopGestureRecording(true);
						}
						else if (!CheckIfStopGestureRecording())
						{
							if ((this.gestureRecorder.Options & KinectRecordOptions.Color) != 0)
								this.gestureRecorder.Record(colorFrame);
							if ((this.gestureRecorder.Options & KinectRecordOptions.Bodies) != 0)
								this.gestureRecorder.Record(bodyFrame, new[] { (this.currentTrackedBody, trackedBodyJointsColorSpacePointsDict) });
						}
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

				if (!this.IsKinectAvailable && this.TrackingState == BodyTrackingState.RecordingGesture)
				{
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
				if (this.gestureToStartRecordingStartTime.HasValue)
				{
					TimeSpan duration = DateTime.Now - this.gestureToStartRecordingStartTime.Value;
					if (duration >= Consts.GestureToStartRecordingTimeLimit)
					{
						this.gestureToStartRecordingStartTime = null;
						this.TrackingState = BodyTrackingState.WaitingToStartRecordingGesture;
						Messenger.Default.Send(new TemporaryStateStartedMessage());
					}
				}
				else
				{
					this.gestureToStartRecordingStartTime = DateTime.Now;
					this.TrackingState = BodyTrackingState.GestureToStartRecording;
				}
			}
			else
			{
				this.gestureToStartRecordingStartTime = null;
				this.TrackingState = BodyTrackingState.Standard;
			}

			return isRightHandClosed;
		}
		#endregion

		#region Gesture recording methods
		private void CreateTemporaryRecordFile()
		{
			string fileName = $"{Utils.RandomString(32)}{Consts.GestureRecordFileExtension}";
			this.gestureRecordFile = File.Create(fileName);
			File.SetAttributes(fileName, File.GetAttributes(fileName) | FileAttributes.Hidden);
		}

		private void StartGestureRecording()
		{
			CreateTemporaryRecordFile();
			this.gestureRecorder = new KinectRecorder(KinectRecordOptions.All, this.gestureRecordFile,
				Consts.GestureRecordResizingCoef);
			this.gestureToStartRecordingStartTime = null;
			this.gestureRecordStartTime = DateTime.Now;
			this.TrackingState = BodyTrackingState.RecordingGesture;
		}

		private bool CheckIfStopGestureRecording()
		{
			if (this.TrackingState == BodyTrackingState.RecordingGesture && this.gestureRecordStartTime.HasValue)
			{
				TimeSpan duration = DateTime.Now - this.gestureRecordStartTime.Value;
				if (duration >= Consts.GestureRecordTimeLimit)
				{
					Messenger.Default.Send(new GestureRecordingFinishedMessage());
					return true;
				}
			}

			return false;
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
			if (this.gestureToStartRecordingStartTime != null)
				this.gestureToStartRecordingStartTime = null;
			if (this.currentTrackedBody != null)
				this.currentTrackedBody = null;
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
		#endregion

		#endregion
	}
}
