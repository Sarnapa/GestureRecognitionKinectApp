using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit
{
	public static class FeaturesHelper
	{
		#region Public methods

		#region Joints gesture features methods

		#region Angle vector methods
		public static float[] CalculateAngleVector(BodyData[] bodyFrames, JointType jointType)
		{
			return GetVector(bodyFrames, jointType, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2));
		}

		public static float[] CalculateAngleVector(IEnumerable<Vector3> jointsPositions)
		{
			return GetVector(jointsPositions, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2));
		}
		#endregion

		#region F1F2SpatialAngle feature methods
		public static float GetF1F2SpatialAngle(float[] angleVector)
		{
			return angleVector?.FirstOrDefault() ?? float.NaN;
		}

		public static float CalculateF1F2SpatialAngle(Vector3 f1JointPosition, Vector3 f2JointPosition)
		{
			return MathHelper.CalculateSpatialAngle(f1JointPosition, f2JointPosition);
		}
		#endregion

		#region FN_1FNSpatialAngle feature methods
		public static float GetFN_1FNSpatialAngle(float[] angleVector)
		{
			return angleVector?.LastOrDefault() ?? float.NaN;
		}

		public static float CalculateFN_1FNSpatialAngle(Vector3 fN_1JointPosition, Vector3 fNJointPosition)
		{
			return MathHelper.CalculateSpatialAngle(fN_1JointPosition, fNJointPosition);
		}
		#endregion

		#region F1FNSpatialAngle feature methods
		public static float CalculateF1FNSpatialAngle(BodyData bodyFrame1, BodyData bodyFrameN, JointType jointType)
		{
			if (bodyFrame1 == null)
				throw new ArgumentNullException(nameof(bodyFrame1));
			if (bodyFrameN == null)
				throw new ArgumentNullException(nameof(bodyFrameN));

			return GetVector(new[] { bodyFrame1, bodyFrameN }, jointType, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2))?.FirstOrDefault() ?? float.NaN;
		}

		public static float CalculateF1FNSpatialAngle(Vector3 f1JointPosition, Vector3 fNJointPosition)
		{
			return MathHelper.CalculateSpatialAngle(f1JointPosition, fNJointPosition);
		}
		#endregion

		#region TotalVectorAngle feature methods
		public static float CalculateTotalVectorAngle(float[] angleVector)
		{
			var filteredAngleVector = angleVector?.Where(a => !float.IsNaN(a)).ToArray();
			return filteredAngleVector != null && filteredAngleVector.Any() ? filteredAngleVector.Sum() : float.NaN;
		}

		public static float CalculateTotalVectorAngle(IEnumerable<Vector3> jointsPositions)
		{
			return Sum(jointsPositions, (v1, v2) => MathHelper.CalculateSpatialAngle(v1, v2));
		}
		#endregion

		#region SquaredTotalVectorAngle feature methods
		public static float CalculateSquaredTotalVectorAngle(float[] angleVector)
		{
			var filteredAngleVector = angleVector?.Where(a => !float.IsNaN(a)).ToArray();
			return filteredAngleVector != null && filteredAngleVector.Any() ? Convert.ToSingle(filteredAngleVector.Sum(a => Math.Pow(a, 2))) : float.NaN;
		}

		public static float CalculateSquaredTotalVectorAngle(IEnumerable<Vector3> jointsPositions)
		{
			return Sum(jointsPositions, (v1, v2) => Convert.ToSingle(Math.Pow(MathHelper.CalculateSpatialAngle(v1, v2), 2)));
		}
		#endregion

		#region Displacement vector methods
		public static float[] CalculateDisplacementVector(BodyData[] bodyFrames, JointType jointType)
		{
			return GetVector(bodyFrames, jointType, (v1, v2) => MathHelper.Distance(v1, v2));
		}

		public static float[] CalculateDisplacementVector(IEnumerable<Vector3> jointsPositions)
		{
			return GetVector(jointsPositions, (v1, v2) => MathHelper.Distance(v1, v2));
		}
		#endregion

		#region TotalVectorDisplacement feature methods
		public static float CalculateTotalVectorDisplacement(BodyData bodyFrame1, BodyData bodyFrameN, JointType jointType)
		{
			if (bodyFrame1 == null)
				throw new ArgumentNullException(nameof(bodyFrame1));
			if (bodyFrameN == null)
				throw new ArgumentNullException(nameof(bodyFrameN));

			return GetVector(new[] { bodyFrame1, bodyFrameN }, jointType, (v1, v2) => MathHelper.Distance(v1, v2))?.FirstOrDefault() ?? float.NaN;
		}

		public static float CalculateTotalVectorDisplacement(Vector3 f1JointPosition, Vector3 fNJointPosition)
		{
			return MathHelper.Distance(f1JointPosition, fNJointPosition);
		}
		#endregion

		#region TotalDisplacement feature methods
		public static float CalculateTotalDisplacement(float[] displacementVector)
		{
			var filteredDisplacementVector = displacementVector?.Where(d => !float.IsNaN(d)).ToArray();
			return filteredDisplacementVector != null && filteredDisplacementVector.Any() ? filteredDisplacementVector.Sum() : float.NaN;
		}

		public static float CalculateTotalDisplacement(IEnumerable<Vector3> jointsPositions)
		{
			return Sum(jointsPositions, (v1, v2) => MathHelper.Distance(v1, v2));
		}
		#endregion

		#region MaximumDisplacement feature methods
		public static float CalculateMaximumDisplacement(float[] displacementVector)
		{
			var filteredDisplacementVector = displacementVector?.Where(d => !float.IsNaN(d)).ToArray();
			return filteredDisplacementVector != null && filteredDisplacementVector.Any() ? filteredDisplacementVector.Max() : float.NaN;
		}
		#endregion

		#region Bounding box methods
		public static JointBoundingBox GetBoundingBox(BodyData[] bodyFrames, JointType jointType)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));

			float? minX = null, maxX = null, minY = null, maxY = null, minZ = null, maxZ = null;

			if (bodyFrames.Any())
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

				if (minX.HasValue && maxX.HasValue && minY.HasValue && maxY.HasValue && minZ.HasValue && maxZ.HasValue)
					return new JointBoundingBox(minX.Value, maxX.Value, minY.Value, maxY.Value, minZ.Value, maxZ.Value);
			}

			return null;
		}
		#endregion

		#region BoundingBoxDiagonalLength feature methods
		public static float CalculateBoundingBoxDiagonalLength(JointBoundingBox boundingBox)
		{
			if (boundingBox == null)
				throw new ArgumentNullException(nameof(boundingBox));

			return MathHelper.GetDiagonalLength(boundingBox);
		}
		#endregion

		#region BoundingBoxAngle feature methods
		public static float CalculateBoundingBoxAngle(JointBoundingBox boundingBox)
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
		public static float[] CalculateAngleVector(BodyData[] bodyFrames, Bone bone)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));
			if (bone == null)
				throw new ArgumentNullException(nameof(bone));

			var res = new List<float>();

			foreach (var bodyFrame in bodyFrames)
			{
				var parentJoint = GetJoint(bodyFrame, bone.ParentJoint);
				var childJoint = GetJoint(bodyFrame, bone.ChildJoint);
				if (parentJoint.HasValue && childJoint.HasValue)
				{
					var parentJointPos = parentJoint.Value.Position;
					var childJointPos = childJoint.Value.Position;
					// TODO: MP: To ogranicza nas do siedzenia w określonej odległości od sensora.
					var referencePoint = new Vector3(parentJointPos.X, 1f, 0f);

					float a = MathHelper.Distance(referencePoint, childJointPos);
					float b = MathHelper.Distance(referencePoint, parentJointPos);
					float c = MathHelper.Distance(childJointPos, parentJointPos);

					double angle = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b));
					res.Add(MathHelper.ConvertRadiansToDegrees(angle));
				}
				else
					res.Add(float.NaN);
			}

			return res.ToArray();
		}
		#endregion

		#region InitialAngle feature methods
		public static float GetInitialAngle(float[] angleVector)
		{
			return angleVector?.FirstOrDefault() ?? float.NaN;
		}
		#endregion

		#region FinalAngle feature methods
		public static float GetFinalAngle(float[] angleVector)
		{
			return angleVector?.LastOrDefault() ?? float.NaN;
		}
		#endregion

		#region MeanAngle feature methods
		public static float CalculateMeanAngle(float[] angleVector)
		{
			var filteredAngleVector = angleVector?.Where(a => !float.IsNaN(a)).ToArray();
			return filteredAngleVector != null && filteredAngleVector.Any() ? filteredAngleVector.Average() : float.NaN;
		}
		#endregion

		#region MaximumAngle feature methods
		public static float CalculateMaximumAngle(float[] angleVector)
		{
			var filteredAngleVector = angleVector?.Where(a => !float.IsNaN(a)).ToArray();
			return filteredAngleVector != null && filteredAngleVector.Any() ? filteredAngleVector.Max() : float.NaN;
		}
		#endregion

		#endregion

		#region Between hand joints distance methods

		#region Distance vector methods
		public static float[] CalculateDistanceVector(BodyData[] bodyFrames, JointType jointType1, JointType jointType2)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));

			var res = new List<float>();

			foreach (var bodyFrame in bodyFrames)
			{
				var joint1 = GetJoint(bodyFrame, jointType1);
				var joint2 = GetJoint(bodyFrame, jointType2);
				if (joint1.HasValue && joint2.HasValue)
				{
					var joint1Pos = joint1.Value.Position;
					var joint2Pos = joint2.Value.Position;

					res.Add(MathHelper.Distance(joint1Pos, joint2Pos));
				}
				else
					res.Add(float.NaN);
			}

			return res.ToArray();
		}
		#endregion

		#region BetweenHandJointsDistanceMax feature methods
		public static float CalculateBetweenHandJointsDistanceMax(float[] distanceVector)
		{
			var filteredDistanceVector = distanceVector?.Where(d => !float.IsNaN(d)).ToArray();
			return filteredDistanceVector != null && filteredDistanceVector.Any() ? filteredDistanceVector.Max() : float.NaN;
		}
		#endregion

		#region BetweenHandJointsDistanceMean feature methods
		public static float CalculateBetweenHandJointsDistanceMean(float[] distanceVector)
		{
			var filteredDistanceVector = distanceVector?.Where(a => !float.IsNaN(a)).ToArray();
			return filteredDistanceVector != null && filteredDistanceVector.Any() ? filteredDistanceVector.Average() : float.NaN;
		}
		#endregion

		#endregion

		#endregion

		#region Private methods
		private static float Sum(IEnumerable<Vector3> jointsPositions, Func<Vector3, Vector3, float> calculationFunc)
		{
			if (calculationFunc == null)
				throw new ArgumentNullException(nameof(calculationFunc));

			float res = 0f;

			if (jointsPositions != null && jointsPositions.Any())
			{
				var jointsPositionsArray = jointsPositions.ToArray();
				for (int i = 1; i < jointsPositionsArray.Length; i++)
					res += calculationFunc(jointsPositionsArray[i - 1], jointsPositionsArray[i]);
			}

			return res;
		}

		private static float[] GetVector(IEnumerable<Vector3> jointsPositions, Func<Vector3, Vector3, float> calculationFunc)
		{
			if (calculationFunc == null)
				throw new ArgumentNullException(nameof(calculationFunc));

			var res = new List<float>();

			if (jointsPositions != null && jointsPositions.Any())
			{
				var jointsPositionsArray = jointsPositions.ToArray();
				for (int i = 1; i < jointsPositionsArray.Length; i++)
					res.Add(calculationFunc(jointsPositionsArray[i - 1], jointsPositionsArray[i]));
			}

			return res.ToArray();
		}

		private static float[] GetVector(BodyData[] bodyFrames, JointType jointType, Func<Vector3, Vector3, float> calculationFunc)
		{
			if (bodyFrames == null)
				throw new ArgumentNullException(nameof(bodyFrames));

			var res = new List<float>();

			for (int i = 1; i < bodyFrames.Length; i++)
			{
				var firstBodyFrame = bodyFrames[i - 1];
				var secondBodyFrame = bodyFrames[i];
				var firstBodyFrameJoint = GetJoint(firstBodyFrame, jointType);
				var secondBodyFrameJoint = GetJoint(secondBodyFrame, jointType);
				if (firstBodyFrameJoint.HasValue && secondBodyFrameJoint.HasValue)
					res.Add(calculationFunc(firstBodyFrameJoint.Value.Position,
						secondBodyFrameJoint.Value.Position));
				else
					res.Add(float.NaN);
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
