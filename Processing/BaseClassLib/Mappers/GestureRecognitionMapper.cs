using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using static GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures.KinectGestureRecognitionDefinitions;
using static GestureRecognition.Processing.BaseClassLib.Structures.Body.KinectBonesDefinitions;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Mappers
{
	public static class GestureRecognitionMapper
	{
		#region GestureFeatures -> GestureDataView
		public static GestureDataView Map(this GestureFeatures features, string label)
		{
			if (features == null)
				return null;

			if (!features.IsValid)
				return new GestureDataView();

			#region ElbowLeft joint features
			double? elbowLeftF1F2SpatialAngle = null;
			double? elbowLeftFN_1FNSpatialAngle = null;
			double? elbowLeftF1FNSpatialAngle = null;
			double? elbowLeftTotalVectorAngle = null;
			double? elbowLeftSquaredTotalVectorAngle = null;
			double? elbowLeftTotalVectorDisplacement = null;
			double? elbowLeftTotalDisplacement = null;
			double? elbowLeftMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.ElbowLeft, out var elbowLeftFeatures))
			{
				elbowLeftF1F2SpatialAngle = elbowLeftFeatures.F1F2SpatialAngle;
				elbowLeftFN_1FNSpatialAngle = elbowLeftFeatures.FN_1FNSpatialAngle;
				elbowLeftF1FNSpatialAngle = elbowLeftFeatures.F1FNSpatialAngle;
				elbowLeftTotalVectorAngle = elbowLeftFeatures.TotalVectorAngle;
				elbowLeftSquaredTotalVectorAngle = elbowLeftFeatures.SquaredTotalVectorAngle;
				elbowLeftTotalVectorDisplacement = elbowLeftFeatures.TotalVectorDisplacement;
				elbowLeftTotalDisplacement = elbowLeftFeatures.TotalDisplacement;
				elbowLeftMaximumDisplacement = elbowLeftFeatures.MaximumDisplacement;
			}
			#endregion

			#region ElbowRight joint features
			double? elbowRightF1F2SpatialAngle = null;
			double? elbowRightFN_1FNSpatialAngle = null;
			double? elbowRightF1FNSpatialAngle = null;
			double? elbowRightTotalVectorAngle = null;
			double? elbowRightSquaredTotalVectorAngle = null;
			double? elbowRightTotalVectorDisplacement = null;
			double? elbowRightTotalDisplacement = null;
			double? elbowRightMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.ElbowRight, out var elbowRightFeatures))
			{
				elbowRightF1F2SpatialAngle = elbowRightFeatures.F1F2SpatialAngle;
				elbowRightFN_1FNSpatialAngle = elbowRightFeatures.FN_1FNSpatialAngle;
				elbowRightF1FNSpatialAngle = elbowRightFeatures.F1FNSpatialAngle;
				elbowRightTotalVectorAngle = elbowRightFeatures.TotalVectorAngle;
				elbowRightSquaredTotalVectorAngle = elbowRightFeatures.SquaredTotalVectorAngle;
				elbowRightTotalVectorDisplacement = elbowRightFeatures.TotalVectorDisplacement;
				elbowRightTotalDisplacement = elbowRightFeatures.TotalDisplacement;
				elbowRightMaximumDisplacement = elbowRightFeatures.MaximumDisplacement;
			}
			#endregion

			#region WristLeft joint features
			double? wristLeftF1F2SpatialAngle = null;
			double? wristLeftFN_1FNSpatialAngle = null;
			double? wristLeftF1FNSpatialAngle = null;
			double? wristLeftTotalVectorAngle = null;
			double? wristLeftSquaredTotalVectorAngle = null;
			double? wristLeftTotalVectorDisplacement = null;
			double? wristLeftTotalDisplacement = null;
			double? wristLeftMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.WristLeft, out var wristLeftFeatures))
			{
				wristLeftF1F2SpatialAngle = wristLeftFeatures.F1F2SpatialAngle;
				wristLeftFN_1FNSpatialAngle = wristLeftFeatures.FN_1FNSpatialAngle;
				wristLeftF1FNSpatialAngle = wristLeftFeatures.F1FNSpatialAngle;
				wristLeftTotalVectorAngle = wristLeftFeatures.TotalVectorAngle;
				wristLeftSquaredTotalVectorAngle = wristLeftFeatures.SquaredTotalVectorAngle;
				wristLeftTotalVectorDisplacement = wristLeftFeatures.TotalVectorDisplacement;
				wristLeftTotalDisplacement = wristLeftFeatures.TotalDisplacement;
				wristLeftMaximumDisplacement = wristLeftFeatures.MaximumDisplacement;
			}
			#endregion

			#region WristRight joint features
			double? wristRightF1F2SpatialAngle = null;
			double? wristRightFN_1FNSpatialAngle = null;
			double? wristRightF1FNSpatialAngle = null;
			double? wristRightTotalVectorAngle = null;
			double? wristRightSquaredTotalVectorAngle = null;
			double? wristRightTotalVectorDisplacement = null;
			double? wristRightTotalDisplacement = null;
			double? wristRightMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.WristRight, out var wristRightFeatures))
			{
				wristRightF1F2SpatialAngle = wristRightFeatures.F1F2SpatialAngle;
				wristRightFN_1FNSpatialAngle = wristRightFeatures.FN_1FNSpatialAngle;
				wristRightF1FNSpatialAngle = wristRightFeatures.F1FNSpatialAngle;
				wristRightTotalVectorAngle = wristRightFeatures.TotalVectorAngle;
				wristRightSquaredTotalVectorAngle = wristRightFeatures.SquaredTotalVectorAngle;
				wristRightTotalVectorDisplacement = wristRightFeatures.TotalVectorDisplacement;
				wristRightTotalDisplacement = wristRightFeatures.TotalDisplacement;
				wristRightMaximumDisplacement = wristRightFeatures.MaximumDisplacement;
			}
			#endregion

			#region HandLeft joint features
			double? handLeftF1F2SpatialAngle = null;
			double? handLeftFN_1FNSpatialAngle = null;
			double? handLeftF1FNSpatialAngle = null;
			double? handLeftTotalVectorAngle = null;
			double? handLeftSquaredTotalVectorAngle = null;
			double? handLeftTotalVectorDisplacement = null;
			double? handLeftTotalDisplacement = null;
			double? handLeftMaximumDisplacement = null;
			double? handLeftBoundingBoxDiagonalLength = null;
			double? handLeftBoundingBoxAngle = null;
			//HandState[] handLeftHandStates = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.HandLeft, out var handLeftFeatures)
				&& handLeftFeatures is HandJointGestureFeatures handLeftHandFeatures)
			{
				handLeftF1F2SpatialAngle = handLeftHandFeatures.F1F2SpatialAngle;
				handLeftFN_1FNSpatialAngle = handLeftHandFeatures.FN_1FNSpatialAngle;
				handLeftF1FNSpatialAngle = handLeftHandFeatures.F1FNSpatialAngle;
				handLeftTotalVectorAngle = handLeftHandFeatures.TotalVectorAngle;
				handLeftSquaredTotalVectorAngle = handLeftHandFeatures.SquaredTotalVectorAngle;
				handLeftTotalVectorDisplacement = handLeftHandFeatures.TotalVectorDisplacement;
				handLeftTotalDisplacement = handLeftHandFeatures.TotalDisplacement;
				handLeftMaximumDisplacement = handLeftHandFeatures.MaximumDisplacement;
				handLeftBoundingBoxDiagonalLength = handLeftHandFeatures.BoundingBoxDiagonalLength;
				handLeftBoundingBoxAngle = handLeftHandFeatures.BoundingBoxAngle;
				//handLeftHandStates = handLeftHandFeatures.HandStates;
			}
			#endregion

			#region HandRight joint features
			double? handRightF1F2SpatialAngle = null;
			double? handRightFN_1FNSpatialAngle = null;
			double? handRightF1FNSpatialAngle = null;
			double? handRightTotalVectorAngle = null;
			double? handRightSquaredTotalVectorAngle = null;
			double? handRightTotalVectorDisplacement = null;
			double? handRightTotalDisplacement = null;
			double? handRightMaximumDisplacement = null;
			double? handRightBoundingBoxDiagonalLength = null;
			double? handRightBoundingBoxAngle = null;
			//HandState[] handRightHandStates = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.HandRight, out var handRightFeatures)
				&& handRightFeatures is HandJointGestureFeatures handRightHandFeatures)
			{
				handRightF1F2SpatialAngle = handRightHandFeatures.F1F2SpatialAngle;
				handRightFN_1FNSpatialAngle = handRightHandFeatures.FN_1FNSpatialAngle;
				handRightF1FNSpatialAngle = handRightHandFeatures.F1FNSpatialAngle;
				handRightTotalVectorAngle = handRightHandFeatures.TotalVectorAngle;
				handRightSquaredTotalVectorAngle = handRightHandFeatures.SquaredTotalVectorAngle;
				handRightTotalVectorDisplacement = handRightHandFeatures.TotalVectorDisplacement;
				handRightTotalDisplacement = handRightHandFeatures.TotalDisplacement;
				handRightMaximumDisplacement = handRightHandFeatures.MaximumDisplacement;
				handRightBoundingBoxDiagonalLength = handRightHandFeatures.BoundingBoxDiagonalLength;
				handRightBoundingBoxAngle = handRightHandFeatures.BoundingBoxAngle;
				//handRightHandStates = handRightHandFeatures.HandStates;
			}
			#endregion

			#region ThumbLeft joint features
			double? thumbLeftF1F2SpatialAngle = null;
			double? thumbLeftFN_1FNSpatialAngle = null;
			double? thumbLeftF1FNSpatialAngle = null;
			double? thumbLeftTotalVectorAngle = null;
			double? thumbLeftSquaredTotalVectorAngle = null;
			double? thumbLeftTotalVectorDisplacement = null;
			double? thumbLeftTotalDisplacement = null;
			double? thumbLeftMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.ThumbLeft, out var thumbLeftFeatures))
			{
				thumbLeftF1F2SpatialAngle = thumbLeftFeatures.F1F2SpatialAngle;
				thumbLeftFN_1FNSpatialAngle = thumbLeftFeatures.FN_1FNSpatialAngle;
				thumbLeftF1FNSpatialAngle = thumbLeftFeatures.F1FNSpatialAngle;
				thumbLeftTotalVectorAngle = thumbLeftFeatures.TotalVectorAngle;
				thumbLeftSquaredTotalVectorAngle = thumbLeftFeatures.SquaredTotalVectorAngle;
				thumbLeftTotalVectorDisplacement = thumbLeftFeatures.TotalVectorDisplacement;
				thumbLeftTotalDisplacement = thumbLeftFeatures.TotalDisplacement;
				thumbLeftMaximumDisplacement = thumbLeftFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbRight joint features
			double? thumbRightF1F2SpatialAngle = null;
			double? thumbRightFN_1FNSpatialAngle = null;
			double? thumbRightF1FNSpatialAngle = null;
			double? thumbRightTotalVectorAngle = null;
			double? thumbRightSquaredTotalVectorAngle = null;
			double? thumbRightTotalVectorDisplacement = null;
			double? thumbRightTotalDisplacement = null;
			double? thumbRightMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.ThumbRight, out var thumbRightFeatures))
			{
				thumbRightF1F2SpatialAngle = thumbRightFeatures.F1F2SpatialAngle;
				thumbRightFN_1FNSpatialAngle = thumbRightFeatures.FN_1FNSpatialAngle;
				thumbRightF1FNSpatialAngle = thumbRightFeatures.F1FNSpatialAngle;
				thumbRightTotalVectorAngle = thumbRightFeatures.TotalVectorAngle;
				thumbRightSquaredTotalVectorAngle = thumbRightFeatures.SquaredTotalVectorAngle;
				thumbRightTotalVectorDisplacement = thumbRightFeatures.TotalVectorDisplacement;
				thumbRightTotalDisplacement = thumbRightFeatures.TotalDisplacement;
				thumbRightMaximumDisplacement = thumbRightFeatures.MaximumDisplacement;
			}
			#endregion

			#region HandTipLeft joint features
			double? handTipLeftF1F2SpatialAngle = null;
			double? handTipLeftFN_1FNSpatialAngle = null;
			double? handTipLeftF1FNSpatialAngle = null;
			double? handTipLeftTotalVectorAngle = null;
			double? handTipLeftSquaredTotalVectorAngle = null;
			double? handTipLeftTotalVectorDisplacement = null;
			double? handTipLeftTotalDisplacement = null;
			double? handTipLeftMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.HandTipLeft, out var handTipLeftFeatures))
			{
				handTipLeftF1F2SpatialAngle = handTipLeftFeatures.F1F2SpatialAngle;
				handTipLeftFN_1FNSpatialAngle = handTipLeftFeatures.FN_1FNSpatialAngle;
				handTipLeftF1FNSpatialAngle = handTipLeftFeatures.F1FNSpatialAngle;
				handTipLeftTotalVectorAngle = handTipLeftFeatures.TotalVectorAngle;
				handTipLeftSquaredTotalVectorAngle = handTipLeftFeatures.SquaredTotalVectorAngle;
				handTipLeftTotalVectorDisplacement = handTipLeftFeatures.TotalVectorDisplacement;
				handTipLeftTotalDisplacement = handTipLeftFeatures.TotalDisplacement;
				handTipLeftMaximumDisplacement = handTipLeftFeatures.MaximumDisplacement;
			}
			#endregion

			#region HandTipRight joint features
			double? handTipRightF1F2SpatialAngle = null;
			double? handTipRightFN_1FNSpatialAngle = null;
			double? handTipRightF1FNSpatialAngle = null;
			double? handTipRightTotalVectorAngle = null;
			double? handTipRightSquaredTotalVectorAngle = null;
			double? handTipRightTotalVectorDisplacement = null;
			double? handTipRightTotalDisplacement = null;
			double? handTipRightMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(JointType.HandTipRight, out var handTipRightFeatures))
			{
				handTipRightF1F2SpatialAngle = handTipRightFeatures.F1F2SpatialAngle;
				handTipRightFN_1FNSpatialAngle = handTipRightFeatures.FN_1FNSpatialAngle;
				handTipRightF1FNSpatialAngle = handTipRightFeatures.F1FNSpatialAngle;
				handTipRightTotalVectorAngle = handTipRightFeatures.TotalVectorAngle;
				handTipRightSquaredTotalVectorAngle = handTipRightFeatures.SquaredTotalVectorAngle;
				handTipRightTotalVectorDisplacement = handTipRightFeatures.TotalVectorDisplacement;
				handTipRightTotalDisplacement = handTipRightFeatures.TotalDisplacement;
				handTipRightMaximumDisplacement = handTipRightFeatures.MaximumDisplacement;
			}
			#endregion

			#region ElbowLeftWristLeft bone features
			double? elbowLeftWristLeftBoneInitialAngle = null;
			double? elbowLeftWristLeftBoneFinalAngle = null;
			double? elbowLeftWristLeftBoneMeanAngle = null;
			double? elbowLeftWristLeftBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(ElbowLeftWristLeftBone, out var elbowLeftWristLeftBoneAngleData))
			{
				elbowLeftWristLeftBoneInitialAngle = elbowLeftWristLeftBoneAngleData.InitialAngle;
				elbowLeftWristLeftBoneFinalAngle = elbowLeftWristLeftBoneAngleData.FinalAngle;
				elbowLeftWristLeftBoneMeanAngle = elbowLeftWristLeftBoneAngleData.MeanAngle;
				elbowLeftWristLeftBoneMaximumAngle = elbowLeftWristLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ElbowRightWristRight bone features
			double? elbowRightWristRightBoneInitialAngle = null;
			double? elbowRightWristRightBoneFinalAngle = null;
			double? elbowRightWristRightBoneMeanAngle = null;
			double? elbowRightWristRightBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(ElbowRightWristRightBone, out var elbowRightWristRightBoneAngleData))
			{
				elbowRightWristRightBoneInitialAngle = elbowRightWristRightBoneAngleData.InitialAngle;
				elbowRightWristRightBoneFinalAngle = elbowRightWristRightBoneAngleData.FinalAngle;
				elbowRightWristRightBoneMeanAngle = elbowRightWristRightBoneAngleData.MeanAngle;
				elbowRightWristRightBoneMaximumAngle = elbowRightWristRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristLeftHandLeft bone features
			double? wristLeftHandLeftBoneInitialAngle = null;
			double? wristLeftHandLeftBoneFinalAngle = null;
			double? wristLeftHandLeftBoneMeanAngle = null;
			double? wristLeftHandLeftBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(WristLeftHandLeftBone, out var wristLeftHandLeftBoneAngleData))
			{
				wristLeftHandLeftBoneInitialAngle = wristLeftHandLeftBoneAngleData.InitialAngle;
				wristLeftHandLeftBoneFinalAngle = wristLeftHandLeftBoneAngleData.FinalAngle;
				wristLeftHandLeftBoneMeanAngle = wristLeftHandLeftBoneAngleData.MeanAngle;
				wristLeftHandLeftBoneMaximumAngle = wristLeftHandLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristRightHandRight bone features
			double? wristRightHandRightBoneInitialAngle = null;
			double? wristRightHandRightBoneFinalAngle = null;
			double? wristRightHandRightBoneMeanAngle = null;
			double? wristRightHandRightBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(WristRightHandRightBone, out var wristRightHandRightBoneAngleData))
			{
				wristRightHandRightBoneInitialAngle = wristRightHandRightBoneAngleData.InitialAngle;
				wristRightHandRightBoneFinalAngle = wristRightHandRightBoneAngleData.FinalAngle;
				wristRightHandRightBoneMeanAngle = wristRightHandRightBoneAngleData.MeanAngle;
				wristRightHandRightBoneMaximumAngle = wristRightHandRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region HandLeftHandTipLeft bone features
			double? handLeftHandTipLeftBoneInitialAngle = null;
			double? handLeftHandTipLeftBoneFinalAngle = null;
			double? handLeftHandTipLeftBoneMeanAngle = null;
			double? handLeftHandTipLeftBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(HandLeftHandTipLeftBone, out var handLeftHandTipLeftBoneAngleData))
			{
				handLeftHandTipLeftBoneInitialAngle = handLeftHandTipLeftBoneAngleData.InitialAngle;
				handLeftHandTipLeftBoneFinalAngle = handLeftHandTipLeftBoneAngleData.FinalAngle;
				handLeftHandTipLeftBoneMeanAngle = handLeftHandTipLeftBoneAngleData.MeanAngle;
				handLeftHandTipLeftBoneMaximumAngle = handLeftHandTipLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region HandRightHandTipRight bone features
			double? handRightHandTipRightBoneInitialAngle = null;
			double? handRightHandTipRightBoneFinalAngle = null;
			double? handRightHandTipRightBoneMeanAngle = null;
			double? handRightHandTipRightBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(HandRightHandTipRightBone, out var handRightHandTipRightBoneAngleData))
			{
				handRightHandTipRightBoneInitialAngle = handRightHandTipRightBoneAngleData.InitialAngle;
				handRightHandTipRightBoneFinalAngle = handRightHandTipRightBoneAngleData.FinalAngle;
				handRightHandTipRightBoneMeanAngle = handRightHandTipRightBoneAngleData.MeanAngle;
				handRightHandTipRightBoneMaximumAngle = handRightHandTipRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region Hands distances features
			double? betweenHandJointsDistanceMax = features.BetweenHandJointsDistanceMax;
			double? betweenHandJointsDistanceMean = features.BetweenHandJointsDistanceMean;
			#endregion

			return new GestureDataView()
			{
				#region ElbowLeft joint features
				ElbowLeftF1F2SpatialAngle = elbowLeftF1F2SpatialAngle,
				ElbowLeftFN_1FNSpatialAngle = elbowLeftFN_1FNSpatialAngle,
				ElbowLeftF1FNSpatialAngle = elbowLeftF1FNSpatialAngle,
				ElbowLeftTotalVectorAngle = elbowLeftTotalVectorAngle,
				ElbowLeftSquaredTotalVectorAngle = elbowLeftSquaredTotalVectorAngle,
				ElbowLeftTotalVectorDisplacement = elbowLeftTotalVectorDisplacement,
				ElbowLeftTotalDisplacement = elbowLeftTotalDisplacement,
				ElbowLeftMaximumDisplacement = elbowLeftMaximumDisplacement,
				#endregion

				#region ElbowRight joint features
				ElbowRightF1F2SpatialAngle = elbowRightF1F2SpatialAngle,
				ElbowRightFN_1FNSpatialAngle = elbowRightFN_1FNSpatialAngle,
				ElbowRightF1FNSpatialAngle = elbowRightF1FNSpatialAngle,
				ElbowRightTotalVectorAngle = elbowRightTotalVectorAngle,
				ElbowRightSquaredTotalVectorAngle = elbowRightSquaredTotalVectorAngle,
				ElbowRightTotalVectorDisplacement = elbowRightTotalVectorDisplacement,
				ElbowRightTotalDisplacement = elbowRightTotalDisplacement,
				ElbowRightMaximumDisplacement = elbowRightMaximumDisplacement,
				#endregion

				#region WristLeft joint features
				WristLeftF1F2SpatialAngle = wristLeftF1F2SpatialAngle,
				WristLeftFN_1FNSpatialAngle = wristLeftFN_1FNSpatialAngle,
				WristLeftF1FNSpatialAngle = wristLeftF1FNSpatialAngle,
				WristLeftTotalVectorAngle = wristLeftTotalVectorAngle,
				WristLeftSquaredTotalVectorAngle = wristLeftSquaredTotalVectorAngle,
				WristLeftTotalVectorDisplacement = wristLeftTotalVectorDisplacement,
				WristLeftTotalDisplacement = wristLeftTotalDisplacement,
				WristLeftMaximumDisplacement = wristLeftMaximumDisplacement,
				#endregion

				#region WristRight joint features
				WristRightF1F2SpatialAngle = wristRightF1F2SpatialAngle,
				WristRightFN_1FNSpatialAngle = wristRightFN_1FNSpatialAngle,
				WristRightF1FNSpatialAngle = wristRightF1FNSpatialAngle,
				WristRightTotalVectorAngle = wristRightTotalVectorAngle,
				WristRightSquaredTotalVectorAngle = wristRightSquaredTotalVectorAngle,
				WristRightTotalVectorDisplacement = wristRightTotalVectorDisplacement,
				WristRightTotalDisplacement = wristRightTotalDisplacement,
				WristRightMaximumDisplacement = wristRightMaximumDisplacement,
				#endregion

				#region HandLeft joint features
				HandLeftF1F2SpatialAngle = handLeftF1F2SpatialAngle,
				HandLeftFN_1FNSpatialAngle = handLeftFN_1FNSpatialAngle,
				HandLeftF1FNSpatialAngle = handLeftF1FNSpatialAngle,
				HandLeftTotalVectorAngle = handLeftTotalVectorAngle,
				HandLeftSquaredTotalVectorAngle = handLeftSquaredTotalVectorAngle,
				HandLeftTotalVectorDisplacement = handLeftTotalVectorDisplacement,
				HandLeftTotalDisplacement = handLeftTotalDisplacement,
				HandLeftMaximumDisplacement = handLeftMaximumDisplacement,
				HandLeftBoundingBoxDiagonalLength = handLeftBoundingBoxDiagonalLength,
				HandLeftBoundingBoxAngle = handLeftBoundingBoxAngle,
				//HandLeftHandStates = handLeftHandStates,
				#endregion

				#region HandRight joint features
				HandRightF1F2SpatialAngle = handRightF1F2SpatialAngle,
				HandRightFN_1FNSpatialAngle = handRightFN_1FNSpatialAngle,
				HandRightF1FNSpatialAngle = handRightF1FNSpatialAngle,
				HandRightTotalVectorAngle = handRightTotalVectorAngle,
				HandRightSquaredTotalVectorAngle = handRightSquaredTotalVectorAngle,
				HandRightTotalVectorDisplacement = handRightTotalVectorDisplacement,
				HandRightTotalDisplacement = handRightTotalDisplacement,
				HandRightMaximumDisplacement = handRightMaximumDisplacement,
				HandRightBoundingBoxDiagonalLength = handRightBoundingBoxDiagonalLength,
				HandRightBoundingBoxAngle = handRightBoundingBoxAngle,
				//HandRightHandStates = handRightHandStates,
				#endregion

				#region ThumbLeft joint features
				ThumbLeftF1F2SpatialAngle = thumbLeftF1F2SpatialAngle,
				ThumbLeftFN_1FNSpatialAngle = thumbLeftFN_1FNSpatialAngle,
				ThumbLeftF1FNSpatialAngle = thumbLeftF1FNSpatialAngle,
				ThumbLeftTotalVectorAngle = thumbLeftTotalVectorAngle,
				ThumbLeftSquaredTotalVectorAngle = thumbLeftSquaredTotalVectorAngle,
				ThumbLeftTotalVectorDisplacement = thumbLeftTotalVectorDisplacement,
				ThumbLeftTotalDisplacement = thumbLeftTotalDisplacement,
				ThumbLeftMaximumDisplacement = thumbLeftMaximumDisplacement,
				#endregion

				#region ThumbRight joint features
				ThumbRightF1F2SpatialAngle = thumbRightF1F2SpatialAngle,
				ThumbRightFN_1FNSpatialAngle = thumbRightFN_1FNSpatialAngle,
				ThumbRightF1FNSpatialAngle = thumbRightF1FNSpatialAngle,
				ThumbRightTotalVectorAngle = thumbRightTotalVectorAngle,
				ThumbRightSquaredTotalVectorAngle = thumbRightSquaredTotalVectorAngle,
				ThumbRightTotalVectorDisplacement = thumbRightTotalVectorDisplacement,
				ThumbRightTotalDisplacement = thumbRightTotalDisplacement,
				ThumbRightMaximumDisplacement = thumbRightMaximumDisplacement,
				#endregion

				#region HandTipLeft joint features
				HandTipLeftF1F2SpatialAngle = handTipLeftF1F2SpatialAngle,
				HandTipLeftFN_1FNSpatialAngle = handTipLeftFN_1FNSpatialAngle,
				HandTipLeftF1FNSpatialAngle = handTipLeftF1FNSpatialAngle,
				HandTipLeftTotalVectorAngle = handTipLeftTotalVectorAngle,
				HandTipLeftSquaredTotalVectorAngle = handTipLeftSquaredTotalVectorAngle,
				HandTipLeftTotalVectorDisplacement = handTipLeftTotalVectorDisplacement,
				HandTipLeftTotalDisplacement = handTipLeftTotalDisplacement,
				HandTipLeftMaximumDisplacement = handTipLeftMaximumDisplacement,
				#endregion

				#region HandTipRight joint features
				HandTipRightF1F2SpatialAngle = handTipRightF1F2SpatialAngle,
				HandTipRightFN_1FNSpatialAngle = handTipRightFN_1FNSpatialAngle,
				HandTipRightF1FNSpatialAngle = handTipRightF1FNSpatialAngle,
				HandTipRightTotalVectorAngle = handTipRightTotalVectorAngle,
				HandTipRightSquaredTotalVectorAngle = handTipRightSquaredTotalVectorAngle,
				HandTipRightTotalVectorDisplacement = handTipRightTotalVectorDisplacement,
				HandTipRightTotalDisplacement = handTipRightTotalDisplacement,
				HandTipRightMaximumDisplacement = handTipRightMaximumDisplacement,
				#endregion

				#region ElbowLeftWristLeft bone features
				ElbowLeftWristLeftBoneInitialAngle = elbowLeftWristLeftBoneInitialAngle,
				ElbowLeftWristLeftBoneFinalAngle = elbowLeftWristLeftBoneFinalAngle,
				ElbowLeftWristLeftBoneMeanAngle = elbowLeftWristLeftBoneMeanAngle,
				ElbowLeftWristLeftBoneMaximumAngle = elbowLeftWristLeftBoneMaximumAngle,
				#endregion

				#region ElbowRightWristRight bone features
				ElbowRightWristRightBoneInitialAngle = elbowRightWristRightBoneInitialAngle,
				ElbowRightWristRightBoneFinalAngle = elbowRightWristRightBoneFinalAngle,
				ElbowRightWristRightBoneMeanAngle = elbowRightWristRightBoneMeanAngle,
				ElbowRightWristRightBoneMaximumAngle = elbowRightWristRightBoneMaximumAngle,
				#endregion

				#region WristLeftHandLeft bone features
				WristLeftHandLeftBoneInitialAngle = wristLeftHandLeftBoneInitialAngle,
				WristLeftHandLeftBoneFinalAngle = wristLeftHandLeftBoneFinalAngle,
				WristLeftHandLeftBoneMeanAngle = wristLeftHandLeftBoneMeanAngle,
				WristLeftHandLeftBoneMaximumAngle = wristLeftHandLeftBoneMaximumAngle,
				#endregion

				#region WristRightHandRight bone features
				WristRightHandRightBoneInitialAngle = wristRightHandRightBoneInitialAngle,
				WristRightHandRightBoneFinalAngle = wristRightHandRightBoneFinalAngle,
				WristRightHandRightBoneMeanAngle = wristRightHandRightBoneMeanAngle,
				WristRightHandRightBoneMaximumAngle = wristRightHandRightBoneMaximumAngle,
				#endregion

				#region HandLeftHandTipLeft bone features
				HandLeftHandTipLeftBoneInitialAngle = handLeftHandTipLeftBoneInitialAngle,
				HandLeftHandTipLeftBoneFinalAngle = handLeftHandTipLeftBoneFinalAngle,
				HandLeftHandTipLeftBoneMeanAngle = handLeftHandTipLeftBoneFinalAngle,
				HandLeftHandTipLeftBoneMaximumAngle = handLeftHandTipLeftBoneMaximumAngle,
				#endregion

				#region HandRightHandTipRight bone features
				HandRightHandTipRightBoneInitialAngle = handRightHandTipRightBoneInitialAngle,
				HandRightHandTipRightBoneFinalAngle = handRightHandTipRightBoneFinalAngle,
				HandRightHandTipRightBoneMeanAngle = handRightHandTipRightBoneMeanAngle,
				HandRightHandTipRightBoneMaximumAngle = handRightHandTipRightBoneMaximumAngle,
				#endregion

				#region Hands distances features
				BetweenHandJointsDistanceMax = betweenHandJointsDistanceMax,
				BetweenHandJointsDistanceMean = betweenHandJointsDistanceMean,
				#endregion

				Label = label,
			};
		}
		#endregion

		#region GestureDataView -> (GestureFeatures, string)
		public static (GestureFeatures features, string label) Map(this GestureDataView gesture)
		{
			if (gesture == null)
				return (null, null);

			var features = new GestureFeatures(GestureRecognitionJoints, GestureRecognitionBones);

			#region ElbowLeft joint features
			double? elbowLeftF1F2SpatialAngle = gesture.ElbowLeftF1F2SpatialAngle;
			double? elbowLeftFN_1FNSpatialAngle = gesture.ElbowLeftFN_1FNSpatialAngle;
			double? elbowLeftF1FNSpatialAngle = gesture.ElbowLeftF1FNSpatialAngle;
			double? elbowLeftTotalVectorAngle = gesture.ElbowLeftTotalVectorAngle;
			double? elbowLeftSquaredTotalVectorAngle = gesture.ElbowLeftSquaredTotalVectorAngle;
			double? elbowLeftTotalVectorDisplacement = gesture.ElbowLeftTotalVectorDisplacement;
			double? elbowLeftTotalDisplacement = gesture.ElbowLeftTotalDisplacement;
			double? elbowLeftMaximumDisplacement = gesture.ElbowLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ElbowLeft, new JointGestureFeatures(elbowLeftF1F2SpatialAngle,
				elbowLeftFN_1FNSpatialAngle, elbowLeftF1FNSpatialAngle, elbowLeftTotalVectorAngle, elbowLeftSquaredTotalVectorAngle,
				elbowLeftTotalVectorDisplacement, elbowLeftTotalDisplacement, elbowLeftMaximumDisplacement));
			#endregion

			#region ElbowRight joint features
			double? elbowRightF1F2SpatialAngle = gesture.ElbowRightF1F2SpatialAngle;
			double? elbowRightFN_1FNSpatialAngle = gesture.ElbowRightFN_1FNSpatialAngle;
			double? elbowRightF1FNSpatialAngle = gesture.ElbowRightF1FNSpatialAngle;
			double? elbowRightTotalVectorAngle = gesture.ElbowRightTotalVectorAngle;
			double? elbowRightSquaredTotalVectorAngle = gesture.ElbowRightSquaredTotalVectorAngle;
			double? elbowRightTotalVectorDisplacement = gesture.ElbowRightTotalVectorDisplacement;
			double? elbowRightTotalDisplacement = gesture.ElbowRightTotalDisplacement;
			double? elbowRightMaximumDisplacement = gesture.ElbowRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ElbowRight, new JointGestureFeatures(elbowRightF1F2SpatialAngle,
				elbowRightFN_1FNSpatialAngle, elbowRightF1FNSpatialAngle, elbowRightTotalVectorAngle, elbowRightSquaredTotalVectorAngle,
				elbowRightTotalVectorDisplacement, elbowRightTotalDisplacement, elbowRightMaximumDisplacement));
			#endregion

			#region WristLeft joint features
			double? wristLeftF1F2SpatialAngle = gesture.WristLeftF1F2SpatialAngle;
			double? wristLeftFN_1FNSpatialAngle = gesture.WristLeftFN_1FNSpatialAngle;
			double? wristLeftF1FNSpatialAngle = gesture.WristLeftF1FNSpatialAngle;
			double? wristLeftTotalVectorAngle = gesture.WristLeftTotalVectorAngle;
			double? wristLeftSquaredTotalVectorAngle = gesture.WristLeftSquaredTotalVectorAngle;
			double? wristLeftTotalVectorDisplacement = gesture.WristLeftTotalVectorDisplacement;
			double? wristLeftTotalDisplacement = gesture.WristLeftTotalDisplacement;
			double? wristLeftMaximumDisplacement = gesture.WristLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.WristLeft, new JointGestureFeatures(wristLeftF1F2SpatialAngle,
				wristLeftFN_1FNSpatialAngle, wristLeftF1FNSpatialAngle, wristLeftTotalVectorAngle, wristLeftSquaredTotalVectorAngle,
				wristLeftTotalVectorDisplacement, wristLeftTotalDisplacement, wristLeftMaximumDisplacement));
			#endregion

			#region WristRight joint features
			double? wristRightF1F2SpatialAngle = gesture.WristRightF1F2SpatialAngle;
			double? wristRightFN_1FNSpatialAngle = gesture.WristRightFN_1FNSpatialAngle;
			double? wristRightF1FNSpatialAngle = gesture.WristRightF1FNSpatialAngle;
			double? wristRightTotalVectorAngle = gesture.WristRightTotalVectorAngle;
			double? wristRightSquaredTotalVectorAngle = gesture.WristRightSquaredTotalVectorAngle;
			double? wristRightTotalVectorDisplacement = gesture.WristRightTotalVectorDisplacement;
			double? wristRightTotalDisplacement = gesture.WristRightTotalDisplacement;
			double? wristRightMaximumDisplacement = gesture.WristRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.WristRight, new JointGestureFeatures(wristRightF1F2SpatialAngle,
				wristRightFN_1FNSpatialAngle, wristRightF1FNSpatialAngle, wristRightTotalVectorAngle, wristRightSquaredTotalVectorAngle,
				wristRightTotalVectorDisplacement, wristRightTotalDisplacement, wristRightMaximumDisplacement));
			#endregion

			#region HandLeft joint features
			double? handLeftF1F2SpatialAngle = gesture.HandLeftF1F2SpatialAngle;
			double? handLeftFN_1FNSpatialAngle = gesture.HandLeftFN_1FNSpatialAngle;
			double? handLeftF1FNSpatialAngle = gesture.HandLeftF1FNSpatialAngle;
			double? handLeftTotalVectorAngle = gesture.HandLeftTotalVectorAngle;
			double? handLeftSquaredTotalVectorAngle = gesture.HandLeftSquaredTotalVectorAngle;
			double? handLeftTotalVectorDisplacement = gesture.HandLeftTotalVectorDisplacement;
			double? handLeftTotalDisplacement = gesture.HandLeftTotalDisplacement;
			double? handLeftMaximumDisplacement = gesture.HandLeftMaximumDisplacement;
			double? handLeftBoundingBoxDiagonalLength = gesture.HandLeftBoundingBoxDiagonalLength;
			double? handLeftBoundingBoxAngle = gesture.HandLeftBoundingBoxAngle;
			//HandState[] handLeftHandStates = gesture.HandLeftHandStates;
			features.AddJointGestureFeature(JointType.HandLeft, new HandJointGestureFeatures(handLeftF1F2SpatialAngle,
				handLeftFN_1FNSpatialAngle, handLeftF1FNSpatialAngle, handLeftTotalVectorAngle, handLeftSquaredTotalVectorAngle,
				handLeftTotalVectorDisplacement, handLeftTotalDisplacement, handLeftMaximumDisplacement,
				handLeftBoundingBoxDiagonalLength, handLeftBoundingBoxAngle/*, handLeftHandStates*/));
			#endregion

			#region HandRight joint features
			double? handRightF1F2SpatialAngle = gesture.HandRightF1F2SpatialAngle;
			double? handRightFN_1FNSpatialAngle = gesture.HandRightFN_1FNSpatialAngle;
			double? handRightF1FNSpatialAngle = gesture.HandRightF1FNSpatialAngle;
			double? handRightTotalVectorAngle = gesture.HandRightTotalVectorAngle;
			double? handRightSquaredTotalVectorAngle = gesture.HandRightSquaredTotalVectorAngle;
			double? handRightTotalVectorDisplacement = gesture.HandRightTotalVectorDisplacement;
			double? handRightTotalDisplacement = gesture.HandRightTotalDisplacement;
			double? handRightMaximumDisplacement = gesture.HandRightMaximumDisplacement;
			double? handRightBoundingBoxDiagonalLength = gesture.HandRightBoundingBoxDiagonalLength;
			double? handRightBoundingBoxAngle = gesture.HandRightBoundingBoxAngle;
			//HandState[] handRightHandStates = gesture.HandRightHandStates;
			features.AddJointGestureFeature(JointType.HandRight, new HandJointGestureFeatures(handRightF1F2SpatialAngle,
				handRightFN_1FNSpatialAngle, handRightF1FNSpatialAngle, handRightTotalVectorAngle, handRightSquaredTotalVectorAngle,
				handRightTotalVectorDisplacement, handRightTotalDisplacement, handRightMaximumDisplacement,
				handRightBoundingBoxDiagonalLength, handRightBoundingBoxAngle/*, handRightHandStates*/));
			#endregion

			#region ThumbLeft joint features
			double? thumbLeftF1F2SpatialAngle = gesture.ThumbLeftF1F2SpatialAngle;
			double? thumbLeftFN_1FNSpatialAngle = gesture.ThumbLeftFN_1FNSpatialAngle;
			double? thumbLeftF1FNSpatialAngle = gesture.ThumbLeftF1FNSpatialAngle;
			double? thumbLeftTotalVectorAngle = gesture.ThumbLeftTotalVectorAngle;
			double? thumbLeftSquaredTotalVectorAngle = gesture.ThumbLeftSquaredTotalVectorAngle;
			double? thumbLeftTotalVectorDisplacement = gesture.ThumbLeftTotalVectorDisplacement;
			double? thumbLeftTotalDisplacement = gesture.ThumbLeftTotalDisplacement;
			double? thumbLeftMaximumDisplacement = gesture.ThumbLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ThumbLeft, new JointGestureFeatures(thumbLeftF1F2SpatialAngle,
				thumbLeftFN_1FNSpatialAngle, thumbLeftF1FNSpatialAngle, thumbLeftTotalVectorAngle, thumbLeftSquaredTotalVectorAngle,
				thumbLeftTotalVectorDisplacement, thumbLeftTotalDisplacement, thumbLeftMaximumDisplacement));
			#endregion

			#region ThumbRight joint features
			double? thumbRightF1F2SpatialAngle = gesture.ThumbRightF1F2SpatialAngle;
			double? thumbRightFN_1FNSpatialAngle = gesture.ThumbRightFN_1FNSpatialAngle;
			double? thumbRightF1FNSpatialAngle = gesture.ThumbRightF1FNSpatialAngle;
			double? thumbRightTotalVectorAngle = gesture.ThumbRightTotalVectorAngle;
			double? thumbRightSquaredTotalVectorAngle = gesture.ThumbRightSquaredTotalVectorAngle;
			double? thumbRightTotalVectorDisplacement = gesture.ThumbRightTotalVectorDisplacement;
			double? thumbRightTotalDisplacement = gesture.ThumbRightTotalDisplacement;
			double? thumbRightMaximumDisplacement = gesture.ThumbRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ThumbRight, new JointGestureFeatures(thumbRightF1F2SpatialAngle,
				thumbRightFN_1FNSpatialAngle, thumbRightF1FNSpatialAngle, thumbRightTotalVectorAngle, thumbRightSquaredTotalVectorAngle,
				thumbRightTotalVectorDisplacement, thumbRightTotalDisplacement, thumbRightMaximumDisplacement));
			#endregion

			#region HandTipLeft joint features
			double? handTipLeftF1F2SpatialAngle = gesture.HandTipLeftF1F2SpatialAngle;
			double? handTipLeftFN_1FNSpatialAngle = gesture.HandTipLeftFN_1FNSpatialAngle;
			double? handTipLeftF1FNSpatialAngle = gesture.HandTipLeftF1FNSpatialAngle;
			double? handTipLeftTotalVectorAngle = gesture.HandTipLeftTotalVectorAngle;
			double? handTipLeftSquaredTotalVectorAngle = gesture.HandTipLeftSquaredTotalVectorAngle;
			double? handTipLeftTotalVectorDisplacement = gesture.HandTipLeftTotalVectorDisplacement;
			double? handTipLeftTotalDisplacement = gesture.HandTipLeftTotalDisplacement;
			double? handTipLeftMaximumDisplacement = gesture.HandTipLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.HandTipLeft, new JointGestureFeatures(handTipLeftF1F2SpatialAngle,
				handTipLeftFN_1FNSpatialAngle, handTipLeftF1FNSpatialAngle, handTipLeftTotalVectorAngle, handTipLeftSquaredTotalVectorAngle,
				handTipLeftTotalVectorDisplacement, handTipLeftTotalDisplacement, handTipLeftMaximumDisplacement));
			#endregion

			#region HandTipRight joint features
			double? handTipRightF1F2SpatialAngle = gesture.HandTipRightF1F2SpatialAngle;
			double? handTipRightFN_1FNSpatialAngle = gesture.HandTipRightFN_1FNSpatialAngle;
			double? handTipRightF1FNSpatialAngle = gesture.HandTipRightF1FNSpatialAngle;
			double? handTipRightTotalVectorAngle = gesture.HandTipRightTotalVectorAngle;
			double? handTipRightSquaredTotalVectorAngle = gesture.HandTipRightSquaredTotalVectorAngle;
			double? handTipRightTotalVectorDisplacement = gesture.HandTipRightTotalVectorDisplacement;
			double? handTipRightTotalDisplacement = gesture.HandTipRightTotalDisplacement;
			double? handTipRightMaximumDisplacement = gesture.HandTipRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.HandTipRight, new JointGestureFeatures(handTipRightF1F2SpatialAngle,
				handTipRightFN_1FNSpatialAngle, handTipRightF1FNSpatialAngle, handTipRightTotalVectorAngle, handTipRightSquaredTotalVectorAngle,
				handTipRightTotalVectorDisplacement, handTipRightTotalDisplacement, handTipRightMaximumDisplacement));
			#endregion

			#region ElbowLeftWristLeft bone features
			double? elbowLeftWristLeftBoneInitialAngle = gesture.ElbowLeftWristLeftBoneInitialAngle;
			double? elbowLeftWristLeftBoneFinalAngle = gesture.ElbowLeftWristLeftBoneFinalAngle;
			double? elbowLeftWristLeftBoneMeanAngle = gesture.ElbowLeftWristLeftBoneMeanAngle;
			double? elbowLeftWristLeftBoneMaximumAngle = gesture.ElbowLeftWristLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(ElbowLeftWristLeftBone, new BoneJointsAngleData(elbowLeftWristLeftBoneInitialAngle,
				elbowLeftWristLeftBoneFinalAngle, elbowLeftWristLeftBoneMeanAngle, elbowLeftWristLeftBoneMaximumAngle));
			#endregion

			#region ElbowRightWristRight bone features
			double? elbowRightWristRightBoneInitialAngle = gesture.ElbowRightWristRightBoneInitialAngle;
			double? elbowRightWristRightBoneFinalAngle = gesture.ElbowRightWristRightBoneFinalAngle;
			double? elbowRightWristRightBoneMeanAngle = gesture.ElbowRightWristRightBoneMeanAngle;
			double? elbowRightWristRightBoneMaximumAngle = gesture.ElbowRightWristRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(ElbowRightWristRightBone, new BoneJointsAngleData(elbowRightWristRightBoneInitialAngle,
				elbowRightWristRightBoneFinalAngle, elbowRightWristRightBoneMeanAngle, elbowRightWristRightBoneMaximumAngle));
			#endregion

			#region WristLeftHandLeft bone features
			double? wristLeftHandLeftBoneInitialAngle = gesture.WristLeftHandLeftBoneInitialAngle;
			double? wristLeftHandLeftBoneFinalAngle = gesture.WristLeftHandLeftBoneFinalAngle;
			double? wristLeftHandLeftBoneMeanAngle = gesture.WristLeftHandLeftBoneMeanAngle;
			double? wristLeftHandLeftBoneMaximumAngle = gesture.WristLeftHandLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(WristLeftHandLeftBone, new BoneJointsAngleData(wristLeftHandLeftBoneInitialAngle,
				wristLeftHandLeftBoneFinalAngle, wristLeftHandLeftBoneMeanAngle, wristLeftHandLeftBoneMaximumAngle));
			#endregion

			#region WristRightHandRight bone features
			double? wristRightHandRightBoneInitialAngle = gesture.WristRightHandRightBoneInitialAngle;
			double? wristRightHandRightBoneFinalAngle = gesture.WristRightHandRightBoneFinalAngle;
			double? wristRightHandRightBoneMeanAngle = gesture.WristRightHandRightBoneMeanAngle;
			double? wristRightHandRightBoneMaximumAngle = gesture.WristRightHandRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(WristRightHandRightBone, new BoneJointsAngleData(wristRightHandRightBoneInitialAngle,
				wristRightHandRightBoneFinalAngle, wristRightHandRightBoneMeanAngle, wristRightHandRightBoneMaximumAngle));
			#endregion

			#region HandLeftHandTipLeft bone features
			double? handLeftHandTipLeftBoneInitialAngle = gesture.HandLeftHandTipLeftBoneInitialAngle;
			double? handLeftHandTipLeftBoneFinalAngle = gesture.HandLeftHandTipLeftBoneFinalAngle;
			double? handLeftHandTipLeftBoneMeanAngle = gesture.HandLeftHandTipLeftBoneMeanAngle;
			double? handLeftHandTipLeftBoneMaximumAngle = gesture.HandLeftHandTipLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(HandLeftHandTipLeftBone, new BoneJointsAngleData(handLeftHandTipLeftBoneInitialAngle,
				handLeftHandTipLeftBoneFinalAngle, handLeftHandTipLeftBoneMeanAngle, handLeftHandTipLeftBoneMaximumAngle));
			#endregion

			#region HandRightHandTipRight bone features
			double? handRightHandTipRightBoneInitialAngle = gesture.HandRightHandTipRightBoneInitialAngle;
			double? handRightHandTipRightBoneFinalAngle = gesture.HandRightHandTipRightBoneFinalAngle;
			double? handRightHandTipRightBoneMeanAngle = gesture.HandRightHandTipRightBoneMeanAngle;
			double? handRightHandTipRightBoneMaximumAngle = gesture.HandRightHandTipRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(HandRightHandTipRightBone, new BoneJointsAngleData(handRightHandTipRightBoneInitialAngle,
				handRightHandTipRightBoneFinalAngle, handRightHandTipRightBoneMeanAngle, handRightHandTipRightBoneMaximumAngle));
			#endregion

			#region Hands distances features
			features.BetweenHandJointsDistanceMax = gesture.BetweenHandJointsDistanceMax;
			features.BetweenHandJointsDistanceMean = gesture.BetweenHandJointsDistanceMean;
			#endregion

			return (features, gesture.Label);
		}
		#endregion
	}
}
