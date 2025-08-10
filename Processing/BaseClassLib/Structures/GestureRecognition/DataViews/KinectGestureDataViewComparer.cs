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
			NullableEquals(x.ElbowLeftF1F2SpatialAngle, y.ElbowLeftF1F2SpatialAngle) &&
			NullableEquals(x.ElbowLeftFN_1FNSpatialAngle, y.ElbowLeftFN_1FNSpatialAngle) &&
			NullableEquals(x.ElbowLeftF1FNSpatialAngle, y.ElbowLeftF1FNSpatialAngle) &&
			NullableEquals(x.ElbowLeftTotalVectorAngle, y.ElbowLeftTotalVectorAngle) &&
			NullableEquals(x.ElbowLeftSquaredTotalVectorAngle, y.ElbowLeftSquaredTotalVectorAngle) &&
			NullableEquals(x.ElbowLeftTotalVectorDisplacement, y.ElbowLeftTotalVectorDisplacement) &&
			NullableEquals(x.ElbowLeftTotalDisplacement, y.ElbowLeftTotalDisplacement) &&
			NullableEquals(x.ElbowLeftMaximumDisplacement, y.ElbowLeftMaximumDisplacement) &&
			#endregion

			#region ElbowRight joint features
			NullableEquals(x.ElbowRightF1F2SpatialAngle, y.ElbowRightF1F2SpatialAngle) &&
			NullableEquals(x.ElbowRightFN_1FNSpatialAngle, y.ElbowRightFN_1FNSpatialAngle) &&
			NullableEquals(x.ElbowRightF1FNSpatialAngle, y.ElbowRightF1FNSpatialAngle) &&
			NullableEquals(x.ElbowRightTotalVectorAngle, y.ElbowRightTotalVectorAngle) &&
			NullableEquals(x.ElbowRightSquaredTotalVectorAngle, y.ElbowRightSquaredTotalVectorAngle) &&
			NullableEquals(x.ElbowRightTotalVectorDisplacement, y.ElbowRightTotalVectorDisplacement) &&
			NullableEquals(x.ElbowRightTotalDisplacement, y.ElbowRightTotalDisplacement) &&
			NullableEquals(x.ElbowRightMaximumDisplacement, y.ElbowRightMaximumDisplacement) &&
			#endregion

			#region WristLeft joint features
			NullableEquals(x.WristLeftF1F2SpatialAngle, y.WristLeftF1F2SpatialAngle) &&
			NullableEquals(x.WristLeftFN_1FNSpatialAngle, y.WristLeftFN_1FNSpatialAngle) &&
			NullableEquals(x.WristLeftF1FNSpatialAngle, y.WristLeftF1FNSpatialAngle) &&
			NullableEquals(x.WristLeftTotalVectorAngle, y.WristLeftTotalVectorAngle) &&
			NullableEquals(x.WristLeftSquaredTotalVectorAngle, y.WristLeftSquaredTotalVectorAngle) &&
			NullableEquals(x.WristLeftTotalVectorDisplacement, y.WristLeftTotalVectorDisplacement) &&
			NullableEquals(x.WristLeftTotalDisplacement, y.WristLeftTotalDisplacement) &&
			NullableEquals(x.WristLeftMaximumDisplacement, y.WristLeftMaximumDisplacement) &&
			#endregion

			#region WristRight joint features
			NullableEquals(x.WristRightF1F2SpatialAngle, y.WristRightF1F2SpatialAngle) &&
			NullableEquals(x.WristRightFN_1FNSpatialAngle, y.WristRightFN_1FNSpatialAngle) &&
			NullableEquals(x.WristRightF1FNSpatialAngle, y.WristRightF1FNSpatialAngle) &&
			NullableEquals(x.WristRightTotalVectorAngle, y.WristRightTotalVectorAngle) &&
			NullableEquals(x.WristRightSquaredTotalVectorAngle, y.WristRightSquaredTotalVectorAngle) &&
			NullableEquals(x.WristRightTotalVectorDisplacement, y.WristRightTotalVectorDisplacement) &&
			NullableEquals(x.WristRightTotalDisplacement, y.WristRightTotalDisplacement) &&
			NullableEquals(x.WristRightMaximumDisplacement, y.WristRightMaximumDisplacement) &&
			#endregion

			#region HandLeft joint features
			NullableEquals(x.HandLeftF1F2SpatialAngle, y.HandLeftF1F2SpatialAngle) &&
			NullableEquals(x.HandLeftFN_1FNSpatialAngle, y.HandLeftFN_1FNSpatialAngle) &&
			NullableEquals(x.HandLeftF1FNSpatialAngle, y.HandLeftF1FNSpatialAngle) &&
			NullableEquals(x.HandLeftTotalVectorAngle, y.HandLeftTotalVectorAngle) &&
			NullableEquals(x.HandLeftSquaredTotalVectorAngle, y.HandLeftSquaredTotalVectorAngle) &&
			NullableEquals(x.HandLeftTotalVectorDisplacement, y.HandLeftTotalVectorDisplacement) &&
			NullableEquals(x.HandLeftTotalDisplacement, y.HandLeftTotalDisplacement) &&
			NullableEquals(x.HandLeftMaximumDisplacement, y.HandLeftMaximumDisplacement) &&
			NullableEquals(x.HandLeftBoundingBoxDiagonalLength, y.HandLeftBoundingBoxDiagonalLength) &&
			NullableEquals(x.HandLeftBoundingBoxAngle, y.HandLeftBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandLeftHandStates
			#endregion

			#region HandRight joint features
			NullableEquals(x.HandRightF1F2SpatialAngle, y.HandRightF1F2SpatialAngle) &&
			NullableEquals(x.HandRightFN_1FNSpatialAngle, y.HandRightFN_1FNSpatialAngle) &&
			NullableEquals(x.HandRightF1FNSpatialAngle, y.HandRightF1FNSpatialAngle) &&
			NullableEquals(x.HandRightTotalVectorAngle, y.HandRightTotalVectorAngle) &&
			NullableEquals(x.HandRightSquaredTotalVectorAngle, y.HandRightSquaredTotalVectorAngle) &&
			NullableEquals(x.HandRightTotalVectorDisplacement, y.HandRightTotalVectorDisplacement) &&
			NullableEquals(x.HandRightTotalDisplacement, y.HandRightTotalDisplacement) &&
			NullableEquals(x.HandRightMaximumDisplacement, y.HandRightMaximumDisplacement) &&
			NullableEquals(x.HandRightBoundingBoxDiagonalLength, y.HandRightBoundingBoxDiagonalLength) &&
			NullableEquals(x.HandRightBoundingBoxAngle, y.HandRightBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandRightHandStates
			#endregion

			#region ThumbLeft joint features
			NullableEquals(x.ThumbLeftF1F2SpatialAngle, y.ThumbLeftF1F2SpatialAngle) &&
			NullableEquals(x.ThumbLeftFN_1FNSpatialAngle, y.ThumbLeftFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbLeftF1FNSpatialAngle, y.ThumbLeftF1FNSpatialAngle) &&
			NullableEquals(x.ThumbLeftTotalVectorAngle, y.ThumbLeftTotalVectorAngle) &&
			NullableEquals(x.ThumbLeftSquaredTotalVectorAngle, y.ThumbLeftSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbLeftTotalVectorDisplacement, y.ThumbLeftTotalVectorDisplacement) &&
			NullableEquals(x.ThumbLeftTotalDisplacement, y.ThumbLeftTotalDisplacement) &&
			NullableEquals(x.ThumbLeftMaximumDisplacement, y.ThumbLeftMaximumDisplacement) &&
			#endregion

			#region ThumbRight joint features
			NullableEquals(x.ThumbRightF1F2SpatialAngle, y.ThumbRightF1F2SpatialAngle) &&
			NullableEquals(x.ThumbRightFN_1FNSpatialAngle, y.ThumbRightFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbRightF1FNSpatialAngle, y.ThumbRightF1FNSpatialAngle) &&
			NullableEquals(x.ThumbRightTotalVectorAngle, y.ThumbRightTotalVectorAngle) &&
			NullableEquals(x.ThumbRightSquaredTotalVectorAngle, y.ThumbRightSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbRightTotalVectorDisplacement, y.ThumbRightTotalVectorDisplacement) &&
			NullableEquals(x.ThumbRightTotalDisplacement, y.ThumbRightTotalDisplacement) &&
			NullableEquals(x.ThumbRightMaximumDisplacement, y.ThumbRightMaximumDisplacement) &&
			#endregion

			#region HandTipLeft joint features
			NullableEquals(x.HandTipLeftF1F2SpatialAngle, y.HandTipLeftF1F2SpatialAngle) &&
			NullableEquals(x.HandTipLeftFN_1FNSpatialAngle, y.HandTipLeftFN_1FNSpatialAngle) &&
			NullableEquals(x.HandTipLeftF1FNSpatialAngle, y.HandTipLeftF1FNSpatialAngle) &&
			NullableEquals(x.HandTipLeftTotalVectorAngle, y.HandTipLeftTotalVectorAngle) &&
			NullableEquals(x.HandTipLeftSquaredTotalVectorAngle, y.HandTipLeftSquaredTotalVectorAngle) &&
			NullableEquals(x.HandTipLeftTotalVectorDisplacement, y.HandTipLeftTotalVectorDisplacement) &&
			NullableEquals(x.HandTipLeftTotalDisplacement, y.HandTipLeftTotalDisplacement) &&
			NullableEquals(x.HandTipLeftMaximumDisplacement, y.HandTipLeftMaximumDisplacement) &&
			#endregion

			#region HandTipRight joint features
			NullableEquals(x.HandTipRightF1F2SpatialAngle, y.HandTipRightF1F2SpatialAngle) &&
			NullableEquals(x.HandTipRightFN_1FNSpatialAngle, y.HandTipRightFN_1FNSpatialAngle) &&
			NullableEquals(x.HandTipRightF1FNSpatialAngle, y.HandTipRightF1FNSpatialAngle) &&
			NullableEquals(x.HandTipRightTotalVectorAngle, y.HandTipRightTotalVectorAngle) &&
			NullableEquals(x.HandTipRightSquaredTotalVectorAngle, y.HandTipRightSquaredTotalVectorAngle) &&
			NullableEquals(x.HandTipRightTotalVectorDisplacement, y.HandTipRightTotalVectorDisplacement) &&
			NullableEquals(x.HandTipRightTotalDisplacement, y.HandTipRightTotalDisplacement) &&
			NullableEquals(x.HandTipRightMaximumDisplacement, y.HandTipRightMaximumDisplacement) &&
			#endregion

			#region ElbowLeftWristLeft bone features
			NullableEquals(x.ElbowLeftWristLeftBoneInitialAngle, y.ElbowLeftWristLeftBoneInitialAngle) &&
			NullableEquals(x.ElbowLeftWristLeftBoneFinalAngle, y.ElbowLeftWristLeftBoneFinalAngle) &&
			NullableEquals(x.ElbowLeftWristLeftBoneMeanAngle, y.ElbowLeftWristLeftBoneMeanAngle) &&
			NullableEquals(x.ElbowLeftWristLeftBoneMaximumAngle, y.ElbowLeftWristLeftBoneMaximumAngle) &&
			#endregion

			#region ElbowRightWristRight bone features
			NullableEquals(x.ElbowRightWristRightBoneInitialAngle, y.ElbowRightWristRightBoneInitialAngle) &&
			NullableEquals(x.ElbowRightWristRightBoneFinalAngle, y.ElbowRightWristRightBoneFinalAngle) &&
			NullableEquals(x.ElbowRightWristRightBoneMeanAngle, y.ElbowRightWristRightBoneMeanAngle) &&
			NullableEquals(x.ElbowRightWristRightBoneMaximumAngle, y.ElbowRightWristRightBoneMaximumAngle) &&
			#endregion

			#region WristLeftHandLeft bone features
			NullableEquals(x.WristLeftHandLeftBoneInitialAngle, y.WristLeftHandLeftBoneInitialAngle) &&
			NullableEquals(x.WristLeftHandLeftBoneFinalAngle, y.WristLeftHandLeftBoneFinalAngle) &&
			NullableEquals(x.WristLeftHandLeftBoneMeanAngle, y.WristLeftHandLeftBoneMeanAngle) &&
			NullableEquals(x.WristLeftHandLeftBoneMaximumAngle, y.WristLeftHandLeftBoneMaximumAngle) &&
			#endregion

			#region WristRightHandRight bone features
			NullableEquals(x.WristRightHandRightBoneInitialAngle, y.WristRightHandRightBoneInitialAngle) &&
			NullableEquals(x.WristRightHandRightBoneFinalAngle, y.WristRightHandRightBoneFinalAngle) &&
			NullableEquals(x.WristRightHandRightBoneMeanAngle, y.WristRightHandRightBoneMeanAngle) &&
			NullableEquals(x.WristRightHandRightBoneMaximumAngle, y.WristRightHandRightBoneMaximumAngle) &&
			#endregion

			#region HandLeftHandTipLeft bone features
			NullableEquals(x.HandLeftHandTipLeftBoneInitialAngle, y.HandLeftHandTipLeftBoneInitialAngle) &&
			NullableEquals(x.HandLeftHandTipLeftBoneFinalAngle, y.HandLeftHandTipLeftBoneFinalAngle) &&
			NullableEquals(x.HandLeftHandTipLeftBoneMeanAngle, y.HandLeftHandTipLeftBoneMeanAngle) &&
			NullableEquals(x.HandLeftHandTipLeftBoneMaximumAngle, y.HandLeftHandTipLeftBoneMaximumAngle) &&
			#endregion

			#region HandRightHandTipRight bone features
			NullableEquals(x.HandRightHandTipRightBoneInitialAngle, y.HandRightHandTipRightBoneInitialAngle) &&
			NullableEquals(x.HandRightHandTipRightBoneFinalAngle, y.HandRightHandTipRightBoneFinalAngle) &&
			NullableEquals(x.HandRightHandTipRightBoneMeanAngle, y.HandRightHandTipRightBoneMeanAngle) &&
			NullableEquals(x.HandRightHandTipRightBoneMaximumAngle, y.HandRightHandTipRightBoneMaximumAngle) &&
			#endregion

			#region Hands distances features
			NullableEquals(x.BetweenHandJointsDistanceMax, y.BetweenHandJointsDistanceMax) &&
			NullableEquals(x.BetweenHandJointsDistanceMean, y.BetweenHandJointsDistanceMean) &&
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
