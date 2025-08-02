using System;
using System.Drawing;
using System.IO;
using System.Linq;
using SkiaSharp;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Tests;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Processing.BaseClassLib.Tests
{
	public class DrawBodyDataManager
	{
		#region Private fields
		private readonly string inputImagePath;
		private readonly string outputImagePath;

		/// <summary>
		/// Radius of drawn hand circles
		/// </summary>
		private readonly float handSize = (float)KinectRenderBodyFrameConsts.HAND_SIZE;

		/// <summary>
		/// Thickness of drawn joint
		/// </summary>
		private readonly float jointThickness = (float)KinectRenderBodyFrameConsts.JOINT_THICKNESS;

		/// <summary>
		/// Thickness of drawn joint (that joint taking part in gesture recognition processing)
		/// </summary>
		private readonly float gestureRecognitionJointThickness = (float)KinectRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS;

		/// <summary>
		/// Thickness of lines representing user skeleton
		/// </summary>
		private readonly float bodySkeletonThickness = (float)KinectRenderBodyFrameConsts.BODY_SKELETON_THICKNESS;

		/// <summary>
		/// Not drawn joints
		/// </summary>
		private readonly JointType[] jointsToIgnore = KinectRenderBodyFrameConsts.JOINTS_TO_IGNORE;

		/// <summary>
		/// Joints involved in the gesture recognition process
		/// </summary>
		private readonly JointType[] gestureRecognitionJoints = KinectGestureRecognitionDefinitions.GestureRecognitionJoints;

		/// <summary>
		/// Color used for drawing hands that are currently tracked as closed
		/// </summary>
		private readonly SKColor handClosedColor = new SKColor(255, 0, 0, 128);

		/// <summary>
		/// Color used for drawing hands that are currently tracked as opened
		/// </summary>
		private readonly SKColor handOpenColor = new SKColor(0, 255, 0, 128);

		/// <summary>
		/// Color used for drawing hands that are currently tracked as in lasso (pointer) position
		/// </summary>
		private readonly SKColor handLassoColor = new SKColor(0, 0, 255, 128);

		/// <summary>
		/// Color used for drawing joints that are currently tracked
		/// </summary>
		private readonly SKColor trackedJointColor = new SKColor(68, 192, 68, 255);

		/// <summary>
		/// Color used for drawing joints that are currently tracked (that joint taking part in gesture recognition processing)
		/// </summary>
		private readonly SKColor trackedGestureRecognitionJointColor = new SKColor(128, 0, 128, 255);

		/// <summary>
		/// Color used for drawing joints that are currently inferred
		/// </summary>        
		private readonly SKColor inferredJointColor = SKColors.Yellow;

		/// <summary>
		/// Color used for drawing bones
		/// </summary>        
		private readonly SKColor boneColor = SKColors.Red;

		/// <summary>
		/// Color used for drawing bones that are currently inferred
		/// </summary>        
		private readonly SKColor inferredBoneColor = SKColors.Gray;

		/// <summary>
		/// Definition of bones
		/// </summary>
		private readonly Bone[] bones = KinectBonesDefinitions.AllBonesWithoutLegs.ToArray();

		// TODO: Facilitate to set this option in user settings.
		/// <summary>
		/// Is it enabled mode to draw inferred bones and joints?
		/// </summary>
		private readonly bool isInferredMode = false;
		#endregion

		#region Constructors
		public DrawBodyDataManager(DrawBodyDataManagerParameters parameters)
		{
			if (string.IsNullOrEmpty(parameters?.InputImagePath))
				throw new ArgumentNullException(nameof(parameters.InputImagePath));
			if (string.IsNullOrEmpty(parameters?.OutputImagePath))
				throw new ArgumentNullException(nameof(parameters.OutputImagePath));

			this.inputImagePath = parameters.InputImagePath;
			this.outputImagePath = parameters.OutputImagePath;
			this.handSize = parameters.HandSize;
			this.jointThickness = parameters.JointThickness;
			this.gestureRecognitionJointThickness = parameters.GestureRecognitionJointThickness;
			this.bodySkeletonThickness = parameters.BodySkeletonThickness;
			this.jointsToIgnore = parameters.JointsToIgnore ?? new JointType[0];
			this.gestureRecognitionJoints = parameters.GestureRecognitionJoints ?? new JointType[0];
			this.bones = parameters.Bones ?? new Bone[0];
			this.isInferredMode = parameters.IsInferredMode;
		}
		#endregion

		#region Public methods
		public void DrawBodyData(BodyDataWithColorSpacePoints body, RectangleF boundingBox)
		{
			using (SKBitmap baseBitmap = SKBitmap.Decode(this.inputImagePath))
			using (SKCanvas canvas = new SKCanvas(baseBitmap))
			{
				var trackedJointPaint = new SKPaint
				{
					Color = this.trackedJointColor,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var gestureRecognitionJointPaint = new SKPaint
				{
					Color = this.trackedGestureRecognitionJointColor,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var inferredJointPaint = new SKPaint
				{
					Color = this.inferredJointColor,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var bonePaint = new SKPaint
				{
					Color = this.boneColor,
					StrokeWidth = this.bodySkeletonThickness,
					Style = SKPaintStyle.Stroke,
					IsAntialias = true
				};

				var inferredBonePaint = new SKPaint
				{
					Color = this.inferredBoneColor,
					StrokeWidth = 1f,
					Style = SKPaintStyle.Stroke,
					IsAntialias = true
				};

				var handClosedPaint = new SKPaint
				{
					Color = this.handClosedColor,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var handOpenPaint = new SKPaint
				{
					Color = this.handOpenColor,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var handLassoPaint = new SKPaint
				{
					Color = this.handLassoColor,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var boundingBoxPaint = new SKPaint
				{
					Color = new SKColor(255, 0, 0, 128),
					Style = SKPaintStyle.Stroke,
					StrokeWidth = 2,
					IsAntialias = true
				};

				if (!boundingBox.IsEmpty)
				{
					canvas.DrawRect(boundingBox.X, boundingBox.Y, boundingBox.Width, boundingBox.Height, boundingBoxPaint);
				}

				var jointPoints = body.JointsColorSpacePoints.ToDictionary(kvp => kvp.Key, kvp => new SKPoint(kvp.Value.X, kvp.Value.Y));

				foreach (var bone in this.bones)
				{
					var j0 = bone.ParentJoint;
					var j1 = bone.ChildJoint;

					if (!body.Joints.TryGetValue(j0, out Joint joint0) ||
							!body.Joints.TryGetValue(j1, out Joint joint1))
						continue;

					var state0 = joint0.TrackingState;
					var state1 = joint1.TrackingState;
					if (state0 == TrackingState.NotTracked || state1 == TrackingState.NotTracked)
						continue;

					if (!this.isInferredMode && (state0 == TrackingState.Inferred || state1 == TrackingState.Inferred))
						continue;

					var linePaint = state0 == TrackingState.Tracked && state1 == TrackingState.Tracked
							? bonePaint : inferredBonePaint;

					SKPoint p0 = jointPoints[j0];
					SKPoint p1 = jointPoints[j1];

					canvas.DrawLine(p0.X, p0.Y, p1.X, p1.Y, linePaint);
				}

				foreach (var kvp in body.Joints)
				{
					var jointType = kvp.Key;
					var joint = kvp.Value;

					if (this.jointsToIgnore.Contains(jointType))
						continue;

					SKPaint circlePaint = null;
					float radius = this.jointThickness;

					if (joint.TrackingState == TrackingState.Tracked)
					{
						if (this.gestureRecognitionJoints.Contains(jointType))
						{
							circlePaint = gestureRecognitionJointPaint;
							radius = this.gestureRecognitionJointThickness;
						}
						else
						{
							circlePaint = trackedJointPaint;
						}
					}
					else if (joint.TrackingState == TrackingState.Inferred && this.isInferredMode)
					{
						circlePaint = inferredJointPaint;
					}

					if (circlePaint != null)
					{
						SKPoint center = jointPoints[jointType];
						canvas.DrawCircle(center.X, center.Y, radius, circlePaint);
					}
				}

				if (jointPoints.TryGetValue(JointType.HandLeft, out SKPoint handLeftPos) && body.Joints.TryGetValue(JointType.HandLeft, out Joint handLeftJoint)
					&& (handLeftJoint.TrackingState == TrackingState.Tracked || handLeftJoint.TrackingState == TrackingState.Inferred && this.isInferredMode))
				{
					switch (body.HandLeftState)
					{
						case HandState.Closed:
							canvas.DrawCircle(handLeftPos.X, handLeftPos.Y, this.handSize, handClosedPaint);
							break;
						case HandState.Open:
							canvas.DrawCircle(handLeftPos.X, handLeftPos.Y, this.handSize, handOpenPaint);
							break;
						case HandState.Lasso:
							canvas.DrawCircle(handLeftPos.X, handLeftPos.Y, this.handSize, handLassoPaint);
							break;
					}
				}

				if (jointPoints.TryGetValue(JointType.HandRight, out SKPoint handRightPos) && body.Joints.TryGetValue(JointType.HandRight, out Joint handRightJoint)
					&& (handRightJoint.TrackingState == TrackingState.Tracked || handRightJoint.TrackingState == TrackingState.Inferred && this.isInferredMode))
				{
					switch (body.HandRightState)
					{
						case HandState.Closed:
							canvas.DrawCircle(handRightPos.X, handRightPos.Y, this.handSize, handClosedPaint);
							break;
						case HandState.Open:
							canvas.DrawCircle(handRightPos.X, handRightPos.Y, this.handSize, handOpenPaint);
							break;
						case HandState.Lasso:
							canvas.DrawCircle(handRightPos.X, handRightPos.Y, this.handSize, handLassoPaint);
							break;
					}
				}

				using (SKImage finalImage = SKImage.FromBitmap(baseBitmap))
				using (SKData encodedData = finalImage.Encode())
				using (var fileStream = new FileStream(this.outputImagePath, FileMode.Create, FileAccess.Write))
				{
					encodedData.SaveTo(fileStream);
				}
			}
		}
		#endregion
	}
}
