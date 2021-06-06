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
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Structures;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class BodyTrackingModel
	{
		#region Private / protected fields
		/// <summary>
		/// Time limit for gesture record
		/// </summary>
		private readonly TimeSpan gestureRecordTimeLimit = TimeSpan.FromSeconds(10);

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

		private DateTime startGestureRecordTime;

		private DateTime lastDisplayedColorFrameTime;
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

		public void StartStopRecordingGesture()
		{
			if (this.TrackingState == BodyTrackingState.Standard)
			{
				CreateTemporaryRecordFile();
				this.gestureRecorder = new KinectRecorder(KinectRecordOptions.All, this.gestureRecordFile,
					Consts.GestureRecordResizingCoef);
				this.startGestureRecordTime = DateTime.Now;
				this.TrackingState = BodyTrackingState.RecordingGesture;
			}
			else if (this.TrackingState == BodyTrackingState.RecordingGesture)
			{
				this.gestureRecorder.Stop();
				CleanGestureRecorder(false);
			}
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

			try
			{
				colorFrame = multiSourceFrame.ColorFrameReference.AcquireFrame();
				bodyFrame = multiSourceFrame.BodyFrameReference.AcquireFrame();

				if (colorFrame != null)
				{
					this.colorImage.Lock();
					colorImageLocked = true;

					if (this.gestureRecorder != null && (this.gestureRecorder.Options & KinectRecordOptions.Color) != 0)
						this.gestureRecorder.Record(colorFrame);

					this.renderColorFrameManager.ProcessColorFrame(colorFrame, this.displayImageWidth, this.displayImageHeight,
						ref this.colorImage);

					this.colorImage.Unlock();
					colorImageLocked = false;

					if (bodyFrame != null && bodyFrame.BodyCount > 0)
					{
						var bodies = new Body[bodyFrame.BodyCount];
						// The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
						// As long as those body objects are not disposed and not set to null in the array,
						// those body objects will be re-used.
						bodyFrame.GetAndRefreshBodyData(bodies);

						var trackedBodies = bodies.Where(b => b != null && b.IsTracked);
						int trackedBodiesCount = trackedBodies.Count();
						Messenger.Default.Send(new TrackedUsersCountChangedMessage()
						{
							Count = trackedBodiesCount
						});

						var trackedBodiesData = ConvertToColorSpace(trackedBodies);

						if (this.gestureRecorder != null && (this.gestureRecorder.Options & KinectRecordOptions.Bodies) != 0)
							this.gestureRecorder.Record(bodyFrame, trackedBodiesData);

						using (var dc = this.bodyImageDrawingGroup.Open())
						{
							if (trackedBodiesCount > 0)
							{
								// Only one user movements can be processed.
								if (trackedBodiesCount != 1)
								{
									string basicText = $"Detected {trackedBodiesCount} users.\nOnly one user movemenets can be tracked.";
									string gestureRecorderText = $"Gesture recording has been cancelled.";

									Messenger.Default.Send(new StoppedBodyTrackingMessage()
									{
										IsStopped = true,
										Text = this.TrackingState == BodyTrackingState.RecordingGesture ?
											$"{basicText}\n{gestureRecorderText}" : basicText
									});

									CleanGestureRecorder();
									UpdateLastDisplayedColorFrameTime();
									return;
								}
								else
								{
									Messenger.Default.Send(new StoppedBodyTrackingMessage()
									{
										IsStopped = false,
									});
								}

								// Draw a transparent background to set the render size
								dc.DrawRectangle(Brushes.Transparent, null, new Rect(0.0, 0.0, this.displayImageWidth, this.displayImageHeight));

								var trackedBodyData = trackedBodiesData.FirstOrDefault();
								var trackedBody = trackedBodyData.Item1;
								var trackedBodyColorSpacePoints = trackedBodyData.Item2?.ToDictionary(
									kv => kv.Key, kv => new Point(kv.Value.X, kv.Value.Y));
								// Process body data
								if (trackedBody != null && trackedBodyColorSpacePoints != null)
								{
									this.renderBodyFrameManager.DrawBody(trackedBody.Joints, trackedBodyColorSpacePoints, dc, 0);

									if (trackedBodyColorSpacePoints.ContainsKey(JointType.HandLeft))
										this.renderBodyFrameManager.DrawHand(trackedBody.HandLeftState, trackedBodyColorSpacePoints[JointType.HandLeft], dc);
									if (trackedBodyColorSpacePoints.ContainsKey(JointType.HandRight))
										this.renderBodyFrameManager.DrawHand(trackedBody.HandRightState, trackedBodyColorSpacePoints[JointType.HandRight], dc);

									// prevent drawing outside of our render area
									this.bodyImageDrawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, this.displayImageWidth, this.displayImageHeight));
								}
							}
						}
					}

					UpdateLastDisplayedColorFrameTime();
				}
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
				string statusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
																												: Properties.Resources.NoSensorStatusText;
				Messenger.Default.Send(new KinectStatusMessage() { Text = statusText });
			}
		}
		#endregion

		#region Convert body joints coordinations to color coordinations methods
		private IEnumerable<(Body, BodyJointsColorSpacePointsDict)> ConvertToColorSpace(IEnumerable<Body> bodies)
		{
			if (bodies == null || !bodies.Any())
				return Enumerable.Empty<(Body, BodyJointsColorSpacePointsDict)>();

			return bodies.Select(b => (b, ConvertToColorSpace(b.Joints)));
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

		#region Gesture recording methods
		private void CreateTemporaryRecordFile()
		{
			string fileName = $"{Utils.RandomString(32)}{Consts.GestureRecordFileExtension}";
			this.gestureRecordFile = File.Create(fileName);
			File.SetAttributes(fileName, File.GetAttributes(fileName) | FileAttributes.Hidden);
		}

		private void CleanGestureRecorder(bool deleteGestureRecordFile = true)
		{
			this.TrackingState = BodyTrackingState.Standard;
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
		private void UpdateLastDisplayedColorFrameTime()
		{
			var now = DateTime.Now;
			Messenger.Default.Send(new FPSValueMessage() { Value = 1 / (now - this.lastDisplayedColorFrameTime).TotalSeconds });
			this.lastDisplayedColorFrameTime = now;
		}
		#endregion

		#endregion
	}
}
