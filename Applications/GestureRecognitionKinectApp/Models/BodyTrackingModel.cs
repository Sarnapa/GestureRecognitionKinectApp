using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class BodyTrackingModel
	{
		#region Private / protected fields
		/// <summary>
		/// Radius of drawn hand circles
		/// </summary>
		private const double HandSize = 30;

		/// <summary>
		/// Thickness of drawn joint lines
		/// </summary>
		private const double JointThickness = 10;

		/// <summary>
		/// Thickness of drawn joint lines (that joint taking part in gesture recognition processing)
		/// </summary>
		private const double GestureRecognitionJointThickness = 25;

		/// <summary>
		/// Thickness of clip edge rectangles
		/// </summary>
		private const double ClipBoundsThickness = 10;

		/// <summary>
		/// Joint taking part in gesture recognition processing
		/// </summary>
		private readonly JointType[] gestureRecognitionJoints = new JointType[] {JointType.ElbowLeft, JointType.ElbowRight,
			JointType.WristLeft, JointType.WristRight, JointType.HandLeft, JointType.HandRight};

		/// <summary>
		/// Not drawn joints
		/// </summary>
		private readonly JointType[] jointsToIgnore = new JointType[] {JointType.KneeLeft, JointType.KneeRight, JointType.AnkleLeft,
			JointType.AnkleRight, JointType.FootLeft, JointType.FootRight};

		/// <summary>
		/// Brush used for drawing hands that are currently tracked as closed
		/// </summary>
		private readonly Brush handClosedBrush = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));

		/// <summary>
		/// Brush used for drawing hands that are currently tracked as opened
		/// </summary>
		private readonly Brush handOpenBrush = new SolidColorBrush(Color.FromArgb(128, 0, 255, 0));

		/// <summary>
		/// Brush used for drawing hands that are currently tracked as in lasso (pointer) position
		/// </summary>
		private readonly Brush handLassoBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));

		/// <summary>
		/// Brush used for drawing joints that are currently tracked
		/// </summary>
		private readonly Brush trackedJointBrush = new SolidColorBrush(Color.FromArgb(255, 68, 192, 68));

		/// <summary>
		/// Brush used for drawing joints that are currently tracked (that joint taking part in gesture recognition processing)
		/// </summary>
		private readonly Brush trackedGestureRecognitionJointBrush = new SolidColorBrush(Color.FromArgb(255, 128, 0, 128));

		/// <summary>
		/// Brush used for drawing joints that are currently inferred
		/// </summary>        
		private readonly Brush inferredJointBrush = Brushes.Yellow;

		/// <summary>
		/// Pen used for drawing bones that are currently inferred
		/// </summary>        
		private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);

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
		/// Definition of bones
		/// </summary>
		private List<Tuple<JointType, JointType>> bones;

		/// <summary>
		/// List of colors for each body tracked
		/// </summary>
		private List<Pen> bodyColors;

		// TODO: Facilitate to set this option in user settings.
		/// <summary>
		/// Is it enabled mode to draw inferred bones and joints?
		/// </summary>
		private bool isInferredMode = false;

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
			this.bones = new List<Tuple<JointType, JointType>>();

			// Torso
			this.bones.Add(new Tuple<JointType, JointType>(JointType.Head, JointType.Neck));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.Neck, JointType.SpineShoulder));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.SpineMid));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineMid, JointType.SpineBase));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderRight));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderLeft));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipRight));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipLeft));

			// Right Arm
			this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderRight, JointType.ElbowRight));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowRight, JointType.WristRight));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.HandRight));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.HandRight, JointType.HandTipRight));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.ThumbRight));

			// Left Arm
			this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderLeft, JointType.ElbowLeft));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowLeft, JointType.WristLeft));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.HandLeft));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.HandLeft, JointType.HandTipLeft));
			this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.ThumbLeft));

			// Right Leg
			//this.bones.Add(new Tuple<JointType, JointType>(JointType.HipRight, JointType.KneeRight));
			//this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeRight, JointType.AnkleRight));
			//this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleRight, JointType.FootRight));

			// Left Leg
			//this.bones.Add(new Tuple<JointType, JointType>(JointType.HipLeft, JointType.KneeLeft));
			//this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeLeft, JointType.AnkleLeft));
			//this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleLeft, JointType.FootLeft));

			// Populate body colors, one for each BodyIndex
			this.bodyColors = new List<Pen>();
			this.bodyColors.Add(new Pen(Brushes.Red, 10));
			this.bodyColors.Add(new Pen(Brushes.Orange, 10));
			this.bodyColors.Add(new Pen(Brushes.Green, 10));
			this.bodyColors.Add(new Pen(Brushes.Blue, 10));
			this.bodyColors.Add(new Pen(Brushes.Indigo, 10));
			this.bodyColors.Add(new Pen(Brushes.Violet, 10));
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
									var drawPen = this.bodyColors[0];

									var joints = trackedBody.Joints;
									// Convert the joint points to display space
									var jointPoints = new Dictionary<JointType, Point>();

									foreach (var jointType in joints.Keys)
									{
										var position = joints[jointType].Position;
										var mapSpacePoint = this.coordinateMapper.MapCameraPointToColorSpace(position);
										jointPoints[jointType] = new Point(mapSpacePoint.X, mapSpacePoint.Y);
									}

									this.DrawBody(joints, jointPoints, dc, drawPen);

									this.DrawHand(trackedBody.HandLeftState, jointPoints[JointType.HandLeft], dc);
									this.DrawHand(trackedBody.HandRightState, jointPoints[JointType.HandRight], dc);

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

		#region Drawing body parts methods
		/// <summary>
		/// Draws a body
		/// </summary>
		/// <param name="joints">Joints to draw</param>
		/// <param name="jointPoints">Translated positions of joints to draw</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		/// <param name="drawingPen">Specifies color to draw a specific body</param>
		private void DrawBody(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, DrawingContext drawingContext, Pen drawingPen)
		{
			// Draw the bones
			foreach (var bone in this.bones)
			{
				this.DrawBone(joints, jointPoints, bone.Item1, bone.Item2, drawingContext, drawingPen);
			}

			// Draw the joints
			foreach (var jointType in joints.Keys)
			{
				if (this.jointsToIgnore.Contains(jointType))
					continue;

				Brush drawBrush = null;
				double drawThickness = JointThickness;

				var trackingState = joints[jointType].TrackingState;

				if (this.gestureRecognitionJoints.Contains(jointType) && trackingState == TrackingState.Tracked)
				{
					drawBrush = this.trackedGestureRecognitionJointBrush;
					drawThickness = GestureRecognitionJointThickness;
				}
				else if (trackingState == TrackingState.Tracked)
				{
					drawBrush = this.trackedJointBrush;
				}
				else if (this.isInferredMode && trackingState == TrackingState.Inferred)
				{
					drawBrush = this.inferredJointBrush;
				}

				if (drawBrush != null)
				{
					drawingContext.DrawEllipse(drawBrush, null, jointPoints[jointType], drawThickness, drawThickness);
				}
			}
		}

		/// <summary>
		/// Draws one bone of a body (joint to joint)
		/// </summary>
		/// <param name="joints">Joints to draw</param>
		/// <param name="jointPoints">Translated positions of joints to draw</param>
		/// <param name="jointType0">First joint of bone to draw</param>
		/// <param name="jointType1">Second joint of bone to draw</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		/// /// <param name="drawingPen">Specifies color to draw a specific bone</param>
		private void DrawBone(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, JointType jointType0, JointType jointType1, DrawingContext drawingContext,
			Pen drawingPen)
		{
			Joint joint0 = joints[jointType0];
			Joint joint1 = joints[jointType1];

			// If we can't find either of these joints, exit
			if (joint0.TrackingState == TrackingState.NotTracked ||
				joint1.TrackingState == TrackingState.NotTracked)
			{
				return;
			}

			if (!this.isInferredMode && (joint0.TrackingState == TrackingState.Inferred ||
				joint1.TrackingState == TrackingState.Inferred))
			{
				return;
			}

			Pen drawPen = this.inferredBonePen;
			if ((joint0.TrackingState == TrackingState.Tracked) && (joint1.TrackingState == TrackingState.Tracked))
			{
				drawPen = drawingPen;
			}

			drawingContext.DrawLine(drawPen, jointPoints[jointType0], jointPoints[jointType1]);
		}

		/// <summary>
		/// Draws a hand symbol if the hand is tracked: red circle = closed, green circle = opened; blue circle = lasso
		/// </summary>
		/// <param name="handState">State of the hand</param>
		/// <param name="handPosition">Position of the hand</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		private void DrawHand(HandState handState, Point handPosition, DrawingContext drawingContext)
		{
			switch (handState)
			{
				case HandState.Closed:
					drawingContext.DrawEllipse(this.handClosedBrush, null, handPosition, HandSize, HandSize);
					break;

				case HandState.Open:
					drawingContext.DrawEllipse(this.handOpenBrush, null, handPosition, HandSize, HandSize);
					break;

				case HandState.Lasso:
					drawingContext.DrawEllipse(this.handLassoBrush, null, handPosition, HandSize, HandSize);
					break;
			}
		}

		/// <summary>
		/// Draws indicators to show which edges are clipping body data
		/// </summary>
		/// <param name="body">Body to draw clipping information for</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		private void DrawClippedEdges(Body body, DrawingContext drawingContext)
		{
			var clippedEdges = body.ClippedEdges;

			if (clippedEdges.HasFlag(FrameEdges.Bottom))
			{
				drawingContext.DrawRectangle(
					Brushes.Red,
					null,
					new Rect(0, this.displayImageHeight - ClipBoundsThickness, this.displayImageWidth, ClipBoundsThickness));
			}

			if (clippedEdges.HasFlag(FrameEdges.Top))
			{
				drawingContext.DrawRectangle(
					Brushes.Red,
					null,
					new Rect(0, 0, this.displayImageWidth, ClipBoundsThickness));
			}

			if (clippedEdges.HasFlag(FrameEdges.Left))
			{
				drawingContext.DrawRectangle(
					Brushes.Red,
					null,
					new Rect(0, 0, ClipBoundsThickness, this.displayImageHeight));
			}

			if (clippedEdges.HasFlag(FrameEdges.Right))
			{
				drawingContext.DrawRectangle(
					Brushes.Red,
					null,
					new Rect(this.displayImageWidth - ClipBoundsThickness, 0, ClipBoundsThickness, this.displayImageHeight));
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
