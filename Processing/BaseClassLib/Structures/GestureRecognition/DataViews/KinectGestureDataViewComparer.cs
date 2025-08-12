using System;
using System.Collections.Generic;
using static GestureRecognition.Processing.BaseClassLib.Utils.DataViewsUtils;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews
{
	public class KinectGestureDataViewComparer: IEqualityComparer<KinectGestureDataView>
	{
		#region Instance
		public static KinectGestureDataViewComparer Instance = new KinectGestureDataViewComparer();
		#endregion

		#region IEqualityComparer implementation
		public bool Equals(KinectGestureDataView x, KinectGestureDataView y)
		{
			if (ReferenceEquals(x, y)) 
				return true;

			if (x == null || y == null) 
				return false;

			return
			#region ElbowLeft joint features
			GestureFeatureEquals(x.ElbowLeftF1F2SpatialAngle, y.ElbowLeftF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ElbowLeftFN_1FNSpatialAngle, y.ElbowLeftFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowLeftF1FNSpatialAngle, y.ElbowLeftF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowLeftTotalVectorAngle, y.ElbowLeftTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowLeftSquaredTotalVectorAngle, y.ElbowLeftSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowLeftTotalVectorDisplacement, y.ElbowLeftTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ElbowLeftTotalDisplacement, y.ElbowLeftTotalDisplacement) &&
			GestureFeatureEquals(x.ElbowLeftMaximumDisplacement, y.ElbowLeftMaximumDisplacement) &&
			#endregion

			#region ElbowRight joint features
			GestureFeatureEquals(x.ElbowRightF1F2SpatialAngle, y.ElbowRightF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ElbowRightFN_1FNSpatialAngle, y.ElbowRightFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowRightF1FNSpatialAngle, y.ElbowRightF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowRightTotalVectorAngle, y.ElbowRightTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowRightSquaredTotalVectorAngle, y.ElbowRightSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowRightTotalVectorDisplacement, y.ElbowRightTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ElbowRightTotalDisplacement, y.ElbowRightTotalDisplacement) &&
			GestureFeatureEquals(x.ElbowRightMaximumDisplacement, y.ElbowRightMaximumDisplacement) &&
			#endregion

			#region WristLeft joint features
			GestureFeatureEquals(x.WristLeftF1F2SpatialAngle, y.WristLeftF1F2SpatialAngle) &&
			GestureFeatureEquals(x.WristLeftFN_1FNSpatialAngle, y.WristLeftFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristLeftF1FNSpatialAngle, y.WristLeftF1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristLeftTotalVectorAngle, y.WristLeftTotalVectorAngle) &&
			GestureFeatureEquals(x.WristLeftSquaredTotalVectorAngle, y.WristLeftSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.WristLeftTotalVectorDisplacement, y.WristLeftTotalVectorDisplacement) &&
			GestureFeatureEquals(x.WristLeftTotalDisplacement, y.WristLeftTotalDisplacement) &&
			GestureFeatureEquals(x.WristLeftMaximumDisplacement, y.WristLeftMaximumDisplacement) &&
			#endregion

			#region WristRight joint features
			GestureFeatureEquals(x.WristRightF1F2SpatialAngle, y.WristRightF1F2SpatialAngle) &&
			GestureFeatureEquals(x.WristRightFN_1FNSpatialAngle, y.WristRightFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristRightF1FNSpatialAngle, y.WristRightF1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristRightTotalVectorAngle, y.WristRightTotalVectorAngle) &&
			GestureFeatureEquals(x.WristRightSquaredTotalVectorAngle, y.WristRightSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.WristRightTotalVectorDisplacement, y.WristRightTotalVectorDisplacement) &&
			GestureFeatureEquals(x.WristRightTotalDisplacement, y.WristRightTotalDisplacement) &&
			GestureFeatureEquals(x.WristRightMaximumDisplacement, y.WristRightMaximumDisplacement) &&
			#endregion

			#region HandLeft joint features
			GestureFeatureEquals(x.HandLeftF1F2SpatialAngle, y.HandLeftF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandLeftFN_1FNSpatialAngle, y.HandLeftFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandLeftF1FNSpatialAngle, y.HandLeftF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandLeftTotalVectorAngle, y.HandLeftTotalVectorAngle) &&
			GestureFeatureEquals(x.HandLeftSquaredTotalVectorAngle, y.HandLeftSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandLeftTotalVectorDisplacement, y.HandLeftTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandLeftTotalDisplacement, y.HandLeftTotalDisplacement) &&
			GestureFeatureEquals(x.HandLeftMaximumDisplacement, y.HandLeftMaximumDisplacement) &&
			GestureFeatureEquals(x.HandLeftBoundingBoxDiagonalLength, y.HandLeftBoundingBoxDiagonalLength) &&
			GestureFeatureEquals(x.HandLeftBoundingBoxAngle, y.HandLeftBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandLeftHandStates
			#endregion

			#region HandRight joint features
			GestureFeatureEquals(x.HandRightF1F2SpatialAngle, y.HandRightF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandRightFN_1FNSpatialAngle, y.HandRightFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandRightF1FNSpatialAngle, y.HandRightF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandRightTotalVectorAngle, y.HandRightTotalVectorAngle) &&
			GestureFeatureEquals(x.HandRightSquaredTotalVectorAngle, y.HandRightSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandRightTotalVectorDisplacement, y.HandRightTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandRightTotalDisplacement, y.HandRightTotalDisplacement) &&
			GestureFeatureEquals(x.HandRightMaximumDisplacement, y.HandRightMaximumDisplacement) &&
			GestureFeatureEquals(x.HandRightBoundingBoxDiagonalLength, y.HandRightBoundingBoxDiagonalLength) &&
			GestureFeatureEquals(x.HandRightBoundingBoxAngle, y.HandRightBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandRightHandStates
			#endregion

			#region ThumbLeft joint features
			GestureFeatureEquals(x.ThumbLeftF1F2SpatialAngle, y.ThumbLeftF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbLeftFN_1FNSpatialAngle, y.ThumbLeftFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbLeftF1FNSpatialAngle, y.ThumbLeftF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbLeftTotalVectorAngle, y.ThumbLeftTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbLeftSquaredTotalVectorAngle, y.ThumbLeftSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbLeftTotalVectorDisplacement, y.ThumbLeftTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbLeftTotalDisplacement, y.ThumbLeftTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbLeftMaximumDisplacement, y.ThumbLeftMaximumDisplacement) &&
			#endregion

			#region ThumbRight joint features
			GestureFeatureEquals(x.ThumbRightF1F2SpatialAngle, y.ThumbRightF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbRightFN_1FNSpatialAngle, y.ThumbRightFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbRightF1FNSpatialAngle, y.ThumbRightF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbRightTotalVectorAngle, y.ThumbRightTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbRightSquaredTotalVectorAngle, y.ThumbRightSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbRightTotalVectorDisplacement, y.ThumbRightTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbRightTotalDisplacement, y.ThumbRightTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbRightMaximumDisplacement, y.ThumbRightMaximumDisplacement) &&
			#endregion

			#region HandTipLeft joint features
			GestureFeatureEquals(x.HandTipLeftF1F2SpatialAngle, y.HandTipLeftF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandTipLeftFN_1FNSpatialAngle, y.HandTipLeftFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipLeftF1FNSpatialAngle, y.HandTipLeftF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipLeftTotalVectorAngle, y.HandTipLeftTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipLeftSquaredTotalVectorAngle, y.HandTipLeftSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipLeftTotalVectorDisplacement, y.HandTipLeftTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandTipLeftTotalDisplacement, y.HandTipLeftTotalDisplacement) &&
			GestureFeatureEquals(x.HandTipLeftMaximumDisplacement, y.HandTipLeftMaximumDisplacement) &&
			#endregion

			#region HandTipRight joint features
			GestureFeatureEquals(x.HandTipRightF1F2SpatialAngle, y.HandTipRightF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandTipRightFN_1FNSpatialAngle, y.HandTipRightFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipRightF1FNSpatialAngle, y.HandTipRightF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipRightTotalVectorAngle, y.HandTipRightTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipRightSquaredTotalVectorAngle, y.HandTipRightSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipRightTotalVectorDisplacement, y.HandTipRightTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandTipRightTotalDisplacement, y.HandTipRightTotalDisplacement) &&
			GestureFeatureEquals(x.HandTipRightMaximumDisplacement, y.HandTipRightMaximumDisplacement) &&
			#endregion

			#region ElbowLeftWristLeft bone features
			GestureFeatureEquals(x.ElbowLeftWristLeftBoneInitialAngle, y.ElbowLeftWristLeftBoneInitialAngle) &&
			GestureFeatureEquals(x.ElbowLeftWristLeftBoneFinalAngle, y.ElbowLeftWristLeftBoneFinalAngle) &&
			GestureFeatureEquals(x.ElbowLeftWristLeftBoneMeanAngle, y.ElbowLeftWristLeftBoneMeanAngle) &&
			GestureFeatureEquals(x.ElbowLeftWristLeftBoneMaximumAngle, y.ElbowLeftWristLeftBoneMaximumAngle) &&
			#endregion

			#region ElbowRightWristRight bone features
			GestureFeatureEquals(x.ElbowRightWristRightBoneInitialAngle, y.ElbowRightWristRightBoneInitialAngle) &&
			GestureFeatureEquals(x.ElbowRightWristRightBoneFinalAngle, y.ElbowRightWristRightBoneFinalAngle) &&
			GestureFeatureEquals(x.ElbowRightWristRightBoneMeanAngle, y.ElbowRightWristRightBoneMeanAngle) &&
			GestureFeatureEquals(x.ElbowRightWristRightBoneMaximumAngle, y.ElbowRightWristRightBoneMaximumAngle) &&
			#endregion

			#region WristLeftHandLeft bone features
			GestureFeatureEquals(x.WristLeftHandLeftBoneInitialAngle, y.WristLeftHandLeftBoneInitialAngle) &&
			GestureFeatureEquals(x.WristLeftHandLeftBoneFinalAngle, y.WristLeftHandLeftBoneFinalAngle) &&
			GestureFeatureEquals(x.WristLeftHandLeftBoneMeanAngle, y.WristLeftHandLeftBoneMeanAngle) &&
			GestureFeatureEquals(x.WristLeftHandLeftBoneMaximumAngle, y.WristLeftHandLeftBoneMaximumAngle) &&
			#endregion

			#region WristRightHandRight bone features
			GestureFeatureEquals(x.WristRightHandRightBoneInitialAngle, y.WristRightHandRightBoneInitialAngle) &&
			GestureFeatureEquals(x.WristRightHandRightBoneFinalAngle, y.WristRightHandRightBoneFinalAngle) &&
			GestureFeatureEquals(x.WristRightHandRightBoneMeanAngle, y.WristRightHandRightBoneMeanAngle) &&
			GestureFeatureEquals(x.WristRightHandRightBoneMaximumAngle, y.WristRightHandRightBoneMaximumAngle) &&
			#endregion

			#region HandLeftHandTipLeft bone features
			GestureFeatureEquals(x.HandLeftHandTipLeftBoneInitialAngle, y.HandLeftHandTipLeftBoneInitialAngle) &&
			GestureFeatureEquals(x.HandLeftHandTipLeftBoneFinalAngle, y.HandLeftHandTipLeftBoneFinalAngle) &&
			GestureFeatureEquals(x.HandLeftHandTipLeftBoneMeanAngle, y.HandLeftHandTipLeftBoneMeanAngle) &&
			GestureFeatureEquals(x.HandLeftHandTipLeftBoneMaximumAngle, y.HandLeftHandTipLeftBoneMaximumAngle) &&
			#endregion

			#region HandRightHandTipRight bone features
			GestureFeatureEquals(x.HandRightHandTipRightBoneInitialAngle, y.HandRightHandTipRightBoneInitialAngle) &&
			GestureFeatureEquals(x.HandRightHandTipRightBoneFinalAngle, y.HandRightHandTipRightBoneFinalAngle) &&
			GestureFeatureEquals(x.HandRightHandTipRightBoneMeanAngle, y.HandRightHandTipRightBoneMeanAngle) &&
			GestureFeatureEquals(x.HandRightHandTipRightBoneMaximumAngle, y.HandRightHandTipRightBoneMaximumAngle) &&
			#endregion

			#region WristLeftThumbLeft bone features
			GestureFeatureEquals(x.WristLeftThumbLeftBoneInitialAngle, y.WristLeftThumbLeftBoneInitialAngle) &&
			GestureFeatureEquals(x.WristLeftThumbLeftBoneFinalAngle, y.WristLeftThumbLeftBoneFinalAngle) &&
			GestureFeatureEquals(x.WristLeftThumbLeftBoneMeanAngle, y.WristLeftThumbLeftBoneMeanAngle) &&
			GestureFeatureEquals(x.WristLeftThumbLeftBoneMaximumAngle, y.WristLeftThumbLeftBoneMaximumAngle) &&
			#endregion

			#region WristRightThumbRight bone features
			GestureFeatureEquals(x.WristRightThumbRightBoneInitialAngle, y.WristRightThumbRightBoneInitialAngle) &&
			GestureFeatureEquals(x.WristRightThumbRightBoneFinalAngle, y.WristRightThumbRightBoneFinalAngle) &&
			GestureFeatureEquals(x.WristRightThumbRightBoneMeanAngle, y.WristRightThumbRightBoneMeanAngle) &&
			GestureFeatureEquals(x.WristRightThumbRightBoneMaximumAngle, y.WristRightThumbRightBoneMaximumAngle) &&
			#endregion

			#region Hands distances features
			GestureFeatureEquals(x.BetweenHandJointsDistanceMax, y.BetweenHandJointsDistanceMax) &&
			GestureFeatureEquals(x.BetweenHandJointsDistanceMean, y.BetweenHandJointsDistanceMean) &&
			#endregion

			#region Label
			string.Equals(x.Label, y.Label, StringComparison.OrdinalIgnoreCase);
			#endregion
		}

		public int GetHashCode(KinectGestureDataView obj)
		{
			if (obj == null)
				return 0;

			var hash = new HashCode();

			#region ElbowLeft joint features
			hash.Add(obj.ElbowLeftF1F2SpatialAngle);
			hash.Add(obj.ElbowLeftFN_1FNSpatialAngle);
			hash.Add(obj.ElbowLeftF1FNSpatialAngle);
			hash.Add(obj.ElbowLeftTotalVectorAngle);
			hash.Add(obj.ElbowLeftSquaredTotalVectorAngle);
			hash.Add(obj.ElbowLeftTotalVectorDisplacement);
			hash.Add(obj.ElbowLeftTotalDisplacement);
			hash.Add(obj.ElbowLeftMaximumDisplacement);
			#endregion

			#region ElbowRight joint features
			hash.Add(obj.ElbowRightF1F2SpatialAngle);
			hash.Add(obj.ElbowRightFN_1FNSpatialAngle);
			hash.Add(obj.ElbowRightF1FNSpatialAngle);
			hash.Add(obj.ElbowRightTotalVectorAngle);
			hash.Add(obj.ElbowRightSquaredTotalVectorAngle);
			hash.Add(obj.ElbowRightTotalVectorDisplacement);
			hash.Add(obj.ElbowRightTotalDisplacement);
			hash.Add(obj.ElbowRightMaximumDisplacement);
			#endregion

			#region WristLeft joint features
			hash.Add(obj.WristLeftF1F2SpatialAngle);
			hash.Add(obj.WristLeftFN_1FNSpatialAngle);
			hash.Add(obj.WristLeftF1FNSpatialAngle);
			hash.Add(obj.WristLeftTotalVectorAngle);
			hash.Add(obj.WristLeftSquaredTotalVectorAngle);
			hash.Add(obj.WristLeftTotalVectorDisplacement);
			hash.Add(obj.WristLeftTotalDisplacement);
			hash.Add(obj.WristLeftMaximumDisplacement);
			#endregion

			#region WristRight joint features
			hash.Add(obj.WristRightF1F2SpatialAngle);
			hash.Add(obj.WristRightFN_1FNSpatialAngle);
			hash.Add(obj.WristRightF1FNSpatialAngle);
			hash.Add(obj.WristRightTotalVectorAngle);
			hash.Add(obj.WristRightSquaredTotalVectorAngle);
			hash.Add(obj.WristRightTotalVectorDisplacement);
			hash.Add(obj.WristRightTotalDisplacement);
			hash.Add(obj.WristRightMaximumDisplacement);
			#endregion

			#region HandLeft joint features
			hash.Add(obj.HandLeftF1F2SpatialAngle);
			hash.Add(obj.HandLeftFN_1FNSpatialAngle);
			hash.Add(obj.HandLeftF1FNSpatialAngle);
			hash.Add(obj.HandLeftTotalVectorAngle);
			hash.Add(obj.HandLeftSquaredTotalVectorAngle);
			hash.Add(obj.HandLeftTotalVectorDisplacement);
			hash.Add(obj.HandLeftTotalDisplacement);
			hash.Add(obj.HandLeftMaximumDisplacement);
			hash.Add(obj.HandLeftBoundingBoxDiagonalLength);
			hash.Add(obj.HandLeftBoundingBoxAngle);
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandLeftHandStates
			#endregion

			#region HandRight joint features
			hash.Add(obj.HandRightF1F2SpatialAngle);
			hash.Add(obj.HandRightFN_1FNSpatialAngle);
			hash.Add(obj.HandRightF1FNSpatialAngle);
			hash.Add(obj.HandRightTotalVectorAngle);
			hash.Add(obj.HandRightSquaredTotalVectorAngle);
			hash.Add(obj.HandRightTotalVectorDisplacement);
			hash.Add(obj.HandRightTotalDisplacement);
			hash.Add(obj.HandRightMaximumDisplacement);
			hash.Add(obj.HandRightBoundingBoxDiagonalLength);
			hash.Add(obj.HandRightBoundingBoxAngle);
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandRightHandStates
			#endregion

			#region ThumbLeft joint features
			hash.Add(obj.ThumbLeftF1F2SpatialAngle);
			hash.Add(obj.ThumbLeftFN_1FNSpatialAngle);
			hash.Add(obj.ThumbLeftF1FNSpatialAngle);
			hash.Add(obj.ThumbLeftTotalVectorAngle);
			hash.Add(obj.ThumbLeftSquaredTotalVectorAngle);
			hash.Add(obj.ThumbLeftTotalVectorDisplacement);
			hash.Add(obj.ThumbLeftTotalDisplacement);
			hash.Add(obj.ThumbLeftMaximumDisplacement);
			#endregion

			#region ThumbRight joint features
			hash.Add(obj.ThumbRightF1F2SpatialAngle);
			hash.Add(obj.ThumbRightFN_1FNSpatialAngle);
			hash.Add(obj.ThumbRightF1FNSpatialAngle);
			hash.Add(obj.ThumbRightTotalVectorAngle);
			hash.Add(obj.ThumbRightSquaredTotalVectorAngle);
			hash.Add(obj.ThumbRightTotalVectorDisplacement);
			hash.Add(obj.ThumbRightTotalDisplacement);
			hash.Add(obj.ThumbRightMaximumDisplacement);
			#endregion

			#region HandTipLeft joint features
			hash.Add(obj.HandTipLeftF1F2SpatialAngle);
			hash.Add(obj.HandTipLeftFN_1FNSpatialAngle);
			hash.Add(obj.HandTipLeftF1FNSpatialAngle);
			hash.Add(obj.HandTipLeftTotalVectorAngle);
			hash.Add(obj.HandTipLeftSquaredTotalVectorAngle);
			hash.Add(obj.HandTipLeftTotalVectorDisplacement);
			hash.Add(obj.HandTipLeftTotalDisplacement);
			hash.Add(obj.HandTipLeftMaximumDisplacement);
			#endregion

			#region HandTipRight joint features
			hash.Add(obj.HandTipRightF1F2SpatialAngle);
			hash.Add(obj.HandTipRightFN_1FNSpatialAngle);
			hash.Add(obj.HandTipRightF1FNSpatialAngle);
			hash.Add(obj.HandTipRightTotalVectorAngle);
			hash.Add(obj.HandTipRightSquaredTotalVectorAngle);
			hash.Add(obj.HandTipRightTotalVectorDisplacement);
			hash.Add(obj.HandTipRightTotalDisplacement);
			hash.Add(obj.HandTipRightMaximumDisplacement);
			#endregion

			#region ElbowLeftWristLeft bone features
			hash.Add(obj.ElbowLeftWristLeftBoneInitialAngle);
			hash.Add(obj.ElbowLeftWristLeftBoneFinalAngle);
			hash.Add(obj.ElbowLeftWristLeftBoneMeanAngle);
			hash.Add(obj.ElbowLeftWristLeftBoneMaximumAngle);
			#endregion

			#region ElbowRightWristRight bone features
			hash.Add(obj.ElbowRightWristRightBoneInitialAngle);
			hash.Add(obj.ElbowRightWristRightBoneFinalAngle);
			hash.Add(obj.ElbowRightWristRightBoneMeanAngle);
			hash.Add(obj.ElbowRightWristRightBoneMaximumAngle);
			#endregion

			#region WristLeftHandLeft bone features
			hash.Add(obj.WristLeftHandLeftBoneInitialAngle);
			hash.Add(obj.WristLeftHandLeftBoneFinalAngle);
			hash.Add(obj.WristLeftHandLeftBoneMeanAngle);
			hash.Add(obj.WristLeftHandLeftBoneMaximumAngle);
			#endregion

			#region WristRightHandRight bone features
			hash.Add(obj.WristRightHandRightBoneInitialAngle);
			hash.Add(obj.WristRightHandRightBoneFinalAngle);
			hash.Add(obj.WristRightHandRightBoneMeanAngle);
			hash.Add(obj.WristRightHandRightBoneMaximumAngle);
			#endregion

			#region HandLeftHandTipLeft bone features
			hash.Add(obj.HandLeftHandTipLeftBoneInitialAngle);
			hash.Add(obj.HandLeftHandTipLeftBoneFinalAngle);
			hash.Add(obj.HandLeftHandTipLeftBoneMeanAngle);
			hash.Add(obj.HandLeftHandTipLeftBoneMaximumAngle);
			#endregion

			#region HandRightHandTipRight bone features
			hash.Add(obj.HandRightHandTipRightBoneInitialAngle);
			hash.Add(obj.HandRightHandTipRightBoneFinalAngle);
			hash.Add(obj.HandRightHandTipRightBoneMeanAngle);
			hash.Add(obj.HandRightHandTipRightBoneMaximumAngle);
			#endregion

			#region WristLeftThumbLeft bone features
			hash.Add(obj.WristLeftThumbLeftBoneInitialAngle);
			hash.Add(obj.WristLeftThumbLeftBoneFinalAngle);
			hash.Add(obj.WristLeftThumbLeftBoneMeanAngle);
			hash.Add(obj.WristLeftThumbLeftBoneMaximumAngle);
			#endregion

			#region WristRightThumbRight bone features
			hash.Add(obj.WristRightThumbRightBoneInitialAngle);
			hash.Add(obj.WristRightThumbRightBoneFinalAngle);
			hash.Add(obj.WristRightThumbRightBoneMeanAngle);
			hash.Add(obj.WristRightThumbRightBoneMaximumAngle);
			#endregion

			#region Hands distances features
			hash.Add(obj.BetweenHandJointsDistanceMax);
			hash.Add(obj.BetweenHandJointsDistanceMean);
			#endregion

			#region Label
			hash.Add(obj.Label);
			#endregion

			return hash.ToHashCode();
		}
		#endregion
	}
}
