using System;
using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using static GestureRecognition.Processing.BaseClassLib.Utils.DataViewsUtils;


namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews
{
	public class MediaPipeHandLandmarksGestureDataViewComparer: IEqualityComparer<MediaPipeHandLandmarksGestureDataView>
	{
		#region Instance
		public static MediaPipeHandLandmarksGestureDataViewComparer Instance = new MediaPipeHandLandmarksGestureDataViewComparer();
		#endregion

		#region IEqualityComparer implementation
		public bool Equals(MediaPipeHandLandmarksGestureDataView x, MediaPipeHandLandmarksGestureDataView y)
		{
			if (ReferenceEquals(x, y))
				return true;

			if (x == null || y == null)
				return false;

			return
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

			#region ThumbCMCDominant joint features
			GestureFeatureEquals(x.ThumbCMCDominantF1F2SpatialAngle, y.ThumbCMCDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbCMCDominantFN_1FNSpatialAngle, y.ThumbCMCDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbCMCDominantF1FNSpatialAngle, y.ThumbCMCDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbCMCDominantTotalVectorAngle, y.ThumbCMCDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbCMCDominantSquaredTotalVectorAngle, y.ThumbCMCDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbCMCDominantTotalVectorDisplacement, y.ThumbCMCDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbCMCDominantTotalDisplacement, y.ThumbCMCDominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbCMCDominantMaximumDisplacement, y.ThumbCMCDominantMaximumDisplacement) &&
			#endregion

			#region ThumbMCPDominant joint features
			GestureFeatureEquals(x.ThumbMCPDominantF1F2SpatialAngle, y.ThumbMCPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbMCPDominantFN_1FNSpatialAngle, y.ThumbMCPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbMCPDominantF1FNSpatialAngle, y.ThumbMCPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbMCPDominantTotalVectorAngle, y.ThumbMCPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbMCPDominantSquaredTotalVectorAngle, y.ThumbMCPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbMCPDominantTotalVectorDisplacement, y.ThumbMCPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbMCPDominantTotalDisplacement, y.ThumbMCPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbMCPDominantMaximumDisplacement, y.ThumbMCPDominantMaximumDisplacement) &&
			#endregion

			#region ThumbIPDominant joint features
			GestureFeatureEquals(x.ThumbIPDominantF1F2SpatialAngle, y.ThumbIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbIPDominantFN_1FNSpatialAngle, y.ThumbIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbIPDominantF1FNSpatialAngle, y.ThumbIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbIPDominantTotalVectorAngle, y.ThumbIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbIPDominantSquaredTotalVectorAngle, y.ThumbIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbIPDominantTotalVectorDisplacement, y.ThumbIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbIPDominantTotalDisplacement, y.ThumbIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbIPDominantMaximumDisplacement, y.ThumbIPDominantMaximumDisplacement) &&
			#endregion

			#region ThumbTIPDominant joint features
			GestureFeatureEquals(x.ThumbTIPDominantF1F2SpatialAngle, y.ThumbTIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbTIPDominantFN_1FNSpatialAngle, y.ThumbTIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbTIPDominantF1FNSpatialAngle, y.ThumbTIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbTIPDominantTotalVectorAngle, y.ThumbTIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbTIPDominantSquaredTotalVectorAngle, y.ThumbTIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbTIPDominantTotalVectorDisplacement, y.ThumbTIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbTIPDominantTotalDisplacement, y.ThumbTIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbTIPDominantMaximumDisplacement, y.ThumbTIPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerMCPDominant joint features
			GestureFeatureEquals(x.IndexFingerMCPDominantF1F2SpatialAngle, y.IndexFingerMCPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantFN_1FNSpatialAngle, y.IndexFingerMCPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantF1FNSpatialAngle, y.IndexFingerMCPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantTotalVectorAngle, y.IndexFingerMCPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantSquaredTotalVectorAngle, y.IndexFingerMCPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantTotalVectorDisplacement, y.IndexFingerMCPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantTotalDisplacement, y.IndexFingerMCPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerMCPDominantMaximumDisplacement, y.IndexFingerMCPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerPIPDominant joint features
			GestureFeatureEquals(x.IndexFingerPIPDominantF1F2SpatialAngle, y.IndexFingerPIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantFN_1FNSpatialAngle, y.IndexFingerPIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantF1FNSpatialAngle, y.IndexFingerPIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantTotalVectorAngle, y.IndexFingerPIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantSquaredTotalVectorAngle, y.IndexFingerPIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantTotalVectorDisplacement, y.IndexFingerPIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantTotalDisplacement, y.IndexFingerPIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerPIPDominantMaximumDisplacement, y.IndexFingerPIPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerDIPDominant joint features
			GestureFeatureEquals(x.IndexFingerDIPDominantF1F2SpatialAngle, y.IndexFingerDIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantFN_1FNSpatialAngle, y.IndexFingerDIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantF1FNSpatialAngle, y.IndexFingerDIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantTotalVectorAngle, y.IndexFingerDIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantSquaredTotalVectorAngle, y.IndexFingerDIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantTotalVectorDisplacement, y.IndexFingerDIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantTotalDisplacement, y.IndexFingerDIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerDIPDominantMaximumDisplacement, y.IndexFingerDIPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerTIPDominant joint features
			GestureFeatureEquals(x.IndexFingerTIPDominantF1F2SpatialAngle, y.IndexFingerTIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantFN_1FNSpatialAngle, y.IndexFingerTIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantF1FNSpatialAngle, y.IndexFingerTIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantTotalVectorAngle, y.IndexFingerTIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantSquaredTotalVectorAngle, y.IndexFingerTIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantTotalVectorDisplacement, y.IndexFingerTIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantTotalDisplacement, y.IndexFingerTIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerTIPDominantMaximumDisplacement, y.IndexFingerTIPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerMCPDominant joint features
			GestureFeatureEquals(x.MiddleFingerMCPDominantF1F2SpatialAngle, y.MiddleFingerMCPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantFN_1FNSpatialAngle, y.MiddleFingerMCPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantF1FNSpatialAngle, y.MiddleFingerMCPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantTotalVectorAngle, y.MiddleFingerMCPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantSquaredTotalVectorAngle, y.MiddleFingerMCPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantTotalVectorDisplacement, y.MiddleFingerMCPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantTotalDisplacement, y.MiddleFingerMCPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerMCPDominantMaximumDisplacement, y.MiddleFingerMCPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerPIPDominant joint features
			GestureFeatureEquals(x.MiddleFingerPIPDominantF1F2SpatialAngle, y.MiddleFingerPIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantFN_1FNSpatialAngle, y.MiddleFingerPIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantF1FNSpatialAngle, y.MiddleFingerPIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantTotalVectorAngle, y.MiddleFingerPIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantSquaredTotalVectorAngle, y.MiddleFingerPIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantTotalVectorDisplacement, y.MiddleFingerPIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantTotalDisplacement, y.MiddleFingerPIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerPIPDominantMaximumDisplacement, y.MiddleFingerPIPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerDIPDominant joint features
			GestureFeatureEquals(x.MiddleFingerDIPDominantF1F2SpatialAngle, y.MiddleFingerDIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantFN_1FNSpatialAngle, y.MiddleFingerDIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantF1FNSpatialAngle, y.MiddleFingerDIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantTotalVectorAngle, y.MiddleFingerDIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantSquaredTotalVectorAngle, y.MiddleFingerDIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantTotalVectorDisplacement, y.MiddleFingerDIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantTotalDisplacement, y.MiddleFingerDIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerDIPDominantMaximumDisplacement, y.MiddleFingerDIPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerTIPDominant joint features
			GestureFeatureEquals(x.MiddleFingerTIPDominantF1F2SpatialAngle, y.MiddleFingerTIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantFN_1FNSpatialAngle, y.MiddleFingerTIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantF1FNSpatialAngle, y.MiddleFingerTIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantTotalVectorAngle, y.MiddleFingerTIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantSquaredTotalVectorAngle, y.MiddleFingerTIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantTotalVectorDisplacement, y.MiddleFingerTIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantTotalDisplacement, y.MiddleFingerTIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerTIPDominantMaximumDisplacement, y.MiddleFingerTIPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerMCPDominant joint features
			GestureFeatureEquals(x.RingFingerMCPDominantF1F2SpatialAngle, y.RingFingerMCPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPDominantFN_1FNSpatialAngle, y.RingFingerMCPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPDominantF1FNSpatialAngle, y.RingFingerMCPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPDominantTotalVectorAngle, y.RingFingerMCPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerMCPDominantSquaredTotalVectorAngle, y.RingFingerMCPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerMCPDominantTotalVectorDisplacement, y.RingFingerMCPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerMCPDominantTotalDisplacement, y.RingFingerMCPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerMCPDominantMaximumDisplacement, y.RingFingerMCPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerPIPDominant joint features
			GestureFeatureEquals(x.RingFingerPIPDominantF1F2SpatialAngle, y.RingFingerPIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPDominantFN_1FNSpatialAngle, y.RingFingerPIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPDominantF1FNSpatialAngle, y.RingFingerPIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPDominantTotalVectorAngle, y.RingFingerPIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerPIPDominantSquaredTotalVectorAngle, y.RingFingerPIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerPIPDominantTotalVectorDisplacement, y.RingFingerPIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerPIPDominantTotalDisplacement, y.RingFingerPIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerPIPDominantMaximumDisplacement, y.RingFingerPIPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerDIPDominant joint features
			GestureFeatureEquals(x.RingFingerDIPDominantF1F2SpatialAngle, y.RingFingerDIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPDominantFN_1FNSpatialAngle, y.RingFingerDIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPDominantF1FNSpatialAngle, y.RingFingerDIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPDominantTotalVectorAngle, y.RingFingerDIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerDIPDominantSquaredTotalVectorAngle, y.RingFingerDIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerDIPDominantTotalVectorDisplacement, y.RingFingerDIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerDIPDominantTotalDisplacement, y.RingFingerDIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerDIPDominantMaximumDisplacement, y.RingFingerDIPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerTIPDominant joint features
			GestureFeatureEquals(x.RingFingerTIPDominantF1F2SpatialAngle, y.RingFingerTIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerTIPDominantFN_1FNSpatialAngle, y.RingFingerTIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerTIPDominantF1FNSpatialAngle, y.RingFingerTIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerTIPDominantTotalVectorAngle, y.RingFingerTIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerTIPDominantSquaredTotalVectorAngle, y.RingFingerTIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerTIPDominantTotalVectorDisplacement, y.RingFingerTIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerTIPDominantTotalDisplacement, y.RingFingerTIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerTIPDominantMaximumDisplacement, y.RingFingerTIPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyMCPDominant joint features
			GestureFeatureEquals(x.PinkyMCPDominantF1F2SpatialAngle, y.PinkyMCPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyMCPDominantFN_1FNSpatialAngle, y.PinkyMCPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyMCPDominantF1FNSpatialAngle, y.PinkyMCPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyMCPDominantTotalVectorAngle, y.PinkyMCPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyMCPDominantSquaredTotalVectorAngle, y.PinkyMCPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyMCPDominantTotalVectorDisplacement, y.PinkyMCPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyMCPDominantTotalDisplacement, y.PinkyMCPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyMCPDominantMaximumDisplacement, y.PinkyMCPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyPIPDominant joint features
			GestureFeatureEquals(x.PinkyPIPDominantF1F2SpatialAngle, y.PinkyPIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyPIPDominantFN_1FNSpatialAngle, y.PinkyPIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyPIPDominantF1FNSpatialAngle, y.PinkyPIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyPIPDominantTotalVectorAngle, y.PinkyPIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyPIPDominantSquaredTotalVectorAngle, y.PinkyPIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyPIPDominantTotalVectorDisplacement, y.PinkyPIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyPIPDominantTotalDisplacement, y.PinkyPIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyPIPDominantMaximumDisplacement, y.PinkyPIPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyDIPDominant joint features
			GestureFeatureEquals(x.PinkyDIPDominantF1F2SpatialAngle, y.PinkyDIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyDIPDominantFN_1FNSpatialAngle, y.PinkyDIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyDIPDominantF1FNSpatialAngle, y.PinkyDIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyDIPDominantTotalVectorAngle, y.PinkyDIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyDIPDominantSquaredTotalVectorAngle, y.PinkyDIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyDIPDominantTotalVectorDisplacement, y.PinkyDIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyDIPDominantTotalDisplacement, y.PinkyDIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyDIPDominantMaximumDisplacement, y.PinkyDIPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyTIPDominant joint features
			GestureFeatureEquals(x.PinkyTIPDominantF1F2SpatialAngle, y.PinkyTIPDominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyTIPDominantFN_1FNSpatialAngle, y.PinkyTIPDominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyTIPDominantF1FNSpatialAngle, y.PinkyTIPDominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyTIPDominantTotalVectorAngle, y.PinkyTIPDominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyTIPDominantSquaredTotalVectorAngle, y.PinkyTIPDominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyTIPDominantTotalVectorDisplacement, y.PinkyTIPDominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyTIPDominantTotalDisplacement, y.PinkyTIPDominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyTIPDominantMaximumDisplacement, y.PinkyTIPDominantMaximumDisplacement) &&
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

			#region ThumbCMCNondominant joint features
			GestureFeatureEquals(x.ThumbCMCNondominantF1F2SpatialAngle, y.ThumbCMCNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbCMCNondominantFN_1FNSpatialAngle, y.ThumbCMCNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbCMCNondominantF1FNSpatialAngle, y.ThumbCMCNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbCMCNondominantTotalVectorAngle, y.ThumbCMCNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbCMCNondominantSquaredTotalVectorAngle, y.ThumbCMCNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbCMCNondominantTotalVectorDisplacement, y.ThumbCMCNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbCMCNondominantTotalDisplacement, y.ThumbCMCNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbCMCNondominantMaximumDisplacement, y.ThumbCMCNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbMCPNondominant joint features
			GestureFeatureEquals(x.ThumbMCPNondominantF1F2SpatialAngle, y.ThumbMCPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbMCPNondominantFN_1FNSpatialAngle, y.ThumbMCPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbMCPNondominantF1FNSpatialAngle, y.ThumbMCPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbMCPNondominantTotalVectorAngle, y.ThumbMCPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbMCPNondominantSquaredTotalVectorAngle, y.ThumbMCPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbMCPNondominantTotalVectorDisplacement, y.ThumbMCPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbMCPNondominantTotalDisplacement, y.ThumbMCPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbMCPNondominantMaximumDisplacement, y.ThumbMCPNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbIPNondominant joint features
			GestureFeatureEquals(x.ThumbIPNondominantF1F2SpatialAngle, y.ThumbIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbIPNondominantFN_1FNSpatialAngle, y.ThumbIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbIPNondominantF1FNSpatialAngle, y.ThumbIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbIPNondominantTotalVectorAngle, y.ThumbIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbIPNondominantSquaredTotalVectorAngle, y.ThumbIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbIPNondominantTotalVectorDisplacement, y.ThumbIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbIPNondominantTotalDisplacement, y.ThumbIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbIPNondominantMaximumDisplacement, y.ThumbIPNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbTIPNondominant joint features
			GestureFeatureEquals(x.ThumbTIPNondominantF1F2SpatialAngle, y.ThumbTIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.ThumbTIPNondominantFN_1FNSpatialAngle, y.ThumbTIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbTIPNondominantF1FNSpatialAngle, y.ThumbTIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.ThumbTIPNondominantTotalVectorAngle, y.ThumbTIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbTIPNondominantSquaredTotalVectorAngle, y.ThumbTIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.ThumbTIPNondominantTotalVectorDisplacement, y.ThumbTIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.ThumbTIPNondominantTotalDisplacement, y.ThumbTIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.ThumbTIPNondominantMaximumDisplacement, y.ThumbTIPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerMCPNondominant joint features
			GestureFeatureEquals(x.IndexFingerMCPNondominantF1F2SpatialAngle, y.IndexFingerMCPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantFN_1FNSpatialAngle, y.IndexFingerMCPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantF1FNSpatialAngle, y.IndexFingerMCPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantTotalVectorAngle, y.IndexFingerMCPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantSquaredTotalVectorAngle, y.IndexFingerMCPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantTotalVectorDisplacement, y.IndexFingerMCPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantTotalDisplacement, y.IndexFingerMCPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerMCPNondominantMaximumDisplacement, y.IndexFingerMCPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerPIPNondominant joint features
			GestureFeatureEquals(x.IndexFingerPIPNondominantF1F2SpatialAngle, y.IndexFingerPIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantFN_1FNSpatialAngle, y.IndexFingerPIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantF1FNSpatialAngle, y.IndexFingerPIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantTotalVectorAngle, y.IndexFingerPIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantSquaredTotalVectorAngle, y.IndexFingerPIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantTotalVectorDisplacement, y.IndexFingerPIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantTotalDisplacement, y.IndexFingerPIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerPIPNondominantMaximumDisplacement, y.IndexFingerPIPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerDIPNondominant joint features
			GestureFeatureEquals(x.IndexFingerDIPNondominantF1F2SpatialAngle, y.IndexFingerDIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantFN_1FNSpatialAngle, y.IndexFingerDIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantF1FNSpatialAngle, y.IndexFingerDIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantTotalVectorAngle, y.IndexFingerDIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantSquaredTotalVectorAngle, y.IndexFingerDIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantTotalVectorDisplacement, y.IndexFingerDIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantTotalDisplacement, y.IndexFingerDIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerDIPNondominantMaximumDisplacement, y.IndexFingerDIPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerTIPNondominant joint features
			GestureFeatureEquals(x.IndexFingerTIPNondominantF1F2SpatialAngle, y.IndexFingerTIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantFN_1FNSpatialAngle, y.IndexFingerTIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantF1FNSpatialAngle, y.IndexFingerTIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantTotalVectorAngle, y.IndexFingerTIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantSquaredTotalVectorAngle, y.IndexFingerTIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantTotalVectorDisplacement, y.IndexFingerTIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantTotalDisplacement, y.IndexFingerTIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.IndexFingerTIPNondominantMaximumDisplacement, y.IndexFingerTIPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerMCPNondominant joint features
			GestureFeatureEquals(x.MiddleFingerMCPNondominantF1F2SpatialAngle, y.MiddleFingerMCPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantFN_1FNSpatialAngle, y.MiddleFingerMCPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantF1FNSpatialAngle, y.MiddleFingerMCPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantTotalVectorAngle, y.MiddleFingerMCPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantSquaredTotalVectorAngle, y.MiddleFingerMCPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantTotalVectorDisplacement, y.MiddleFingerMCPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantTotalDisplacement, y.MiddleFingerMCPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerMCPNondominantMaximumDisplacement, y.MiddleFingerMCPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerPIPNondominant joint features
			GestureFeatureEquals(x.MiddleFingerPIPNondominantF1F2SpatialAngle, y.MiddleFingerPIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantFN_1FNSpatialAngle, y.MiddleFingerPIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantF1FNSpatialAngle, y.MiddleFingerPIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantTotalVectorAngle, y.MiddleFingerPIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantSquaredTotalVectorAngle, y.MiddleFingerPIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantTotalVectorDisplacement, y.MiddleFingerPIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantTotalDisplacement, y.MiddleFingerPIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerPIPNondominantMaximumDisplacement, y.MiddleFingerPIPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerDIPNondominant joint features
			GestureFeatureEquals(x.MiddleFingerDIPNondominantF1F2SpatialAngle, y.MiddleFingerDIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantFN_1FNSpatialAngle, y.MiddleFingerDIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantF1FNSpatialAngle, y.MiddleFingerDIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantTotalVectorAngle, y.MiddleFingerDIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantSquaredTotalVectorAngle, y.MiddleFingerDIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantTotalVectorDisplacement, y.MiddleFingerDIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantTotalDisplacement, y.MiddleFingerDIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerDIPNondominantMaximumDisplacement, y.MiddleFingerDIPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerTIPNondominant joint features
			GestureFeatureEquals(x.MiddleFingerTIPNondominantF1F2SpatialAngle, y.MiddleFingerTIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantFN_1FNSpatialAngle, y.MiddleFingerTIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantF1FNSpatialAngle, y.MiddleFingerTIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantTotalVectorAngle, y.MiddleFingerTIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantSquaredTotalVectorAngle, y.MiddleFingerTIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantTotalVectorDisplacement, y.MiddleFingerTIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantTotalDisplacement, y.MiddleFingerTIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.MiddleFingerTIPNondominantMaximumDisplacement, y.MiddleFingerTIPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerMCPNondominant joint features
			GestureFeatureEquals(x.RingFingerMCPNondominantF1F2SpatialAngle, y.RingFingerMCPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantFN_1FNSpatialAngle, y.RingFingerMCPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantF1FNSpatialAngle, y.RingFingerMCPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantTotalVectorAngle, y.RingFingerMCPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantSquaredTotalVectorAngle, y.RingFingerMCPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantTotalVectorDisplacement, y.RingFingerMCPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantTotalDisplacement, y.RingFingerMCPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerMCPNondominantMaximumDisplacement, y.RingFingerMCPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerPIPNondominant joint features
			GestureFeatureEquals(x.RingFingerPIPNondominantF1F2SpatialAngle, y.RingFingerPIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantFN_1FNSpatialAngle, y.RingFingerPIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantF1FNSpatialAngle, y.RingFingerPIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantTotalVectorAngle, y.RingFingerPIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantSquaredTotalVectorAngle, y.RingFingerPIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantTotalVectorDisplacement, y.RingFingerPIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantTotalDisplacement, y.RingFingerPIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerPIPNondominantMaximumDisplacement, y.RingFingerPIPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerDIPNondominant joint features
			GestureFeatureEquals(x.RingFingerDIPNondominantF1F2SpatialAngle, y.RingFingerDIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantFN_1FNSpatialAngle, y.RingFingerDIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantF1FNSpatialAngle, y.RingFingerDIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantTotalVectorAngle, y.RingFingerDIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantSquaredTotalVectorAngle, y.RingFingerDIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantTotalVectorDisplacement, y.RingFingerDIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantTotalDisplacement, y.RingFingerDIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerDIPNondominantMaximumDisplacement, y.RingFingerDIPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerTIPNondominant joint features
			GestureFeatureEquals(x.RingFingerTIPNondominantF1F2SpatialAngle, y.RingFingerTIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantFN_1FNSpatialAngle, y.RingFingerTIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantF1FNSpatialAngle, y.RingFingerTIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantTotalVectorAngle, y.RingFingerTIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantSquaredTotalVectorAngle, y.RingFingerTIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantTotalVectorDisplacement, y.RingFingerTIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantTotalDisplacement, y.RingFingerTIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.RingFingerTIPNondominantMaximumDisplacement, y.RingFingerTIPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyMCPNondominant joint features
			GestureFeatureEquals(x.PinkyMCPNondominantF1F2SpatialAngle, y.PinkyMCPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyMCPNondominantFN_1FNSpatialAngle, y.PinkyMCPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyMCPNondominantF1FNSpatialAngle, y.PinkyMCPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyMCPNondominantTotalVectorAngle, y.PinkyMCPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyMCPNondominantSquaredTotalVectorAngle, y.PinkyMCPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyMCPNondominantTotalVectorDisplacement, y.PinkyMCPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyMCPNondominantTotalDisplacement, y.PinkyMCPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyMCPNondominantMaximumDisplacement, y.PinkyMCPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyPIPNondominant joint features
			GestureFeatureEquals(x.PinkyPIPNondominantF1F2SpatialAngle, y.PinkyPIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyPIPNondominantFN_1FNSpatialAngle, y.PinkyPIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyPIPNondominantF1FNSpatialAngle, y.PinkyPIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyPIPNondominantTotalVectorAngle, y.PinkyPIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyPIPNondominantSquaredTotalVectorAngle, y.PinkyPIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyPIPNondominantTotalVectorDisplacement, y.PinkyPIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyPIPNondominantTotalDisplacement, y.PinkyPIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyPIPNondominantMaximumDisplacement, y.PinkyPIPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyDIPNondominant joint features
			GestureFeatureEquals(x.PinkyDIPNondominantF1F2SpatialAngle, y.PinkyDIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyDIPNondominantFN_1FNSpatialAngle, y.PinkyDIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyDIPNondominantF1FNSpatialAngle, y.PinkyDIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyDIPNondominantTotalVectorAngle, y.PinkyDIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyDIPNondominantSquaredTotalVectorAngle, y.PinkyDIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyDIPNondominantTotalVectorDisplacement, y.PinkyDIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyDIPNondominantTotalDisplacement, y.PinkyDIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyDIPNondominantMaximumDisplacement, y.PinkyDIPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyTIPNondominant joint features
			GestureFeatureEquals(x.PinkyTIPNondominantF1F2SpatialAngle, y.PinkyTIPNondominantF1F2SpatialAngle) &&
			GestureFeatureEquals(x.PinkyTIPNondominantFN_1FNSpatialAngle, y.PinkyTIPNondominantFN_1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyTIPNondominantF1FNSpatialAngle, y.PinkyTIPNondominantF1FNSpatialAngle) &&
			GestureFeatureEquals(x.PinkyTIPNondominantTotalVectorAngle, y.PinkyTIPNondominantTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyTIPNondominantSquaredTotalVectorAngle, y.PinkyTIPNondominantSquaredTotalVectorAngle) &&
			GestureFeatureEquals(x.PinkyTIPNondominantTotalVectorDisplacement, y.PinkyTIPNondominantTotalVectorDisplacement) &&
			GestureFeatureEquals(x.PinkyTIPNondominantTotalDisplacement, y.PinkyTIPNondominantTotalDisplacement) &&
			GestureFeatureEquals(x.PinkyTIPNondominantMaximumDisplacement, y.PinkyTIPNondominantMaximumDisplacement) &&
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

			#region WristThumbCMCDominantBone bone features
			GestureFeatureEquals(x.WristThumbCMCDominantBoneInitialAngle, y.WristThumbCMCDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristThumbCMCDominantBoneFinalAngle, y.WristThumbCMCDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristThumbCMCDominantBoneMeanAngle, y.WristThumbCMCDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristThumbCMCDominantBoneMaximumAngle, y.WristThumbCMCDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbCMCThumbMCPDominantBone bone features
			GestureFeatureEquals(x.ThumbCMCThumbMCPDominantBoneInitialAngle, y.ThumbCMCThumbMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbCMCThumbMCPDominantBoneFinalAngle, y.ThumbCMCThumbMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbCMCThumbMCPDominantBoneMeanAngle, y.ThumbCMCThumbMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbCMCThumbMCPDominantBoneMaximumAngle, y.ThumbCMCThumbMCPDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPThumbIPDominantBone bone features
			GestureFeatureEquals(x.ThumbMCPThumbIPDominantBoneInitialAngle, y.ThumbMCPThumbIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbMCPThumbIPDominantBoneFinalAngle, y.ThumbMCPThumbIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbMCPThumbIPDominantBoneMeanAngle, y.ThumbMCPThumbIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbMCPThumbIPDominantBoneMaximumAngle, y.ThumbMCPThumbIPDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbIPThumbTIPDominantBone bone features
			GestureFeatureEquals(x.ThumbIPThumbTIPDominantBoneInitialAngle, y.ThumbIPThumbTIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbIPThumbTIPDominantBoneFinalAngle, y.ThumbIPThumbTIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbIPThumbTIPDominantBoneMeanAngle, y.ThumbIPThumbTIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbIPThumbTIPDominantBoneMaximumAngle, y.ThumbIPThumbTIPDominantBoneMaximumAngle) &&
			#endregion

			#region WristIndexFingerMCPDominantBone bone features
			GestureFeatureEquals(x.WristIndexFingerMCPDominantBoneInitialAngle, y.WristIndexFingerMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristIndexFingerMCPDominantBoneFinalAngle, y.WristIndexFingerMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristIndexFingerMCPDominantBoneMeanAngle, y.WristIndexFingerMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristIndexFingerMCPDominantBoneMaximumAngle, y.WristIndexFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPIndexFingerPIPDominantBone bone features
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerPIPIndexFingerDIPDominantBone bone features
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerDIPIndexFingerTIPDominantBone bone features
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPDominantBone bone features
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPDominantBone bone features
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPDominantBone bone features
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPRingFingerPIPDominantBone bone features
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPDominantBoneInitialAngle, y.RingFingerMCPRingFingerPIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPDominantBoneFinalAngle, y.RingFingerMCPRingFingerPIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPDominantBoneMeanAngle, y.RingFingerMCPRingFingerPIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle, y.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerPIPRingFingerDIPDominantBone bone features
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPDominantBoneInitialAngle, y.RingFingerPIPRingFingerDIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPDominantBoneFinalAngle, y.RingFingerPIPRingFingerDIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPDominantBoneMeanAngle, y.RingFingerPIPRingFingerDIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle, y.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerDIPRingFingerTIPDominantBone bone features
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPDominantBoneInitialAngle, y.RingFingerDIPRingFingerTIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPDominantBoneFinalAngle, y.RingFingerDIPRingFingerTIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPDominantBoneMeanAngle, y.RingFingerDIPRingFingerTIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle, y.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle) &&
			#endregion

			#region WristPinkyMCPDominantBone bone features
			GestureFeatureEquals(x.WristPinkyMCPDominantBoneInitialAngle, y.WristPinkyMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristPinkyMCPDominantBoneFinalAngle, y.WristPinkyMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristPinkyMCPDominantBoneMeanAngle, y.WristPinkyMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristPinkyMCPDominantBoneMaximumAngle, y.WristPinkyMCPDominantBoneMaximumAngle) &&
			#endregion

			#region PinkyMCPPinkyPIPDominantBone bone features
			GestureFeatureEquals(x.PinkyMCPPinkyPIPDominantBoneInitialAngle, y.PinkyMCPPinkyPIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.PinkyMCPPinkyPIPDominantBoneFinalAngle, y.PinkyMCPPinkyPIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.PinkyMCPPinkyPIPDominantBoneMeanAngle, y.PinkyMCPPinkyPIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.PinkyMCPPinkyPIPDominantBoneMaximumAngle, y.PinkyMCPPinkyPIPDominantBoneMaximumAngle) &&
			#endregion

			#region PinkyPIPPinkyDIPDominantBone bone features
			GestureFeatureEquals(x.PinkyPIPPinkyDIPDominantBoneInitialAngle, y.PinkyPIPPinkyDIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.PinkyPIPPinkyDIPDominantBoneFinalAngle, y.PinkyPIPPinkyDIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.PinkyPIPPinkyDIPDominantBoneMeanAngle, y.PinkyPIPPinkyDIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.PinkyPIPPinkyDIPDominantBoneMaximumAngle, y.PinkyPIPPinkyDIPDominantBoneMaximumAngle) &&
			#endregion

			#region PinkyDIPPinkyTIPDominantBone bone features
			GestureFeatureEquals(x.PinkyDIPPinkyTIPDominantBoneInitialAngle, y.PinkyDIPPinkyTIPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.PinkyDIPPinkyTIPDominantBoneFinalAngle, y.PinkyDIPPinkyTIPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.PinkyDIPPinkyTIPDominantBoneMeanAngle, y.PinkyDIPPinkyTIPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.PinkyDIPPinkyTIPDominantBoneMaximumAngle, y.PinkyDIPPinkyTIPDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPIndexFingerMCPDominantBone bone features
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPDominantBoneInitialAngle, y.ThumbMCPIndexFingerMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPDominantBoneFinalAngle, y.ThumbMCPIndexFingerMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPDominantBoneMeanAngle, y.ThumbMCPIndexFingerMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPDominantBoneMaximumAngle, y.ThumbMCPIndexFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominantBone bone features
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPRingFingerMCPDominantBone bone features
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPPinkyMCPDominantBone bone features
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPDominantBoneInitialAngle, y.RingFingerMCPPinkyMCPDominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPDominantBoneFinalAngle, y.RingFingerMCPPinkyMCPDominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPDominantBoneMeanAngle, y.RingFingerMCPPinkyMCPDominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPDominantBoneMaximumAngle, y.RingFingerMCPPinkyMCPDominantBoneMaximumAngle) &&
			#endregion

			#region WristThumbCMCNondominantBone bone features
			GestureFeatureEquals(x.WristThumbCMCNondominantBoneInitialAngle, y.WristThumbCMCNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristThumbCMCNondominantBoneFinalAngle, y.WristThumbCMCNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristThumbCMCNondominantBoneMeanAngle, y.WristThumbCMCNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristThumbCMCNondominantBoneMaximumAngle, y.WristThumbCMCNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbCMCThumbMCPNondominantBone bone features
			GestureFeatureEquals(x.ThumbCMCThumbMCPNondominantBoneInitialAngle, y.ThumbCMCThumbMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbCMCThumbMCPNondominantBoneFinalAngle, y.ThumbCMCThumbMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbCMCThumbMCPNondominantBoneMeanAngle, y.ThumbCMCThumbMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbCMCThumbMCPNondominantBoneMaximumAngle, y.ThumbCMCThumbMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPThumbIPNondominantBone bone features
			GestureFeatureEquals(x.ThumbMCPThumbIPNondominantBoneInitialAngle, y.ThumbMCPThumbIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbMCPThumbIPNondominantBoneFinalAngle, y.ThumbMCPThumbIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbMCPThumbIPNondominantBoneMeanAngle, y.ThumbMCPThumbIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbMCPThumbIPNondominantBoneMaximumAngle, y.ThumbMCPThumbIPNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbIPThumbTIPNondominantBone bone features
			GestureFeatureEquals(x.ThumbIPThumbTIPNondominantBoneInitialAngle, y.ThumbIPThumbTIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbIPThumbTIPNondominantBoneFinalAngle, y.ThumbIPThumbTIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbIPThumbTIPNondominantBoneMeanAngle, y.ThumbIPThumbTIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbIPThumbTIPNondominantBoneMaximumAngle, y.ThumbIPThumbTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region WristIndexFingerMCPNondominantBone bone features
			GestureFeatureEquals(x.WristIndexFingerMCPNondominantBoneInitialAngle, y.WristIndexFingerMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristIndexFingerMCPNondominantBoneFinalAngle, y.WristIndexFingerMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristIndexFingerMCPNondominantBoneMeanAngle, y.WristIndexFingerMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristIndexFingerMCPNondominantBoneMaximumAngle, y.WristIndexFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPIndexFingerPIPNondominantBone bone features
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerPIPIndexFingerDIPNondominantBone bone features
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerDIPIndexFingerTIPNondominantBone bone features
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPNondominantBone bone features
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPNondominantBone bone features
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPNondominantBone bone features
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPRingFingerPIPNondominantBone bone features
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle, y.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle, y.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle, y.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle, y.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerPIPRingFingerDIPNondominantBone bone features
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle, y.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle, y.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle, y.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle, y.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerDIPRingFingerTIPNondominantBone bone features
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle, y.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle, y.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle, y.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle, y.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region WristPinkyMCPNondominantBone bone features
			GestureFeatureEquals(x.WristPinkyMCPNondominantBoneInitialAngle, y.WristPinkyMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.WristPinkyMCPNondominantBoneFinalAngle, y.WristPinkyMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.WristPinkyMCPNondominantBoneMeanAngle, y.WristPinkyMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.WristPinkyMCPNondominantBoneMaximumAngle, y.WristPinkyMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region PinkyMCPPinkyPIPNondominantBone bone features
			GestureFeatureEquals(x.PinkyMCPPinkyPIPNondominantBoneInitialAngle, y.PinkyMCPPinkyPIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.PinkyMCPPinkyPIPNondominantBoneFinalAngle, y.PinkyMCPPinkyPIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.PinkyMCPPinkyPIPNondominantBoneMeanAngle, y.PinkyMCPPinkyPIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.PinkyMCPPinkyPIPNondominantBoneMaximumAngle, y.PinkyMCPPinkyPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region PinkyPIPPinkyDIPNondominantBone bone features
			GestureFeatureEquals(x.PinkyPIPPinkyDIPNondominantBoneInitialAngle, y.PinkyPIPPinkyDIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.PinkyPIPPinkyDIPNondominantBoneFinalAngle, y.PinkyPIPPinkyDIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.PinkyPIPPinkyDIPNondominantBoneMeanAngle, y.PinkyPIPPinkyDIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.PinkyPIPPinkyDIPNondominantBoneMaximumAngle, y.PinkyPIPPinkyDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region PinkyDIPPinkyTIPNondominantBone bone features
			GestureFeatureEquals(x.PinkyDIPPinkyTIPNondominantBoneInitialAngle, y.PinkyDIPPinkyTIPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.PinkyDIPPinkyTIPNondominantBoneFinalAngle, y.PinkyDIPPinkyTIPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.PinkyDIPPinkyTIPNondominantBoneMeanAngle, y.PinkyDIPPinkyTIPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.PinkyDIPPinkyTIPNondominantBoneMaximumAngle, y.PinkyDIPPinkyTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPIndexFingerMCPNondominantBone bone features
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPNondominantBoneInitialAngle, y.ThumbMCPIndexFingerMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPNondominantBoneFinalAngle, y.ThumbMCPIndexFingerMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPNondominantBoneMeanAngle, y.ThumbMCPIndexFingerMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle, y.ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominantBone bone features
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPRingFingerMCPNondominantBone bone features
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPPinkyMCPNondominantBone bone features
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPNondominantBoneInitialAngle, y.RingFingerMCPPinkyMCPNondominantBoneInitialAngle) &&
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPNondominantBoneFinalAngle, y.RingFingerMCPPinkyMCPNondominantBoneFinalAngle) &&
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPNondominantBoneMeanAngle, y.RingFingerMCPPinkyMCPNondominantBoneMeanAngle) &&
			GestureFeatureEquals(x.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle, y.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle) &&
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

		public int GetHashCode(MediaPipeHandLandmarksGestureDataView obj)
		{
			if (obj == null)
				return 0;

			var hash = new HashCode();

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

			#region ThumbCMCDominant joint features
			hash.Add(obj.ThumbCMCDominantF1F2SpatialAngle);
			hash.Add(obj.ThumbCMCDominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbCMCDominantF1FNSpatialAngle);
			hash.Add(obj.ThumbCMCDominantTotalVectorAngle);
			hash.Add(obj.ThumbCMCDominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbCMCDominantTotalVectorDisplacement);
			hash.Add(obj.ThumbCMCDominantTotalDisplacement);
			hash.Add(obj.ThumbCMCDominantMaximumDisplacement);
			#endregion

			#region ThumbMCPDominant joint features
			hash.Add(obj.ThumbMCPDominantF1F2SpatialAngle);
			hash.Add(obj.ThumbMCPDominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbMCPDominantF1FNSpatialAngle);
			hash.Add(obj.ThumbMCPDominantTotalVectorAngle);
			hash.Add(obj.ThumbMCPDominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbMCPDominantTotalVectorDisplacement);
			hash.Add(obj.ThumbMCPDominantTotalDisplacement);
			hash.Add(obj.ThumbMCPDominantMaximumDisplacement);
			#endregion

			#region ThumbIPDominant joint features
			hash.Add(obj.ThumbIPDominantF1F2SpatialAngle);
			hash.Add(obj.ThumbIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbIPDominantF1FNSpatialAngle);
			hash.Add(obj.ThumbIPDominantTotalVectorAngle);
			hash.Add(obj.ThumbIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbIPDominantTotalVectorDisplacement);
			hash.Add(obj.ThumbIPDominantTotalDisplacement);
			hash.Add(obj.ThumbIPDominantMaximumDisplacement);
			#endregion

			#region ThumbTIPDominant joint features
			hash.Add(obj.ThumbTIPDominantF1F2SpatialAngle);
			hash.Add(obj.ThumbTIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbTIPDominantF1FNSpatialAngle);
			hash.Add(obj.ThumbTIPDominantTotalVectorAngle);
			hash.Add(obj.ThumbTIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbTIPDominantTotalVectorDisplacement);
			hash.Add(obj.ThumbTIPDominantTotalDisplacement);
			hash.Add(obj.ThumbTIPDominantMaximumDisplacement);
			#endregion

			#region IndexFingerMCPDominant joint features
			hash.Add(obj.IndexFingerMCPDominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerMCPDominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerMCPDominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerMCPDominantTotalVectorAngle);
			hash.Add(obj.IndexFingerMCPDominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerMCPDominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerMCPDominantTotalDisplacement);
			hash.Add(obj.IndexFingerMCPDominantMaximumDisplacement);
			#endregion

			#region IndexFingerPIPDominant joint features
			hash.Add(obj.IndexFingerPIPDominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerPIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerPIPDominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerPIPDominantTotalVectorAngle);
			hash.Add(obj.IndexFingerPIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerPIPDominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerPIPDominantTotalDisplacement);
			hash.Add(obj.IndexFingerPIPDominantMaximumDisplacement);
			#endregion

			#region IndexFingerDIPDominant joint features
			hash.Add(obj.IndexFingerDIPDominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerDIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerDIPDominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerDIPDominantTotalVectorAngle);
			hash.Add(obj.IndexFingerDIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerDIPDominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerDIPDominantTotalDisplacement);
			hash.Add(obj.IndexFingerDIPDominantMaximumDisplacement);
			#endregion

			#region IndexFingerTIPDominant joint features
			hash.Add(obj.IndexFingerTIPDominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerTIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerTIPDominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerTIPDominantTotalVectorAngle);
			hash.Add(obj.IndexFingerTIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerTIPDominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerTIPDominantTotalDisplacement);
			hash.Add(obj.IndexFingerTIPDominantMaximumDisplacement);
			#endregion

			#region MiddleFingerMCPDominant joint features
			hash.Add(obj.MiddleFingerMCPDominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerMCPDominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerMCPDominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerMCPDominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerMCPDominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerMCPDominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerMCPDominantTotalDisplacement);
			hash.Add(obj.MiddleFingerMCPDominantMaximumDisplacement);
			#endregion

			#region MiddleFingerPIPDominant joint features
			hash.Add(obj.MiddleFingerPIPDominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerPIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerPIPDominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerPIPDominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerPIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerPIPDominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerPIPDominantTotalDisplacement);
			hash.Add(obj.MiddleFingerPIPDominantMaximumDisplacement);
			#endregion

			#region MiddleFingerDIPDominant joint features
			hash.Add(obj.MiddleFingerDIPDominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerDIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerDIPDominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerDIPDominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerDIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerDIPDominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerDIPDominantTotalDisplacement);
			hash.Add(obj.MiddleFingerDIPDominantMaximumDisplacement);
			#endregion

			#region MiddleFingerTIPDominant joint features
			hash.Add(obj.MiddleFingerTIPDominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerTIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerTIPDominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerTIPDominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerTIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerTIPDominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerTIPDominantTotalDisplacement);
			hash.Add(obj.MiddleFingerTIPDominantMaximumDisplacement);
			#endregion

			#region RingFingerMCPDominant joint features
			hash.Add(obj.RingFingerMCPDominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerMCPDominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerMCPDominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerMCPDominantTotalVectorAngle);
			hash.Add(obj.RingFingerMCPDominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerMCPDominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerMCPDominantTotalDisplacement);
			hash.Add(obj.RingFingerMCPDominantMaximumDisplacement);
			#endregion

			#region RingFingerPIPDominant joint features
			hash.Add(obj.RingFingerPIPDominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerPIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerPIPDominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerPIPDominantTotalVectorAngle);
			hash.Add(obj.RingFingerPIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerPIPDominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerPIPDominantTotalDisplacement);
			hash.Add(obj.RingFingerPIPDominantMaximumDisplacement);
			#endregion

			#region RingFingerDIPDominant joint features
			hash.Add(obj.RingFingerDIPDominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerDIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerDIPDominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerDIPDominantTotalVectorAngle);
			hash.Add(obj.RingFingerDIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerDIPDominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerDIPDominantTotalDisplacement);
			hash.Add(obj.RingFingerDIPDominantMaximumDisplacement);
			#endregion

			#region RingFingerTIPDominant joint features
			hash.Add(obj.RingFingerTIPDominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerTIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerTIPDominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerTIPDominantTotalVectorAngle);
			hash.Add(obj.RingFingerTIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerTIPDominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerTIPDominantTotalDisplacement);
			hash.Add(obj.RingFingerTIPDominantMaximumDisplacement);
			#endregion

			#region PinkyMCPDominant joint features
			hash.Add(obj.PinkyMCPDominantF1F2SpatialAngle);
			hash.Add(obj.PinkyMCPDominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyMCPDominantF1FNSpatialAngle);
			hash.Add(obj.PinkyMCPDominantTotalVectorAngle);
			hash.Add(obj.PinkyMCPDominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyMCPDominantTotalVectorDisplacement);
			hash.Add(obj.PinkyMCPDominantTotalDisplacement);
			hash.Add(obj.PinkyMCPDominantMaximumDisplacement);
			#endregion

			#region PinkyPIPDominant joint features
			hash.Add(obj.PinkyPIPDominantF1F2SpatialAngle);
			hash.Add(obj.PinkyPIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyPIPDominantF1FNSpatialAngle);
			hash.Add(obj.PinkyPIPDominantTotalVectorAngle);
			hash.Add(obj.PinkyPIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyPIPDominantTotalVectorDisplacement);
			hash.Add(obj.PinkyPIPDominantTotalDisplacement);
			hash.Add(obj.PinkyPIPDominantMaximumDisplacement);
			#endregion

			#region PinkyDIPDominant joint features
			hash.Add(obj.PinkyDIPDominantF1F2SpatialAngle);
			hash.Add(obj.PinkyDIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyDIPDominantF1FNSpatialAngle);
			hash.Add(obj.PinkyDIPDominantTotalVectorAngle);
			hash.Add(obj.PinkyDIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyDIPDominantTotalVectorDisplacement);
			hash.Add(obj.PinkyDIPDominantTotalDisplacement);
			hash.Add(obj.PinkyDIPDominantMaximumDisplacement);
			#endregion

			#region PinkyTIPDominant joint features
			hash.Add(obj.PinkyTIPDominantF1F2SpatialAngle);
			hash.Add(obj.PinkyTIPDominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyTIPDominantF1FNSpatialAngle);
			hash.Add(obj.PinkyTIPDominantTotalVectorAngle);
			hash.Add(obj.PinkyTIPDominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyTIPDominantTotalVectorDisplacement);
			hash.Add(obj.PinkyTIPDominantTotalDisplacement);
			hash.Add(obj.PinkyTIPDominantMaximumDisplacement);
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
			//public HandState[] HandDominantHandStates
			//{
			//	get;
			//	set;
			//}
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

			#region ThumbCMCNondominant joint features
			hash.Add(obj.ThumbCMCNondominantF1F2SpatialAngle);
			hash.Add(obj.ThumbCMCNondominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbCMCNondominantF1FNSpatialAngle);
			hash.Add(obj.ThumbCMCNondominantTotalVectorAngle);
			hash.Add(obj.ThumbCMCNondominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbCMCNondominantTotalVectorDisplacement);
			hash.Add(obj.ThumbCMCNondominantTotalDisplacement);
			hash.Add(obj.ThumbCMCNondominantMaximumDisplacement);
			#endregion

			#region ThumbMCPNondominant joint features
			hash.Add(obj.ThumbMCPNondominantF1F2SpatialAngle);
			hash.Add(obj.ThumbMCPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbMCPNondominantF1FNSpatialAngle);
			hash.Add(obj.ThumbMCPNondominantTotalVectorAngle);
			hash.Add(obj.ThumbMCPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbMCPNondominantTotalVectorDisplacement);
			hash.Add(obj.ThumbMCPNondominantTotalDisplacement);
			hash.Add(obj.ThumbMCPNondominantMaximumDisplacement);
			#endregion

			#region ThumbIPNondominant joint features
			hash.Add(obj.ThumbIPNondominantF1F2SpatialAngle);
			hash.Add(obj.ThumbIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbIPNondominantF1FNSpatialAngle);
			hash.Add(obj.ThumbIPNondominantTotalVectorAngle);
			hash.Add(obj.ThumbIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbIPNondominantTotalVectorDisplacement);
			hash.Add(obj.ThumbIPNondominantTotalDisplacement);
			hash.Add(obj.ThumbIPNondominantMaximumDisplacement);
			#endregion

			#region ThumbTIPNondominant joint features
			hash.Add(obj.ThumbTIPNondominantF1F2SpatialAngle);
			hash.Add(obj.ThumbTIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.ThumbTIPNondominantF1FNSpatialAngle);
			hash.Add(obj.ThumbTIPNondominantTotalVectorAngle);
			hash.Add(obj.ThumbTIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.ThumbTIPNondominantTotalVectorDisplacement);
			hash.Add(obj.ThumbTIPNondominantTotalDisplacement);
			hash.Add(obj.ThumbTIPNondominantMaximumDisplacement);
			#endregion

			#region IndexFingerMCPNondominant joint features
			hash.Add(obj.IndexFingerMCPNondominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerMCPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerMCPNondominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerMCPNondominantTotalVectorAngle);
			hash.Add(obj.IndexFingerMCPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerMCPNondominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerMCPNondominantTotalDisplacement);
			hash.Add(obj.IndexFingerMCPNondominantMaximumDisplacement);
			#endregion

			#region IndexFingerPIPNondominant joint features
			hash.Add(obj.IndexFingerPIPNondominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerPIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerPIPNondominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerPIPNondominantTotalVectorAngle);
			hash.Add(obj.IndexFingerPIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerPIPNondominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerPIPNondominantTotalDisplacement);
			hash.Add(obj.IndexFingerPIPNondominantMaximumDisplacement);
			#endregion

			#region IndexFingerDIPNondominant joint features
			hash.Add(obj.IndexFingerDIPNondominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerDIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerDIPNondominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerDIPNondominantTotalVectorAngle);
			hash.Add(obj.IndexFingerDIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerDIPNondominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerDIPNondominantTotalDisplacement);
			hash.Add(obj.IndexFingerDIPNondominantMaximumDisplacement);
			#endregion

			#region IndexFingerTIPNondominant joint features
			hash.Add(obj.IndexFingerTIPNondominantF1F2SpatialAngle);
			hash.Add(obj.IndexFingerTIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.IndexFingerTIPNondominantF1FNSpatialAngle);
			hash.Add(obj.IndexFingerTIPNondominantTotalVectorAngle);
			hash.Add(obj.IndexFingerTIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.IndexFingerTIPNondominantTotalVectorDisplacement);
			hash.Add(obj.IndexFingerTIPNondominantTotalDisplacement);
			hash.Add(obj.IndexFingerTIPNondominantMaximumDisplacement);
			#endregion

			#region MiddleFingerMCPNondominant joint features
			hash.Add(obj.MiddleFingerMCPNondominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerMCPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerMCPNondominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerMCPNondominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerMCPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerMCPNondominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerMCPNondominantTotalDisplacement);
			hash.Add(obj.MiddleFingerMCPNondominantMaximumDisplacement);
			#endregion

			#region MiddleFingerPIPNondominant joint features
			hash.Add(obj.MiddleFingerPIPNondominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerPIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerPIPNondominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerPIPNondominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerPIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerPIPNondominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerPIPNondominantTotalDisplacement);
			hash.Add(obj.MiddleFingerPIPNondominantMaximumDisplacement);
			#endregion

			#region MiddleFingerDIPNondominant joint features
			hash.Add(obj.MiddleFingerDIPNondominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerDIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerDIPNondominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerDIPNondominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerDIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerDIPNondominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerDIPNondominantTotalDisplacement);
			hash.Add(obj.MiddleFingerDIPNondominantMaximumDisplacement);
			#endregion

			#region MiddleFingerTIPNondominant joint features
			hash.Add(obj.MiddleFingerTIPNondominantF1F2SpatialAngle);
			hash.Add(obj.MiddleFingerTIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.MiddleFingerTIPNondominantF1FNSpatialAngle);
			hash.Add(obj.MiddleFingerTIPNondominantTotalVectorAngle);
			hash.Add(obj.MiddleFingerTIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.MiddleFingerTIPNondominantTotalVectorDisplacement);
			hash.Add(obj.MiddleFingerTIPNondominantTotalDisplacement);
			hash.Add(obj.MiddleFingerTIPNondominantMaximumDisplacement);
			#endregion

			#region RingFingerMCPNondominant joint features
			hash.Add(obj.RingFingerMCPNondominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerMCPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerMCPNondominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerMCPNondominantTotalVectorAngle);
			hash.Add(obj.RingFingerMCPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerMCPNondominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerMCPNondominantTotalDisplacement);
			hash.Add(obj.RingFingerMCPNondominantMaximumDisplacement);
			#endregion

			#region RingFingerPIPNondominant joint features
			hash.Add(obj.RingFingerPIPNondominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerPIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerPIPNondominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerPIPNondominantTotalVectorAngle);
			hash.Add(obj.RingFingerPIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerPIPNondominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerPIPNondominantTotalDisplacement);
			hash.Add(obj.RingFingerPIPNondominantMaximumDisplacement);
			#endregion

			#region RingFingerDIPNondominant joint features
			hash.Add(obj.RingFingerDIPNondominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerDIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerDIPNondominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerDIPNondominantTotalVectorAngle);
			hash.Add(obj.RingFingerDIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerDIPNondominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerDIPNondominantTotalDisplacement);
			hash.Add(obj.RingFingerDIPNondominantMaximumDisplacement);
			#endregion

			#region RingFingerTIPNondominant joint features
			hash.Add(obj.RingFingerTIPNondominantF1F2SpatialAngle);
			hash.Add(obj.RingFingerTIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.RingFingerTIPNondominantF1FNSpatialAngle);
			hash.Add(obj.RingFingerTIPNondominantTotalVectorAngle);
			hash.Add(obj.RingFingerTIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.RingFingerTIPNondominantTotalVectorDisplacement);
			hash.Add(obj.RingFingerTIPNondominantTotalDisplacement);
			hash.Add(obj.RingFingerTIPNondominantMaximumDisplacement);
			#endregion

			#region PinkyMCPNondominant joint features
			hash.Add(obj.PinkyMCPNondominantF1F2SpatialAngle);
			hash.Add(obj.PinkyMCPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyMCPNondominantF1FNSpatialAngle);
			hash.Add(obj.PinkyMCPNondominantTotalVectorAngle);
			hash.Add(obj.PinkyMCPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyMCPNondominantTotalVectorDisplacement);
			hash.Add(obj.PinkyMCPNondominantTotalDisplacement);
			hash.Add(obj.PinkyMCPNondominantMaximumDisplacement);
			#endregion

			#region PinkyPIPNondominant joint features
			hash.Add(obj.PinkyPIPNondominantF1F2SpatialAngle);
			hash.Add(obj.PinkyPIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyPIPNondominantF1FNSpatialAngle);
			hash.Add(obj.PinkyPIPNondominantTotalVectorAngle);
			hash.Add(obj.PinkyPIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyPIPNondominantTotalVectorDisplacement);
			hash.Add(obj.PinkyPIPNondominantTotalDisplacement);
			hash.Add(obj.PinkyPIPNondominantMaximumDisplacement);
			#endregion

			#region PinkyDIPNondominant joint features
			hash.Add(obj.PinkyDIPNondominantF1F2SpatialAngle);
			hash.Add(obj.PinkyDIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyDIPNondominantF1FNSpatialAngle);
			hash.Add(obj.PinkyDIPNondominantTotalVectorAngle);
			hash.Add(obj.PinkyDIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyDIPNondominantTotalVectorDisplacement);
			hash.Add(obj.PinkyDIPNondominantTotalDisplacement);
			hash.Add(obj.PinkyDIPNondominantMaximumDisplacement);
			#endregion

			#region PinkyTIPNondominant joint features
			hash.Add(obj.PinkyTIPNondominantF1F2SpatialAngle);
			hash.Add(obj.PinkyTIPNondominantFN_1FNSpatialAngle);
			hash.Add(obj.PinkyTIPNondominantF1FNSpatialAngle);
			hash.Add(obj.PinkyTIPNondominantTotalVectorAngle);
			hash.Add(obj.PinkyTIPNondominantSquaredTotalVectorAngle);
			hash.Add(obj.PinkyTIPNondominantTotalVectorDisplacement);
			hash.Add(obj.PinkyTIPNondominantTotalDisplacement);
			hash.Add(obj.PinkyTIPNondominantMaximumDisplacement);
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
			//public HandState[] HandNondominantHandStates
			//{
			//	get;
			//	set;
			//}
			#endregion

			#region WristThumbCMCDominantBone bone features
			hash.Add(obj.WristThumbCMCDominantBoneInitialAngle);
			hash.Add(obj.WristThumbCMCDominantBoneFinalAngle);
			hash.Add(obj.WristThumbCMCDominantBoneMeanAngle);
			hash.Add(obj.WristThumbCMCDominantBoneMaximumAngle);
			#endregion

			#region ThumbCMCThumbMCPDominantBone bone features
			hash.Add(obj.ThumbCMCThumbMCPDominantBoneInitialAngle);
			hash.Add(obj.ThumbCMCThumbMCPDominantBoneFinalAngle);
			hash.Add(obj.ThumbCMCThumbMCPDominantBoneMeanAngle);
			hash.Add(obj.ThumbCMCThumbMCPDominantBoneMaximumAngle);
			#endregion

			#region ThumbMCPThumbIPDominantBone bone features
			hash.Add(obj.ThumbMCPThumbIPDominantBoneInitialAngle);
			hash.Add(obj.ThumbMCPThumbIPDominantBoneFinalAngle);
			hash.Add(obj.ThumbMCPThumbIPDominantBoneMeanAngle);
			hash.Add(obj.ThumbMCPThumbIPDominantBoneMaximumAngle);
			#endregion

			#region ThumbIPThumbTIPDominantBone bone features
			hash.Add(obj.ThumbIPThumbTIPDominantBoneInitialAngle);
			hash.Add(obj.ThumbIPThumbTIPDominantBoneFinalAngle);
			hash.Add(obj.ThumbIPThumbTIPDominantBoneMeanAngle);
			hash.Add(obj.ThumbIPThumbTIPDominantBoneMaximumAngle);
			#endregion

			#region WristIndexFingerMCPDominantBone bone features
			hash.Add(obj.WristIndexFingerMCPDominantBoneInitialAngle);
			hash.Add(obj.WristIndexFingerMCPDominantBoneFinalAngle);
			hash.Add(obj.WristIndexFingerMCPDominantBoneMeanAngle);
			hash.Add(obj.WristIndexFingerMCPDominantBoneMaximumAngle);
			#endregion

			#region IndexFingerMCPIndexFingerPIPDominantBone bone features
			hash.Add(obj.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle);
			hash.Add(obj.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle);
			hash.Add(obj.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle);
			hash.Add(obj.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle);
			#endregion

			#region IndexFingerPIPIndexFingerDIPDominantBone bone features
			hash.Add(obj.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle);
			hash.Add(obj.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle);
			hash.Add(obj.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle);
			hash.Add(obj.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle);
			#endregion

			#region IndexFingerDIPIndexFingerTIPDominantBone bone features
			hash.Add(obj.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle);
			hash.Add(obj.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle);
			hash.Add(obj.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle);
			hash.Add(obj.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPDominantBone bone features
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPDominantBone bone features
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPDominantBone bone features
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle);
			#endregion

			#region RingFingerMCPRingFingerPIPDominantBone bone features
			hash.Add(obj.RingFingerMCPRingFingerPIPDominantBoneInitialAngle);
			hash.Add(obj.RingFingerMCPRingFingerPIPDominantBoneFinalAngle);
			hash.Add(obj.RingFingerMCPRingFingerPIPDominantBoneMeanAngle);
			hash.Add(obj.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle);
			#endregion

			#region RingFingerPIPRingFingerDIPDominantBone bone features
			hash.Add(obj.RingFingerPIPRingFingerDIPDominantBoneInitialAngle);
			hash.Add(obj.RingFingerPIPRingFingerDIPDominantBoneFinalAngle);
			hash.Add(obj.RingFingerPIPRingFingerDIPDominantBoneMeanAngle);
			hash.Add(obj.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle);
			#endregion

			#region RingFingerDIPRingFingerTIPDominantBone bone features
			hash.Add(obj.RingFingerDIPRingFingerTIPDominantBoneInitialAngle);
			hash.Add(obj.RingFingerDIPRingFingerTIPDominantBoneFinalAngle);
			hash.Add(obj.RingFingerDIPRingFingerTIPDominantBoneMeanAngle);
			hash.Add(obj.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle);
			#endregion

			#region WristPinkyMCPDominantBone bone features
			hash.Add(obj.WristPinkyMCPDominantBoneInitialAngle);
			hash.Add(obj.WristPinkyMCPDominantBoneFinalAngle);
			hash.Add(obj.WristPinkyMCPDominantBoneMeanAngle);
			hash.Add(obj.WristPinkyMCPDominantBoneMaximumAngle);
			#endregion

			#region PinkyMCPPinkyPIPDominantBone bone features
			hash.Add(obj.PinkyMCPPinkyPIPDominantBoneInitialAngle);
			hash.Add(obj.PinkyMCPPinkyPIPDominantBoneFinalAngle);
			hash.Add(obj.PinkyMCPPinkyPIPDominantBoneMeanAngle);
			hash.Add(obj.PinkyMCPPinkyPIPDominantBoneMaximumAngle);
			#endregion

			#region PinkyPIPPinkyDIPDominantBone bone features
			hash.Add(obj.PinkyPIPPinkyDIPDominantBoneInitialAngle);
			hash.Add(obj.PinkyPIPPinkyDIPDominantBoneFinalAngle);
			hash.Add(obj.PinkyPIPPinkyDIPDominantBoneMeanAngle);
			hash.Add(obj.PinkyPIPPinkyDIPDominantBoneMaximumAngle);
			#endregion

			#region PinkyDIPPinkyTIPDominantBone bone features
			hash.Add(obj.PinkyDIPPinkyTIPDominantBoneInitialAngle);
			hash.Add(obj.PinkyDIPPinkyTIPDominantBoneFinalAngle);
			hash.Add(obj.PinkyDIPPinkyTIPDominantBoneMeanAngle);
			hash.Add(obj.PinkyDIPPinkyTIPDominantBoneMaximumAngle);
			#endregion

			#region ThumbMCPIndexFingerMCPDominantBone bone features
			hash.Add(obj.ThumbMCPIndexFingerMCPDominantBoneInitialAngle);
			hash.Add(obj.ThumbMCPIndexFingerMCPDominantBoneFinalAngle);
			hash.Add(obj.ThumbMCPIndexFingerMCPDominantBoneMeanAngle);
			hash.Add(obj.ThumbMCPIndexFingerMCPDominantBoneMaximumAngle);
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominantBone bone features
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle);
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle);
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle);
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerMCPRingFingerMCPDominantBone bone features
			hash.Add(obj.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle);
			#endregion

			#region RingFingerMCPPinkyMCPDominantBone bone features
			hash.Add(obj.RingFingerMCPPinkyMCPDominantBoneInitialAngle);
			hash.Add(obj.RingFingerMCPPinkyMCPDominantBoneFinalAngle);
			hash.Add(obj.RingFingerMCPPinkyMCPDominantBoneMeanAngle);
			hash.Add(obj.RingFingerMCPPinkyMCPDominantBoneMaximumAngle);
			#endregion

			#region WristThumbCMCNondominantBone bone features
			hash.Add(obj.WristThumbCMCNondominantBoneInitialAngle);
			hash.Add(obj.WristThumbCMCNondominantBoneFinalAngle);
			hash.Add(obj.WristThumbCMCNondominantBoneMeanAngle);
			hash.Add(obj.WristThumbCMCNondominantBoneMaximumAngle);
			#endregion

			#region ThumbCMCThumbMCPNondominantBone bone features
			hash.Add(obj.ThumbCMCThumbMCPNondominantBoneInitialAngle);
			hash.Add(obj.ThumbCMCThumbMCPNondominantBoneFinalAngle);
			hash.Add(obj.ThumbCMCThumbMCPNondominantBoneMeanAngle);
			hash.Add(obj.ThumbCMCThumbMCPNondominantBoneMaximumAngle);
			#endregion

			#region ThumbMCPThumbIPNondominantBone bone features
			hash.Add(obj.ThumbMCPThumbIPNondominantBoneInitialAngle);
			hash.Add(obj.ThumbMCPThumbIPNondominantBoneFinalAngle);
			hash.Add(obj.ThumbMCPThumbIPNondominantBoneMeanAngle);
			hash.Add(obj.ThumbMCPThumbIPNondominantBoneMaximumAngle);
			#endregion

			#region ThumbIPThumbTIPNondominantBone bone features
			hash.Add(obj.ThumbIPThumbTIPNondominantBoneInitialAngle);
			hash.Add(obj.ThumbIPThumbTIPNondominantBoneFinalAngle);
			hash.Add(obj.ThumbIPThumbTIPNondominantBoneMeanAngle);
			hash.Add(obj.ThumbIPThumbTIPNondominantBoneMaximumAngle);
			#endregion

			#region WristIndexFingerMCPNondominantBone bone features
			hash.Add(obj.WristIndexFingerMCPNondominantBoneInitialAngle);
			hash.Add(obj.WristIndexFingerMCPNondominantBoneFinalAngle);
			hash.Add(obj.WristIndexFingerMCPNondominantBoneMeanAngle);
			hash.Add(obj.WristIndexFingerMCPNondominantBoneMaximumAngle);
			#endregion

			#region IndexFingerMCPIndexFingerPIPNondominantBone bone features
			hash.Add(obj.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle);
			hash.Add(obj.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle);
			hash.Add(obj.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle);
			hash.Add(obj.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle);
			#endregion

			#region IndexFingerPIPIndexFingerDIPNondominantBone bone features
			hash.Add(obj.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle);
			hash.Add(obj.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle);
			hash.Add(obj.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle);
			hash.Add(obj.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle);
			#endregion

			#region IndexFingerDIPIndexFingerTIPNondominantBone bone features
			hash.Add(obj.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle);
			hash.Add(obj.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle);
			hash.Add(obj.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle);
			hash.Add(obj.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPNondominantBone bone features
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPNondominantBone bone features
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPNondominantBone bone features
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle);
			#endregion

			#region RingFingerMCPRingFingerPIPNondominantBone bone features
			hash.Add(obj.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle);
			hash.Add(obj.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle);
			hash.Add(obj.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle);
			hash.Add(obj.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle);
			#endregion

			#region RingFingerPIPRingFingerDIPNondominantBone bone features
			hash.Add(obj.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle);
			hash.Add(obj.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle);
			hash.Add(obj.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle);
			hash.Add(obj.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle);
			#endregion

			#region RingFingerDIPRingFingerTIPNondominantBone bone features
			hash.Add(obj.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle);
			hash.Add(obj.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle);
			hash.Add(obj.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle);
			hash.Add(obj.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle);
			#endregion

			#region WristPinkyMCPNondominantBone bone features
			hash.Add(obj.WristPinkyMCPNondominantBoneInitialAngle);
			hash.Add(obj.WristPinkyMCPNondominantBoneFinalAngle);
			hash.Add(obj.WristPinkyMCPNondominantBoneMeanAngle);
			hash.Add(obj.WristPinkyMCPNondominantBoneMaximumAngle);
			#endregion

			#region PinkyMCPPinkyPIPNondominantBone bone features
			hash.Add(obj.PinkyMCPPinkyPIPNondominantBoneInitialAngle);
			hash.Add(obj.PinkyMCPPinkyPIPNondominantBoneFinalAngle);
			hash.Add(obj.PinkyMCPPinkyPIPNondominantBoneMeanAngle);
			hash.Add(obj.PinkyMCPPinkyPIPNondominantBoneMaximumAngle);
			#endregion

			#region PinkyPIPPinkyDIPNondominantBone bone features
			hash.Add(obj.PinkyPIPPinkyDIPNondominantBoneInitialAngle);
			hash.Add(obj.PinkyPIPPinkyDIPNondominantBoneFinalAngle);
			hash.Add(obj.PinkyPIPPinkyDIPNondominantBoneMeanAngle);
			hash.Add(obj.PinkyPIPPinkyDIPNondominantBoneMaximumAngle);
			#endregion

			#region PinkyDIPPinkyTIPNondominantBone bone features
			hash.Add(obj.PinkyDIPPinkyTIPNondominantBoneInitialAngle);
			hash.Add(obj.PinkyDIPPinkyTIPNondominantBoneFinalAngle);
			hash.Add(obj.PinkyDIPPinkyTIPNondominantBoneMeanAngle);
			hash.Add(obj.PinkyDIPPinkyTIPNondominantBoneMaximumAngle);
			#endregion

			#region ThumbMCPIndexFingerMCPNondominantBone bone features
			hash.Add(obj.ThumbMCPIndexFingerMCPNondominantBoneInitialAngle);
			hash.Add(obj.ThumbMCPIndexFingerMCPNondominantBoneFinalAngle);
			hash.Add(obj.ThumbMCPIndexFingerMCPNondominantBoneMeanAngle);
			hash.Add(obj.ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle);
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominantBone bone features
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle);
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle);
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle);
			hash.Add(obj.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle);
			#endregion

			#region MiddleFingerMCPRingFingerMCPNondominantBone bone features
			hash.Add(obj.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle);
			hash.Add(obj.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle);
			hash.Add(obj.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle);
			hash.Add(obj.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle);
			#endregion

			#region RingFingerMCPPinkyMCPNondominantBone bone features
			hash.Add(obj.RingFingerMCPPinkyMCPNondominantBoneInitialAngle);
			hash.Add(obj.RingFingerMCPPinkyMCPNondominantBoneFinalAngle);
			hash.Add(obj.RingFingerMCPPinkyMCPNondominantBoneMeanAngle);
			hash.Add(obj.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle);
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
