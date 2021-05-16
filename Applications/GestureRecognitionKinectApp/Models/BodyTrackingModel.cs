using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Helpers;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class BodyTrackingModel
	{
		#region Private / protected fields
		/// <summary>
		/// Render skeleton data
		/// </summary>
		private readonly DrawSkeletonManager drawSkeletonManager;

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

		private DateTime lastDisplayedColorFrameTime;
		#endregion

		#region Public properties
		public ImageSource ColorImage
		{
			get
			{
				return this.colorImage;
			}
		}

		public ImageSource BodyImage
		{
			get
			{
				return this.bodyImage;
			}
		}
		#endregion

		#region Constructors
		public BodyTrackingModel()
		{
			this.drawSkeletonManager = new DrawSkeletonManager();
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

			Messenger.Default.Send(new DisplayImageChangedMessage() { Changed = true });

			// Open the sensor
			this.kinectSensor.Open();

			// Set the status text
			string statusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
																											: Properties.Resources.NoSensorStatusText;
			Messenger.Default.Send(new KinectStatusMessage() { Text = statusText });

			if (this.multiSourceReader != null)
				this.multiSourceReader.MultiSourceFrameArrived += this.Reader_FrameArrived;
		}

		public void Cleanup()
		{
			if (this.multiSourceReader != null)
			{
				this.multiSourceReader.Dispose();
				this.multiSourceReader = null;
			}

			if (this.kinectSensor != null)
			{
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

					// Process color frame
					var colorFrameDescription = colorFrame.FrameDescription;
					using (var colorBuffer = colorFrame.LockRawImageBuffer())
					{
						// Verify data and write the new color frame data to the display bitmap
						if ((colorFrameDescription.Width == this.displayImageWidth) && (colorFrameDescription.Height == this.displayImageHeight))
						{
							colorFrame.CopyConvertedFrameDataToIntPtr(
								this.colorImage.BackBuffer,
								(uint)(this.displayImageWidth * this.displayImageHeight * 4),
								ColorImageFormat.Bgra);

							this.colorImage.AddDirtyRect(new Int32Rect(0, 0, this.displayImageWidth, this.displayImageHeight));
						}
					}

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

						using (var dc = this.bodyImageDrawingGroup.Open())
						{
							if (trackedBodiesCount > 0)
							{
								// Only one user movements can be processed.
								if (trackedBodiesCount != 1)
								{
									Messenger.Default.Send(new StoppedBodyTrackingMessage()
									{
										IsStopped = true,
										Text = $"Detected {trackedBodiesCount} users.\nOnly one user movemenets can be tracked."
									});

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

								var trackedBody = trackedBodies.FirstOrDefault();
								// Process body data
								if (trackedBody != null)
								{
									var joints = trackedBody.Joints;
									// Convert the joint points to display space
									var jointPoints = new Dictionary<JointType, Point>();

									foreach (var jointType in joints.Keys)
									{
										var position = joints[jointType].Position;
										var mapSpacePoint = this.coordinateMapper.MapCameraPointToColorSpace(position);
										jointPoints[jointType] = new Point(mapSpacePoint.X, mapSpacePoint.Y);
									}

									this.drawSkeletonManager.DrawBody(joints, jointPoints, dc, 0);

									this.drawSkeletonManager.DrawHand(trackedBody.HandLeftState, jointPoints[JointType.HandLeft], dc);
									this.drawSkeletonManager.DrawHand(trackedBody.HandRightState, jointPoints[JointType.HandRight], dc);

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
			string statusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
																											: Properties.Resources.NoSensorStatusText;
			Messenger.Default.Send(new KinectStatusMessage() { Text = statusText });
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
