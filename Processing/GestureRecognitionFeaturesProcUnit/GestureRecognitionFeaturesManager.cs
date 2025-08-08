using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit
{
	public class GestureRecognitionFeaturesManager
	{
		#region Private fields
		private readonly IEnumerable<JointType> joints;
		private readonly IEnumerable<Bone> bones;
		#endregion

		#region Constructors
		public GestureRecognitionFeaturesManager(BodyTrackingMode mode)
		{
			switch (mode)
			{
				case BodyTrackingMode.MediaPipePoseLandmarks:
					this.joints = MediaPipePoseLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints;
					this.bones = MediaPipePoseLandmarksGestureRecognitionDefinitions.GestureRecognitionBones;
					break;
				case BodyTrackingMode.MediaPipeHandLandmarks:
					this.joints = MediaPipeHandLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints;
					this.bones = MediaPipeHandLandmarksGestureRecognitionDefinitions.GestureRecognitionBones;
					break;
				default:
					this.joints = KinectGestureRecognitionDefinitions.GestureRecognitionJoints;
					this.bones = KinectGestureRecognitionDefinitions.GestureRecognitionBones;
					break;
			}
		}
		#endregion

		#region Public methods
		public async Task<GestureFeatures> CalculateFeatures(BodyData[] bodyFrames)
		{
			if (bodyFrames == null || !bodyFrames.Any())
				return null;

			var gestureFeatures = new GestureFeatures(this.joints, this.bones);
			var gestureFeaturesTasks = new List<Task>();

			foreach (var joint in this.joints)
				gestureFeaturesTasks.Add(CalculateJointGestureFeaturesTask(gestureFeatures, bodyFrames, joint));

			foreach (var bone in this.bones)
				gestureFeaturesTasks.Add(CalculateBoneJointsAngleDataTask(gestureFeatures, bodyFrames, bone));

			gestureFeaturesTasks.Add(CalculateBetweenHandJointsDistanceFeaturesTask(gestureFeatures, bodyFrames));
			gestureFeaturesTasks.Add(GetHandDominanceTask(gestureFeatures, bodyFrames));

			await Task.WhenAll(gestureFeaturesTasks);

			return gestureFeatures;
		}
		#endregion

		#region Private methods

		private Task CalculateJointGestureFeaturesTask(GestureFeatures gestureFeatures, BodyData[] bodyFrames, JointType jointType)
		{
			return Task.Run(() => CalculateJointGestureFeatures(gestureFeatures, bodyFrames, jointType));
		}

		private void CalculateJointGestureFeatures(GestureFeatures gestureFeatures, BodyData[] bodyFrames, JointType jointType)
		{
			bool isHand = jointType == JointType.HandLeft || jointType == JointType.HandRight;

			double?[] angleVector = FeaturesHelper.CalculateAngleVector(bodyFrames, jointType);
			double? f1F2SpatialAngle = FeaturesHelper.GetF1F2SpatialAngle(angleVector);
			double? fN_1FNSpatialAngle = FeaturesHelper.GetFN_1FNSpatialAngle(angleVector);
			double? f1FNSpatialAngle = FeaturesHelper.CalculateF1FNSpatialAngle(bodyFrames.FirstOrDefault(),
				bodyFrames.LastOrDefault(), jointType);
			double? totalVectorAngle = FeaturesHelper.CalculateTotalVectorAngle(angleVector);
			double? squaredTotalVectorAngle = FeaturesHelper.CalculateSquaredTotalVectorAngle(angleVector);

			double?[] displacementVector = FeaturesHelper.CalculateDisplacementVector(bodyFrames, jointType);
			double? totalVectorDisplacement = FeaturesHelper.CalculateTotalVectorDisplacement(bodyFrames.FirstOrDefault(),
				bodyFrames.LastOrDefault(), jointType);
			double? totalDisplacement = FeaturesHelper.CalculateTotalDisplacement(displacementVector);
			double? maximumDisplacement = FeaturesHelper.CalculateMaximumDisplacement(displacementVector);

			if (isHand)
			{
				var boundingBox = FeaturesHelper.GetBoundingBox(bodyFrames, jointType);
				double? boundingBoxDiagonalLength = null, boundingBoxAngle = null;
				if (boundingBox != null)
				{
					boundingBoxDiagonalLength = FeaturesHelper.CalculateBoundingBoxDiagonalLength(boundingBox);
					boundingBoxAngle = FeaturesHelper.CalculateBoundingBoxAngle(boundingBox);
				}

				// Turned off for now, if the results are not satisfactory then turn it on
				//var handStates = FeaturesHelper.GetHandStates(bodyFrames, jointType);
				gestureFeatures.AddJointGestureFeature(jointType, new HandJointGestureFeatures(f1F2SpatialAngle,
					fN_1FNSpatialAngle, f1FNSpatialAngle, totalVectorAngle, squaredTotalVectorAngle, totalVectorDisplacement,
					totalDisplacement, maximumDisplacement, boundingBoxDiagonalLength, boundingBoxAngle/*, handStates*/));
			}
			else
			{
				gestureFeatures.AddJointGestureFeature(jointType, new JointGestureFeatures(f1F2SpatialAngle,
					fN_1FNSpatialAngle, f1FNSpatialAngle, totalVectorAngle, squaredTotalVectorAngle, totalVectorDisplacement,
					totalDisplacement, maximumDisplacement));
			}
		}

		private Task CalculateBoneJointsAngleDataTask(GestureFeatures gestureFeatures, BodyData[] bodyFrames, Bone bone)
		{
			return Task.Run(() => CalculateBoneJointsAngleData(gestureFeatures, bodyFrames, bone));
		}

		private void CalculateBoneJointsAngleData(GestureFeatures gestureFeatures, BodyData[] bodyFrames, Bone bone)
		{
			double?[] angleVector = FeaturesHelper.CalculateAngleVector(bodyFrames, bone);
			double? initialAngle = FeaturesHelper.GetInitialAngle(angleVector);
			double? finalAngle = FeaturesHelper.GetFinalAngle(angleVector);
			double? meanAngle = FeaturesHelper.CalculateMeanAngle(angleVector);
			double? maximumAngle = FeaturesHelper.CalculateMaximumAngle(angleVector);

			gestureFeatures.AddBoneJointsAngleData(bone, new BoneJointsAngleData(initialAngle, finalAngle, meanAngle,
				maximumAngle));
		}

		private Task CalculateBetweenHandJointsDistanceFeaturesTask(GestureFeatures gestureFeatures, BodyData[] bodyFrames)
		{
			return Task.Run(() => CalculateBetweenHandJointsDistanceFeatures(gestureFeatures, bodyFrames));
		}

		private void CalculateBetweenHandJointsDistanceFeatures(GestureFeatures gestureFeatures, BodyData[] bodyFrames)
		{
			double?[] distanceVector = FeaturesHelper.CalculateDistanceVector(bodyFrames, JointType.HandLeft, JointType.HandRight);
			double? betweenHandJointsDistanceMax = FeaturesHelper.CalculateBetweenHandJointsDistanceMax(distanceVector);
			double? betweenHandJointsDistanceMean = FeaturesHelper.CalculateBetweenHandJointsDistanceMean(distanceVector);

			gestureFeatures.BetweenHandJointsDistanceMax = betweenHandJointsDistanceMax;
			gestureFeatures.BetweenHandJointsDistanceMean = betweenHandJointsDistanceMean;
		}

		private Task GetHandDominanceTask(GestureFeatures gestureFeatures, BodyData[] bodyFrames)
		{
			return Task.Run(() => GetHandDominance(gestureFeatures, bodyFrames));
		}

		private void GetHandDominance(GestureFeatures gestureFeatures, BodyData[] bodyFrames)
		{
			int leftHandDominanceFramesCount = bodyFrames.Where(f => f.HandDominance == HandDominance.Left).Count();
			int rightHandDominanceFramesCount = bodyFrames.Where(f => f.HandDominance == HandDominance.Right).Count();

			if (leftHandDominanceFramesCount > rightHandDominanceFramesCount)
				gestureFeatures.HandDominance = HandDominance.Left;
			else if (leftHandDominanceFramesCount < rightHandDominanceFramesCount)
				gestureFeatures.HandDominance = HandDominance.Right;
			else
				gestureFeatures.HandDominance = HandDominance.Unknown;
		}
		#endregion
	}
}
