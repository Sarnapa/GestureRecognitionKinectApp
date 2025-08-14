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
			#region ElbowDominant joint features
			GestureFeatureEquals(x.ElbowDominantF1F2SpatialAngle, y.ElbowDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ElbowDominantFN_1FNSpatialAngle, y.ElbowDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowDominantF1FNSpatialAngle, y.ElbowDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowDominantTotalVectorAngle, y.ElbowDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowDominantSquaredTotalVectorAngle, y.ElbowDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowDominantTotalVectorDisplacement, y.ElbowDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ElbowDominantTotalDisplacement, y.ElbowDominantTotalDisplacement) &&
			GestureFeatureEquals(x.ElbowDominantMaximumDisplacement, y.ElbowDominantMaximumDisplacement) &&
			#endregion

			#region ElbowNondominant joint features
			GestureFeatureEquals(x.ElbowNondominantF1F2SpatialAngle, y.ElbowNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ElbowNondominantFN_1FNSpatialAngle, y.ElbowNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowNondominantF1FNSpatialAngle, y.ElbowNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ElbowNondominantTotalVectorAngle, y.ElbowNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowNondominantSquaredTotalVectorAngle, y.ElbowNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ElbowNondominantTotalVectorDisplacement, y.ElbowNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ElbowNondominantTotalDisplacement, y.ElbowNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.ElbowNondominantMaximumDisplacement, y.ElbowNondominantMaximumDisplacement) &&
			#endregion

			#region WristDominant joint features
			GestureFeatureEquals(x.WristDominantF1F2SpatialAngle, y.WristDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.WristDominantFN_1FNSpatialAngle, y.WristDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristDominantF1FNSpatialAngle, y.WristDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristDominantTotalVectorAngle, y.WristDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.WristDominantSquaredTotalVectorAngle, y.WristDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.WristDominantTotalVectorDisplacement, y.WristDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.WristDominantTotalDisplacement, y.WristDominantTotalDisplacement) &&
			GestureFeatureEquals(x.WristDominantMaximumDisplacement, y.WristDominantMaximumDisplacement) &&
			#endregion

			#region WristNondominant joint features
			GestureFeatureEquals(x.WristNondominantF1F2SpatialAngle, y.WristNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.WristNondominantFN_1FNSpatialAngle, y.WristNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristNondominantF1FNSpatialAngle, y.WristNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.WristNondominantTotalVectorAngle, y.WristNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.WristNondominantSquaredTotalVectorAngle, y.WristNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.WristNondominantTotalVectorDisplacement, y.WristNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.WristNondominantTotalDisplacement, y.WristNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.WristNondominantMaximumDisplacement, y.WristNondominantMaximumDisplacement) &&
			#endregion

			#region HandDominant joint features
			GestureFeatureEquals(x.HandDominantF1F2SpatialAngle, y.HandDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandDominantFN_1FNSpatialAngle, y.HandDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandDominantF1FNSpatialAngle, y.HandDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandDominantTotalVectorAngle, y.HandDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.HandDominantSquaredTotalVectorAngle, y.HandDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandDominantTotalVectorDisplacement, y.HandDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandDominantTotalDisplacement, y.HandDominantTotalDisplacement) &&
			GestureFeatureEquals(x.HandDominantMaximumDisplacement, y.HandDominantMaximumDisplacement) &&
			GestureFeatureEquals(x.HandDominantBoundingBoxDiagonalLength, y.HandDominantBoundingBoxDiagonalLength) &&
			GestureFeatureEquals(x.HandDominantBoundingBoxAngle, y.HandDominantBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandDominantHandStates
			#endregion

			#region HandNondominant joint features
			GestureFeatureEquals(x.HandNondominantF1F2SpatialAngle, y.HandNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandNondominantFN_1FNSpatialAngle, y.HandNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandNondominantF1FNSpatialAngle, y.HandNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandNondominantTotalVectorAngle, y.HandNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.HandNondominantSquaredTotalVectorAngle, y.HandNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandNondominantTotalVectorDisplacement, y.HandNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandNondominantTotalDisplacement, y.HandNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.HandNondominantMaximumDisplacement, y.HandNondominantMaximumDisplacement) &&
			GestureFeatureEquals(x.HandNondominantBoundingBoxDiagonalLength, y.HandNondominantBoundingBoxDiagonalLength) &&
			GestureFeatureEquals(x.HandNondominantBoundingBoxAngle, y.HandNondominantBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandNondominantHandStates
			#endregion

			#region ThumbDominant joint features
			GestureFeatureEquals(x.ThumbDominantF1F2SpatialAngle, y.ThumbDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbDominantFN_1FNSpatialAngle, y.ThumbDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbDominantF1FNSpatialAngle, y.ThumbDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbDominantTotalVectorAngle, y.ThumbDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbDominantSquaredTotalVectorAngle, y.ThumbDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbDominantTotalVectorDisplacement, y.ThumbDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbDominantTotalDisplacement, y.ThumbDominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbDominantMaximumDisplacement, y.ThumbDominantMaximumDisplacement) &&
			#endregion

			#region ThumbNondominant joint features
			GestureFeatureEquals(x.ThumbNondominantF1F2SpatialAngle, y.ThumbNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbNondominantFN_1FNSpatialAngle, y.ThumbNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbNondominantF1FNSpatialAngle, y.ThumbNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbNondominantTotalVectorAngle, y.ThumbNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbNondominantSquaredTotalVectorAngle, y.ThumbNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbNondominantTotalVectorDisplacement, y.ThumbNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbNondominantTotalDisplacement, y.ThumbNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbNondominantMaximumDisplacement, y.ThumbNondominantMaximumDisplacement) &&
			#endregion

			#region HandTipDominant joint features
			GestureFeatureEquals(x.HandTipDominantF1F2SpatialAngle, y.HandTipDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandTipDominantFN_1FNSpatialAngle, y.HandTipDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipDominantF1FNSpatialAngle, y.HandTipDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipDominantTotalVectorAngle, y.HandTipDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipDominantSquaredTotalVectorAngle, y.HandTipDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipDominantTotalVectorDisplacement, y.HandTipDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandTipDominantTotalDisplacement, y.HandTipDominantTotalDisplacement) &&
			GestureFeatureEquals(x.HandTipDominantMaximumDisplacement, y.HandTipDominantMaximumDisplacement) &&
			#endregion

			#region HandTipNondominant joint features
			GestureFeatureEquals(x.HandTipNondominantF1F2SpatialAngle, y.HandTipNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.HandTipNondominantFN_1FNSpatialAngle, y.HandTipNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipNondominantF1FNSpatialAngle, y.HandTipNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.HandTipNondominantTotalVectorAngle, y.HandTipNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipNondominantSquaredTotalVectorAngle, y.HandTipNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.HandTipNondominantTotalVectorDisplacement, y.HandTipNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.HandTipNondominantTotalDisplacement, y.HandTipNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.HandTipNondominantMaximumDisplacement, y.HandTipNondominantMaximumDisplacement) &&
			#endregion

			#region ElbowWristDominant bone features
			GestureFeatureEquals(x.ElbowWristDominantBoneInitialAngle, y.ElbowWristDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ElbowWristDominantBoneFinalAngle, y.ElbowWristDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ElbowWristDominantBoneMeanAngle, y.ElbowWristDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ElbowWristDominantBoneMaximumAngle, y.ElbowWristDominantBoneMaximumAngle) &&
			#endregion

			#region ElbowWristNondominant bone features
			GestureFeatureEquals(x.ElbowWristNondominantBoneInitialAngle, y.ElbowWristNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ElbowWristNondominantBoneFinalAngle, y.ElbowWristNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ElbowWristNondominantBoneMeanAngle, y.ElbowWristNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ElbowWristNondominantBoneMaximumAngle, y.ElbowWristNondominantBoneMaximumAngle) &&
			#endregion

			#region WristHandDominant bone features
			GestureFeatureEquals(x.WristHandDominantBoneInitialAngle, y.WristHandDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristHandDominantBoneFinalAngle, y.WristHandDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristHandDominantBoneMeanAngle, y.WristHandDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristHandDominantBoneMaximumAngle, y.WristHandDominantBoneMaximumAngle) &&
			#endregion

			#region WristHandNondominant bone features
			GestureFeatureEquals(x.WristHandNondominantBoneInitialAngle, y.WristHandNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristHandNondominantBoneFinalAngle, y.WristHandNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristHandNondominantBoneMeanAngle, y.WristHandNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristHandNondominantBoneMaximumAngle, y.WristHandNondominantBoneMaximumAngle) &&
			#endregion

			#region HandHandTipDominant bone features
			GestureFeatureEquals(x.HandHandTipDominantBoneInitialAngle, y.HandHandTipDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.HandHandTipDominantBoneFinalAngle, y.HandHandTipDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.HandHandTipDominantBoneMeanAngle, y.HandHandTipDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.HandHandTipDominantBoneMaximumAngle, y.HandHandTipDominantBoneMaximumAngle) &&
			#endregion

			#region HandHandTipNondominant bone features
			GestureFeatureEquals(x.HandHandTipNondominantBoneInitialAngle, y.HandHandTipNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.HandHandTipNondominantBoneFinalAngle, y.HandHandTipNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.HandHandTipNondominantBoneMeanAngle, y.HandHandTipNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.HandHandTipNondominantBoneMaximumAngle, y.HandHandTipNondominantBoneMaximumAngle) &&
			#endregion

			#region WristThumbDominant bone features
			GestureFeatureEquals(x.WristThumbDominantBoneInitialAngle, y.WristThumbDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristThumbDominantBoneFinalAngle, y.WristThumbDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristThumbDominantBoneMeanAngle, y.WristThumbDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristThumbDominantBoneMaximumAngle, y.WristThumbDominantBoneMaximumAngle) &&
			#endregion

			#region WristThumbNondominant bone features
			GestureFeatureEquals(x.WristThumbNondominantBoneInitialAngle, y.WristThumbNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristThumbNondominantBoneFinalAngle, y.WristThumbNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristThumbNondominantBoneMeanAngle, y.WristThumbNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristThumbNondominantBoneMaximumAngle, y.WristThumbNondominantBoneMaximumAngle) &&
			#endregion

			#region Hands distances features
			GestureFeatureEquals(x.BetweenHandJointsDistanceMax, y.BetweenHandJointsDistanceMax) &&
			GestureFeatureEquals(x.BetweenHandJointsDistanceMean, y.BetweenHandJointsDistanceMean) &&
			#endregion

			#region HandDominance
			x.HandDominance == y.HandDominance &&
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

			#region ElbowDominant joint features
			hash.Add(obj.ElbowDominantF1F2SpatialAngle);
			hash.Add(obj.ElbowDominantFN_1FNSpatialAngle);
			hash.Add(obj.ElbowDominantF1FNSpatialAngle);
			hash.Add(obj.ElbowDominantTotalVectorAngle);
			hash.Add(obj.ElbowDominantSquaredTotalVectorAngle);
			hash.Add(obj.ElbowDominantTotalVectorDisplacement);
			hash.Add(obj.ElbowDominantTotalDisplacement);
			hash.Add(obj.ElbowDominantMaximumDisplacement);
			#endregion

			#region ElbowNondominant joint features
			hash.Add(obj.ElbowNondominantF1F2SpatialAngle);
			hash.Add(obj.ElbowNondominantFN_1FNSpatialAngle);
			hash.Add(obj.ElbowNondominantF1FNSpatialAngle);
			hash.Add(obj.ElbowNondominantTotalVectorAngle);
			hash.Add(obj.ElbowNondominantSquaredTotalVectorAngle);
			hash.Add(obj.ElbowNondominantTotalVectorDisplacement);
			hash.Add(obj.ElbowNondominantTotalDisplacement);
			hash.Add(obj.ElbowNondominantMaximumDisplacement);
			#endregion

			#region WristDominant joint features
			hash.Add(obj.WristDominantF1F2SpatialAngle);
			hash.Add(obj.WristDominantFN_1FNSpatialAngle);
			hash.Add(obj.WristDominantF1FNSpatialAngle);
			hash.Add(obj.WristDominantTotalVectorAngle);
			hash.Add(obj.WristDominantSquaredTotalVectorAngle);
			hash.Add(obj.WristDominantTotalVectorDisplacement);
			hash.Add(obj.WristDominantTotalDisplacement);
			hash.Add(obj.WristDominantMaximumDisplacement);
			#endregion

			#region WristNondominant joint features
			hash.Add(obj.WristNondominantF1F2SpatialAngle);
			hash.Add(obj.WristNondominantFN_1FNSpatialAngle);
			hash.Add(obj.WristNondominantF1FNSpatialAngle);
			hash.Add(obj.WristNondominantTotalVectorAngle);
			hash.Add(obj.WristNondominantSquaredTotalVectorAngle);
			hash.Add(obj.WristNondominantTotalVectorDisplacement);
			hash.Add(obj.WristNondominantTotalDisplacement);
			hash.Add(obj.WristNondominantMaximumDisplacement);
			#endregion

			#region HandDominant joint features
			hash.Add(obj.HandDominantF1F2SpatialAngle);
			hash.Add(obj.HandDominantFN_1FNSpatialAngle);
			hash.Add(obj.HandDominantF1FNSpatialAngle);
			hash.Add(obj.HandDominantTotalVectorAngle);
			hash.Add(obj.HandDominantSquaredTotalVectorAngle);
			hash.Add(obj.HandDominantTotalVectorDisplacement);
			hash.Add(obj.HandDominantTotalDisplacement);
			hash.Add(obj.HandDominantMaximumDisplacement);
			hash.Add(obj.HandDominantBoundingBoxDiagonalLength);
			hash.Add(obj.HandDominantBoundingBoxAngle);
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandDominantHandStates
			#endregion

			#region HandNondominant joint features
			hash.Add(obj.HandNondominantF1F2SpatialAngle);
			hash.Add(obj.HandNondominantFN_1FNSpatialAngle);
			hash.Add(obj.HandNondominantF1FNSpatialAngle);
			hash.Add(obj.HandNondominantTotalVectorAngle);
			hash.Add(obj.HandNondominantSquaredTotalVectorAngle);
			hash.Add(obj.HandNondominantTotalVectorDisplacement);
			hash.Add(obj.HandNondominantTotalDisplacement);
			hash.Add(obj.HandNondominantMaximumDisplacement);
			hash.Add(obj.HandNondominantBoundingBoxDiagonalLength);
			hash.Add(obj.HandNondominantBoundingBoxAngle);
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandNondominantHandStates
			#endregion

			#region ThumbDominant joint features
			hash.Add(obj.ThumbDominantF1F2SpatialAngle);
			hash.Add(obj.ThumbDominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbDominantF1FNSpatialAngle);
			hash.Add(obj.ThumbDominantTotalVectorAngle);
			hash.Add(obj.ThumbDominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbDominantTotalVectorDisplacement);
			hash.Add(obj.ThumbDominantTotalDisplacement);
			hash.Add(obj.ThumbDominantMaximumDisplacement);
			#endregion

			#region ThumbNondominant joint features
			hash.Add(obj.ThumbNondominantF1F2SpatialAngle);
			hash.Add(obj.ThumbNondominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbNondominantF1FNSpatialAngle);
			hash.Add(obj.ThumbNondominantTotalVectorAngle);
			hash.Add(obj.ThumbNondominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbNondominantTotalVectorDisplacement);
			hash.Add(obj.ThumbNondominantTotalDisplacement);
			hash.Add(obj.ThumbNondominantMaximumDisplacement);
			#endregion

			#region HandTipDominant joint features
			hash.Add(obj.HandTipDominantF1F2SpatialAngle);
			hash.Add(obj.HandTipDominantFN_1FNSpatialAngle);
			hash.Add(obj.HandTipDominantF1FNSpatialAngle);
			hash.Add(obj.HandTipDominantTotalVectorAngle);
			hash.Add(obj.HandTipDominantSquaredTotalVectorAngle);
			hash.Add(obj.HandTipDominantTotalVectorDisplacement);
			hash.Add(obj.HandTipDominantTotalDisplacement);
			hash.Add(obj.HandTipDominantMaximumDisplacement);
			#endregion

			#region HandTipNondominant joint features
			hash.Add(obj.HandTipNondominantF1F2SpatialAngle);
			hash.Add(obj.HandTipNondominantFN_1FNSpatialAngle);
			hash.Add(obj.HandTipNondominantF1FNSpatialAngle);
			hash.Add(obj.HandTipNondominantTotalVectorAngle);
			hash.Add(obj.HandTipNondominantSquaredTotalVectorAngle);
			hash.Add(obj.HandTipNondominantTotalVectorDisplacement);
			hash.Add(obj.HandTipNondominantTotalDisplacement);
			hash.Add(obj.HandTipNondominantMaximumDisplacement);
			#endregion

			#region ElbowWristDominant bone features
			hash.Add(obj.ElbowWristDominantBoneInitialAngle);
			hash.Add(obj.ElbowWristDominantBoneFinalAngle);
			hash.Add(obj.ElbowWristDominantBoneMeanAngle);
			hash.Add(obj.ElbowWristDominantBoneMaximumAngle);
			#endregion

			#region ElbowWristNondominant bone features
			hash.Add(obj.ElbowWristNondominantBoneInitialAngle);
			hash.Add(obj.ElbowWristNondominantBoneFinalAngle);
			hash.Add(obj.ElbowWristNondominantBoneMeanAngle);
			hash.Add(obj.ElbowWristNondominantBoneMaximumAngle);
			#endregion

			#region WristHandDominant bone features
			hash.Add(obj.WristHandDominantBoneInitialAngle);
			hash.Add(obj.WristHandDominantBoneFinalAngle);
			hash.Add(obj.WristHandDominantBoneMeanAngle);
			hash.Add(obj.WristHandDominantBoneMaximumAngle);
			#endregion

			#region WristHandNondominant bone features
			hash.Add(obj.WristHandNondominantBoneInitialAngle);
			hash.Add(obj.WristHandNondominantBoneFinalAngle);
			hash.Add(obj.WristHandNondominantBoneMeanAngle);
			hash.Add(obj.WristHandNondominantBoneMaximumAngle);
			#endregion

			#region HandHandTipDominant bone features
			hash.Add(obj.HandHandTipDominantBoneInitialAngle);
			hash.Add(obj.HandHandTipDominantBoneFinalAngle);
			hash.Add(obj.HandHandTipDominantBoneMeanAngle);
			hash.Add(obj.HandHandTipDominantBoneMaximumAngle);
			#endregion

			#region HandHandTipNondominant bone features
			hash.Add(obj.HandHandTipNondominantBoneInitialAngle);
			hash.Add(obj.HandHandTipNondominantBoneFinalAngle);
			hash.Add(obj.HandHandTipNondominantBoneMeanAngle);
			hash.Add(obj.HandHandTipNondominantBoneMaximumAngle);
			#endregion

			#region WristThumbDominant bone features
			hash.Add(obj.WristThumbDominantBoneInitialAngle);
			hash.Add(obj.WristThumbDominantBoneFinalAngle);
			hash.Add(obj.WristThumbDominantBoneMeanAngle);
			hash.Add(obj.WristThumbDominantBoneMaximumAngle);
			#endregion

			#region WristThumbNondominant bone features
			hash.Add(obj.WristThumbNondominantBoneInitialAngle);
			hash.Add(obj.WristThumbNondominantBoneFinalAngle);
			hash.Add(obj.WristThumbNondominantBoneMeanAngle);
			hash.Add(obj.WristThumbNondominantBoneMaximumAngle);
			#endregion

			#region Hands distances features
			hash.Add(obj.BetweenHandJointsDistanceMax);
			hash.Add(obj.BetweenHandJointsDistanceMean);
			#endregion

			#region HandDominance
			hash.Add(obj.HandDominance);
			#endregion

			#region Label
			hash.Add(obj.Label);
			#endregion

			return hash.ToHashCode();
		}
		#endregion
	}
}
