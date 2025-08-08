using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using KinectBonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.KinectBonesDefinitions;
using MediaPipeHandLandmarksBonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.MediaPipeHandLandmarksBonesDefinitions;
using KinectGestureRecognitionDefs = GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures.KinectGestureRecognitionDefinitions;
using MediaPipeHandLandmarksGestureRecognitionDefs = GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures.MediaPipeHandLandmarksGestureRecognitionDefinitions;

namespace GestureRecognition.Processing.BaseClassLib.Mappers
{
	public static class GestureRecognitionMapper
	{
		#region GestureFeatures -> KinectGestureDataView
		public static KinectGestureDataView MapToKinectGestureDataView(this GestureFeatures features, string label)
		{
			if (features == null)
				return null;

			if (!features.IsValid)
				return new KinectGestureDataView();

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
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.ElbowLeftWristLeftBone, out var elbowLeftWristLeftBoneAngleData))
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
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.ElbowRightWristRightBone, out var elbowRightWristRightBoneAngleData))
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
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.WristLeftHandLeftBone, out var wristLeftHandLeftBoneAngleData))
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
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.WristRightHandRightBone, out var wristRightHandRightBoneAngleData))
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
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.HandLeftHandTipLeftBone, out var handLeftHandTipLeftBoneAngleData))
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
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.HandRightHandTipRightBone, out var handRightHandTipRightBoneAngleData))
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

			return new KinectGestureDataView()
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

		#region KinectGestureDataView -> (GestureFeatures, string)
		public static (GestureFeatures features, string label) MapFromKinectGestureDataView(this KinectGestureDataView gesture)
		{
			if (gesture == null)
				return (null, null);

			var features = new GestureFeatures(KinectGestureRecognitionDefs.GestureRecognitionJoints, KinectGestureRecognitionDefs.GestureRecognitionBones);

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
			features.AddBoneJointsAngleData(KinectBonesDefs.ElbowLeftWristLeftBone, new BoneJointsAngleData(elbowLeftWristLeftBoneInitialAngle,
				elbowLeftWristLeftBoneFinalAngle, elbowLeftWristLeftBoneMeanAngle, elbowLeftWristLeftBoneMaximumAngle));
			#endregion

			#region ElbowRightWristRight bone features
			double? elbowRightWristRightBoneInitialAngle = gesture.ElbowRightWristRightBoneInitialAngle;
			double? elbowRightWristRightBoneFinalAngle = gesture.ElbowRightWristRightBoneFinalAngle;
			double? elbowRightWristRightBoneMeanAngle = gesture.ElbowRightWristRightBoneMeanAngle;
			double? elbowRightWristRightBoneMaximumAngle = gesture.ElbowRightWristRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.ElbowRightWristRightBone, new BoneJointsAngleData(elbowRightWristRightBoneInitialAngle,
				elbowRightWristRightBoneFinalAngle, elbowRightWristRightBoneMeanAngle, elbowRightWristRightBoneMaximumAngle));
			#endregion

			#region WristLeftHandLeft bone features
			double? wristLeftHandLeftBoneInitialAngle = gesture.WristLeftHandLeftBoneInitialAngle;
			double? wristLeftHandLeftBoneFinalAngle = gesture.WristLeftHandLeftBoneFinalAngle;
			double? wristLeftHandLeftBoneMeanAngle = gesture.WristLeftHandLeftBoneMeanAngle;
			double? wristLeftHandLeftBoneMaximumAngle = gesture.WristLeftHandLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.WristLeftHandLeftBone, new BoneJointsAngleData(wristLeftHandLeftBoneInitialAngle,
				wristLeftHandLeftBoneFinalAngle, wristLeftHandLeftBoneMeanAngle, wristLeftHandLeftBoneMaximumAngle));
			#endregion

			#region WristRightHandRight bone features
			double? wristRightHandRightBoneInitialAngle = gesture.WristRightHandRightBoneInitialAngle;
			double? wristRightHandRightBoneFinalAngle = gesture.WristRightHandRightBoneFinalAngle;
			double? wristRightHandRightBoneMeanAngle = gesture.WristRightHandRightBoneMeanAngle;
			double? wristRightHandRightBoneMaximumAngle = gesture.WristRightHandRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.WristRightHandRightBone, new BoneJointsAngleData(wristRightHandRightBoneInitialAngle,
				wristRightHandRightBoneFinalAngle, wristRightHandRightBoneMeanAngle, wristRightHandRightBoneMaximumAngle));
			#endregion

			#region HandLeftHandTipLeft bone features
			double? handLeftHandTipLeftBoneInitialAngle = gesture.HandLeftHandTipLeftBoneInitialAngle;
			double? handLeftHandTipLeftBoneFinalAngle = gesture.HandLeftHandTipLeftBoneFinalAngle;
			double? handLeftHandTipLeftBoneMeanAngle = gesture.HandLeftHandTipLeftBoneMeanAngle;
			double? handLeftHandTipLeftBoneMaximumAngle = gesture.HandLeftHandTipLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.HandLeftHandTipLeftBone, new BoneJointsAngleData(handLeftHandTipLeftBoneInitialAngle,
				handLeftHandTipLeftBoneFinalAngle, handLeftHandTipLeftBoneMeanAngle, handLeftHandTipLeftBoneMaximumAngle));
			#endregion

			#region HandRightHandTipRight bone features
			double? handRightHandTipRightBoneInitialAngle = gesture.HandRightHandTipRightBoneInitialAngle;
			double? handRightHandTipRightBoneFinalAngle = gesture.HandRightHandTipRightBoneFinalAngle;
			double? handRightHandTipRightBoneMeanAngle = gesture.HandRightHandTipRightBoneMeanAngle;
			double? handRightHandTipRightBoneMaximumAngle = gesture.HandRightHandTipRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.HandRightHandTipRightBone, new BoneJointsAngleData(handRightHandTipRightBoneInitialAngle,
				handRightHandTipRightBoneFinalAngle, handRightHandTipRightBoneMeanAngle, handRightHandTipRightBoneMaximumAngle));
			#endregion

			#region Hands distances features
			features.BetweenHandJointsDistanceMax = gesture.BetweenHandJointsDistanceMax;
			features.BetweenHandJointsDistanceMean = gesture.BetweenHandJointsDistanceMean;
			#endregion

			return (features, gesture.Label);
		}
		#endregion

		#region GestureFeatures -> MediaPipeHandLandmarksGestureDataView
		public static MediaPipeHandLandmarksGestureDataView MapToMediaPipeHandLandmarksGestureDataView(this GestureFeatures features, string label)
		{
			if (features == null)
				return null;

			if (!features.IsValid)
				return new MediaPipeHandLandmarksGestureDataView();

			#region WristDominant joint features
			double? wristDominantF1F2SpatialAngle = null;
			double? wristDominantFN_1FNSpatialAngle = null;
			double? wristDominantF1FNSpatialAngle = null;
			double? wristDominantTotalVectorAngle = null;
			double? wristDominantSquaredTotalVectorAngle = null;
			double? wristDominantTotalVectorDisplacement = null;
			double? wristDominantTotalDisplacement = null;
			double? wristDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.WristLeft, JointType.WristRight, features.HandDominance, true),
				out var wristDominantFeatures))
			{
				wristDominantF1F2SpatialAngle = wristDominantFeatures.F1F2SpatialAngle;
				wristDominantFN_1FNSpatialAngle = wristDominantFeatures.FN_1FNSpatialAngle;
				wristDominantF1FNSpatialAngle = wristDominantFeatures.F1FNSpatialAngle;
				wristDominantTotalVectorAngle = wristDominantFeatures.TotalVectorAngle;
				wristDominantSquaredTotalVectorAngle = wristDominantFeatures.SquaredTotalVectorAngle;
				wristDominantTotalVectorDisplacement = wristDominantFeatures.TotalVectorDisplacement;
				wristDominantTotalDisplacement = wristDominantFeatures.TotalDisplacement;
				wristDominantMaximumDisplacement = wristDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbCMCDominant joint features
			double? thumbCMCDominantF1F2SpatialAngle = null;
			double? thumbCMCDominantFN_1FNSpatialAngle = null;
			double? thumbCMCDominantF1FNSpatialAngle = null;
			double? thumbCMCDominantTotalVectorAngle = null;
			double? thumbCMCDominantSquaredTotalVectorAngle = null;
			double? thumbCMCDominantTotalVectorDisplacement = null;
			double? thumbCMCDominantTotalDisplacement = null;
			double? thumbCMCDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbCMCLeft, JointType.ThumbCMCRight, features.HandDominance, true),
				out var thumbCMCDominantFeatures))
			{
				thumbCMCDominantF1F2SpatialAngle = thumbCMCDominantFeatures.F1F2SpatialAngle;
				thumbCMCDominantFN_1FNSpatialAngle = thumbCMCDominantFeatures.FN_1FNSpatialAngle;
				thumbCMCDominantF1FNSpatialAngle = thumbCMCDominantFeatures.F1FNSpatialAngle;
				thumbCMCDominantTotalVectorAngle = thumbCMCDominantFeatures.TotalVectorAngle;
				thumbCMCDominantSquaredTotalVectorAngle = thumbCMCDominantFeatures.SquaredTotalVectorAngle;
				thumbCMCDominantTotalVectorDisplacement = thumbCMCDominantFeatures.TotalVectorDisplacement;
				thumbCMCDominantTotalDisplacement = thumbCMCDominantFeatures.TotalDisplacement;
				thumbCMCDominantMaximumDisplacement = thumbCMCDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbMCPDominant joint features
			double? thumbMCPDominantF1F2SpatialAngle = null;
			double? thumbMCPDominantFN_1FNSpatialAngle = null;
			double? thumbMCPDominantF1FNSpatialAngle = null;
			double? thumbMCPDominantTotalVectorAngle = null;
			double? thumbMCPDominantSquaredTotalVectorAngle = null;
			double? thumbMCPDominantTotalVectorDisplacement = null;
			double? thumbMCPDominantTotalDisplacement = null;
			double? thumbMCPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbMCPLeft, JointType.ThumbMCPRight, features.HandDominance, true),
				out var thumbMCPDominantFeatures))
			{
				thumbMCPDominantF1F2SpatialAngle = thumbMCPDominantFeatures.F1F2SpatialAngle;
				thumbMCPDominantFN_1FNSpatialAngle = thumbMCPDominantFeatures.FN_1FNSpatialAngle;
				thumbMCPDominantF1FNSpatialAngle = thumbMCPDominantFeatures.F1FNSpatialAngle;
				thumbMCPDominantTotalVectorAngle = thumbMCPDominantFeatures.TotalVectorAngle;
				thumbMCPDominantSquaredTotalVectorAngle = thumbMCPDominantFeatures.SquaredTotalVectorAngle;
				thumbMCPDominantTotalVectorDisplacement = thumbMCPDominantFeatures.TotalVectorDisplacement;
				thumbMCPDominantTotalDisplacement = thumbMCPDominantFeatures.TotalDisplacement;
				thumbMCPDominantMaximumDisplacement = thumbMCPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbIPDominant joint features
			double? thumbIPDominantF1F2SpatialAngle = null;
			double? thumbIPDominantFN_1FNSpatialAngle = null;
			double? thumbIPDominantF1FNSpatialAngle = null;
			double? thumbIPDominantTotalVectorAngle = null;
			double? thumbIPDominantSquaredTotalVectorAngle = null;
			double? thumbIPDominantTotalVectorDisplacement = null;
			double? thumbIPDominantTotalDisplacement = null;
			double? thumbIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbIPLeft, JointType.ThumbIPRight, features.HandDominance, true),
				out var thumbIPDominantFeatures))
			{
				thumbIPDominantF1F2SpatialAngle = thumbIPDominantFeatures.F1F2SpatialAngle;
				thumbIPDominantFN_1FNSpatialAngle = thumbIPDominantFeatures.FN_1FNSpatialAngle;
				thumbIPDominantF1FNSpatialAngle = thumbIPDominantFeatures.F1FNSpatialAngle;
				thumbIPDominantTotalVectorAngle = thumbIPDominantFeatures.TotalVectorAngle;
				thumbIPDominantSquaredTotalVectorAngle = thumbIPDominantFeatures.SquaredTotalVectorAngle;
				thumbIPDominantTotalVectorDisplacement = thumbIPDominantFeatures.TotalVectorDisplacement;
				thumbIPDominantTotalDisplacement = thumbIPDominantFeatures.TotalDisplacement;
				thumbIPDominantMaximumDisplacement = thumbIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbTIPDominant joint features
			double? thumbTIPDominantF1F2SpatialAngle = null;
			double? thumbTIPDominantFN_1FNSpatialAngle = null;
			double? thumbTIPDominantF1FNSpatialAngle = null;
			double? thumbTIPDominantTotalVectorAngle = null;
			double? thumbTIPDominantSquaredTotalVectorAngle = null;
			double? thumbTIPDominantTotalVectorDisplacement = null;
			double? thumbTIPDominantTotalDisplacement = null;
			double? thumbTIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbTIPLeft, JointType.ThumbTIPRight, features.HandDominance, true),
				out var thumbTIPDominantFeatures))
			{
				thumbTIPDominantF1F2SpatialAngle = thumbTIPDominantFeatures.F1F2SpatialAngle;
				thumbTIPDominantFN_1FNSpatialAngle = thumbTIPDominantFeatures.FN_1FNSpatialAngle;
				thumbTIPDominantF1FNSpatialAngle = thumbTIPDominantFeatures.F1FNSpatialAngle;
				thumbTIPDominantTotalVectorAngle = thumbTIPDominantFeatures.TotalVectorAngle;
				thumbTIPDominantSquaredTotalVectorAngle = thumbTIPDominantFeatures.SquaredTotalVectorAngle;
				thumbTIPDominantTotalVectorDisplacement = thumbTIPDominantFeatures.TotalVectorDisplacement;
				thumbTIPDominantTotalDisplacement = thumbTIPDominantFeatures.TotalDisplacement;
				thumbTIPDominantMaximumDisplacement = thumbTIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerMCPDominant joint features
			double? indexFingerMCPDominantF1F2SpatialAngle = null;
			double? indexFingerMCPDominantFN_1FNSpatialAngle = null;
			double? indexFingerMCPDominantF1FNSpatialAngle = null;
			double? indexFingerMCPDominantTotalVectorAngle = null;
			double? indexFingerMCPDominantSquaredTotalVectorAngle = null;
			double? indexFingerMCPDominantTotalVectorDisplacement = null;
			double? indexFingerMCPDominantTotalDisplacement = null;
			double? indexFingerMCPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, features.HandDominance, true),
				out var indexFingerMCPDominantFeatures))
			{
				indexFingerMCPDominantF1F2SpatialAngle = indexFingerMCPDominantFeatures.F1F2SpatialAngle;
				indexFingerMCPDominantFN_1FNSpatialAngle = indexFingerMCPDominantFeatures.FN_1FNSpatialAngle;
				indexFingerMCPDominantF1FNSpatialAngle = indexFingerMCPDominantFeatures.F1FNSpatialAngle;
				indexFingerMCPDominantTotalVectorAngle = indexFingerMCPDominantFeatures.TotalVectorAngle;
				indexFingerMCPDominantSquaredTotalVectorAngle = indexFingerMCPDominantFeatures.SquaredTotalVectorAngle;
				indexFingerMCPDominantTotalVectorDisplacement = indexFingerMCPDominantFeatures.TotalVectorDisplacement;
				indexFingerMCPDominantTotalDisplacement = indexFingerMCPDominantFeatures.TotalDisplacement;
				indexFingerMCPDominantMaximumDisplacement = indexFingerMCPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerPIPDominant joint features
			double? indexFingerPIPDominantF1F2SpatialAngle = null;
			double? indexFingerPIPDominantFN_1FNSpatialAngle = null;
			double? indexFingerPIPDominantF1FNSpatialAngle = null;
			double? indexFingerPIPDominantTotalVectorAngle = null;
			double? indexFingerPIPDominantSquaredTotalVectorAngle = null;
			double? indexFingerPIPDominantTotalVectorDisplacement = null;
			double? indexFingerPIPDominantTotalDisplacement = null;
			double? indexFingerPIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, features.HandDominance, true),
				out var indexFingerPIPDominantFeatures))
			{
				indexFingerPIPDominantF1F2SpatialAngle = indexFingerPIPDominantFeatures.F1F2SpatialAngle;
				indexFingerPIPDominantFN_1FNSpatialAngle = indexFingerPIPDominantFeatures.FN_1FNSpatialAngle;
				indexFingerPIPDominantF1FNSpatialAngle = indexFingerPIPDominantFeatures.F1FNSpatialAngle;
				indexFingerPIPDominantTotalVectorAngle = indexFingerPIPDominantFeatures.TotalVectorAngle;
				indexFingerPIPDominantSquaredTotalVectorAngle = indexFingerPIPDominantFeatures.SquaredTotalVectorAngle;
				indexFingerPIPDominantTotalVectorDisplacement = indexFingerPIPDominantFeatures.TotalVectorDisplacement;
				indexFingerPIPDominantTotalDisplacement = indexFingerPIPDominantFeatures.TotalDisplacement;
				indexFingerPIPDominantMaximumDisplacement = indexFingerPIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerDIPDominant joint features
			double? indexFingerDIPDominantF1F2SpatialAngle = null;
			double? indexFingerDIPDominantFN_1FNSpatialAngle = null;
			double? indexFingerDIPDominantF1FNSpatialAngle = null;
			double? indexFingerDIPDominantTotalVectorAngle = null;
			double? indexFingerDIPDominantSquaredTotalVectorAngle = null;
			double? indexFingerDIPDominantTotalVectorDisplacement = null;
			double? indexFingerDIPDominantTotalDisplacement = null;
			double? indexFingerDIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, features.HandDominance, true),
				out var indexFingerDIPDominantFeatures))
			{
				indexFingerDIPDominantF1F2SpatialAngle = indexFingerDIPDominantFeatures.F1F2SpatialAngle;
				indexFingerDIPDominantFN_1FNSpatialAngle = indexFingerDIPDominantFeatures.FN_1FNSpatialAngle;
				indexFingerDIPDominantF1FNSpatialAngle = indexFingerDIPDominantFeatures.F1FNSpatialAngle;
				indexFingerDIPDominantTotalVectorAngle = indexFingerDIPDominantFeatures.TotalVectorAngle;
				indexFingerDIPDominantSquaredTotalVectorAngle = indexFingerDIPDominantFeatures.SquaredTotalVectorAngle;
				indexFingerDIPDominantTotalVectorDisplacement = indexFingerDIPDominantFeatures.TotalVectorDisplacement;
				indexFingerDIPDominantTotalDisplacement = indexFingerDIPDominantFeatures.TotalDisplacement;
				indexFingerDIPDominantMaximumDisplacement = indexFingerDIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerTIPDominant joint features
			double? indexFingerTIPDominantF1F2SpatialAngle = null;
			double? indexFingerTIPDominantFN_1FNSpatialAngle = null;
			double? indexFingerTIPDominantF1FNSpatialAngle = null;
			double? indexFingerTIPDominantTotalVectorAngle = null;
			double? indexFingerTIPDominantSquaredTotalVectorAngle = null;
			double? indexFingerTIPDominantTotalVectorDisplacement = null;
			double? indexFingerTIPDominantTotalDisplacement = null;
			double? indexFingerTIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight, features.HandDominance, true),
				out var indexFingerTIPDominantFeatures))
			{
				indexFingerTIPDominantF1F2SpatialAngle = indexFingerTIPDominantFeatures.F1F2SpatialAngle;
				indexFingerTIPDominantFN_1FNSpatialAngle = indexFingerTIPDominantFeatures.FN_1FNSpatialAngle;
				indexFingerTIPDominantF1FNSpatialAngle = indexFingerTIPDominantFeatures.F1FNSpatialAngle;
				indexFingerTIPDominantTotalVectorAngle = indexFingerTIPDominantFeatures.TotalVectorAngle;
				indexFingerTIPDominantSquaredTotalVectorAngle = indexFingerTIPDominantFeatures.SquaredTotalVectorAngle;
				indexFingerTIPDominantTotalVectorDisplacement = indexFingerTIPDominantFeatures.TotalVectorDisplacement;
				indexFingerTIPDominantTotalDisplacement = indexFingerTIPDominantFeatures.TotalDisplacement;
				indexFingerTIPDominantMaximumDisplacement = indexFingerTIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerMCPDominant joint features
			double? middleFingerMCPDominantF1F2SpatialAngle = null;
			double? middleFingerMCPDominantFN_1FNSpatialAngle = null;
			double? middleFingerMCPDominantF1FNSpatialAngle = null;
			double? middleFingerMCPDominantTotalVectorAngle = null;
			double? middleFingerMCPDominantSquaredTotalVectorAngle = null;
			double? middleFingerMCPDominantTotalVectorDisplacement = null;
			double? middleFingerMCPDominantTotalDisplacement = null;
			double? middleFingerMCPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, features.HandDominance, true),
				out var middleFingerMCPDominantFeatures))
			{
				middleFingerMCPDominantF1F2SpatialAngle = middleFingerMCPDominantFeatures.F1F2SpatialAngle;
				middleFingerMCPDominantFN_1FNSpatialAngle = middleFingerMCPDominantFeatures.FN_1FNSpatialAngle;
				middleFingerMCPDominantF1FNSpatialAngle = middleFingerMCPDominantFeatures.F1FNSpatialAngle;
				middleFingerMCPDominantTotalVectorAngle = middleFingerMCPDominantFeatures.TotalVectorAngle;
				middleFingerMCPDominantSquaredTotalVectorAngle = middleFingerMCPDominantFeatures.SquaredTotalVectorAngle;
				middleFingerMCPDominantTotalVectorDisplacement = middleFingerMCPDominantFeatures.TotalVectorDisplacement;
				middleFingerMCPDominantTotalDisplacement = middleFingerMCPDominantFeatures.TotalDisplacement;
				middleFingerMCPDominantMaximumDisplacement = middleFingerMCPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerPIPDominant joint features
			double? middleFingerPIPDominantF1F2SpatialAngle = null;
			double? middleFingerPIPDominantFN_1FNSpatialAngle = null;
			double? middleFingerPIPDominantF1FNSpatialAngle = null;
			double? middleFingerPIPDominantTotalVectorAngle = null;
			double? middleFingerPIPDominantSquaredTotalVectorAngle = null;
			double? middleFingerPIPDominantTotalVectorDisplacement = null;
			double? middleFingerPIPDominantTotalDisplacement = null;
			double? middleFingerPIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight, features.HandDominance, true),
				out var middleFingerPIPDominantFeatures))
			{
				middleFingerPIPDominantF1F2SpatialAngle = middleFingerPIPDominantFeatures.F1F2SpatialAngle;
				middleFingerPIPDominantFN_1FNSpatialAngle = middleFingerPIPDominantFeatures.FN_1FNSpatialAngle;
				middleFingerPIPDominantF1FNSpatialAngle = middleFingerPIPDominantFeatures.F1FNSpatialAngle;
				middleFingerPIPDominantTotalVectorAngle = middleFingerPIPDominantFeatures.TotalVectorAngle;
				middleFingerPIPDominantSquaredTotalVectorAngle = middleFingerPIPDominantFeatures.SquaredTotalVectorAngle;
				middleFingerPIPDominantTotalVectorDisplacement = middleFingerPIPDominantFeatures.TotalVectorDisplacement;
				middleFingerPIPDominantTotalDisplacement = middleFingerPIPDominantFeatures.TotalDisplacement;
				middleFingerPIPDominantMaximumDisplacement = middleFingerPIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerDIPDominant joint features
			double? middleFingerDIPDominantF1F2SpatialAngle = null;
			double? middleFingerDIPDominantFN_1FNSpatialAngle = null;
			double? middleFingerDIPDominantF1FNSpatialAngle = null;
			double? middleFingerDIPDominantTotalVectorAngle = null;
			double? middleFingerDIPDominantSquaredTotalVectorAngle = null;
			double? middleFingerDIPDominantTotalVectorDisplacement = null;
			double? middleFingerDIPDominantTotalDisplacement = null;
			double? middleFingerDIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, features.HandDominance, true),
				out var middleFingerDIPDominantFeatures))
			{
				middleFingerDIPDominantF1F2SpatialAngle = middleFingerDIPDominantFeatures.F1F2SpatialAngle;
				middleFingerDIPDominantFN_1FNSpatialAngle = middleFingerDIPDominantFeatures.FN_1FNSpatialAngle;
				middleFingerDIPDominantF1FNSpatialAngle = middleFingerDIPDominantFeatures.F1FNSpatialAngle;
				middleFingerDIPDominantTotalVectorAngle = middleFingerDIPDominantFeatures.TotalVectorAngle;
				middleFingerDIPDominantSquaredTotalVectorAngle = middleFingerDIPDominantFeatures.SquaredTotalVectorAngle;
				middleFingerDIPDominantTotalVectorDisplacement = middleFingerDIPDominantFeatures.TotalVectorDisplacement;
				middleFingerDIPDominantTotalDisplacement = middleFingerDIPDominantFeatures.TotalDisplacement;
				middleFingerDIPDominantMaximumDisplacement = middleFingerDIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerTIPDominant joint features
			double? middleFingerTIPDominantF1F2SpatialAngle = null;
			double? middleFingerTIPDominantFN_1FNSpatialAngle = null;
			double? middleFingerTIPDominantF1FNSpatialAngle = null;
			double? middleFingerTIPDominantTotalVectorAngle = null;
			double? middleFingerTIPDominantSquaredTotalVectorAngle = null;
			double? middleFingerTIPDominantTotalVectorDisplacement = null;
			double? middleFingerTIPDominantTotalDisplacement = null;
			double? middleFingerTIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight, features.HandDominance, true),
				out var middleFingerTIPDominantFeatures))
			{
				middleFingerTIPDominantF1F2SpatialAngle = middleFingerTIPDominantFeatures.F1F2SpatialAngle;
				middleFingerTIPDominantFN_1FNSpatialAngle = middleFingerTIPDominantFeatures.FN_1FNSpatialAngle;
				middleFingerTIPDominantF1FNSpatialAngle = middleFingerTIPDominantFeatures.F1FNSpatialAngle;
				middleFingerTIPDominantTotalVectorAngle = middleFingerTIPDominantFeatures.TotalVectorAngle;
				middleFingerTIPDominantSquaredTotalVectorAngle = middleFingerTIPDominantFeatures.SquaredTotalVectorAngle;
				middleFingerTIPDominantTotalVectorDisplacement = middleFingerTIPDominantFeatures.TotalVectorDisplacement;
				middleFingerTIPDominantTotalDisplacement = middleFingerTIPDominantFeatures.TotalDisplacement;
				middleFingerTIPDominantMaximumDisplacement = middleFingerTIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerMCPDominant joint features
			double? ringFingerMCPDominantF1F2SpatialAngle = null;
			double? ringFingerMCPDominantFN_1FNSpatialAngle = null;
			double? ringFingerMCPDominantF1FNSpatialAngle = null;
			double? ringFingerMCPDominantTotalVectorAngle = null;
			double? ringFingerMCPDominantSquaredTotalVectorAngle = null;
			double? ringFingerMCPDominantTotalVectorDisplacement = null;
			double? ringFingerMCPDominantTotalDisplacement = null;
			double? ringFingerMCPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, features.HandDominance, true),
				out var ringFingerMCPDominantFeatures))
			{
				ringFingerMCPDominantF1F2SpatialAngle = ringFingerMCPDominantFeatures.F1F2SpatialAngle;
				ringFingerMCPDominantFN_1FNSpatialAngle = ringFingerMCPDominantFeatures.FN_1FNSpatialAngle;
				ringFingerMCPDominantF1FNSpatialAngle = ringFingerMCPDominantFeatures.F1FNSpatialAngle;
				ringFingerMCPDominantTotalVectorAngle = ringFingerMCPDominantFeatures.TotalVectorAngle;
				ringFingerMCPDominantSquaredTotalVectorAngle = ringFingerMCPDominantFeatures.SquaredTotalVectorAngle;
				ringFingerMCPDominantTotalVectorDisplacement = ringFingerMCPDominantFeatures.TotalVectorDisplacement;
				ringFingerMCPDominantTotalDisplacement = ringFingerMCPDominantFeatures.TotalDisplacement;
				ringFingerMCPDominantMaximumDisplacement = ringFingerMCPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerPIPDominant joint features
			double? ringFingerPIPDominantF1F2SpatialAngle = null;
			double? ringFingerPIPDominantFN_1FNSpatialAngle = null;
			double? ringFingerPIPDominantF1FNSpatialAngle = null;
			double? ringFingerPIPDominantTotalVectorAngle = null;
			double? ringFingerPIPDominantSquaredTotalVectorAngle = null;
			double? ringFingerPIPDominantTotalVectorDisplacement = null;
			double? ringFingerPIPDominantTotalDisplacement = null;
			double? ringFingerPIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight, features.HandDominance, true),
				out var ringFingerPIPDominantFeatures))
			{
				ringFingerPIPDominantF1F2SpatialAngle = ringFingerPIPDominantFeatures.F1F2SpatialAngle;
				ringFingerPIPDominantFN_1FNSpatialAngle = ringFingerPIPDominantFeatures.FN_1FNSpatialAngle;
				ringFingerPIPDominantF1FNSpatialAngle = ringFingerPIPDominantFeatures.F1FNSpatialAngle;
				ringFingerPIPDominantTotalVectorAngle = ringFingerPIPDominantFeatures.TotalVectorAngle;
				ringFingerPIPDominantSquaredTotalVectorAngle = ringFingerPIPDominantFeatures.SquaredTotalVectorAngle;
				ringFingerPIPDominantTotalVectorDisplacement = ringFingerPIPDominantFeatures.TotalVectorDisplacement;
				ringFingerPIPDominantTotalDisplacement = ringFingerPIPDominantFeatures.TotalDisplacement;
				ringFingerPIPDominantMaximumDisplacement = ringFingerPIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerDIPDominant joint features
			double? ringFingerDIPDominantF1F2SpatialAngle = null;
			double? ringFingerDIPDominantFN_1FNSpatialAngle = null;
			double? ringFingerDIPDominantF1FNSpatialAngle = null;
			double? ringFingerDIPDominantTotalVectorAngle = null;
			double? ringFingerDIPDominantSquaredTotalVectorAngle = null;
			double? ringFingerDIPDominantTotalVectorDisplacement = null;
			double? ringFingerDIPDominantTotalDisplacement = null;
			double? ringFingerDIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, features.HandDominance, true),
				out var ringFingerDIPDominantFeatures))
			{
				ringFingerDIPDominantF1F2SpatialAngle = ringFingerDIPDominantFeatures.F1F2SpatialAngle;
				ringFingerDIPDominantFN_1FNSpatialAngle = ringFingerDIPDominantFeatures.FN_1FNSpatialAngle;
				ringFingerDIPDominantF1FNSpatialAngle = ringFingerDIPDominantFeatures.F1FNSpatialAngle;
				ringFingerDIPDominantTotalVectorAngle = ringFingerDIPDominantFeatures.TotalVectorAngle;
				ringFingerDIPDominantSquaredTotalVectorAngle = ringFingerDIPDominantFeatures.SquaredTotalVectorAngle;
				ringFingerDIPDominantTotalVectorDisplacement = ringFingerDIPDominantFeatures.TotalVectorDisplacement;
				ringFingerDIPDominantTotalDisplacement = ringFingerDIPDominantFeatures.TotalDisplacement;
				ringFingerDIPDominantMaximumDisplacement = ringFingerDIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerTIPDominant joint features
			double? ringFingerTIPDominantF1F2SpatialAngle = null;
			double? ringFingerTIPDominantFN_1FNSpatialAngle = null;
			double? ringFingerTIPDominantF1FNSpatialAngle = null;
			double? ringFingerTIPDominantTotalVectorAngle = null;
			double? ringFingerTIPDominantSquaredTotalVectorAngle = null;
			double? ringFingerTIPDominantTotalVectorDisplacement = null;
			double? ringFingerTIPDominantTotalDisplacement = null;
			double? ringFingerTIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight, features.HandDominance, true),
				out var ringFingerTIPDominantFeatures))
			{
				ringFingerTIPDominantF1F2SpatialAngle = ringFingerTIPDominantFeatures.F1F2SpatialAngle;
				ringFingerTIPDominantFN_1FNSpatialAngle = ringFingerTIPDominantFeatures.FN_1FNSpatialAngle;
				ringFingerTIPDominantF1FNSpatialAngle = ringFingerTIPDominantFeatures.F1FNSpatialAngle;
				ringFingerTIPDominantTotalVectorAngle = ringFingerTIPDominantFeatures.TotalVectorAngle;
				ringFingerTIPDominantSquaredTotalVectorAngle = ringFingerTIPDominantFeatures.SquaredTotalVectorAngle;
				ringFingerTIPDominantTotalVectorDisplacement = ringFingerTIPDominantFeatures.TotalVectorDisplacement;
				ringFingerTIPDominantTotalDisplacement = ringFingerTIPDominantFeatures.TotalDisplacement;
				ringFingerTIPDominantMaximumDisplacement = ringFingerTIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyMCPDominant joint features
			double? pinkyMCPDominantF1F2SpatialAngle = null;
			double? pinkyMCPDominantFN_1FNSpatialAngle = null;
			double? pinkyMCPDominantF1FNSpatialAngle = null;
			double? pinkyMCPDominantTotalVectorAngle = null;
			double? pinkyMCPDominantSquaredTotalVectorAngle = null;
			double? pinkyMCPDominantTotalVectorDisplacement = null;
			double? pinkyMCPDominantTotalDisplacement = null;
			double? pinkyMCPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyMCPLeft, JointType.PinkyMCPRight, features.HandDominance, true),
				out var pinkyMCPDominantFeatures))
			{
				pinkyMCPDominantF1F2SpatialAngle = pinkyMCPDominantFeatures.F1F2SpatialAngle;
				pinkyMCPDominantFN_1FNSpatialAngle = pinkyMCPDominantFeatures.FN_1FNSpatialAngle;
				pinkyMCPDominantF1FNSpatialAngle = pinkyMCPDominantFeatures.F1FNSpatialAngle;
				pinkyMCPDominantTotalVectorAngle = pinkyMCPDominantFeatures.TotalVectorAngle;
				pinkyMCPDominantSquaredTotalVectorAngle = pinkyMCPDominantFeatures.SquaredTotalVectorAngle;
				pinkyMCPDominantTotalVectorDisplacement = pinkyMCPDominantFeatures.TotalVectorDisplacement;
				pinkyMCPDominantTotalDisplacement = pinkyMCPDominantFeatures.TotalDisplacement;
				pinkyMCPDominantMaximumDisplacement = pinkyMCPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyPIPDominant joint features
			double? pinkyPIPDominantF1F2SpatialAngle = null;
			double? pinkyPIPDominantFN_1FNSpatialAngle = null;
			double? pinkyPIPDominantF1FNSpatialAngle = null;
			double? pinkyPIPDominantTotalVectorAngle = null;
			double? pinkyPIPDominantSquaredTotalVectorAngle = null;
			double? pinkyPIPDominantTotalVectorDisplacement = null;
			double? pinkyPIPDominantTotalDisplacement = null;
			double? pinkyPIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyPIPLeft, JointType.PinkyPIPRight, features.HandDominance, true),
				out var pinkyPIPDominantFeatures))
			{
				pinkyPIPDominantF1F2SpatialAngle = pinkyPIPDominantFeatures.F1F2SpatialAngle;
				pinkyPIPDominantFN_1FNSpatialAngle = pinkyPIPDominantFeatures.FN_1FNSpatialAngle;
				pinkyPIPDominantF1FNSpatialAngle = pinkyPIPDominantFeatures.F1FNSpatialAngle;
				pinkyPIPDominantTotalVectorAngle = pinkyPIPDominantFeatures.TotalVectorAngle;
				pinkyPIPDominantSquaredTotalVectorAngle = pinkyPIPDominantFeatures.SquaredTotalVectorAngle;
				pinkyPIPDominantTotalVectorDisplacement = pinkyPIPDominantFeatures.TotalVectorDisplacement;
				pinkyPIPDominantTotalDisplacement = pinkyPIPDominantFeatures.TotalDisplacement;
				pinkyPIPDominantMaximumDisplacement = pinkyPIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyDIPDominant joint features
			double? pinkyDIPDominantF1F2SpatialAngle = null;
			double? pinkyDIPDominantFN_1FNSpatialAngle = null;
			double? pinkyDIPDominantF1FNSpatialAngle = null;
			double? pinkyDIPDominantTotalVectorAngle = null;
			double? pinkyDIPDominantSquaredTotalVectorAngle = null;
			double? pinkyDIPDominantTotalVectorDisplacement = null;
			double? pinkyDIPDominantTotalDisplacement = null;
			double? pinkyDIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyDIPLeft, JointType.PinkyDIPRight, features.HandDominance, true),
				out var pinkyDIPDominantFeatures))
			{
				pinkyDIPDominantF1F2SpatialAngle = pinkyDIPDominantFeatures.F1F2SpatialAngle;
				pinkyDIPDominantFN_1FNSpatialAngle = pinkyDIPDominantFeatures.FN_1FNSpatialAngle;
				pinkyDIPDominantF1FNSpatialAngle = pinkyDIPDominantFeatures.F1FNSpatialAngle;
				pinkyDIPDominantTotalVectorAngle = pinkyDIPDominantFeatures.TotalVectorAngle;
				pinkyDIPDominantSquaredTotalVectorAngle = pinkyDIPDominantFeatures.SquaredTotalVectorAngle;
				pinkyDIPDominantTotalVectorDisplacement = pinkyDIPDominantFeatures.TotalVectorDisplacement;
				pinkyDIPDominantTotalDisplacement = pinkyDIPDominantFeatures.TotalDisplacement;
				pinkyDIPDominantMaximumDisplacement = pinkyDIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyTIPDominant joint features
			double? pinkyTIPDominantF1F2SpatialAngle = null;
			double? pinkyTIPDominantFN_1FNSpatialAngle = null;
			double? pinkyTIPDominantF1FNSpatialAngle = null;
			double? pinkyTIPDominantTotalVectorAngle = null;
			double? pinkyTIPDominantSquaredTotalVectorAngle = null;
			double? pinkyTIPDominantTotalVectorDisplacement = null;
			double? pinkyTIPDominantTotalDisplacement = null;
			double? pinkyTIPDominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyTIPLeft, JointType.PinkyTIPRight, features.HandDominance, true),
				out var pinkyTIPDominantFeatures))
			{
				pinkyTIPDominantF1F2SpatialAngle = pinkyTIPDominantFeatures.F1F2SpatialAngle;
				pinkyTIPDominantFN_1FNSpatialAngle = pinkyTIPDominantFeatures.FN_1FNSpatialAngle;
				pinkyTIPDominantF1FNSpatialAngle = pinkyTIPDominantFeatures.F1FNSpatialAngle;
				pinkyTIPDominantTotalVectorAngle = pinkyTIPDominantFeatures.TotalVectorAngle;
				pinkyTIPDominantSquaredTotalVectorAngle = pinkyTIPDominantFeatures.SquaredTotalVectorAngle;
				pinkyTIPDominantTotalVectorDisplacement = pinkyTIPDominantFeatures.TotalVectorDisplacement;
				pinkyTIPDominantTotalDisplacement = pinkyTIPDominantFeatures.TotalDisplacement;
				pinkyTIPDominantMaximumDisplacement = pinkyTIPDominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region HandDominant joint features
			double? handDominantF1F2SpatialAngle = null;
			double? handDominantFN_1FNSpatialAngle = null;
			double? handDominantF1FNSpatialAngle = null;
			double? handDominantTotalVectorAngle = null;
			double? handDominantSquaredTotalVectorAngle = null;
			double? handDominantTotalVectorDisplacement = null;
			double? handDominantTotalDisplacement = null;
			double? handDominantMaximumDisplacement = null;
			double? handDominantBoundingBoxDiagonalLength = null;
			double? handDominantBoundingBoxAngle = null;
			//HandState[] handDominantHandStates = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.HandLeft, JointType.HandRight, features.HandDominance, true),
				out var handDominantFeatures) && handDominantFeatures is HandJointGestureFeatures handDominantHandFeatures)
			{
				handDominantF1F2SpatialAngle = handDominantHandFeatures.F1F2SpatialAngle;
				handDominantFN_1FNSpatialAngle = handDominantHandFeatures.FN_1FNSpatialAngle;
				handDominantF1FNSpatialAngle = handDominantHandFeatures.F1FNSpatialAngle;
				handDominantTotalVectorAngle = handDominantHandFeatures.TotalVectorAngle;
				handDominantSquaredTotalVectorAngle = handDominantHandFeatures.SquaredTotalVectorAngle;
				handDominantTotalVectorDisplacement = handDominantHandFeatures.TotalVectorDisplacement;
				handDominantTotalDisplacement = handDominantHandFeatures.TotalDisplacement;
				handDominantMaximumDisplacement = handDominantHandFeatures.MaximumDisplacement;
				handDominantBoundingBoxDiagonalLength = handDominantHandFeatures.BoundingBoxDiagonalLength;
				handDominantBoundingBoxAngle = handDominantHandFeatures.BoundingBoxAngle;
				//handDominantHandStates = handDominantHandFeatures.HandStates;
			}
			#endregion

			#region WristNondominant joint features
			double? wristNondominantF1F2SpatialAngle = null;
			double? wristNondominantFN_1FNSpatialAngle = null;
			double? wristNondominantF1FNSpatialAngle = null;
			double? wristNondominantTotalVectorAngle = null;
			double? wristNondominantSquaredTotalVectorAngle = null;
			double? wristNondominantTotalVectorDisplacement = null;
			double? wristNondominantTotalDisplacement = null;
			double? wristNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.WristLeft, JointType.WristRight, features.HandDominance, false),
				out var wristNondominantFeatures))
			{
				wristNondominantF1F2SpatialAngle = wristNondominantFeatures.F1F2SpatialAngle;
				wristNondominantFN_1FNSpatialAngle = wristNondominantFeatures.FN_1FNSpatialAngle;
				wristNondominantF1FNSpatialAngle = wristNondominantFeatures.F1FNSpatialAngle;
				wristNondominantTotalVectorAngle = wristNondominantFeatures.TotalVectorAngle;
				wristNondominantSquaredTotalVectorAngle = wristNondominantFeatures.SquaredTotalVectorAngle;
				wristNondominantTotalVectorDisplacement = wristNondominantFeatures.TotalVectorDisplacement;
				wristNondominantTotalDisplacement = wristNondominantFeatures.TotalDisplacement;
				wristNondominantMaximumDisplacement = wristNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbCMCNondominant joint features
			double? thumbCMCNondominantF1F2SpatialAngle = null;
			double? thumbCMCNondominantFN_1FNSpatialAngle = null;
			double? thumbCMCNondominantF1FNSpatialAngle = null;
			double? thumbCMCNondominantTotalVectorAngle = null;
			double? thumbCMCNondominantSquaredTotalVectorAngle = null;
			double? thumbCMCNondominantTotalVectorDisplacement = null;
			double? thumbCMCNondominantTotalDisplacement = null;
			double? thumbCMCNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbCMCLeft, JointType.ThumbCMCRight, features.HandDominance, false),
				out var thumbCMCNondominantFeatures))
			{
				thumbCMCNondominantF1F2SpatialAngle = thumbCMCNondominantFeatures.F1F2SpatialAngle;
				thumbCMCNondominantFN_1FNSpatialAngle = thumbCMCNondominantFeatures.FN_1FNSpatialAngle;
				thumbCMCNondominantF1FNSpatialAngle = thumbCMCNondominantFeatures.F1FNSpatialAngle;
				thumbCMCNondominantTotalVectorAngle = thumbCMCNondominantFeatures.TotalVectorAngle;
				thumbCMCNondominantSquaredTotalVectorAngle = thumbCMCNondominantFeatures.SquaredTotalVectorAngle;
				thumbCMCNondominantTotalVectorDisplacement = thumbCMCNondominantFeatures.TotalVectorDisplacement;
				thumbCMCNondominantTotalDisplacement = thumbCMCNondominantFeatures.TotalDisplacement;
				thumbCMCNondominantMaximumDisplacement = thumbCMCNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbMCPNondominant joint features
			double? thumbMCPNondominantF1F2SpatialAngle = null;
			double? thumbMCPNondominantFN_1FNSpatialAngle = null;
			double? thumbMCPNondominantF1FNSpatialAngle = null;
			double? thumbMCPNondominantTotalVectorAngle = null;
			double? thumbMCPNondominantSquaredTotalVectorAngle = null;
			double? thumbMCPNondominantTotalVectorDisplacement = null;
			double? thumbMCPNondominantTotalDisplacement = null;
			double? thumbMCPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbMCPLeft, JointType.ThumbMCPRight, features.HandDominance, false),
				out var thumbMCPNondominantFeatures))
			{
				thumbMCPNondominantF1F2SpatialAngle = thumbMCPNondominantFeatures.F1F2SpatialAngle;
				thumbMCPNondominantFN_1FNSpatialAngle = thumbMCPNondominantFeatures.FN_1FNSpatialAngle;
				thumbMCPNondominantF1FNSpatialAngle = thumbMCPNondominantFeatures.F1FNSpatialAngle;
				thumbMCPNondominantTotalVectorAngle = thumbMCPNondominantFeatures.TotalVectorAngle;
				thumbMCPNondominantSquaredTotalVectorAngle = thumbMCPNondominantFeatures.SquaredTotalVectorAngle;
				thumbMCPNondominantTotalVectorDisplacement = thumbMCPNondominantFeatures.TotalVectorDisplacement;
				thumbMCPNondominantTotalDisplacement = thumbMCPNondominantFeatures.TotalDisplacement;
				thumbMCPNondominantMaximumDisplacement = thumbMCPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbIPNondominant joint features
			double? thumbIPNondominantF1F2SpatialAngle = null;
			double? thumbIPNondominantFN_1FNSpatialAngle = null;
			double? thumbIPNondominantF1FNSpatialAngle = null;
			double? thumbIPNondominantTotalVectorAngle = null;
			double? thumbIPNondominantSquaredTotalVectorAngle = null;
			double? thumbIPNondominantTotalVectorDisplacement = null;
			double? thumbIPNondominantTotalDisplacement = null;
			double? thumbIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbIPLeft, JointType.ThumbIPRight, features.HandDominance, false),
				out var thumbIPNondominantFeatures))
			{
				thumbIPNondominantF1F2SpatialAngle = thumbIPNondominantFeatures.F1F2SpatialAngle;
				thumbIPNondominantFN_1FNSpatialAngle = thumbIPNondominantFeatures.FN_1FNSpatialAngle;
				thumbIPNondominantF1FNSpatialAngle = thumbIPNondominantFeatures.F1FNSpatialAngle;
				thumbIPNondominantTotalVectorAngle = thumbIPNondominantFeatures.TotalVectorAngle;
				thumbIPNondominantSquaredTotalVectorAngle = thumbIPNondominantFeatures.SquaredTotalVectorAngle;
				thumbIPNondominantTotalVectorDisplacement = thumbIPNondominantFeatures.TotalVectorDisplacement;
				thumbIPNondominantTotalDisplacement = thumbIPNondominantFeatures.TotalDisplacement;
				thumbIPNondominantMaximumDisplacement = thumbIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region ThumbTIPNondominant joint features
			double? thumbTIPNondominantF1F2SpatialAngle = null;
			double? thumbTIPNondominantFN_1FNSpatialAngle = null;
			double? thumbTIPNondominantF1FNSpatialAngle = null;
			double? thumbTIPNondominantTotalVectorAngle = null;
			double? thumbTIPNondominantSquaredTotalVectorAngle = null;
			double? thumbTIPNondominantTotalVectorDisplacement = null;
			double? thumbTIPNondominantTotalDisplacement = null;
			double? thumbTIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.ThumbTIPLeft, JointType.ThumbTIPRight, features.HandDominance, false),
				out var thumbTIPNondominantFeatures))
			{
				thumbTIPNondominantF1F2SpatialAngle = thumbTIPNondominantFeatures.F1F2SpatialAngle;
				thumbTIPNondominantFN_1FNSpatialAngle = thumbTIPNondominantFeatures.FN_1FNSpatialAngle;
				thumbTIPNondominantF1FNSpatialAngle = thumbTIPNondominantFeatures.F1FNSpatialAngle;
				thumbTIPNondominantTotalVectorAngle = thumbTIPNondominantFeatures.TotalVectorAngle;
				thumbTIPNondominantSquaredTotalVectorAngle = thumbTIPNondominantFeatures.SquaredTotalVectorAngle;
				thumbTIPNondominantTotalVectorDisplacement = thumbTIPNondominantFeatures.TotalVectorDisplacement;
				thumbTIPNondominantTotalDisplacement = thumbTIPNondominantFeatures.TotalDisplacement;
				thumbTIPNondominantMaximumDisplacement = thumbTIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerMCPNondominant joint features
			double? indexFingerMCPNondominantF1F2SpatialAngle = null;
			double? indexFingerMCPNondominantFN_1FNSpatialAngle = null;
			double? indexFingerMCPNondominantF1FNSpatialAngle = null;
			double? indexFingerMCPNondominantTotalVectorAngle = null;
			double? indexFingerMCPNondominantSquaredTotalVectorAngle = null;
			double? indexFingerMCPNondominantTotalVectorDisplacement = null;
			double? indexFingerMCPNondominantTotalDisplacement = null;
			double? indexFingerMCPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, features.HandDominance, false),
				out var indexFingerMCPNondominantFeatures))
			{
				indexFingerMCPNondominantF1F2SpatialAngle = indexFingerMCPNondominantFeatures.F1F2SpatialAngle;
				indexFingerMCPNondominantFN_1FNSpatialAngle = indexFingerMCPNondominantFeatures.FN_1FNSpatialAngle;
				indexFingerMCPNondominantF1FNSpatialAngle = indexFingerMCPNondominantFeatures.F1FNSpatialAngle;
				indexFingerMCPNondominantTotalVectorAngle = indexFingerMCPNondominantFeatures.TotalVectorAngle;
				indexFingerMCPNondominantSquaredTotalVectorAngle = indexFingerMCPNondominantFeatures.SquaredTotalVectorAngle;
				indexFingerMCPNondominantTotalVectorDisplacement = indexFingerMCPNondominantFeatures.TotalVectorDisplacement;
				indexFingerMCPNondominantTotalDisplacement = indexFingerMCPNondominantFeatures.TotalDisplacement;
				indexFingerMCPNondominantMaximumDisplacement = indexFingerMCPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerPIPNondominant joint features
			double? indexFingerPIPNondominantF1F2SpatialAngle = null;
			double? indexFingerPIPNondominantFN_1FNSpatialAngle = null;
			double? indexFingerPIPNondominantF1FNSpatialAngle = null;
			double? indexFingerPIPNondominantTotalVectorAngle = null;
			double? indexFingerPIPNondominantSquaredTotalVectorAngle = null;
			double? indexFingerPIPNondominantTotalVectorDisplacement = null;
			double? indexFingerPIPNondominantTotalDisplacement = null;
			double? indexFingerPIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, features.HandDominance, false),
				out var indexFingerPIPNondominantFeatures))
			{
				indexFingerPIPNondominantF1F2SpatialAngle = indexFingerPIPNondominantFeatures.F1F2SpatialAngle;
				indexFingerPIPNondominantFN_1FNSpatialAngle = indexFingerPIPNondominantFeatures.FN_1FNSpatialAngle;
				indexFingerPIPNondominantF1FNSpatialAngle = indexFingerPIPNondominantFeatures.F1FNSpatialAngle;
				indexFingerPIPNondominantTotalVectorAngle = indexFingerPIPNondominantFeatures.TotalVectorAngle;
				indexFingerPIPNondominantSquaredTotalVectorAngle = indexFingerPIPNondominantFeatures.SquaredTotalVectorAngle;
				indexFingerPIPNondominantTotalVectorDisplacement = indexFingerPIPNondominantFeatures.TotalVectorDisplacement;
				indexFingerPIPNondominantTotalDisplacement = indexFingerPIPNondominantFeatures.TotalDisplacement;
				indexFingerPIPNondominantMaximumDisplacement = indexFingerPIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerDIPNondominant joint features
			double? indexFingerDIPNondominantF1F2SpatialAngle = null;
			double? indexFingerDIPNondominantFN_1FNSpatialAngle = null;
			double? indexFingerDIPNondominantF1FNSpatialAngle = null;
			double? indexFingerDIPNondominantTotalVectorAngle = null;
			double? indexFingerDIPNondominantSquaredTotalVectorAngle = null;
			double? indexFingerDIPNondominantTotalVectorDisplacement = null;
			double? indexFingerDIPNondominantTotalDisplacement = null;
			double? indexFingerDIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, features.HandDominance, false),
				out var indexFingerDIPNondominantFeatures))
			{
				indexFingerDIPNondominantF1F2SpatialAngle = indexFingerDIPNondominantFeatures.F1F2SpatialAngle;
				indexFingerDIPNondominantFN_1FNSpatialAngle = indexFingerDIPNondominantFeatures.FN_1FNSpatialAngle;
				indexFingerDIPNondominantF1FNSpatialAngle = indexFingerDIPNondominantFeatures.F1FNSpatialAngle;
				indexFingerDIPNondominantTotalVectorAngle = indexFingerDIPNondominantFeatures.TotalVectorAngle;
				indexFingerDIPNondominantSquaredTotalVectorAngle = indexFingerDIPNondominantFeatures.SquaredTotalVectorAngle;
				indexFingerDIPNondominantTotalVectorDisplacement = indexFingerDIPNondominantFeatures.TotalVectorDisplacement;
				indexFingerDIPNondominantTotalDisplacement = indexFingerDIPNondominantFeatures.TotalDisplacement;
				indexFingerDIPNondominantMaximumDisplacement = indexFingerDIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region IndexFingerTIPNondominant joint features
			double? indexFingerTIPNondominantF1F2SpatialAngle = null;
			double? indexFingerTIPNondominantFN_1FNSpatialAngle = null;
			double? indexFingerTIPNondominantF1FNSpatialAngle = null;
			double? indexFingerTIPNondominantTotalVectorAngle = null;
			double? indexFingerTIPNondominantSquaredTotalVectorAngle = null;
			double? indexFingerTIPNondominantTotalVectorDisplacement = null;
			double? indexFingerTIPNondominantTotalDisplacement = null;
			double? indexFingerTIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight, features.HandDominance, false),
				out var indexFingerTIPNondominantFeatures))
			{
				indexFingerTIPNondominantF1F2SpatialAngle = indexFingerTIPNondominantFeatures.F1F2SpatialAngle;
				indexFingerTIPNondominantFN_1FNSpatialAngle = indexFingerTIPNondominantFeatures.FN_1FNSpatialAngle;
				indexFingerTIPNondominantF1FNSpatialAngle = indexFingerTIPNondominantFeatures.F1FNSpatialAngle;
				indexFingerTIPNondominantTotalVectorAngle = indexFingerTIPNondominantFeatures.TotalVectorAngle;
				indexFingerTIPNondominantSquaredTotalVectorAngle = indexFingerTIPNondominantFeatures.SquaredTotalVectorAngle;
				indexFingerTIPNondominantTotalVectorDisplacement = indexFingerTIPNondominantFeatures.TotalVectorDisplacement;
				indexFingerTIPNondominantTotalDisplacement = indexFingerTIPNondominantFeatures.TotalDisplacement;
				indexFingerTIPNondominantMaximumDisplacement = indexFingerTIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerMCPNondominant joint features
			double? middleFingerMCPNondominantF1F2SpatialAngle = null;
			double? middleFingerMCPNondominantFN_1FNSpatialAngle = null;
			double? middleFingerMCPNondominantF1FNSpatialAngle = null;
			double? middleFingerMCPNondominantTotalVectorAngle = null;
			double? middleFingerMCPNondominantSquaredTotalVectorAngle = null;
			double? middleFingerMCPNondominantTotalVectorDisplacement = null;
			double? middleFingerMCPNondominantTotalDisplacement = null;
			double? middleFingerMCPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, features.HandDominance, false),
				out var middleFingerMCPNondominantFeatures))
			{
				middleFingerMCPNondominantF1F2SpatialAngle = middleFingerMCPNondominantFeatures.F1F2SpatialAngle;
				middleFingerMCPNondominantFN_1FNSpatialAngle = middleFingerMCPNondominantFeatures.FN_1FNSpatialAngle;
				middleFingerMCPNondominantF1FNSpatialAngle = middleFingerMCPNondominantFeatures.F1FNSpatialAngle;
				middleFingerMCPNondominantTotalVectorAngle = middleFingerMCPNondominantFeatures.TotalVectorAngle;
				middleFingerMCPNondominantSquaredTotalVectorAngle = middleFingerMCPNondominantFeatures.SquaredTotalVectorAngle;
				middleFingerMCPNondominantTotalVectorDisplacement = middleFingerMCPNondominantFeatures.TotalVectorDisplacement;
				middleFingerMCPNondominantTotalDisplacement = middleFingerMCPNondominantFeatures.TotalDisplacement;
				middleFingerMCPNondominantMaximumDisplacement = middleFingerMCPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerPIPNondominant joint features
			double? middleFingerPIPNondominantF1F2SpatialAngle = null;
			double? middleFingerPIPNondominantFN_1FNSpatialAngle = null;
			double? middleFingerPIPNondominantF1FNSpatialAngle = null;
			double? middleFingerPIPNondominantTotalVectorAngle = null;
			double? middleFingerPIPNondominantSquaredTotalVectorAngle = null;
			double? middleFingerPIPNondominantTotalVectorDisplacement = null;
			double? middleFingerPIPNondominantTotalDisplacement = null;
			double? middleFingerPIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight, features.HandDominance, false),
				out var middleFingerPIPNondominantFeatures))
			{
				middleFingerPIPNondominantF1F2SpatialAngle = middleFingerPIPNondominantFeatures.F1F2SpatialAngle;
				middleFingerPIPNondominantFN_1FNSpatialAngle = middleFingerPIPNondominantFeatures.FN_1FNSpatialAngle;
				middleFingerPIPNondominantF1FNSpatialAngle = middleFingerPIPNondominantFeatures.F1FNSpatialAngle;
				middleFingerPIPNondominantTotalVectorAngle = middleFingerPIPNondominantFeatures.TotalVectorAngle;
				middleFingerPIPNondominantSquaredTotalVectorAngle = middleFingerPIPNondominantFeatures.SquaredTotalVectorAngle;
				middleFingerPIPNondominantTotalVectorDisplacement = middleFingerPIPNondominantFeatures.TotalVectorDisplacement;
				middleFingerPIPNondominantTotalDisplacement = middleFingerPIPNondominantFeatures.TotalDisplacement;
				middleFingerPIPNondominantMaximumDisplacement = middleFingerPIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerDIPNondominant joint features
			double? middleFingerDIPNondominantF1F2SpatialAngle = null;
			double? middleFingerDIPNondominantFN_1FNSpatialAngle = null;
			double? middleFingerDIPNondominantF1FNSpatialAngle = null;
			double? middleFingerDIPNondominantTotalVectorAngle = null;
			double? middleFingerDIPNondominantSquaredTotalVectorAngle = null;
			double? middleFingerDIPNondominantTotalVectorDisplacement = null;
			double? middleFingerDIPNondominantTotalDisplacement = null;
			double? middleFingerDIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, features.HandDominance, false),
				out var middleFingerDIPNondominantFeatures))
			{
				middleFingerDIPNondominantF1F2SpatialAngle = middleFingerDIPNondominantFeatures.F1F2SpatialAngle;
				middleFingerDIPNondominantFN_1FNSpatialAngle = middleFingerDIPNondominantFeatures.FN_1FNSpatialAngle;
				middleFingerDIPNondominantF1FNSpatialAngle = middleFingerDIPNondominantFeatures.F1FNSpatialAngle;
				middleFingerDIPNondominantTotalVectorAngle = middleFingerDIPNondominantFeatures.TotalVectorAngle;
				middleFingerDIPNondominantSquaredTotalVectorAngle = middleFingerDIPNondominantFeatures.SquaredTotalVectorAngle;
				middleFingerDIPNondominantTotalVectorDisplacement = middleFingerDIPNondominantFeatures.TotalVectorDisplacement;
				middleFingerDIPNondominantTotalDisplacement = middleFingerDIPNondominantFeatures.TotalDisplacement;
				middleFingerDIPNondominantMaximumDisplacement = middleFingerDIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region MiddleFingerTIPNondominant joint features
			double? middleFingerTIPNondominantF1F2SpatialAngle = null;
			double? middleFingerTIPNondominantFN_1FNSpatialAngle = null;
			double? middleFingerTIPNondominantF1FNSpatialAngle = null;
			double? middleFingerTIPNondominantTotalVectorAngle = null;
			double? middleFingerTIPNondominantSquaredTotalVectorAngle = null;
			double? middleFingerTIPNondominantTotalVectorDisplacement = null;
			double? middleFingerTIPNondominantTotalDisplacement = null;
			double? middleFingerTIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight, features.HandDominance, false),
				out var middleFingerTIPNondominantFeatures))
			{
				middleFingerTIPNondominantF1F2SpatialAngle = middleFingerTIPNondominantFeatures.F1F2SpatialAngle;
				middleFingerTIPNondominantFN_1FNSpatialAngle = middleFingerTIPNondominantFeatures.FN_1FNSpatialAngle;
				middleFingerTIPNondominantF1FNSpatialAngle = middleFingerTIPNondominantFeatures.F1FNSpatialAngle;
				middleFingerTIPNondominantTotalVectorAngle = middleFingerTIPNondominantFeatures.TotalVectorAngle;
				middleFingerTIPNondominantSquaredTotalVectorAngle = middleFingerTIPNondominantFeatures.SquaredTotalVectorAngle;
				middleFingerTIPNondominantTotalVectorDisplacement = middleFingerTIPNondominantFeatures.TotalVectorDisplacement;
				middleFingerTIPNondominantTotalDisplacement = middleFingerTIPNondominantFeatures.TotalDisplacement;
				middleFingerTIPNondominantMaximumDisplacement = middleFingerTIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerMCPNondominant joint features
			double? ringFingerMCPNondominantF1F2SpatialAngle = null;
			double? ringFingerMCPNondominantFN_1FNSpatialAngle = null;
			double? ringFingerMCPNondominantF1FNSpatialAngle = null;
			double? ringFingerMCPNondominantTotalVectorAngle = null;
			double? ringFingerMCPNondominantSquaredTotalVectorAngle = null;
			double? ringFingerMCPNondominantTotalVectorDisplacement = null;
			double? ringFingerMCPNondominantTotalDisplacement = null;
			double? ringFingerMCPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, features.HandDominance, false),
				out var ringFingerMCPNondominantFeatures))
			{
				ringFingerMCPNondominantF1F2SpatialAngle = ringFingerMCPNondominantFeatures.F1F2SpatialAngle;
				ringFingerMCPNondominantFN_1FNSpatialAngle = ringFingerMCPNondominantFeatures.FN_1FNSpatialAngle;
				ringFingerMCPNondominantF1FNSpatialAngle = ringFingerMCPNondominantFeatures.F1FNSpatialAngle;
				ringFingerMCPNondominantTotalVectorAngle = ringFingerMCPNondominantFeatures.TotalVectorAngle;
				ringFingerMCPNondominantSquaredTotalVectorAngle = ringFingerMCPNondominantFeatures.SquaredTotalVectorAngle;
				ringFingerMCPNondominantTotalVectorDisplacement = ringFingerMCPNondominantFeatures.TotalVectorDisplacement;
				ringFingerMCPNondominantTotalDisplacement = ringFingerMCPNondominantFeatures.TotalDisplacement;
				ringFingerMCPNondominantMaximumDisplacement = ringFingerMCPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerPIPNondominant joint features
			double? ringFingerPIPNondominantF1F2SpatialAngle = null;
			double? ringFingerPIPNondominantFN_1FNSpatialAngle = null;
			double? ringFingerPIPNondominantF1FNSpatialAngle = null;
			double? ringFingerPIPNondominantTotalVectorAngle = null;
			double? ringFingerPIPNondominantSquaredTotalVectorAngle = null;
			double? ringFingerPIPNondominantTotalVectorDisplacement = null;
			double? ringFingerPIPNondominantTotalDisplacement = null;
			double? ringFingerPIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight, features.HandDominance, false),
				out var ringFingerPIPNondominantFeatures))
			{
				ringFingerPIPNondominantF1F2SpatialAngle = ringFingerPIPNondominantFeatures.F1F2SpatialAngle;
				ringFingerPIPNondominantFN_1FNSpatialAngle = ringFingerPIPNondominantFeatures.FN_1FNSpatialAngle;
				ringFingerPIPNondominantF1FNSpatialAngle = ringFingerPIPNondominantFeatures.F1FNSpatialAngle;
				ringFingerPIPNondominantTotalVectorAngle = ringFingerPIPNondominantFeatures.TotalVectorAngle;
				ringFingerPIPNondominantSquaredTotalVectorAngle = ringFingerPIPNondominantFeatures.SquaredTotalVectorAngle;
				ringFingerPIPNondominantTotalVectorDisplacement = ringFingerPIPNondominantFeatures.TotalVectorDisplacement;
				ringFingerPIPNondominantTotalDisplacement = ringFingerPIPNondominantFeatures.TotalDisplacement;
				ringFingerPIPNondominantMaximumDisplacement = ringFingerPIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerDIPNondominant joint features
			double? ringFingerDIPNondominantF1F2SpatialAngle = null;
			double? ringFingerDIPNondominantFN_1FNSpatialAngle = null;
			double? ringFingerDIPNondominantF1FNSpatialAngle = null;
			double? ringFingerDIPNondominantTotalVectorAngle = null;
			double? ringFingerDIPNondominantSquaredTotalVectorAngle = null;
			double? ringFingerDIPNondominantTotalVectorDisplacement = null;
			double? ringFingerDIPNondominantTotalDisplacement = null;
			double? ringFingerDIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, features.HandDominance, false),
				out var ringFingerDIPNondominantFeatures))
			{
				ringFingerDIPNondominantF1F2SpatialAngle = ringFingerDIPNondominantFeatures.F1F2SpatialAngle;
				ringFingerDIPNondominantFN_1FNSpatialAngle = ringFingerDIPNondominantFeatures.FN_1FNSpatialAngle;
				ringFingerDIPNondominantF1FNSpatialAngle = ringFingerDIPNondominantFeatures.F1FNSpatialAngle;
				ringFingerDIPNondominantTotalVectorAngle = ringFingerDIPNondominantFeatures.TotalVectorAngle;
				ringFingerDIPNondominantSquaredTotalVectorAngle = ringFingerDIPNondominantFeatures.SquaredTotalVectorAngle;
				ringFingerDIPNondominantTotalVectorDisplacement = ringFingerDIPNondominantFeatures.TotalVectorDisplacement;
				ringFingerDIPNondominantTotalDisplacement = ringFingerDIPNondominantFeatures.TotalDisplacement;
				ringFingerDIPNondominantMaximumDisplacement = ringFingerDIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region RingFingerTIPNondominant joint features
			double? ringFingerTIPNondominantF1F2SpatialAngle = null;
			double? ringFingerTIPNondominantFN_1FNSpatialAngle = null;
			double? ringFingerTIPNondominantF1FNSpatialAngle = null;
			double? ringFingerTIPNondominantTotalVectorAngle = null;
			double? ringFingerTIPNondominantSquaredTotalVectorAngle = null;
			double? ringFingerTIPNondominantTotalVectorDisplacement = null;
			double? ringFingerTIPNondominantTotalDisplacement = null;
			double? ringFingerTIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight, features.HandDominance, false),
				out var ringFingerTIPNondominantFeatures))
			{
				ringFingerTIPNondominantF1F2SpatialAngle = ringFingerTIPNondominantFeatures.F1F2SpatialAngle;
				ringFingerTIPNondominantFN_1FNSpatialAngle = ringFingerTIPNondominantFeatures.FN_1FNSpatialAngle;
				ringFingerTIPNondominantF1FNSpatialAngle = ringFingerTIPNondominantFeatures.F1FNSpatialAngle;
				ringFingerTIPNondominantTotalVectorAngle = ringFingerTIPNondominantFeatures.TotalVectorAngle;
				ringFingerTIPNondominantSquaredTotalVectorAngle = ringFingerTIPNondominantFeatures.SquaredTotalVectorAngle;
				ringFingerTIPNondominantTotalVectorDisplacement = ringFingerTIPNondominantFeatures.TotalVectorDisplacement;
				ringFingerTIPNondominantTotalDisplacement = ringFingerTIPNondominantFeatures.TotalDisplacement;
				ringFingerTIPNondominantMaximumDisplacement = ringFingerTIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyMCPNondominant joint features
			double? pinkyMCPNondominantF1F2SpatialAngle = null;
			double? pinkyMCPNondominantFN_1FNSpatialAngle = null;
			double? pinkyMCPNondominantF1FNSpatialAngle = null;
			double? pinkyMCPNondominantTotalVectorAngle = null;
			double? pinkyMCPNondominantSquaredTotalVectorAngle = null;
			double? pinkyMCPNondominantTotalVectorDisplacement = null;
			double? pinkyMCPNondominantTotalDisplacement = null;
			double? pinkyMCPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyMCPLeft, JointType.PinkyMCPRight, features.HandDominance, false),
				out var pinkyMCPNondominantFeatures))
			{
				pinkyMCPNondominantF1F2SpatialAngle = pinkyMCPNondominantFeatures.F1F2SpatialAngle;
				pinkyMCPNondominantFN_1FNSpatialAngle = pinkyMCPNondominantFeatures.FN_1FNSpatialAngle;
				pinkyMCPNondominantF1FNSpatialAngle = pinkyMCPNondominantFeatures.F1FNSpatialAngle;
				pinkyMCPNondominantTotalVectorAngle = pinkyMCPNondominantFeatures.TotalVectorAngle;
				pinkyMCPNondominantSquaredTotalVectorAngle = pinkyMCPNondominantFeatures.SquaredTotalVectorAngle;
				pinkyMCPNondominantTotalVectorDisplacement = pinkyMCPNondominantFeatures.TotalVectorDisplacement;
				pinkyMCPNondominantTotalDisplacement = pinkyMCPNondominantFeatures.TotalDisplacement;
				pinkyMCPNondominantMaximumDisplacement = pinkyMCPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyPIPNondominant joint features
			double? pinkyPIPNondominantF1F2SpatialAngle = null;
			double? pinkyPIPNondominantFN_1FNSpatialAngle = null;
			double? pinkyPIPNondominantF1FNSpatialAngle = null;
			double? pinkyPIPNondominantTotalVectorAngle = null;
			double? pinkyPIPNondominantSquaredTotalVectorAngle = null;
			double? pinkyPIPNondominantTotalVectorDisplacement = null;
			double? pinkyPIPNondominantTotalDisplacement = null;
			double? pinkyPIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyPIPLeft, JointType.PinkyPIPRight, features.HandDominance, false),
				out var pinkyPIPNondominantFeatures))
			{
				pinkyPIPNondominantF1F2SpatialAngle = pinkyPIPNondominantFeatures.F1F2SpatialAngle;
				pinkyPIPNondominantFN_1FNSpatialAngle = pinkyPIPNondominantFeatures.FN_1FNSpatialAngle;
				pinkyPIPNondominantF1FNSpatialAngle = pinkyPIPNondominantFeatures.F1FNSpatialAngle;
				pinkyPIPNondominantTotalVectorAngle = pinkyPIPNondominantFeatures.TotalVectorAngle;
				pinkyPIPNondominantSquaredTotalVectorAngle = pinkyPIPNondominantFeatures.SquaredTotalVectorAngle;
				pinkyPIPNondominantTotalVectorDisplacement = pinkyPIPNondominantFeatures.TotalVectorDisplacement;
				pinkyPIPNondominantTotalDisplacement = pinkyPIPNondominantFeatures.TotalDisplacement;
				pinkyPIPNondominantMaximumDisplacement = pinkyPIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyDIPNondominant joint features
			double? pinkyDIPNondominantF1F2SpatialAngle = null;
			double? pinkyDIPNondominantFN_1FNSpatialAngle = null;
			double? pinkyDIPNondominantF1FNSpatialAngle = null;
			double? pinkyDIPNondominantTotalVectorAngle = null;
			double? pinkyDIPNondominantSquaredTotalVectorAngle = null;
			double? pinkyDIPNondominantTotalVectorDisplacement = null;
			double? pinkyDIPNondominantTotalDisplacement = null;
			double? pinkyDIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyDIPLeft, JointType.PinkyDIPRight, features.HandDominance, false),
				out var pinkyDIPNondominantFeatures))
			{
				pinkyDIPNondominantF1F2SpatialAngle = pinkyDIPNondominantFeatures.F1F2SpatialAngle;
				pinkyDIPNondominantFN_1FNSpatialAngle = pinkyDIPNondominantFeatures.FN_1FNSpatialAngle;
				pinkyDIPNondominantF1FNSpatialAngle = pinkyDIPNondominantFeatures.F1FNSpatialAngle;
				pinkyDIPNondominantTotalVectorAngle = pinkyDIPNondominantFeatures.TotalVectorAngle;
				pinkyDIPNondominantSquaredTotalVectorAngle = pinkyDIPNondominantFeatures.SquaredTotalVectorAngle;
				pinkyDIPNondominantTotalVectorDisplacement = pinkyDIPNondominantFeatures.TotalVectorDisplacement;
				pinkyDIPNondominantTotalDisplacement = pinkyDIPNondominantFeatures.TotalDisplacement;
				pinkyDIPNondominantMaximumDisplacement = pinkyDIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region PinkyTIPNondominant joint features
			double? pinkyTIPNondominantF1F2SpatialAngle = null;
			double? pinkyTIPNondominantFN_1FNSpatialAngle = null;
			double? pinkyTIPNondominantF1FNSpatialAngle = null;
			double? pinkyTIPNondominantTotalVectorAngle = null;
			double? pinkyTIPNondominantSquaredTotalVectorAngle = null;
			double? pinkyTIPNondominantTotalVectorDisplacement = null;
			double? pinkyTIPNondominantTotalDisplacement = null;
			double? pinkyTIPNondominantMaximumDisplacement = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.PinkyTIPLeft, JointType.PinkyTIPRight, features.HandDominance, false),
				out var pinkyTIPNondominantFeatures))
			{
				pinkyTIPNondominantF1F2SpatialAngle = pinkyTIPNondominantFeatures.F1F2SpatialAngle;
				pinkyTIPNondominantFN_1FNSpatialAngle = pinkyTIPNondominantFeatures.FN_1FNSpatialAngle;
				pinkyTIPNondominantF1FNSpatialAngle = pinkyTIPNondominantFeatures.F1FNSpatialAngle;
				pinkyTIPNondominantTotalVectorAngle = pinkyTIPNondominantFeatures.TotalVectorAngle;
				pinkyTIPNondominantSquaredTotalVectorAngle = pinkyTIPNondominantFeatures.SquaredTotalVectorAngle;
				pinkyTIPNondominantTotalVectorDisplacement = pinkyTIPNondominantFeatures.TotalVectorDisplacement;
				pinkyTIPNondominantTotalDisplacement = pinkyTIPNondominantFeatures.TotalDisplacement;
				pinkyTIPNondominantMaximumDisplacement = pinkyTIPNondominantFeatures.MaximumDisplacement;
			}
			#endregion

			#region HandNondominant joint features
			double? handNondominantF1F2SpatialAngle = null;
			double? handNondominantFN_1FNSpatialAngle = null;
			double? handNondominantF1FNSpatialAngle = null;
			double? handNondominantTotalVectorAngle = null;
			double? handNondominantSquaredTotalVectorAngle = null;
			double? handNondominantTotalVectorDisplacement = null;
			double? handNondominantTotalDisplacement = null;
			double? handNondominantMaximumDisplacement = null;
			double? handNondominantBoundingBoxDiagonalLength = null;
			double? handNondominantBoundingBoxAngle = null;
			//HandState[] handNondominantHandStates = null;
			if (features.JointsGestureFeaturesDict.TryGetValue(GetJointTypeByHandDominance(JointType.HandLeft, JointType.HandRight, features.HandDominance, false),
				out var handNondominantFeatures) && handNondominantFeatures is HandJointGestureFeatures handNondominantHandFeatures)
			{
				handNondominantF1F2SpatialAngle = handNondominantHandFeatures.F1F2SpatialAngle;
				handNondominantFN_1FNSpatialAngle = handNondominantHandFeatures.FN_1FNSpatialAngle;
				handNondominantF1FNSpatialAngle = handNondominantHandFeatures.F1FNSpatialAngle;
				handNondominantTotalVectorAngle = handNondominantHandFeatures.TotalVectorAngle;
				handNondominantSquaredTotalVectorAngle = handNondominantHandFeatures.SquaredTotalVectorAngle;
				handNondominantTotalVectorDisplacement = handNondominantHandFeatures.TotalVectorDisplacement;
				handNondominantTotalDisplacement = handNondominantHandFeatures.TotalDisplacement;
				handNondominantMaximumDisplacement = handNondominantHandFeatures.MaximumDisplacement;
				handNondominantBoundingBoxDiagonalLength = handNondominantHandFeatures.BoundingBoxDiagonalLength;
				handNondominantBoundingBoxAngle = handNondominantHandFeatures.BoundingBoxAngle;
				//handNondominantHandStates = handNondominantHandFeatures.HandStates;
			}
			#endregion

			#region WristThumbCMCDominant bone features
			double? wristThumbCMCDominantBoneInitialAngle = null;
			double? wristThumbCMCDominantBoneFinalAngle = null;
			double? wristThumbCMCDominantBoneMeanAngle = null;
			double? wristThumbCMCDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristThumbCMCLeftBone, MediaPipeHandLandmarksBonesDefs.WristThumbCMCRightBone,
				features.HandDominance, true), out var wristThumbCMCDominantBoneAngleData))
			{
				wristThumbCMCDominantBoneInitialAngle = wristThumbCMCDominantBoneAngleData.InitialAngle;
				wristThumbCMCDominantBoneFinalAngle = wristThumbCMCDominantBoneAngleData.FinalAngle;
				wristThumbCMCDominantBoneMeanAngle = wristThumbCMCDominantBoneAngleData.MeanAngle;
				wristThumbCMCDominantBoneMaximumAngle = wristThumbCMCDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbCMCThumbMCPDominant bone features
			double? thumbCMCThumbMCPDominantBoneInitialAngle = null;
			double? thumbCMCThumbMCPDominantBoneFinalAngle = null;
			double? thumbCMCThumbMCPDominantBoneMeanAngle = null;
			double? thumbCMCThumbMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPRightBone,
				features.HandDominance, true), out var thumbCMCThumbMCPDominantBoneAngleData))
			{
				thumbCMCThumbMCPDominantBoneInitialAngle = thumbCMCThumbMCPDominantBoneAngleData.InitialAngle;
				thumbCMCThumbMCPDominantBoneFinalAngle = thumbCMCThumbMCPDominantBoneAngleData.FinalAngle;
				thumbCMCThumbMCPDominantBoneMeanAngle = thumbCMCThumbMCPDominantBoneAngleData.MeanAngle;
				thumbCMCThumbMCPDominantBoneMaximumAngle = thumbCMCThumbMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbMCPThumbIPDominant bone features
			double? thumbMCPThumbIPDominantBoneInitialAngle = null;
			double? thumbMCPThumbIPDominantBoneFinalAngle = null;
			double? thumbMCPThumbIPDominantBoneMeanAngle = null;
			double? thumbMCPThumbIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPRightBone,
				features.HandDominance, true), out var thumbMCPThumbIPDominantBoneAngleData))
			{
				thumbMCPThumbIPDominantBoneInitialAngle = thumbMCPThumbIPDominantBoneAngleData.InitialAngle;
				thumbMCPThumbIPDominantBoneFinalAngle = thumbMCPThumbIPDominantBoneAngleData.FinalAngle;
				thumbMCPThumbIPDominantBoneMeanAngle = thumbMCPThumbIPDominantBoneAngleData.MeanAngle;
				thumbMCPThumbIPDominantBoneMaximumAngle = thumbMCPThumbIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbIPThumbTIPDominant bone features
			double? thumbIPThumbTIPDominantBoneInitialAngle = null;
			double? thumbIPThumbTIPDominantBoneFinalAngle = null;
			double? thumbIPThumbTIPDominantBoneMeanAngle = null;
			double? thumbIPThumbTIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPRightBone,
				features.HandDominance, true), out var thumbIPThumbTIPDominantBoneAngleData))
			{
				thumbIPThumbTIPDominantBoneInitialAngle = thumbIPThumbTIPDominantBoneAngleData.InitialAngle;
				thumbIPThumbTIPDominantBoneFinalAngle = thumbIPThumbTIPDominantBoneAngleData.FinalAngle;
				thumbIPThumbTIPDominantBoneMeanAngle = thumbIPThumbTIPDominantBoneAngleData.MeanAngle;
				thumbIPThumbTIPDominantBoneMaximumAngle = thumbIPThumbTIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristIndexFingerMCPDominant bone features
			double? wristIndexFingerMCPDominantBoneInitialAngle = null;
			double? wristIndexFingerMCPDominantBoneFinalAngle = null;
			double? wristIndexFingerMCPDominantBoneMeanAngle = null;
			double? wristIndexFingerMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPRightBone,
				features.HandDominance, true), out var wristIndexFingerMCPDominantBoneAngleData))
			{
				wristIndexFingerMCPDominantBoneInitialAngle = wristIndexFingerMCPDominantBoneAngleData.InitialAngle;
				wristIndexFingerMCPDominantBoneFinalAngle = wristIndexFingerMCPDominantBoneAngleData.FinalAngle;
				wristIndexFingerMCPDominantBoneMeanAngle = wristIndexFingerMCPDominantBoneAngleData.MeanAngle;
				wristIndexFingerMCPDominantBoneMaximumAngle = wristIndexFingerMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerMCPIndexFingerPIPDominant bone features
			double? indexFingerMCPIndexFingerPIPDominantBoneInitialAngle = null;
			double? indexFingerMCPIndexFingerPIPDominantBoneFinalAngle = null;
			double? indexFingerMCPIndexFingerPIPDominantBoneMeanAngle = null;
			double? indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPRightBone,
				features.HandDominance, true), out var indexFingerMCPIndexFingerPIPDominantBoneAngleData))
			{
				indexFingerMCPIndexFingerPIPDominantBoneInitialAngle = indexFingerMCPIndexFingerPIPDominantBoneAngleData.InitialAngle;
				indexFingerMCPIndexFingerPIPDominantBoneFinalAngle = indexFingerMCPIndexFingerPIPDominantBoneAngleData.FinalAngle;
				indexFingerMCPIndexFingerPIPDominantBoneMeanAngle = indexFingerMCPIndexFingerPIPDominantBoneAngleData.MeanAngle;
				indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle = indexFingerMCPIndexFingerPIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerPIPIndexFingerDIPDominant bone features
			double? indexFingerPIPIndexFingerDIPDominantBoneInitialAngle = null;
			double? indexFingerPIPIndexFingerDIPDominantBoneFinalAngle = null;
			double? indexFingerPIPIndexFingerDIPDominantBoneMeanAngle = null;
			double? indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPRightBone,
				features.HandDominance, true), out var indexFingerPIPIndexFingerDIPDominantBoneAngleData))
			{
				indexFingerPIPIndexFingerDIPDominantBoneInitialAngle = indexFingerPIPIndexFingerDIPDominantBoneAngleData.InitialAngle;
				indexFingerPIPIndexFingerDIPDominantBoneFinalAngle = indexFingerPIPIndexFingerDIPDominantBoneAngleData.FinalAngle;
				indexFingerPIPIndexFingerDIPDominantBoneMeanAngle = indexFingerPIPIndexFingerDIPDominantBoneAngleData.MeanAngle;
				indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle = indexFingerPIPIndexFingerDIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerDIPIndexFingerTIPDominant bone features
			double? indexFingerDIPIndexFingerTIPDominantBoneInitialAngle = null;
			double? indexFingerDIPIndexFingerTIPDominantBoneFinalAngle = null;
			double? indexFingerDIPIndexFingerTIPDominantBoneMeanAngle = null;
			double? indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPRightBone,
				features.HandDominance, true), out var indexFingerDIPIndexFingerTIPDominantBoneAngleData))
			{
				indexFingerDIPIndexFingerTIPDominantBoneInitialAngle = indexFingerDIPIndexFingerTIPDominantBoneAngleData.InitialAngle;
				indexFingerDIPIndexFingerTIPDominantBoneFinalAngle = indexFingerDIPIndexFingerTIPDominantBoneAngleData.FinalAngle;
				indexFingerDIPIndexFingerTIPDominantBoneMeanAngle = indexFingerDIPIndexFingerTIPDominantBoneAngleData.MeanAngle;
				indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle = indexFingerDIPIndexFingerTIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPDominant bone features
			double? middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle = null;
			double? middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle = null;
			double? middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle = null;
			double? middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPRightBone,
				features.HandDominance, true), out var middleFingerMCPMiddleFingerPIPDominantBoneAngleData))
			{
				middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle = middleFingerMCPMiddleFingerPIPDominantBoneAngleData.InitialAngle;
				middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle = middleFingerMCPMiddleFingerPIPDominantBoneAngleData.FinalAngle;
				middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle = middleFingerMCPMiddleFingerPIPDominantBoneAngleData.MeanAngle;
				middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle = middleFingerMCPMiddleFingerPIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPDominant bone features
			double? middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle = null;
			double? middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle = null;
			double? middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle = null;
			double? middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPRightBone,
				features.HandDominance, true), out var middleFingerPIPMiddleFingerDIPDominantBoneAngleData))
			{
				middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle = middleFingerPIPMiddleFingerDIPDominantBoneAngleData.InitialAngle;
				middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle = middleFingerPIPMiddleFingerDIPDominantBoneAngleData.FinalAngle;
				middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle = middleFingerPIPMiddleFingerDIPDominantBoneAngleData.MeanAngle;
				middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle = middleFingerPIPMiddleFingerDIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPDominant bone features
			double? middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle = null;
			double? middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle = null;
			double? middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle = null;
			double? middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPRightBone,
				features.HandDominance, true), out var middleFingerDIPMiddleFingerTIPDominantBoneAngleData))
			{
				middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle = middleFingerDIPMiddleFingerTIPDominantBoneAngleData.InitialAngle;
				middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle = middleFingerDIPMiddleFingerTIPDominantBoneAngleData.FinalAngle;
				middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle = middleFingerDIPMiddleFingerTIPDominantBoneAngleData.MeanAngle;
				middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle = middleFingerDIPMiddleFingerTIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerMCPRingFingerPIPDominant bone features
			double? ringFingerMCPRingFingerPIPDominantBoneInitialAngle = null;
			double? ringFingerMCPRingFingerPIPDominantBoneFinalAngle = null;
			double? ringFingerMCPRingFingerPIPDominantBoneMeanAngle = null;
			double? ringFingerMCPRingFingerPIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPRightBone,
				features.HandDominance, true), out var ringFingerMCPRingFingerPIPDominantBoneAngleData))
			{
				ringFingerMCPRingFingerPIPDominantBoneInitialAngle = ringFingerMCPRingFingerPIPDominantBoneAngleData.InitialAngle;
				ringFingerMCPRingFingerPIPDominantBoneFinalAngle = ringFingerMCPRingFingerPIPDominantBoneAngleData.FinalAngle;
				ringFingerMCPRingFingerPIPDominantBoneMeanAngle = ringFingerMCPRingFingerPIPDominantBoneAngleData.MeanAngle;
				ringFingerMCPRingFingerPIPDominantBoneMaximumAngle = ringFingerMCPRingFingerPIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerPIPRingFingerDIPDominant bone features
			double? ringFingerPIPRingFingerDIPDominantBoneInitialAngle = null;
			double? ringFingerPIPRingFingerDIPDominantBoneFinalAngle = null;
			double? ringFingerPIPRingFingerDIPDominantBoneMeanAngle = null;
			double? ringFingerPIPRingFingerDIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPRightBone,
				features.HandDominance, true), out var ringFingerPIPRingFingerDIPDominantBoneAngleData))
			{
				ringFingerPIPRingFingerDIPDominantBoneInitialAngle = ringFingerPIPRingFingerDIPDominantBoneAngleData.InitialAngle;
				ringFingerPIPRingFingerDIPDominantBoneFinalAngle = ringFingerPIPRingFingerDIPDominantBoneAngleData.FinalAngle;
				ringFingerPIPRingFingerDIPDominantBoneMeanAngle = ringFingerPIPRingFingerDIPDominantBoneAngleData.MeanAngle;
				ringFingerPIPRingFingerDIPDominantBoneMaximumAngle = ringFingerPIPRingFingerDIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerDIPRingFingerTIPDominant bone features
			double? ringFingerDIPRingFingerTIPDominantBoneInitialAngle = null;
			double? ringFingerDIPRingFingerTIPDominantBoneFinalAngle = null;
			double? ringFingerDIPRingFingerTIPDominantBoneMeanAngle = null;
			double? ringFingerDIPRingFingerTIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPRightBone,
				features.HandDominance, true), out var ringFingerDIPRingFingerTIPDominantBoneAngleData))
			{
				ringFingerDIPRingFingerTIPDominantBoneInitialAngle = ringFingerDIPRingFingerTIPDominantBoneAngleData.InitialAngle;
				ringFingerDIPRingFingerTIPDominantBoneFinalAngle = ringFingerDIPRingFingerTIPDominantBoneAngleData.FinalAngle;
				ringFingerDIPRingFingerTIPDominantBoneMeanAngle = ringFingerDIPRingFingerTIPDominantBoneAngleData.MeanAngle;
				ringFingerDIPRingFingerTIPDominantBoneMaximumAngle = ringFingerDIPRingFingerTIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristPinkyMCPDominant bone features
			double? wristPinkyMCPDominantBoneInitialAngle = null;
			double? wristPinkyMCPDominantBoneFinalAngle = null;
			double? wristPinkyMCPDominantBoneMeanAngle = null;
			double? wristPinkyMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristPinkyMCPRightBone,
				features.HandDominance, true), out var wristPinkyMCPDominantBoneAngleData))
			{
				wristPinkyMCPDominantBoneInitialAngle = wristPinkyMCPDominantBoneAngleData.InitialAngle;
				wristPinkyMCPDominantBoneFinalAngle = wristPinkyMCPDominantBoneAngleData.FinalAngle;
				wristPinkyMCPDominantBoneMeanAngle = wristPinkyMCPDominantBoneAngleData.MeanAngle;
				wristPinkyMCPDominantBoneMaximumAngle = wristPinkyMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region PinkyMCPPinkyPIPDominant bone features
			double? pinkyMCPPinkyPIPDominantBoneInitialAngle = null;
			double? pinkyMCPPinkyPIPDominantBoneFinalAngle = null;
			double? pinkyMCPPinkyPIPDominantBoneMeanAngle = null;
			double? pinkyMCPPinkyPIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPRightBone,
				features.HandDominance, true), out var pinkyMCPPinkyPIPDominantBoneAngleData))
			{
				pinkyMCPPinkyPIPDominantBoneInitialAngle = pinkyMCPPinkyPIPDominantBoneAngleData.InitialAngle;
				pinkyMCPPinkyPIPDominantBoneFinalAngle = pinkyMCPPinkyPIPDominantBoneAngleData.FinalAngle;
				pinkyMCPPinkyPIPDominantBoneMeanAngle = pinkyMCPPinkyPIPDominantBoneAngleData.MeanAngle;
				pinkyMCPPinkyPIPDominantBoneMaximumAngle = pinkyMCPPinkyPIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region PinkyPIPPinkyDIPDominant bone features
			double? pinkyPIPPinkyDIPDominantBoneInitialAngle = null;
			double? pinkyPIPPinkyDIPDominantBoneFinalAngle = null;
			double? pinkyPIPPinkyDIPDominantBoneMeanAngle = null;
			double? pinkyPIPPinkyDIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPRightBone,
				features.HandDominance, true), out var pinkyPIPPinkyDIPDominantBoneAngleData))
			{
				pinkyPIPPinkyDIPDominantBoneInitialAngle = pinkyPIPPinkyDIPDominantBoneAngleData.InitialAngle;
				pinkyPIPPinkyDIPDominantBoneFinalAngle = pinkyPIPPinkyDIPDominantBoneAngleData.FinalAngle;
				pinkyPIPPinkyDIPDominantBoneMeanAngle = pinkyPIPPinkyDIPDominantBoneAngleData.MeanAngle;
				pinkyPIPPinkyDIPDominantBoneMaximumAngle = pinkyPIPPinkyDIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region PinkyDIPPinkyTIPDominant bone features
			double? pinkyDIPPinkyTIPDominantBoneInitialAngle = null;
			double? pinkyDIPPinkyTIPDominantBoneFinalAngle = null;
			double? pinkyDIPPinkyTIPDominantBoneMeanAngle = null;
			double? pinkyDIPPinkyTIPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, true), out var pinkyDIPPinkyTIPDominantBoneAngleData))
			{
				pinkyDIPPinkyTIPDominantBoneInitialAngle = pinkyDIPPinkyTIPDominantBoneAngleData.InitialAngle;
				pinkyDIPPinkyTIPDominantBoneFinalAngle = pinkyDIPPinkyTIPDominantBoneAngleData.FinalAngle;
				pinkyDIPPinkyTIPDominantBoneMeanAngle = pinkyDIPPinkyTIPDominantBoneAngleData.MeanAngle;
				pinkyDIPPinkyTIPDominantBoneMaximumAngle = pinkyDIPPinkyTIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbIPIndexFingerMCPDominant bone features
			double? thumbIPIndexFingerMCPDominantBoneInitialAngle = null;
			double? thumbIPIndexFingerMCPDominantBoneFinalAngle = null;
			double? thumbIPIndexFingerMCPDominantBoneMeanAngle = null;
			double? thumbIPIndexFingerMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPRightBone,
				features.HandDominance, true), out var thumbIPIndexFingerMCPDominantBoneAngleData))
			{
				thumbIPIndexFingerMCPDominantBoneInitialAngle = thumbIPIndexFingerMCPDominantBoneAngleData.InitialAngle;
				thumbIPIndexFingerMCPDominantBoneFinalAngle = thumbIPIndexFingerMCPDominantBoneAngleData.FinalAngle;
				thumbIPIndexFingerMCPDominantBoneMeanAngle = thumbIPIndexFingerMCPDominantBoneAngleData.MeanAngle;
				thumbIPIndexFingerMCPDominantBoneMaximumAngle = thumbIPIndexFingerMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominant bone features
			double? indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle = null;
			double? indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle = null;
			double? indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle = null;
			double? indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPRightBone,
				features.HandDominance, true), out var indexFingerMCPMiddleFingerMCPDominantBoneAngleData))
			{
				indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle = indexFingerMCPMiddleFingerMCPDominantBoneAngleData.InitialAngle;
				indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle = indexFingerMCPMiddleFingerMCPDominantBoneAngleData.FinalAngle;
				indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle = indexFingerMCPMiddleFingerMCPDominantBoneAngleData.MeanAngle;
				indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle = indexFingerMCPMiddleFingerMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerMCPRingFingerMCPDominant bone features
			double? middleFingerMCPRingFingerMCPDominantBoneInitialAngle = null;
			double? middleFingerMCPRingFingerMCPDominantBoneFinalAngle = null;
			double? middleFingerMCPRingFingerMCPDominantBoneMeanAngle = null;
			double? middleFingerMCPRingFingerMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPRightBone,
				features.HandDominance, true), out var middleFingerMCPRingFingerMCPDominantBoneAngleData))
			{
				middleFingerMCPRingFingerMCPDominantBoneInitialAngle = middleFingerMCPRingFingerMCPDominantBoneAngleData.InitialAngle;
				middleFingerMCPRingFingerMCPDominantBoneFinalAngle = middleFingerMCPRingFingerMCPDominantBoneAngleData.FinalAngle;
				middleFingerMCPRingFingerMCPDominantBoneMeanAngle = middleFingerMCPRingFingerMCPDominantBoneAngleData.MeanAngle;
				middleFingerMCPRingFingerMCPDominantBoneMaximumAngle = middleFingerMCPRingFingerMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerMCPPinkyMCPDominant bone features
			double? ringFingerMCPPinkyMCPDominantBoneInitialAngle = null;
			double? ringFingerMCPPinkyMCPDominantBoneFinalAngle = null;
			double? ringFingerMCPPinkyMCPDominantBoneMeanAngle = null;
			double? ringFingerMCPPinkyMCPDominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPRightBone,
				features.HandDominance, true), out var ringFingerMCPPinkyMCPDominantBoneAngleData))
			{
				ringFingerMCPPinkyMCPDominantBoneInitialAngle = ringFingerMCPPinkyMCPDominantBoneAngleData.InitialAngle;
				ringFingerMCPPinkyMCPDominantBoneFinalAngle = ringFingerMCPPinkyMCPDominantBoneAngleData.FinalAngle;
				ringFingerMCPPinkyMCPDominantBoneMeanAngle = ringFingerMCPPinkyMCPDominantBoneAngleData.MeanAngle;
				ringFingerMCPPinkyMCPDominantBoneMaximumAngle = ringFingerMCPPinkyMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristThumbCMCNondominant bone features
			double? wristThumbCMCNondominantBoneInitialAngle = null;
			double? wristThumbCMCNondominantBoneFinalAngle = null;
			double? wristThumbCMCNondominantBoneMeanAngle = null;
			double? wristThumbCMCNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristThumbCMCLeftBone, MediaPipeHandLandmarksBonesDefs.WristThumbCMCRightBone,
				features.HandDominance, true), out var wristThumbCMCNondominantBoneAngleData))
			{
				wristThumbCMCNondominantBoneInitialAngle = wristThumbCMCNondominantBoneAngleData.InitialAngle;
				wristThumbCMCNondominantBoneFinalAngle = wristThumbCMCNondominantBoneAngleData.FinalAngle;
				wristThumbCMCNondominantBoneMeanAngle = wristThumbCMCNondominantBoneAngleData.MeanAngle;
				wristThumbCMCNondominantBoneMaximumAngle = wristThumbCMCNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbCMCThumbMCPNondominant bone features
			double? thumbCMCThumbMCPNondominantBoneInitialAngle = null;
			double? thumbCMCThumbMCPNondominantBoneFinalAngle = null;
			double? thumbCMCThumbMCPNondominantBoneMeanAngle = null;
			double? thumbCMCThumbMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPRightBone,
				features.HandDominance, true), out var thumbCMCThumbMCPNondominantBoneAngleData))
			{
				thumbCMCThumbMCPNondominantBoneInitialAngle = thumbCMCThumbMCPNondominantBoneAngleData.InitialAngle;
				thumbCMCThumbMCPNondominantBoneFinalAngle = thumbCMCThumbMCPNondominantBoneAngleData.FinalAngle;
				thumbCMCThumbMCPNondominantBoneMeanAngle = thumbCMCThumbMCPNondominantBoneAngleData.MeanAngle;
				thumbCMCThumbMCPNondominantBoneMaximumAngle = thumbCMCThumbMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbMCPThumbIPNondominant bone features
			double? thumbMCPThumbIPNondominantBoneInitialAngle = null;
			double? thumbMCPThumbIPNondominantBoneFinalAngle = null;
			double? thumbMCPThumbIPNondominantBoneMeanAngle = null;
			double? thumbMCPThumbIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPRightBone,
				features.HandDominance, true), out var thumbMCPThumbIPNondominantBoneAngleData))
			{
				thumbMCPThumbIPNondominantBoneInitialAngle = thumbMCPThumbIPNondominantBoneAngleData.InitialAngle;
				thumbMCPThumbIPNondominantBoneFinalAngle = thumbMCPThumbIPNondominantBoneAngleData.FinalAngle;
				thumbMCPThumbIPNondominantBoneMeanAngle = thumbMCPThumbIPNondominantBoneAngleData.MeanAngle;
				thumbMCPThumbIPNondominantBoneMaximumAngle = thumbMCPThumbIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbIPThumbTIPNondominant bone features
			double? thumbIPThumbTIPNondominantBoneInitialAngle = null;
			double? thumbIPThumbTIPNondominantBoneFinalAngle = null;
			double? thumbIPThumbTIPNondominantBoneMeanAngle = null;
			double? thumbIPThumbTIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPRightBone,
				features.HandDominance, true), out var thumbIPThumbTIPNondominantBoneAngleData))
			{
				thumbIPThumbTIPNondominantBoneInitialAngle = thumbIPThumbTIPNondominantBoneAngleData.InitialAngle;
				thumbIPThumbTIPNondominantBoneFinalAngle = thumbIPThumbTIPNondominantBoneAngleData.FinalAngle;
				thumbIPThumbTIPNondominantBoneMeanAngle = thumbIPThumbTIPNondominantBoneAngleData.MeanAngle;
				thumbIPThumbTIPNondominantBoneMaximumAngle = thumbIPThumbTIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristIndexFingerMCPNondominant bone features
			double? wristIndexFingerMCPNondominantBoneInitialAngle = null;
			double? wristIndexFingerMCPNondominantBoneFinalAngle = null;
			double? wristIndexFingerMCPNondominantBoneMeanAngle = null;
			double? wristIndexFingerMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPRightBone,
				features.HandDominance, true), out var wristIndexFingerMCPNondominantBoneAngleData))
			{
				wristIndexFingerMCPNondominantBoneInitialAngle = wristIndexFingerMCPNondominantBoneAngleData.InitialAngle;
				wristIndexFingerMCPNondominantBoneFinalAngle = wristIndexFingerMCPNondominantBoneAngleData.FinalAngle;
				wristIndexFingerMCPNondominantBoneMeanAngle = wristIndexFingerMCPNondominantBoneAngleData.MeanAngle;
				wristIndexFingerMCPNondominantBoneMaximumAngle = wristIndexFingerMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerMCPIndexFingerPIPNondominant bone features
			double? indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle = null;
			double? indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle = null;
			double? indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle = null;
			double? indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPRightBone,
				features.HandDominance, true), out var indexFingerMCPIndexFingerPIPNondominantBoneAngleData))
			{
				indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle = indexFingerMCPIndexFingerPIPNondominantBoneAngleData.InitialAngle;
				indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle = indexFingerMCPIndexFingerPIPNondominantBoneAngleData.FinalAngle;
				indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle = indexFingerMCPIndexFingerPIPNondominantBoneAngleData.MeanAngle;
				indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle = indexFingerMCPIndexFingerPIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerPIPIndexFingerDIPNondominant bone features
			double? indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle = null;
			double? indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle = null;
			double? indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle = null;
			double? indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPRightBone,
				features.HandDominance, true), out var indexFingerPIPIndexFingerDIPNondominantBoneAngleData))
			{
				indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle = indexFingerPIPIndexFingerDIPNondominantBoneAngleData.InitialAngle;
				indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle = indexFingerPIPIndexFingerDIPNondominantBoneAngleData.FinalAngle;
				indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle = indexFingerPIPIndexFingerDIPNondominantBoneAngleData.MeanAngle;
				indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle = indexFingerPIPIndexFingerDIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerDIPIndexFingerTIPNondominant bone features
			double? indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle = null;
			double? indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle = null;
			double? indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle = null;
			double? indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPRightBone,
				features.HandDominance, true), out var indexFingerDIPIndexFingerTIPNondominantBoneAngleData))
			{
				indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle = indexFingerDIPIndexFingerTIPNondominantBoneAngleData.InitialAngle;
				indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle = indexFingerDIPIndexFingerTIPNondominantBoneAngleData.FinalAngle;
				indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle = indexFingerDIPIndexFingerTIPNondominantBoneAngleData.MeanAngle;
				indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle = indexFingerDIPIndexFingerTIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPNondominant bone features
			double? middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle = null;
			double? middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle = null;
			double? middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle = null;
			double? middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPRightBone,
				features.HandDominance, true), out var middleFingerMCPMiddleFingerPIPNondominantBoneAngleData))
			{
				middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle = middleFingerMCPMiddleFingerPIPNondominantBoneAngleData.InitialAngle;
				middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle = middleFingerMCPMiddleFingerPIPNondominantBoneAngleData.FinalAngle;
				middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle = middleFingerMCPMiddleFingerPIPNondominantBoneAngleData.MeanAngle;
				middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle = middleFingerMCPMiddleFingerPIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPNondominant bone features
			double? middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle = null;
			double? middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle = null;
			double? middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle = null;
			double? middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPRightBone,
				features.HandDominance, true), out var middleFingerPIPMiddleFingerDIPNondominantBoneAngleData))
			{
				middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle = middleFingerPIPMiddleFingerDIPNondominantBoneAngleData.InitialAngle;
				middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle = middleFingerPIPMiddleFingerDIPNondominantBoneAngleData.FinalAngle;
				middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle = middleFingerPIPMiddleFingerDIPNondominantBoneAngleData.MeanAngle;
				middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle = middleFingerPIPMiddleFingerDIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPNondominant bone features
			double? middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle = null;
			double? middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle = null;
			double? middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle = null;
			double? middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPRightBone,
				features.HandDominance, true), out var middleFingerDIPMiddleFingerTIPNondominantBoneAngleData))
			{
				middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle = middleFingerDIPMiddleFingerTIPNondominantBoneAngleData.InitialAngle;
				middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle = middleFingerDIPMiddleFingerTIPNondominantBoneAngleData.FinalAngle;
				middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle = middleFingerDIPMiddleFingerTIPNondominantBoneAngleData.MeanAngle;
				middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle = middleFingerDIPMiddleFingerTIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerMCPRingFingerPIPNondominant bone features
			double? ringFingerMCPRingFingerPIPNondominantBoneInitialAngle = null;
			double? ringFingerMCPRingFingerPIPNondominantBoneFinalAngle = null;
			double? ringFingerMCPRingFingerPIPNondominantBoneMeanAngle = null;
			double? ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPRightBone,
				features.HandDominance, true), out var ringFingerMCPRingFingerPIPNondominantBoneAngleData))
			{
				ringFingerMCPRingFingerPIPNondominantBoneInitialAngle = ringFingerMCPRingFingerPIPNondominantBoneAngleData.InitialAngle;
				ringFingerMCPRingFingerPIPNondominantBoneFinalAngle = ringFingerMCPRingFingerPIPNondominantBoneAngleData.FinalAngle;
				ringFingerMCPRingFingerPIPNondominantBoneMeanAngle = ringFingerMCPRingFingerPIPNondominantBoneAngleData.MeanAngle;
				ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle = ringFingerMCPRingFingerPIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerPIPRingFingerDIPNondominant bone features
			double? ringFingerPIPRingFingerDIPNondominantBoneInitialAngle = null;
			double? ringFingerPIPRingFingerDIPNondominantBoneFinalAngle = null;
			double? ringFingerPIPRingFingerDIPNondominantBoneMeanAngle = null;
			double? ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPRightBone,
				features.HandDominance, true), out var ringFingerPIPRingFingerDIPNondominantBoneAngleData))
			{
				ringFingerPIPRingFingerDIPNondominantBoneInitialAngle = ringFingerPIPRingFingerDIPNondominantBoneAngleData.InitialAngle;
				ringFingerPIPRingFingerDIPNondominantBoneFinalAngle = ringFingerPIPRingFingerDIPNondominantBoneAngleData.FinalAngle;
				ringFingerPIPRingFingerDIPNondominantBoneMeanAngle = ringFingerPIPRingFingerDIPNondominantBoneAngleData.MeanAngle;
				ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle = ringFingerPIPRingFingerDIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerDIPRingFingerTIPNondominant bone features
			double? ringFingerDIPRingFingerTIPNondominantBoneInitialAngle = null;
			double? ringFingerDIPRingFingerTIPNondominantBoneFinalAngle = null;
			double? ringFingerDIPRingFingerTIPNondominantBoneMeanAngle = null;
			double? ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPRightBone,
				features.HandDominance, true), out var ringFingerDIPRingFingerTIPNondominantBoneAngleData))
			{
				ringFingerDIPRingFingerTIPNondominantBoneInitialAngle = ringFingerDIPRingFingerTIPNondominantBoneAngleData.InitialAngle;
				ringFingerDIPRingFingerTIPNondominantBoneFinalAngle = ringFingerDIPRingFingerTIPNondominantBoneAngleData.FinalAngle;
				ringFingerDIPRingFingerTIPNondominantBoneMeanAngle = ringFingerDIPRingFingerTIPNondominantBoneAngleData.MeanAngle;
				ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle = ringFingerDIPRingFingerTIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristPinkyMCPNondominant bone features
			double? wristPinkyMCPNondominantBoneInitialAngle = null;
			double? wristPinkyMCPNondominantBoneFinalAngle = null;
			double? wristPinkyMCPNondominantBoneMeanAngle = null;
			double? wristPinkyMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristPinkyMCPRightBone,
				features.HandDominance, true), out var wristPinkyMCPNondominantBoneAngleData))
			{
				wristPinkyMCPNondominantBoneInitialAngle = wristPinkyMCPNondominantBoneAngleData.InitialAngle;
				wristPinkyMCPNondominantBoneFinalAngle = wristPinkyMCPNondominantBoneAngleData.FinalAngle;
				wristPinkyMCPNondominantBoneMeanAngle = wristPinkyMCPNondominantBoneAngleData.MeanAngle;
				wristPinkyMCPNondominantBoneMaximumAngle = wristPinkyMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region PinkyMCPPinkyPIPNondominant bone features
			double? pinkyMCPPinkyPIPNondominantBoneInitialAngle = null;
			double? pinkyMCPPinkyPIPNondominantBoneFinalAngle = null;
			double? pinkyMCPPinkyPIPNondominantBoneMeanAngle = null;
			double? pinkyMCPPinkyPIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPRightBone,
				features.HandDominance, true), out var pinkyMCPPinkyPIPNondominantBoneAngleData))
			{
				pinkyMCPPinkyPIPNondominantBoneInitialAngle = pinkyMCPPinkyPIPNondominantBoneAngleData.InitialAngle;
				pinkyMCPPinkyPIPNondominantBoneFinalAngle = pinkyMCPPinkyPIPNondominantBoneAngleData.FinalAngle;
				pinkyMCPPinkyPIPNondominantBoneMeanAngle = pinkyMCPPinkyPIPNondominantBoneAngleData.MeanAngle;
				pinkyMCPPinkyPIPNondominantBoneMaximumAngle = pinkyMCPPinkyPIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region PinkyPIPPinkyDIPNondominant bone features
			double? pinkyPIPPinkyDIPNondominantBoneInitialAngle = null;
			double? pinkyPIPPinkyDIPNondominantBoneFinalAngle = null;
			double? pinkyPIPPinkyDIPNondominantBoneMeanAngle = null;
			double? pinkyPIPPinkyDIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPRightBone,
				features.HandDominance, true), out var pinkyPIPPinkyDIPNondominantBoneAngleData))
			{
				pinkyPIPPinkyDIPNondominantBoneInitialAngle = pinkyPIPPinkyDIPNondominantBoneAngleData.InitialAngle;
				pinkyPIPPinkyDIPNondominantBoneFinalAngle = pinkyPIPPinkyDIPNondominantBoneAngleData.FinalAngle;
				pinkyPIPPinkyDIPNondominantBoneMeanAngle = pinkyPIPPinkyDIPNondominantBoneAngleData.MeanAngle;
				pinkyPIPPinkyDIPNondominantBoneMaximumAngle = pinkyPIPPinkyDIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region PinkyDIPPinkyTIPNondominant bone features
			double? pinkyDIPPinkyTIPNondominantBoneInitialAngle = null;
			double? pinkyDIPPinkyTIPNondominantBoneFinalAngle = null;
			double? pinkyDIPPinkyTIPNondominantBoneMeanAngle = null;
			double? pinkyDIPPinkyTIPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, true), out var pinkyDIPPinkyTIPNondominantBoneAngleData))
			{
				pinkyDIPPinkyTIPNondominantBoneInitialAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.InitialAngle;
				pinkyDIPPinkyTIPNondominantBoneFinalAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.FinalAngle;
				pinkyDIPPinkyTIPNondominantBoneMeanAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.MeanAngle;
				pinkyDIPPinkyTIPNondominantBoneMaximumAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbIPIndexFingerMCPNondominant bone features
			double? thumbIPIndexFingerMCPNondominantBoneInitialAngle = null;
			double? thumbIPIndexFingerMCPNondominantBoneFinalAngle = null;
			double? thumbIPIndexFingerMCPNondominantBoneMeanAngle = null;
			double? thumbIPIndexFingerMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPRightBone,
				features.HandDominance, true), out var thumbIPIndexFingerMCPNondominantBoneAngleData))
			{
				thumbIPIndexFingerMCPNondominantBoneInitialAngle = thumbIPIndexFingerMCPNondominantBoneAngleData.InitialAngle;
				thumbIPIndexFingerMCPNondominantBoneFinalAngle = thumbIPIndexFingerMCPNondominantBoneAngleData.FinalAngle;
				thumbIPIndexFingerMCPNondominantBoneMeanAngle = thumbIPIndexFingerMCPNondominantBoneAngleData.MeanAngle;
				thumbIPIndexFingerMCPNondominantBoneMaximumAngle = thumbIPIndexFingerMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominant bone features
			double? indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle = null;
			double? indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle = null;
			double? indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle = null;
			double? indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPRightBone,
				features.HandDominance, true), out var indexFingerMCPMiddleFingerMCPNondominantBoneAngleData))
			{
				indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle = indexFingerMCPMiddleFingerMCPNondominantBoneAngleData.InitialAngle;
				indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle = indexFingerMCPMiddleFingerMCPNondominantBoneAngleData.FinalAngle;
				indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle = indexFingerMCPMiddleFingerMCPNondominantBoneAngleData.MeanAngle;
				indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle = indexFingerMCPMiddleFingerMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region MiddleFingerMCPRingFingerMCPNondominant bone features
			double? middleFingerMCPRingFingerMCPNondominantBoneInitialAngle = null;
			double? middleFingerMCPRingFingerMCPNondominantBoneFinalAngle = null;
			double? middleFingerMCPRingFingerMCPNondominantBoneMeanAngle = null;
			double? middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPRightBone,
				features.HandDominance, true), out var middleFingerMCPRingFingerMCPNondominantBoneAngleData))
			{
				middleFingerMCPRingFingerMCPNondominantBoneInitialAngle = middleFingerMCPRingFingerMCPNondominantBoneAngleData.InitialAngle;
				middleFingerMCPRingFingerMCPNondominantBoneFinalAngle = middleFingerMCPRingFingerMCPNondominantBoneAngleData.FinalAngle;
				middleFingerMCPRingFingerMCPNondominantBoneMeanAngle = middleFingerMCPRingFingerMCPNondominantBoneAngleData.MeanAngle;
				middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle = middleFingerMCPRingFingerMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region RingFingerMCPPinkyMCPNondominant bone features
			double? ringFingerMCPPinkyMCPNondominantBoneInitialAngle = null;
			double? ringFingerMCPPinkyMCPNondominantBoneFinalAngle = null;
			double? ringFingerMCPPinkyMCPNondominantBoneMeanAngle = null;
			double? ringFingerMCPPinkyMCPNondominantBoneMaximumAngle = null;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPRightBone,
				features.HandDominance, true), out var ringFingerMCPPinkyMCPNondominantBoneAngleData))
			{
				ringFingerMCPPinkyMCPNondominantBoneInitialAngle = ringFingerMCPPinkyMCPNondominantBoneAngleData.InitialAngle;
				ringFingerMCPPinkyMCPNondominantBoneFinalAngle = ringFingerMCPPinkyMCPNondominantBoneAngleData.FinalAngle;
				ringFingerMCPPinkyMCPNondominantBoneMeanAngle = ringFingerMCPPinkyMCPNondominantBoneAngleData.MeanAngle;
				ringFingerMCPPinkyMCPNondominantBoneMaximumAngle = ringFingerMCPPinkyMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region Hands distances features
			double? betweenHandJointsDistanceMax = features.BetweenHandJointsDistanceMax;
			double? betweenHandJointsDistanceMean = features.BetweenHandJointsDistanceMean;
			#endregion

			return new MediaPipeHandLandmarksGestureDataView()
			{
				#region WristDominant joint features
				WristDominantF1F2SpatialAngle = wristDominantF1F2SpatialAngle,
				WristDominantFN_1FNSpatialAngle = wristDominantFN_1FNSpatialAngle,
				WristDominantF1FNSpatialAngle = wristDominantF1FNSpatialAngle,
				WristDominantTotalVectorAngle = wristDominantTotalVectorAngle,
				WristDominantSquaredTotalVectorAngle = wristDominantSquaredTotalVectorAngle,
				WristDominantTotalVectorDisplacement = wristDominantTotalVectorDisplacement,
				WristDominantTotalDisplacement = wristDominantTotalDisplacement,
				WristDominantMaximumDisplacement = wristDominantMaximumDisplacement,
				#endregion

				#region ThumbCMCDominant joint features
				ThumbCMCDominantF1F2SpatialAngle = thumbCMCDominantF1F2SpatialAngle,
				ThumbCMCDominantFN_1FNSpatialAngle = thumbCMCDominantFN_1FNSpatialAngle,
				ThumbCMCDominantF1FNSpatialAngle = thumbCMCDominantF1FNSpatialAngle,
				ThumbCMCDominantTotalVectorAngle = thumbCMCDominantTotalVectorAngle,
				ThumbCMCDominantSquaredTotalVectorAngle = thumbCMCDominantSquaredTotalVectorAngle,
				ThumbCMCDominantTotalVectorDisplacement = thumbCMCDominantTotalVectorDisplacement,
				ThumbCMCDominantTotalDisplacement = thumbCMCDominantTotalDisplacement,
				ThumbCMCDominantMaximumDisplacement = thumbCMCDominantMaximumDisplacement,
				#endregion

				#region ThumbMCPDominant joint features
				ThumbMCPDominantF1F2SpatialAngle = thumbMCPDominantF1F2SpatialAngle,
				ThumbMCPDominantFN_1FNSpatialAngle = thumbMCPDominantFN_1FNSpatialAngle,
				ThumbMCPDominantF1FNSpatialAngle = thumbMCPDominantF1FNSpatialAngle,
				ThumbMCPDominantTotalVectorAngle = thumbMCPDominantTotalVectorAngle,
				ThumbMCPDominantSquaredTotalVectorAngle = thumbMCPDominantSquaredTotalVectorAngle,
				ThumbMCPDominantTotalVectorDisplacement = thumbMCPDominantTotalVectorDisplacement,
				ThumbMCPDominantTotalDisplacement = thumbMCPDominantTotalDisplacement,
				ThumbMCPDominantMaximumDisplacement = thumbMCPDominantMaximumDisplacement,
				#endregion

				#region ThumbIPDominant joint features
				ThumbIPDominantF1F2SpatialAngle = thumbIPDominantF1F2SpatialAngle,
				ThumbIPDominantFN_1FNSpatialAngle = thumbIPDominantFN_1FNSpatialAngle,
				ThumbIPDominantF1FNSpatialAngle = thumbIPDominantF1FNSpatialAngle,
				ThumbIPDominantTotalVectorAngle = thumbIPDominantTotalVectorAngle,
				ThumbIPDominantSquaredTotalVectorAngle = thumbIPDominantSquaredTotalVectorAngle,
				ThumbIPDominantTotalVectorDisplacement = thumbIPDominantTotalVectorDisplacement,
				ThumbIPDominantTotalDisplacement = thumbIPDominantTotalDisplacement,
				ThumbIPDominantMaximumDisplacement = thumbIPDominantMaximumDisplacement,
				#endregion

				#region ThumbTIPDominant joint features
				ThumbTIPDominantF1F2SpatialAngle = thumbTIPDominantF1F2SpatialAngle,
				ThumbTIPDominantFN_1FNSpatialAngle = thumbTIPDominantFN_1FNSpatialAngle,
				ThumbTIPDominantF1FNSpatialAngle = thumbTIPDominantF1FNSpatialAngle,
				ThumbTIPDominantTotalVectorAngle = thumbTIPDominantTotalVectorAngle,
				ThumbTIPDominantSquaredTotalVectorAngle = thumbTIPDominantSquaredTotalVectorAngle,
				ThumbTIPDominantTotalVectorDisplacement = thumbTIPDominantTotalVectorDisplacement,
				ThumbTIPDominantTotalDisplacement = thumbTIPDominantTotalDisplacement,
				ThumbTIPDominantMaximumDisplacement = thumbTIPDominantMaximumDisplacement,
				#endregion

				#region IndexFingerMCPDominant joint features
				IndexFingerMCPDominantF1F2SpatialAngle = indexFingerMCPDominantF1F2SpatialAngle,
				IndexFingerMCPDominantFN_1FNSpatialAngle = indexFingerMCPDominantFN_1FNSpatialAngle,
				IndexFingerMCPDominantF1FNSpatialAngle = indexFingerMCPDominantF1FNSpatialAngle,
				IndexFingerMCPDominantTotalVectorAngle = indexFingerMCPDominantTotalVectorAngle,
				IndexFingerMCPDominantSquaredTotalVectorAngle = indexFingerMCPDominantSquaredTotalVectorAngle,
				IndexFingerMCPDominantTotalVectorDisplacement = indexFingerMCPDominantTotalVectorDisplacement,
				IndexFingerMCPDominantTotalDisplacement = indexFingerMCPDominantTotalDisplacement,
				IndexFingerMCPDominantMaximumDisplacement = indexFingerMCPDominantMaximumDisplacement,
				#endregion

				#region IndexFingerPIPDominant joint features
				IndexFingerPIPDominantF1F2SpatialAngle = indexFingerPIPDominantF1F2SpatialAngle,
				IndexFingerPIPDominantFN_1FNSpatialAngle = indexFingerPIPDominantFN_1FNSpatialAngle,
				IndexFingerPIPDominantF1FNSpatialAngle = indexFingerPIPDominantF1FNSpatialAngle,
				IndexFingerPIPDominantTotalVectorAngle = indexFingerPIPDominantTotalVectorAngle,
				IndexFingerPIPDominantSquaredTotalVectorAngle = indexFingerPIPDominantSquaredTotalVectorAngle,
				IndexFingerPIPDominantTotalVectorDisplacement = indexFingerPIPDominantTotalVectorDisplacement,
				IndexFingerPIPDominantTotalDisplacement = indexFingerPIPDominantTotalDisplacement,
				IndexFingerPIPDominantMaximumDisplacement = indexFingerPIPDominantMaximumDisplacement,
				#endregion

				#region IndexFingerDIPDominant joint features
				IndexFingerDIPDominantF1F2SpatialAngle = indexFingerDIPDominantF1F2SpatialAngle,
				IndexFingerDIPDominantFN_1FNSpatialAngle = indexFingerDIPDominantFN_1FNSpatialAngle,
				IndexFingerDIPDominantF1FNSpatialAngle = indexFingerDIPDominantF1FNSpatialAngle,
				IndexFingerDIPDominantTotalVectorAngle = indexFingerDIPDominantTotalVectorAngle,
				IndexFingerDIPDominantSquaredTotalVectorAngle = indexFingerDIPDominantSquaredTotalVectorAngle,
				IndexFingerDIPDominantTotalVectorDisplacement = indexFingerDIPDominantTotalVectorDisplacement,
				IndexFingerDIPDominantTotalDisplacement = indexFingerDIPDominantTotalDisplacement,
				IndexFingerDIPDominantMaximumDisplacement = indexFingerDIPDominantMaximumDisplacement,
				#endregion

				#region IndexFingerTIPDominant joint features
				IndexFingerTIPDominantF1F2SpatialAngle = indexFingerTIPDominantF1F2SpatialAngle,
				IndexFingerTIPDominantFN_1FNSpatialAngle = indexFingerTIPDominantFN_1FNSpatialAngle,
				IndexFingerTIPDominantF1FNSpatialAngle = indexFingerTIPDominantF1FNSpatialAngle,
				IndexFingerTIPDominantTotalVectorAngle = indexFingerTIPDominantTotalVectorAngle,
				IndexFingerTIPDominantSquaredTotalVectorAngle = indexFingerTIPDominantSquaredTotalVectorAngle,
				IndexFingerTIPDominantTotalVectorDisplacement = indexFingerTIPDominantTotalVectorDisplacement,
				IndexFingerTIPDominantTotalDisplacement = indexFingerTIPDominantTotalDisplacement,
				IndexFingerTIPDominantMaximumDisplacement = indexFingerTIPDominantMaximumDisplacement,
				#endregion

				#region MiddleFingerMCPDominant joint features
				MiddleFingerMCPDominantF1F2SpatialAngle = middleFingerMCPDominantF1F2SpatialAngle,
				MiddleFingerMCPDominantFN_1FNSpatialAngle = middleFingerMCPDominantFN_1FNSpatialAngle,
				MiddleFingerMCPDominantF1FNSpatialAngle = middleFingerMCPDominantF1FNSpatialAngle,
				MiddleFingerMCPDominantTotalVectorAngle = middleFingerMCPDominantTotalVectorAngle,
				MiddleFingerMCPDominantSquaredTotalVectorAngle = middleFingerMCPDominantSquaredTotalVectorAngle,
				MiddleFingerMCPDominantTotalVectorDisplacement = middleFingerMCPDominantTotalVectorDisplacement,
				MiddleFingerMCPDominantTotalDisplacement = middleFingerMCPDominantTotalDisplacement,
				MiddleFingerMCPDominantMaximumDisplacement = middleFingerMCPDominantMaximumDisplacement,
				#endregion

				#region MiddleFingerPIPDominant joint features
				MiddleFingerPIPDominantF1F2SpatialAngle = middleFingerPIPDominantF1F2SpatialAngle,
				MiddleFingerPIPDominantFN_1FNSpatialAngle = middleFingerPIPDominantFN_1FNSpatialAngle,
				MiddleFingerPIPDominantF1FNSpatialAngle = middleFingerPIPDominantF1FNSpatialAngle,
				MiddleFingerPIPDominantTotalVectorAngle = middleFingerPIPDominantTotalVectorAngle,
				MiddleFingerPIPDominantSquaredTotalVectorAngle = middleFingerPIPDominantSquaredTotalVectorAngle,
				MiddleFingerPIPDominantTotalVectorDisplacement = middleFingerPIPDominantTotalVectorDisplacement,
				MiddleFingerPIPDominantTotalDisplacement = middleFingerPIPDominantTotalDisplacement,
				MiddleFingerPIPDominantMaximumDisplacement = middleFingerPIPDominantMaximumDisplacement,
				#endregion

				#region MiddleFingerDIPDominant joint features
				MiddleFingerDIPDominantF1F2SpatialAngle = middleFingerDIPDominantF1F2SpatialAngle,
				MiddleFingerDIPDominantFN_1FNSpatialAngle = middleFingerDIPDominantFN_1FNSpatialAngle,
				MiddleFingerDIPDominantF1FNSpatialAngle = middleFingerDIPDominantF1FNSpatialAngle,
				MiddleFingerDIPDominantTotalVectorAngle = middleFingerDIPDominantTotalVectorAngle,
				MiddleFingerDIPDominantSquaredTotalVectorAngle = middleFingerDIPDominantSquaredTotalVectorAngle,
				MiddleFingerDIPDominantTotalVectorDisplacement = middleFingerDIPDominantTotalVectorDisplacement,
				MiddleFingerDIPDominantTotalDisplacement = middleFingerDIPDominantTotalDisplacement,
				MiddleFingerDIPDominantMaximumDisplacement = middleFingerDIPDominantMaximumDisplacement,
				#endregion

				#region MiddleFingerTIPDominant joint features
				MiddleFingerTIPDominantF1F2SpatialAngle = middleFingerTIPDominantF1F2SpatialAngle,
				MiddleFingerTIPDominantFN_1FNSpatialAngle = middleFingerTIPDominantFN_1FNSpatialAngle,
				MiddleFingerTIPDominantF1FNSpatialAngle = middleFingerTIPDominantF1FNSpatialAngle,
				MiddleFingerTIPDominantTotalVectorAngle = middleFingerTIPDominantTotalVectorAngle,
				MiddleFingerTIPDominantSquaredTotalVectorAngle = middleFingerTIPDominantSquaredTotalVectorAngle,
				MiddleFingerTIPDominantTotalVectorDisplacement = middleFingerTIPDominantTotalVectorDisplacement,
				MiddleFingerTIPDominantTotalDisplacement = middleFingerTIPDominantTotalDisplacement,
				MiddleFingerTIPDominantMaximumDisplacement = middleFingerTIPDominantMaximumDisplacement,
				#endregion

				#region RingFingerMCPDominant joint features
				RingFingerMCPDominantF1F2SpatialAngle = ringFingerMCPDominantF1F2SpatialAngle,
				RingFingerMCPDominantFN_1FNSpatialAngle = ringFingerMCPDominantFN_1FNSpatialAngle,
				RingFingerMCPDominantF1FNSpatialAngle = ringFingerMCPDominantF1FNSpatialAngle,
				RingFingerMCPDominantTotalVectorAngle = ringFingerMCPDominantTotalVectorAngle,
				RingFingerMCPDominantSquaredTotalVectorAngle = ringFingerMCPDominantSquaredTotalVectorAngle,
				RingFingerMCPDominantTotalVectorDisplacement = ringFingerMCPDominantTotalVectorDisplacement,
				RingFingerMCPDominantTotalDisplacement = ringFingerMCPDominantTotalDisplacement,
				RingFingerMCPDominantMaximumDisplacement = ringFingerMCPDominantMaximumDisplacement,
				#endregion

				#region RingFingerPIPDominant joint features
				RingFingerPIPDominantF1F2SpatialAngle = ringFingerPIPDominantF1F2SpatialAngle,
				RingFingerPIPDominantFN_1FNSpatialAngle = ringFingerPIPDominantFN_1FNSpatialAngle,
				RingFingerPIPDominantF1FNSpatialAngle = ringFingerPIPDominantF1FNSpatialAngle,
				RingFingerPIPDominantTotalVectorAngle = ringFingerPIPDominantTotalVectorAngle,
				RingFingerPIPDominantSquaredTotalVectorAngle = ringFingerPIPDominantSquaredTotalVectorAngle,
				RingFingerPIPDominantTotalVectorDisplacement = ringFingerPIPDominantTotalVectorDisplacement,
				RingFingerPIPDominantTotalDisplacement = ringFingerPIPDominantTotalDisplacement,
				RingFingerPIPDominantMaximumDisplacement = ringFingerPIPDominantMaximumDisplacement,
				#endregion

				#region RingFingerDIPDominant joint features
				RingFingerDIPDominantF1F2SpatialAngle = ringFingerDIPDominantF1F2SpatialAngle,
				RingFingerDIPDominantFN_1FNSpatialAngle = ringFingerDIPDominantFN_1FNSpatialAngle,
				RingFingerDIPDominantF1FNSpatialAngle = ringFingerDIPDominantF1FNSpatialAngle,
				RingFingerDIPDominantTotalVectorAngle = ringFingerDIPDominantTotalVectorAngle,
				RingFingerDIPDominantSquaredTotalVectorAngle = ringFingerDIPDominantSquaredTotalVectorAngle,
				RingFingerDIPDominantTotalVectorDisplacement = ringFingerDIPDominantTotalVectorDisplacement,
				RingFingerDIPDominantTotalDisplacement = ringFingerDIPDominantTotalDisplacement,
				RingFingerDIPDominantMaximumDisplacement = ringFingerDIPDominantMaximumDisplacement,
				#endregion

				#region RingFingerTIPDominant joint features
				RingFingerTIPDominantF1F2SpatialAngle = ringFingerTIPDominantF1F2SpatialAngle,
				RingFingerTIPDominantFN_1FNSpatialAngle = ringFingerTIPDominantFN_1FNSpatialAngle,
				RingFingerTIPDominantF1FNSpatialAngle = ringFingerTIPDominantF1FNSpatialAngle,
				RingFingerTIPDominantTotalVectorAngle = ringFingerTIPDominantTotalVectorAngle,
				RingFingerTIPDominantSquaredTotalVectorAngle = ringFingerTIPDominantSquaredTotalVectorAngle,
				RingFingerTIPDominantTotalVectorDisplacement = ringFingerTIPDominantTotalVectorDisplacement,
				RingFingerTIPDominantTotalDisplacement = ringFingerTIPDominantTotalDisplacement,
				RingFingerTIPDominantMaximumDisplacement = ringFingerTIPDominantMaximumDisplacement,
				#endregion

				#region PinkyMCPDominant joint features
				PinkyMCPDominantF1F2SpatialAngle = pinkyMCPDominantF1F2SpatialAngle,
				PinkyMCPDominantFN_1FNSpatialAngle = pinkyMCPDominantFN_1FNSpatialAngle,
				PinkyMCPDominantF1FNSpatialAngle = pinkyMCPDominantF1FNSpatialAngle,
				PinkyMCPDominantTotalVectorAngle = pinkyMCPDominantTotalVectorAngle,
				PinkyMCPDominantSquaredTotalVectorAngle = pinkyMCPDominantSquaredTotalVectorAngle,
				PinkyMCPDominantTotalVectorDisplacement = pinkyMCPDominantTotalVectorDisplacement,
				PinkyMCPDominantTotalDisplacement = pinkyMCPDominantTotalDisplacement,
				PinkyMCPDominantMaximumDisplacement = pinkyMCPDominantMaximumDisplacement,
				#endregion

				#region PinkyPIPDominant joint features
				PinkyPIPDominantF1F2SpatialAngle = pinkyPIPDominantF1F2SpatialAngle,
				PinkyPIPDominantFN_1FNSpatialAngle = pinkyPIPDominantFN_1FNSpatialAngle,
				PinkyPIPDominantF1FNSpatialAngle = pinkyPIPDominantF1FNSpatialAngle,
				PinkyPIPDominantTotalVectorAngle = pinkyPIPDominantTotalVectorAngle,
				PinkyPIPDominantSquaredTotalVectorAngle = pinkyPIPDominantSquaredTotalVectorAngle,
				PinkyPIPDominantTotalVectorDisplacement = pinkyPIPDominantTotalVectorDisplacement,
				PinkyPIPDominantTotalDisplacement = pinkyPIPDominantTotalDisplacement,
				PinkyPIPDominantMaximumDisplacement = pinkyPIPDominantMaximumDisplacement,
				#endregion

				#region PinkyDIPDominant joint features
				PinkyDIPDominantF1F2SpatialAngle = pinkyDIPDominantF1F2SpatialAngle,
				PinkyDIPDominantFN_1FNSpatialAngle = pinkyDIPDominantFN_1FNSpatialAngle,
				PinkyDIPDominantF1FNSpatialAngle = pinkyDIPDominantF1FNSpatialAngle,
				PinkyDIPDominantTotalVectorAngle = pinkyDIPDominantTotalVectorAngle,
				PinkyDIPDominantSquaredTotalVectorAngle = pinkyDIPDominantSquaredTotalVectorAngle,
				PinkyDIPDominantTotalVectorDisplacement = pinkyDIPDominantTotalVectorDisplacement,
				PinkyDIPDominantTotalDisplacement = pinkyDIPDominantTotalDisplacement,
				PinkyDIPDominantMaximumDisplacement = pinkyDIPDominantMaximumDisplacement,
				#endregion

				#region PinkyTIPDominant joint features
				PinkyTIPDominantF1F2SpatialAngle = pinkyTIPDominantF1F2SpatialAngle,
				PinkyTIPDominantFN_1FNSpatialAngle = pinkyTIPDominantFN_1FNSpatialAngle,
				PinkyTIPDominantF1FNSpatialAngle = pinkyTIPDominantF1FNSpatialAngle,
				PinkyTIPDominantTotalVectorAngle = pinkyTIPDominantTotalVectorAngle,
				PinkyTIPDominantSquaredTotalVectorAngle = pinkyTIPDominantSquaredTotalVectorAngle,
				PinkyTIPDominantTotalVectorDisplacement = pinkyTIPDominantTotalVectorDisplacement,
				PinkyTIPDominantTotalDisplacement = pinkyTIPDominantTotalDisplacement,
				PinkyTIPDominantMaximumDisplacement = pinkyTIPDominantMaximumDisplacement,
				#endregion

				#region HandDominant joint features
				HandDominantF1F2SpatialAngle = handDominantF1F2SpatialAngle,
				HandDominantFN_1FNSpatialAngle = handDominantFN_1FNSpatialAngle,
				HandDominantF1FNSpatialAngle = handDominantF1FNSpatialAngle,
				HandDominantTotalVectorAngle = handDominantTotalVectorAngle,
				HandDominantSquaredTotalVectorAngle = handDominantSquaredTotalVectorAngle,
				HandDominantTotalVectorDisplacement = handDominantTotalVectorDisplacement,
				HandDominantTotalDisplacement = handDominantTotalDisplacement,
				HandDominantMaximumDisplacement = handDominantMaximumDisplacement,
				HandDominantBoundingBoxDiagonalLength = handDominantBoundingBoxDiagonalLength,
				HandDominantBoundingBoxAngle = handDominantBoundingBoxAngle,
				// HandDominantHandStates = handDominantHandStates
				#endregion

				#region WristNondominant joint features
				WristNondominantF1F2SpatialAngle = wristNondominantF1F2SpatialAngle,
				WristNondominantFN_1FNSpatialAngle = wristNondominantFN_1FNSpatialAngle,
				WristNondominantF1FNSpatialAngle = wristNondominantF1FNSpatialAngle,
				WristNondominantTotalVectorAngle = wristNondominantTotalVectorAngle,
				WristNondominantSquaredTotalVectorAngle = wristNondominantSquaredTotalVectorAngle,
				WristNondominantTotalVectorDisplacement = wristNondominantTotalVectorDisplacement,
				WristNondominantTotalDisplacement = wristNondominantTotalDisplacement,
				WristNondominantMaximumDisplacement = wristNondominantMaximumDisplacement,
				#endregion

				#region ThumbCMCNondominant joint features
				ThumbCMCNondominantF1F2SpatialAngle = thumbCMCNondominantF1F2SpatialAngle,
				ThumbCMCNondominantFN_1FNSpatialAngle = thumbCMCNondominantFN_1FNSpatialAngle,
				ThumbCMCNondominantF1FNSpatialAngle = thumbCMCNondominantF1FNSpatialAngle,
				ThumbCMCNondominantTotalVectorAngle = thumbCMCNondominantTotalVectorAngle,
				ThumbCMCNondominantSquaredTotalVectorAngle = thumbCMCNondominantSquaredTotalVectorAngle,
				ThumbCMCNondominantTotalVectorDisplacement = thumbCMCNondominantTotalVectorDisplacement,
				ThumbCMCNondominantTotalDisplacement = thumbCMCNondominantTotalDisplacement,
				ThumbCMCNondominantMaximumDisplacement = thumbCMCNondominantMaximumDisplacement,
				#endregion

				#region ThumbMCPNondominant joint features
				ThumbMCPNondominantF1F2SpatialAngle = thumbMCPNondominantF1F2SpatialAngle,
				ThumbMCPNondominantFN_1FNSpatialAngle = thumbMCPNondominantFN_1FNSpatialAngle,
				ThumbMCPNondominantF1FNSpatialAngle = thumbMCPNondominantF1FNSpatialAngle,
				ThumbMCPNondominantTotalVectorAngle = thumbMCPNondominantTotalVectorAngle,
				ThumbMCPNondominantSquaredTotalVectorAngle = thumbMCPNondominantSquaredTotalVectorAngle,
				ThumbMCPNondominantTotalVectorDisplacement = thumbMCPNondominantTotalVectorDisplacement,
				ThumbMCPNondominantTotalDisplacement = thumbMCPNondominantTotalDisplacement,
				ThumbMCPNondominantMaximumDisplacement = thumbMCPNondominantMaximumDisplacement,
				#endregion

				#region ThumbIPNondominant joint features
				ThumbIPNondominantF1F2SpatialAngle = thumbIPNondominantF1F2SpatialAngle,
				ThumbIPNondominantFN_1FNSpatialAngle = thumbIPNondominantFN_1FNSpatialAngle,
				ThumbIPNondominantF1FNSpatialAngle = thumbIPNondominantF1FNSpatialAngle,
				ThumbIPNondominantTotalVectorAngle = thumbIPNondominantTotalVectorAngle,
				ThumbIPNondominantSquaredTotalVectorAngle = thumbIPNondominantSquaredTotalVectorAngle,
				ThumbIPNondominantTotalVectorDisplacement = thumbIPNondominantTotalVectorDisplacement,
				ThumbIPNondominantTotalDisplacement = thumbIPNondominantTotalDisplacement,
				ThumbIPNondominantMaximumDisplacement = thumbIPNondominantMaximumDisplacement,
				#endregion

				#region ThumbTIPNondominant joint features
				ThumbTIPNondominantF1F2SpatialAngle = thumbTIPNondominantF1F2SpatialAngle,
				ThumbTIPNondominantFN_1FNSpatialAngle = thumbTIPNondominantFN_1FNSpatialAngle,
				ThumbTIPNondominantF1FNSpatialAngle = thumbTIPNondominantF1FNSpatialAngle,
				ThumbTIPNondominantTotalVectorAngle = thumbTIPNondominantTotalVectorAngle,
				ThumbTIPNondominantSquaredTotalVectorAngle = thumbTIPNondominantSquaredTotalVectorAngle,
				ThumbTIPNondominantTotalVectorDisplacement = thumbTIPNondominantTotalVectorDisplacement,
				ThumbTIPNondominantTotalDisplacement = thumbTIPNondominantTotalDisplacement,
				ThumbTIPNondominantMaximumDisplacement = thumbTIPNondominantMaximumDisplacement,
				#endregion

				#region IndexFingerMCPNondominant joint features
				IndexFingerMCPNondominantF1F2SpatialAngle = indexFingerMCPNondominantF1F2SpatialAngle,
				IndexFingerMCPNondominantFN_1FNSpatialAngle = indexFingerMCPNondominantFN_1FNSpatialAngle,
				IndexFingerMCPNondominantF1FNSpatialAngle = indexFingerMCPNondominantF1FNSpatialAngle,
				IndexFingerMCPNondominantTotalVectorAngle = indexFingerMCPNondominantTotalVectorAngle,
				IndexFingerMCPNondominantSquaredTotalVectorAngle = indexFingerMCPNondominantSquaredTotalVectorAngle,
				IndexFingerMCPNondominantTotalVectorDisplacement = indexFingerMCPNondominantTotalVectorDisplacement,
				IndexFingerMCPNondominantTotalDisplacement = indexFingerMCPNondominantTotalDisplacement,
				IndexFingerMCPNondominantMaximumDisplacement = indexFingerMCPNondominantMaximumDisplacement,
				#endregion

				#region IndexFingerPIPNondominant joint features
				IndexFingerPIPNondominantF1F2SpatialAngle = indexFingerPIPNondominantF1F2SpatialAngle,
				IndexFingerPIPNondominantFN_1FNSpatialAngle = indexFingerPIPNondominantFN_1FNSpatialAngle,
				IndexFingerPIPNondominantF1FNSpatialAngle = indexFingerPIPNondominantF1FNSpatialAngle,
				IndexFingerPIPNondominantTotalVectorAngle = indexFingerPIPNondominantTotalVectorAngle,
				IndexFingerPIPNondominantSquaredTotalVectorAngle = indexFingerPIPNondominantSquaredTotalVectorAngle,
				IndexFingerPIPNondominantTotalVectorDisplacement = indexFingerPIPNondominantTotalVectorDisplacement,
				IndexFingerPIPNondominantTotalDisplacement = indexFingerPIPNondominantTotalDisplacement,
				IndexFingerPIPNondominantMaximumDisplacement = indexFingerPIPNondominantMaximumDisplacement,
				#endregion

				#region IndexFingerDIPNondominant joint features
				IndexFingerDIPNondominantF1F2SpatialAngle = indexFingerDIPNondominantF1F2SpatialAngle,
				IndexFingerDIPNondominantFN_1FNSpatialAngle = indexFingerDIPNondominantFN_1FNSpatialAngle,
				IndexFingerDIPNondominantF1FNSpatialAngle = indexFingerDIPNondominantF1FNSpatialAngle,
				IndexFingerDIPNondominantTotalVectorAngle = indexFingerDIPNondominantTotalVectorAngle,
				IndexFingerDIPNondominantSquaredTotalVectorAngle = indexFingerDIPNondominantSquaredTotalVectorAngle,
				IndexFingerDIPNondominantTotalVectorDisplacement = indexFingerDIPNondominantTotalVectorDisplacement,
				IndexFingerDIPNondominantTotalDisplacement = indexFingerDIPNondominantTotalDisplacement,
				IndexFingerDIPNondominantMaximumDisplacement = indexFingerDIPNondominantMaximumDisplacement,
				#endregion

				#region IndexFingerTIPNondominant joint features
				IndexFingerTIPNondominantF1F2SpatialAngle = indexFingerTIPNondominantF1F2SpatialAngle,
				IndexFingerTIPNondominantFN_1FNSpatialAngle = indexFingerTIPNondominantFN_1FNSpatialAngle,
				IndexFingerTIPNondominantF1FNSpatialAngle = indexFingerTIPNondominantF1FNSpatialAngle,
				IndexFingerTIPNondominantTotalVectorAngle = indexFingerTIPNondominantTotalVectorAngle,
				IndexFingerTIPNondominantSquaredTotalVectorAngle = indexFingerTIPNondominantSquaredTotalVectorAngle,
				IndexFingerTIPNondominantTotalVectorDisplacement = indexFingerTIPNondominantTotalVectorDisplacement,
				IndexFingerTIPNondominantTotalDisplacement = indexFingerTIPNondominantTotalDisplacement,
				IndexFingerTIPNondominantMaximumDisplacement = indexFingerTIPNondominantMaximumDisplacement,
				#endregion

				#region MiddleFingerMCPNondominant joint features
				MiddleFingerMCPNondominantF1F2SpatialAngle = middleFingerMCPNondominantF1F2SpatialAngle,
				MiddleFingerMCPNondominantFN_1FNSpatialAngle = middleFingerMCPNondominantFN_1FNSpatialAngle,
				MiddleFingerMCPNondominantF1FNSpatialAngle = middleFingerMCPNondominantF1FNSpatialAngle,
				MiddleFingerMCPNondominantTotalVectorAngle = middleFingerMCPNondominantTotalVectorAngle,
				MiddleFingerMCPNondominantSquaredTotalVectorAngle = middleFingerMCPNondominantSquaredTotalVectorAngle,
				MiddleFingerMCPNondominantTotalVectorDisplacement = middleFingerMCPNondominantTotalVectorDisplacement,
				MiddleFingerMCPNondominantTotalDisplacement = middleFingerMCPNondominantTotalDisplacement,
				MiddleFingerMCPNondominantMaximumDisplacement = middleFingerMCPNondominantMaximumDisplacement,
				#endregion

				#region MiddleFingerPIPNondominant joint features
				MiddleFingerPIPNondominantF1F2SpatialAngle = middleFingerPIPNondominantF1F2SpatialAngle,
				MiddleFingerPIPNondominantFN_1FNSpatialAngle = middleFingerPIPNondominantFN_1FNSpatialAngle,
				MiddleFingerPIPNondominantF1FNSpatialAngle = middleFingerPIPNondominantF1FNSpatialAngle,
				MiddleFingerPIPNondominantTotalVectorAngle = middleFingerPIPNondominantTotalVectorAngle,
				MiddleFingerPIPNondominantSquaredTotalVectorAngle = middleFingerPIPNondominantSquaredTotalVectorAngle,
				MiddleFingerPIPNondominantTotalVectorDisplacement = middleFingerPIPNondominantTotalVectorDisplacement,
				MiddleFingerPIPNondominantTotalDisplacement = middleFingerPIPNondominantTotalDisplacement,
				MiddleFingerPIPNondominantMaximumDisplacement = middleFingerPIPNondominantMaximumDisplacement,
				#endregion

				#region MiddleFingerDIPNondominant joint features
				MiddleFingerDIPNondominantF1F2SpatialAngle = middleFingerDIPNondominantF1F2SpatialAngle,
				MiddleFingerDIPNondominantFN_1FNSpatialAngle = middleFingerDIPNondominantFN_1FNSpatialAngle,
				MiddleFingerDIPNondominantF1FNSpatialAngle = middleFingerDIPNondominantF1FNSpatialAngle,
				MiddleFingerDIPNondominantTotalVectorAngle = middleFingerDIPNondominantTotalVectorAngle,
				MiddleFingerDIPNondominantSquaredTotalVectorAngle = middleFingerDIPNondominantSquaredTotalVectorAngle,
				MiddleFingerDIPNondominantTotalVectorDisplacement = middleFingerDIPNondominantTotalVectorDisplacement,
				MiddleFingerDIPNondominantTotalDisplacement = middleFingerDIPNondominantTotalDisplacement,
				MiddleFingerDIPNondominantMaximumDisplacement = middleFingerDIPNondominantMaximumDisplacement,
				#endregion

				#region MiddleFingerTIPNondominant joint features
				MiddleFingerTIPNondominantF1F2SpatialAngle = middleFingerTIPNondominantF1F2SpatialAngle,
				MiddleFingerTIPNondominantFN_1FNSpatialAngle = middleFingerTIPNondominantFN_1FNSpatialAngle,
				MiddleFingerTIPNondominantF1FNSpatialAngle = middleFingerTIPNondominantF1FNSpatialAngle,
				MiddleFingerTIPNondominantTotalVectorAngle = middleFingerTIPNondominantTotalVectorAngle,
				MiddleFingerTIPNondominantSquaredTotalVectorAngle = middleFingerTIPNondominantSquaredTotalVectorAngle,
				MiddleFingerTIPNondominantTotalVectorDisplacement = middleFingerTIPNondominantTotalVectorDisplacement,
				MiddleFingerTIPNondominantTotalDisplacement = middleFingerTIPNondominantTotalDisplacement,
				MiddleFingerTIPNondominantMaximumDisplacement = middleFingerTIPNondominantMaximumDisplacement,
				#endregion

				#region RingFingerMCPNondominant joint features
				RingFingerMCPNondominantF1F2SpatialAngle = ringFingerMCPNondominantF1F2SpatialAngle,
				RingFingerMCPNondominantFN_1FNSpatialAngle = ringFingerMCPNondominantFN_1FNSpatialAngle,
				RingFingerMCPNondominantF1FNSpatialAngle = ringFingerMCPNondominantF1FNSpatialAngle,
				RingFingerMCPNondominantTotalVectorAngle = ringFingerMCPNondominantTotalVectorAngle,
				RingFingerMCPNondominantSquaredTotalVectorAngle = ringFingerMCPNondominantSquaredTotalVectorAngle,
				RingFingerMCPNondominantTotalVectorDisplacement = ringFingerMCPNondominantTotalVectorDisplacement,
				RingFingerMCPNondominantTotalDisplacement = ringFingerMCPNondominantTotalDisplacement,
				RingFingerMCPNondominantMaximumDisplacement = ringFingerMCPNondominantMaximumDisplacement,
				#endregion

				#region RingFingerPIPNondominant joint features
				RingFingerPIPNondominantF1F2SpatialAngle = ringFingerPIPNondominantF1F2SpatialAngle,
				RingFingerPIPNondominantFN_1FNSpatialAngle = ringFingerPIPNondominantFN_1FNSpatialAngle,
				RingFingerPIPNondominantF1FNSpatialAngle = ringFingerPIPNondominantF1FNSpatialAngle,
				RingFingerPIPNondominantTotalVectorAngle = ringFingerPIPNondominantTotalVectorAngle,
				RingFingerPIPNondominantSquaredTotalVectorAngle = ringFingerPIPNondominantSquaredTotalVectorAngle,
				RingFingerPIPNondominantTotalVectorDisplacement = ringFingerPIPNondominantTotalVectorDisplacement,
				RingFingerPIPNondominantTotalDisplacement = ringFingerPIPNondominantTotalDisplacement,
				RingFingerPIPNondominantMaximumDisplacement = ringFingerPIPNondominantMaximumDisplacement,
				#endregion

				#region RingFingerDIPNondominant joint features
				RingFingerDIPNondominantF1F2SpatialAngle = ringFingerDIPNondominantF1F2SpatialAngle,
				RingFingerDIPNondominantFN_1FNSpatialAngle = ringFingerDIPNondominantFN_1FNSpatialAngle,
				RingFingerDIPNondominantF1FNSpatialAngle = ringFingerDIPNondominantF1FNSpatialAngle,
				RingFingerDIPNondominantTotalVectorAngle = ringFingerDIPNondominantTotalVectorAngle,
				RingFingerDIPNondominantSquaredTotalVectorAngle = ringFingerDIPNondominantSquaredTotalVectorAngle,
				RingFingerDIPNondominantTotalVectorDisplacement = ringFingerDIPNondominantTotalVectorDisplacement,
				RingFingerDIPNondominantTotalDisplacement = ringFingerDIPNondominantTotalDisplacement,
				RingFingerDIPNondominantMaximumDisplacement = ringFingerDIPNondominantMaximumDisplacement,
				#endregion

				#region RingFingerTIPNondominant joint features
				RingFingerTIPNondominantF1F2SpatialAngle = ringFingerTIPNondominantF1F2SpatialAngle,
				RingFingerTIPNondominantFN_1FNSpatialAngle = ringFingerTIPNondominantFN_1FNSpatialAngle,
				RingFingerTIPNondominantF1FNSpatialAngle = ringFingerTIPNondominantF1FNSpatialAngle,
				RingFingerTIPNondominantTotalVectorAngle = ringFingerTIPNondominantTotalVectorAngle,
				RingFingerTIPNondominantSquaredTotalVectorAngle = ringFingerTIPNondominantSquaredTotalVectorAngle,
				RingFingerTIPNondominantTotalVectorDisplacement = ringFingerTIPNondominantTotalVectorDisplacement,
				RingFingerTIPNondominantTotalDisplacement = ringFingerTIPNondominantTotalDisplacement,
				RingFingerTIPNondominantMaximumDisplacement = ringFingerTIPNondominantMaximumDisplacement,
				#endregion

				#region PinkyMCPNondominant joint features
				PinkyMCPNondominantF1F2SpatialAngle = pinkyMCPNondominantF1F2SpatialAngle,
				PinkyMCPNondominantFN_1FNSpatialAngle = pinkyMCPNondominantFN_1FNSpatialAngle,
				PinkyMCPNondominantF1FNSpatialAngle = pinkyMCPNondominantF1FNSpatialAngle,
				PinkyMCPNondominantTotalVectorAngle = pinkyMCPNondominantTotalVectorAngle,
				PinkyMCPNondominantSquaredTotalVectorAngle = pinkyMCPNondominantSquaredTotalVectorAngle,
				PinkyMCPNondominantTotalVectorDisplacement = pinkyMCPNondominantTotalVectorDisplacement,
				PinkyMCPNondominantTotalDisplacement = pinkyMCPNondominantTotalDisplacement,
				PinkyMCPNondominantMaximumDisplacement = pinkyMCPNondominantMaximumDisplacement,
				#endregion

				#region PinkyPIPNondominant joint features
				PinkyPIPNondominantF1F2SpatialAngle = pinkyPIPNondominantF1F2SpatialAngle,
				PinkyPIPNondominantFN_1FNSpatialAngle = pinkyPIPNondominantFN_1FNSpatialAngle,
				PinkyPIPNondominantF1FNSpatialAngle = pinkyPIPNondominantF1FNSpatialAngle,
				PinkyPIPNondominantTotalVectorAngle = pinkyPIPNondominantTotalVectorAngle,
				PinkyPIPNondominantSquaredTotalVectorAngle = pinkyPIPNondominantSquaredTotalVectorAngle,
				PinkyPIPNondominantTotalVectorDisplacement = pinkyPIPNondominantTotalVectorDisplacement,
				PinkyPIPNondominantTotalDisplacement = pinkyPIPNondominantTotalDisplacement,
				PinkyPIPNondominantMaximumDisplacement = pinkyPIPNondominantMaximumDisplacement,
				#endregion

				#region PinkyDIPNondominant joint features
				PinkyDIPNondominantF1F2SpatialAngle = pinkyDIPNondominantF1F2SpatialAngle,
				PinkyDIPNondominantFN_1FNSpatialAngle = pinkyDIPNondominantFN_1FNSpatialAngle,
				PinkyDIPNondominantF1FNSpatialAngle = pinkyDIPNondominantF1FNSpatialAngle,
				PinkyDIPNondominantTotalVectorAngle = pinkyDIPNondominantTotalVectorAngle,
				PinkyDIPNondominantSquaredTotalVectorAngle = pinkyDIPNondominantSquaredTotalVectorAngle,
				PinkyDIPNondominantTotalVectorDisplacement = pinkyDIPNondominantTotalVectorDisplacement,
				PinkyDIPNondominantTotalDisplacement = pinkyDIPNondominantTotalDisplacement,
				PinkyDIPNondominantMaximumDisplacement = pinkyDIPNondominantMaximumDisplacement,
				#endregion

				#region PinkyTIPNondominant joint features
				PinkyTIPNondominantF1F2SpatialAngle = pinkyTIPNondominantF1F2SpatialAngle,
				PinkyTIPNondominantFN_1FNSpatialAngle = pinkyTIPNondominantFN_1FNSpatialAngle,
				PinkyTIPNondominantF1FNSpatialAngle = pinkyTIPNondominantF1FNSpatialAngle,
				PinkyTIPNondominantTotalVectorAngle = pinkyTIPNondominantTotalVectorAngle,
				PinkyTIPNondominantSquaredTotalVectorAngle = pinkyTIPNondominantSquaredTotalVectorAngle,
				PinkyTIPNondominantTotalVectorDisplacement = pinkyTIPNondominantTotalVectorDisplacement,
				PinkyTIPNondominantTotalDisplacement = pinkyTIPNondominantTotalDisplacement,
				PinkyTIPNondominantMaximumDisplacement = pinkyTIPNondominantMaximumDisplacement,
				#endregion

				#region HandNondominant joint features
				HandNondominantF1F2SpatialAngle = handNondominantF1F2SpatialAngle,
				HandNondominantFN_1FNSpatialAngle = handNondominantFN_1FNSpatialAngle,
				HandNondominantF1FNSpatialAngle = handNondominantF1FNSpatialAngle,
				HandNondominantTotalVectorAngle = handNondominantTotalVectorAngle,
				HandNondominantSquaredTotalVectorAngle = handNondominantSquaredTotalVectorAngle,
				HandNondominantTotalVectorDisplacement = handNondominantTotalVectorDisplacement,
				HandNondominantTotalDisplacement = handNondominantTotalDisplacement,
				HandNondominantMaximumDisplacement = handNondominantMaximumDisplacement,
				HandNondominantBoundingBoxDiagonalLength = handNondominantBoundingBoxDiagonalLength,
				HandNondominantBoundingBoxAngle = handNondominantBoundingBoxAngle,
				// HandNondominantHandStates = handNondominantHandStates
				#endregion

				#region WristThumbCMCDominantBone bone features
				WristThumbCMCDominantBoneInitialAngle = wristThumbCMCDominantBoneInitialAngle,
				WristThumbCMCDominantBoneFinalAngle = wristThumbCMCDominantBoneFinalAngle,
				WristThumbCMCDominantBoneMeanAngle = wristThumbCMCDominantBoneMeanAngle,
				WristThumbCMCDominantBoneMaximumAngle = wristThumbCMCDominantBoneMaximumAngle,
				#endregion

				#region ThumbCMCThumbMCPDominantBone bone features
				ThumbCMCThumbMCPDominantBoneInitialAngle = thumbCMCThumbMCPDominantBoneInitialAngle,
				ThumbCMCThumbMCPDominantBoneFinalAngle = thumbCMCThumbMCPDominantBoneFinalAngle,
				ThumbCMCThumbMCPDominantBoneMeanAngle = thumbCMCThumbMCPDominantBoneMeanAngle,
				ThumbCMCThumbMCPDominantBoneMaximumAngle = thumbCMCThumbMCPDominantBoneMaximumAngle,
				#endregion

				#region ThumbMCPThumbIPDominantBone bone features
				ThumbMCPThumbIPDominantBoneInitialAngle = thumbMCPThumbIPDominantBoneInitialAngle,
				ThumbMCPThumbIPDominantBoneFinalAngle = thumbMCPThumbIPDominantBoneFinalAngle,
				ThumbMCPThumbIPDominantBoneMeanAngle = thumbMCPThumbIPDominantBoneMeanAngle,
				ThumbMCPThumbIPDominantBoneMaximumAngle = thumbMCPThumbIPDominantBoneMaximumAngle,
				#endregion

				#region ThumbIPThumbTIPDominantBone bone features
				ThumbIPThumbTIPDominantBoneInitialAngle = thumbIPThumbTIPDominantBoneInitialAngle,
				ThumbIPThumbTIPDominantBoneFinalAngle = thumbIPThumbTIPDominantBoneFinalAngle,
				ThumbIPThumbTIPDominantBoneMeanAngle = thumbIPThumbTIPDominantBoneMeanAngle,
				ThumbIPThumbTIPDominantBoneMaximumAngle = thumbIPThumbTIPDominantBoneMaximumAngle,
				#endregion

				#region WristIndexFingerMCPDominantBone bone features
				WristIndexFingerMCPDominantBoneInitialAngle = wristIndexFingerMCPDominantBoneInitialAngle,
				WristIndexFingerMCPDominantBoneFinalAngle = wristIndexFingerMCPDominantBoneFinalAngle,
				WristIndexFingerMCPDominantBoneMeanAngle = wristIndexFingerMCPDominantBoneMeanAngle,
				WristIndexFingerMCPDominantBoneMaximumAngle = wristIndexFingerMCPDominantBoneMaximumAngle,
				#endregion

				#region IndexFingerMCPIndexFingerPIPDominantBone bone features
				IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle = indexFingerMCPIndexFingerPIPDominantBoneInitialAngle,
				IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle = indexFingerMCPIndexFingerPIPDominantBoneFinalAngle,
				IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle = indexFingerMCPIndexFingerPIPDominantBoneMeanAngle,
				IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle = indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle,
				#endregion

				#region IndexFingerPIPIndexFingerDIPDominantBone bone features
				IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle = indexFingerPIPIndexFingerDIPDominantBoneInitialAngle,
				IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle = indexFingerPIPIndexFingerDIPDominantBoneFinalAngle,
				IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle = indexFingerPIPIndexFingerDIPDominantBoneMeanAngle,
				IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle = indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle,
				#endregion

				#region IndexFingerDIPIndexFingerTIPDominantBone bone features
				IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle = indexFingerDIPIndexFingerTIPDominantBoneInitialAngle,
				IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle = indexFingerDIPIndexFingerTIPDominantBoneFinalAngle,
				IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle = indexFingerDIPIndexFingerTIPDominantBoneMeanAngle,
				IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle = indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerMCPMiddleFingerPIPDominantBone bone features
				MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle = middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle,
				MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle = middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle,
				MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle = middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle,
				MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle = middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerPIPMiddleFingerDIPDominantBone bone features
				MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle = middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle,
				MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle = middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle,
				MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle = middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle,
				MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle = middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerDIPMiddleFingerTIPDominantBone bone features
				MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle = middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle,
				MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle = middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle,
				MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle = middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle,
				MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle = middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle,
				#endregion

				#region RingFingerMCPRingFingerPIPDominantBone bone features
				RingFingerMCPRingFingerPIPDominantBoneInitialAngle = ringFingerMCPRingFingerPIPDominantBoneInitialAngle,
				RingFingerMCPRingFingerPIPDominantBoneFinalAngle = ringFingerMCPRingFingerPIPDominantBoneFinalAngle,
				RingFingerMCPRingFingerPIPDominantBoneMeanAngle = ringFingerMCPRingFingerPIPDominantBoneMeanAngle,
				RingFingerMCPRingFingerPIPDominantBoneMaximumAngle = ringFingerMCPRingFingerPIPDominantBoneMaximumAngle,
				#endregion

				#region RingFingerPIPRingFingerDIPDominantBone bone features
				RingFingerPIPRingFingerDIPDominantBoneInitialAngle = ringFingerPIPRingFingerDIPDominantBoneInitialAngle,
				RingFingerPIPRingFingerDIPDominantBoneFinalAngle = ringFingerPIPRingFingerDIPDominantBoneFinalAngle,
				RingFingerPIPRingFingerDIPDominantBoneMeanAngle = ringFingerPIPRingFingerDIPDominantBoneMeanAngle,
				RingFingerPIPRingFingerDIPDominantBoneMaximumAngle = ringFingerPIPRingFingerDIPDominantBoneMaximumAngle,
				#endregion

				#region RingFingerDIPRingFingerTIPDominantBone bone features
				RingFingerDIPRingFingerTIPDominantBoneInitialAngle = ringFingerDIPRingFingerTIPDominantBoneInitialAngle,
				RingFingerDIPRingFingerTIPDominantBoneFinalAngle = ringFingerDIPRingFingerTIPDominantBoneFinalAngle,
				RingFingerDIPRingFingerTIPDominantBoneMeanAngle = ringFingerDIPRingFingerTIPDominantBoneMeanAngle,
				RingFingerDIPRingFingerTIPDominantBoneMaximumAngle = ringFingerDIPRingFingerTIPDominantBoneMaximumAngle,
				#endregion

				#region WristPinkyMCPDominantBone bone features
				WristPinkyMCPDominantBoneInitialAngle = wristPinkyMCPDominantBoneInitialAngle,
				WristPinkyMCPDominantBoneFinalAngle = wristPinkyMCPDominantBoneFinalAngle,
				WristPinkyMCPDominantBoneMeanAngle = wristPinkyMCPDominantBoneMeanAngle,
				WristPinkyMCPDominantBoneMaximumAngle = wristPinkyMCPDominantBoneMaximumAngle,
				#endregion

				#region PinkyMCPPinkyPIPDominantBone bone features
				PinkyMCPPinkyPIPDominantBoneInitialAngle = pinkyMCPPinkyPIPDominantBoneInitialAngle,
				PinkyMCPPinkyPIPDominantBoneFinalAngle = pinkyMCPPinkyPIPDominantBoneFinalAngle,
				PinkyMCPPinkyPIPDominantBoneMeanAngle = pinkyMCPPinkyPIPDominantBoneMeanAngle,
				PinkyMCPPinkyPIPDominantBoneMaximumAngle = pinkyMCPPinkyPIPDominantBoneMaximumAngle,
				#endregion

				#region PinkyPIPPinkyDIPDominantBone bone features
				PinkyPIPPinkyDIPDominantBoneInitialAngle = pinkyPIPPinkyDIPDominantBoneInitialAngle,
				PinkyPIPPinkyDIPDominantBoneFinalAngle = pinkyPIPPinkyDIPDominantBoneFinalAngle,
				PinkyPIPPinkyDIPDominantBoneMeanAngle = pinkyPIPPinkyDIPDominantBoneMeanAngle,
				PinkyPIPPinkyDIPDominantBoneMaximumAngle = pinkyPIPPinkyDIPDominantBoneMaximumAngle,
				#endregion

				#region PinkyDIPPinkyTIPDominantBone bone features
				PinkyDIPPinkyTIPDominantBoneInitialAngle = pinkyDIPPinkyTIPDominantBoneInitialAngle,
				PinkyDIPPinkyTIPDominantBoneFinalAngle = pinkyDIPPinkyTIPDominantBoneFinalAngle,
				PinkyDIPPinkyTIPDominantBoneMeanAngle = pinkyDIPPinkyTIPDominantBoneMeanAngle,
				PinkyDIPPinkyTIPDominantBoneMaximumAngle = pinkyDIPPinkyTIPDominantBoneMaximumAngle,
				#endregion

				#region ThumbIPIndexFingerMCPDominantBone bone features
				ThumbIPIndexFingerMCPDominantBoneInitialAngle = thumbIPIndexFingerMCPDominantBoneInitialAngle,
				ThumbIPIndexFingerMCPDominantBoneFinalAngle = thumbIPIndexFingerMCPDominantBoneFinalAngle,
				ThumbIPIndexFingerMCPDominantBoneMeanAngle = thumbIPIndexFingerMCPDominantBoneMeanAngle,
				ThumbIPIndexFingerMCPDominantBoneMaximumAngle = thumbIPIndexFingerMCPDominantBoneMaximumAngle,
				#endregion

				#region IndexFingerMCPMiddleFingerMCPDominantBone bone features
				IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle = indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle,
				IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle = indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle,
				IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle = indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle,
				IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle = indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerMCPRingFingerMCPDominantBone bone features
				MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle = middleFingerMCPRingFingerMCPDominantBoneInitialAngle,
				MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle = middleFingerMCPRingFingerMCPDominantBoneFinalAngle,
				MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle = middleFingerMCPRingFingerMCPDominantBoneMeanAngle,
				MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle = middleFingerMCPRingFingerMCPDominantBoneMaximumAngle,
				#endregion

				#region RingFingerMCPPinkyMCPDominantBone bone features
				RingFingerMCPPinkyMCPDominantBoneInitialAngle = ringFingerMCPPinkyMCPDominantBoneInitialAngle,
				RingFingerMCPPinkyMCPDominantBoneFinalAngle = ringFingerMCPPinkyMCPDominantBoneFinalAngle,
				RingFingerMCPPinkyMCPDominantBoneMeanAngle = ringFingerMCPPinkyMCPDominantBoneMeanAngle,
				RingFingerMCPPinkyMCPDominantBoneMaximumAngle = ringFingerMCPPinkyMCPDominantBoneMaximumAngle,
				#endregion

				#region WristThumbCMCNondominantBone bone features
				WristThumbCMCNondominantBoneInitialAngle = wristThumbCMCNondominantBoneInitialAngle,
				WristThumbCMCNondominantBoneFinalAngle = wristThumbCMCNondominantBoneFinalAngle,
				WristThumbCMCNondominantBoneMeanAngle = wristThumbCMCNondominantBoneMeanAngle,
				WristThumbCMCNondominantBoneMaximumAngle = wristThumbCMCNondominantBoneMaximumAngle,
				#endregion

				#region ThumbCMCThumbMCPNondominantBone bone features
				ThumbCMCThumbMCPNondominantBoneInitialAngle = thumbCMCThumbMCPNondominantBoneInitialAngle,
				ThumbCMCThumbMCPNondominantBoneFinalAngle = thumbCMCThumbMCPNondominantBoneFinalAngle,
				ThumbCMCThumbMCPNondominantBoneMeanAngle = thumbCMCThumbMCPNondominantBoneMeanAngle,
				ThumbCMCThumbMCPNondominantBoneMaximumAngle = thumbCMCThumbMCPNondominantBoneMaximumAngle,
				#endregion

				#region ThumbMCPThumbIPNondominantBone bone features
				ThumbMCPThumbIPNondominantBoneInitialAngle = thumbMCPThumbIPNondominantBoneInitialAngle,
				ThumbMCPThumbIPNondominantBoneFinalAngle = thumbMCPThumbIPNondominantBoneFinalAngle,
				ThumbMCPThumbIPNondominantBoneMeanAngle = thumbMCPThumbIPNondominantBoneMeanAngle,
				ThumbMCPThumbIPNondominantBoneMaximumAngle = thumbMCPThumbIPNondominantBoneMaximumAngle,
				#endregion

				#region ThumbIPThumbTIPNondominantBone bone features
				ThumbIPThumbTIPNondominantBoneInitialAngle = thumbIPThumbTIPNondominantBoneInitialAngle,
				ThumbIPThumbTIPNondominantBoneFinalAngle = thumbIPThumbTIPNondominantBoneFinalAngle,
				ThumbIPThumbTIPNondominantBoneMeanAngle = thumbIPThumbTIPNondominantBoneMeanAngle,
				ThumbIPThumbTIPNondominantBoneMaximumAngle = thumbIPThumbTIPNondominantBoneMaximumAngle,
				#endregion

				#region WristIndexFingerMCPNondominantBone bone features
				WristIndexFingerMCPNondominantBoneInitialAngle = wristIndexFingerMCPNondominantBoneInitialAngle,
				WristIndexFingerMCPNondominantBoneFinalAngle = wristIndexFingerMCPNondominantBoneFinalAngle,
				WristIndexFingerMCPNondominantBoneMeanAngle = wristIndexFingerMCPNondominantBoneMeanAngle,
				WristIndexFingerMCPNondominantBoneMaximumAngle = wristIndexFingerMCPNondominantBoneMaximumAngle,
				#endregion

				#region IndexFingerMCPIndexFingerPIPNondominantBone bone features
				IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle = indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle,
				IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle = indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle,
				IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle = indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle,
				IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle = indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle,
				#endregion

				#region IndexFingerPIPIndexFingerDIPNondominantBone bone features
				IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle = indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle,
				IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle = indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle,
				IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle = indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle,
				IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle = indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle,
				#endregion

				#region IndexFingerDIPIndexFingerTIPNondominantBone bone features
				IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle = indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle,
				IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle = indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle,
				IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle = indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle,
				IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle = indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerMCPMiddleFingerPIPNondominantBone bone features
				MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle = middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle,
				MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle = middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle,
				MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle = middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle,
				MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle = middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerPIPMiddleFingerDIPNondominantBone bone features
				MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle = middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle,
				MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle = middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle,
				MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle = middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle,
				MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle = middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerDIPMiddleFingerTIPNondominantBone bone features
				MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle = middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle,
				MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle = middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle,
				MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle = middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle,
				MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle = middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle,
				#endregion

				#region RingFingerMCPRingFingerPIPNondominantBone bone features
				RingFingerMCPRingFingerPIPNondominantBoneInitialAngle = ringFingerMCPRingFingerPIPNondominantBoneInitialAngle,
				RingFingerMCPRingFingerPIPNondominantBoneFinalAngle = ringFingerMCPRingFingerPIPNondominantBoneFinalAngle,
				RingFingerMCPRingFingerPIPNondominantBoneMeanAngle = ringFingerMCPRingFingerPIPNondominantBoneMeanAngle,
				RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle = ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle,
				#endregion

				#region RingFingerPIPRingFingerDIPNondominantBone bone features
				RingFingerPIPRingFingerDIPNondominantBoneInitialAngle = ringFingerPIPRingFingerDIPNondominantBoneInitialAngle,
				RingFingerPIPRingFingerDIPNondominantBoneFinalAngle = ringFingerPIPRingFingerDIPNondominantBoneFinalAngle,
				RingFingerPIPRingFingerDIPNondominantBoneMeanAngle = ringFingerPIPRingFingerDIPNondominantBoneMeanAngle,
				RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle = ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle,
				#endregion

				#region RingFingerDIPRingFingerTIPNondominantBone bone features
				RingFingerDIPRingFingerTIPNondominantBoneInitialAngle = ringFingerDIPRingFingerTIPNondominantBoneInitialAngle,
				RingFingerDIPRingFingerTIPNondominantBoneFinalAngle = ringFingerDIPRingFingerTIPNondominantBoneFinalAngle,
				RingFingerDIPRingFingerTIPNondominantBoneMeanAngle = ringFingerDIPRingFingerTIPNondominantBoneMeanAngle,
				RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle = ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle,
				#endregion

				#region WristPinkyMCPNondominantBone bone features
				WristPinkyMCPNondominantBoneInitialAngle = wristPinkyMCPNondominantBoneInitialAngle,
				WristPinkyMCPNondominantBoneFinalAngle = wristPinkyMCPNondominantBoneFinalAngle,
				WristPinkyMCPNondominantBoneMeanAngle = wristPinkyMCPNondominantBoneMeanAngle,
				WristPinkyMCPNondominantBoneMaximumAngle = wristPinkyMCPNondominantBoneMaximumAngle,
				#endregion

				#region PinkyMCPPinkyPIPNondominantBone bone features
				PinkyMCPPinkyPIPNondominantBoneInitialAngle = pinkyMCPPinkyPIPNondominantBoneInitialAngle,
				PinkyMCPPinkyPIPNondominantBoneFinalAngle = pinkyMCPPinkyPIPNondominantBoneFinalAngle,
				PinkyMCPPinkyPIPNondominantBoneMeanAngle = pinkyMCPPinkyPIPNondominantBoneMeanAngle,
				PinkyMCPPinkyPIPNondominantBoneMaximumAngle = pinkyMCPPinkyPIPNondominantBoneMaximumAngle,
				#endregion

				#region PinkyPIPPinkyDIPNondominantBone bone features
				PinkyPIPPinkyDIPNondominantBoneInitialAngle = pinkyPIPPinkyDIPNondominantBoneInitialAngle,
				PinkyPIPPinkyDIPNondominantBoneFinalAngle = pinkyPIPPinkyDIPNondominantBoneFinalAngle,
				PinkyPIPPinkyDIPNondominantBoneMeanAngle = pinkyPIPPinkyDIPNondominantBoneMeanAngle,
				PinkyPIPPinkyDIPNondominantBoneMaximumAngle = pinkyPIPPinkyDIPNondominantBoneMaximumAngle,
				#endregion

				#region PinkyDIPPinkyTIPNondominantBone bone features
				PinkyDIPPinkyTIPNondominantBoneInitialAngle = pinkyDIPPinkyTIPNondominantBoneInitialAngle,
				PinkyDIPPinkyTIPNondominantBoneFinalAngle = pinkyDIPPinkyTIPNondominantBoneFinalAngle,
				PinkyDIPPinkyTIPNondominantBoneMeanAngle = pinkyDIPPinkyTIPNondominantBoneMeanAngle,
				PinkyDIPPinkyTIPNondominantBoneMaximumAngle = pinkyDIPPinkyTIPNondominantBoneMaximumAngle,
				#endregion

				#region ThumbIPIndexFingerMCPNondominantBone bone features
				ThumbIPIndexFingerMCPNondominantBoneInitialAngle = thumbIPIndexFingerMCPNondominantBoneInitialAngle,
				ThumbIPIndexFingerMCPNondominantBoneFinalAngle = thumbIPIndexFingerMCPNondominantBoneFinalAngle,
				ThumbIPIndexFingerMCPNondominantBoneMeanAngle = thumbIPIndexFingerMCPNondominantBoneMeanAngle,
				ThumbIPIndexFingerMCPNondominantBoneMaximumAngle = thumbIPIndexFingerMCPNondominantBoneMaximumAngle,
				#endregion

				#region IndexFingerMCPMiddleFingerMCPNondominantBone bone features
				IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle = indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle,
				IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle = indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle,
				IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle = indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle,
				IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle = indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle,
				#endregion

				#region MiddleFingerMCPRingFingerMCPNondominantBone bone features
				MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle = middleFingerMCPRingFingerMCPNondominantBoneInitialAngle,
				MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle = middleFingerMCPRingFingerMCPNondominantBoneFinalAngle,
				MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle = middleFingerMCPRingFingerMCPNondominantBoneMeanAngle,
				MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle = middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle,
				#endregion

				#region RingFingerMCPPinkyMCPNondominantBone bone features
				RingFingerMCPPinkyMCPNondominantBoneInitialAngle = ringFingerMCPPinkyMCPNondominantBoneInitialAngle,
				RingFingerMCPPinkyMCPNondominantBoneFinalAngle = ringFingerMCPPinkyMCPNondominantBoneFinalAngle,
				RingFingerMCPPinkyMCPNondominantBoneMeanAngle = ringFingerMCPPinkyMCPNondominantBoneMeanAngle,
				RingFingerMCPPinkyMCPNondominantBoneMaximumAngle = ringFingerMCPPinkyMCPNondominantBoneMaximumAngle,
				#endregion

				#region Hands distances features
				BetweenHandJointsDistanceMax = betweenHandJointsDistanceMax,
				BetweenHandJointsDistanceMean = betweenHandJointsDistanceMean,
				#endregion

				HandDominance = (int)features.HandDominance,
				Label = label,
			};
		}
		#endregion

		#region MediaPipeHandLandmarksGestureDataView -> (GestureFeatures, string)
		public static (GestureFeatures features, string label) MapFromMediaPipeHandLandmarksGestureDataView(this MediaPipeHandLandmarksGestureDataView gesture)
		{
			if (gesture == null)
				return (null, null);

			var features = new GestureFeatures(MediaPipeHandLandmarksGestureRecognitionDefs.GestureRecognitionJoints, MediaPipeHandLandmarksGestureRecognitionDefs.GestureRecognitionBones);
			features.HandDominance = (HandDominance)gesture.HandDominance;

			#region WristDominant joint features
			double? wristDominantF1F2SpatialAngle = gesture.WristDominantF1F2SpatialAngle;
			double? wristDominantFN_1FNSpatialAngle = gesture.WristDominantFN_1FNSpatialAngle;
			double? wristDominantF1FNSpatialAngle = gesture.WristDominantF1FNSpatialAngle;
			double? wristDominantTotalVectorAngle = gesture.WristDominantTotalVectorAngle;
			double? wristDominantSquaredTotalVectorAngle = gesture.WristDominantSquaredTotalVectorAngle;
			double? wristDominantTotalVectorDisplacement = gesture.WristDominantTotalVectorDisplacement;
			double? wristDominantTotalDisplacement = gesture.WristDominantTotalDisplacement;
			double? wristDominantMaximumDisplacement = gesture.WristDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.WristLeft, JointType.WristRight, features.HandDominance, true), 
				new JointGestureFeatures(wristDominantF1F2SpatialAngle, wristDominantFN_1FNSpatialAngle, wristDominantF1FNSpatialAngle,
				wristDominantTotalVectorAngle, wristDominantSquaredTotalVectorAngle,
				wristDominantTotalVectorDisplacement, wristDominantTotalDisplacement, wristDominantMaximumDisplacement));
			#endregion

			#region ThumbCMCDominant joint features
			double? thumbCMCDominantF1F2SpatialAngle = gesture.ThumbCMCDominantF1F2SpatialAngle;
			double? thumbCMCDominantFN_1FNSpatialAngle = gesture.ThumbCMCDominantFN_1FNSpatialAngle;
			double? thumbCMCDominantF1FNSpatialAngle = gesture.ThumbCMCDominantF1FNSpatialAngle;
			double? thumbCMCDominantTotalVectorAngle = gesture.ThumbCMCDominantTotalVectorAngle;
			double? thumbCMCDominantSquaredTotalVectorAngle = gesture.ThumbCMCDominantSquaredTotalVectorAngle;
			double? thumbCMCDominantTotalVectorDisplacement = gesture.ThumbCMCDominantTotalVectorDisplacement;
			double? thumbCMCDominantTotalDisplacement = gesture.ThumbCMCDominantTotalDisplacement;
			double? thumbCMCDominantMaximumDisplacement = gesture.ThumbCMCDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbCMCLeft, JointType.ThumbCMCRight, features.HandDominance, true),
				new JointGestureFeatures(thumbCMCDominantF1F2SpatialAngle, thumbCMCDominantFN_1FNSpatialAngle, thumbCMCDominantF1FNSpatialAngle,
				thumbCMCDominantTotalVectorAngle, thumbCMCDominantSquaredTotalVectorAngle,
				thumbCMCDominantTotalVectorDisplacement, thumbCMCDominantTotalDisplacement, thumbCMCDominantMaximumDisplacement));
			#endregion

			#region ThumbMCPDominant joint features
			double? thumbMCPDominantF1F2SpatialAngle = gesture.ThumbMCPDominantF1F2SpatialAngle;
			double? thumbMCPDominantFN_1FNSpatialAngle = gesture.ThumbMCPDominantFN_1FNSpatialAngle;
			double? thumbMCPDominantF1FNSpatialAngle = gesture.ThumbMCPDominantF1FNSpatialAngle;
			double? thumbMCPDominantTotalVectorAngle = gesture.ThumbMCPDominantTotalVectorAngle;
			double? thumbMCPDominantSquaredTotalVectorAngle = gesture.ThumbMCPDominantSquaredTotalVectorAngle;
			double? thumbMCPDominantTotalVectorDisplacement = gesture.ThumbMCPDominantTotalVectorDisplacement;
			double? thumbMCPDominantTotalDisplacement = gesture.ThumbMCPDominantTotalDisplacement;
			double? thumbMCPDominantMaximumDisplacement = gesture.ThumbMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbMCPLeft, JointType.ThumbMCPRight, features.HandDominance, true),
				new JointGestureFeatures(thumbMCPDominantF1F2SpatialAngle, thumbMCPDominantFN_1FNSpatialAngle, thumbMCPDominantF1FNSpatialAngle,
				thumbMCPDominantTotalVectorAngle, thumbMCPDominantSquaredTotalVectorAngle,
				thumbMCPDominantTotalVectorDisplacement, thumbMCPDominantTotalDisplacement, thumbMCPDominantMaximumDisplacement));
			#endregion

			#region ThumbIPDominant joint features
			double? thumbIPDominantF1F2SpatialAngle = gesture.ThumbIPDominantF1F2SpatialAngle;
			double? thumbIPDominantFN_1FNSpatialAngle = gesture.ThumbIPDominantFN_1FNSpatialAngle;
			double? thumbIPDominantF1FNSpatialAngle = gesture.ThumbIPDominantF1FNSpatialAngle;
			double? thumbIPDominantTotalVectorAngle = gesture.ThumbIPDominantTotalVectorAngle;
			double? thumbIPDominantSquaredTotalVectorAngle = gesture.ThumbIPDominantSquaredTotalVectorAngle;
			double? thumbIPDominantTotalVectorDisplacement = gesture.ThumbIPDominantTotalVectorDisplacement;
			double? thumbIPDominantTotalDisplacement = gesture.ThumbIPDominantTotalDisplacement;
			double? thumbIPDominantMaximumDisplacement = gesture.ThumbIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbIPLeft, JointType.ThumbIPRight, features.HandDominance, true),
				new JointGestureFeatures(thumbIPDominantF1F2SpatialAngle, thumbIPDominantFN_1FNSpatialAngle, thumbIPDominantF1FNSpatialAngle,
				thumbIPDominantTotalVectorAngle, thumbIPDominantSquaredTotalVectorAngle,
				thumbIPDominantTotalVectorDisplacement, thumbIPDominantTotalDisplacement, thumbIPDominantMaximumDisplacement));
			#endregion

			#region ThumbTIPDominant joint features
			double? thumbTIPDominantF1F2SpatialAngle = gesture.ThumbTIPDominantF1F2SpatialAngle;
			double? thumbTIPDominantFN_1FNSpatialAngle = gesture.ThumbTIPDominantFN_1FNSpatialAngle;
			double? thumbTIPDominantF1FNSpatialAngle = gesture.ThumbTIPDominantF1FNSpatialAngle;
			double? thumbTIPDominantTotalVectorAngle = gesture.ThumbTIPDominantTotalVectorAngle;
			double? thumbTIPDominantSquaredTotalVectorAngle = gesture.ThumbTIPDominantSquaredTotalVectorAngle;
			double? thumbTIPDominantTotalVectorDisplacement = gesture.ThumbTIPDominantTotalVectorDisplacement;
			double? thumbTIPDominantTotalDisplacement = gesture.ThumbTIPDominantTotalDisplacement;
			double? thumbTIPDominantMaximumDisplacement = gesture.ThumbTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbTIPLeft, JointType.ThumbTIPRight, features.HandDominance, true),
				new JointGestureFeatures(thumbTIPDominantF1F2SpatialAngle, thumbTIPDominantFN_1FNSpatialAngle, thumbTIPDominantF1FNSpatialAngle,
				thumbTIPDominantTotalVectorAngle, thumbTIPDominantSquaredTotalVectorAngle,
				thumbTIPDominantTotalVectorDisplacement, thumbTIPDominantTotalDisplacement, thumbTIPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerMCPDominant joint features
			double? indexFingerMCPDominantF1F2SpatialAngle = gesture.IndexFingerMCPDominantF1F2SpatialAngle;
			double? indexFingerMCPDominantFN_1FNSpatialAngle = gesture.IndexFingerMCPDominantFN_1FNSpatialAngle;
			double? indexFingerMCPDominantF1FNSpatialAngle = gesture.IndexFingerMCPDominantF1FNSpatialAngle;
			double? indexFingerMCPDominantTotalVectorAngle = gesture.IndexFingerMCPDominantTotalVectorAngle;
			double? indexFingerMCPDominantSquaredTotalVectorAngle = gesture.IndexFingerMCPDominantSquaredTotalVectorAngle;
			double? indexFingerMCPDominantTotalVectorDisplacement = gesture.IndexFingerMCPDominantTotalVectorDisplacement;
			double? indexFingerMCPDominantTotalDisplacement = gesture.IndexFingerMCPDominantTotalDisplacement;
			double? indexFingerMCPDominantMaximumDisplacement = gesture.IndexFingerMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerMCPDominantF1F2SpatialAngle, indexFingerMCPDominantFN_1FNSpatialAngle, indexFingerMCPDominantF1FNSpatialAngle,
				indexFingerMCPDominantTotalVectorAngle, indexFingerMCPDominantSquaredTotalVectorAngle,
				indexFingerMCPDominantTotalVectorDisplacement, indexFingerMCPDominantTotalDisplacement, indexFingerMCPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerPIPDominant joint features
			double? indexFingerPIPDominantF1F2SpatialAngle = gesture.IndexFingerPIPDominantF1F2SpatialAngle;
			double? indexFingerPIPDominantFN_1FNSpatialAngle = gesture.IndexFingerPIPDominantFN_1FNSpatialAngle;
			double? indexFingerPIPDominantF1FNSpatialAngle = gesture.IndexFingerPIPDominantF1FNSpatialAngle;
			double? indexFingerPIPDominantTotalVectorAngle = gesture.IndexFingerPIPDominantTotalVectorAngle;
			double? indexFingerPIPDominantSquaredTotalVectorAngle = gesture.IndexFingerPIPDominantSquaredTotalVectorAngle;
			double? indexFingerPIPDominantTotalVectorDisplacement = gesture.IndexFingerPIPDominantTotalVectorDisplacement;
			double? indexFingerPIPDominantTotalDisplacement = gesture.IndexFingerPIPDominantTotalDisplacement;
			double? indexFingerPIPDominantMaximumDisplacement = gesture.IndexFingerPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerPIPDominantF1F2SpatialAngle, indexFingerPIPDominantFN_1FNSpatialAngle, indexFingerPIPDominantF1FNSpatialAngle,
				indexFingerPIPDominantTotalVectorAngle, indexFingerPIPDominantSquaredTotalVectorAngle,
				indexFingerPIPDominantTotalVectorDisplacement, indexFingerPIPDominantTotalDisplacement, indexFingerPIPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerDIPDominant joint features
			double? indexFingerDIPDominantF1F2SpatialAngle = gesture.IndexFingerDIPDominantF1F2SpatialAngle;
			double? indexFingerDIPDominantFN_1FNSpatialAngle = gesture.IndexFingerDIPDominantFN_1FNSpatialAngle;
			double? indexFingerDIPDominantF1FNSpatialAngle = gesture.IndexFingerDIPDominantF1FNSpatialAngle;
			double? indexFingerDIPDominantTotalVectorAngle = gesture.IndexFingerDIPDominantTotalVectorAngle;
			double? indexFingerDIPDominantSquaredTotalVectorAngle = gesture.IndexFingerDIPDominantSquaredTotalVectorAngle;
			double? indexFingerDIPDominantTotalVectorDisplacement = gesture.IndexFingerDIPDominantTotalVectorDisplacement;
			double? indexFingerDIPDominantTotalDisplacement = gesture.IndexFingerDIPDominantTotalDisplacement;
			double? indexFingerDIPDominantMaximumDisplacement = gesture.IndexFingerDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerDIPDominantF1F2SpatialAngle, indexFingerDIPDominantFN_1FNSpatialAngle, indexFingerDIPDominantF1FNSpatialAngle,
				indexFingerDIPDominantTotalVectorAngle, indexFingerDIPDominantSquaredTotalVectorAngle,
				indexFingerDIPDominantTotalVectorDisplacement, indexFingerDIPDominantTotalDisplacement, indexFingerDIPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerTIPDominant joint features
			double? indexFingerTIPDominantF1F2SpatialAngle = gesture.IndexFingerTIPDominantF1F2SpatialAngle;
			double? indexFingerTIPDominantFN_1FNSpatialAngle = gesture.IndexFingerTIPDominantFN_1FNSpatialAngle;
			double? indexFingerTIPDominantF1FNSpatialAngle = gesture.IndexFingerTIPDominantF1FNSpatialAngle;
			double? indexFingerTIPDominantTotalVectorAngle = gesture.IndexFingerTIPDominantTotalVectorAngle;
			double? indexFingerTIPDominantSquaredTotalVectorAngle = gesture.IndexFingerTIPDominantSquaredTotalVectorAngle;
			double? indexFingerTIPDominantTotalVectorDisplacement = gesture.IndexFingerTIPDominantTotalVectorDisplacement;
			double? indexFingerTIPDominantTotalDisplacement = gesture.IndexFingerTIPDominantTotalDisplacement;
			double? indexFingerTIPDominantMaximumDisplacement = gesture.IndexFingerTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerTIPDominantF1F2SpatialAngle, indexFingerTIPDominantFN_1FNSpatialAngle, indexFingerTIPDominantF1FNSpatialAngle,
				indexFingerTIPDominantTotalVectorAngle, indexFingerTIPDominantSquaredTotalVectorAngle,
				indexFingerTIPDominantTotalVectorDisplacement, indexFingerTIPDominantTotalDisplacement, indexFingerTIPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerMCPDominant joint features
			double? middleFingerMCPDominantF1F2SpatialAngle = gesture.MiddleFingerMCPDominantF1F2SpatialAngle;
			double? middleFingerMCPDominantFN_1FNSpatialAngle = gesture.MiddleFingerMCPDominantFN_1FNSpatialAngle;
			double? middleFingerMCPDominantF1FNSpatialAngle = gesture.MiddleFingerMCPDominantF1FNSpatialAngle;
			double? middleFingerMCPDominantTotalVectorAngle = gesture.MiddleFingerMCPDominantTotalVectorAngle;
			double? middleFingerMCPDominantSquaredTotalVectorAngle = gesture.MiddleFingerMCPDominantSquaredTotalVectorAngle;
			double? middleFingerMCPDominantTotalVectorDisplacement = gesture.MiddleFingerMCPDominantTotalVectorDisplacement;
			double? middleFingerMCPDominantTotalDisplacement = gesture.MiddleFingerMCPDominantTotalDisplacement;
			double? middleFingerMCPDominantMaximumDisplacement = gesture.MiddleFingerMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerMCPDominantF1F2SpatialAngle, middleFingerMCPDominantFN_1FNSpatialAngle, middleFingerMCPDominantF1FNSpatialAngle,
				middleFingerMCPDominantTotalVectorAngle, middleFingerMCPDominantSquaredTotalVectorAngle,
				middleFingerMCPDominantTotalVectorDisplacement, middleFingerMCPDominantTotalDisplacement, middleFingerMCPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerPIPDominant joint features
			double? middleFingerPIPDominantF1F2SpatialAngle = gesture.MiddleFingerPIPDominantF1F2SpatialAngle;
			double? middleFingerPIPDominantFN_1FNSpatialAngle = gesture.MiddleFingerPIPDominantFN_1FNSpatialAngle;
			double? middleFingerPIPDominantF1FNSpatialAngle = gesture.MiddleFingerPIPDominantF1FNSpatialAngle;
			double? middleFingerPIPDominantTotalVectorAngle = gesture.MiddleFingerPIPDominantTotalVectorAngle;
			double? middleFingerPIPDominantSquaredTotalVectorAngle = gesture.MiddleFingerPIPDominantSquaredTotalVectorAngle;
			double? middleFingerPIPDominantTotalVectorDisplacement = gesture.MiddleFingerPIPDominantTotalVectorDisplacement;
			double? middleFingerPIPDominantTotalDisplacement = gesture.MiddleFingerPIPDominantTotalDisplacement;
			double? middleFingerPIPDominantMaximumDisplacement = gesture.MiddleFingerPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerPIPDominantF1F2SpatialAngle, middleFingerPIPDominantFN_1FNSpatialAngle, middleFingerPIPDominantF1FNSpatialAngle,
				middleFingerPIPDominantTotalVectorAngle, middleFingerPIPDominantSquaredTotalVectorAngle,
				middleFingerPIPDominantTotalVectorDisplacement, middleFingerPIPDominantTotalDisplacement, middleFingerPIPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerDIPDominant joint features
			double? middleFingerDIPDominantF1F2SpatialAngle = gesture.MiddleFingerDIPDominantF1F2SpatialAngle;
			double? middleFingerDIPDominantFN_1FNSpatialAngle = gesture.MiddleFingerDIPDominantFN_1FNSpatialAngle;
			double? middleFingerDIPDominantF1FNSpatialAngle = gesture.MiddleFingerDIPDominantF1FNSpatialAngle;
			double? middleFingerDIPDominantTotalVectorAngle = gesture.MiddleFingerDIPDominantTotalVectorAngle;
			double? middleFingerDIPDominantSquaredTotalVectorAngle = gesture.MiddleFingerDIPDominantSquaredTotalVectorAngle;
			double? middleFingerDIPDominantTotalVectorDisplacement = gesture.MiddleFingerDIPDominantTotalVectorDisplacement;
			double? middleFingerDIPDominantTotalDisplacement = gesture.MiddleFingerDIPDominantTotalDisplacement;
			double? middleFingerDIPDominantMaximumDisplacement = gesture.MiddleFingerDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerDIPDominantF1F2SpatialAngle, middleFingerDIPDominantFN_1FNSpatialAngle, middleFingerDIPDominantF1FNSpatialAngle,
				middleFingerDIPDominantTotalVectorAngle, middleFingerDIPDominantSquaredTotalVectorAngle,
				middleFingerDIPDominantTotalVectorDisplacement, middleFingerDIPDominantTotalDisplacement, middleFingerDIPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerTIPDominant joint features
			double? middleFingerTIPDominantF1F2SpatialAngle = gesture.MiddleFingerTIPDominantF1F2SpatialAngle;
			double? middleFingerTIPDominantFN_1FNSpatialAngle = gesture.MiddleFingerTIPDominantFN_1FNSpatialAngle;
			double? middleFingerTIPDominantF1FNSpatialAngle = gesture.MiddleFingerTIPDominantF1FNSpatialAngle;
			double? middleFingerTIPDominantTotalVectorAngle = gesture.MiddleFingerTIPDominantTotalVectorAngle;
			double? middleFingerTIPDominantSquaredTotalVectorAngle = gesture.MiddleFingerTIPDominantSquaredTotalVectorAngle;
			double? middleFingerTIPDominantTotalVectorDisplacement = gesture.MiddleFingerTIPDominantTotalVectorDisplacement;
			double? middleFingerTIPDominantTotalDisplacement = gesture.MiddleFingerTIPDominantTotalDisplacement;
			double? middleFingerTIPDominantMaximumDisplacement = gesture.MiddleFingerTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerTIPDominantF1F2SpatialAngle, middleFingerTIPDominantFN_1FNSpatialAngle, middleFingerTIPDominantF1FNSpatialAngle,
				middleFingerTIPDominantTotalVectorAngle, middleFingerTIPDominantSquaredTotalVectorAngle,
				middleFingerTIPDominantTotalVectorDisplacement, middleFingerTIPDominantTotalDisplacement, middleFingerTIPDominantMaximumDisplacement));
			#endregion

			#region RingFingerMCPDominant joint features
			double? ringFingerMCPDominantF1F2SpatialAngle = gesture.RingFingerMCPDominantF1F2SpatialAngle;
			double? ringFingerMCPDominantFN_1FNSpatialAngle = gesture.RingFingerMCPDominantFN_1FNSpatialAngle;
			double? ringFingerMCPDominantF1FNSpatialAngle = gesture.RingFingerMCPDominantF1FNSpatialAngle;
			double? ringFingerMCPDominantTotalVectorAngle = gesture.RingFingerMCPDominantTotalVectorAngle;
			double? ringFingerMCPDominantSquaredTotalVectorAngle = gesture.RingFingerMCPDominantSquaredTotalVectorAngle;
			double? ringFingerMCPDominantTotalVectorDisplacement = gesture.RingFingerMCPDominantTotalVectorDisplacement;
			double? ringFingerMCPDominantTotalDisplacement = gesture.RingFingerMCPDominantTotalDisplacement;
			double? ringFingerMCPDominantMaximumDisplacement = gesture.RingFingerMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerMCPDominantF1F2SpatialAngle, ringFingerMCPDominantFN_1FNSpatialAngle, ringFingerMCPDominantF1FNSpatialAngle,
				ringFingerMCPDominantTotalVectorAngle, ringFingerMCPDominantSquaredTotalVectorAngle,
				ringFingerMCPDominantTotalVectorDisplacement, ringFingerMCPDominantTotalDisplacement, ringFingerMCPDominantMaximumDisplacement));
			#endregion

			#region RingFingerPIPDominant joint features
			double? ringFingerPIPDominantF1F2SpatialAngle = gesture.RingFingerPIPDominantF1F2SpatialAngle;
			double? ringFingerPIPDominantFN_1FNSpatialAngle = gesture.RingFingerPIPDominantFN_1FNSpatialAngle;
			double? ringFingerPIPDominantF1FNSpatialAngle = gesture.RingFingerPIPDominantF1FNSpatialAngle;
			double? ringFingerPIPDominantTotalVectorAngle = gesture.RingFingerPIPDominantTotalVectorAngle;
			double? ringFingerPIPDominantSquaredTotalVectorAngle = gesture.RingFingerPIPDominantSquaredTotalVectorAngle;
			double? ringFingerPIPDominantTotalVectorDisplacement = gesture.RingFingerPIPDominantTotalVectorDisplacement;
			double? ringFingerPIPDominantTotalDisplacement = gesture.RingFingerPIPDominantTotalDisplacement;
			double? ringFingerPIPDominantMaximumDisplacement = gesture.RingFingerPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerPIPDominantF1F2SpatialAngle, ringFingerPIPDominantFN_1FNSpatialAngle, ringFingerPIPDominantF1FNSpatialAngle,
				ringFingerPIPDominantTotalVectorAngle, ringFingerPIPDominantSquaredTotalVectorAngle,
				ringFingerPIPDominantTotalVectorDisplacement, ringFingerPIPDominantTotalDisplacement, ringFingerPIPDominantMaximumDisplacement));
			#endregion

			#region RingFingerDIPDominant joint features
			double? ringFingerDIPDominantF1F2SpatialAngle = gesture.RingFingerDIPDominantF1F2SpatialAngle;
			double? ringFingerDIPDominantFN_1FNSpatialAngle = gesture.RingFingerDIPDominantFN_1FNSpatialAngle;
			double? ringFingerDIPDominantF1FNSpatialAngle = gesture.RingFingerDIPDominantF1FNSpatialAngle;
			double? ringFingerDIPDominantTotalVectorAngle = gesture.RingFingerDIPDominantTotalVectorAngle;
			double? ringFingerDIPDominantSquaredTotalVectorAngle = gesture.RingFingerDIPDominantSquaredTotalVectorAngle;
			double? ringFingerDIPDominantTotalVectorDisplacement = gesture.RingFingerDIPDominantTotalVectorDisplacement;
			double? ringFingerDIPDominantTotalDisplacement = gesture.RingFingerDIPDominantTotalDisplacement;
			double? ringFingerDIPDominantMaximumDisplacement = gesture.RingFingerDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerDIPDominantF1F2SpatialAngle, ringFingerDIPDominantFN_1FNSpatialAngle, ringFingerDIPDominantF1FNSpatialAngle,
				ringFingerDIPDominantTotalVectorAngle, ringFingerDIPDominantSquaredTotalVectorAngle,
				ringFingerDIPDominantTotalVectorDisplacement, ringFingerDIPDominantTotalDisplacement, ringFingerDIPDominantMaximumDisplacement));
			#endregion

			#region RingFingerTIPDominant joint features
			double? ringFingerTIPDominantF1F2SpatialAngle = gesture.RingFingerTIPDominantF1F2SpatialAngle;
			double? ringFingerTIPDominantFN_1FNSpatialAngle = gesture.RingFingerTIPDominantFN_1FNSpatialAngle;
			double? ringFingerTIPDominantF1FNSpatialAngle = gesture.RingFingerTIPDominantF1FNSpatialAngle;
			double? ringFingerTIPDominantTotalVectorAngle = gesture.RingFingerTIPDominantTotalVectorAngle;
			double? ringFingerTIPDominantSquaredTotalVectorAngle = gesture.RingFingerTIPDominantSquaredTotalVectorAngle;
			double? ringFingerTIPDominantTotalVectorDisplacement = gesture.RingFingerTIPDominantTotalVectorDisplacement;
			double? ringFingerTIPDominantTotalDisplacement = gesture.RingFingerTIPDominantTotalDisplacement;
			double? ringFingerTIPDominantMaximumDisplacement = gesture.RingFingerTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerTIPDominantF1F2SpatialAngle, ringFingerTIPDominantFN_1FNSpatialAngle, ringFingerTIPDominantF1FNSpatialAngle,
				ringFingerTIPDominantTotalVectorAngle, ringFingerTIPDominantSquaredTotalVectorAngle,
				ringFingerTIPDominantTotalVectorDisplacement, ringFingerTIPDominantTotalDisplacement, ringFingerTIPDominantMaximumDisplacement));
			#endregion

			#region PinkyMCPDominant joint features
			double? pinkyMCPDominantF1F2SpatialAngle = gesture.PinkyMCPDominantF1F2SpatialAngle;
			double? pinkyMCPDominantFN_1FNSpatialAngle = gesture.PinkyMCPDominantFN_1FNSpatialAngle;
			double? pinkyMCPDominantF1FNSpatialAngle = gesture.PinkyMCPDominantF1FNSpatialAngle;
			double? pinkyMCPDominantTotalVectorAngle = gesture.PinkyMCPDominantTotalVectorAngle;
			double? pinkyMCPDominantSquaredTotalVectorAngle = gesture.PinkyMCPDominantSquaredTotalVectorAngle;
			double? pinkyMCPDominantTotalVectorDisplacement = gesture.PinkyMCPDominantTotalVectorDisplacement;
			double? pinkyMCPDominantTotalDisplacement = gesture.PinkyMCPDominantTotalDisplacement;
			double? pinkyMCPDominantMaximumDisplacement = gesture.PinkyMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyMCPLeft, JointType.PinkyMCPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyMCPDominantF1F2SpatialAngle, pinkyMCPDominantFN_1FNSpatialAngle, pinkyMCPDominantF1FNSpatialAngle,
				pinkyMCPDominantTotalVectorAngle, pinkyMCPDominantSquaredTotalVectorAngle,
				pinkyMCPDominantTotalVectorDisplacement, pinkyMCPDominantTotalDisplacement, pinkyMCPDominantMaximumDisplacement));
			#endregion

			#region PinkyPIPDominant joint features
			double? pinkyPIPDominantF1F2SpatialAngle = gesture.PinkyPIPDominantF1F2SpatialAngle;
			double? pinkyPIPDominantFN_1FNSpatialAngle = gesture.PinkyPIPDominantFN_1FNSpatialAngle;
			double? pinkyPIPDominantF1FNSpatialAngle = gesture.PinkyPIPDominantF1FNSpatialAngle;
			double? pinkyPIPDominantTotalVectorAngle = gesture.PinkyPIPDominantTotalVectorAngle;
			double? pinkyPIPDominantSquaredTotalVectorAngle = gesture.PinkyPIPDominantSquaredTotalVectorAngle;
			double? pinkyPIPDominantTotalVectorDisplacement = gesture.PinkyPIPDominantTotalVectorDisplacement;
			double? pinkyPIPDominantTotalDisplacement = gesture.PinkyPIPDominantTotalDisplacement;
			double? pinkyPIPDominantMaximumDisplacement = gesture.PinkyPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyPIPLeft, JointType.PinkyPIPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyPIPDominantF1F2SpatialAngle, pinkyPIPDominantFN_1FNSpatialAngle, pinkyPIPDominantF1FNSpatialAngle,
				pinkyPIPDominantTotalVectorAngle, pinkyPIPDominantSquaredTotalVectorAngle,
				pinkyPIPDominantTotalVectorDisplacement, pinkyPIPDominantTotalDisplacement, pinkyPIPDominantMaximumDisplacement));
			#endregion

			#region PinkyDIPDominant joint features
			double? pinkyDIPDominantF1F2SpatialAngle = gesture.PinkyDIPDominantF1F2SpatialAngle;
			double? pinkyDIPDominantFN_1FNSpatialAngle = gesture.PinkyDIPDominantFN_1FNSpatialAngle;
			double? pinkyDIPDominantF1FNSpatialAngle = gesture.PinkyDIPDominantF1FNSpatialAngle;
			double? pinkyDIPDominantTotalVectorAngle = gesture.PinkyDIPDominantTotalVectorAngle;
			double? pinkyDIPDominantSquaredTotalVectorAngle = gesture.PinkyDIPDominantSquaredTotalVectorAngle;
			double? pinkyDIPDominantTotalVectorDisplacement = gesture.PinkyDIPDominantTotalVectorDisplacement;
			double? pinkyDIPDominantTotalDisplacement = gesture.PinkyDIPDominantTotalDisplacement;
			double? pinkyDIPDominantMaximumDisplacement = gesture.PinkyDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyDIPLeft, JointType.PinkyDIPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyDIPDominantF1F2SpatialAngle, pinkyDIPDominantFN_1FNSpatialAngle, pinkyDIPDominantF1FNSpatialAngle,
				pinkyDIPDominantTotalVectorAngle, pinkyDIPDominantSquaredTotalVectorAngle,
				pinkyDIPDominantTotalVectorDisplacement, pinkyDIPDominantTotalDisplacement, pinkyDIPDominantMaximumDisplacement));
			#endregion

			#region PinkyTIPDominant joint features
			double? pinkyTIPDominantF1F2SpatialAngle = gesture.PinkyTIPDominantF1F2SpatialAngle;
			double? pinkyTIPDominantFN_1FNSpatialAngle = gesture.PinkyTIPDominantFN_1FNSpatialAngle;
			double? pinkyTIPDominantF1FNSpatialAngle = gesture.PinkyTIPDominantF1FNSpatialAngle;
			double? pinkyTIPDominantTotalVectorAngle = gesture.PinkyTIPDominantTotalVectorAngle;
			double? pinkyTIPDominantSquaredTotalVectorAngle = gesture.PinkyTIPDominantSquaredTotalVectorAngle;
			double? pinkyTIPDominantTotalVectorDisplacement = gesture.PinkyTIPDominantTotalVectorDisplacement;
			double? pinkyTIPDominantTotalDisplacement = gesture.PinkyTIPDominantTotalDisplacement;
			double? pinkyTIPDominantMaximumDisplacement = gesture.PinkyTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyTIPLeft, JointType.PinkyTIPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyTIPDominantF1F2SpatialAngle, pinkyTIPDominantFN_1FNSpatialAngle, pinkyTIPDominantF1FNSpatialAngle,
				pinkyTIPDominantTotalVectorAngle, pinkyTIPDominantSquaredTotalVectorAngle,
				pinkyTIPDominantTotalVectorDisplacement, pinkyTIPDominantTotalDisplacement, pinkyTIPDominantMaximumDisplacement));
			#endregion

			#region HandDominant joint features
			double? handDominantF1F2SpatialAngle = gesture.HandDominantF1F2SpatialAngle;
			double? handDominantFN_1FNSpatialAngle = gesture.HandDominantFN_1FNSpatialAngle;
			double? handDominantF1FNSpatialAngle = gesture.HandDominantF1FNSpatialAngle;
			double? handDominantTotalVectorAngle = gesture.HandDominantTotalVectorAngle;
			double? handDominantSquaredTotalVectorAngle = gesture.HandDominantSquaredTotalVectorAngle;
			double? handDominantTotalVectorDisplacement = gesture.HandDominantTotalVectorDisplacement;
			double? handDominantTotalDisplacement = gesture.HandDominantTotalDisplacement;
			double? handDominantMaximumDisplacement = gesture.HandDominantMaximumDisplacement;
			double? handDominantBoundingBoxDiagonalLength = gesture.HandDominantBoundingBoxDiagonalLength;
			double? handDominantBoundingBoxAngle = gesture.HandDominantBoundingBoxAngle;
			//HandState[] handDominantHandStates = gesture.HandDominantHandStates;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.HandLeft, JointType.HandRight, features.HandDominance, true), 
				new HandJointGestureFeatures(handDominantF1F2SpatialAngle, handDominantFN_1FNSpatialAngle, handDominantF1FNSpatialAngle,
				handDominantTotalVectorAngle, handDominantSquaredTotalVectorAngle,
				handDominantTotalVectorDisplacement, handDominantTotalDisplacement, handDominantMaximumDisplacement,
				handDominantBoundingBoxDiagonalLength, handDominantBoundingBoxAngle/*, handDominantHandStates*/));
			#endregion

			#region WristNondominant joint features
			double? wristNondominantF1F2SpatialAngle = gesture.WristNondominantF1F2SpatialAngle;
			double? wristNondominantFN_1FNSpatialAngle = gesture.WristNondominantFN_1FNSpatialAngle;
			double? wristNondominantF1FNSpatialAngle = gesture.WristNondominantF1FNSpatialAngle;
			double? wristNondominantTotalVectorAngle = gesture.WristNondominantTotalVectorAngle;
			double? wristNondominantSquaredTotalVectorAngle = gesture.WristNondominantSquaredTotalVectorAngle;
			double? wristNondominantTotalVectorDisplacement = gesture.WristNondominantTotalVectorDisplacement;
			double? wristNondominantTotalDisplacement = gesture.WristNondominantTotalDisplacement;
			double? wristNondominantMaximumDisplacement = gesture.WristNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.WristLeft, JointType.WristRight, features.HandDominance, false),
				new JointGestureFeatures(wristNondominantF1F2SpatialAngle, wristNondominantFN_1FNSpatialAngle, wristNondominantF1FNSpatialAngle,
				wristNondominantTotalVectorAngle, wristNondominantSquaredTotalVectorAngle,
				wristNondominantTotalVectorDisplacement, wristNondominantTotalDisplacement, wristNondominantMaximumDisplacement));
			#endregion

			#region ThumbCMCNondominant joint features
			double? thumbCMCNondominantF1F2SpatialAngle = gesture.ThumbCMCNondominantF1F2SpatialAngle;
			double? thumbCMCNondominantFN_1FNSpatialAngle = gesture.ThumbCMCNondominantFN_1FNSpatialAngle;
			double? thumbCMCNondominantF1FNSpatialAngle = gesture.ThumbCMCNondominantF1FNSpatialAngle;
			double? thumbCMCNondominantTotalVectorAngle = gesture.ThumbCMCNondominantTotalVectorAngle;
			double? thumbCMCNondominantSquaredTotalVectorAngle = gesture.ThumbCMCNondominantSquaredTotalVectorAngle;
			double? thumbCMCNondominantTotalVectorDisplacement = gesture.ThumbCMCNondominantTotalVectorDisplacement;
			double? thumbCMCNondominantTotalDisplacement = gesture.ThumbCMCNondominantTotalDisplacement;
			double? thumbCMCNondominantMaximumDisplacement = gesture.ThumbCMCNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbCMCLeft, JointType.ThumbCMCRight, features.HandDominance, false),
				new JointGestureFeatures(thumbCMCNondominantF1F2SpatialAngle, thumbCMCNondominantFN_1FNSpatialAngle, thumbCMCNondominantF1FNSpatialAngle,
				thumbCMCNondominantTotalVectorAngle, thumbCMCNondominantSquaredTotalVectorAngle,
				thumbCMCNondominantTotalVectorDisplacement, thumbCMCNondominantTotalDisplacement, thumbCMCNondominantMaximumDisplacement));
			#endregion

			#region ThumbMCPNondominant joint features
			double? thumbMCPNondominantF1F2SpatialAngle = gesture.ThumbMCPNondominantF1F2SpatialAngle;
			double? thumbMCPNondominantFN_1FNSpatialAngle = gesture.ThumbMCPNondominantFN_1FNSpatialAngle;
			double? thumbMCPNondominantF1FNSpatialAngle = gesture.ThumbMCPNondominantF1FNSpatialAngle;
			double? thumbMCPNondominantTotalVectorAngle = gesture.ThumbMCPNondominantTotalVectorAngle;
			double? thumbMCPNondominantSquaredTotalVectorAngle = gesture.ThumbMCPNondominantSquaredTotalVectorAngle;
			double? thumbMCPNondominantTotalVectorDisplacement = gesture.ThumbMCPNondominantTotalVectorDisplacement;
			double? thumbMCPNondominantTotalDisplacement = gesture.ThumbMCPNondominantTotalDisplacement;
			double? thumbMCPNondominantMaximumDisplacement = gesture.ThumbMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbMCPLeft, JointType.ThumbMCPRight, features.HandDominance, false),
				new JointGestureFeatures(thumbMCPNondominantF1F2SpatialAngle, thumbMCPNondominantFN_1FNSpatialAngle, thumbMCPNondominantF1FNSpatialAngle,
				thumbMCPNondominantTotalVectorAngle, thumbMCPNondominantSquaredTotalVectorAngle,
				thumbMCPNondominantTotalVectorDisplacement, thumbMCPNondominantTotalDisplacement, thumbMCPNondominantMaximumDisplacement));
			#endregion

			#region ThumbIPNondominant joint features
			double? thumbIPNondominantF1F2SpatialAngle = gesture.ThumbIPNondominantF1F2SpatialAngle;
			double? thumbIPNondominantFN_1FNSpatialAngle = gesture.ThumbIPNondominantFN_1FNSpatialAngle;
			double? thumbIPNondominantF1FNSpatialAngle = gesture.ThumbIPNondominantF1FNSpatialAngle;
			double? thumbIPNondominantTotalVectorAngle = gesture.ThumbIPNondominantTotalVectorAngle;
			double? thumbIPNondominantSquaredTotalVectorAngle = gesture.ThumbIPNondominantSquaredTotalVectorAngle;
			double? thumbIPNondominantTotalVectorDisplacement = gesture.ThumbIPNondominantTotalVectorDisplacement;
			double? thumbIPNondominantTotalDisplacement = gesture.ThumbIPNondominantTotalDisplacement;
			double? thumbIPNondominantMaximumDisplacement = gesture.ThumbIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbIPLeft, JointType.ThumbIPRight, features.HandDominance, false),
				new JointGestureFeatures(thumbIPNondominantF1F2SpatialAngle, thumbIPNondominantFN_1FNSpatialAngle, thumbIPNondominantF1FNSpatialAngle,
				thumbIPNondominantTotalVectorAngle, thumbIPNondominantSquaredTotalVectorAngle,
				thumbIPNondominantTotalVectorDisplacement, thumbIPNondominantTotalDisplacement, thumbIPNondominantMaximumDisplacement));
			#endregion

			#region ThumbTIPNondominant joint features
			double? thumbTIPNondominantF1F2SpatialAngle = gesture.ThumbTIPNondominantF1F2SpatialAngle;
			double? thumbTIPNondominantFN_1FNSpatialAngle = gesture.ThumbTIPNondominantFN_1FNSpatialAngle;
			double? thumbTIPNondominantF1FNSpatialAngle = gesture.ThumbTIPNondominantF1FNSpatialAngle;
			double? thumbTIPNondominantTotalVectorAngle = gesture.ThumbTIPNondominantTotalVectorAngle;
			double? thumbTIPNondominantSquaredTotalVectorAngle = gesture.ThumbTIPNondominantSquaredTotalVectorAngle;
			double? thumbTIPNondominantTotalVectorDisplacement = gesture.ThumbTIPNondominantTotalVectorDisplacement;
			double? thumbTIPNondominantTotalDisplacement = gesture.ThumbTIPNondominantTotalDisplacement;
			double? thumbTIPNondominantMaximumDisplacement = gesture.ThumbTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbTIPLeft, JointType.ThumbTIPRight, features.HandDominance, false),
				new JointGestureFeatures(thumbTIPNondominantF1F2SpatialAngle, thumbTIPNondominantFN_1FNSpatialAngle, thumbTIPNondominantF1FNSpatialAngle,
				thumbTIPNondominantTotalVectorAngle, thumbTIPNondominantSquaredTotalVectorAngle,
				thumbTIPNondominantTotalVectorDisplacement, thumbTIPNondominantTotalDisplacement, thumbTIPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerMCPNondominant joint features
			double? indexFingerMCPNondominantF1F2SpatialAngle = gesture.IndexFingerMCPNondominantF1F2SpatialAngle;
			double? indexFingerMCPNondominantFN_1FNSpatialAngle = gesture.IndexFingerMCPNondominantFN_1FNSpatialAngle;
			double? indexFingerMCPNondominantF1FNSpatialAngle = gesture.IndexFingerMCPNondominantF1FNSpatialAngle;
			double? indexFingerMCPNondominantTotalVectorAngle = gesture.IndexFingerMCPNondominantTotalVectorAngle;
			double? indexFingerMCPNondominantSquaredTotalVectorAngle = gesture.IndexFingerMCPNondominantSquaredTotalVectorAngle;
			double? indexFingerMCPNondominantTotalVectorDisplacement = gesture.IndexFingerMCPNondominantTotalVectorDisplacement;
			double? indexFingerMCPNondominantTotalDisplacement = gesture.IndexFingerMCPNondominantTotalDisplacement;
			double? indexFingerMCPNondominantMaximumDisplacement = gesture.IndexFingerMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerMCPNondominantF1F2SpatialAngle, indexFingerMCPNondominantFN_1FNSpatialAngle, indexFingerMCPNondominantF1FNSpatialAngle,
				indexFingerMCPNondominantTotalVectorAngle, indexFingerMCPNondominantSquaredTotalVectorAngle,
				indexFingerMCPNondominantTotalVectorDisplacement, indexFingerMCPNondominantTotalDisplacement, indexFingerMCPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerPIPNondominant joint features
			double? indexFingerPIPNondominantF1F2SpatialAngle = gesture.IndexFingerPIPNondominantF1F2SpatialAngle;
			double? indexFingerPIPNondominantFN_1FNSpatialAngle = gesture.IndexFingerPIPNondominantFN_1FNSpatialAngle;
			double? indexFingerPIPNondominantF1FNSpatialAngle = gesture.IndexFingerPIPNondominantF1FNSpatialAngle;
			double? indexFingerPIPNondominantTotalVectorAngle = gesture.IndexFingerPIPNondominantTotalVectorAngle;
			double? indexFingerPIPNondominantSquaredTotalVectorAngle = gesture.IndexFingerPIPNondominantSquaredTotalVectorAngle;
			double? indexFingerPIPNondominantTotalVectorDisplacement = gesture.IndexFingerPIPNondominantTotalVectorDisplacement;
			double? indexFingerPIPNondominantTotalDisplacement = gesture.IndexFingerPIPNondominantTotalDisplacement;
			double? indexFingerPIPNondominantMaximumDisplacement = gesture.IndexFingerPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerPIPNondominantF1F2SpatialAngle, indexFingerPIPNondominantFN_1FNSpatialAngle, indexFingerPIPNondominantF1FNSpatialAngle,
				indexFingerPIPNondominantTotalVectorAngle, indexFingerPIPNondominantSquaredTotalVectorAngle,
				indexFingerPIPNondominantTotalVectorDisplacement, indexFingerPIPNondominantTotalDisplacement, indexFingerPIPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerDIPNondominant joint features
			double? indexFingerDIPNondominantF1F2SpatialAngle = gesture.IndexFingerDIPNondominantF1F2SpatialAngle;
			double? indexFingerDIPNondominantFN_1FNSpatialAngle = gesture.IndexFingerDIPNondominantFN_1FNSpatialAngle;
			double? indexFingerDIPNondominantF1FNSpatialAngle = gesture.IndexFingerDIPNondominantF1FNSpatialAngle;
			double? indexFingerDIPNondominantTotalVectorAngle = gesture.IndexFingerDIPNondominantTotalVectorAngle;
			double? indexFingerDIPNondominantSquaredTotalVectorAngle = gesture.IndexFingerDIPNondominantSquaredTotalVectorAngle;
			double? indexFingerDIPNondominantTotalVectorDisplacement = gesture.IndexFingerDIPNondominantTotalVectorDisplacement;
			double? indexFingerDIPNondominantTotalDisplacement = gesture.IndexFingerDIPNondominantTotalDisplacement;
			double? indexFingerDIPNondominantMaximumDisplacement = gesture.IndexFingerDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerDIPNondominantF1F2SpatialAngle, indexFingerDIPNondominantFN_1FNSpatialAngle, indexFingerDIPNondominantF1FNSpatialAngle,
				indexFingerDIPNondominantTotalVectorAngle, indexFingerDIPNondominantSquaredTotalVectorAngle,
				indexFingerDIPNondominantTotalVectorDisplacement, indexFingerDIPNondominantTotalDisplacement, indexFingerDIPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerTIPNondominant joint features
			double? indexFingerTIPNondominantF1F2SpatialAngle = gesture.IndexFingerTIPNondominantF1F2SpatialAngle;
			double? indexFingerTIPNondominantFN_1FNSpatialAngle = gesture.IndexFingerTIPNondominantFN_1FNSpatialAngle;
			double? indexFingerTIPNondominantF1FNSpatialAngle = gesture.IndexFingerTIPNondominantF1FNSpatialAngle;
			double? indexFingerTIPNondominantTotalVectorAngle = gesture.IndexFingerTIPNondominantTotalVectorAngle;
			double? indexFingerTIPNondominantSquaredTotalVectorAngle = gesture.IndexFingerTIPNondominantSquaredTotalVectorAngle;
			double? indexFingerTIPNondominantTotalVectorDisplacement = gesture.IndexFingerTIPNondominantTotalVectorDisplacement;
			double? indexFingerTIPNondominantTotalDisplacement = gesture.IndexFingerTIPNondominantTotalDisplacement;
			double? indexFingerTIPNondominantMaximumDisplacement = gesture.IndexFingerTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerTIPNondominantF1F2SpatialAngle, indexFingerTIPNondominantFN_1FNSpatialAngle, indexFingerTIPNondominantF1FNSpatialAngle,
				indexFingerTIPNondominantTotalVectorAngle, indexFingerTIPNondominantSquaredTotalVectorAngle,
				indexFingerTIPNondominantTotalVectorDisplacement, indexFingerTIPNondominantTotalDisplacement, indexFingerTIPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerMCPNondominant joint features
			double? middleFingerMCPNondominantF1F2SpatialAngle = gesture.MiddleFingerMCPNondominantF1F2SpatialAngle;
			double? middleFingerMCPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerMCPNondominantFN_1FNSpatialAngle;
			double? middleFingerMCPNondominantF1FNSpatialAngle = gesture.MiddleFingerMCPNondominantF1FNSpatialAngle;
			double? middleFingerMCPNondominantTotalVectorAngle = gesture.MiddleFingerMCPNondominantTotalVectorAngle;
			double? middleFingerMCPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerMCPNondominantSquaredTotalVectorAngle;
			double? middleFingerMCPNondominantTotalVectorDisplacement = gesture.MiddleFingerMCPNondominantTotalVectorDisplacement;
			double? middleFingerMCPNondominantTotalDisplacement = gesture.MiddleFingerMCPNondominantTotalDisplacement;
			double? middleFingerMCPNondominantMaximumDisplacement = gesture.MiddleFingerMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerMCPNondominantF1F2SpatialAngle, middleFingerMCPNondominantFN_1FNSpatialAngle, middleFingerMCPNondominantF1FNSpatialAngle,
				middleFingerMCPNondominantTotalVectorAngle, middleFingerMCPNondominantSquaredTotalVectorAngle,
				middleFingerMCPNondominantTotalVectorDisplacement, middleFingerMCPNondominantTotalDisplacement, middleFingerMCPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerPIPNondominant joint features
			double? middleFingerPIPNondominantF1F2SpatialAngle = gesture.MiddleFingerPIPNondominantF1F2SpatialAngle;
			double? middleFingerPIPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerPIPNondominantFN_1FNSpatialAngle;
			double? middleFingerPIPNondominantF1FNSpatialAngle = gesture.MiddleFingerPIPNondominantF1FNSpatialAngle;
			double? middleFingerPIPNondominantTotalVectorAngle = gesture.MiddleFingerPIPNondominantTotalVectorAngle;
			double? middleFingerPIPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerPIPNondominantSquaredTotalVectorAngle;
			double? middleFingerPIPNondominantTotalVectorDisplacement = gesture.MiddleFingerPIPNondominantTotalVectorDisplacement;
			double? middleFingerPIPNondominantTotalDisplacement = gesture.MiddleFingerPIPNondominantTotalDisplacement;
			double? middleFingerPIPNondominantMaximumDisplacement = gesture.MiddleFingerPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerPIPNondominantF1F2SpatialAngle, middleFingerPIPNondominantFN_1FNSpatialAngle, middleFingerPIPNondominantF1FNSpatialAngle,
				middleFingerPIPNondominantTotalVectorAngle, middleFingerPIPNondominantSquaredTotalVectorAngle,
				middleFingerPIPNondominantTotalVectorDisplacement, middleFingerPIPNondominantTotalDisplacement, middleFingerPIPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerDIPNondominant joint features
			double? middleFingerDIPNondominantF1F2SpatialAngle = gesture.MiddleFingerDIPNondominantF1F2SpatialAngle;
			double? middleFingerDIPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerDIPNondominantFN_1FNSpatialAngle;
			double? middleFingerDIPNondominantF1FNSpatialAngle = gesture.MiddleFingerDIPNondominantF1FNSpatialAngle;
			double? middleFingerDIPNondominantTotalVectorAngle = gesture.MiddleFingerDIPNondominantTotalVectorAngle;
			double? middleFingerDIPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerDIPNondominantSquaredTotalVectorAngle;
			double? middleFingerDIPNondominantTotalVectorDisplacement = gesture.MiddleFingerDIPNondominantTotalVectorDisplacement;
			double? middleFingerDIPNondominantTotalDisplacement = gesture.MiddleFingerDIPNondominantTotalDisplacement;
			double? middleFingerDIPNondominantMaximumDisplacement = gesture.MiddleFingerDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerDIPNondominantF1F2SpatialAngle, middleFingerDIPNondominantFN_1FNSpatialAngle, middleFingerDIPNondominantF1FNSpatialAngle,
				middleFingerDIPNondominantTotalVectorAngle, middleFingerDIPNondominantSquaredTotalVectorAngle,
				middleFingerDIPNondominantTotalVectorDisplacement, middleFingerDIPNondominantTotalDisplacement, middleFingerDIPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerTIPNondominant joint features
			double? middleFingerTIPNondominantF1F2SpatialAngle = gesture.MiddleFingerTIPNondominantF1F2SpatialAngle;
			double? middleFingerTIPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerTIPNondominantFN_1FNSpatialAngle;
			double? middleFingerTIPNondominantF1FNSpatialAngle = gesture.MiddleFingerTIPNondominantF1FNSpatialAngle;
			double? middleFingerTIPNondominantTotalVectorAngle = gesture.MiddleFingerTIPNondominantTotalVectorAngle;
			double? middleFingerTIPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerTIPNondominantSquaredTotalVectorAngle;
			double? middleFingerTIPNondominantTotalVectorDisplacement = gesture.MiddleFingerTIPNondominantTotalVectorDisplacement;
			double? middleFingerTIPNondominantTotalDisplacement = gesture.MiddleFingerTIPNondominantTotalDisplacement;
			double? middleFingerTIPNondominantMaximumDisplacement = gesture.MiddleFingerTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerTIPNondominantF1F2SpatialAngle, middleFingerTIPNondominantFN_1FNSpatialAngle, middleFingerTIPNondominantF1FNSpatialAngle,
				middleFingerTIPNondominantTotalVectorAngle, middleFingerTIPNondominantSquaredTotalVectorAngle,
				middleFingerTIPNondominantTotalVectorDisplacement, middleFingerTIPNondominantTotalDisplacement, middleFingerTIPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerMCPNondominant joint features
			double? ringFingerMCPNondominantF1F2SpatialAngle = gesture.RingFingerMCPNondominantF1F2SpatialAngle;
			double? ringFingerMCPNondominantFN_1FNSpatialAngle = gesture.RingFingerMCPNondominantFN_1FNSpatialAngle;
			double? ringFingerMCPNondominantF1FNSpatialAngle = gesture.RingFingerMCPNondominantF1FNSpatialAngle;
			double? ringFingerMCPNondominantTotalVectorAngle = gesture.RingFingerMCPNondominantTotalVectorAngle;
			double? ringFingerMCPNondominantSquaredTotalVectorAngle = gesture.RingFingerMCPNondominantSquaredTotalVectorAngle;
			double? ringFingerMCPNondominantTotalVectorDisplacement = gesture.RingFingerMCPNondominantTotalVectorDisplacement;
			double? ringFingerMCPNondominantTotalDisplacement = gesture.RingFingerMCPNondominantTotalDisplacement;
			double? ringFingerMCPNondominantMaximumDisplacement = gesture.RingFingerMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerMCPNondominantF1F2SpatialAngle, ringFingerMCPNondominantFN_1FNSpatialAngle, ringFingerMCPNondominantF1FNSpatialAngle,
				ringFingerMCPNondominantTotalVectorAngle, ringFingerMCPNondominantSquaredTotalVectorAngle,
				ringFingerMCPNondominantTotalVectorDisplacement, ringFingerMCPNondominantTotalDisplacement, ringFingerMCPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerPIPNondominant joint features
			double? ringFingerPIPNondominantF1F2SpatialAngle = gesture.RingFingerPIPNondominantF1F2SpatialAngle;
			double? ringFingerPIPNondominantFN_1FNSpatialAngle = gesture.RingFingerPIPNondominantFN_1FNSpatialAngle;
			double? ringFingerPIPNondominantF1FNSpatialAngle = gesture.RingFingerPIPNondominantF1FNSpatialAngle;
			double? ringFingerPIPNondominantTotalVectorAngle = gesture.RingFingerPIPNondominantTotalVectorAngle;
			double? ringFingerPIPNondominantSquaredTotalVectorAngle = gesture.RingFingerPIPNondominantSquaredTotalVectorAngle;
			double? ringFingerPIPNondominantTotalVectorDisplacement = gesture.RingFingerPIPNondominantTotalVectorDisplacement;
			double? ringFingerPIPNondominantTotalDisplacement = gesture.RingFingerPIPNondominantTotalDisplacement;
			double? ringFingerPIPNondominantMaximumDisplacement = gesture.RingFingerPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerPIPNondominantF1F2SpatialAngle, ringFingerPIPNondominantFN_1FNSpatialAngle, ringFingerPIPNondominantF1FNSpatialAngle,
				ringFingerPIPNondominantTotalVectorAngle, ringFingerPIPNondominantSquaredTotalVectorAngle,
				ringFingerPIPNondominantTotalVectorDisplacement, ringFingerPIPNondominantTotalDisplacement, ringFingerPIPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerDIPNondominant joint features
			double? ringFingerDIPNondominantF1F2SpatialAngle = gesture.RingFingerDIPNondominantF1F2SpatialAngle;
			double? ringFingerDIPNondominantFN_1FNSpatialAngle = gesture.RingFingerDIPNondominantFN_1FNSpatialAngle;
			double? ringFingerDIPNondominantF1FNSpatialAngle = gesture.RingFingerDIPNondominantF1FNSpatialAngle;
			double? ringFingerDIPNondominantTotalVectorAngle = gesture.RingFingerDIPNondominantTotalVectorAngle;
			double? ringFingerDIPNondominantSquaredTotalVectorAngle = gesture.RingFingerDIPNondominantSquaredTotalVectorAngle;
			double? ringFingerDIPNondominantTotalVectorDisplacement = gesture.RingFingerDIPNondominantTotalVectorDisplacement;
			double? ringFingerDIPNondominantTotalDisplacement = gesture.RingFingerDIPNondominantTotalDisplacement;
			double? ringFingerDIPNondominantMaximumDisplacement = gesture.RingFingerDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerDIPNondominantF1F2SpatialAngle, ringFingerDIPNondominantFN_1FNSpatialAngle, ringFingerDIPNondominantF1FNSpatialAngle,
				ringFingerDIPNondominantTotalVectorAngle, ringFingerDIPNondominantSquaredTotalVectorAngle,
				ringFingerDIPNondominantTotalVectorDisplacement, ringFingerDIPNondominantTotalDisplacement, ringFingerDIPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerTIPNondominant joint features
			double? ringFingerTIPNondominantF1F2SpatialAngle = gesture.RingFingerTIPNondominantF1F2SpatialAngle;
			double? ringFingerTIPNondominantFN_1FNSpatialAngle = gesture.RingFingerTIPNondominantFN_1FNSpatialAngle;
			double? ringFingerTIPNondominantF1FNSpatialAngle = gesture.RingFingerTIPNondominantF1FNSpatialAngle;
			double? ringFingerTIPNondominantTotalVectorAngle = gesture.RingFingerTIPNondominantTotalVectorAngle;
			double? ringFingerTIPNondominantSquaredTotalVectorAngle = gesture.RingFingerTIPNondominantSquaredTotalVectorAngle;
			double? ringFingerTIPNondominantTotalVectorDisplacement = gesture.RingFingerTIPNondominantTotalVectorDisplacement;
			double? ringFingerTIPNondominantTotalDisplacement = gesture.RingFingerTIPNondominantTotalDisplacement;
			double? ringFingerTIPNondominantMaximumDisplacement = gesture.RingFingerTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerTIPNondominantF1F2SpatialAngle, ringFingerTIPNondominantFN_1FNSpatialAngle, ringFingerTIPNondominantF1FNSpatialAngle,
				ringFingerTIPNondominantTotalVectorAngle, ringFingerTIPNondominantSquaredTotalVectorAngle,
				ringFingerTIPNondominantTotalVectorDisplacement, ringFingerTIPNondominantTotalDisplacement, ringFingerTIPNondominantMaximumDisplacement));
			#endregion

			#region PinkyMCPNondominant joint features
			double? pinkyMCPNondominantF1F2SpatialAngle = gesture.PinkyMCPNondominantF1F2SpatialAngle;
			double? pinkyMCPNondominantFN_1FNSpatialAngle = gesture.PinkyMCPNondominantFN_1FNSpatialAngle;
			double? pinkyMCPNondominantF1FNSpatialAngle = gesture.PinkyMCPNondominantF1FNSpatialAngle;
			double? pinkyMCPNondominantTotalVectorAngle = gesture.PinkyMCPNondominantTotalVectorAngle;
			double? pinkyMCPNondominantSquaredTotalVectorAngle = gesture.PinkyMCPNondominantSquaredTotalVectorAngle;
			double? pinkyMCPNondominantTotalVectorDisplacement = gesture.PinkyMCPNondominantTotalVectorDisplacement;
			double? pinkyMCPNondominantTotalDisplacement = gesture.PinkyMCPNondominantTotalDisplacement;
			double? pinkyMCPNondominantMaximumDisplacement = gesture.PinkyMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyMCPLeft, JointType.PinkyMCPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyMCPNondominantF1F2SpatialAngle, pinkyMCPNondominantFN_1FNSpatialAngle, pinkyMCPNondominantF1FNSpatialAngle,
				pinkyMCPNondominantTotalVectorAngle, pinkyMCPNondominantSquaredTotalVectorAngle,
				pinkyMCPNondominantTotalVectorDisplacement, pinkyMCPNondominantTotalDisplacement, pinkyMCPNondominantMaximumDisplacement));
			#endregion

			#region PinkyPIPNondominant joint features
			double? pinkyPIPNondominantF1F2SpatialAngle = gesture.PinkyPIPNondominantF1F2SpatialAngle;
			double? pinkyPIPNondominantFN_1FNSpatialAngle = gesture.PinkyPIPNondominantFN_1FNSpatialAngle;
			double? pinkyPIPNondominantF1FNSpatialAngle = gesture.PinkyPIPNondominantF1FNSpatialAngle;
			double? pinkyPIPNondominantTotalVectorAngle = gesture.PinkyPIPNondominantTotalVectorAngle;
			double? pinkyPIPNondominantSquaredTotalVectorAngle = gesture.PinkyPIPNondominantSquaredTotalVectorAngle;
			double? pinkyPIPNondominantTotalVectorDisplacement = gesture.PinkyPIPNondominantTotalVectorDisplacement;
			double? pinkyPIPNondominantTotalDisplacement = gesture.PinkyPIPNondominantTotalDisplacement;
			double? pinkyPIPNondominantMaximumDisplacement = gesture.PinkyPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyPIPLeft, JointType.PinkyPIPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyPIPNondominantF1F2SpatialAngle, pinkyPIPNondominantFN_1FNSpatialAngle, pinkyPIPNondominantF1FNSpatialAngle,
				pinkyPIPNondominantTotalVectorAngle, pinkyPIPNondominantSquaredTotalVectorAngle,
				pinkyPIPNondominantTotalVectorDisplacement, pinkyPIPNondominantTotalDisplacement, pinkyPIPNondominantMaximumDisplacement));
			#endregion

			#region PinkyDIPNondominant joint features
			double? pinkyDIPNondominantF1F2SpatialAngle = gesture.PinkyDIPNondominantF1F2SpatialAngle;
			double? pinkyDIPNondominantFN_1FNSpatialAngle = gesture.PinkyDIPNondominantFN_1FNSpatialAngle;
			double? pinkyDIPNondominantF1FNSpatialAngle = gesture.PinkyDIPNondominantF1FNSpatialAngle;
			double? pinkyDIPNondominantTotalVectorAngle = gesture.PinkyDIPNondominantTotalVectorAngle;
			double? pinkyDIPNondominantSquaredTotalVectorAngle = gesture.PinkyDIPNondominantSquaredTotalVectorAngle;
			double? pinkyDIPNondominantTotalVectorDisplacement = gesture.PinkyDIPNondominantTotalVectorDisplacement;
			double? pinkyDIPNondominantTotalDisplacement = gesture.PinkyDIPNondominantTotalDisplacement;
			double? pinkyDIPNondominantMaximumDisplacement = gesture.PinkyDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyDIPLeft, JointType.PinkyDIPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyDIPNondominantF1F2SpatialAngle, pinkyDIPNondominantFN_1FNSpatialAngle, pinkyDIPNondominantF1FNSpatialAngle,
				pinkyDIPNondominantTotalVectorAngle, pinkyDIPNondominantSquaredTotalVectorAngle,
				pinkyDIPNondominantTotalVectorDisplacement, pinkyDIPNondominantTotalDisplacement, pinkyDIPNondominantMaximumDisplacement));
			#endregion

			#region PinkyTIPNondominant joint features
			double? pinkyTIPNondominantF1F2SpatialAngle = gesture.PinkyTIPNondominantF1F2SpatialAngle;
			double? pinkyTIPNondominantFN_1FNSpatialAngle = gesture.PinkyTIPNondominantFN_1FNSpatialAngle;
			double? pinkyTIPNondominantF1FNSpatialAngle = gesture.PinkyTIPNondominantF1FNSpatialAngle;
			double? pinkyTIPNondominantTotalVectorAngle = gesture.PinkyTIPNondominantTotalVectorAngle;
			double? pinkyTIPNondominantSquaredTotalVectorAngle = gesture.PinkyTIPNondominantSquaredTotalVectorAngle;
			double? pinkyTIPNondominantTotalVectorDisplacement = gesture.PinkyTIPNondominantTotalVectorDisplacement;
			double? pinkyTIPNondominantTotalDisplacement = gesture.PinkyTIPNondominantTotalDisplacement;
			double? pinkyTIPNondominantMaximumDisplacement = gesture.PinkyTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyTIPLeft, JointType.PinkyTIPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyTIPNondominantF1F2SpatialAngle, pinkyTIPNondominantFN_1FNSpatialAngle, pinkyTIPNondominantF1FNSpatialAngle,
				pinkyTIPNondominantTotalVectorAngle, pinkyTIPNondominantSquaredTotalVectorAngle,
				pinkyTIPNondominantTotalVectorDisplacement, pinkyTIPNondominantTotalDisplacement, pinkyTIPNondominantMaximumDisplacement));
			#endregion

			#region HandNondominant joint features
			double? handNondominantF1F2SpatialAngle = gesture.HandNondominantF1F2SpatialAngle;
			double? handNondominantFN_1FNSpatialAngle = gesture.HandNondominantFN_1FNSpatialAngle;
			double? handNondominantF1FNSpatialAngle = gesture.HandNondominantF1FNSpatialAngle;
			double? handNondominantTotalVectorAngle = gesture.HandNondominantTotalVectorAngle;
			double? handNondominantSquaredTotalVectorAngle = gesture.HandNondominantSquaredTotalVectorAngle;
			double? handNondominantTotalVectorDisplacement = gesture.HandNondominantTotalVectorDisplacement;
			double? handNondominantTotalDisplacement = gesture.HandNondominantTotalDisplacement;
			double? handNondominantMaximumDisplacement = gesture.HandNondominantMaximumDisplacement;
			double? handNondominantBoundingBoxDiagonalLength = gesture.HandNondominantBoundingBoxDiagonalLength;
			double? handNondominantBoundingBoxAngle = gesture.HandNondominantBoundingBoxAngle;
			//HandState[] handNondominantHandStates = gesture.HandNondominantHandStates;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.HandLeft, JointType.HandRight, features.HandDominance, false),
				new HandJointGestureFeatures(handNondominantF1F2SpatialAngle, handNondominantFN_1FNSpatialAngle, handNondominantF1FNSpatialAngle,
				handNondominantTotalVectorAngle, handNondominantSquaredTotalVectorAngle,
				handNondominantTotalVectorDisplacement, handNondominantTotalDisplacement, handNondominantMaximumDisplacement,
				handNondominantBoundingBoxDiagonalLength, handNondominantBoundingBoxAngle/*, handNondominantHandStates*/));
			#endregion

			#region WristThumbCMCDominant bone features
			double? wristThumbCMCDominantBoneInitialAngle = gesture.WristThumbCMCDominantBoneInitialAngle;
			double? wristThumbCMCDominantBoneFinalAngle = gesture.WristThumbCMCDominantBoneFinalAngle;
			double? wristThumbCMCDominantBoneMeanAngle = gesture.WristThumbCMCDominantBoneMeanAngle;
			double? wristThumbCMCDominantBoneMaximumAngle = gesture.WristThumbCMCDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristThumbCMCLeftBone, MediaPipeHandLandmarksBonesDefs.WristThumbCMCRightBone,
				features.HandDominance, true), new BoneJointsAngleData(wristThumbCMCDominantBoneInitialAngle, wristThumbCMCDominantBoneFinalAngle,
				wristThumbCMCDominantBoneMeanAngle, wristThumbCMCDominantBoneMaximumAngle));
			#endregion

			#region ThumbCMCThumbMCPDominant bone features
			double? thumbCMCThumbMCPDominantBoneInitialAngle = gesture.ThumbCMCThumbMCPDominantBoneInitialAngle;
			double? thumbCMCThumbMCPDominantBoneFinalAngle = gesture.ThumbCMCThumbMCPDominantBoneFinalAngle;
			double? thumbCMCThumbMCPDominantBoneMeanAngle = gesture.ThumbCMCThumbMCPDominantBoneMeanAngle;
			double? thumbCMCThumbMCPDominantBoneMaximumAngle = gesture.ThumbCMCThumbMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbCMCThumbMCPDominantBoneInitialAngle, thumbCMCThumbMCPDominantBoneFinalAngle,
				thumbCMCThumbMCPDominantBoneMeanAngle, thumbCMCThumbMCPDominantBoneMaximumAngle));
			#endregion

			#region ThumbMCPThumbIPDominant bone features
			double? thumbMCPThumbIPDominantBoneInitialAngle = gesture.ThumbMCPThumbIPDominantBoneInitialAngle;
			double? thumbMCPThumbIPDominantBoneFinalAngle = gesture.ThumbMCPThumbIPDominantBoneFinalAngle;
			double? thumbMCPThumbIPDominantBoneMeanAngle = gesture.ThumbMCPThumbIPDominantBoneMeanAngle;
			double? thumbMCPThumbIPDominantBoneMaximumAngle = gesture.ThumbMCPThumbIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbMCPThumbIPDominantBoneInitialAngle, thumbMCPThumbIPDominantBoneFinalAngle,
				thumbMCPThumbIPDominantBoneMeanAngle, thumbMCPThumbIPDominantBoneMaximumAngle));
			#endregion

			#region ThumbIPThumbTIPDominant bone features
			double? thumbIPThumbTIPDominantBoneInitialAngle = gesture.ThumbIPThumbTIPDominantBoneInitialAngle;
			double? thumbIPThumbTIPDominantBoneFinalAngle = gesture.ThumbIPThumbTIPDominantBoneFinalAngle;
			double? thumbIPThumbTIPDominantBoneMeanAngle = gesture.ThumbIPThumbTIPDominantBoneMeanAngle;
			double? thumbIPThumbTIPDominantBoneMaximumAngle = gesture.ThumbIPThumbTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbIPThumbTIPDominantBoneInitialAngle, thumbIPThumbTIPDominantBoneFinalAngle,
				thumbIPThumbTIPDominantBoneMeanAngle, thumbIPThumbTIPDominantBoneMaximumAngle));
			#endregion

			#region WristIndexFingerMCPDominant bone features
			double? wristIndexFingerMCPDominantBoneInitialAngle = gesture.WristIndexFingerMCPDominantBoneInitialAngle;
			double? wristIndexFingerMCPDominantBoneFinalAngle = gesture.WristIndexFingerMCPDominantBoneFinalAngle;
			double? wristIndexFingerMCPDominantBoneMeanAngle = gesture.WristIndexFingerMCPDominantBoneMeanAngle;
			double? wristIndexFingerMCPDominantBoneMaximumAngle = gesture.WristIndexFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(wristIndexFingerMCPDominantBoneInitialAngle, wristIndexFingerMCPDominantBoneFinalAngle,
				wristIndexFingerMCPDominantBoneMeanAngle, wristIndexFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPIndexFingerPIPDominant bone features
			double? indexFingerMCPIndexFingerPIPDominantBoneInitialAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle;
			double? indexFingerMCPIndexFingerPIPDominantBoneFinalAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle;
			double? indexFingerMCPIndexFingerPIPDominantBoneMeanAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle;
			double? indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerMCPIndexFingerPIPDominantBoneInitialAngle, indexFingerMCPIndexFingerPIPDominantBoneFinalAngle,
				indexFingerMCPIndexFingerPIPDominantBoneMeanAngle, indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerPIPIndexFingerDIPDominant bone features
			double? indexFingerPIPIndexFingerDIPDominantBoneInitialAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle;
			double? indexFingerPIPIndexFingerDIPDominantBoneFinalAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle;
			double? indexFingerPIPIndexFingerDIPDominantBoneMeanAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle;
			double? indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerPIPIndexFingerDIPDominantBoneInitialAngle, indexFingerPIPIndexFingerDIPDominantBoneFinalAngle,
				indexFingerPIPIndexFingerDIPDominantBoneMeanAngle, indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerDIPIndexFingerTIPDominant bone features
			double? indexFingerDIPIndexFingerTIPDominantBoneInitialAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle;
			double? indexFingerDIPIndexFingerTIPDominantBoneFinalAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle;
			double? indexFingerDIPIndexFingerTIPDominantBoneMeanAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle;
			double? indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerDIPIndexFingerTIPDominantBoneInitialAngle, indexFingerDIPIndexFingerTIPDominantBoneFinalAngle,
				indexFingerDIPIndexFingerTIPDominantBoneMeanAngle, indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPDominant bone features
			double? middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle;
			double? middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle;
			double? middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle;
			double? middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle, middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle,
				middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle, middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPDominant bone features
			double? middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle;
			double? middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle;
			double? middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle;
			double? middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle, middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle,
				middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle, middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPDominant bone features
			double? middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle;
			double? middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle;
			double? middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle;
			double? middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle, middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle,
				middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle, middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPRingFingerPIPDominant bone features
			double? ringFingerMCPRingFingerPIPDominantBoneInitialAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneInitialAngle;
			double? ringFingerMCPRingFingerPIPDominantBoneFinalAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneFinalAngle;
			double? ringFingerMCPRingFingerPIPDominantBoneMeanAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneMeanAngle;
			double? ringFingerMCPRingFingerPIPDominantBoneMaximumAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerMCPRingFingerPIPDominantBoneInitialAngle, ringFingerMCPRingFingerPIPDominantBoneFinalAngle,
				ringFingerMCPRingFingerPIPDominantBoneMeanAngle, ringFingerMCPRingFingerPIPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerPIPRingFingerDIPDominant bone features
			double? ringFingerPIPRingFingerDIPDominantBoneInitialAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneInitialAngle;
			double? ringFingerPIPRingFingerDIPDominantBoneFinalAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneFinalAngle;
			double? ringFingerPIPRingFingerDIPDominantBoneMeanAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneMeanAngle;
			double? ringFingerPIPRingFingerDIPDominantBoneMaximumAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerPIPRingFingerDIPDominantBoneInitialAngle, ringFingerPIPRingFingerDIPDominantBoneFinalAngle,
				ringFingerPIPRingFingerDIPDominantBoneMeanAngle, ringFingerPIPRingFingerDIPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerDIPRingFingerTIPDominant bone features
			double? ringFingerDIPRingFingerTIPDominantBoneInitialAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneInitialAngle;
			double? ringFingerDIPRingFingerTIPDominantBoneFinalAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneFinalAngle;
			double? ringFingerDIPRingFingerTIPDominantBoneMeanAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneMeanAngle;
			double? ringFingerDIPRingFingerTIPDominantBoneMaximumAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerDIPRingFingerTIPDominantBoneInitialAngle, ringFingerDIPRingFingerTIPDominantBoneFinalAngle,
				ringFingerDIPRingFingerTIPDominantBoneMeanAngle, ringFingerDIPRingFingerTIPDominantBoneMaximumAngle));
			#endregion

			#region WristPinkyMCPDominant bone features
			double? wristPinkyMCPDominantBoneInitialAngle = gesture.WristPinkyMCPDominantBoneInitialAngle;
			double? wristPinkyMCPDominantBoneFinalAngle = gesture.WristPinkyMCPDominantBoneFinalAngle;
			double? wristPinkyMCPDominantBoneMeanAngle = gesture.WristPinkyMCPDominantBoneMeanAngle;
			double? wristPinkyMCPDominantBoneMaximumAngle = gesture.WristPinkyMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristPinkyMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(wristPinkyMCPDominantBoneInitialAngle, wristPinkyMCPDominantBoneFinalAngle,
				wristPinkyMCPDominantBoneMeanAngle, wristPinkyMCPDominantBoneMaximumAngle));
			#endregion

			#region PinkyMCPPinkyPIPDominant bone features
			double? pinkyMCPPinkyPIPDominantBoneInitialAngle = gesture.PinkyMCPPinkyPIPDominantBoneInitialAngle;
			double? pinkyMCPPinkyPIPDominantBoneFinalAngle = gesture.PinkyMCPPinkyPIPDominantBoneFinalAngle;
			double? pinkyMCPPinkyPIPDominantBoneMeanAngle = gesture.PinkyMCPPinkyPIPDominantBoneMeanAngle;
			double? pinkyMCPPinkyPIPDominantBoneMaximumAngle = gesture.PinkyMCPPinkyPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(pinkyMCPPinkyPIPDominantBoneInitialAngle, pinkyMCPPinkyPIPDominantBoneFinalAngle,
				pinkyMCPPinkyPIPDominantBoneMeanAngle, pinkyMCPPinkyPIPDominantBoneMaximumAngle));
			#endregion

			#region PinkyPIPPinkyDIPDominant bone features
			double? pinkyPIPPinkyDIPDominantBoneInitialAngle = gesture.PinkyPIPPinkyDIPDominantBoneInitialAngle;
			double? pinkyPIPPinkyDIPDominantBoneFinalAngle = gesture.PinkyPIPPinkyDIPDominantBoneFinalAngle;
			double? pinkyPIPPinkyDIPDominantBoneMeanAngle = gesture.PinkyPIPPinkyDIPDominantBoneMeanAngle;
			double? pinkyPIPPinkyDIPDominantBoneMaximumAngle = gesture.PinkyPIPPinkyDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(pinkyPIPPinkyDIPDominantBoneInitialAngle, pinkyPIPPinkyDIPDominantBoneFinalAngle,
				pinkyPIPPinkyDIPDominantBoneMeanAngle, pinkyPIPPinkyDIPDominantBoneMaximumAngle));
			#endregion

			#region PinkyDIPPinkyTIPDominant bone features
			double? pinkyDIPPinkyTIPDominantBoneInitialAngle = gesture.PinkyDIPPinkyTIPDominantBoneInitialAngle;
			double? pinkyDIPPinkyTIPDominantBoneFinalAngle = gesture.PinkyDIPPinkyTIPDominantBoneFinalAngle;
			double? pinkyDIPPinkyTIPDominantBoneMeanAngle = gesture.PinkyDIPPinkyTIPDominantBoneMeanAngle;
			double? pinkyDIPPinkyTIPDominantBoneMaximumAngle = gesture.PinkyDIPPinkyTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(pinkyDIPPinkyTIPDominantBoneInitialAngle, pinkyDIPPinkyTIPDominantBoneFinalAngle,
				pinkyDIPPinkyTIPDominantBoneMeanAngle, pinkyDIPPinkyTIPDominantBoneMaximumAngle));
			#endregion

			#region ThumbIPIndexFingerMCPDominant bone features
			double? thumbIPIndexFingerMCPDominantBoneInitialAngle = gesture.ThumbIPIndexFingerMCPDominantBoneInitialAngle;
			double? thumbIPIndexFingerMCPDominantBoneFinalAngle = gesture.ThumbIPIndexFingerMCPDominantBoneFinalAngle;
			double? thumbIPIndexFingerMCPDominantBoneMeanAngle = gesture.ThumbIPIndexFingerMCPDominantBoneMeanAngle;
			double? thumbIPIndexFingerMCPDominantBoneMaximumAngle = gesture.ThumbIPIndexFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbIPIndexFingerMCPDominantBoneInitialAngle, thumbIPIndexFingerMCPDominantBoneFinalAngle,
				thumbIPIndexFingerMCPDominantBoneMeanAngle, thumbIPIndexFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominant bone features
			double? indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle;
			double? indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle;
			double? indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle;
			double? indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle, indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle,
				indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle, indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPRingFingerMCPDominant bone features
			double? middleFingerMCPRingFingerMCPDominantBoneInitialAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle;
			double? middleFingerMCPRingFingerMCPDominantBoneFinalAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle;
			double? middleFingerMCPRingFingerMCPDominantBoneMeanAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle;
			double? middleFingerMCPRingFingerMCPDominantBoneMaximumAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerMCPRingFingerMCPDominantBoneInitialAngle, middleFingerMCPRingFingerMCPDominantBoneFinalAngle,
				middleFingerMCPRingFingerMCPDominantBoneMeanAngle, middleFingerMCPRingFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPPinkyMCPDominant bone features
			double? ringFingerMCPPinkyMCPDominantBoneInitialAngle = gesture.RingFingerMCPPinkyMCPDominantBoneInitialAngle;
			double? ringFingerMCPPinkyMCPDominantBoneFinalAngle = gesture.RingFingerMCPPinkyMCPDominantBoneFinalAngle;
			double? ringFingerMCPPinkyMCPDominantBoneMeanAngle = gesture.RingFingerMCPPinkyMCPDominantBoneMeanAngle;
			double? ringFingerMCPPinkyMCPDominantBoneMaximumAngle = gesture.RingFingerMCPPinkyMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerMCPPinkyMCPDominantBoneInitialAngle, ringFingerMCPPinkyMCPDominantBoneFinalAngle,
				ringFingerMCPPinkyMCPDominantBoneMeanAngle, ringFingerMCPPinkyMCPDominantBoneMaximumAngle));
			#endregion

			#region WristThumbCMCNondominant bone features
			double? wristThumbCMCNondominantBoneInitialAngle = gesture.WristThumbCMCNondominantBoneInitialAngle;
			double? wristThumbCMCNondominantBoneFinalAngle = gesture.WristThumbCMCNondominantBoneFinalAngle;
			double? wristThumbCMCNondominantBoneMeanAngle = gesture.WristThumbCMCNondominantBoneMeanAngle;
			double? wristThumbCMCNondominantBoneMaximumAngle = gesture.WristThumbCMCNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristThumbCMCLeftBone, MediaPipeHandLandmarksBonesDefs.WristThumbCMCRightBone,
				features.HandDominance, false), new BoneJointsAngleData(wristThumbCMCNondominantBoneInitialAngle, wristThumbCMCNondominantBoneFinalAngle,
				wristThumbCMCNondominantBoneMeanAngle, wristThumbCMCNondominantBoneMaximumAngle));
			#endregion

			#region ThumbCMCThumbMCPNondominant bone features
			double? thumbCMCThumbMCPNondominantBoneInitialAngle = gesture.ThumbCMCThumbMCPNondominantBoneInitialAngle;
			double? thumbCMCThumbMCPNondominantBoneFinalAngle = gesture.ThumbCMCThumbMCPNondominantBoneFinalAngle;
			double? thumbCMCThumbMCPNondominantBoneMeanAngle = gesture.ThumbCMCThumbMCPNondominantBoneMeanAngle;
			double? thumbCMCThumbMCPNondominantBoneMaximumAngle = gesture.ThumbCMCThumbMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbCMCThumbMCPNondominantBoneInitialAngle, thumbCMCThumbMCPNondominantBoneFinalAngle,
				thumbCMCThumbMCPNondominantBoneMeanAngle, thumbCMCThumbMCPNondominantBoneMaximumAngle));
			#endregion

			#region ThumbMCPThumbIPNondominant bone features
			double? thumbMCPThumbIPNondominantBoneInitialAngle = gesture.ThumbMCPThumbIPNondominantBoneInitialAngle;
			double? thumbMCPThumbIPNondominantBoneFinalAngle = gesture.ThumbMCPThumbIPNondominantBoneFinalAngle;
			double? thumbMCPThumbIPNondominantBoneMeanAngle = gesture.ThumbMCPThumbIPNondominantBoneMeanAngle;
			double? thumbMCPThumbIPNondominantBoneMaximumAngle = gesture.ThumbMCPThumbIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbMCPThumbIPNondominantBoneInitialAngle, thumbMCPThumbIPNondominantBoneFinalAngle,
				thumbMCPThumbIPNondominantBoneMeanAngle, thumbMCPThumbIPNondominantBoneMaximumAngle));
			#endregion

			#region ThumbIPThumbTIPNondominant bone features
			double? thumbIPThumbTIPNondominantBoneInitialAngle = gesture.ThumbIPThumbTIPNondominantBoneInitialAngle;
			double? thumbIPThumbTIPNondominantBoneFinalAngle = gesture.ThumbIPThumbTIPNondominantBoneFinalAngle;
			double? thumbIPThumbTIPNondominantBoneMeanAngle = gesture.ThumbIPThumbTIPNondominantBoneMeanAngle;
			double? thumbIPThumbTIPNondominantBoneMaximumAngle = gesture.ThumbIPThumbTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbIPThumbTIPNondominantBoneInitialAngle, thumbIPThumbTIPNondominantBoneFinalAngle,
				thumbIPThumbTIPNondominantBoneMeanAngle, thumbIPThumbTIPNondominantBoneMaximumAngle));
			#endregion

			#region WristIndexFingerMCPNondominant bone features
			double? wristIndexFingerMCPNondominantBoneInitialAngle = gesture.WristIndexFingerMCPNondominantBoneInitialAngle;
			double? wristIndexFingerMCPNondominantBoneFinalAngle = gesture.WristIndexFingerMCPNondominantBoneFinalAngle;
			double? wristIndexFingerMCPNondominantBoneMeanAngle = gesture.WristIndexFingerMCPNondominantBoneMeanAngle;
			double? wristIndexFingerMCPNondominantBoneMaximumAngle = gesture.WristIndexFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(wristIndexFingerMCPNondominantBoneInitialAngle, wristIndexFingerMCPNondominantBoneFinalAngle,
				wristIndexFingerMCPNondominantBoneMeanAngle, wristIndexFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPIndexFingerPIPNondominant bone features
			double? indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle;
			double? indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle;
			double? indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle;
			double? indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle, indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle,
				indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle, indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerPIPIndexFingerDIPNondominant bone features
			double? indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle;
			double? indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle;
			double? indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle;
			double? indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle, indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle,
				indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle, indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerDIPIndexFingerTIPNondominant bone features
			double? indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle;
			double? indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle;
			double? indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle;
			double? indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle, indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle,
				indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle, indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPNondominant bone features
			double? middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle;
			double? middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle;
			double? middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle;
			double? middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle, middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle,
				middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle, middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPNondominant bone features
			double? middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle;
			double? middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle;
			double? middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle;
			double? middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle, middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle,
				middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle, middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPNondominant bone features
			double? middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle;
			double? middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle;
			double? middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle;
			double? middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle, middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle,
				middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle, middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPRingFingerPIPNondominant bone features
			double? ringFingerMCPRingFingerPIPNondominantBoneInitialAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle;
			double? ringFingerMCPRingFingerPIPNondominantBoneFinalAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle;
			double? ringFingerMCPRingFingerPIPNondominantBoneMeanAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle;
			double? ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerMCPRingFingerPIPNondominantBoneInitialAngle, ringFingerMCPRingFingerPIPNondominantBoneFinalAngle,
				ringFingerMCPRingFingerPIPNondominantBoneMeanAngle, ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerPIPRingFingerDIPNondominant bone features
			double? ringFingerPIPRingFingerDIPNondominantBoneInitialAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle;
			double? ringFingerPIPRingFingerDIPNondominantBoneFinalAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle;
			double? ringFingerPIPRingFingerDIPNondominantBoneMeanAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle;
			double? ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerPIPRingFingerDIPNondominantBoneInitialAngle, ringFingerPIPRingFingerDIPNondominantBoneFinalAngle,
				ringFingerPIPRingFingerDIPNondominantBoneMeanAngle, ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerDIPRingFingerTIPNondominant bone features
			double? ringFingerDIPRingFingerTIPNondominantBoneInitialAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle;
			double? ringFingerDIPRingFingerTIPNondominantBoneFinalAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle;
			double? ringFingerDIPRingFingerTIPNondominantBoneMeanAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle;
			double? ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerDIPRingFingerTIPNondominantBoneInitialAngle, ringFingerDIPRingFingerTIPNondominantBoneFinalAngle,
				ringFingerDIPRingFingerTIPNondominantBoneMeanAngle, ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle));
			#endregion

			#region WristPinkyMCPNondominant bone features
			double? wristPinkyMCPNondominantBoneInitialAngle = gesture.WristPinkyMCPNondominantBoneInitialAngle;
			double? wristPinkyMCPNondominantBoneFinalAngle = gesture.WristPinkyMCPNondominantBoneFinalAngle;
			double? wristPinkyMCPNondominantBoneMeanAngle = gesture.WristPinkyMCPNondominantBoneMeanAngle;
			double? wristPinkyMCPNondominantBoneMaximumAngle = gesture.WristPinkyMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristPinkyMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(wristPinkyMCPNondominantBoneInitialAngle, wristPinkyMCPNondominantBoneFinalAngle,
				wristPinkyMCPNondominantBoneMeanAngle, wristPinkyMCPNondominantBoneMaximumAngle));
			#endregion

			#region PinkyMCPPinkyPIPNondominant bone features
			double? pinkyMCPPinkyPIPNondominantBoneInitialAngle = gesture.PinkyMCPPinkyPIPNondominantBoneInitialAngle;
			double? pinkyMCPPinkyPIPNondominantBoneFinalAngle = gesture.PinkyMCPPinkyPIPNondominantBoneFinalAngle;
			double? pinkyMCPPinkyPIPNondominantBoneMeanAngle = gesture.PinkyMCPPinkyPIPNondominantBoneMeanAngle;
			double? pinkyMCPPinkyPIPNondominantBoneMaximumAngle = gesture.PinkyMCPPinkyPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(pinkyMCPPinkyPIPNondominantBoneInitialAngle, pinkyMCPPinkyPIPNondominantBoneFinalAngle,
				pinkyMCPPinkyPIPNondominantBoneMeanAngle, pinkyMCPPinkyPIPNondominantBoneMaximumAngle));
			#endregion

			#region PinkyPIPPinkyDIPNondominant bone features
			double? pinkyPIPPinkyDIPNondominantBoneInitialAngle = gesture.PinkyPIPPinkyDIPNondominantBoneInitialAngle;
			double? pinkyPIPPinkyDIPNondominantBoneFinalAngle = gesture.PinkyPIPPinkyDIPNondominantBoneFinalAngle;
			double? pinkyPIPPinkyDIPNondominantBoneMeanAngle = gesture.PinkyPIPPinkyDIPNondominantBoneMeanAngle;
			double? pinkyPIPPinkyDIPNondominantBoneMaximumAngle = gesture.PinkyPIPPinkyDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(pinkyPIPPinkyDIPNondominantBoneInitialAngle, pinkyPIPPinkyDIPNondominantBoneFinalAngle,
				pinkyPIPPinkyDIPNondominantBoneMeanAngle, pinkyPIPPinkyDIPNondominantBoneMaximumAngle));
			#endregion

			#region PinkyDIPPinkyTIPNondominant bone features
			double? pinkyDIPPinkyTIPNondominantBoneInitialAngle = gesture.PinkyDIPPinkyTIPNondominantBoneInitialAngle;
			double? pinkyDIPPinkyTIPNondominantBoneFinalAngle = gesture.PinkyDIPPinkyTIPNondominantBoneFinalAngle;
			double? pinkyDIPPinkyTIPNondominantBoneMeanAngle = gesture.PinkyDIPPinkyTIPNondominantBoneMeanAngle;
			double? pinkyDIPPinkyTIPNondominantBoneMaximumAngle = gesture.PinkyDIPPinkyTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(pinkyDIPPinkyTIPNondominantBoneInitialAngle, pinkyDIPPinkyTIPNondominantBoneFinalAngle,
				pinkyDIPPinkyTIPNondominantBoneMeanAngle, pinkyDIPPinkyTIPNondominantBoneMaximumAngle));
			#endregion

			#region ThumbIPIndexFingerMCPNondominant bone features
			double? thumbIPIndexFingerMCPNondominantBoneInitialAngle = gesture.ThumbIPIndexFingerMCPNondominantBoneInitialAngle;
			double? thumbIPIndexFingerMCPNondominantBoneFinalAngle = gesture.ThumbIPIndexFingerMCPNondominantBoneFinalAngle;
			double? thumbIPIndexFingerMCPNondominantBoneMeanAngle = gesture.ThumbIPIndexFingerMCPNondominantBoneMeanAngle;
			double? thumbIPIndexFingerMCPNondominantBoneMaximumAngle = gesture.ThumbIPIndexFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPIndexFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbIPIndexFingerMCPNondominantBoneInitialAngle, thumbIPIndexFingerMCPNondominantBoneFinalAngle,
				thumbIPIndexFingerMCPNondominantBoneMeanAngle, thumbIPIndexFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominant bone features
			double? indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle;
			double? indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle;
			double? indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle;
			double? indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle, indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle,
				indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle, indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPRingFingerMCPNondominant bone features
			double? middleFingerMCPRingFingerMCPNondominantBoneInitialAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle;
			double? middleFingerMCPRingFingerMCPNondominantBoneFinalAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle;
			double? middleFingerMCPRingFingerMCPNondominantBoneMeanAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle;
			double? middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerMCPRingFingerMCPNondominantBoneInitialAngle, middleFingerMCPRingFingerMCPNondominantBoneFinalAngle,
				middleFingerMCPRingFingerMCPNondominantBoneMeanAngle, middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPPinkyMCPNondominant bone features
			double? ringFingerMCPPinkyMCPNondominantBoneInitialAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneInitialAngle;
			double? ringFingerMCPPinkyMCPNondominantBoneFinalAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneFinalAngle;
			double? ringFingerMCPPinkyMCPNondominantBoneMeanAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneMeanAngle;
			double? ringFingerMCPPinkyMCPNondominantBoneMaximumAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerMCPPinkyMCPNondominantBoneInitialAngle, ringFingerMCPPinkyMCPNondominantBoneFinalAngle,
				ringFingerMCPPinkyMCPNondominantBoneMeanAngle, ringFingerMCPPinkyMCPNondominantBoneMaximumAngle));
			#endregion

			#region Hands distances features
			features.BetweenHandJointsDistanceMax = gesture.BetweenHandJointsDistanceMax;
			features.BetweenHandJointsDistanceMean = gesture.BetweenHandJointsDistanceMean;
			#endregion

			return (features, gesture.Label);
		}
		#endregion

		#region Private methods
		private static JointType GetJointTypeByHandDominance(JointType leftJoint, JointType rightJoint, HandDominance handDominance, bool takeJointFromDominantHand)
		{
			if (handDominance == HandDominance.Left)
				return takeJointFromDominantHand ? leftJoint : rightJoint;

			return takeJointFromDominantHand ? rightJoint : leftJoint;
		}

		private static Bone GetBoneByHandDominance(Bone leftBone, Bone rightBone, HandDominance handDominance, bool takeBoneFromDominantHand)
		{
			if (handDominance == HandDominance.Left)
				return takeBoneFromDominantHand ? leftBone : rightBone;

			return takeBoneFromDominantHand ? rightBone : leftBone;
		}
		#endregion
	}
}
