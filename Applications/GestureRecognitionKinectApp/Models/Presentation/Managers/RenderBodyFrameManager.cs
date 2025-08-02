using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Structures.Managers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Bodies;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers
{
	public class RenderBodyFrameManager
	{
		#region Private fields
		/// <summary>
		/// Radius of drawn hand circles
		/// </summary>
		private readonly double handSize = KinectRenderBodyFrameConsts.HAND_SIZE;

		/// <summary>
		/// Thickness of drawn joint
		/// </summary>
		private readonly double jointThickness = KinectRenderBodyFrameConsts.JOINT_THICKNESS;

		/// <summary>
		/// Thickness of drawn joint (that joint taking part in gesture recognition processing)
		/// </summary>
		private readonly double gestureRecognitionJointThickness = KinectRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS;

		/// <summary>
		/// Thickness of lines representing user skeleton
		/// </summary>
		private readonly double bodySkeletonThickness = KinectRenderBodyFrameConsts.BODY_SKELETON_THICKNESS;

		/// <summary>
		/// Not drawn joints
		/// </summary>
		private readonly JointType[] jointsToIgnore = KinectRenderBodyFrameConsts.JOINTS_TO_IGNORE;

		/// <summary>
		/// Joints involved in the gesture recognition process
		/// </summary>
		private readonly JointType[] gestureRecognitionJoints = KinectGestureRecognitionDefinitions.GestureRecognitionJoints;

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
		private readonly Bone[] bones = KinectBonesDefinitions.AllBonesWithoutLegs.ToArray();

		/// <summary>
		/// List of colors for each body tracked
		/// </summary>
		private readonly Pen[] bodyColors = [];

		// TODO: Facilitate to set this option in user settings.
		/// <summary>
		/// Is it enabled mode to draw inferred bones and joints?
		/// </summary>
		private readonly bool isInferredMode = false;
		#endregion

		#region Constructors
		public RenderBodyFrameManager(RenderBodyFrameManagerParameters parameters)
		{
			if (parameters != null)
			{
				this.handSize = parameters.HandSize;
				this.jointThickness = parameters.JointThickness;
				this.gestureRecognitionJointThickness = parameters.GestureRecognitionJointThickness;
				this.bodySkeletonThickness = parameters.BodySkeletonThickness;
				this.jointsToIgnore = parameters.JointsToIgnore ?? [];
				this.gestureRecognitionJoints = parameters.GestureRecognitionJoints ?? [];
				this.bones = parameters.Bones ?? [];
				this.isInferredMode = parameters.IsInferredMode;
			}

			if (parameters?.ResizingCoef != 1.0f)
			{
				this.handSize *= parameters.ResizingCoef;
				this.jointThickness *= parameters.ResizingCoef;
				this.gestureRecognitionJointThickness *= parameters.ResizingCoef;
				this.bodySkeletonThickness *= parameters.ResizingCoef;
			}

			this.bodyColors = GetBodyColors();
		}

		public RenderBodyFrameManager(float resizingCoef)
		{
			if (resizingCoef != 1.0f)
			{
				this.handSize *= resizingCoef;
				this.jointThickness *= resizingCoef;
				this.gestureRecognitionJointThickness *= resizingCoef;
				this.bodySkeletonThickness *= resizingCoef;
			}

			this.bodyColors = GetBodyColors();
		}
		#endregion

		#region Public methods
		public void ProcessBodyFrame(ReplayBodyFrame bodyFrame, DrawingContext drawingContext)
		{
			if (bodyFrame == null)
				throw new ArgumentNullException(nameof(bodyFrame));
			if (drawingContext == null)
				throw new ArgumentNullException(nameof(drawingContext));

			if (bodyFrame.Bodies != null)
			{
				for (int i = 0; i < bodyFrame.Bodies.Length; i++)
				{
					if (i < this.bodyColors.Length)
					{
						var body = bodyFrame.Bodies[i];
						var bodyColorSpacePoints = body?.JointsColorSpacePoints?.ToDictionary(
							kv => kv.Key, kv => new Point(kv.Value.X, kv.Value.Y));

						if (body != null && bodyColorSpacePoints != null)
						{
							DrawBody(body.Joints, bodyColorSpacePoints, drawingContext, i);

							if (bodyColorSpacePoints.ContainsKey(JointType.HandLeft))
								DrawHand(body.HandLeftState, bodyColorSpacePoints[JointType.HandLeft], drawingContext);
							if (bodyColorSpacePoints.ContainsKey(JointType.HandRight))
								DrawHand(body.HandRightState, bodyColorSpacePoints[JointType.HandRight], drawingContext);
						}
					}
				}
			}
		}

		/// <summary>
		/// Draws a body
		/// </summary>
		/// <param name="joints">Joints to draw</param>
		/// <param name="jointPoints">Translated positions of joints to draw</param>
		/// <param name="drawingContext">Drawing context to draw to</param>
		/// <param name="bodyIdx">Body index</param>
		public void DrawBody(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, DrawingContext drawingContext, int bodyIdx)
		{
			if (bodyIdx < 0 || bodyIdx >= this.bodyColors.Length)
				throw new ArgumentException(nameof(bodyIdx));

			var bodyPen = this.bodyColors[bodyIdx];

			// Draw the bones
			foreach (var bone in this.bones)
			{
				this.DrawBone(joints, jointPoints, bone.ParentJoint, bone.ChildJoint, drawingContext, bodyPen);
			}

			// Draw the joints
			foreach (var jointType in joints.Keys)
			{
				if (this.jointsToIgnore.Contains(jointType))
					continue;

				Brush drawBrush = null;
				double drawThickness = this.jointThickness;

				var trackingState = joints[jointType].TrackingState;

				if (this.gestureRecognitionJoints.Contains(jointType) && trackingState == TrackingState.Tracked)
				{
					drawBrush = this.trackedGestureRecognitionJointBrush;
					drawThickness = this.gestureRecognitionJointThickness;
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
					drawingContext.DrawEllipse(this.handClosedBrush, null, handPosition, handSize, handSize);
					break;

				case HandState.Open:
					drawingContext.DrawEllipse(this.handOpenBrush, null, handPosition, handSize, handSize);
					break;

				case HandState.Lasso:
					drawingContext.DrawEllipse(this.handLassoBrush, null, handPosition, handSize, handSize);
					break;
			}
		}
		#endregion

		#region Private methods
		private Pen[] GetBodyColors()
		{
			// Populate body colors, one for each BodyIndex
			return 
			[
				new Pen(Brushes.Red, this.bodySkeletonThickness),
				new Pen(Brushes.Orange, this.bodySkeletonThickness),
				new Pen(Brushes.Green, this.bodySkeletonThickness),
				new Pen(Brushes.Blue, this.bodySkeletonThickness),
				new Pen(Brushes.Indigo, this.bodySkeletonThickness),
				new Pen(Brushes.Violet, this.bodySkeletonThickness),
			];
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
			if (!joints.TryGetValue(jointType0, out Joint joint0) || !joints.TryGetValue(jointType1, out Joint joint1))
				return;

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
