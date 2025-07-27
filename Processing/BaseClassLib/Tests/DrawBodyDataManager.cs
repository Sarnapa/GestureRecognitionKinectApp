using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using SkiaSharp;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using static GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures.GestureRecognitionDefinitions;

namespace GestureRecognition.Processing.BaseClassLib.Tests
{
	public class DrawBodyDataManager
	{
		#region Private fields
		private readonly string inputImagePath;
		private readonly string outputImagePath;

		/// <summary>
		/// Not drawn joints
		/// </summary>
		private readonly JointType[] jointsToIgnore = {
			//JointType.KneeLeft, JointType.KneeRight, JointType.AnkleLeft,
			//JointType.AnkleRight, JointType.FootLeft, JointType.FootRight,
			//// From MediaPipe
			//JointType.EyeInnerLeft, JointType.EyeLeft, JointType.EyeOuterLeft,
			//JointType.EyeInnerRight, JointType.EyeRight, JointType.EyeOuterRight,
			//JointType.EarLeft, JointType.EarRight,
			//JointType.MouthLeft, JointType.MouthRight,
			//JointType.HeelLeft, JointType.HeelRight,
			//JointType.FootIndexLeft, JointType.FootIndexRight
			};

		/// <summary>
		/// Definition of bones
		/// </summary>
		private readonly List<Bone> bones = MediaPipesBonesDefinitions.AllBones; // KinectBonesDefinitions.AllBonesWithoutLegs;

		private bool isInferredMode = false;
		#endregion

		#region Constructors
		public DrawBodyDataManager(string inputImagePath, string outputImagePath)
		{
			this.inputImagePath = inputImagePath;
			this.outputImagePath = outputImagePath;
		}
		#endregion

		#region Public methods
		public void DrawBodyData(BodyDataWithColorSpacePoints body, RectangleF boundingBox)
		{
			using (SKBitmap baseBitmap = SKBitmap.Decode(inputImagePath))
			using (SKCanvas canvas = new SKCanvas(baseBitmap))
			{
				var bonePaint = new SKPaint
				{
					Color = SKColors.Red,
					StrokeWidth = 10f,
					Style = SKPaintStyle.Stroke,
					IsAntialias = true
				};

				var inferredBonePaint = new SKPaint
				{
					Color = SKColors.Gray,
					StrokeWidth = 1f,
					Style = SKPaintStyle.Stroke,
					IsAntialias = true
				};

				var trackedJointPaint = new SKPaint
				{
					Color = new SKColor(68, 192, 68, 255),
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var specialJointPaint = new SKPaint
				{
					Color = new SKColor(128, 0, 128, 255),
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var inferredJointPaint = new SKPaint
				{
					Color = SKColors.Yellow,
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var handClosedPaint = new SKPaint
				{
					Color = new SKColor(255, 0, 0, 128),
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var handOpenPaint = new SKPaint
				{
					Color = new SKColor(0, 255, 0, 128),
					Style = SKPaintStyle.Fill,
					IsAntialias = true
				};

				var handLassoPaint = new SKPaint
				{
					Color = new SKColor(0, 0, 255, 128),
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
					float radius = 8f;

					if (joint.TrackingState == TrackingState.Tracked)
					{
						if (GestureRecognitionJoints.Contains(jointType))
						{
							circlePaint = specialJointPaint;
							radius = 12f;
						}
						else
						{
							circlePaint = trackedJointPaint;
						}
					}
					else if (joint.TrackingState == TrackingState.Inferred && this.isInferredMode)
					{
						circlePaint = inferredJointPaint;
						radius = 8f;
					}

					if (circlePaint != null)
					{
						SKPoint center = jointPoints[jointType];
						canvas.DrawCircle(center.X, center.Y, radius, circlePaint);
					}
				}

				if (jointPoints.TryGetValue(JointType.HandLeft, out SKPoint handLeftPos))
				{
					switch (body.HandLeftState)
					{
						case HandState.Closed:
							canvas.DrawCircle(handLeftPos.X, handLeftPos.Y, 15f, handClosedPaint);
							break;
						case HandState.Open:
							canvas.DrawCircle(handLeftPos.X, handLeftPos.Y, 15f, handOpenPaint);
							break;
						case HandState.Lasso:
							canvas.DrawCircle(handLeftPos.X, handLeftPos.Y, 15f, handLassoPaint);
							break;
					}
				}

				if (jointPoints.TryGetValue(JointType.HandRight, out SKPoint handRightPos))
				{
					switch (body.HandRightState)
					{
						case HandState.Closed:
							canvas.DrawCircle(handRightPos.X, handRightPos.Y, 15f, handClosedPaint);
							break;
						case HandState.Open:
							canvas.DrawCircle(handRightPos.X, handRightPos.Y, 15f, handOpenPaint);
							break;
						case HandState.Lasso:
							canvas.DrawCircle(handRightPos.X, handRightPos.Y, 15f, handLassoPaint);
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
