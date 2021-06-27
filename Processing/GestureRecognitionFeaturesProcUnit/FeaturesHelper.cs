using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.Kinect;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.Kinect;

namespace GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit
{
	public static class FeaturesHelper
	{
		#region Public methods

		#region Joints gesture features methods

		#region Angle vector methods
		public static double?[] CalculateAngleVector(BodyData[] bodyFrames, JointType jointType)
		{
			return GetVector(bodyFrames, jointType, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2));
		}

		public static double[] CalculateAngleVector(IEnumerable<CameraSpacePoint> jointsPositions)
		{
			return CalculateAngleVector(jointsPositions?.Map());
		}

		public static double[] CalculateAngleVector(IEnumerable<Vector3> jointsPositions)
		{
			return GetVector(jointsPositions, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2));
		}
		#endregion

		#region F1F2SpatialAngle feature methods
		public static double? GetF1F2SpatialAngle(double?[] angleVector)
		{
			return angleVector?.FirstOrDefault();
		}

		public static double CalculateF1F2SpatialAngle(CameraSpacePoint f1JointPosition, CameraSpacePoint f2JointPosition)
		{
			return CalculateF1F2SpatialAngle(f1JointPosition.Map(), f2JointPosition.Map());
		}

		public static double CalculateF1F2SpatialAngle(Vector3 f1JointPosition, Vector3 f2JointPosition)
		{
			return MathHelper.CalculateSpatialAngle(f1JointPosition, f2JointPosition);
		}
		#endregion

		#region FN_1FNSpatialAngle feature methods
		public static double? GetFN_1FNSpatialAngle(double?[] angleVector)
		{
			return angleVector?.LastOrDefault();
		}

		public static double CalculateFN_1FNSpatialAngle(CameraSpacePoint fN_1JointPosition, CameraSpacePoint fNJointPosition)
		{
			return CalculateFN_1FNSpatialAngle(fN_1JointPosition.Map(), fNJointPosition.Map());
		}

		public static double CalculateFN_1FNSpatialAngle(Vector3 fN_1JointPosition, Vector3 fNJointPosition)
		{
			return MathHelper.CalculateSpatialAngle(fN_1JointPosition, fNJointPosition);
		}
		#endregion

		#region F1FNSpatialAngle feature methods
		public static double? CalculateF1FNSpatialAngle(BodyData bodyFrame1, BodyData bodyFrameN, JointType jointType)
		{
			if (bodyFrame1 == null)
				throw new ArgumentNullException(nameof(bodyFrame1));
			if (bodyFrameN == null)
				throw new ArgumentNullException(nameof(bodyFrameN));

			return GetVector(new[] { bodyFrame1, bodyFrameN }, jointType, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2))?.FirstOrDefault();
		}

		public static double CalculateF1FNSpatialAngle(CameraSpacePoint f1JointPosition, CameraSpacePoint fNJointPosition)
		{
			return CalculateF1FNSpatialAngle(f1JointPosition.Map(), fNJointPosition.Map());
		}

		public static double CalculateF1FNSpatialAngle(Vector3 f1JointPosition, Vector3 fNJointPosition)
		{
			return MathHelper.CalculateSpatialAngle(f1JointPosition, fNJointPosition);
		}
		#endregion

		#region TotalVectorAngle feature methods
		public static double? CalculateTotalVectorAngle(double?[] angleVector)
		{
			return angleVector?.Where(a => a.HasValue).Sum(a => a.Value);
		}

		public static double CalculateTotalVectorAngle(IEnumerable<CameraSpacePoint> jointsPositions)
		{
			return CalculateTotalVectorAngle(jointsPositions?.Map());
		}

		public static double CalculateTotalVectorAngle(IEnumerable<Vector3> jointsPositions)
		{
			return Sum(jointsPositions, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2));
		}
		#endregion

		#region SquaredTotalVectorAngle feature methods
		public static double? CalculateSquaredTotalVectorAngle(double?[] angleVector)
		{
			return angleVector?.Where(a => a.HasValue).Sum(a => Math.Pow(a.Value, 2));
		}

		public static double CalculateSquaredTotalVectorAngle(IEnumerable<CameraSpacePoint> jointsPositions)
		{
			return CalculateSquaredTotalVectorAngle(jointsPositions?.Map());
		}

		public static double CalculateSquaredTotalVectorAngle(IEnumerable<Vector3> jointsPositions)
		{
			return Sum(jointsPositions, (v1, v2) => Math.Pow(MathHelper.CalculateSpatialAngle(v1, v2), 2));
		}
		#endregion

		#region Displacement vector methods
		public static double?[] CalculateDisplacementVector(BodyData[] bodyFrames, JointType jointType)
		{
			return GetVector(bodyFrames, jointType, (v1, v2) => MathHelper.Distance(v1, v2));
		}

		public static double[] CalculateDisplacementVector(IEnumerable<CameraSpacePoint> jointsPositions)
		{
			return CalculateDisplacementVector(jointsPositions?.Map());
		}

		public static double[] CalculateDisplacementVector(IEnumerable<Vector3> jointsPositions)
		{
			return GetVector(jointsPositions, (v1, v2) => MathHelper.Distance(v1, v2));
		}
		#endregion

		#region TotalVectorDisplacement feature methods
		public static double? CalculateTotalVectorDisplacement(BodyData bodyFrame1, BodyData bodyFrameN, JointType jointType)
		{
			if (bodyFrame1 == null)
				throw new ArgumentNullException(nameof(bodyFrame1));
			if (bodyFrameN == null)
				throw new ArgumentNullException(nameof(bodyFrameN));

			return GetVector(new[] { bodyFrame1, bodyFrameN }, jointType, (v1, v2) => MathHelper.Distance(v1, v2))?.FirstOrDefault();
		}

		public static double CalculateTotalVectorDisplacement(CameraSpacePoint f1JointPosition, CameraSpacePoint fNJointPosition)
		{
			return CalculateTotalVectorDisplacement(f1JointPosition.Map(), fNJointPosition.Map());
		}

		public static double CalculateTotalVectorDisplacement(Vector3 f1JointPosition, Vector3 fNJointPosition)
		{
			return MathHelper.Distance(f1JointPosition, fNJointPosition);
		}
		#endregion

		#region TotalDisplacement feature methods
		public static double? CalculateTotalDisplacement(double?[] displacementVector)
		{
			return displacementVector?.Where(d => d.HasValue).Sum(d => d.Value);
		}

		public static double CalculateTotalDisplacement(IEnumerable<CameraSpacePoint> jointsPositions)
		{
			return CalculateTotalDisplacement(jointsPositions?.Map());
		}

		public static double CalculateTotalDisplacement(IEnumerable<Vector3> jointsPositions)
		{
			return Sum(jointsPositions, (v1, v2) => MathHelper.Distance(v1, v2));
		}
		#endregion

		#region MaximumDisplacement feature methods
		public static double? CalculateMaximumDisplacement(double?[] displacementVector)
		{
			return displacementVector?.Where(d => d.HasValue).Max(d => d.Value);
		}
		#endregion

		#region Bounding box methods
		public static JointBoundingBox GetBoundingBox(BodyData[] bodyFrames, JointType jointType)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));

			float? minX = null, maxX = null, minY = null, maxY = null, minZ = null, maxZ = null;

			if (!bodyFrames.Any())
			{
				foreach (var bodyFrame in bodyFrames)
				{
					var bodyFrameJoint = GetJoint(bodyFrame, jointType);
					if (bodyFrameJoint.HasValue)
					{
						var position = bodyFrameJoint.Value.Position;
						if (!minX.HasValue || minX.Value > position.X)
							minX = position.X;
						if (!maxX.HasValue || maxX.Value < position.X)
							maxX = position.X;
						if (!minY.HasValue || minY.Value > position.Y)
							minY = position.Y;
						if (!maxY.HasValue || maxY.Value < position.Y)
							maxY = position.Y;
						if (!minZ.HasValue || minZ.Value > position.Z)
							minZ = position.Z;
						if (!maxZ.HasValue || maxZ.Value < position.Z)
							maxZ = position.Z;
					}
				}

				if (minX.HasValue && maxX.HasValue && minY.HasValue && maxY.HasValue && minZ.HasValue
					&& maxZ.HasValue)
					return new JointBoundingBox(minX.Value, maxX.Value, minY.Value, maxY.Value, minZ.Value, maxZ.Value);
			}

			return null;
		}
		#endregion

		#region BoundingBoxDiagonalLength feature methods
		public static double CalculateBoundingBoxDiagonalLength(JointBoundingBox boundingBox)
		{
			if (boundingBox == null)
				throw new ArgumentNullException(nameof(boundingBox));

			return MathHelper.GetDiagonalLength(boundingBox);
		}
		#endregion

		#region BoundingBoxAngle feature methods
		public static double CalculateBoundingBoxAngle(JointBoundingBox boundingBox)
		{
			if (boundingBox == null)
				throw new ArgumentNullException(nameof(boundingBox));

			return MathHelper.GetAngle(boundingBox);
		}
		#endregion

		#region HandStates feature methods
		public static HandState[] GetHandStates(BodyData[] bodyFrames, JointType jointType)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));
			if (jointType != JointType.HandLeft && jointType != JointType.HandRight)
				throw new ArgumentException(nameof(jointType));

			var res = new List<HandState>();

			foreach (var bodyFrame in bodyFrames)
			{
				if (bodyFrame.IsTracked && bodyFrame.Joints != null && bodyFrame.Joints.ContainsKey(jointType))
				{
					if (jointType == JointType.HandLeft)
						res.Add(bodyFrame.HandLeftState);
					else
						res.Add(bodyFrame.HandRightState);
				}
				else
					res.Add(HandState.NotTracked);
			}

			return res.ToArray();
		}
		#endregion

		#endregion

		#region Bone joints angle data methods

		#region Angle vector methods
		public static double?[] CalculateAngleVector(BodyData[] bodyFrames, Bone bone)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));
			if (bone == null)
				throw new ArgumentNullException(nameof(bone));

			var res = new List<double?>();

			foreach (var bodyFrame in bodyFrames)
			{
				var parentJoint = GetJoint(bodyFrame, bone.ParentJoint);
				var childJoint = GetJoint(bodyFrame, bone.ChildJoint);
				if (parentJoint.HasValue && childJoint.HasValue)
				{
					var parentJointPos = parentJoint.Value.Position.Map();
					var childJointPos = childJoint.Value.Position.Map();
					var referencePoint = new Vector3(parentJointPos.X, 0, 0);

					double a = MathHelper.Distance(referencePoint, childJointPos);
					double b = MathHelper.Distance(referencePoint, parentJointPos);
					double c = MathHelper.Distance(childJointPos, parentJointPos);

					double angle = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / 2 * a * b * c);
					res.Add(MathHelper.ConvertRadiansToDegrees(angle));
				}
				else
					res.Add(null);
			}

			return res.ToArray();
		}
		#endregion

		#region InitialAngle feature methods
		public static double? GetInitialAngle(double?[] angleVector)
		{
			return angleVector?.FirstOrDefault();
		}
		#endregion

		#region FinalAngle feature methods
		public static double? GetFinalAngle(double?[] angleVector)
		{
			return angleVector?.LastOrDefault();
		}
		#endregion

		#region MeanAngle feature methods
		public static double? CalculateMeanAngle(double?[] angleVector)
		{
			return angleVector?.Where(a => a.HasValue).Average(a => a.Value);
		}
		#endregion

		#region MaximumAngle feature methods
		public static double? CalculateMaximumAngle(double?[] angleVector)
		{
			return angleVector?.Where(a => a.HasValue).Max(a => a.Value);
		}
		#endregion

		#endregion

		#region Between hand joints distance methods

		#region Distance vector methods
		public static double?[] CalculateDistanceVector(BodyData[] bodyFrames, JointType jointType1, JointType jointType2)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));

			var res = new List<double?>();

			foreach (var bodyFrame in bodyFrames)
			{
				var joint1 = GetJoint(bodyFrame, jointType1);
				var joint2 = GetJoint(bodyFrame, jointType2);
				if (joint1.HasValue && joint2.HasValue)
				{
					var joint1Pos = joint1.Value.Position.Map();
					var joint2Pos = joint2.Value.Position.Map();

					res.Add(MathHelper.Distance(joint1Pos, joint2Pos));
				}
				else
					res.Add(null);
			}

			return res.ToArray();
		}
		#endregion

		#region BetweenHandJointsDistanceMax feature methods
		public static double? CalculateBetweenHandJointsDistanceMax(double?[] distanceVector)
		{
			return distanceVector?.Where(d => d.HasValue).Max(d => d.Value);
		}
		#endregion

		#region BetweenHandJointsDistanceMean feature methods
		public static double? CalculateBetweenHandJointsDistanceMean(double?[] distanceVector)
		{
			return distanceVector?.Where(d => d.HasValue).Average(d => d.Value);
		}
		#endregion

		#endregion

		#endregion

		#region Private methods
		private static double Sum(IEnumerable<Vector3> jointsPositions, Func<Vector3, Vector3, double> calculationFunc)
		{
			if (calculationFunc == null)
				throw new ArgumentNullException(nameof(calculationFunc));

			double res = 0d;

			if (jointsPositions != null && jointsPositions.Any())
			{
				var jointsPositionsArray = jointsPositions.ToArray();
				for (int i = 1; i < jointsPositionsArray.Length; i++)
					res += calculationFunc(jointsPositionsArray[i - 1], jointsPositionsArray[i]);
			}

			return res;
		}

		private static double[] GetVector(IEnumerable<Vector3> jointsPositions, Func<Vector3, Vector3, double> calculationFunc)
		{
			if (calculationFunc == null)
				throw new ArgumentNullException(nameof(calculationFunc));

			var res = new List<double>();

			if (jointsPositions != null && jointsPositions.Any())
			{
				var jointsPositionsArray = jointsPositions.ToArray();
				for (int i = 1; i < jointsPositionsArray.Length; i++)
					res.Add(calculationFunc(jointsPositionsArray[i - 1], jointsPositionsArray[i]));
			}

			return res.ToArray();
		}

		private static double?[] GetVector(BodyData[] bodyFrames, JointType jointType, Func<Vector3, Vector3, double> calculationFunc)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));

			var res = new List<double?>();

			for (int i = 1; i < bodyFrames.Length; i++)
			{
				var firstBodyFrame = bodyFrames[i - 1];
				var secondBodyFrame = bodyFrames[i];
				var firstBodyFrameJoint = GetJoint(firstBodyFrame, jointType);
				var secondBodyFrameJoint = GetJoint(secondBodyFrame, jointType);
				if (firstBodyFrameJoint.HasValue && secondBodyFrameJoint.HasValue)
					res.Add(calculationFunc(firstBodyFrameJoint.Value.Position.Map(),
						secondBodyFrameJoint.Value.Position.Map()));
				else
					res.Add(null);
			}

			return res.ToArray();
		}

		private static Joint? GetJoint(BodyData bodyFrame, JointType jointType)
		{
			if (bodyFrame == null)
				throw new ArgumentNullException(nameof(jointType));

			if (bodyFrame.IsTracked && bodyFrame.Joints != null && bodyFrame.Joints.TryGetValue(jointType, out Joint joint) 
				&& joint.TrackingState == TrackingState.Tracked)
				return joint;

			return null;
		}
		#endregion
	}
}
