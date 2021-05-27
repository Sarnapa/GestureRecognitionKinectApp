using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Microsoft.Kinect;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers
{
	public class RenderBodyFrameManager
	{
		#region Private fields
		/// <summary>
		/// Radius of drawn hand circles
		/// </summary>
		private const double HandSize = 15;

		/// <summary>
		/// Thickness of drawn joint lines
		/// </summary>
		private const double JointThickness = 8;

		/// <summary>
		/// Thickness of drawn joint lines (that joint taking part in gesture recognition processing)
		/// </summary>
		private const double GestureRecognitionJointThickness = 12;

		/// <summary>
		/// Joint taking part in gesture recognition processing
		/// </summary>
		private readonly JointType[] gestureRecognitionJoints = new JointType[] {JointType.ElbowLeft, JointType.ElbowRight,
			JointType.WristLeft, JointType.WristRight, JointType.HandLeft, JointType.HandRight, JointType.ThumbLeft, JointType.ThumbRight,
			JointType.HandTipLeft, JointType.HandTipRight};

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
		/// Definition of bones
		/// </summary>
		private readonly List<Tuple<JointType, JointType>> bones;

		/// <summary>
		/// List of colors for each body tracked
		/// </summary>
		private readonly List<Pen> bodyColors;

		// TODO: Facilitate to set this option in user settings.
		/// <summary>
		/// Is it enabled mode to draw inferred bones and joints?
		/// </summary>
		private bool isInferredMode = false;
		#endregion

		#region Constructors
		public RenderBodyFrameManager()
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
		/// <summary>
		/// Draws a body
		/// </summary>
		/// <param name="joints">Joints to draw</param>
		/// <param name="jointPoints">Translated positions of joints to draw</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		/// <param name="bodyIdx">Body index</param>
		public void DrawBody(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, DrawingContext drawingContext, int bodyIdx)
		{
			if (bodyIdx < 0 || bodyIdx >= this.bodyColors.Count)
				throw new ArgumentException(nameof(bodyIdx));

			var bodyPen = this.bodyColors[bodyIdx];

			// Draw the bones
			foreach (var bone in this.bones)
			{
				this.DrawBone(joints, jointPoints, bone.Item1, bone.Item2, drawingContext, bodyPen);
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
		/// Draws a hand symbol if the hand is tracked: red circle = closed, green circle = opened; blue circle = lasso
		/// </summary>
		/// <param name="handState">State of the hand</param>
		/// <param name="handPosition">Position of the hand</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		public void DrawHand(HandState handState, Point handPosition, DrawingContext drawingContext)
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
		#endregion

		#region Private methods
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
		#endregion
	}
}
