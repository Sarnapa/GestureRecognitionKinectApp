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
			float elbowLeftF1F2SpatialAngle = float.NaN;
			float elbowLeftFN_1FNSpatialAngle = float.NaN;
			float elbowLeftF1FNSpatialAngle = float.NaN;
			float elbowLeftTotalVectorAngle = float.NaN;
			float elbowLeftSquaredTotalVectorAngle = float.NaN;
			float elbowLeftTotalVectorDisplacement = float.NaN;
			float elbowLeftTotalDisplacement = float.NaN;
			float elbowLeftMaximumDisplacement = float.NaN;
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
			float elbowRightF1F2SpatialAngle = float.NaN;
			float elbowRightFN_1FNSpatialAngle = float.NaN;
			float elbowRightF1FNSpatialAngle = float.NaN;
			float elbowRightTotalVectorAngle = float.NaN;
			float elbowRightSquaredTotalVectorAngle = float.NaN;
			float elbowRightTotalVectorDisplacement = float.NaN;
			float elbowRightTotalDisplacement = float.NaN;
			float elbowRightMaximumDisplacement = float.NaN;
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
			float wristLeftF1F2SpatialAngle = float.NaN;
			float wristLeftFN_1FNSpatialAngle = float.NaN;
			float wristLeftF1FNSpatialAngle = float.NaN;
			float wristLeftTotalVectorAngle = float.NaN;
			float wristLeftSquaredTotalVectorAngle = float.NaN;
			float wristLeftTotalVectorDisplacement = float.NaN;
			float wristLeftTotalDisplacement = float.NaN;
			float wristLeftMaximumDisplacement = float.NaN;
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
			float wristRightF1F2SpatialAngle = float.NaN;
			float wristRightFN_1FNSpatialAngle = float.NaN;
			float wristRightF1FNSpatialAngle = float.NaN;
			float wristRightTotalVectorAngle = float.NaN;
			float wristRightSquaredTotalVectorAngle = float.NaN;
			float wristRightTotalVectorDisplacement = float.NaN;
			float wristRightTotalDisplacement = float.NaN;
			float wristRightMaximumDisplacement = float.NaN;
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
			float handLeftF1F2SpatialAngle = float.NaN;
			float handLeftFN_1FNSpatialAngle = float.NaN;
			float handLeftF1FNSpatialAngle = float.NaN;
			float handLeftTotalVectorAngle = float.NaN;
			float handLeftSquaredTotalVectorAngle = float.NaN;
			float handLeftTotalVectorDisplacement = float.NaN;
			float handLeftTotalDisplacement = float.NaN;
			float handLeftMaximumDisplacement = float.NaN;
			float handLeftBoundingBoxDiagonalLength = float.NaN;
			float handLeftBoundingBoxAngle = float.NaN;
			//HandState[] handLeftHandStates = float.NaN;
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
			float handRightF1F2SpatialAngle = float.NaN;
			float handRightFN_1FNSpatialAngle = float.NaN;
			float handRightF1FNSpatialAngle = float.NaN;
			float handRightTotalVectorAngle = float.NaN;
			float handRightSquaredTotalVectorAngle = float.NaN;
			float handRightTotalVectorDisplacement = float.NaN;
			float handRightTotalDisplacement = float.NaN;
			float handRightMaximumDisplacement = float.NaN;
			float handRightBoundingBoxDiagonalLength = float.NaN;
			float handRightBoundingBoxAngle = float.NaN;
			//HandState[] handRightHandStates = float.NaN;
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
			float thumbLeftF1F2SpatialAngle = float.NaN;
			float thumbLeftFN_1FNSpatialAngle = float.NaN;
			float thumbLeftF1FNSpatialAngle = float.NaN;
			float thumbLeftTotalVectorAngle = float.NaN;
			float thumbLeftSquaredTotalVectorAngle = float.NaN;
			float thumbLeftTotalVectorDisplacement = float.NaN;
			float thumbLeftTotalDisplacement = float.NaN;
			float thumbLeftMaximumDisplacement = float.NaN;
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
			float thumbRightF1F2SpatialAngle = float.NaN;
			float thumbRightFN_1FNSpatialAngle = float.NaN;
			float thumbRightF1FNSpatialAngle = float.NaN;
			float thumbRightTotalVectorAngle = float.NaN;
			float thumbRightSquaredTotalVectorAngle = float.NaN;
			float thumbRightTotalVectorDisplacement = float.NaN;
			float thumbRightTotalDisplacement = float.NaN;
			float thumbRightMaximumDisplacement = float.NaN;
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
			float handTipLeftF1F2SpatialAngle = float.NaN;
			float handTipLeftFN_1FNSpatialAngle = float.NaN;
			float handTipLeftF1FNSpatialAngle = float.NaN;
			float handTipLeftTotalVectorAngle = float.NaN;
			float handTipLeftSquaredTotalVectorAngle = float.NaN;
			float handTipLeftTotalVectorDisplacement = float.NaN;
			float handTipLeftTotalDisplacement = float.NaN;
			float handTipLeftMaximumDisplacement = float.NaN;
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
			float handTipRightF1F2SpatialAngle = float.NaN;
			float handTipRightFN_1FNSpatialAngle = float.NaN;
			float handTipRightF1FNSpatialAngle = float.NaN;
			float handTipRightTotalVectorAngle = float.NaN;
			float handTipRightSquaredTotalVectorAngle = float.NaN;
			float handTipRightTotalVectorDisplacement = float.NaN;
			float handTipRightTotalDisplacement = float.NaN;
			float handTipRightMaximumDisplacement = float.NaN;
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
			float elbowLeftWristLeftBoneInitialAngle = float.NaN;
			float elbowLeftWristLeftBoneFinalAngle = float.NaN;
			float elbowLeftWristLeftBoneMeanAngle = float.NaN;
			float elbowLeftWristLeftBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.ElbowLeftWristLeftBone, out var elbowLeftWristLeftBoneAngleData))
			{
				elbowLeftWristLeftBoneInitialAngle = elbowLeftWristLeftBoneAngleData.InitialAngle;
				elbowLeftWristLeftBoneFinalAngle = elbowLeftWristLeftBoneAngleData.FinalAngle;
				elbowLeftWristLeftBoneMeanAngle = elbowLeftWristLeftBoneAngleData.MeanAngle;
				elbowLeftWristLeftBoneMaximumAngle = elbowLeftWristLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ElbowRightWristRight bone features
			float elbowRightWristRightBoneInitialAngle = float.NaN;
			float elbowRightWristRightBoneFinalAngle = float.NaN;
			float elbowRightWristRightBoneMeanAngle = float.NaN;
			float elbowRightWristRightBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.ElbowRightWristRightBone, out var elbowRightWristRightBoneAngleData))
			{
				elbowRightWristRightBoneInitialAngle = elbowRightWristRightBoneAngleData.InitialAngle;
				elbowRightWristRightBoneFinalAngle = elbowRightWristRightBoneAngleData.FinalAngle;
				elbowRightWristRightBoneMeanAngle = elbowRightWristRightBoneAngleData.MeanAngle;
				elbowRightWristRightBoneMaximumAngle = elbowRightWristRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristLeftHandLeft bone features
			float wristLeftHandLeftBoneInitialAngle = float.NaN;
			float wristLeftHandLeftBoneFinalAngle = float.NaN;
			float wristLeftHandLeftBoneMeanAngle = float.NaN;
			float wristLeftHandLeftBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.WristLeftHandLeftBone, out var wristLeftHandLeftBoneAngleData))
			{
				wristLeftHandLeftBoneInitialAngle = wristLeftHandLeftBoneAngleData.InitialAngle;
				wristLeftHandLeftBoneFinalAngle = wristLeftHandLeftBoneAngleData.FinalAngle;
				wristLeftHandLeftBoneMeanAngle = wristLeftHandLeftBoneAngleData.MeanAngle;
				wristLeftHandLeftBoneMaximumAngle = wristLeftHandLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristRightHandRight bone features
			float wristRightHandRightBoneInitialAngle = float.NaN;
			float wristRightHandRightBoneFinalAngle = float.NaN;
			float wristRightHandRightBoneMeanAngle = float.NaN;
			float wristRightHandRightBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.WristRightHandRightBone, out var wristRightHandRightBoneAngleData))
			{
				wristRightHandRightBoneInitialAngle = wristRightHandRightBoneAngleData.InitialAngle;
				wristRightHandRightBoneFinalAngle = wristRightHandRightBoneAngleData.FinalAngle;
				wristRightHandRightBoneMeanAngle = wristRightHandRightBoneAngleData.MeanAngle;
				wristRightHandRightBoneMaximumAngle = wristRightHandRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region HandLeftHandTipLeft bone features
			float handLeftHandTipLeftBoneInitialAngle = float.NaN;
			float handLeftHandTipLeftBoneFinalAngle = float.NaN;
			float handLeftHandTipLeftBoneMeanAngle = float.NaN;
			float handLeftHandTipLeftBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.HandLeftHandTipLeftBone, out var handLeftHandTipLeftBoneAngleData))
			{
				handLeftHandTipLeftBoneInitialAngle = handLeftHandTipLeftBoneAngleData.InitialAngle;
				handLeftHandTipLeftBoneFinalAngle = handLeftHandTipLeftBoneAngleData.FinalAngle;
				handLeftHandTipLeftBoneMeanAngle = handLeftHandTipLeftBoneAngleData.MeanAngle;
				handLeftHandTipLeftBoneMaximumAngle = handLeftHandTipLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region HandRightHandTipRight bone features
			float handRightHandTipRightBoneInitialAngle = float.NaN;
			float handRightHandTipRightBoneFinalAngle = float.NaN;
			float handRightHandTipRightBoneMeanAngle = float.NaN;
			float handRightHandTipRightBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.HandRightHandTipRightBone, out var handRightHandTipRightBoneAngleData))
			{
				handRightHandTipRightBoneInitialAngle = handRightHandTipRightBoneAngleData.InitialAngle;
				handRightHandTipRightBoneFinalAngle = handRightHandTipRightBoneAngleData.FinalAngle;
				handRightHandTipRightBoneMeanAngle = handRightHandTipRightBoneAngleData.MeanAngle;
				handRightHandTipRightBoneMaximumAngle = handRightHandTipRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristLeftThumbLeft bone features
			float wristLeftThumbLeftBoneInitialAngle = float.NaN;
			float wristLeftThumbLeftBoneFinalAngle = float.NaN;
			float wristLeftThumbLeftBoneMeanAngle = float.NaN;
			float wristLeftThumbLeftBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.WristLeftThumbLeftBone, out var wristLeftThumbLeftBoneAngleData))
			{
				wristLeftThumbLeftBoneInitialAngle = wristLeftThumbLeftBoneAngleData.InitialAngle;
				wristLeftThumbLeftBoneFinalAngle = wristLeftThumbLeftBoneAngleData.FinalAngle;
				wristLeftThumbLeftBoneMeanAngle = wristLeftThumbLeftBoneAngleData.MeanAngle;
				wristLeftThumbLeftBoneMaximumAngle = wristLeftThumbLeftBoneAngleData.MaximumAngle;
			}
			#endregion

			#region WristRightThumbRight bone features
			float wristRightThumbRightBoneInitialAngle = float.NaN;
			float wristRightThumbRightBoneFinalAngle = float.NaN;
			float wristRightThumbRightBoneMeanAngle = float.NaN;
			float wristRightThumbRightBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(KinectBonesDefs.WristRightThumbRightBone, out var wristRightThumbRightBoneAngleData))
			{
				wristRightThumbRightBoneInitialAngle = wristRightThumbRightBoneAngleData.InitialAngle;
				wristRightThumbRightBoneFinalAngle = wristRightThumbRightBoneAngleData.FinalAngle;
				wristRightThumbRightBoneMeanAngle = wristRightThumbRightBoneAngleData.MeanAngle;
				wristRightThumbRightBoneMaximumAngle = wristRightThumbRightBoneAngleData.MaximumAngle;
			}
			#endregion

			#region Hands distances features
			float betweenHandJointsDistanceMax = features.BetweenHandJointsDistanceMax;
			float betweenHandJointsDistanceMean = features.BetweenHandJointsDistanceMean;
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

				#region WristLeftThumbLeft bone features
				WristLeftThumbLeftBoneInitialAngle = wristLeftThumbLeftBoneInitialAngle,
				WristLeftThumbLeftBoneFinalAngle = wristLeftThumbLeftBoneFinalAngle,
				WristLeftThumbLeftBoneMeanAngle = wristLeftThumbLeftBoneMeanAngle,
				WristLeftThumbLeftBoneMaximumAngle = wristLeftThumbLeftBoneMaximumAngle,
				#endregion

				#region WristRightThumbRight bone features
				WristRightThumbRightBoneInitialAngle = wristRightThumbRightBoneInitialAngle,
				WristRightThumbRightBoneFinalAngle = wristRightThumbRightBoneFinalAngle,
				WristRightThumbRightBoneMeanAngle = wristRightThumbRightBoneMeanAngle,
				WristRightThumbRightBoneMaximumAngle = wristRightThumbRightBoneMaximumAngle,
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
			float elbowLeftF1F2SpatialAngle = gesture.ElbowLeftF1F2SpatialAngle;
			float elbowLeftFN_1FNSpatialAngle = gesture.ElbowLeftFN_1FNSpatialAngle;
			float elbowLeftF1FNSpatialAngle = gesture.ElbowLeftF1FNSpatialAngle;
			float elbowLeftTotalVectorAngle = gesture.ElbowLeftTotalVectorAngle;
			float elbowLeftSquaredTotalVectorAngle = gesture.ElbowLeftSquaredTotalVectorAngle;
			float elbowLeftTotalVectorDisplacement = gesture.ElbowLeftTotalVectorDisplacement;
			float elbowLeftTotalDisplacement = gesture.ElbowLeftTotalDisplacement;
			float elbowLeftMaximumDisplacement = gesture.ElbowLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ElbowLeft, new JointGestureFeatures(elbowLeftF1F2SpatialAngle,
				elbowLeftFN_1FNSpatialAngle, elbowLeftF1FNSpatialAngle, elbowLeftTotalVectorAngle, elbowLeftSquaredTotalVectorAngle,
				elbowLeftTotalVectorDisplacement, elbowLeftTotalDisplacement, elbowLeftMaximumDisplacement));
			#endregion

			#region ElbowRight joint features
			float elbowRightF1F2SpatialAngle = gesture.ElbowRightF1F2SpatialAngle;
			float elbowRightFN_1FNSpatialAngle = gesture.ElbowRightFN_1FNSpatialAngle;
			float elbowRightF1FNSpatialAngle = gesture.ElbowRightF1FNSpatialAngle;
			float elbowRightTotalVectorAngle = gesture.ElbowRightTotalVectorAngle;
			float elbowRightSquaredTotalVectorAngle = gesture.ElbowRightSquaredTotalVectorAngle;
			float elbowRightTotalVectorDisplacement = gesture.ElbowRightTotalVectorDisplacement;
			float elbowRightTotalDisplacement = gesture.ElbowRightTotalDisplacement;
			float elbowRightMaximumDisplacement = gesture.ElbowRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ElbowRight, new JointGestureFeatures(elbowRightF1F2SpatialAngle,
				elbowRightFN_1FNSpatialAngle, elbowRightF1FNSpatialAngle, elbowRightTotalVectorAngle, elbowRightSquaredTotalVectorAngle,
				elbowRightTotalVectorDisplacement, elbowRightTotalDisplacement, elbowRightMaximumDisplacement));
			#endregion

			#region WristLeft joint features
			float wristLeftF1F2SpatialAngle = gesture.WristLeftF1F2SpatialAngle;
			float wristLeftFN_1FNSpatialAngle = gesture.WristLeftFN_1FNSpatialAngle;
			float wristLeftF1FNSpatialAngle = gesture.WristLeftF1FNSpatialAngle;
			float wristLeftTotalVectorAngle = gesture.WristLeftTotalVectorAngle;
			float wristLeftSquaredTotalVectorAngle = gesture.WristLeftSquaredTotalVectorAngle;
			float wristLeftTotalVectorDisplacement = gesture.WristLeftTotalVectorDisplacement;
			float wristLeftTotalDisplacement = gesture.WristLeftTotalDisplacement;
			float wristLeftMaximumDisplacement = gesture.WristLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.WristLeft, new JointGestureFeatures(wristLeftF1F2SpatialAngle,
				wristLeftFN_1FNSpatialAngle, wristLeftF1FNSpatialAngle, wristLeftTotalVectorAngle, wristLeftSquaredTotalVectorAngle,
				wristLeftTotalVectorDisplacement, wristLeftTotalDisplacement, wristLeftMaximumDisplacement));
			#endregion

			#region WristRight joint features
			float wristRightF1F2SpatialAngle = gesture.WristRightF1F2SpatialAngle;
			float wristRightFN_1FNSpatialAngle = gesture.WristRightFN_1FNSpatialAngle;
			float wristRightF1FNSpatialAngle = gesture.WristRightF1FNSpatialAngle;
			float wristRightTotalVectorAngle = gesture.WristRightTotalVectorAngle;
			float wristRightSquaredTotalVectorAngle = gesture.WristRightSquaredTotalVectorAngle;
			float wristRightTotalVectorDisplacement = gesture.WristRightTotalVectorDisplacement;
			float wristRightTotalDisplacement = gesture.WristRightTotalDisplacement;
			float wristRightMaximumDisplacement = gesture.WristRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.WristRight, new JointGestureFeatures(wristRightF1F2SpatialAngle,
				wristRightFN_1FNSpatialAngle, wristRightF1FNSpatialAngle, wristRightTotalVectorAngle, wristRightSquaredTotalVectorAngle,
				wristRightTotalVectorDisplacement, wristRightTotalDisplacement, wristRightMaximumDisplacement));
			#endregion

			#region HandLeft joint features
			float handLeftF1F2SpatialAngle = gesture.HandLeftF1F2SpatialAngle;
			float handLeftFN_1FNSpatialAngle = gesture.HandLeftFN_1FNSpatialAngle;
			float handLeftF1FNSpatialAngle = gesture.HandLeftF1FNSpatialAngle;
			float handLeftTotalVectorAngle = gesture.HandLeftTotalVectorAngle;
			float handLeftSquaredTotalVectorAngle = gesture.HandLeftSquaredTotalVectorAngle;
			float handLeftTotalVectorDisplacement = gesture.HandLeftTotalVectorDisplacement;
			float handLeftTotalDisplacement = gesture.HandLeftTotalDisplacement;
			float handLeftMaximumDisplacement = gesture.HandLeftMaximumDisplacement;
			float handLeftBoundingBoxDiagonalLength = gesture.HandLeftBoundingBoxDiagonalLength;
			float handLeftBoundingBoxAngle = gesture.HandLeftBoundingBoxAngle;
			//HandState[] handLeftHandStates = gesture.HandLeftHandStates;
			features.AddJointGestureFeature(JointType.HandLeft, new HandJointGestureFeatures(handLeftF1F2SpatialAngle,
				handLeftFN_1FNSpatialAngle, handLeftF1FNSpatialAngle, handLeftTotalVectorAngle, handLeftSquaredTotalVectorAngle,
				handLeftTotalVectorDisplacement, handLeftTotalDisplacement, handLeftMaximumDisplacement,
				handLeftBoundingBoxDiagonalLength, handLeftBoundingBoxAngle/*, handLeftHandStates*/));
			#endregion

			#region HandRight joint features
			float handRightF1F2SpatialAngle = gesture.HandRightF1F2SpatialAngle;
			float handRightFN_1FNSpatialAngle = gesture.HandRightFN_1FNSpatialAngle;
			float handRightF1FNSpatialAngle = gesture.HandRightF1FNSpatialAngle;
			float handRightTotalVectorAngle = gesture.HandRightTotalVectorAngle;
			float handRightSquaredTotalVectorAngle = gesture.HandRightSquaredTotalVectorAngle;
			float handRightTotalVectorDisplacement = gesture.HandRightTotalVectorDisplacement;
			float handRightTotalDisplacement = gesture.HandRightTotalDisplacement;
			float handRightMaximumDisplacement = gesture.HandRightMaximumDisplacement;
			float handRightBoundingBoxDiagonalLength = gesture.HandRightBoundingBoxDiagonalLength;
			float handRightBoundingBoxAngle = gesture.HandRightBoundingBoxAngle;
			//HandState[] handRightHandStates = gesture.HandRightHandStates;
			features.AddJointGestureFeature(JointType.HandRight, new HandJointGestureFeatures(handRightF1F2SpatialAngle,
				handRightFN_1FNSpatialAngle, handRightF1FNSpatialAngle, handRightTotalVectorAngle, handRightSquaredTotalVectorAngle,
				handRightTotalVectorDisplacement, handRightTotalDisplacement, handRightMaximumDisplacement,
				handRightBoundingBoxDiagonalLength, handRightBoundingBoxAngle/*, handRightHandStates*/));
			#endregion

			#region ThumbLeft joint features
			float thumbLeftF1F2SpatialAngle = gesture.ThumbLeftF1F2SpatialAngle;
			float thumbLeftFN_1FNSpatialAngle = gesture.ThumbLeftFN_1FNSpatialAngle;
			float thumbLeftF1FNSpatialAngle = gesture.ThumbLeftF1FNSpatialAngle;
			float thumbLeftTotalVectorAngle = gesture.ThumbLeftTotalVectorAngle;
			float thumbLeftSquaredTotalVectorAngle = gesture.ThumbLeftSquaredTotalVectorAngle;
			float thumbLeftTotalVectorDisplacement = gesture.ThumbLeftTotalVectorDisplacement;
			float thumbLeftTotalDisplacement = gesture.ThumbLeftTotalDisplacement;
			float thumbLeftMaximumDisplacement = gesture.ThumbLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ThumbLeft, new JointGestureFeatures(thumbLeftF1F2SpatialAngle,
				thumbLeftFN_1FNSpatialAngle, thumbLeftF1FNSpatialAngle, thumbLeftTotalVectorAngle, thumbLeftSquaredTotalVectorAngle,
				thumbLeftTotalVectorDisplacement, thumbLeftTotalDisplacement, thumbLeftMaximumDisplacement));
			#endregion

			#region ThumbRight joint features
			float thumbRightF1F2SpatialAngle = gesture.ThumbRightF1F2SpatialAngle;
			float thumbRightFN_1FNSpatialAngle = gesture.ThumbRightFN_1FNSpatialAngle;
			float thumbRightF1FNSpatialAngle = gesture.ThumbRightF1FNSpatialAngle;
			float thumbRightTotalVectorAngle = gesture.ThumbRightTotalVectorAngle;
			float thumbRightSquaredTotalVectorAngle = gesture.ThumbRightSquaredTotalVectorAngle;
			float thumbRightTotalVectorDisplacement = gesture.ThumbRightTotalVectorDisplacement;
			float thumbRightTotalDisplacement = gesture.ThumbRightTotalDisplacement;
			float thumbRightMaximumDisplacement = gesture.ThumbRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.ThumbRight, new JointGestureFeatures(thumbRightF1F2SpatialAngle,
				thumbRightFN_1FNSpatialAngle, thumbRightF1FNSpatialAngle, thumbRightTotalVectorAngle, thumbRightSquaredTotalVectorAngle,
				thumbRightTotalVectorDisplacement, thumbRightTotalDisplacement, thumbRightMaximumDisplacement));
			#endregion

			#region HandTipLeft joint features
			float handTipLeftF1F2SpatialAngle = gesture.HandTipLeftF1F2SpatialAngle;
			float handTipLeftFN_1FNSpatialAngle = gesture.HandTipLeftFN_1FNSpatialAngle;
			float handTipLeftF1FNSpatialAngle = gesture.HandTipLeftF1FNSpatialAngle;
			float handTipLeftTotalVectorAngle = gesture.HandTipLeftTotalVectorAngle;
			float handTipLeftSquaredTotalVectorAngle = gesture.HandTipLeftSquaredTotalVectorAngle;
			float handTipLeftTotalVectorDisplacement = gesture.HandTipLeftTotalVectorDisplacement;
			float handTipLeftTotalDisplacement = gesture.HandTipLeftTotalDisplacement;
			float handTipLeftMaximumDisplacement = gesture.HandTipLeftMaximumDisplacement;
			features.AddJointGestureFeature(JointType.HandTipLeft, new JointGestureFeatures(handTipLeftF1F2SpatialAngle,
				handTipLeftFN_1FNSpatialAngle, handTipLeftF1FNSpatialAngle, handTipLeftTotalVectorAngle, handTipLeftSquaredTotalVectorAngle,
				handTipLeftTotalVectorDisplacement, handTipLeftTotalDisplacement, handTipLeftMaximumDisplacement));
			#endregion

			#region HandTipRight joint features
			float handTipRightF1F2SpatialAngle = gesture.HandTipRightF1F2SpatialAngle;
			float handTipRightFN_1FNSpatialAngle = gesture.HandTipRightFN_1FNSpatialAngle;
			float handTipRightF1FNSpatialAngle = gesture.HandTipRightF1FNSpatialAngle;
			float handTipRightTotalVectorAngle = gesture.HandTipRightTotalVectorAngle;
			float handTipRightSquaredTotalVectorAngle = gesture.HandTipRightSquaredTotalVectorAngle;
			float handTipRightTotalVectorDisplacement = gesture.HandTipRightTotalVectorDisplacement;
			float handTipRightTotalDisplacement = gesture.HandTipRightTotalDisplacement;
			float handTipRightMaximumDisplacement = gesture.HandTipRightMaximumDisplacement;
			features.AddJointGestureFeature(JointType.HandTipRight, new JointGestureFeatures(handTipRightF1F2SpatialAngle,
				handTipRightFN_1FNSpatialAngle, handTipRightF1FNSpatialAngle, handTipRightTotalVectorAngle, handTipRightSquaredTotalVectorAngle,
				handTipRightTotalVectorDisplacement, handTipRightTotalDisplacement, handTipRightMaximumDisplacement));
			#endregion

			#region ElbowLeftWristLeft bone features
			float elbowLeftWristLeftBoneInitialAngle = gesture.ElbowLeftWristLeftBoneInitialAngle;
			float elbowLeftWristLeftBoneFinalAngle = gesture.ElbowLeftWristLeftBoneFinalAngle;
			float elbowLeftWristLeftBoneMeanAngle = gesture.ElbowLeftWristLeftBoneMeanAngle;
			float elbowLeftWristLeftBoneMaximumAngle = gesture.ElbowLeftWristLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.ElbowLeftWristLeftBone, new BoneJointsAngleData(elbowLeftWristLeftBoneInitialAngle,
				elbowLeftWristLeftBoneFinalAngle, elbowLeftWristLeftBoneMeanAngle, elbowLeftWristLeftBoneMaximumAngle));
			#endregion

			#region ElbowRightWristRight bone features
			float elbowRightWristRightBoneInitialAngle = gesture.ElbowRightWristRightBoneInitialAngle;
			float elbowRightWristRightBoneFinalAngle = gesture.ElbowRightWristRightBoneFinalAngle;
			float elbowRightWristRightBoneMeanAngle = gesture.ElbowRightWristRightBoneMeanAngle;
			float elbowRightWristRightBoneMaximumAngle = gesture.ElbowRightWristRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.ElbowRightWristRightBone, new BoneJointsAngleData(elbowRightWristRightBoneInitialAngle,
				elbowRightWristRightBoneFinalAngle, elbowRightWristRightBoneMeanAngle, elbowRightWristRightBoneMaximumAngle));
			#endregion

			#region WristLeftHandLeft bone features
			float wristLeftHandLeftBoneInitialAngle = gesture.WristLeftHandLeftBoneInitialAngle;
			float wristLeftHandLeftBoneFinalAngle = gesture.WristLeftHandLeftBoneFinalAngle;
			float wristLeftHandLeftBoneMeanAngle = gesture.WristLeftHandLeftBoneMeanAngle;
			float wristLeftHandLeftBoneMaximumAngle = gesture.WristLeftHandLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.WristLeftHandLeftBone, new BoneJointsAngleData(wristLeftHandLeftBoneInitialAngle,
				wristLeftHandLeftBoneFinalAngle, wristLeftHandLeftBoneMeanAngle, wristLeftHandLeftBoneMaximumAngle));
			#endregion

			#region WristRightHandRight bone features
			float wristRightHandRightBoneInitialAngle = gesture.WristRightHandRightBoneInitialAngle;
			float wristRightHandRightBoneFinalAngle = gesture.WristRightHandRightBoneFinalAngle;
			float wristRightHandRightBoneMeanAngle = gesture.WristRightHandRightBoneMeanAngle;
			float wristRightHandRightBoneMaximumAngle = gesture.WristRightHandRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.WristRightHandRightBone, new BoneJointsAngleData(wristRightHandRightBoneInitialAngle,
				wristRightHandRightBoneFinalAngle, wristRightHandRightBoneMeanAngle, wristRightHandRightBoneMaximumAngle));
			#endregion

			#region HandLeftHandTipLeft bone features
			float handLeftHandTipLeftBoneInitialAngle = gesture.HandLeftHandTipLeftBoneInitialAngle;
			float handLeftHandTipLeftBoneFinalAngle = gesture.HandLeftHandTipLeftBoneFinalAngle;
			float handLeftHandTipLeftBoneMeanAngle = gesture.HandLeftHandTipLeftBoneMeanAngle;
			float handLeftHandTipLeftBoneMaximumAngle = gesture.HandLeftHandTipLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.HandLeftHandTipLeftBone, new BoneJointsAngleData(handLeftHandTipLeftBoneInitialAngle,
				handLeftHandTipLeftBoneFinalAngle, handLeftHandTipLeftBoneMeanAngle, handLeftHandTipLeftBoneMaximumAngle));
			#endregion

			#region HandRightHandTipRight bone features
			float handRightHandTipRightBoneInitialAngle = gesture.HandRightHandTipRightBoneInitialAngle;
			float handRightHandTipRightBoneFinalAngle = gesture.HandRightHandTipRightBoneFinalAngle;
			float handRightHandTipRightBoneMeanAngle = gesture.HandRightHandTipRightBoneMeanAngle;
			float handRightHandTipRightBoneMaximumAngle = gesture.HandRightHandTipRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.HandRightHandTipRightBone, new BoneJointsAngleData(handRightHandTipRightBoneInitialAngle,
				handRightHandTipRightBoneFinalAngle, handRightHandTipRightBoneMeanAngle, handRightHandTipRightBoneMaximumAngle));
			#endregion


			#region WristLeftThumbLeft bone features
			float wristLeftThumbLeftBoneInitialAngle = gesture.WristLeftThumbLeftBoneInitialAngle;
			float wristLeftThumbLeftBoneFinalAngle = gesture.WristLeftThumbLeftBoneFinalAngle;
			float wristLeftThumbLeftBoneMeanAngle = gesture.WristLeftThumbLeftBoneMeanAngle;
			float wristLeftThumbLeftBoneMaximumAngle = gesture.WristLeftThumbLeftBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.WristLeftThumbLeftBone, new BoneJointsAngleData(wristLeftThumbLeftBoneInitialAngle,
				wristLeftThumbLeftBoneFinalAngle, wristLeftThumbLeftBoneMeanAngle, wristLeftThumbLeftBoneMaximumAngle));
			#endregion


			#region WristRightThumbRight bone features
			float wristRightThumbRightBoneInitialAngle = gesture.WristRightThumbRightBoneInitialAngle;
			float wristRightThumbRightBoneFinalAngle = gesture.WristRightThumbRightBoneFinalAngle;
			float wristRightThumbRightBoneMeanAngle = gesture.WristRightThumbRightBoneMeanAngle;
			float wristRightThumbRightBoneMaximumAngle = gesture.WristRightThumbRightBoneMaximumAngle;
			features.AddBoneJointsAngleData(KinectBonesDefs.WristRightThumbRightBone, new BoneJointsAngleData(wristRightThumbRightBoneInitialAngle,
				wristRightThumbRightBoneFinalAngle, wristRightThumbRightBoneMeanAngle, wristRightThumbRightBoneMaximumAngle));
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
			float wristDominantF1F2SpatialAngle = float.NaN;
			float wristDominantFN_1FNSpatialAngle = float.NaN;
			float wristDominantF1FNSpatialAngle = float.NaN;
			float wristDominantTotalVectorAngle = float.NaN;
			float wristDominantSquaredTotalVectorAngle = float.NaN;
			float wristDominantTotalVectorDisplacement = float.NaN;
			float wristDominantTotalDisplacement = float.NaN;
			float wristDominantMaximumDisplacement = float.NaN;
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
			float thumbCMCDominantF1F2SpatialAngle = float.NaN;
			float thumbCMCDominantFN_1FNSpatialAngle = float.NaN;
			float thumbCMCDominantF1FNSpatialAngle = float.NaN;
			float thumbCMCDominantTotalVectorAngle = float.NaN;
			float thumbCMCDominantSquaredTotalVectorAngle = float.NaN;
			float thumbCMCDominantTotalVectorDisplacement = float.NaN;
			float thumbCMCDominantTotalDisplacement = float.NaN;
			float thumbCMCDominantMaximumDisplacement = float.NaN;
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
			float thumbMCPDominantF1F2SpatialAngle = float.NaN;
			float thumbMCPDominantFN_1FNSpatialAngle = float.NaN;
			float thumbMCPDominantF1FNSpatialAngle = float.NaN;
			float thumbMCPDominantTotalVectorAngle = float.NaN;
			float thumbMCPDominantSquaredTotalVectorAngle = float.NaN;
			float thumbMCPDominantTotalVectorDisplacement = float.NaN;
			float thumbMCPDominantTotalDisplacement = float.NaN;
			float thumbMCPDominantMaximumDisplacement = float.NaN;
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
			float thumbIPDominantF1F2SpatialAngle = float.NaN;
			float thumbIPDominantFN_1FNSpatialAngle = float.NaN;
			float thumbIPDominantF1FNSpatialAngle = float.NaN;
			float thumbIPDominantTotalVectorAngle = float.NaN;
			float thumbIPDominantSquaredTotalVectorAngle = float.NaN;
			float thumbIPDominantTotalVectorDisplacement = float.NaN;
			float thumbIPDominantTotalDisplacement = float.NaN;
			float thumbIPDominantMaximumDisplacement = float.NaN;
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
			float thumbTIPDominantF1F2SpatialAngle = float.NaN;
			float thumbTIPDominantFN_1FNSpatialAngle = float.NaN;
			float thumbTIPDominantF1FNSpatialAngle = float.NaN;
			float thumbTIPDominantTotalVectorAngle = float.NaN;
			float thumbTIPDominantSquaredTotalVectorAngle = float.NaN;
			float thumbTIPDominantTotalVectorDisplacement = float.NaN;
			float thumbTIPDominantTotalDisplacement = float.NaN;
			float thumbTIPDominantMaximumDisplacement = float.NaN;
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
			float indexFingerMCPDominantF1F2SpatialAngle = float.NaN;
			float indexFingerMCPDominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerMCPDominantF1FNSpatialAngle = float.NaN;
			float indexFingerMCPDominantTotalVectorAngle = float.NaN;
			float indexFingerMCPDominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerMCPDominantTotalVectorDisplacement = float.NaN;
			float indexFingerMCPDominantTotalDisplacement = float.NaN;
			float indexFingerMCPDominantMaximumDisplacement = float.NaN;
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
			float indexFingerPIPDominantF1F2SpatialAngle = float.NaN;
			float indexFingerPIPDominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerPIPDominantF1FNSpatialAngle = float.NaN;
			float indexFingerPIPDominantTotalVectorAngle = float.NaN;
			float indexFingerPIPDominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerPIPDominantTotalVectorDisplacement = float.NaN;
			float indexFingerPIPDominantTotalDisplacement = float.NaN;
			float indexFingerPIPDominantMaximumDisplacement = float.NaN;
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
			float indexFingerDIPDominantF1F2SpatialAngle = float.NaN;
			float indexFingerDIPDominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerDIPDominantF1FNSpatialAngle = float.NaN;
			float indexFingerDIPDominantTotalVectorAngle = float.NaN;
			float indexFingerDIPDominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerDIPDominantTotalVectorDisplacement = float.NaN;
			float indexFingerDIPDominantTotalDisplacement = float.NaN;
			float indexFingerDIPDominantMaximumDisplacement = float.NaN;
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
			float indexFingerTIPDominantF1F2SpatialAngle = float.NaN;
			float indexFingerTIPDominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerTIPDominantF1FNSpatialAngle = float.NaN;
			float indexFingerTIPDominantTotalVectorAngle = float.NaN;
			float indexFingerTIPDominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerTIPDominantTotalVectorDisplacement = float.NaN;
			float indexFingerTIPDominantTotalDisplacement = float.NaN;
			float indexFingerTIPDominantMaximumDisplacement = float.NaN;
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
			float middleFingerMCPDominantF1F2SpatialAngle = float.NaN;
			float middleFingerMCPDominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerMCPDominantF1FNSpatialAngle = float.NaN;
			float middleFingerMCPDominantTotalVectorAngle = float.NaN;
			float middleFingerMCPDominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerMCPDominantTotalVectorDisplacement = float.NaN;
			float middleFingerMCPDominantTotalDisplacement = float.NaN;
			float middleFingerMCPDominantMaximumDisplacement = float.NaN;
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
			float middleFingerPIPDominantF1F2SpatialAngle = float.NaN;
			float middleFingerPIPDominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerPIPDominantF1FNSpatialAngle = float.NaN;
			float middleFingerPIPDominantTotalVectorAngle = float.NaN;
			float middleFingerPIPDominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerPIPDominantTotalVectorDisplacement = float.NaN;
			float middleFingerPIPDominantTotalDisplacement = float.NaN;
			float middleFingerPIPDominantMaximumDisplacement = float.NaN;
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
			float middleFingerDIPDominantF1F2SpatialAngle = float.NaN;
			float middleFingerDIPDominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerDIPDominantF1FNSpatialAngle = float.NaN;
			float middleFingerDIPDominantTotalVectorAngle = float.NaN;
			float middleFingerDIPDominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerDIPDominantTotalVectorDisplacement = float.NaN;
			float middleFingerDIPDominantTotalDisplacement = float.NaN;
			float middleFingerDIPDominantMaximumDisplacement = float.NaN;
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
			float middleFingerTIPDominantF1F2SpatialAngle = float.NaN;
			float middleFingerTIPDominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerTIPDominantF1FNSpatialAngle = float.NaN;
			float middleFingerTIPDominantTotalVectorAngle = float.NaN;
			float middleFingerTIPDominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerTIPDominantTotalVectorDisplacement = float.NaN;
			float middleFingerTIPDominantTotalDisplacement = float.NaN;
			float middleFingerTIPDominantMaximumDisplacement = float.NaN;
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
			float ringFingerMCPDominantF1F2SpatialAngle = float.NaN;
			float ringFingerMCPDominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerMCPDominantF1FNSpatialAngle = float.NaN;
			float ringFingerMCPDominantTotalVectorAngle = float.NaN;
			float ringFingerMCPDominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerMCPDominantTotalVectorDisplacement = float.NaN;
			float ringFingerMCPDominantTotalDisplacement = float.NaN;
			float ringFingerMCPDominantMaximumDisplacement = float.NaN;
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
			float ringFingerPIPDominantF1F2SpatialAngle = float.NaN;
			float ringFingerPIPDominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerPIPDominantF1FNSpatialAngle = float.NaN;
			float ringFingerPIPDominantTotalVectorAngle = float.NaN;
			float ringFingerPIPDominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerPIPDominantTotalVectorDisplacement = float.NaN;
			float ringFingerPIPDominantTotalDisplacement = float.NaN;
			float ringFingerPIPDominantMaximumDisplacement = float.NaN;
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
			float ringFingerDIPDominantF1F2SpatialAngle = float.NaN;
			float ringFingerDIPDominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerDIPDominantF1FNSpatialAngle = float.NaN;
			float ringFingerDIPDominantTotalVectorAngle = float.NaN;
			float ringFingerDIPDominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerDIPDominantTotalVectorDisplacement = float.NaN;
			float ringFingerDIPDominantTotalDisplacement = float.NaN;
			float ringFingerDIPDominantMaximumDisplacement = float.NaN;
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
			float ringFingerTIPDominantF1F2SpatialAngle = float.NaN;
			float ringFingerTIPDominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerTIPDominantF1FNSpatialAngle = float.NaN;
			float ringFingerTIPDominantTotalVectorAngle = float.NaN;
			float ringFingerTIPDominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerTIPDominantTotalVectorDisplacement = float.NaN;
			float ringFingerTIPDominantTotalDisplacement = float.NaN;
			float ringFingerTIPDominantMaximumDisplacement = float.NaN;
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
			float pinkyMCPDominantF1F2SpatialAngle = float.NaN;
			float pinkyMCPDominantFN_1FNSpatialAngle = float.NaN;
			float pinkyMCPDominantF1FNSpatialAngle = float.NaN;
			float pinkyMCPDominantTotalVectorAngle = float.NaN;
			float pinkyMCPDominantSquaredTotalVectorAngle = float.NaN;
			float pinkyMCPDominantTotalVectorDisplacement = float.NaN;
			float pinkyMCPDominantTotalDisplacement = float.NaN;
			float pinkyMCPDominantMaximumDisplacement = float.NaN;
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
			float pinkyPIPDominantF1F2SpatialAngle = float.NaN;
			float pinkyPIPDominantFN_1FNSpatialAngle = float.NaN;
			float pinkyPIPDominantF1FNSpatialAngle = float.NaN;
			float pinkyPIPDominantTotalVectorAngle = float.NaN;
			float pinkyPIPDominantSquaredTotalVectorAngle = float.NaN;
			float pinkyPIPDominantTotalVectorDisplacement = float.NaN;
			float pinkyPIPDominantTotalDisplacement = float.NaN;
			float pinkyPIPDominantMaximumDisplacement = float.NaN;
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
			float pinkyDIPDominantF1F2SpatialAngle = float.NaN;
			float pinkyDIPDominantFN_1FNSpatialAngle = float.NaN;
			float pinkyDIPDominantF1FNSpatialAngle = float.NaN;
			float pinkyDIPDominantTotalVectorAngle = float.NaN;
			float pinkyDIPDominantSquaredTotalVectorAngle = float.NaN;
			float pinkyDIPDominantTotalVectorDisplacement = float.NaN;
			float pinkyDIPDominantTotalDisplacement = float.NaN;
			float pinkyDIPDominantMaximumDisplacement = float.NaN;
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
			float pinkyTIPDominantF1F2SpatialAngle = float.NaN;
			float pinkyTIPDominantFN_1FNSpatialAngle = float.NaN;
			float pinkyTIPDominantF1FNSpatialAngle = float.NaN;
			float pinkyTIPDominantTotalVectorAngle = float.NaN;
			float pinkyTIPDominantSquaredTotalVectorAngle = float.NaN;
			float pinkyTIPDominantTotalVectorDisplacement = float.NaN;
			float pinkyTIPDominantTotalDisplacement = float.NaN;
			float pinkyTIPDominantMaximumDisplacement = float.NaN;
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
			float handDominantF1F2SpatialAngle = float.NaN;
			float handDominantFN_1FNSpatialAngle = float.NaN;
			float handDominantF1FNSpatialAngle = float.NaN;
			float handDominantTotalVectorAngle = float.NaN;
			float handDominantSquaredTotalVectorAngle = float.NaN;
			float handDominantTotalVectorDisplacement = float.NaN;
			float handDominantTotalDisplacement = float.NaN;
			float handDominantMaximumDisplacement = float.NaN;
			float handDominantBoundingBoxDiagonalLength = float.NaN;
			float handDominantBoundingBoxAngle = float.NaN;
			//HandState[] handDominantHandStates = float.NaN;
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
			float wristNondominantF1F2SpatialAngle = float.NaN;
			float wristNondominantFN_1FNSpatialAngle = float.NaN;
			float wristNondominantF1FNSpatialAngle = float.NaN;
			float wristNondominantTotalVectorAngle = float.NaN;
			float wristNondominantSquaredTotalVectorAngle = float.NaN;
			float wristNondominantTotalVectorDisplacement = float.NaN;
			float wristNondominantTotalDisplacement = float.NaN;
			float wristNondominantMaximumDisplacement = float.NaN;
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
			float thumbCMCNondominantF1F2SpatialAngle = float.NaN;
			float thumbCMCNondominantFN_1FNSpatialAngle = float.NaN;
			float thumbCMCNondominantF1FNSpatialAngle = float.NaN;
			float thumbCMCNondominantTotalVectorAngle = float.NaN;
			float thumbCMCNondominantSquaredTotalVectorAngle = float.NaN;
			float thumbCMCNondominantTotalVectorDisplacement = float.NaN;
			float thumbCMCNondominantTotalDisplacement = float.NaN;
			float thumbCMCNondominantMaximumDisplacement = float.NaN;
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
			float thumbMCPNondominantF1F2SpatialAngle = float.NaN;
			float thumbMCPNondominantFN_1FNSpatialAngle = float.NaN;
			float thumbMCPNondominantF1FNSpatialAngle = float.NaN;
			float thumbMCPNondominantTotalVectorAngle = float.NaN;
			float thumbMCPNondominantSquaredTotalVectorAngle = float.NaN;
			float thumbMCPNondominantTotalVectorDisplacement = float.NaN;
			float thumbMCPNondominantTotalDisplacement = float.NaN;
			float thumbMCPNondominantMaximumDisplacement = float.NaN;
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
			float thumbIPNondominantF1F2SpatialAngle = float.NaN;
			float thumbIPNondominantFN_1FNSpatialAngle = float.NaN;
			float thumbIPNondominantF1FNSpatialAngle = float.NaN;
			float thumbIPNondominantTotalVectorAngle = float.NaN;
			float thumbIPNondominantSquaredTotalVectorAngle = float.NaN;
			float thumbIPNondominantTotalVectorDisplacement = float.NaN;
			float thumbIPNondominantTotalDisplacement = float.NaN;
			float thumbIPNondominantMaximumDisplacement = float.NaN;
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
			float thumbTIPNondominantF1F2SpatialAngle = float.NaN;
			float thumbTIPNondominantFN_1FNSpatialAngle = float.NaN;
			float thumbTIPNondominantF1FNSpatialAngle = float.NaN;
			float thumbTIPNondominantTotalVectorAngle = float.NaN;
			float thumbTIPNondominantSquaredTotalVectorAngle = float.NaN;
			float thumbTIPNondominantTotalVectorDisplacement = float.NaN;
			float thumbTIPNondominantTotalDisplacement = float.NaN;
			float thumbTIPNondominantMaximumDisplacement = float.NaN;
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
			float indexFingerMCPNondominantF1F2SpatialAngle = float.NaN;
			float indexFingerMCPNondominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerMCPNondominantF1FNSpatialAngle = float.NaN;
			float indexFingerMCPNondominantTotalVectorAngle = float.NaN;
			float indexFingerMCPNondominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerMCPNondominantTotalVectorDisplacement = float.NaN;
			float indexFingerMCPNondominantTotalDisplacement = float.NaN;
			float indexFingerMCPNondominantMaximumDisplacement = float.NaN;
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
			float indexFingerPIPNondominantF1F2SpatialAngle = float.NaN;
			float indexFingerPIPNondominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerPIPNondominantF1FNSpatialAngle = float.NaN;
			float indexFingerPIPNondominantTotalVectorAngle = float.NaN;
			float indexFingerPIPNondominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerPIPNondominantTotalVectorDisplacement = float.NaN;
			float indexFingerPIPNondominantTotalDisplacement = float.NaN;
			float indexFingerPIPNondominantMaximumDisplacement = float.NaN;
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
			float indexFingerDIPNondominantF1F2SpatialAngle = float.NaN;
			float indexFingerDIPNondominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerDIPNondominantF1FNSpatialAngle = float.NaN;
			float indexFingerDIPNondominantTotalVectorAngle = float.NaN;
			float indexFingerDIPNondominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerDIPNondominantTotalVectorDisplacement = float.NaN;
			float indexFingerDIPNondominantTotalDisplacement = float.NaN;
			float indexFingerDIPNondominantMaximumDisplacement = float.NaN;
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
			float indexFingerTIPNondominantF1F2SpatialAngle = float.NaN;
			float indexFingerTIPNondominantFN_1FNSpatialAngle = float.NaN;
			float indexFingerTIPNondominantF1FNSpatialAngle = float.NaN;
			float indexFingerTIPNondominantTotalVectorAngle = float.NaN;
			float indexFingerTIPNondominantSquaredTotalVectorAngle = float.NaN;
			float indexFingerTIPNondominantTotalVectorDisplacement = float.NaN;
			float indexFingerTIPNondominantTotalDisplacement = float.NaN;
			float indexFingerTIPNondominantMaximumDisplacement = float.NaN;
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
			float middleFingerMCPNondominantF1F2SpatialAngle = float.NaN;
			float middleFingerMCPNondominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerMCPNondominantF1FNSpatialAngle = float.NaN;
			float middleFingerMCPNondominantTotalVectorAngle = float.NaN;
			float middleFingerMCPNondominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerMCPNondominantTotalVectorDisplacement = float.NaN;
			float middleFingerMCPNondominantTotalDisplacement = float.NaN;
			float middleFingerMCPNondominantMaximumDisplacement = float.NaN;
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
			float middleFingerPIPNondominantF1F2SpatialAngle = float.NaN;
			float middleFingerPIPNondominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerPIPNondominantF1FNSpatialAngle = float.NaN;
			float middleFingerPIPNondominantTotalVectorAngle = float.NaN;
			float middleFingerPIPNondominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerPIPNondominantTotalVectorDisplacement = float.NaN;
			float middleFingerPIPNondominantTotalDisplacement = float.NaN;
			float middleFingerPIPNondominantMaximumDisplacement = float.NaN;
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
			float middleFingerDIPNondominantF1F2SpatialAngle = float.NaN;
			float middleFingerDIPNondominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerDIPNondominantF1FNSpatialAngle = float.NaN;
			float middleFingerDIPNondominantTotalVectorAngle = float.NaN;
			float middleFingerDIPNondominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerDIPNondominantTotalVectorDisplacement = float.NaN;
			float middleFingerDIPNondominantTotalDisplacement = float.NaN;
			float middleFingerDIPNondominantMaximumDisplacement = float.NaN;
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
			float middleFingerTIPNondominantF1F2SpatialAngle = float.NaN;
			float middleFingerTIPNondominantFN_1FNSpatialAngle = float.NaN;
			float middleFingerTIPNondominantF1FNSpatialAngle = float.NaN;
			float middleFingerTIPNondominantTotalVectorAngle = float.NaN;
			float middleFingerTIPNondominantSquaredTotalVectorAngle = float.NaN;
			float middleFingerTIPNondominantTotalVectorDisplacement = float.NaN;
			float middleFingerTIPNondominantTotalDisplacement = float.NaN;
			float middleFingerTIPNondominantMaximumDisplacement = float.NaN;
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
			float ringFingerMCPNondominantF1F2SpatialAngle = float.NaN;
			float ringFingerMCPNondominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerMCPNondominantF1FNSpatialAngle = float.NaN;
			float ringFingerMCPNondominantTotalVectorAngle = float.NaN;
			float ringFingerMCPNondominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerMCPNondominantTotalVectorDisplacement = float.NaN;
			float ringFingerMCPNondominantTotalDisplacement = float.NaN;
			float ringFingerMCPNondominantMaximumDisplacement = float.NaN;
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
			float ringFingerPIPNondominantF1F2SpatialAngle = float.NaN;
			float ringFingerPIPNondominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerPIPNondominantF1FNSpatialAngle = float.NaN;
			float ringFingerPIPNondominantTotalVectorAngle = float.NaN;
			float ringFingerPIPNondominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerPIPNondominantTotalVectorDisplacement = float.NaN;
			float ringFingerPIPNondominantTotalDisplacement = float.NaN;
			float ringFingerPIPNondominantMaximumDisplacement = float.NaN;
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
			float ringFingerDIPNondominantF1F2SpatialAngle = float.NaN;
			float ringFingerDIPNondominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerDIPNondominantF1FNSpatialAngle = float.NaN;
			float ringFingerDIPNondominantTotalVectorAngle = float.NaN;
			float ringFingerDIPNondominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerDIPNondominantTotalVectorDisplacement = float.NaN;
			float ringFingerDIPNondominantTotalDisplacement = float.NaN;
			float ringFingerDIPNondominantMaximumDisplacement = float.NaN;
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
			float ringFingerTIPNondominantF1F2SpatialAngle = float.NaN;
			float ringFingerTIPNondominantFN_1FNSpatialAngle = float.NaN;
			float ringFingerTIPNondominantF1FNSpatialAngle = float.NaN;
			float ringFingerTIPNondominantTotalVectorAngle = float.NaN;
			float ringFingerTIPNondominantSquaredTotalVectorAngle = float.NaN;
			float ringFingerTIPNondominantTotalVectorDisplacement = float.NaN;
			float ringFingerTIPNondominantTotalDisplacement = float.NaN;
			float ringFingerTIPNondominantMaximumDisplacement = float.NaN;
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
			float pinkyMCPNondominantF1F2SpatialAngle = float.NaN;
			float pinkyMCPNondominantFN_1FNSpatialAngle = float.NaN;
			float pinkyMCPNondominantF1FNSpatialAngle = float.NaN;
			float pinkyMCPNondominantTotalVectorAngle = float.NaN;
			float pinkyMCPNondominantSquaredTotalVectorAngle = float.NaN;
			float pinkyMCPNondominantTotalVectorDisplacement = float.NaN;
			float pinkyMCPNondominantTotalDisplacement = float.NaN;
			float pinkyMCPNondominantMaximumDisplacement = float.NaN;
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
			float pinkyPIPNondominantF1F2SpatialAngle = float.NaN;
			float pinkyPIPNondominantFN_1FNSpatialAngle = float.NaN;
			float pinkyPIPNondominantF1FNSpatialAngle = float.NaN;
			float pinkyPIPNondominantTotalVectorAngle = float.NaN;
			float pinkyPIPNondominantSquaredTotalVectorAngle = float.NaN;
			float pinkyPIPNondominantTotalVectorDisplacement = float.NaN;
			float pinkyPIPNondominantTotalDisplacement = float.NaN;
			float pinkyPIPNondominantMaximumDisplacement = float.NaN;
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
			float pinkyDIPNondominantF1F2SpatialAngle = float.NaN;
			float pinkyDIPNondominantFN_1FNSpatialAngle = float.NaN;
			float pinkyDIPNondominantF1FNSpatialAngle = float.NaN;
			float pinkyDIPNondominantTotalVectorAngle = float.NaN;
			float pinkyDIPNondominantSquaredTotalVectorAngle = float.NaN;
			float pinkyDIPNondominantTotalVectorDisplacement = float.NaN;
			float pinkyDIPNondominantTotalDisplacement = float.NaN;
			float pinkyDIPNondominantMaximumDisplacement = float.NaN;
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
			float pinkyTIPNondominantF1F2SpatialAngle = float.NaN;
			float pinkyTIPNondominantFN_1FNSpatialAngle = float.NaN;
			float pinkyTIPNondominantF1FNSpatialAngle = float.NaN;
			float pinkyTIPNondominantTotalVectorAngle = float.NaN;
			float pinkyTIPNondominantSquaredTotalVectorAngle = float.NaN;
			float pinkyTIPNondominantTotalVectorDisplacement = float.NaN;
			float pinkyTIPNondominantTotalDisplacement = float.NaN;
			float pinkyTIPNondominantMaximumDisplacement = float.NaN;
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
			float handNondominantF1F2SpatialAngle = float.NaN;
			float handNondominantFN_1FNSpatialAngle = float.NaN;
			float handNondominantF1FNSpatialAngle = float.NaN;
			float handNondominantTotalVectorAngle = float.NaN;
			float handNondominantSquaredTotalVectorAngle = float.NaN;
			float handNondominantTotalVectorDisplacement = float.NaN;
			float handNondominantTotalDisplacement = float.NaN;
			float handNondominantMaximumDisplacement = float.NaN;
			float handNondominantBoundingBoxDiagonalLength = float.NaN;
			float handNondominantBoundingBoxAngle = float.NaN;
			//HandState[] handNondominantHandStates = float.NaN;
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
			float wristThumbCMCDominantBoneInitialAngle = float.NaN;
			float wristThumbCMCDominantBoneFinalAngle = float.NaN;
			float wristThumbCMCDominantBoneMeanAngle = float.NaN;
			float wristThumbCMCDominantBoneMaximumAngle = float.NaN;
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
			float thumbCMCThumbMCPDominantBoneInitialAngle = float.NaN;
			float thumbCMCThumbMCPDominantBoneFinalAngle = float.NaN;
			float thumbCMCThumbMCPDominantBoneMeanAngle = float.NaN;
			float thumbCMCThumbMCPDominantBoneMaximumAngle = float.NaN;
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
			float thumbMCPThumbIPDominantBoneInitialAngle = float.NaN;
			float thumbMCPThumbIPDominantBoneFinalAngle = float.NaN;
			float thumbMCPThumbIPDominantBoneMeanAngle = float.NaN;
			float thumbMCPThumbIPDominantBoneMaximumAngle = float.NaN;
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
			float thumbIPThumbTIPDominantBoneInitialAngle = float.NaN;
			float thumbIPThumbTIPDominantBoneFinalAngle = float.NaN;
			float thumbIPThumbTIPDominantBoneMeanAngle = float.NaN;
			float thumbIPThumbTIPDominantBoneMaximumAngle = float.NaN;
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
			float wristIndexFingerMCPDominantBoneInitialAngle = float.NaN;
			float wristIndexFingerMCPDominantBoneFinalAngle = float.NaN;
			float wristIndexFingerMCPDominantBoneMeanAngle = float.NaN;
			float wristIndexFingerMCPDominantBoneMaximumAngle = float.NaN;
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
			float indexFingerMCPIndexFingerPIPDominantBoneInitialAngle = float.NaN;
			float indexFingerMCPIndexFingerPIPDominantBoneFinalAngle = float.NaN;
			float indexFingerMCPIndexFingerPIPDominantBoneMeanAngle = float.NaN;
			float indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle = float.NaN;
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
			float indexFingerPIPIndexFingerDIPDominantBoneInitialAngle = float.NaN;
			float indexFingerPIPIndexFingerDIPDominantBoneFinalAngle = float.NaN;
			float indexFingerPIPIndexFingerDIPDominantBoneMeanAngle = float.NaN;
			float indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle = float.NaN;
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
			float indexFingerDIPIndexFingerTIPDominantBoneInitialAngle = float.NaN;
			float indexFingerDIPIndexFingerTIPDominantBoneFinalAngle = float.NaN;
			float indexFingerDIPIndexFingerTIPDominantBoneMeanAngle = float.NaN;
			float indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle = float.NaN;
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
			float middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle = float.NaN;
			float middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle = float.NaN;
			float middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle = float.NaN;
			float middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle = float.NaN;
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
			float middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle = float.NaN;
			float middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle = float.NaN;
			float middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle = float.NaN;
			float middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle = float.NaN;
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
			float middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle = float.NaN;
			float middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle = float.NaN;
			float middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle = float.NaN;
			float middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle = float.NaN;
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
			float ringFingerMCPRingFingerPIPDominantBoneInitialAngle = float.NaN;
			float ringFingerMCPRingFingerPIPDominantBoneFinalAngle = float.NaN;
			float ringFingerMCPRingFingerPIPDominantBoneMeanAngle = float.NaN;
			float ringFingerMCPRingFingerPIPDominantBoneMaximumAngle = float.NaN;
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
			float ringFingerPIPRingFingerDIPDominantBoneInitialAngle = float.NaN;
			float ringFingerPIPRingFingerDIPDominantBoneFinalAngle = float.NaN;
			float ringFingerPIPRingFingerDIPDominantBoneMeanAngle = float.NaN;
			float ringFingerPIPRingFingerDIPDominantBoneMaximumAngle = float.NaN;
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
			float ringFingerDIPRingFingerTIPDominantBoneInitialAngle = float.NaN;
			float ringFingerDIPRingFingerTIPDominantBoneFinalAngle = float.NaN;
			float ringFingerDIPRingFingerTIPDominantBoneMeanAngle = float.NaN;
			float ringFingerDIPRingFingerTIPDominantBoneMaximumAngle = float.NaN;
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
			float wristPinkyMCPDominantBoneInitialAngle = float.NaN;
			float wristPinkyMCPDominantBoneFinalAngle = float.NaN;
			float wristPinkyMCPDominantBoneMeanAngle = float.NaN;
			float wristPinkyMCPDominantBoneMaximumAngle = float.NaN;
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
			float pinkyMCPPinkyPIPDominantBoneInitialAngle = float.NaN;
			float pinkyMCPPinkyPIPDominantBoneFinalAngle = float.NaN;
			float pinkyMCPPinkyPIPDominantBoneMeanAngle = float.NaN;
			float pinkyMCPPinkyPIPDominantBoneMaximumAngle = float.NaN;
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
			float pinkyPIPPinkyDIPDominantBoneInitialAngle = float.NaN;
			float pinkyPIPPinkyDIPDominantBoneFinalAngle = float.NaN;
			float pinkyPIPPinkyDIPDominantBoneMeanAngle = float.NaN;
			float pinkyPIPPinkyDIPDominantBoneMaximumAngle = float.NaN;
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
			float pinkyDIPPinkyTIPDominantBoneInitialAngle = float.NaN;
			float pinkyDIPPinkyTIPDominantBoneFinalAngle = float.NaN;
			float pinkyDIPPinkyTIPDominantBoneMeanAngle = float.NaN;
			float pinkyDIPPinkyTIPDominantBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, true), out var pinkyDIPPinkyTIPDominantBoneAngleData))
			{
				pinkyDIPPinkyTIPDominantBoneInitialAngle = pinkyDIPPinkyTIPDominantBoneAngleData.InitialAngle;
				pinkyDIPPinkyTIPDominantBoneFinalAngle = pinkyDIPPinkyTIPDominantBoneAngleData.FinalAngle;
				pinkyDIPPinkyTIPDominantBoneMeanAngle = pinkyDIPPinkyTIPDominantBoneAngleData.MeanAngle;
				pinkyDIPPinkyTIPDominantBoneMaximumAngle = pinkyDIPPinkyTIPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbMCPIndexFingerMCPDominant bone features
			float thumbMCPIndexFingerMCPDominantBoneInitialAngle = float.NaN;
			float thumbMCPIndexFingerMCPDominantBoneFinalAngle = float.NaN;
			float thumbMCPIndexFingerMCPDominantBoneMeanAngle = float.NaN;
			float thumbMCPIndexFingerMCPDominantBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPRightBone,
				features.HandDominance, true), out var thumbMCPIndexFingerMCPDominantBoneAngleData))
			{
				thumbMCPIndexFingerMCPDominantBoneInitialAngle = thumbMCPIndexFingerMCPDominantBoneAngleData.InitialAngle;
				thumbMCPIndexFingerMCPDominantBoneFinalAngle = thumbMCPIndexFingerMCPDominantBoneAngleData.FinalAngle;
				thumbMCPIndexFingerMCPDominantBoneMeanAngle = thumbMCPIndexFingerMCPDominantBoneAngleData.MeanAngle;
				thumbMCPIndexFingerMCPDominantBoneMaximumAngle = thumbMCPIndexFingerMCPDominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominant bone features
			float indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle = float.NaN;
			float indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle = float.NaN;
			float indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle = float.NaN;
			float indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle = float.NaN;
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
			float middleFingerMCPRingFingerMCPDominantBoneInitialAngle = float.NaN;
			float middleFingerMCPRingFingerMCPDominantBoneFinalAngle = float.NaN;
			float middleFingerMCPRingFingerMCPDominantBoneMeanAngle = float.NaN;
			float middleFingerMCPRingFingerMCPDominantBoneMaximumAngle = float.NaN;
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
			float ringFingerMCPPinkyMCPDominantBoneInitialAngle = float.NaN;
			float ringFingerMCPPinkyMCPDominantBoneFinalAngle = float.NaN;
			float ringFingerMCPPinkyMCPDominantBoneMeanAngle = float.NaN;
			float ringFingerMCPPinkyMCPDominantBoneMaximumAngle = float.NaN;
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
			float wristThumbCMCNondominantBoneInitialAngle = float.NaN;
			float wristThumbCMCNondominantBoneFinalAngle = float.NaN;
			float wristThumbCMCNondominantBoneMeanAngle = float.NaN;
			float wristThumbCMCNondominantBoneMaximumAngle = float.NaN;
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
			float thumbCMCThumbMCPNondominantBoneInitialAngle = float.NaN;
			float thumbCMCThumbMCPNondominantBoneFinalAngle = float.NaN;
			float thumbCMCThumbMCPNondominantBoneMeanAngle = float.NaN;
			float thumbCMCThumbMCPNondominantBoneMaximumAngle = float.NaN;
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
			float thumbMCPThumbIPNondominantBoneInitialAngle = float.NaN;
			float thumbMCPThumbIPNondominantBoneFinalAngle = float.NaN;
			float thumbMCPThumbIPNondominantBoneMeanAngle = float.NaN;
			float thumbMCPThumbIPNondominantBoneMaximumAngle = float.NaN;
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
			float thumbIPThumbTIPNondominantBoneInitialAngle = float.NaN;
			float thumbIPThumbTIPNondominantBoneFinalAngle = float.NaN;
			float thumbIPThumbTIPNondominantBoneMeanAngle = float.NaN;
			float thumbIPThumbTIPNondominantBoneMaximumAngle = float.NaN;
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
			float wristIndexFingerMCPNondominantBoneInitialAngle = float.NaN;
			float wristIndexFingerMCPNondominantBoneFinalAngle = float.NaN;
			float wristIndexFingerMCPNondominantBoneMeanAngle = float.NaN;
			float wristIndexFingerMCPNondominantBoneMaximumAngle = float.NaN;
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
			float indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle = float.NaN;
			float indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle = float.NaN;
			float indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle = float.NaN;
			float indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle = float.NaN;
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
			float indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle = float.NaN;
			float indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle = float.NaN;
			float indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle = float.NaN;
			float indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle = float.NaN;
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
			float indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle = float.NaN;
			float indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle = float.NaN;
			float indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle = float.NaN;
			float indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle = float.NaN;
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
			float middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle = float.NaN;
			float middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle = float.NaN;
			float middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle = float.NaN;
			float middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle = float.NaN;
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
			float middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle = float.NaN;
			float middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle = float.NaN;
			float middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle = float.NaN;
			float middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle = float.NaN;
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
			float middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle = float.NaN;
			float middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle = float.NaN;
			float middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle = float.NaN;
			float middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle = float.NaN;
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
			float ringFingerMCPRingFingerPIPNondominantBoneInitialAngle = float.NaN;
			float ringFingerMCPRingFingerPIPNondominantBoneFinalAngle = float.NaN;
			float ringFingerMCPRingFingerPIPNondominantBoneMeanAngle = float.NaN;
			float ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle = float.NaN;
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
			float ringFingerPIPRingFingerDIPNondominantBoneInitialAngle = float.NaN;
			float ringFingerPIPRingFingerDIPNondominantBoneFinalAngle = float.NaN;
			float ringFingerPIPRingFingerDIPNondominantBoneMeanAngle = float.NaN;
			float ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle = float.NaN;
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
			float ringFingerDIPRingFingerTIPNondominantBoneInitialAngle = float.NaN;
			float ringFingerDIPRingFingerTIPNondominantBoneFinalAngle = float.NaN;
			float ringFingerDIPRingFingerTIPNondominantBoneMeanAngle = float.NaN;
			float ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle = float.NaN;
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
			float wristPinkyMCPNondominantBoneInitialAngle = float.NaN;
			float wristPinkyMCPNondominantBoneFinalAngle = float.NaN;
			float wristPinkyMCPNondominantBoneMeanAngle = float.NaN;
			float wristPinkyMCPNondominantBoneMaximumAngle = float.NaN;
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
			float pinkyMCPPinkyPIPNondominantBoneInitialAngle = float.NaN;
			float pinkyMCPPinkyPIPNondominantBoneFinalAngle = float.NaN;
			float pinkyMCPPinkyPIPNondominantBoneMeanAngle = float.NaN;
			float pinkyMCPPinkyPIPNondominantBoneMaximumAngle = float.NaN;
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
			float pinkyPIPPinkyDIPNondominantBoneInitialAngle = float.NaN;
			float pinkyPIPPinkyDIPNondominantBoneFinalAngle = float.NaN;
			float pinkyPIPPinkyDIPNondominantBoneMeanAngle = float.NaN;
			float pinkyPIPPinkyDIPNondominantBoneMaximumAngle = float.NaN;
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
			float pinkyDIPPinkyTIPNondominantBoneInitialAngle = float.NaN;
			float pinkyDIPPinkyTIPNondominantBoneFinalAngle = float.NaN;
			float pinkyDIPPinkyTIPNondominantBoneMeanAngle = float.NaN;
			float pinkyDIPPinkyTIPNondominantBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, true), out var pinkyDIPPinkyTIPNondominantBoneAngleData))
			{
				pinkyDIPPinkyTIPNondominantBoneInitialAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.InitialAngle;
				pinkyDIPPinkyTIPNondominantBoneFinalAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.FinalAngle;
				pinkyDIPPinkyTIPNondominantBoneMeanAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.MeanAngle;
				pinkyDIPPinkyTIPNondominantBoneMaximumAngle = pinkyDIPPinkyTIPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region ThumbMCPIndexFingerMCPNondominant bone features
			float thumbMCPIndexFingerMCPNondominantBoneInitialAngle = float.NaN;
			float thumbMCPIndexFingerMCPNondominantBoneFinalAngle = float.NaN;
			float thumbMCPIndexFingerMCPNondominantBoneMeanAngle = float.NaN;
			float thumbMCPIndexFingerMCPNondominantBoneMaximumAngle = float.NaN;
			if (features.BoneJointsAngleDataDict.TryGetValue(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPRightBone,
				features.HandDominance, true), out var thumbMCPIndexFingerMCPNondominantBoneAngleData))
			{
				thumbMCPIndexFingerMCPNondominantBoneInitialAngle = thumbMCPIndexFingerMCPNondominantBoneAngleData.InitialAngle;
				thumbMCPIndexFingerMCPNondominantBoneFinalAngle = thumbMCPIndexFingerMCPNondominantBoneAngleData.FinalAngle;
				thumbMCPIndexFingerMCPNondominantBoneMeanAngle = thumbMCPIndexFingerMCPNondominantBoneAngleData.MeanAngle;
				thumbMCPIndexFingerMCPNondominantBoneMaximumAngle = thumbMCPIndexFingerMCPNondominantBoneAngleData.MaximumAngle;
			}
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominant bone features
			float indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle = float.NaN;
			float indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle = float.NaN;
			float indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle = float.NaN;
			float indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle = float.NaN;
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
			float middleFingerMCPRingFingerMCPNondominantBoneInitialAngle = float.NaN;
			float middleFingerMCPRingFingerMCPNondominantBoneFinalAngle = float.NaN;
			float middleFingerMCPRingFingerMCPNondominantBoneMeanAngle = float.NaN;
			float middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle = float.NaN;
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
			float ringFingerMCPPinkyMCPNondominantBoneInitialAngle = float.NaN;
			float ringFingerMCPPinkyMCPNondominantBoneFinalAngle = float.NaN;
			float ringFingerMCPPinkyMCPNondominantBoneMeanAngle = float.NaN;
			float ringFingerMCPPinkyMCPNondominantBoneMaximumAngle = float.NaN;
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
			float betweenHandJointsDistanceMax = features.BetweenHandJointsDistanceMax;
			float betweenHandJointsDistanceMean = features.BetweenHandJointsDistanceMean;
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

				#region ThumbMCPIndexFingerMCPDominantBone bone features
				ThumbMCPIndexFingerMCPDominantBoneInitialAngle = thumbMCPIndexFingerMCPDominantBoneInitialAngle,
				ThumbMCPIndexFingerMCPDominantBoneFinalAngle = thumbMCPIndexFingerMCPDominantBoneFinalAngle,
				ThumbMCPIndexFingerMCPDominantBoneMeanAngle = thumbMCPIndexFingerMCPDominantBoneMeanAngle,
				ThumbMCPIndexFingerMCPDominantBoneMaximumAngle = thumbMCPIndexFingerMCPDominantBoneMaximumAngle,
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

				#region ThumbMCPIndexFingerMCPNondominantBone bone features
				ThumbMCPIndexFingerMCPNondominantBoneInitialAngle = thumbMCPIndexFingerMCPNondominantBoneInitialAngle,
				ThumbMCPIndexFingerMCPNondominantBoneFinalAngle = thumbMCPIndexFingerMCPNondominantBoneFinalAngle,
				ThumbMCPIndexFingerMCPNondominantBoneMeanAngle = thumbMCPIndexFingerMCPNondominantBoneMeanAngle,
				ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle = thumbMCPIndexFingerMCPNondominantBoneMaximumAngle,
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
			float wristDominantF1F2SpatialAngle = gesture.WristDominantF1F2SpatialAngle;
			float wristDominantFN_1FNSpatialAngle = gesture.WristDominantFN_1FNSpatialAngle;
			float wristDominantF1FNSpatialAngle = gesture.WristDominantF1FNSpatialAngle;
			float wristDominantTotalVectorAngle = gesture.WristDominantTotalVectorAngle;
			float wristDominantSquaredTotalVectorAngle = gesture.WristDominantSquaredTotalVectorAngle;
			float wristDominantTotalVectorDisplacement = gesture.WristDominantTotalVectorDisplacement;
			float wristDominantTotalDisplacement = gesture.WristDominantTotalDisplacement;
			float wristDominantMaximumDisplacement = gesture.WristDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.WristLeft, JointType.WristRight, features.HandDominance, true), 
				new JointGestureFeatures(wristDominantF1F2SpatialAngle, wristDominantFN_1FNSpatialAngle, wristDominantF1FNSpatialAngle,
				wristDominantTotalVectorAngle, wristDominantSquaredTotalVectorAngle,
				wristDominantTotalVectorDisplacement, wristDominantTotalDisplacement, wristDominantMaximumDisplacement));
			#endregion

			#region ThumbCMCDominant joint features
			float thumbCMCDominantF1F2SpatialAngle = gesture.ThumbCMCDominantF1F2SpatialAngle;
			float thumbCMCDominantFN_1FNSpatialAngle = gesture.ThumbCMCDominantFN_1FNSpatialAngle;
			float thumbCMCDominantF1FNSpatialAngle = gesture.ThumbCMCDominantF1FNSpatialAngle;
			float thumbCMCDominantTotalVectorAngle = gesture.ThumbCMCDominantTotalVectorAngle;
			float thumbCMCDominantSquaredTotalVectorAngle = gesture.ThumbCMCDominantSquaredTotalVectorAngle;
			float thumbCMCDominantTotalVectorDisplacement = gesture.ThumbCMCDominantTotalVectorDisplacement;
			float thumbCMCDominantTotalDisplacement = gesture.ThumbCMCDominantTotalDisplacement;
			float thumbCMCDominantMaximumDisplacement = gesture.ThumbCMCDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbCMCLeft, JointType.ThumbCMCRight, features.HandDominance, true),
				new JointGestureFeatures(thumbCMCDominantF1F2SpatialAngle, thumbCMCDominantFN_1FNSpatialAngle, thumbCMCDominantF1FNSpatialAngle,
				thumbCMCDominantTotalVectorAngle, thumbCMCDominantSquaredTotalVectorAngle,
				thumbCMCDominantTotalVectorDisplacement, thumbCMCDominantTotalDisplacement, thumbCMCDominantMaximumDisplacement));
			#endregion

			#region ThumbMCPDominant joint features
			float thumbMCPDominantF1F2SpatialAngle = gesture.ThumbMCPDominantF1F2SpatialAngle;
			float thumbMCPDominantFN_1FNSpatialAngle = gesture.ThumbMCPDominantFN_1FNSpatialAngle;
			float thumbMCPDominantF1FNSpatialAngle = gesture.ThumbMCPDominantF1FNSpatialAngle;
			float thumbMCPDominantTotalVectorAngle = gesture.ThumbMCPDominantTotalVectorAngle;
			float thumbMCPDominantSquaredTotalVectorAngle = gesture.ThumbMCPDominantSquaredTotalVectorAngle;
			float thumbMCPDominantTotalVectorDisplacement = gesture.ThumbMCPDominantTotalVectorDisplacement;
			float thumbMCPDominantTotalDisplacement = gesture.ThumbMCPDominantTotalDisplacement;
			float thumbMCPDominantMaximumDisplacement = gesture.ThumbMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbMCPLeft, JointType.ThumbMCPRight, features.HandDominance, true),
				new JointGestureFeatures(thumbMCPDominantF1F2SpatialAngle, thumbMCPDominantFN_1FNSpatialAngle, thumbMCPDominantF1FNSpatialAngle,
				thumbMCPDominantTotalVectorAngle, thumbMCPDominantSquaredTotalVectorAngle,
				thumbMCPDominantTotalVectorDisplacement, thumbMCPDominantTotalDisplacement, thumbMCPDominantMaximumDisplacement));
			#endregion

			#region ThumbIPDominant joint features
			float thumbIPDominantF1F2SpatialAngle = gesture.ThumbIPDominantF1F2SpatialAngle;
			float thumbIPDominantFN_1FNSpatialAngle = gesture.ThumbIPDominantFN_1FNSpatialAngle;
			float thumbIPDominantF1FNSpatialAngle = gesture.ThumbIPDominantF1FNSpatialAngle;
			float thumbIPDominantTotalVectorAngle = gesture.ThumbIPDominantTotalVectorAngle;
			float thumbIPDominantSquaredTotalVectorAngle = gesture.ThumbIPDominantSquaredTotalVectorAngle;
			float thumbIPDominantTotalVectorDisplacement = gesture.ThumbIPDominantTotalVectorDisplacement;
			float thumbIPDominantTotalDisplacement = gesture.ThumbIPDominantTotalDisplacement;
			float thumbIPDominantMaximumDisplacement = gesture.ThumbIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbIPLeft, JointType.ThumbIPRight, features.HandDominance, true),
				new JointGestureFeatures(thumbIPDominantF1F2SpatialAngle, thumbIPDominantFN_1FNSpatialAngle, thumbIPDominantF1FNSpatialAngle,
				thumbIPDominantTotalVectorAngle, thumbIPDominantSquaredTotalVectorAngle,
				thumbIPDominantTotalVectorDisplacement, thumbIPDominantTotalDisplacement, thumbIPDominantMaximumDisplacement));
			#endregion

			#region ThumbTIPDominant joint features
			float thumbTIPDominantF1F2SpatialAngle = gesture.ThumbTIPDominantF1F2SpatialAngle;
			float thumbTIPDominantFN_1FNSpatialAngle = gesture.ThumbTIPDominantFN_1FNSpatialAngle;
			float thumbTIPDominantF1FNSpatialAngle = gesture.ThumbTIPDominantF1FNSpatialAngle;
			float thumbTIPDominantTotalVectorAngle = gesture.ThumbTIPDominantTotalVectorAngle;
			float thumbTIPDominantSquaredTotalVectorAngle = gesture.ThumbTIPDominantSquaredTotalVectorAngle;
			float thumbTIPDominantTotalVectorDisplacement = gesture.ThumbTIPDominantTotalVectorDisplacement;
			float thumbTIPDominantTotalDisplacement = gesture.ThumbTIPDominantTotalDisplacement;
			float thumbTIPDominantMaximumDisplacement = gesture.ThumbTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbTIPLeft, JointType.ThumbTIPRight, features.HandDominance, true),
				new JointGestureFeatures(thumbTIPDominantF1F2SpatialAngle, thumbTIPDominantFN_1FNSpatialAngle, thumbTIPDominantF1FNSpatialAngle,
				thumbTIPDominantTotalVectorAngle, thumbTIPDominantSquaredTotalVectorAngle,
				thumbTIPDominantTotalVectorDisplacement, thumbTIPDominantTotalDisplacement, thumbTIPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerMCPDominant joint features
			float indexFingerMCPDominantF1F2SpatialAngle = gesture.IndexFingerMCPDominantF1F2SpatialAngle;
			float indexFingerMCPDominantFN_1FNSpatialAngle = gesture.IndexFingerMCPDominantFN_1FNSpatialAngle;
			float indexFingerMCPDominantF1FNSpatialAngle = gesture.IndexFingerMCPDominantF1FNSpatialAngle;
			float indexFingerMCPDominantTotalVectorAngle = gesture.IndexFingerMCPDominantTotalVectorAngle;
			float indexFingerMCPDominantSquaredTotalVectorAngle = gesture.IndexFingerMCPDominantSquaredTotalVectorAngle;
			float indexFingerMCPDominantTotalVectorDisplacement = gesture.IndexFingerMCPDominantTotalVectorDisplacement;
			float indexFingerMCPDominantTotalDisplacement = gesture.IndexFingerMCPDominantTotalDisplacement;
			float indexFingerMCPDominantMaximumDisplacement = gesture.IndexFingerMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerMCPDominantF1F2SpatialAngle, indexFingerMCPDominantFN_1FNSpatialAngle, indexFingerMCPDominantF1FNSpatialAngle,
				indexFingerMCPDominantTotalVectorAngle, indexFingerMCPDominantSquaredTotalVectorAngle,
				indexFingerMCPDominantTotalVectorDisplacement, indexFingerMCPDominantTotalDisplacement, indexFingerMCPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerPIPDominant joint features
			float indexFingerPIPDominantF1F2SpatialAngle = gesture.IndexFingerPIPDominantF1F2SpatialAngle;
			float indexFingerPIPDominantFN_1FNSpatialAngle = gesture.IndexFingerPIPDominantFN_1FNSpatialAngle;
			float indexFingerPIPDominantF1FNSpatialAngle = gesture.IndexFingerPIPDominantF1FNSpatialAngle;
			float indexFingerPIPDominantTotalVectorAngle = gesture.IndexFingerPIPDominantTotalVectorAngle;
			float indexFingerPIPDominantSquaredTotalVectorAngle = gesture.IndexFingerPIPDominantSquaredTotalVectorAngle;
			float indexFingerPIPDominantTotalVectorDisplacement = gesture.IndexFingerPIPDominantTotalVectorDisplacement;
			float indexFingerPIPDominantTotalDisplacement = gesture.IndexFingerPIPDominantTotalDisplacement;
			float indexFingerPIPDominantMaximumDisplacement = gesture.IndexFingerPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerPIPDominantF1F2SpatialAngle, indexFingerPIPDominantFN_1FNSpatialAngle, indexFingerPIPDominantF1FNSpatialAngle,
				indexFingerPIPDominantTotalVectorAngle, indexFingerPIPDominantSquaredTotalVectorAngle,
				indexFingerPIPDominantTotalVectorDisplacement, indexFingerPIPDominantTotalDisplacement, indexFingerPIPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerDIPDominant joint features
			float indexFingerDIPDominantF1F2SpatialAngle = gesture.IndexFingerDIPDominantF1F2SpatialAngle;
			float indexFingerDIPDominantFN_1FNSpatialAngle = gesture.IndexFingerDIPDominantFN_1FNSpatialAngle;
			float indexFingerDIPDominantF1FNSpatialAngle = gesture.IndexFingerDIPDominantF1FNSpatialAngle;
			float indexFingerDIPDominantTotalVectorAngle = gesture.IndexFingerDIPDominantTotalVectorAngle;
			float indexFingerDIPDominantSquaredTotalVectorAngle = gesture.IndexFingerDIPDominantSquaredTotalVectorAngle;
			float indexFingerDIPDominantTotalVectorDisplacement = gesture.IndexFingerDIPDominantTotalVectorDisplacement;
			float indexFingerDIPDominantTotalDisplacement = gesture.IndexFingerDIPDominantTotalDisplacement;
			float indexFingerDIPDominantMaximumDisplacement = gesture.IndexFingerDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerDIPDominantF1F2SpatialAngle, indexFingerDIPDominantFN_1FNSpatialAngle, indexFingerDIPDominantF1FNSpatialAngle,
				indexFingerDIPDominantTotalVectorAngle, indexFingerDIPDominantSquaredTotalVectorAngle,
				indexFingerDIPDominantTotalVectorDisplacement, indexFingerDIPDominantTotalDisplacement, indexFingerDIPDominantMaximumDisplacement));
			#endregion

			#region IndexFingerTIPDominant joint features
			float indexFingerTIPDominantF1F2SpatialAngle = gesture.IndexFingerTIPDominantF1F2SpatialAngle;
			float indexFingerTIPDominantFN_1FNSpatialAngle = gesture.IndexFingerTIPDominantFN_1FNSpatialAngle;
			float indexFingerTIPDominantF1FNSpatialAngle = gesture.IndexFingerTIPDominantF1FNSpatialAngle;
			float indexFingerTIPDominantTotalVectorAngle = gesture.IndexFingerTIPDominantTotalVectorAngle;
			float indexFingerTIPDominantSquaredTotalVectorAngle = gesture.IndexFingerTIPDominantSquaredTotalVectorAngle;
			float indexFingerTIPDominantTotalVectorDisplacement = gesture.IndexFingerTIPDominantTotalVectorDisplacement;
			float indexFingerTIPDominantTotalDisplacement = gesture.IndexFingerTIPDominantTotalDisplacement;
			float indexFingerTIPDominantMaximumDisplacement = gesture.IndexFingerTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight, features.HandDominance, true),
				new JointGestureFeatures(indexFingerTIPDominantF1F2SpatialAngle, indexFingerTIPDominantFN_1FNSpatialAngle, indexFingerTIPDominantF1FNSpatialAngle,
				indexFingerTIPDominantTotalVectorAngle, indexFingerTIPDominantSquaredTotalVectorAngle,
				indexFingerTIPDominantTotalVectorDisplacement, indexFingerTIPDominantTotalDisplacement, indexFingerTIPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerMCPDominant joint features
			float middleFingerMCPDominantF1F2SpatialAngle = gesture.MiddleFingerMCPDominantF1F2SpatialAngle;
			float middleFingerMCPDominantFN_1FNSpatialAngle = gesture.MiddleFingerMCPDominantFN_1FNSpatialAngle;
			float middleFingerMCPDominantF1FNSpatialAngle = gesture.MiddleFingerMCPDominantF1FNSpatialAngle;
			float middleFingerMCPDominantTotalVectorAngle = gesture.MiddleFingerMCPDominantTotalVectorAngle;
			float middleFingerMCPDominantSquaredTotalVectorAngle = gesture.MiddleFingerMCPDominantSquaredTotalVectorAngle;
			float middleFingerMCPDominantTotalVectorDisplacement = gesture.MiddleFingerMCPDominantTotalVectorDisplacement;
			float middleFingerMCPDominantTotalDisplacement = gesture.MiddleFingerMCPDominantTotalDisplacement;
			float middleFingerMCPDominantMaximumDisplacement = gesture.MiddleFingerMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerMCPDominantF1F2SpatialAngle, middleFingerMCPDominantFN_1FNSpatialAngle, middleFingerMCPDominantF1FNSpatialAngle,
				middleFingerMCPDominantTotalVectorAngle, middleFingerMCPDominantSquaredTotalVectorAngle,
				middleFingerMCPDominantTotalVectorDisplacement, middleFingerMCPDominantTotalDisplacement, middleFingerMCPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerPIPDominant joint features
			float middleFingerPIPDominantF1F2SpatialAngle = gesture.MiddleFingerPIPDominantF1F2SpatialAngle;
			float middleFingerPIPDominantFN_1FNSpatialAngle = gesture.MiddleFingerPIPDominantFN_1FNSpatialAngle;
			float middleFingerPIPDominantF1FNSpatialAngle = gesture.MiddleFingerPIPDominantF1FNSpatialAngle;
			float middleFingerPIPDominantTotalVectorAngle = gesture.MiddleFingerPIPDominantTotalVectorAngle;
			float middleFingerPIPDominantSquaredTotalVectorAngle = gesture.MiddleFingerPIPDominantSquaredTotalVectorAngle;
			float middleFingerPIPDominantTotalVectorDisplacement = gesture.MiddleFingerPIPDominantTotalVectorDisplacement;
			float middleFingerPIPDominantTotalDisplacement = gesture.MiddleFingerPIPDominantTotalDisplacement;
			float middleFingerPIPDominantMaximumDisplacement = gesture.MiddleFingerPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerPIPDominantF1F2SpatialAngle, middleFingerPIPDominantFN_1FNSpatialAngle, middleFingerPIPDominantF1FNSpatialAngle,
				middleFingerPIPDominantTotalVectorAngle, middleFingerPIPDominantSquaredTotalVectorAngle,
				middleFingerPIPDominantTotalVectorDisplacement, middleFingerPIPDominantTotalDisplacement, middleFingerPIPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerDIPDominant joint features
			float middleFingerDIPDominantF1F2SpatialAngle = gesture.MiddleFingerDIPDominantF1F2SpatialAngle;
			float middleFingerDIPDominantFN_1FNSpatialAngle = gesture.MiddleFingerDIPDominantFN_1FNSpatialAngle;
			float middleFingerDIPDominantF1FNSpatialAngle = gesture.MiddleFingerDIPDominantF1FNSpatialAngle;
			float middleFingerDIPDominantTotalVectorAngle = gesture.MiddleFingerDIPDominantTotalVectorAngle;
			float middleFingerDIPDominantSquaredTotalVectorAngle = gesture.MiddleFingerDIPDominantSquaredTotalVectorAngle;
			float middleFingerDIPDominantTotalVectorDisplacement = gesture.MiddleFingerDIPDominantTotalVectorDisplacement;
			float middleFingerDIPDominantTotalDisplacement = gesture.MiddleFingerDIPDominantTotalDisplacement;
			float middleFingerDIPDominantMaximumDisplacement = gesture.MiddleFingerDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerDIPDominantF1F2SpatialAngle, middleFingerDIPDominantFN_1FNSpatialAngle, middleFingerDIPDominantF1FNSpatialAngle,
				middleFingerDIPDominantTotalVectorAngle, middleFingerDIPDominantSquaredTotalVectorAngle,
				middleFingerDIPDominantTotalVectorDisplacement, middleFingerDIPDominantTotalDisplacement, middleFingerDIPDominantMaximumDisplacement));
			#endregion

			#region MiddleFingerTIPDominant joint features
			float middleFingerTIPDominantF1F2SpatialAngle = gesture.MiddleFingerTIPDominantF1F2SpatialAngle;
			float middleFingerTIPDominantFN_1FNSpatialAngle = gesture.MiddleFingerTIPDominantFN_1FNSpatialAngle;
			float middleFingerTIPDominantF1FNSpatialAngle = gesture.MiddleFingerTIPDominantF1FNSpatialAngle;
			float middleFingerTIPDominantTotalVectorAngle = gesture.MiddleFingerTIPDominantTotalVectorAngle;
			float middleFingerTIPDominantSquaredTotalVectorAngle = gesture.MiddleFingerTIPDominantSquaredTotalVectorAngle;
			float middleFingerTIPDominantTotalVectorDisplacement = gesture.MiddleFingerTIPDominantTotalVectorDisplacement;
			float middleFingerTIPDominantTotalDisplacement = gesture.MiddleFingerTIPDominantTotalDisplacement;
			float middleFingerTIPDominantMaximumDisplacement = gesture.MiddleFingerTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight, features.HandDominance, true),
				new JointGestureFeatures(middleFingerTIPDominantF1F2SpatialAngle, middleFingerTIPDominantFN_1FNSpatialAngle, middleFingerTIPDominantF1FNSpatialAngle,
				middleFingerTIPDominantTotalVectorAngle, middleFingerTIPDominantSquaredTotalVectorAngle,
				middleFingerTIPDominantTotalVectorDisplacement, middleFingerTIPDominantTotalDisplacement, middleFingerTIPDominantMaximumDisplacement));
			#endregion

			#region RingFingerMCPDominant joint features
			float ringFingerMCPDominantF1F2SpatialAngle = gesture.RingFingerMCPDominantF1F2SpatialAngle;
			float ringFingerMCPDominantFN_1FNSpatialAngle = gesture.RingFingerMCPDominantFN_1FNSpatialAngle;
			float ringFingerMCPDominantF1FNSpatialAngle = gesture.RingFingerMCPDominantF1FNSpatialAngle;
			float ringFingerMCPDominantTotalVectorAngle = gesture.RingFingerMCPDominantTotalVectorAngle;
			float ringFingerMCPDominantSquaredTotalVectorAngle = gesture.RingFingerMCPDominantSquaredTotalVectorAngle;
			float ringFingerMCPDominantTotalVectorDisplacement = gesture.RingFingerMCPDominantTotalVectorDisplacement;
			float ringFingerMCPDominantTotalDisplacement = gesture.RingFingerMCPDominantTotalDisplacement;
			float ringFingerMCPDominantMaximumDisplacement = gesture.RingFingerMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerMCPDominantF1F2SpatialAngle, ringFingerMCPDominantFN_1FNSpatialAngle, ringFingerMCPDominantF1FNSpatialAngle,
				ringFingerMCPDominantTotalVectorAngle, ringFingerMCPDominantSquaredTotalVectorAngle,
				ringFingerMCPDominantTotalVectorDisplacement, ringFingerMCPDominantTotalDisplacement, ringFingerMCPDominantMaximumDisplacement));
			#endregion

			#region RingFingerPIPDominant joint features
			float ringFingerPIPDominantF1F2SpatialAngle = gesture.RingFingerPIPDominantF1F2SpatialAngle;
			float ringFingerPIPDominantFN_1FNSpatialAngle = gesture.RingFingerPIPDominantFN_1FNSpatialAngle;
			float ringFingerPIPDominantF1FNSpatialAngle = gesture.RingFingerPIPDominantF1FNSpatialAngle;
			float ringFingerPIPDominantTotalVectorAngle = gesture.RingFingerPIPDominantTotalVectorAngle;
			float ringFingerPIPDominantSquaredTotalVectorAngle = gesture.RingFingerPIPDominantSquaredTotalVectorAngle;
			float ringFingerPIPDominantTotalVectorDisplacement = gesture.RingFingerPIPDominantTotalVectorDisplacement;
			float ringFingerPIPDominantTotalDisplacement = gesture.RingFingerPIPDominantTotalDisplacement;
			float ringFingerPIPDominantMaximumDisplacement = gesture.RingFingerPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerPIPDominantF1F2SpatialAngle, ringFingerPIPDominantFN_1FNSpatialAngle, ringFingerPIPDominantF1FNSpatialAngle,
				ringFingerPIPDominantTotalVectorAngle, ringFingerPIPDominantSquaredTotalVectorAngle,
				ringFingerPIPDominantTotalVectorDisplacement, ringFingerPIPDominantTotalDisplacement, ringFingerPIPDominantMaximumDisplacement));
			#endregion

			#region RingFingerDIPDominant joint features
			float ringFingerDIPDominantF1F2SpatialAngle = gesture.RingFingerDIPDominantF1F2SpatialAngle;
			float ringFingerDIPDominantFN_1FNSpatialAngle = gesture.RingFingerDIPDominantFN_1FNSpatialAngle;
			float ringFingerDIPDominantF1FNSpatialAngle = gesture.RingFingerDIPDominantF1FNSpatialAngle;
			float ringFingerDIPDominantTotalVectorAngle = gesture.RingFingerDIPDominantTotalVectorAngle;
			float ringFingerDIPDominantSquaredTotalVectorAngle = gesture.RingFingerDIPDominantSquaredTotalVectorAngle;
			float ringFingerDIPDominantTotalVectorDisplacement = gesture.RingFingerDIPDominantTotalVectorDisplacement;
			float ringFingerDIPDominantTotalDisplacement = gesture.RingFingerDIPDominantTotalDisplacement;
			float ringFingerDIPDominantMaximumDisplacement = gesture.RingFingerDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerDIPDominantF1F2SpatialAngle, ringFingerDIPDominantFN_1FNSpatialAngle, ringFingerDIPDominantF1FNSpatialAngle,
				ringFingerDIPDominantTotalVectorAngle, ringFingerDIPDominantSquaredTotalVectorAngle,
				ringFingerDIPDominantTotalVectorDisplacement, ringFingerDIPDominantTotalDisplacement, ringFingerDIPDominantMaximumDisplacement));
			#endregion

			#region RingFingerTIPDominant joint features
			float ringFingerTIPDominantF1F2SpatialAngle = gesture.RingFingerTIPDominantF1F2SpatialAngle;
			float ringFingerTIPDominantFN_1FNSpatialAngle = gesture.RingFingerTIPDominantFN_1FNSpatialAngle;
			float ringFingerTIPDominantF1FNSpatialAngle = gesture.RingFingerTIPDominantF1FNSpatialAngle;
			float ringFingerTIPDominantTotalVectorAngle = gesture.RingFingerTIPDominantTotalVectorAngle;
			float ringFingerTIPDominantSquaredTotalVectorAngle = gesture.RingFingerTIPDominantSquaredTotalVectorAngle;
			float ringFingerTIPDominantTotalVectorDisplacement = gesture.RingFingerTIPDominantTotalVectorDisplacement;
			float ringFingerTIPDominantTotalDisplacement = gesture.RingFingerTIPDominantTotalDisplacement;
			float ringFingerTIPDominantMaximumDisplacement = gesture.RingFingerTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight, features.HandDominance, true),
				new JointGestureFeatures(ringFingerTIPDominantF1F2SpatialAngle, ringFingerTIPDominantFN_1FNSpatialAngle, ringFingerTIPDominantF1FNSpatialAngle,
				ringFingerTIPDominantTotalVectorAngle, ringFingerTIPDominantSquaredTotalVectorAngle,
				ringFingerTIPDominantTotalVectorDisplacement, ringFingerTIPDominantTotalDisplacement, ringFingerTIPDominantMaximumDisplacement));
			#endregion

			#region PinkyMCPDominant joint features
			float pinkyMCPDominantF1F2SpatialAngle = gesture.PinkyMCPDominantF1F2SpatialAngle;
			float pinkyMCPDominantFN_1FNSpatialAngle = gesture.PinkyMCPDominantFN_1FNSpatialAngle;
			float pinkyMCPDominantF1FNSpatialAngle = gesture.PinkyMCPDominantF1FNSpatialAngle;
			float pinkyMCPDominantTotalVectorAngle = gesture.PinkyMCPDominantTotalVectorAngle;
			float pinkyMCPDominantSquaredTotalVectorAngle = gesture.PinkyMCPDominantSquaredTotalVectorAngle;
			float pinkyMCPDominantTotalVectorDisplacement = gesture.PinkyMCPDominantTotalVectorDisplacement;
			float pinkyMCPDominantTotalDisplacement = gesture.PinkyMCPDominantTotalDisplacement;
			float pinkyMCPDominantMaximumDisplacement = gesture.PinkyMCPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyMCPLeft, JointType.PinkyMCPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyMCPDominantF1F2SpatialAngle, pinkyMCPDominantFN_1FNSpatialAngle, pinkyMCPDominantF1FNSpatialAngle,
				pinkyMCPDominantTotalVectorAngle, pinkyMCPDominantSquaredTotalVectorAngle,
				pinkyMCPDominantTotalVectorDisplacement, pinkyMCPDominantTotalDisplacement, pinkyMCPDominantMaximumDisplacement));
			#endregion

			#region PinkyPIPDominant joint features
			float pinkyPIPDominantF1F2SpatialAngle = gesture.PinkyPIPDominantF1F2SpatialAngle;
			float pinkyPIPDominantFN_1FNSpatialAngle = gesture.PinkyPIPDominantFN_1FNSpatialAngle;
			float pinkyPIPDominantF1FNSpatialAngle = gesture.PinkyPIPDominantF1FNSpatialAngle;
			float pinkyPIPDominantTotalVectorAngle = gesture.PinkyPIPDominantTotalVectorAngle;
			float pinkyPIPDominantSquaredTotalVectorAngle = gesture.PinkyPIPDominantSquaredTotalVectorAngle;
			float pinkyPIPDominantTotalVectorDisplacement = gesture.PinkyPIPDominantTotalVectorDisplacement;
			float pinkyPIPDominantTotalDisplacement = gesture.PinkyPIPDominantTotalDisplacement;
			float pinkyPIPDominantMaximumDisplacement = gesture.PinkyPIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyPIPLeft, JointType.PinkyPIPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyPIPDominantF1F2SpatialAngle, pinkyPIPDominantFN_1FNSpatialAngle, pinkyPIPDominantF1FNSpatialAngle,
				pinkyPIPDominantTotalVectorAngle, pinkyPIPDominantSquaredTotalVectorAngle,
				pinkyPIPDominantTotalVectorDisplacement, pinkyPIPDominantTotalDisplacement, pinkyPIPDominantMaximumDisplacement));
			#endregion

			#region PinkyDIPDominant joint features
			float pinkyDIPDominantF1F2SpatialAngle = gesture.PinkyDIPDominantF1F2SpatialAngle;
			float pinkyDIPDominantFN_1FNSpatialAngle = gesture.PinkyDIPDominantFN_1FNSpatialAngle;
			float pinkyDIPDominantF1FNSpatialAngle = gesture.PinkyDIPDominantF1FNSpatialAngle;
			float pinkyDIPDominantTotalVectorAngle = gesture.PinkyDIPDominantTotalVectorAngle;
			float pinkyDIPDominantSquaredTotalVectorAngle = gesture.PinkyDIPDominantSquaredTotalVectorAngle;
			float pinkyDIPDominantTotalVectorDisplacement = gesture.PinkyDIPDominantTotalVectorDisplacement;
			float pinkyDIPDominantTotalDisplacement = gesture.PinkyDIPDominantTotalDisplacement;
			float pinkyDIPDominantMaximumDisplacement = gesture.PinkyDIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyDIPLeft, JointType.PinkyDIPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyDIPDominantF1F2SpatialAngle, pinkyDIPDominantFN_1FNSpatialAngle, pinkyDIPDominantF1FNSpatialAngle,
				pinkyDIPDominantTotalVectorAngle, pinkyDIPDominantSquaredTotalVectorAngle,
				pinkyDIPDominantTotalVectorDisplacement, pinkyDIPDominantTotalDisplacement, pinkyDIPDominantMaximumDisplacement));
			#endregion

			#region PinkyTIPDominant joint features
			float pinkyTIPDominantF1F2SpatialAngle = gesture.PinkyTIPDominantF1F2SpatialAngle;
			float pinkyTIPDominantFN_1FNSpatialAngle = gesture.PinkyTIPDominantFN_1FNSpatialAngle;
			float pinkyTIPDominantF1FNSpatialAngle = gesture.PinkyTIPDominantF1FNSpatialAngle;
			float pinkyTIPDominantTotalVectorAngle = gesture.PinkyTIPDominantTotalVectorAngle;
			float pinkyTIPDominantSquaredTotalVectorAngle = gesture.PinkyTIPDominantSquaredTotalVectorAngle;
			float pinkyTIPDominantTotalVectorDisplacement = gesture.PinkyTIPDominantTotalVectorDisplacement;
			float pinkyTIPDominantTotalDisplacement = gesture.PinkyTIPDominantTotalDisplacement;
			float pinkyTIPDominantMaximumDisplacement = gesture.PinkyTIPDominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyTIPLeft, JointType.PinkyTIPRight, features.HandDominance, true),
				new JointGestureFeatures(pinkyTIPDominantF1F2SpatialAngle, pinkyTIPDominantFN_1FNSpatialAngle, pinkyTIPDominantF1FNSpatialAngle,
				pinkyTIPDominantTotalVectorAngle, pinkyTIPDominantSquaredTotalVectorAngle,
				pinkyTIPDominantTotalVectorDisplacement, pinkyTIPDominantTotalDisplacement, pinkyTIPDominantMaximumDisplacement));
			#endregion

			#region HandDominant joint features
			float handDominantF1F2SpatialAngle = gesture.HandDominantF1F2SpatialAngle;
			float handDominantFN_1FNSpatialAngle = gesture.HandDominantFN_1FNSpatialAngle;
			float handDominantF1FNSpatialAngle = gesture.HandDominantF1FNSpatialAngle;
			float handDominantTotalVectorAngle = gesture.HandDominantTotalVectorAngle;
			float handDominantSquaredTotalVectorAngle = gesture.HandDominantSquaredTotalVectorAngle;
			float handDominantTotalVectorDisplacement = gesture.HandDominantTotalVectorDisplacement;
			float handDominantTotalDisplacement = gesture.HandDominantTotalDisplacement;
			float handDominantMaximumDisplacement = gesture.HandDominantMaximumDisplacement;
			float handDominantBoundingBoxDiagonalLength = gesture.HandDominantBoundingBoxDiagonalLength;
			float handDominantBoundingBoxAngle = gesture.HandDominantBoundingBoxAngle;
			//HandState[] handDominantHandStates = gesture.HandDominantHandStates;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.HandLeft, JointType.HandRight, features.HandDominance, true), 
				new HandJointGestureFeatures(handDominantF1F2SpatialAngle, handDominantFN_1FNSpatialAngle, handDominantF1FNSpatialAngle,
				handDominantTotalVectorAngle, handDominantSquaredTotalVectorAngle,
				handDominantTotalVectorDisplacement, handDominantTotalDisplacement, handDominantMaximumDisplacement,
				handDominantBoundingBoxDiagonalLength, handDominantBoundingBoxAngle/*, handDominantHandStates*/));
			#endregion

			#region WristNondominant joint features
			float wristNondominantF1F2SpatialAngle = gesture.WristNondominantF1F2SpatialAngle;
			float wristNondominantFN_1FNSpatialAngle = gesture.WristNondominantFN_1FNSpatialAngle;
			float wristNondominantF1FNSpatialAngle = gesture.WristNondominantF1FNSpatialAngle;
			float wristNondominantTotalVectorAngle = gesture.WristNondominantTotalVectorAngle;
			float wristNondominantSquaredTotalVectorAngle = gesture.WristNondominantSquaredTotalVectorAngle;
			float wristNondominantTotalVectorDisplacement = gesture.WristNondominantTotalVectorDisplacement;
			float wristNondominantTotalDisplacement = gesture.WristNondominantTotalDisplacement;
			float wristNondominantMaximumDisplacement = gesture.WristNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.WristLeft, JointType.WristRight, features.HandDominance, false),
				new JointGestureFeatures(wristNondominantF1F2SpatialAngle, wristNondominantFN_1FNSpatialAngle, wristNondominantF1FNSpatialAngle,
				wristNondominantTotalVectorAngle, wristNondominantSquaredTotalVectorAngle,
				wristNondominantTotalVectorDisplacement, wristNondominantTotalDisplacement, wristNondominantMaximumDisplacement));
			#endregion

			#region ThumbCMCNondominant joint features
			float thumbCMCNondominantF1F2SpatialAngle = gesture.ThumbCMCNondominantF1F2SpatialAngle;
			float thumbCMCNondominantFN_1FNSpatialAngle = gesture.ThumbCMCNondominantFN_1FNSpatialAngle;
			float thumbCMCNondominantF1FNSpatialAngle = gesture.ThumbCMCNondominantF1FNSpatialAngle;
			float thumbCMCNondominantTotalVectorAngle = gesture.ThumbCMCNondominantTotalVectorAngle;
			float thumbCMCNondominantSquaredTotalVectorAngle = gesture.ThumbCMCNondominantSquaredTotalVectorAngle;
			float thumbCMCNondominantTotalVectorDisplacement = gesture.ThumbCMCNondominantTotalVectorDisplacement;
			float thumbCMCNondominantTotalDisplacement = gesture.ThumbCMCNondominantTotalDisplacement;
			float thumbCMCNondominantMaximumDisplacement = gesture.ThumbCMCNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbCMCLeft, JointType.ThumbCMCRight, features.HandDominance, false),
				new JointGestureFeatures(thumbCMCNondominantF1F2SpatialAngle, thumbCMCNondominantFN_1FNSpatialAngle, thumbCMCNondominantF1FNSpatialAngle,
				thumbCMCNondominantTotalVectorAngle, thumbCMCNondominantSquaredTotalVectorAngle,
				thumbCMCNondominantTotalVectorDisplacement, thumbCMCNondominantTotalDisplacement, thumbCMCNondominantMaximumDisplacement));
			#endregion

			#region ThumbMCPNondominant joint features
			float thumbMCPNondominantF1F2SpatialAngle = gesture.ThumbMCPNondominantF1F2SpatialAngle;
			float thumbMCPNondominantFN_1FNSpatialAngle = gesture.ThumbMCPNondominantFN_1FNSpatialAngle;
			float thumbMCPNondominantF1FNSpatialAngle = gesture.ThumbMCPNondominantF1FNSpatialAngle;
			float thumbMCPNondominantTotalVectorAngle = gesture.ThumbMCPNondominantTotalVectorAngle;
			float thumbMCPNondominantSquaredTotalVectorAngle = gesture.ThumbMCPNondominantSquaredTotalVectorAngle;
			float thumbMCPNondominantTotalVectorDisplacement = gesture.ThumbMCPNondominantTotalVectorDisplacement;
			float thumbMCPNondominantTotalDisplacement = gesture.ThumbMCPNondominantTotalDisplacement;
			float thumbMCPNondominantMaximumDisplacement = gesture.ThumbMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbMCPLeft, JointType.ThumbMCPRight, features.HandDominance, false),
				new JointGestureFeatures(thumbMCPNondominantF1F2SpatialAngle, thumbMCPNondominantFN_1FNSpatialAngle, thumbMCPNondominantF1FNSpatialAngle,
				thumbMCPNondominantTotalVectorAngle, thumbMCPNondominantSquaredTotalVectorAngle,
				thumbMCPNondominantTotalVectorDisplacement, thumbMCPNondominantTotalDisplacement, thumbMCPNondominantMaximumDisplacement));
			#endregion

			#region ThumbIPNondominant joint features
			float thumbIPNondominantF1F2SpatialAngle = gesture.ThumbIPNondominantF1F2SpatialAngle;
			float thumbIPNondominantFN_1FNSpatialAngle = gesture.ThumbIPNondominantFN_1FNSpatialAngle;
			float thumbIPNondominantF1FNSpatialAngle = gesture.ThumbIPNondominantF1FNSpatialAngle;
			float thumbIPNondominantTotalVectorAngle = gesture.ThumbIPNondominantTotalVectorAngle;
			float thumbIPNondominantSquaredTotalVectorAngle = gesture.ThumbIPNondominantSquaredTotalVectorAngle;
			float thumbIPNondominantTotalVectorDisplacement = gesture.ThumbIPNondominantTotalVectorDisplacement;
			float thumbIPNondominantTotalDisplacement = gesture.ThumbIPNondominantTotalDisplacement;
			float thumbIPNondominantMaximumDisplacement = gesture.ThumbIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbIPLeft, JointType.ThumbIPRight, features.HandDominance, false),
				new JointGestureFeatures(thumbIPNondominantF1F2SpatialAngle, thumbIPNondominantFN_1FNSpatialAngle, thumbIPNondominantF1FNSpatialAngle,
				thumbIPNondominantTotalVectorAngle, thumbIPNondominantSquaredTotalVectorAngle,
				thumbIPNondominantTotalVectorDisplacement, thumbIPNondominantTotalDisplacement, thumbIPNondominantMaximumDisplacement));
			#endregion

			#region ThumbTIPNondominant joint features
			float thumbTIPNondominantF1F2SpatialAngle = gesture.ThumbTIPNondominantF1F2SpatialAngle;
			float thumbTIPNondominantFN_1FNSpatialAngle = gesture.ThumbTIPNondominantFN_1FNSpatialAngle;
			float thumbTIPNondominantF1FNSpatialAngle = gesture.ThumbTIPNondominantF1FNSpatialAngle;
			float thumbTIPNondominantTotalVectorAngle = gesture.ThumbTIPNondominantTotalVectorAngle;
			float thumbTIPNondominantSquaredTotalVectorAngle = gesture.ThumbTIPNondominantSquaredTotalVectorAngle;
			float thumbTIPNondominantTotalVectorDisplacement = gesture.ThumbTIPNondominantTotalVectorDisplacement;
			float thumbTIPNondominantTotalDisplacement = gesture.ThumbTIPNondominantTotalDisplacement;
			float thumbTIPNondominantMaximumDisplacement = gesture.ThumbTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.ThumbTIPLeft, JointType.ThumbTIPRight, features.HandDominance, false),
				new JointGestureFeatures(thumbTIPNondominantF1F2SpatialAngle, thumbTIPNondominantFN_1FNSpatialAngle, thumbTIPNondominantF1FNSpatialAngle,
				thumbTIPNondominantTotalVectorAngle, thumbTIPNondominantSquaredTotalVectorAngle,
				thumbTIPNondominantTotalVectorDisplacement, thumbTIPNondominantTotalDisplacement, thumbTIPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerMCPNondominant joint features
			float indexFingerMCPNondominantF1F2SpatialAngle = gesture.IndexFingerMCPNondominantF1F2SpatialAngle;
			float indexFingerMCPNondominantFN_1FNSpatialAngle = gesture.IndexFingerMCPNondominantFN_1FNSpatialAngle;
			float indexFingerMCPNondominantF1FNSpatialAngle = gesture.IndexFingerMCPNondominantF1FNSpatialAngle;
			float indexFingerMCPNondominantTotalVectorAngle = gesture.IndexFingerMCPNondominantTotalVectorAngle;
			float indexFingerMCPNondominantSquaredTotalVectorAngle = gesture.IndexFingerMCPNondominantSquaredTotalVectorAngle;
			float indexFingerMCPNondominantTotalVectorDisplacement = gesture.IndexFingerMCPNondominantTotalVectorDisplacement;
			float indexFingerMCPNondominantTotalDisplacement = gesture.IndexFingerMCPNondominantTotalDisplacement;
			float indexFingerMCPNondominantMaximumDisplacement = gesture.IndexFingerMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerMCPNondominantF1F2SpatialAngle, indexFingerMCPNondominantFN_1FNSpatialAngle, indexFingerMCPNondominantF1FNSpatialAngle,
				indexFingerMCPNondominantTotalVectorAngle, indexFingerMCPNondominantSquaredTotalVectorAngle,
				indexFingerMCPNondominantTotalVectorDisplacement, indexFingerMCPNondominantTotalDisplacement, indexFingerMCPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerPIPNondominant joint features
			float indexFingerPIPNondominantF1F2SpatialAngle = gesture.IndexFingerPIPNondominantF1F2SpatialAngle;
			float indexFingerPIPNondominantFN_1FNSpatialAngle = gesture.IndexFingerPIPNondominantFN_1FNSpatialAngle;
			float indexFingerPIPNondominantF1FNSpatialAngle = gesture.IndexFingerPIPNondominantF1FNSpatialAngle;
			float indexFingerPIPNondominantTotalVectorAngle = gesture.IndexFingerPIPNondominantTotalVectorAngle;
			float indexFingerPIPNondominantSquaredTotalVectorAngle = gesture.IndexFingerPIPNondominantSquaredTotalVectorAngle;
			float indexFingerPIPNondominantTotalVectorDisplacement = gesture.IndexFingerPIPNondominantTotalVectorDisplacement;
			float indexFingerPIPNondominantTotalDisplacement = gesture.IndexFingerPIPNondominantTotalDisplacement;
			float indexFingerPIPNondominantMaximumDisplacement = gesture.IndexFingerPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerPIPNondominantF1F2SpatialAngle, indexFingerPIPNondominantFN_1FNSpatialAngle, indexFingerPIPNondominantF1FNSpatialAngle,
				indexFingerPIPNondominantTotalVectorAngle, indexFingerPIPNondominantSquaredTotalVectorAngle,
				indexFingerPIPNondominantTotalVectorDisplacement, indexFingerPIPNondominantTotalDisplacement, indexFingerPIPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerDIPNondominant joint features
			float indexFingerDIPNondominantF1F2SpatialAngle = gesture.IndexFingerDIPNondominantF1F2SpatialAngle;
			float indexFingerDIPNondominantFN_1FNSpatialAngle = gesture.IndexFingerDIPNondominantFN_1FNSpatialAngle;
			float indexFingerDIPNondominantF1FNSpatialAngle = gesture.IndexFingerDIPNondominantF1FNSpatialAngle;
			float indexFingerDIPNondominantTotalVectorAngle = gesture.IndexFingerDIPNondominantTotalVectorAngle;
			float indexFingerDIPNondominantSquaredTotalVectorAngle = gesture.IndexFingerDIPNondominantSquaredTotalVectorAngle;
			float indexFingerDIPNondominantTotalVectorDisplacement = gesture.IndexFingerDIPNondominantTotalVectorDisplacement;
			float indexFingerDIPNondominantTotalDisplacement = gesture.IndexFingerDIPNondominantTotalDisplacement;
			float indexFingerDIPNondominantMaximumDisplacement = gesture.IndexFingerDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerDIPNondominantF1F2SpatialAngle, indexFingerDIPNondominantFN_1FNSpatialAngle, indexFingerDIPNondominantF1FNSpatialAngle,
				indexFingerDIPNondominantTotalVectorAngle, indexFingerDIPNondominantSquaredTotalVectorAngle,
				indexFingerDIPNondominantTotalVectorDisplacement, indexFingerDIPNondominantTotalDisplacement, indexFingerDIPNondominantMaximumDisplacement));
			#endregion

			#region IndexFingerTIPNondominant joint features
			float indexFingerTIPNondominantF1F2SpatialAngle = gesture.IndexFingerTIPNondominantF1F2SpatialAngle;
			float indexFingerTIPNondominantFN_1FNSpatialAngle = gesture.IndexFingerTIPNondominantFN_1FNSpatialAngle;
			float indexFingerTIPNondominantF1FNSpatialAngle = gesture.IndexFingerTIPNondominantF1FNSpatialAngle;
			float indexFingerTIPNondominantTotalVectorAngle = gesture.IndexFingerTIPNondominantTotalVectorAngle;
			float indexFingerTIPNondominantSquaredTotalVectorAngle = gesture.IndexFingerTIPNondominantSquaredTotalVectorAngle;
			float indexFingerTIPNondominantTotalVectorDisplacement = gesture.IndexFingerTIPNondominantTotalVectorDisplacement;
			float indexFingerTIPNondominantTotalDisplacement = gesture.IndexFingerTIPNondominantTotalDisplacement;
			float indexFingerTIPNondominantMaximumDisplacement = gesture.IndexFingerTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight, features.HandDominance, false),
				new JointGestureFeatures(indexFingerTIPNondominantF1F2SpatialAngle, indexFingerTIPNondominantFN_1FNSpatialAngle, indexFingerTIPNondominantF1FNSpatialAngle,
				indexFingerTIPNondominantTotalVectorAngle, indexFingerTIPNondominantSquaredTotalVectorAngle,
				indexFingerTIPNondominantTotalVectorDisplacement, indexFingerTIPNondominantTotalDisplacement, indexFingerTIPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerMCPNondominant joint features
			float middleFingerMCPNondominantF1F2SpatialAngle = gesture.MiddleFingerMCPNondominantF1F2SpatialAngle;
			float middleFingerMCPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerMCPNondominantFN_1FNSpatialAngle;
			float middleFingerMCPNondominantF1FNSpatialAngle = gesture.MiddleFingerMCPNondominantF1FNSpatialAngle;
			float middleFingerMCPNondominantTotalVectorAngle = gesture.MiddleFingerMCPNondominantTotalVectorAngle;
			float middleFingerMCPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerMCPNondominantSquaredTotalVectorAngle;
			float middleFingerMCPNondominantTotalVectorDisplacement = gesture.MiddleFingerMCPNondominantTotalVectorDisplacement;
			float middleFingerMCPNondominantTotalDisplacement = gesture.MiddleFingerMCPNondominantTotalDisplacement;
			float middleFingerMCPNondominantMaximumDisplacement = gesture.MiddleFingerMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerMCPNondominantF1F2SpatialAngle, middleFingerMCPNondominantFN_1FNSpatialAngle, middleFingerMCPNondominantF1FNSpatialAngle,
				middleFingerMCPNondominantTotalVectorAngle, middleFingerMCPNondominantSquaredTotalVectorAngle,
				middleFingerMCPNondominantTotalVectorDisplacement, middleFingerMCPNondominantTotalDisplacement, middleFingerMCPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerPIPNondominant joint features
			float middleFingerPIPNondominantF1F2SpatialAngle = gesture.MiddleFingerPIPNondominantF1F2SpatialAngle;
			float middleFingerPIPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerPIPNondominantFN_1FNSpatialAngle;
			float middleFingerPIPNondominantF1FNSpatialAngle = gesture.MiddleFingerPIPNondominantF1FNSpatialAngle;
			float middleFingerPIPNondominantTotalVectorAngle = gesture.MiddleFingerPIPNondominantTotalVectorAngle;
			float middleFingerPIPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerPIPNondominantSquaredTotalVectorAngle;
			float middleFingerPIPNondominantTotalVectorDisplacement = gesture.MiddleFingerPIPNondominantTotalVectorDisplacement;
			float middleFingerPIPNondominantTotalDisplacement = gesture.MiddleFingerPIPNondominantTotalDisplacement;
			float middleFingerPIPNondominantMaximumDisplacement = gesture.MiddleFingerPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerPIPNondominantF1F2SpatialAngle, middleFingerPIPNondominantFN_1FNSpatialAngle, middleFingerPIPNondominantF1FNSpatialAngle,
				middleFingerPIPNondominantTotalVectorAngle, middleFingerPIPNondominantSquaredTotalVectorAngle,
				middleFingerPIPNondominantTotalVectorDisplacement, middleFingerPIPNondominantTotalDisplacement, middleFingerPIPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerDIPNondominant joint features
			float middleFingerDIPNondominantF1F2SpatialAngle = gesture.MiddleFingerDIPNondominantF1F2SpatialAngle;
			float middleFingerDIPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerDIPNondominantFN_1FNSpatialAngle;
			float middleFingerDIPNondominantF1FNSpatialAngle = gesture.MiddleFingerDIPNondominantF1FNSpatialAngle;
			float middleFingerDIPNondominantTotalVectorAngle = gesture.MiddleFingerDIPNondominantTotalVectorAngle;
			float middleFingerDIPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerDIPNondominantSquaredTotalVectorAngle;
			float middleFingerDIPNondominantTotalVectorDisplacement = gesture.MiddleFingerDIPNondominantTotalVectorDisplacement;
			float middleFingerDIPNondominantTotalDisplacement = gesture.MiddleFingerDIPNondominantTotalDisplacement;
			float middleFingerDIPNondominantMaximumDisplacement = gesture.MiddleFingerDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerDIPNondominantF1F2SpatialAngle, middleFingerDIPNondominantFN_1FNSpatialAngle, middleFingerDIPNondominantF1FNSpatialAngle,
				middleFingerDIPNondominantTotalVectorAngle, middleFingerDIPNondominantSquaredTotalVectorAngle,
				middleFingerDIPNondominantTotalVectorDisplacement, middleFingerDIPNondominantTotalDisplacement, middleFingerDIPNondominantMaximumDisplacement));
			#endregion

			#region MiddleFingerTIPNondominant joint features
			float middleFingerTIPNondominantF1F2SpatialAngle = gesture.MiddleFingerTIPNondominantF1F2SpatialAngle;
			float middleFingerTIPNondominantFN_1FNSpatialAngle = gesture.MiddleFingerTIPNondominantFN_1FNSpatialAngle;
			float middleFingerTIPNondominantF1FNSpatialAngle = gesture.MiddleFingerTIPNondominantF1FNSpatialAngle;
			float middleFingerTIPNondominantTotalVectorAngle = gesture.MiddleFingerTIPNondominantTotalVectorAngle;
			float middleFingerTIPNondominantSquaredTotalVectorAngle = gesture.MiddleFingerTIPNondominantSquaredTotalVectorAngle;
			float middleFingerTIPNondominantTotalVectorDisplacement = gesture.MiddleFingerTIPNondominantTotalVectorDisplacement;
			float middleFingerTIPNondominantTotalDisplacement = gesture.MiddleFingerTIPNondominantTotalDisplacement;
			float middleFingerTIPNondominantMaximumDisplacement = gesture.MiddleFingerTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight, features.HandDominance, false),
				new JointGestureFeatures(middleFingerTIPNondominantF1F2SpatialAngle, middleFingerTIPNondominantFN_1FNSpatialAngle, middleFingerTIPNondominantF1FNSpatialAngle,
				middleFingerTIPNondominantTotalVectorAngle, middleFingerTIPNondominantSquaredTotalVectorAngle,
				middleFingerTIPNondominantTotalVectorDisplacement, middleFingerTIPNondominantTotalDisplacement, middleFingerTIPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerMCPNondominant joint features
			float ringFingerMCPNondominantF1F2SpatialAngle = gesture.RingFingerMCPNondominantF1F2SpatialAngle;
			float ringFingerMCPNondominantFN_1FNSpatialAngle = gesture.RingFingerMCPNondominantFN_1FNSpatialAngle;
			float ringFingerMCPNondominantF1FNSpatialAngle = gesture.RingFingerMCPNondominantF1FNSpatialAngle;
			float ringFingerMCPNondominantTotalVectorAngle = gesture.RingFingerMCPNondominantTotalVectorAngle;
			float ringFingerMCPNondominantSquaredTotalVectorAngle = gesture.RingFingerMCPNondominantSquaredTotalVectorAngle;
			float ringFingerMCPNondominantTotalVectorDisplacement = gesture.RingFingerMCPNondominantTotalVectorDisplacement;
			float ringFingerMCPNondominantTotalDisplacement = gesture.RingFingerMCPNondominantTotalDisplacement;
			float ringFingerMCPNondominantMaximumDisplacement = gesture.RingFingerMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerMCPNondominantF1F2SpatialAngle, ringFingerMCPNondominantFN_1FNSpatialAngle, ringFingerMCPNondominantF1FNSpatialAngle,
				ringFingerMCPNondominantTotalVectorAngle, ringFingerMCPNondominantSquaredTotalVectorAngle,
				ringFingerMCPNondominantTotalVectorDisplacement, ringFingerMCPNondominantTotalDisplacement, ringFingerMCPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerPIPNondominant joint features
			float ringFingerPIPNondominantF1F2SpatialAngle = gesture.RingFingerPIPNondominantF1F2SpatialAngle;
			float ringFingerPIPNondominantFN_1FNSpatialAngle = gesture.RingFingerPIPNondominantFN_1FNSpatialAngle;
			float ringFingerPIPNondominantF1FNSpatialAngle = gesture.RingFingerPIPNondominantF1FNSpatialAngle;
			float ringFingerPIPNondominantTotalVectorAngle = gesture.RingFingerPIPNondominantTotalVectorAngle;
			float ringFingerPIPNondominantSquaredTotalVectorAngle = gesture.RingFingerPIPNondominantSquaredTotalVectorAngle;
			float ringFingerPIPNondominantTotalVectorDisplacement = gesture.RingFingerPIPNondominantTotalVectorDisplacement;
			float ringFingerPIPNondominantTotalDisplacement = gesture.RingFingerPIPNondominantTotalDisplacement;
			float ringFingerPIPNondominantMaximumDisplacement = gesture.RingFingerPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerPIPNondominantF1F2SpatialAngle, ringFingerPIPNondominantFN_1FNSpatialAngle, ringFingerPIPNondominantF1FNSpatialAngle,
				ringFingerPIPNondominantTotalVectorAngle, ringFingerPIPNondominantSquaredTotalVectorAngle,
				ringFingerPIPNondominantTotalVectorDisplacement, ringFingerPIPNondominantTotalDisplacement, ringFingerPIPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerDIPNondominant joint features
			float ringFingerDIPNondominantF1F2SpatialAngle = gesture.RingFingerDIPNondominantF1F2SpatialAngle;
			float ringFingerDIPNondominantFN_1FNSpatialAngle = gesture.RingFingerDIPNondominantFN_1FNSpatialAngle;
			float ringFingerDIPNondominantF1FNSpatialAngle = gesture.RingFingerDIPNondominantF1FNSpatialAngle;
			float ringFingerDIPNondominantTotalVectorAngle = gesture.RingFingerDIPNondominantTotalVectorAngle;
			float ringFingerDIPNondominantSquaredTotalVectorAngle = gesture.RingFingerDIPNondominantSquaredTotalVectorAngle;
			float ringFingerDIPNondominantTotalVectorDisplacement = gesture.RingFingerDIPNondominantTotalVectorDisplacement;
			float ringFingerDIPNondominantTotalDisplacement = gesture.RingFingerDIPNondominantTotalDisplacement;
			float ringFingerDIPNondominantMaximumDisplacement = gesture.RingFingerDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerDIPNondominantF1F2SpatialAngle, ringFingerDIPNondominantFN_1FNSpatialAngle, ringFingerDIPNondominantF1FNSpatialAngle,
				ringFingerDIPNondominantTotalVectorAngle, ringFingerDIPNondominantSquaredTotalVectorAngle,
				ringFingerDIPNondominantTotalVectorDisplacement, ringFingerDIPNondominantTotalDisplacement, ringFingerDIPNondominantMaximumDisplacement));
			#endregion

			#region RingFingerTIPNondominant joint features
			float ringFingerTIPNondominantF1F2SpatialAngle = gesture.RingFingerTIPNondominantF1F2SpatialAngle;
			float ringFingerTIPNondominantFN_1FNSpatialAngle = gesture.RingFingerTIPNondominantFN_1FNSpatialAngle;
			float ringFingerTIPNondominantF1FNSpatialAngle = gesture.RingFingerTIPNondominantF1FNSpatialAngle;
			float ringFingerTIPNondominantTotalVectorAngle = gesture.RingFingerTIPNondominantTotalVectorAngle;
			float ringFingerTIPNondominantSquaredTotalVectorAngle = gesture.RingFingerTIPNondominantSquaredTotalVectorAngle;
			float ringFingerTIPNondominantTotalVectorDisplacement = gesture.RingFingerTIPNondominantTotalVectorDisplacement;
			float ringFingerTIPNondominantTotalDisplacement = gesture.RingFingerTIPNondominantTotalDisplacement;
			float ringFingerTIPNondominantMaximumDisplacement = gesture.RingFingerTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight, features.HandDominance, false),
				new JointGestureFeatures(ringFingerTIPNondominantF1F2SpatialAngle, ringFingerTIPNondominantFN_1FNSpatialAngle, ringFingerTIPNondominantF1FNSpatialAngle,
				ringFingerTIPNondominantTotalVectorAngle, ringFingerTIPNondominantSquaredTotalVectorAngle,
				ringFingerTIPNondominantTotalVectorDisplacement, ringFingerTIPNondominantTotalDisplacement, ringFingerTIPNondominantMaximumDisplacement));
			#endregion

			#region PinkyMCPNondominant joint features
			float pinkyMCPNondominantF1F2SpatialAngle = gesture.PinkyMCPNondominantF1F2SpatialAngle;
			float pinkyMCPNondominantFN_1FNSpatialAngle = gesture.PinkyMCPNondominantFN_1FNSpatialAngle;
			float pinkyMCPNondominantF1FNSpatialAngle = gesture.PinkyMCPNondominantF1FNSpatialAngle;
			float pinkyMCPNondominantTotalVectorAngle = gesture.PinkyMCPNondominantTotalVectorAngle;
			float pinkyMCPNondominantSquaredTotalVectorAngle = gesture.PinkyMCPNondominantSquaredTotalVectorAngle;
			float pinkyMCPNondominantTotalVectorDisplacement = gesture.PinkyMCPNondominantTotalVectorDisplacement;
			float pinkyMCPNondominantTotalDisplacement = gesture.PinkyMCPNondominantTotalDisplacement;
			float pinkyMCPNondominantMaximumDisplacement = gesture.PinkyMCPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyMCPLeft, JointType.PinkyMCPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyMCPNondominantF1F2SpatialAngle, pinkyMCPNondominantFN_1FNSpatialAngle, pinkyMCPNondominantF1FNSpatialAngle,
				pinkyMCPNondominantTotalVectorAngle, pinkyMCPNondominantSquaredTotalVectorAngle,
				pinkyMCPNondominantTotalVectorDisplacement, pinkyMCPNondominantTotalDisplacement, pinkyMCPNondominantMaximumDisplacement));
			#endregion

			#region PinkyPIPNondominant joint features
			float pinkyPIPNondominantF1F2SpatialAngle = gesture.PinkyPIPNondominantF1F2SpatialAngle;
			float pinkyPIPNondominantFN_1FNSpatialAngle = gesture.PinkyPIPNondominantFN_1FNSpatialAngle;
			float pinkyPIPNondominantF1FNSpatialAngle = gesture.PinkyPIPNondominantF1FNSpatialAngle;
			float pinkyPIPNondominantTotalVectorAngle = gesture.PinkyPIPNondominantTotalVectorAngle;
			float pinkyPIPNondominantSquaredTotalVectorAngle = gesture.PinkyPIPNondominantSquaredTotalVectorAngle;
			float pinkyPIPNondominantTotalVectorDisplacement = gesture.PinkyPIPNondominantTotalVectorDisplacement;
			float pinkyPIPNondominantTotalDisplacement = gesture.PinkyPIPNondominantTotalDisplacement;
			float pinkyPIPNondominantMaximumDisplacement = gesture.PinkyPIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyPIPLeft, JointType.PinkyPIPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyPIPNondominantF1F2SpatialAngle, pinkyPIPNondominantFN_1FNSpatialAngle, pinkyPIPNondominantF1FNSpatialAngle,
				pinkyPIPNondominantTotalVectorAngle, pinkyPIPNondominantSquaredTotalVectorAngle,
				pinkyPIPNondominantTotalVectorDisplacement, pinkyPIPNondominantTotalDisplacement, pinkyPIPNondominantMaximumDisplacement));
			#endregion

			#region PinkyDIPNondominant joint features
			float pinkyDIPNondominantF1F2SpatialAngle = gesture.PinkyDIPNondominantF1F2SpatialAngle;
			float pinkyDIPNondominantFN_1FNSpatialAngle = gesture.PinkyDIPNondominantFN_1FNSpatialAngle;
			float pinkyDIPNondominantF1FNSpatialAngle = gesture.PinkyDIPNondominantF1FNSpatialAngle;
			float pinkyDIPNondominantTotalVectorAngle = gesture.PinkyDIPNondominantTotalVectorAngle;
			float pinkyDIPNondominantSquaredTotalVectorAngle = gesture.PinkyDIPNondominantSquaredTotalVectorAngle;
			float pinkyDIPNondominantTotalVectorDisplacement = gesture.PinkyDIPNondominantTotalVectorDisplacement;
			float pinkyDIPNondominantTotalDisplacement = gesture.PinkyDIPNondominantTotalDisplacement;
			float pinkyDIPNondominantMaximumDisplacement = gesture.PinkyDIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyDIPLeft, JointType.PinkyDIPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyDIPNondominantF1F2SpatialAngle, pinkyDIPNondominantFN_1FNSpatialAngle, pinkyDIPNondominantF1FNSpatialAngle,
				pinkyDIPNondominantTotalVectorAngle, pinkyDIPNondominantSquaredTotalVectorAngle,
				pinkyDIPNondominantTotalVectorDisplacement, pinkyDIPNondominantTotalDisplacement, pinkyDIPNondominantMaximumDisplacement));
			#endregion

			#region PinkyTIPNondominant joint features
			float pinkyTIPNondominantF1F2SpatialAngle = gesture.PinkyTIPNondominantF1F2SpatialAngle;
			float pinkyTIPNondominantFN_1FNSpatialAngle = gesture.PinkyTIPNondominantFN_1FNSpatialAngle;
			float pinkyTIPNondominantF1FNSpatialAngle = gesture.PinkyTIPNondominantF1FNSpatialAngle;
			float pinkyTIPNondominantTotalVectorAngle = gesture.PinkyTIPNondominantTotalVectorAngle;
			float pinkyTIPNondominantSquaredTotalVectorAngle = gesture.PinkyTIPNondominantSquaredTotalVectorAngle;
			float pinkyTIPNondominantTotalVectorDisplacement = gesture.PinkyTIPNondominantTotalVectorDisplacement;
			float pinkyTIPNondominantTotalDisplacement = gesture.PinkyTIPNondominantTotalDisplacement;
			float pinkyTIPNondominantMaximumDisplacement = gesture.PinkyTIPNondominantMaximumDisplacement;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.PinkyTIPLeft, JointType.PinkyTIPRight, features.HandDominance, false),
				new JointGestureFeatures(pinkyTIPNondominantF1F2SpatialAngle, pinkyTIPNondominantFN_1FNSpatialAngle, pinkyTIPNondominantF1FNSpatialAngle,
				pinkyTIPNondominantTotalVectorAngle, pinkyTIPNondominantSquaredTotalVectorAngle,
				pinkyTIPNondominantTotalVectorDisplacement, pinkyTIPNondominantTotalDisplacement, pinkyTIPNondominantMaximumDisplacement));
			#endregion

			#region HandNondominant joint features
			float handNondominantF1F2SpatialAngle = gesture.HandNondominantF1F2SpatialAngle;
			float handNondominantFN_1FNSpatialAngle = gesture.HandNondominantFN_1FNSpatialAngle;
			float handNondominantF1FNSpatialAngle = gesture.HandNondominantF1FNSpatialAngle;
			float handNondominantTotalVectorAngle = gesture.HandNondominantTotalVectorAngle;
			float handNondominantSquaredTotalVectorAngle = gesture.HandNondominantSquaredTotalVectorAngle;
			float handNondominantTotalVectorDisplacement = gesture.HandNondominantTotalVectorDisplacement;
			float handNondominantTotalDisplacement = gesture.HandNondominantTotalDisplacement;
			float handNondominantMaximumDisplacement = gesture.HandNondominantMaximumDisplacement;
			float handNondominantBoundingBoxDiagonalLength = gesture.HandNondominantBoundingBoxDiagonalLength;
			float handNondominantBoundingBoxAngle = gesture.HandNondominantBoundingBoxAngle;
			//HandState[] handNondominantHandStates = gesture.HandNondominantHandStates;
			features.AddJointGestureFeature(GetJointTypeByHandDominance(JointType.HandLeft, JointType.HandRight, features.HandDominance, false),
				new HandJointGestureFeatures(handNondominantF1F2SpatialAngle, handNondominantFN_1FNSpatialAngle, handNondominantF1FNSpatialAngle,
				handNondominantTotalVectorAngle, handNondominantSquaredTotalVectorAngle,
				handNondominantTotalVectorDisplacement, handNondominantTotalDisplacement, handNondominantMaximumDisplacement,
				handNondominantBoundingBoxDiagonalLength, handNondominantBoundingBoxAngle/*, handNondominantHandStates*/));
			#endregion

			#region WristThumbCMCDominant bone features
			float wristThumbCMCDominantBoneInitialAngle = gesture.WristThumbCMCDominantBoneInitialAngle;
			float wristThumbCMCDominantBoneFinalAngle = gesture.WristThumbCMCDominantBoneFinalAngle;
			float wristThumbCMCDominantBoneMeanAngle = gesture.WristThumbCMCDominantBoneMeanAngle;
			float wristThumbCMCDominantBoneMaximumAngle = gesture.WristThumbCMCDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristThumbCMCLeftBone, MediaPipeHandLandmarksBonesDefs.WristThumbCMCRightBone,
				features.HandDominance, true), new BoneJointsAngleData(wristThumbCMCDominantBoneInitialAngle, wristThumbCMCDominantBoneFinalAngle,
				wristThumbCMCDominantBoneMeanAngle, wristThumbCMCDominantBoneMaximumAngle));
			#endregion

			#region ThumbCMCThumbMCPDominant bone features
			float thumbCMCThumbMCPDominantBoneInitialAngle = gesture.ThumbCMCThumbMCPDominantBoneInitialAngle;
			float thumbCMCThumbMCPDominantBoneFinalAngle = gesture.ThumbCMCThumbMCPDominantBoneFinalAngle;
			float thumbCMCThumbMCPDominantBoneMeanAngle = gesture.ThumbCMCThumbMCPDominantBoneMeanAngle;
			float thumbCMCThumbMCPDominantBoneMaximumAngle = gesture.ThumbCMCThumbMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbCMCThumbMCPDominantBoneInitialAngle, thumbCMCThumbMCPDominantBoneFinalAngle,
				thumbCMCThumbMCPDominantBoneMeanAngle, thumbCMCThumbMCPDominantBoneMaximumAngle));
			#endregion

			#region ThumbMCPThumbIPDominant bone features
			float thumbMCPThumbIPDominantBoneInitialAngle = gesture.ThumbMCPThumbIPDominantBoneInitialAngle;
			float thumbMCPThumbIPDominantBoneFinalAngle = gesture.ThumbMCPThumbIPDominantBoneFinalAngle;
			float thumbMCPThumbIPDominantBoneMeanAngle = gesture.ThumbMCPThumbIPDominantBoneMeanAngle;
			float thumbMCPThumbIPDominantBoneMaximumAngle = gesture.ThumbMCPThumbIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbMCPThumbIPDominantBoneInitialAngle, thumbMCPThumbIPDominantBoneFinalAngle,
				thumbMCPThumbIPDominantBoneMeanAngle, thumbMCPThumbIPDominantBoneMaximumAngle));
			#endregion

			#region ThumbIPThumbTIPDominant bone features
			float thumbIPThumbTIPDominantBoneInitialAngle = gesture.ThumbIPThumbTIPDominantBoneInitialAngle;
			float thumbIPThumbTIPDominantBoneFinalAngle = gesture.ThumbIPThumbTIPDominantBoneFinalAngle;
			float thumbIPThumbTIPDominantBoneMeanAngle = gesture.ThumbIPThumbTIPDominantBoneMeanAngle;
			float thumbIPThumbTIPDominantBoneMaximumAngle = gesture.ThumbIPThumbTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbIPThumbTIPDominantBoneInitialAngle, thumbIPThumbTIPDominantBoneFinalAngle,
				thumbIPThumbTIPDominantBoneMeanAngle, thumbIPThumbTIPDominantBoneMaximumAngle));
			#endregion

			#region WristIndexFingerMCPDominant bone features
			float wristIndexFingerMCPDominantBoneInitialAngle = gesture.WristIndexFingerMCPDominantBoneInitialAngle;
			float wristIndexFingerMCPDominantBoneFinalAngle = gesture.WristIndexFingerMCPDominantBoneFinalAngle;
			float wristIndexFingerMCPDominantBoneMeanAngle = gesture.WristIndexFingerMCPDominantBoneMeanAngle;
			float wristIndexFingerMCPDominantBoneMaximumAngle = gesture.WristIndexFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(wristIndexFingerMCPDominantBoneInitialAngle, wristIndexFingerMCPDominantBoneFinalAngle,
				wristIndexFingerMCPDominantBoneMeanAngle, wristIndexFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPIndexFingerPIPDominant bone features
			float indexFingerMCPIndexFingerPIPDominantBoneInitialAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle;
			float indexFingerMCPIndexFingerPIPDominantBoneFinalAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle;
			float indexFingerMCPIndexFingerPIPDominantBoneMeanAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle;
			float indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle = gesture.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerMCPIndexFingerPIPDominantBoneInitialAngle, indexFingerMCPIndexFingerPIPDominantBoneFinalAngle,
				indexFingerMCPIndexFingerPIPDominantBoneMeanAngle, indexFingerMCPIndexFingerPIPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerPIPIndexFingerDIPDominant bone features
			float indexFingerPIPIndexFingerDIPDominantBoneInitialAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle;
			float indexFingerPIPIndexFingerDIPDominantBoneFinalAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle;
			float indexFingerPIPIndexFingerDIPDominantBoneMeanAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle;
			float indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle = gesture.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerPIPIndexFingerDIPDominantBoneInitialAngle, indexFingerPIPIndexFingerDIPDominantBoneFinalAngle,
				indexFingerPIPIndexFingerDIPDominantBoneMeanAngle, indexFingerPIPIndexFingerDIPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerDIPIndexFingerTIPDominant bone features
			float indexFingerDIPIndexFingerTIPDominantBoneInitialAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle;
			float indexFingerDIPIndexFingerTIPDominantBoneFinalAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle;
			float indexFingerDIPIndexFingerTIPDominantBoneMeanAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle;
			float indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle = gesture.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerDIPIndexFingerTIPDominantBoneInitialAngle, indexFingerDIPIndexFingerTIPDominantBoneFinalAngle,
				indexFingerDIPIndexFingerTIPDominantBoneMeanAngle, indexFingerDIPIndexFingerTIPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPDominant bone features
			float middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle;
			float middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle;
			float middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle;
			float middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle = gesture.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerMCPMiddleFingerPIPDominantBoneInitialAngle, middleFingerMCPMiddleFingerPIPDominantBoneFinalAngle,
				middleFingerMCPMiddleFingerPIPDominantBoneMeanAngle, middleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPDominant bone features
			float middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle;
			float middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle;
			float middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle;
			float middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle = gesture.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerPIPMiddleFingerDIPDominantBoneInitialAngle, middleFingerPIPMiddleFingerDIPDominantBoneFinalAngle,
				middleFingerPIPMiddleFingerDIPDominantBoneMeanAngle, middleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPDominant bone features
			float middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle;
			float middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle;
			float middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle;
			float middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle = gesture.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerDIPMiddleFingerTIPDominantBoneInitialAngle, middleFingerDIPMiddleFingerTIPDominantBoneFinalAngle,
				middleFingerDIPMiddleFingerTIPDominantBoneMeanAngle, middleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPRingFingerPIPDominant bone features
			float ringFingerMCPRingFingerPIPDominantBoneInitialAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneInitialAngle;
			float ringFingerMCPRingFingerPIPDominantBoneFinalAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneFinalAngle;
			float ringFingerMCPRingFingerPIPDominantBoneMeanAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneMeanAngle;
			float ringFingerMCPRingFingerPIPDominantBoneMaximumAngle = gesture.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerMCPRingFingerPIPDominantBoneInitialAngle, ringFingerMCPRingFingerPIPDominantBoneFinalAngle,
				ringFingerMCPRingFingerPIPDominantBoneMeanAngle, ringFingerMCPRingFingerPIPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerPIPRingFingerDIPDominant bone features
			float ringFingerPIPRingFingerDIPDominantBoneInitialAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneInitialAngle;
			float ringFingerPIPRingFingerDIPDominantBoneFinalAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneFinalAngle;
			float ringFingerPIPRingFingerDIPDominantBoneMeanAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneMeanAngle;
			float ringFingerPIPRingFingerDIPDominantBoneMaximumAngle = gesture.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerPIPRingFingerDIPDominantBoneInitialAngle, ringFingerPIPRingFingerDIPDominantBoneFinalAngle,
				ringFingerPIPRingFingerDIPDominantBoneMeanAngle, ringFingerPIPRingFingerDIPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerDIPRingFingerTIPDominant bone features
			float ringFingerDIPRingFingerTIPDominantBoneInitialAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneInitialAngle;
			float ringFingerDIPRingFingerTIPDominantBoneFinalAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneFinalAngle;
			float ringFingerDIPRingFingerTIPDominantBoneMeanAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneMeanAngle;
			float ringFingerDIPRingFingerTIPDominantBoneMaximumAngle = gesture.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerDIPRingFingerTIPDominantBoneInitialAngle, ringFingerDIPRingFingerTIPDominantBoneFinalAngle,
				ringFingerDIPRingFingerTIPDominantBoneMeanAngle, ringFingerDIPRingFingerTIPDominantBoneMaximumAngle));
			#endregion

			#region WristPinkyMCPDominant bone features
			float wristPinkyMCPDominantBoneInitialAngle = gesture.WristPinkyMCPDominantBoneInitialAngle;
			float wristPinkyMCPDominantBoneFinalAngle = gesture.WristPinkyMCPDominantBoneFinalAngle;
			float wristPinkyMCPDominantBoneMeanAngle = gesture.WristPinkyMCPDominantBoneMeanAngle;
			float wristPinkyMCPDominantBoneMaximumAngle = gesture.WristPinkyMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristPinkyMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(wristPinkyMCPDominantBoneInitialAngle, wristPinkyMCPDominantBoneFinalAngle,
				wristPinkyMCPDominantBoneMeanAngle, wristPinkyMCPDominantBoneMaximumAngle));
			#endregion

			#region PinkyMCPPinkyPIPDominant bone features
			float pinkyMCPPinkyPIPDominantBoneInitialAngle = gesture.PinkyMCPPinkyPIPDominantBoneInitialAngle;
			float pinkyMCPPinkyPIPDominantBoneFinalAngle = gesture.PinkyMCPPinkyPIPDominantBoneFinalAngle;
			float pinkyMCPPinkyPIPDominantBoneMeanAngle = gesture.PinkyMCPPinkyPIPDominantBoneMeanAngle;
			float pinkyMCPPinkyPIPDominantBoneMaximumAngle = gesture.PinkyMCPPinkyPIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(pinkyMCPPinkyPIPDominantBoneInitialAngle, pinkyMCPPinkyPIPDominantBoneFinalAngle,
				pinkyMCPPinkyPIPDominantBoneMeanAngle, pinkyMCPPinkyPIPDominantBoneMaximumAngle));
			#endregion

			#region PinkyPIPPinkyDIPDominant bone features
			float pinkyPIPPinkyDIPDominantBoneInitialAngle = gesture.PinkyPIPPinkyDIPDominantBoneInitialAngle;
			float pinkyPIPPinkyDIPDominantBoneFinalAngle = gesture.PinkyPIPPinkyDIPDominantBoneFinalAngle;
			float pinkyPIPPinkyDIPDominantBoneMeanAngle = gesture.PinkyPIPPinkyDIPDominantBoneMeanAngle;
			float pinkyPIPPinkyDIPDominantBoneMaximumAngle = gesture.PinkyPIPPinkyDIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(pinkyPIPPinkyDIPDominantBoneInitialAngle, pinkyPIPPinkyDIPDominantBoneFinalAngle,
				pinkyPIPPinkyDIPDominantBoneMeanAngle, pinkyPIPPinkyDIPDominantBoneMaximumAngle));
			#endregion

			#region PinkyDIPPinkyTIPDominant bone features
			float pinkyDIPPinkyTIPDominantBoneInitialAngle = gesture.PinkyDIPPinkyTIPDominantBoneInitialAngle;
			float pinkyDIPPinkyTIPDominantBoneFinalAngle = gesture.PinkyDIPPinkyTIPDominantBoneFinalAngle;
			float pinkyDIPPinkyTIPDominantBoneMeanAngle = gesture.PinkyDIPPinkyTIPDominantBoneMeanAngle;
			float pinkyDIPPinkyTIPDominantBoneMaximumAngle = gesture.PinkyDIPPinkyTIPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(pinkyDIPPinkyTIPDominantBoneInitialAngle, pinkyDIPPinkyTIPDominantBoneFinalAngle,
				pinkyDIPPinkyTIPDominantBoneMeanAngle, pinkyDIPPinkyTIPDominantBoneMaximumAngle));
			#endregion

			#region ThumbMCPIndexFingerMCPDominant bone features
			float thumbMCPIndexFingerMCPDominantBoneInitialAngle = gesture.ThumbMCPIndexFingerMCPDominantBoneInitialAngle;
			float thumbMCPIndexFingerMCPDominantBoneFinalAngle = gesture.ThumbMCPIndexFingerMCPDominantBoneFinalAngle;
			float thumbMCPIndexFingerMCPDominantBoneMeanAngle = gesture.ThumbMCPIndexFingerMCPDominantBoneMeanAngle;
			float thumbMCPIndexFingerMCPDominantBoneMaximumAngle = gesture.ThumbMCPIndexFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(thumbMCPIndexFingerMCPDominantBoneInitialAngle, thumbMCPIndexFingerMCPDominantBoneFinalAngle,
				thumbMCPIndexFingerMCPDominantBoneMeanAngle, thumbMCPIndexFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominant bone features
			float indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle;
			float indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle;
			float indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle;
			float indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle = gesture.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(indexFingerMCPMiddleFingerMCPDominantBoneInitialAngle, indexFingerMCPMiddleFingerMCPDominantBoneFinalAngle,
				indexFingerMCPMiddleFingerMCPDominantBoneMeanAngle, indexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPRingFingerMCPDominant bone features
			float middleFingerMCPRingFingerMCPDominantBoneInitialAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle;
			float middleFingerMCPRingFingerMCPDominantBoneFinalAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle;
			float middleFingerMCPRingFingerMCPDominantBoneMeanAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle;
			float middleFingerMCPRingFingerMCPDominantBoneMaximumAngle = gesture.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(middleFingerMCPRingFingerMCPDominantBoneInitialAngle, middleFingerMCPRingFingerMCPDominantBoneFinalAngle,
				middleFingerMCPRingFingerMCPDominantBoneMeanAngle, middleFingerMCPRingFingerMCPDominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPPinkyMCPDominant bone features
			float ringFingerMCPPinkyMCPDominantBoneInitialAngle = gesture.RingFingerMCPPinkyMCPDominantBoneInitialAngle;
			float ringFingerMCPPinkyMCPDominantBoneFinalAngle = gesture.RingFingerMCPPinkyMCPDominantBoneFinalAngle;
			float ringFingerMCPPinkyMCPDominantBoneMeanAngle = gesture.RingFingerMCPPinkyMCPDominantBoneMeanAngle;
			float ringFingerMCPPinkyMCPDominantBoneMaximumAngle = gesture.RingFingerMCPPinkyMCPDominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPPinkyMCPRightBone,
				features.HandDominance, true), new BoneJointsAngleData(ringFingerMCPPinkyMCPDominantBoneInitialAngle, ringFingerMCPPinkyMCPDominantBoneFinalAngle,
				ringFingerMCPPinkyMCPDominantBoneMeanAngle, ringFingerMCPPinkyMCPDominantBoneMaximumAngle));
			#endregion

			#region WristThumbCMCNondominant bone features
			float wristThumbCMCNondominantBoneInitialAngle = gesture.WristThumbCMCNondominantBoneInitialAngle;
			float wristThumbCMCNondominantBoneFinalAngle = gesture.WristThumbCMCNondominantBoneFinalAngle;
			float wristThumbCMCNondominantBoneMeanAngle = gesture.WristThumbCMCNondominantBoneMeanAngle;
			float wristThumbCMCNondominantBoneMaximumAngle = gesture.WristThumbCMCNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristThumbCMCLeftBone, MediaPipeHandLandmarksBonesDefs.WristThumbCMCRightBone,
				features.HandDominance, false), new BoneJointsAngleData(wristThumbCMCNondominantBoneInitialAngle, wristThumbCMCNondominantBoneFinalAngle,
				wristThumbCMCNondominantBoneMeanAngle, wristThumbCMCNondominantBoneMaximumAngle));
			#endregion

			#region ThumbCMCThumbMCPNondominant bone features
			float thumbCMCThumbMCPNondominantBoneInitialAngle = gesture.ThumbCMCThumbMCPNondominantBoneInitialAngle;
			float thumbCMCThumbMCPNondominantBoneFinalAngle = gesture.ThumbCMCThumbMCPNondominantBoneFinalAngle;
			float thumbCMCThumbMCPNondominantBoneMeanAngle = gesture.ThumbCMCThumbMCPNondominantBoneMeanAngle;
			float thumbCMCThumbMCPNondominantBoneMaximumAngle = gesture.ThumbCMCThumbMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbCMCThumbMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbCMCThumbMCPNondominantBoneInitialAngle, thumbCMCThumbMCPNondominantBoneFinalAngle,
				thumbCMCThumbMCPNondominantBoneMeanAngle, thumbCMCThumbMCPNondominantBoneMaximumAngle));
			#endregion

			#region ThumbMCPThumbIPNondominant bone features
			float thumbMCPThumbIPNondominantBoneInitialAngle = gesture.ThumbMCPThumbIPNondominantBoneInitialAngle;
			float thumbMCPThumbIPNondominantBoneFinalAngle = gesture.ThumbMCPThumbIPNondominantBoneFinalAngle;
			float thumbMCPThumbIPNondominantBoneMeanAngle = gesture.ThumbMCPThumbIPNondominantBoneMeanAngle;
			float thumbMCPThumbIPNondominantBoneMaximumAngle = gesture.ThumbMCPThumbIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPThumbIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbMCPThumbIPNondominantBoneInitialAngle, thumbMCPThumbIPNondominantBoneFinalAngle,
				thumbMCPThumbIPNondominantBoneMeanAngle, thumbMCPThumbIPNondominantBoneMaximumAngle));
			#endregion

			#region ThumbIPThumbTIPNondominant bone features
			float thumbIPThumbTIPNondominantBoneInitialAngle = gesture.ThumbIPThumbTIPNondominantBoneInitialAngle;
			float thumbIPThumbTIPNondominantBoneFinalAngle = gesture.ThumbIPThumbTIPNondominantBoneFinalAngle;
			float thumbIPThumbTIPNondominantBoneMeanAngle = gesture.ThumbIPThumbTIPNondominantBoneMeanAngle;
			float thumbIPThumbTIPNondominantBoneMaximumAngle = gesture.ThumbIPThumbTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbIPThumbTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbIPThumbTIPNondominantBoneInitialAngle, thumbIPThumbTIPNondominantBoneFinalAngle,
				thumbIPThumbTIPNondominantBoneMeanAngle, thumbIPThumbTIPNondominantBoneMaximumAngle));
			#endregion

			#region WristIndexFingerMCPNondominant bone features
			float wristIndexFingerMCPNondominantBoneInitialAngle = gesture.WristIndexFingerMCPNondominantBoneInitialAngle;
			float wristIndexFingerMCPNondominantBoneFinalAngle = gesture.WristIndexFingerMCPNondominantBoneFinalAngle;
			float wristIndexFingerMCPNondominantBoneMeanAngle = gesture.WristIndexFingerMCPNondominantBoneMeanAngle;
			float wristIndexFingerMCPNondominantBoneMaximumAngle = gesture.WristIndexFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristIndexFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(wristIndexFingerMCPNondominantBoneInitialAngle, wristIndexFingerMCPNondominantBoneFinalAngle,
				wristIndexFingerMCPNondominantBoneMeanAngle, wristIndexFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPIndexFingerPIPNondominant bone features
			float indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle;
			float indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle;
			float indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle;
			float indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle = gesture.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPIndexFingerPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerMCPIndexFingerPIPNondominantBoneInitialAngle, indexFingerMCPIndexFingerPIPNondominantBoneFinalAngle,
				indexFingerMCPIndexFingerPIPNondominantBoneMeanAngle, indexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerPIPIndexFingerDIPNondominant bone features
			float indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle;
			float indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle;
			float indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle;
			float indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle = gesture.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerPIPIndexFingerDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerPIPIndexFingerDIPNondominantBoneInitialAngle, indexFingerPIPIndexFingerDIPNondominantBoneFinalAngle,
				indexFingerPIPIndexFingerDIPNondominantBoneMeanAngle, indexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerDIPIndexFingerTIPNondominant bone features
			float indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle;
			float indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle;
			float indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle;
			float indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle = gesture.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerDIPIndexFingerTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerDIPIndexFingerTIPNondominantBoneInitialAngle, indexFingerDIPIndexFingerTIPNondominantBoneFinalAngle,
				indexFingerDIPIndexFingerTIPNondominantBoneMeanAngle, indexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPNondominant bone features
			float middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle;
			float middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle;
			float middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle;
			float middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle = gesture.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPMiddleFingerPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle, middleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle,
				middleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle, middleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPNondominant bone features
			float middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle;
			float middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle;
			float middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle;
			float middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle = gesture.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerPIPMiddleFingerDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle, middleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle,
				middleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle, middleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPNondominant bone features
			float middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle;
			float middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle;
			float middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle;
			float middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle = gesture.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerDIPMiddleFingerTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle, middleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle,
				middleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle, middleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPRingFingerPIPNondominant bone features
			float ringFingerMCPRingFingerPIPNondominantBoneInitialAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle;
			float ringFingerMCPRingFingerPIPNondominantBoneFinalAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle;
			float ringFingerMCPRingFingerPIPNondominantBoneMeanAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle;
			float ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle = gesture.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerMCPRingFingerPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerMCPRingFingerPIPNondominantBoneInitialAngle, ringFingerMCPRingFingerPIPNondominantBoneFinalAngle,
				ringFingerMCPRingFingerPIPNondominantBoneMeanAngle, ringFingerMCPRingFingerPIPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerPIPRingFingerDIPNondominant bone features
			float ringFingerPIPRingFingerDIPNondominantBoneInitialAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle;
			float ringFingerPIPRingFingerDIPNondominantBoneFinalAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle;
			float ringFingerPIPRingFingerDIPNondominantBoneMeanAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle;
			float ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle = gesture.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerPIPRingFingerDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerPIPRingFingerDIPNondominantBoneInitialAngle, ringFingerPIPRingFingerDIPNondominantBoneFinalAngle,
				ringFingerPIPRingFingerDIPNondominantBoneMeanAngle, ringFingerPIPRingFingerDIPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerDIPRingFingerTIPNondominant bone features
			float ringFingerDIPRingFingerTIPNondominantBoneInitialAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle;
			float ringFingerDIPRingFingerTIPNondominantBoneFinalAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle;
			float ringFingerDIPRingFingerTIPNondominantBoneMeanAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle;
			float ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle = gesture.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPLeftBone, MediaPipeHandLandmarksBonesDefs.RingFingerDIPRingFingerTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(ringFingerDIPRingFingerTIPNondominantBoneInitialAngle, ringFingerDIPRingFingerTIPNondominantBoneFinalAngle,
				ringFingerDIPRingFingerTIPNondominantBoneMeanAngle, ringFingerDIPRingFingerTIPNondominantBoneMaximumAngle));
			#endregion

			#region WristPinkyMCPNondominant bone features
			float wristPinkyMCPNondominantBoneInitialAngle = gesture.WristPinkyMCPNondominantBoneInitialAngle;
			float wristPinkyMCPNondominantBoneFinalAngle = gesture.WristPinkyMCPNondominantBoneFinalAngle;
			float wristPinkyMCPNondominantBoneMeanAngle = gesture.WristPinkyMCPNondominantBoneMeanAngle;
			float wristPinkyMCPNondominantBoneMaximumAngle = gesture.WristPinkyMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.WristPinkyMCPLeftBone, MediaPipeHandLandmarksBonesDefs.WristPinkyMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(wristPinkyMCPNondominantBoneInitialAngle, wristPinkyMCPNondominantBoneFinalAngle,
				wristPinkyMCPNondominantBoneMeanAngle, wristPinkyMCPNondominantBoneMaximumAngle));
			#endregion

			#region PinkyMCPPinkyPIPNondominant bone features
			float pinkyMCPPinkyPIPNondominantBoneInitialAngle = gesture.PinkyMCPPinkyPIPNondominantBoneInitialAngle;
			float pinkyMCPPinkyPIPNondominantBoneFinalAngle = gesture.PinkyMCPPinkyPIPNondominantBoneFinalAngle;
			float pinkyMCPPinkyPIPNondominantBoneMeanAngle = gesture.PinkyMCPPinkyPIPNondominantBoneMeanAngle;
			float pinkyMCPPinkyPIPNondominantBoneMaximumAngle = gesture.PinkyMCPPinkyPIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyMCPPinkyPIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(pinkyMCPPinkyPIPNondominantBoneInitialAngle, pinkyMCPPinkyPIPNondominantBoneFinalAngle,
				pinkyMCPPinkyPIPNondominantBoneMeanAngle, pinkyMCPPinkyPIPNondominantBoneMaximumAngle));
			#endregion

			#region PinkyPIPPinkyDIPNondominant bone features
			float pinkyPIPPinkyDIPNondominantBoneInitialAngle = gesture.PinkyPIPPinkyDIPNondominantBoneInitialAngle;
			float pinkyPIPPinkyDIPNondominantBoneFinalAngle = gesture.PinkyPIPPinkyDIPNondominantBoneFinalAngle;
			float pinkyPIPPinkyDIPNondominantBoneMeanAngle = gesture.PinkyPIPPinkyDIPNondominantBoneMeanAngle;
			float pinkyPIPPinkyDIPNondominantBoneMaximumAngle = gesture.PinkyPIPPinkyDIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyPIPPinkyDIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(pinkyPIPPinkyDIPNondominantBoneInitialAngle, pinkyPIPPinkyDIPNondominantBoneFinalAngle,
				pinkyPIPPinkyDIPNondominantBoneMeanAngle, pinkyPIPPinkyDIPNondominantBoneMaximumAngle));
			#endregion

			#region PinkyDIPPinkyTIPNondominant bone features
			float pinkyDIPPinkyTIPNondominantBoneInitialAngle = gesture.PinkyDIPPinkyTIPNondominantBoneInitialAngle;
			float pinkyDIPPinkyTIPNondominantBoneFinalAngle = gesture.PinkyDIPPinkyTIPNondominantBoneFinalAngle;
			float pinkyDIPPinkyTIPNondominantBoneMeanAngle = gesture.PinkyDIPPinkyTIPNondominantBoneMeanAngle;
			float pinkyDIPPinkyTIPNondominantBoneMaximumAngle = gesture.PinkyDIPPinkyTIPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPLeftBone, MediaPipeHandLandmarksBonesDefs.PinkyDIPPinkyTIPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(pinkyDIPPinkyTIPNondominantBoneInitialAngle, pinkyDIPPinkyTIPNondominantBoneFinalAngle,
				pinkyDIPPinkyTIPNondominantBoneMeanAngle, pinkyDIPPinkyTIPNondominantBoneMaximumAngle));
			#endregion

			#region ThumbMCPIndexFingerMCPNondominant bone features
			float thumbMCPIndexFingerMCPNondominantBoneInitialAngle = gesture.ThumbMCPIndexFingerMCPNondominantBoneInitialAngle;
			float thumbMCPIndexFingerMCPNondominantBoneFinalAngle = gesture.ThumbMCPIndexFingerMCPNondominantBoneFinalAngle;
			float thumbMCPIndexFingerMCPNondominantBoneMeanAngle = gesture.ThumbMCPIndexFingerMCPNondominantBoneMeanAngle;
			float thumbMCPIndexFingerMCPNondominantBoneMaximumAngle = gesture.ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.ThumbMCPIndexFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(thumbMCPIndexFingerMCPNondominantBoneInitialAngle, thumbMCPIndexFingerMCPNondominantBoneFinalAngle,
				thumbMCPIndexFingerMCPNondominantBoneMeanAngle, thumbMCPIndexFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominant bone features
			float indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle;
			float indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle;
			float indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle;
			float indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle = gesture.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.IndexFingerMCPMiddleFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(indexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle, indexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle,
				indexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle, indexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region MiddleFingerMCPRingFingerMCPNondominant bone features
			float middleFingerMCPRingFingerMCPNondominantBoneInitialAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle;
			float middleFingerMCPRingFingerMCPNondominantBoneFinalAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle;
			float middleFingerMCPRingFingerMCPNondominantBoneMeanAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle;
			float middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle = gesture.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle;
			features.AddBoneJointsAngleData(GetBoneByHandDominance(MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPLeftBone, MediaPipeHandLandmarksBonesDefs.MiddleFingerMCPRingFingerMCPRightBone,
				features.HandDominance, false), new BoneJointsAngleData(middleFingerMCPRingFingerMCPNondominantBoneInitialAngle, middleFingerMCPRingFingerMCPNondominantBoneFinalAngle,
				middleFingerMCPRingFingerMCPNondominantBoneMeanAngle, middleFingerMCPRingFingerMCPNondominantBoneMaximumAngle));
			#endregion

			#region RingFingerMCPPinkyMCPNondominant bone features
			float ringFingerMCPPinkyMCPNondominantBoneInitialAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneInitialAngle;
			float ringFingerMCPPinkyMCPNondominantBoneFinalAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneFinalAngle;
			float ringFingerMCPPinkyMCPNondominantBoneMeanAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneMeanAngle;
			float ringFingerMCPPinkyMCPNondominantBoneMaximumAngle = gesture.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle;
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
