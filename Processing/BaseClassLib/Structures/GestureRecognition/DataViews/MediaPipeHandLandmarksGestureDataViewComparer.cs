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
			NullableEquals(x.WristDominantF1F2SpatialAngle, y.WristDominantF1F2SpatialAngle) &&
			NullableEquals(x.WristDominantFN_1FNSpatialAngle, y.WristDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.WristDominantF1FNSpatialAngle, y.WristDominantF1FNSpatialAngle) &&
			NullableEquals(x.WristDominantTotalVectorAngle, y.WristDominantTotalVectorAngle) &&
			NullableEquals(x.WristDominantSquaredTotalVectorAngle, y.WristDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.WristDominantTotalVectorDisplacement, y.WristDominantTotalVectorDisplacement) &&
			NullableEquals(x.WristDominantTotalDisplacement, y.WristDominantTotalDisplacement) &&
			NullableEquals(x.WristDominantMaximumDisplacement, y.WristDominantMaximumDisplacement) &&
			#endregion

			#region ThumbCMCDominant joint features
			NullableEquals(x.ThumbCMCDominantF1F2SpatialAngle, y.ThumbCMCDominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbCMCDominantFN_1FNSpatialAngle, y.ThumbCMCDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbCMCDominantF1FNSpatialAngle, y.ThumbCMCDominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbCMCDominantTotalVectorAngle, y.ThumbCMCDominantTotalVectorAngle) &&
			NullableEquals(x.ThumbCMCDominantSquaredTotalVectorAngle, y.ThumbCMCDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbCMCDominantTotalVectorDisplacement, y.ThumbCMCDominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbCMCDominantTotalDisplacement, y.ThumbCMCDominantTotalDisplacement) &&
			NullableEquals(x.ThumbCMCDominantMaximumDisplacement, y.ThumbCMCDominantMaximumDisplacement) &&
			#endregion

			#region ThumbMCPDominant joint features
			NullableEquals(x.ThumbMCPDominantF1F2SpatialAngle, y.ThumbMCPDominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbMCPDominantFN_1FNSpatialAngle, y.ThumbMCPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbMCPDominantF1FNSpatialAngle, y.ThumbMCPDominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbMCPDominantTotalVectorAngle, y.ThumbMCPDominantTotalVectorAngle) &&
			NullableEquals(x.ThumbMCPDominantSquaredTotalVectorAngle, y.ThumbMCPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbMCPDominantTotalVectorDisplacement, y.ThumbMCPDominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbMCPDominantTotalDisplacement, y.ThumbMCPDominantTotalDisplacement) &&
			NullableEquals(x.ThumbMCPDominantMaximumDisplacement, y.ThumbMCPDominantMaximumDisplacement) &&
			#endregion

			#region ThumbIPDominant joint features
			NullableEquals(x.ThumbIPDominantF1F2SpatialAngle, y.ThumbIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbIPDominantFN_1FNSpatialAngle, y.ThumbIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbIPDominantF1FNSpatialAngle, y.ThumbIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbIPDominantTotalVectorAngle, y.ThumbIPDominantTotalVectorAngle) &&
			NullableEquals(x.ThumbIPDominantSquaredTotalVectorAngle, y.ThumbIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbIPDominantTotalVectorDisplacement, y.ThumbIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbIPDominantTotalDisplacement, y.ThumbIPDominantTotalDisplacement) &&
			NullableEquals(x.ThumbIPDominantMaximumDisplacement, y.ThumbIPDominantMaximumDisplacement) &&
			#endregion

			#region ThumbTIPDominant joint features
			NullableEquals(x.ThumbTIPDominantF1F2SpatialAngle, y.ThumbTIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbTIPDominantFN_1FNSpatialAngle, y.ThumbTIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbTIPDominantF1FNSpatialAngle, y.ThumbTIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbTIPDominantTotalVectorAngle, y.ThumbTIPDominantTotalVectorAngle) &&
			NullableEquals(x.ThumbTIPDominantSquaredTotalVectorAngle, y.ThumbTIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbTIPDominantTotalVectorDisplacement, y.ThumbTIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbTIPDominantTotalDisplacement, y.ThumbTIPDominantTotalDisplacement) &&
			NullableEquals(x.ThumbTIPDominantMaximumDisplacement, y.ThumbTIPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerMCPDominant joint features
			NullableEquals(x.IndexFingerMCPDominantF1F2SpatialAngle, y.IndexFingerMCPDominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerMCPDominantFN_1FNSpatialAngle, y.IndexFingerMCPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerMCPDominantF1FNSpatialAngle, y.IndexFingerMCPDominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerMCPDominantTotalVectorAngle, y.IndexFingerMCPDominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerMCPDominantSquaredTotalVectorAngle, y.IndexFingerMCPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerMCPDominantTotalVectorDisplacement, y.IndexFingerMCPDominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerMCPDominantTotalDisplacement, y.IndexFingerMCPDominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerMCPDominantMaximumDisplacement, y.IndexFingerMCPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerPIPDominant joint features
			NullableEquals(x.IndexFingerPIPDominantF1F2SpatialAngle, y.IndexFingerPIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerPIPDominantFN_1FNSpatialAngle, y.IndexFingerPIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerPIPDominantF1FNSpatialAngle, y.IndexFingerPIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerPIPDominantTotalVectorAngle, y.IndexFingerPIPDominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerPIPDominantSquaredTotalVectorAngle, y.IndexFingerPIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerPIPDominantTotalVectorDisplacement, y.IndexFingerPIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerPIPDominantTotalDisplacement, y.IndexFingerPIPDominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerPIPDominantMaximumDisplacement, y.IndexFingerPIPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerDIPDominant joint features
			NullableEquals(x.IndexFingerDIPDominantF1F2SpatialAngle, y.IndexFingerDIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerDIPDominantFN_1FNSpatialAngle, y.IndexFingerDIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerDIPDominantF1FNSpatialAngle, y.IndexFingerDIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerDIPDominantTotalVectorAngle, y.IndexFingerDIPDominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerDIPDominantSquaredTotalVectorAngle, y.IndexFingerDIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerDIPDominantTotalVectorDisplacement, y.IndexFingerDIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerDIPDominantTotalDisplacement, y.IndexFingerDIPDominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerDIPDominantMaximumDisplacement, y.IndexFingerDIPDominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerTIPDominant joint features
			NullableEquals(x.IndexFingerTIPDominantF1F2SpatialAngle, y.IndexFingerTIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerTIPDominantFN_1FNSpatialAngle, y.IndexFingerTIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerTIPDominantF1FNSpatialAngle, y.IndexFingerTIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerTIPDominantTotalVectorAngle, y.IndexFingerTIPDominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerTIPDominantSquaredTotalVectorAngle, y.IndexFingerTIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerTIPDominantTotalVectorDisplacement, y.IndexFingerTIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerTIPDominantTotalDisplacement, y.IndexFingerTIPDominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerTIPDominantMaximumDisplacement, y.IndexFingerTIPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerMCPDominant joint features
			NullableEquals(x.MiddleFingerMCPDominantF1F2SpatialAngle, y.MiddleFingerMCPDominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerMCPDominantFN_1FNSpatialAngle, y.MiddleFingerMCPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerMCPDominantF1FNSpatialAngle, y.MiddleFingerMCPDominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerMCPDominantTotalVectorAngle, y.MiddleFingerMCPDominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerMCPDominantSquaredTotalVectorAngle, y.MiddleFingerMCPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerMCPDominantTotalVectorDisplacement, y.MiddleFingerMCPDominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerMCPDominantTotalDisplacement, y.MiddleFingerMCPDominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerMCPDominantMaximumDisplacement, y.MiddleFingerMCPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerPIPDominant joint features
			NullableEquals(x.MiddleFingerPIPDominantF1F2SpatialAngle, y.MiddleFingerPIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerPIPDominantFN_1FNSpatialAngle, y.MiddleFingerPIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerPIPDominantF1FNSpatialAngle, y.MiddleFingerPIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerPIPDominantTotalVectorAngle, y.MiddleFingerPIPDominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerPIPDominantSquaredTotalVectorAngle, y.MiddleFingerPIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerPIPDominantTotalVectorDisplacement, y.MiddleFingerPIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerPIPDominantTotalDisplacement, y.MiddleFingerPIPDominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerPIPDominantMaximumDisplacement, y.MiddleFingerPIPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerDIPDominant joint features
			NullableEquals(x.MiddleFingerDIPDominantF1F2SpatialAngle, y.MiddleFingerDIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerDIPDominantFN_1FNSpatialAngle, y.MiddleFingerDIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerDIPDominantF1FNSpatialAngle, y.MiddleFingerDIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerDIPDominantTotalVectorAngle, y.MiddleFingerDIPDominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerDIPDominantSquaredTotalVectorAngle, y.MiddleFingerDIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerDIPDominantTotalVectorDisplacement, y.MiddleFingerDIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerDIPDominantTotalDisplacement, y.MiddleFingerDIPDominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerDIPDominantMaximumDisplacement, y.MiddleFingerDIPDominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerTIPDominant joint features
			NullableEquals(x.MiddleFingerTIPDominantF1F2SpatialAngle, y.MiddleFingerTIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerTIPDominantFN_1FNSpatialAngle, y.MiddleFingerTIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerTIPDominantF1FNSpatialAngle, y.MiddleFingerTIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerTIPDominantTotalVectorAngle, y.MiddleFingerTIPDominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerTIPDominantSquaredTotalVectorAngle, y.MiddleFingerTIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerTIPDominantTotalVectorDisplacement, y.MiddleFingerTIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerTIPDominantTotalDisplacement, y.MiddleFingerTIPDominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerTIPDominantMaximumDisplacement, y.MiddleFingerTIPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerMCPDominant joint features
			NullableEquals(x.RingFingerMCPDominantF1F2SpatialAngle, y.RingFingerMCPDominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerMCPDominantFN_1FNSpatialAngle, y.RingFingerMCPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerMCPDominantF1FNSpatialAngle, y.RingFingerMCPDominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerMCPDominantTotalVectorAngle, y.RingFingerMCPDominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerMCPDominantSquaredTotalVectorAngle, y.RingFingerMCPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerMCPDominantTotalVectorDisplacement, y.RingFingerMCPDominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerMCPDominantTotalDisplacement, y.RingFingerMCPDominantTotalDisplacement) &&
			NullableEquals(x.RingFingerMCPDominantMaximumDisplacement, y.RingFingerMCPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerPIPDominant joint features
			NullableEquals(x.RingFingerPIPDominantF1F2SpatialAngle, y.RingFingerPIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerPIPDominantFN_1FNSpatialAngle, y.RingFingerPIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerPIPDominantF1FNSpatialAngle, y.RingFingerPIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerPIPDominantTotalVectorAngle, y.RingFingerPIPDominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerPIPDominantSquaredTotalVectorAngle, y.RingFingerPIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerPIPDominantTotalVectorDisplacement, y.RingFingerPIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerPIPDominantTotalDisplacement, y.RingFingerPIPDominantTotalDisplacement) &&
			NullableEquals(x.RingFingerPIPDominantMaximumDisplacement, y.RingFingerPIPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerDIPDominant joint features
			NullableEquals(x.RingFingerDIPDominantF1F2SpatialAngle, y.RingFingerDIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerDIPDominantFN_1FNSpatialAngle, y.RingFingerDIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerDIPDominantF1FNSpatialAngle, y.RingFingerDIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerDIPDominantTotalVectorAngle, y.RingFingerDIPDominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerDIPDominantSquaredTotalVectorAngle, y.RingFingerDIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerDIPDominantTotalVectorDisplacement, y.RingFingerDIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerDIPDominantTotalDisplacement, y.RingFingerDIPDominantTotalDisplacement) &&
			NullableEquals(x.RingFingerDIPDominantMaximumDisplacement, y.RingFingerDIPDominantMaximumDisplacement) &&
			#endregion

			#region RingFingerTIPDominant joint features
			NullableEquals(x.RingFingerTIPDominantF1F2SpatialAngle, y.RingFingerTIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerTIPDominantFN_1FNSpatialAngle, y.RingFingerTIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerTIPDominantF1FNSpatialAngle, y.RingFingerTIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerTIPDominantTotalVectorAngle, y.RingFingerTIPDominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerTIPDominantSquaredTotalVectorAngle, y.RingFingerTIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerTIPDominantTotalVectorDisplacement, y.RingFingerTIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerTIPDominantTotalDisplacement, y.RingFingerTIPDominantTotalDisplacement) &&
			NullableEquals(x.RingFingerTIPDominantMaximumDisplacement, y.RingFingerTIPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyMCPDominant joint features
			NullableEquals(x.PinkyMCPDominantF1F2SpatialAngle, y.PinkyMCPDominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyMCPDominantFN_1FNSpatialAngle, y.PinkyMCPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyMCPDominantF1FNSpatialAngle, y.PinkyMCPDominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyMCPDominantTotalVectorAngle, y.PinkyMCPDominantTotalVectorAngle) &&
			NullableEquals(x.PinkyMCPDominantSquaredTotalVectorAngle, y.PinkyMCPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyMCPDominantTotalVectorDisplacement, y.PinkyMCPDominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyMCPDominantTotalDisplacement, y.PinkyMCPDominantTotalDisplacement) &&
			NullableEquals(x.PinkyMCPDominantMaximumDisplacement, y.PinkyMCPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyPIPDominant joint features
			NullableEquals(x.PinkyPIPDominantF1F2SpatialAngle, y.PinkyPIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyPIPDominantFN_1FNSpatialAngle, y.PinkyPIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyPIPDominantF1FNSpatialAngle, y.PinkyPIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyPIPDominantTotalVectorAngle, y.PinkyPIPDominantTotalVectorAngle) &&
			NullableEquals(x.PinkyPIPDominantSquaredTotalVectorAngle, y.PinkyPIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyPIPDominantTotalVectorDisplacement, y.PinkyPIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyPIPDominantTotalDisplacement, y.PinkyPIPDominantTotalDisplacement) &&
			NullableEquals(x.PinkyPIPDominantMaximumDisplacement, y.PinkyPIPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyDIPDominant joint features
			NullableEquals(x.PinkyDIPDominantF1F2SpatialAngle, y.PinkyDIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyDIPDominantFN_1FNSpatialAngle, y.PinkyDIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyDIPDominantF1FNSpatialAngle, y.PinkyDIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyDIPDominantTotalVectorAngle, y.PinkyDIPDominantTotalVectorAngle) &&
			NullableEquals(x.PinkyDIPDominantSquaredTotalVectorAngle, y.PinkyDIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyDIPDominantTotalVectorDisplacement, y.PinkyDIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyDIPDominantTotalDisplacement, y.PinkyDIPDominantTotalDisplacement) &&
			NullableEquals(x.PinkyDIPDominantMaximumDisplacement, y.PinkyDIPDominantMaximumDisplacement) &&
			#endregion

			#region PinkyTIPDominant joint features
			NullableEquals(x.PinkyTIPDominantF1F2SpatialAngle, y.PinkyTIPDominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyTIPDominantFN_1FNSpatialAngle, y.PinkyTIPDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyTIPDominantF1FNSpatialAngle, y.PinkyTIPDominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyTIPDominantTotalVectorAngle, y.PinkyTIPDominantTotalVectorAngle) &&
			NullableEquals(x.PinkyTIPDominantSquaredTotalVectorAngle, y.PinkyTIPDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyTIPDominantTotalVectorDisplacement, y.PinkyTIPDominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyTIPDominantTotalDisplacement, y.PinkyTIPDominantTotalDisplacement) &&
			NullableEquals(x.PinkyTIPDominantMaximumDisplacement, y.PinkyTIPDominantMaximumDisplacement) &&
			#endregion

			#region HandDominant joint features
			NullableEquals(x.HandDominantF1F2SpatialAngle, y.HandDominantF1F2SpatialAngle) &&
			NullableEquals(x.HandDominantFN_1FNSpatialAngle, y.HandDominantFN_1FNSpatialAngle) &&
			NullableEquals(x.HandDominantF1FNSpatialAngle, y.HandDominantF1FNSpatialAngle) &&
			NullableEquals(x.HandDominantTotalVectorAngle, y.HandDominantTotalVectorAngle) &&
			NullableEquals(x.HandDominantSquaredTotalVectorAngle, y.HandDominantSquaredTotalVectorAngle) &&
			NullableEquals(x.HandDominantTotalVectorDisplacement, y.HandDominantTotalVectorDisplacement) &&
			NullableEquals(x.HandDominantTotalDisplacement, y.HandDominantTotalDisplacement) &&
			NullableEquals(x.HandDominantMaximumDisplacement, y.HandDominantMaximumDisplacement) &&
			NullableEquals(x.HandDominantBoundingBoxDiagonalLength, y.HandDominantBoundingBoxDiagonalLength) &&
			NullableEquals(x.HandDominantBoundingBoxAngle, y.HandDominantBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandDominantHandStates
			#endregion

			#region WristNondominant joint features
			NullableEquals(x.WristNondominantF1F2SpatialAngle, y.WristNondominantF1F2SpatialAngle) &&
			NullableEquals(x.WristNondominantFN_1FNSpatialAngle, y.WristNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.WristNondominantF1FNSpatialAngle, y.WristNondominantF1FNSpatialAngle) &&
			NullableEquals(x.WristNondominantTotalVectorAngle, y.WristNondominantTotalVectorAngle) &&
			NullableEquals(x.WristNondominantSquaredTotalVectorAngle, y.WristNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.WristNondominantTotalVectorDisplacement, y.WristNondominantTotalVectorDisplacement) &&
			NullableEquals(x.WristNondominantTotalDisplacement, y.WristNondominantTotalDisplacement) &&
			NullableEquals(x.WristNondominantMaximumDisplacement, y.WristNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbCMCNondominant joint features
			NullableEquals(x.ThumbCMCNondominantF1F2SpatialAngle, y.ThumbCMCNondominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbCMCNondominantFN_1FNSpatialAngle, y.ThumbCMCNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbCMCNondominantF1FNSpatialAngle, y.ThumbCMCNondominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbCMCNondominantTotalVectorAngle, y.ThumbCMCNondominantTotalVectorAngle) &&
			NullableEquals(x.ThumbCMCNondominantSquaredTotalVectorAngle, y.ThumbCMCNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbCMCNondominantTotalVectorDisplacement, y.ThumbCMCNondominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbCMCNondominantTotalDisplacement, y.ThumbCMCNondominantTotalDisplacement) &&
			NullableEquals(x.ThumbCMCNondominantMaximumDisplacement, y.ThumbCMCNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbMCPNondominant joint features
			NullableEquals(x.ThumbMCPNondominantF1F2SpatialAngle, y.ThumbMCPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbMCPNondominantFN_1FNSpatialAngle, y.ThumbMCPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbMCPNondominantF1FNSpatialAngle, y.ThumbMCPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbMCPNondominantTotalVectorAngle, y.ThumbMCPNondominantTotalVectorAngle) &&
			NullableEquals(x.ThumbMCPNondominantSquaredTotalVectorAngle, y.ThumbMCPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbMCPNondominantTotalVectorDisplacement, y.ThumbMCPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbMCPNondominantTotalDisplacement, y.ThumbMCPNondominantTotalDisplacement) &&
			NullableEquals(x.ThumbMCPNondominantMaximumDisplacement, y.ThumbMCPNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbIPNondominant joint features
			NullableEquals(x.ThumbIPNondominantF1F2SpatialAngle, y.ThumbIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbIPNondominantFN_1FNSpatialAngle, y.ThumbIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbIPNondominantF1FNSpatialAngle, y.ThumbIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbIPNondominantTotalVectorAngle, y.ThumbIPNondominantTotalVectorAngle) &&
			NullableEquals(x.ThumbIPNondominantSquaredTotalVectorAngle, y.ThumbIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbIPNondominantTotalVectorDisplacement, y.ThumbIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbIPNondominantTotalDisplacement, y.ThumbIPNondominantTotalDisplacement) &&
			NullableEquals(x.ThumbIPNondominantMaximumDisplacement, y.ThumbIPNondominantMaximumDisplacement) &&
			#endregion

			#region ThumbTIPNondominant joint features
			NullableEquals(x.ThumbTIPNondominantF1F2SpatialAngle, y.ThumbTIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.ThumbTIPNondominantFN_1FNSpatialAngle, y.ThumbTIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.ThumbTIPNondominantF1FNSpatialAngle, y.ThumbTIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.ThumbTIPNondominantTotalVectorAngle, y.ThumbTIPNondominantTotalVectorAngle) &&
			NullableEquals(x.ThumbTIPNondominantSquaredTotalVectorAngle, y.ThumbTIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.ThumbTIPNondominantTotalVectorDisplacement, y.ThumbTIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.ThumbTIPNondominantTotalDisplacement, y.ThumbTIPNondominantTotalDisplacement) &&
			NullableEquals(x.ThumbTIPNondominantMaximumDisplacement, y.ThumbTIPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerMCPNondominant joint features
			NullableEquals(x.IndexFingerMCPNondominantF1F2SpatialAngle, y.IndexFingerMCPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerMCPNondominantFN_1FNSpatialAngle, y.IndexFingerMCPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerMCPNondominantF1FNSpatialAngle, y.IndexFingerMCPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerMCPNondominantTotalVectorAngle, y.IndexFingerMCPNondominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerMCPNondominantSquaredTotalVectorAngle, y.IndexFingerMCPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerMCPNondominantTotalVectorDisplacement, y.IndexFingerMCPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerMCPNondominantTotalDisplacement, y.IndexFingerMCPNondominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerMCPNondominantMaximumDisplacement, y.IndexFingerMCPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerPIPNondominant joint features
			NullableEquals(x.IndexFingerPIPNondominantF1F2SpatialAngle, y.IndexFingerPIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerPIPNondominantFN_1FNSpatialAngle, y.IndexFingerPIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerPIPNondominantF1FNSpatialAngle, y.IndexFingerPIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerPIPNondominantTotalVectorAngle, y.IndexFingerPIPNondominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerPIPNondominantSquaredTotalVectorAngle, y.IndexFingerPIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerPIPNondominantTotalVectorDisplacement, y.IndexFingerPIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerPIPNondominantTotalDisplacement, y.IndexFingerPIPNondominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerPIPNondominantMaximumDisplacement, y.IndexFingerPIPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerDIPNondominant joint features
			NullableEquals(x.IndexFingerDIPNondominantF1F2SpatialAngle, y.IndexFingerDIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerDIPNondominantFN_1FNSpatialAngle, y.IndexFingerDIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerDIPNondominantF1FNSpatialAngle, y.IndexFingerDIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerDIPNondominantTotalVectorAngle, y.IndexFingerDIPNondominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerDIPNondominantSquaredTotalVectorAngle, y.IndexFingerDIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerDIPNondominantTotalVectorDisplacement, y.IndexFingerDIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerDIPNondominantTotalDisplacement, y.IndexFingerDIPNondominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerDIPNondominantMaximumDisplacement, y.IndexFingerDIPNondominantMaximumDisplacement) &&
			#endregion

			#region IndexFingerTIPNondominant joint features
			NullableEquals(x.IndexFingerTIPNondominantF1F2SpatialAngle, y.IndexFingerTIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.IndexFingerTIPNondominantFN_1FNSpatialAngle, y.IndexFingerTIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerTIPNondominantF1FNSpatialAngle, y.IndexFingerTIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.IndexFingerTIPNondominantTotalVectorAngle, y.IndexFingerTIPNondominantTotalVectorAngle) &&
			NullableEquals(x.IndexFingerTIPNondominantSquaredTotalVectorAngle, y.IndexFingerTIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.IndexFingerTIPNondominantTotalVectorDisplacement, y.IndexFingerTIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.IndexFingerTIPNondominantTotalDisplacement, y.IndexFingerTIPNondominantTotalDisplacement) &&
			NullableEquals(x.IndexFingerTIPNondominantMaximumDisplacement, y.IndexFingerTIPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerMCPNondominant joint features
			NullableEquals(x.MiddleFingerMCPNondominantF1F2SpatialAngle, y.MiddleFingerMCPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerMCPNondominantFN_1FNSpatialAngle, y.MiddleFingerMCPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerMCPNondominantF1FNSpatialAngle, y.MiddleFingerMCPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerMCPNondominantTotalVectorAngle, y.MiddleFingerMCPNondominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerMCPNondominantSquaredTotalVectorAngle, y.MiddleFingerMCPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerMCPNondominantTotalVectorDisplacement, y.MiddleFingerMCPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerMCPNondominantTotalDisplacement, y.MiddleFingerMCPNondominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerMCPNondominantMaximumDisplacement, y.MiddleFingerMCPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerPIPNondominant joint features
			NullableEquals(x.MiddleFingerPIPNondominantF1F2SpatialAngle, y.MiddleFingerPIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerPIPNondominantFN_1FNSpatialAngle, y.MiddleFingerPIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerPIPNondominantF1FNSpatialAngle, y.MiddleFingerPIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerPIPNondominantTotalVectorAngle, y.MiddleFingerPIPNondominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerPIPNondominantSquaredTotalVectorAngle, y.MiddleFingerPIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerPIPNondominantTotalVectorDisplacement, y.MiddleFingerPIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerPIPNondominantTotalDisplacement, y.MiddleFingerPIPNondominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerPIPNondominantMaximumDisplacement, y.MiddleFingerPIPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerDIPNondominant joint features
			NullableEquals(x.MiddleFingerDIPNondominantF1F2SpatialAngle, y.MiddleFingerDIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerDIPNondominantFN_1FNSpatialAngle, y.MiddleFingerDIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerDIPNondominantF1FNSpatialAngle, y.MiddleFingerDIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerDIPNondominantTotalVectorAngle, y.MiddleFingerDIPNondominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerDIPNondominantSquaredTotalVectorAngle, y.MiddleFingerDIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerDIPNondominantTotalVectorDisplacement, y.MiddleFingerDIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerDIPNondominantTotalDisplacement, y.MiddleFingerDIPNondominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerDIPNondominantMaximumDisplacement, y.MiddleFingerDIPNondominantMaximumDisplacement) &&
			#endregion

			#region MiddleFingerTIPNondominant joint features
			NullableEquals(x.MiddleFingerTIPNondominantF1F2SpatialAngle, y.MiddleFingerTIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.MiddleFingerTIPNondominantFN_1FNSpatialAngle, y.MiddleFingerTIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerTIPNondominantF1FNSpatialAngle, y.MiddleFingerTIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.MiddleFingerTIPNondominantTotalVectorAngle, y.MiddleFingerTIPNondominantTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerTIPNondominantSquaredTotalVectorAngle, y.MiddleFingerTIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.MiddleFingerTIPNondominantTotalVectorDisplacement, y.MiddleFingerTIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.MiddleFingerTIPNondominantTotalDisplacement, y.MiddleFingerTIPNondominantTotalDisplacement) &&
			NullableEquals(x.MiddleFingerTIPNondominantMaximumDisplacement, y.MiddleFingerTIPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerMCPNondominant joint features
			NullableEquals(x.RingFingerMCPNondominantF1F2SpatialAngle, y.RingFingerMCPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerMCPNondominantFN_1FNSpatialAngle, y.RingFingerMCPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerMCPNondominantF1FNSpatialAngle, y.RingFingerMCPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerMCPNondominantTotalVectorAngle, y.RingFingerMCPNondominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerMCPNondominantSquaredTotalVectorAngle, y.RingFingerMCPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerMCPNondominantTotalVectorDisplacement, y.RingFingerMCPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerMCPNondominantTotalDisplacement, y.RingFingerMCPNondominantTotalDisplacement) &&
			NullableEquals(x.RingFingerMCPNondominantMaximumDisplacement, y.RingFingerMCPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerPIPNondominant joint features
			NullableEquals(x.RingFingerPIPNondominantF1F2SpatialAngle, y.RingFingerPIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerPIPNondominantFN_1FNSpatialAngle, y.RingFingerPIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerPIPNondominantF1FNSpatialAngle, y.RingFingerPIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerPIPNondominantTotalVectorAngle, y.RingFingerPIPNondominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerPIPNondominantSquaredTotalVectorAngle, y.RingFingerPIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerPIPNondominantTotalVectorDisplacement, y.RingFingerPIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerPIPNondominantTotalDisplacement, y.RingFingerPIPNondominantTotalDisplacement) &&
			NullableEquals(x.RingFingerPIPNondominantMaximumDisplacement, y.RingFingerPIPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerDIPNondominant joint features
			NullableEquals(x.RingFingerDIPNondominantF1F2SpatialAngle, y.RingFingerDIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerDIPNondominantFN_1FNSpatialAngle, y.RingFingerDIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerDIPNondominantF1FNSpatialAngle, y.RingFingerDIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerDIPNondominantTotalVectorAngle, y.RingFingerDIPNondominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerDIPNondominantSquaredTotalVectorAngle, y.RingFingerDIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerDIPNondominantTotalVectorDisplacement, y.RingFingerDIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerDIPNondominantTotalDisplacement, y.RingFingerDIPNondominantTotalDisplacement) &&
			NullableEquals(x.RingFingerDIPNondominantMaximumDisplacement, y.RingFingerDIPNondominantMaximumDisplacement) &&
			#endregion

			#region RingFingerTIPNondominant joint features
			NullableEquals(x.RingFingerTIPNondominantF1F2SpatialAngle, y.RingFingerTIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.RingFingerTIPNondominantFN_1FNSpatialAngle, y.RingFingerTIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.RingFingerTIPNondominantF1FNSpatialAngle, y.RingFingerTIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.RingFingerTIPNondominantTotalVectorAngle, y.RingFingerTIPNondominantTotalVectorAngle) &&
			NullableEquals(x.RingFingerTIPNondominantSquaredTotalVectorAngle, y.RingFingerTIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.RingFingerTIPNondominantTotalVectorDisplacement, y.RingFingerTIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.RingFingerTIPNondominantTotalDisplacement, y.RingFingerTIPNondominantTotalDisplacement) &&
			NullableEquals(x.RingFingerTIPNondominantMaximumDisplacement, y.RingFingerTIPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyMCPNondominant joint features
			NullableEquals(x.PinkyMCPNondominantF1F2SpatialAngle, y.PinkyMCPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyMCPNondominantFN_1FNSpatialAngle, y.PinkyMCPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyMCPNondominantF1FNSpatialAngle, y.PinkyMCPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyMCPNondominantTotalVectorAngle, y.PinkyMCPNondominantTotalVectorAngle) &&
			NullableEquals(x.PinkyMCPNondominantSquaredTotalVectorAngle, y.PinkyMCPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyMCPNondominantTotalVectorDisplacement, y.PinkyMCPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyMCPNondominantTotalDisplacement, y.PinkyMCPNondominantTotalDisplacement) &&
			NullableEquals(x.PinkyMCPNondominantMaximumDisplacement, y.PinkyMCPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyPIPNondominant joint features
			NullableEquals(x.PinkyPIPNondominantF1F2SpatialAngle, y.PinkyPIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyPIPNondominantFN_1FNSpatialAngle, y.PinkyPIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyPIPNondominantF1FNSpatialAngle, y.PinkyPIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyPIPNondominantTotalVectorAngle, y.PinkyPIPNondominantTotalVectorAngle) &&
			NullableEquals(x.PinkyPIPNondominantSquaredTotalVectorAngle, y.PinkyPIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyPIPNondominantTotalVectorDisplacement, y.PinkyPIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyPIPNondominantTotalDisplacement, y.PinkyPIPNondominantTotalDisplacement) &&
			NullableEquals(x.PinkyPIPNondominantMaximumDisplacement, y.PinkyPIPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyDIPNondominant joint features
			NullableEquals(x.PinkyDIPNondominantF1F2SpatialAngle, y.PinkyDIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyDIPNondominantFN_1FNSpatialAngle, y.PinkyDIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyDIPNondominantF1FNSpatialAngle, y.PinkyDIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyDIPNondominantTotalVectorAngle, y.PinkyDIPNondominantTotalVectorAngle) &&
			NullableEquals(x.PinkyDIPNondominantSquaredTotalVectorAngle, y.PinkyDIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyDIPNondominantTotalVectorDisplacement, y.PinkyDIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyDIPNondominantTotalDisplacement, y.PinkyDIPNondominantTotalDisplacement) &&
			NullableEquals(x.PinkyDIPNondominantMaximumDisplacement, y.PinkyDIPNondominantMaximumDisplacement) &&
			#endregion

			#region PinkyTIPNondominant joint features
			NullableEquals(x.PinkyTIPNondominantF1F2SpatialAngle, y.PinkyTIPNondominantF1F2SpatialAngle) &&
			NullableEquals(x.PinkyTIPNondominantFN_1FNSpatialAngle, y.PinkyTIPNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.PinkyTIPNondominantF1FNSpatialAngle, y.PinkyTIPNondominantF1FNSpatialAngle) &&
			NullableEquals(x.PinkyTIPNondominantTotalVectorAngle, y.PinkyTIPNondominantTotalVectorAngle) &&
			NullableEquals(x.PinkyTIPNondominantSquaredTotalVectorAngle, y.PinkyTIPNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.PinkyTIPNondominantTotalVectorDisplacement, y.PinkyTIPNondominantTotalVectorDisplacement) &&
			NullableEquals(x.PinkyTIPNondominantTotalDisplacement, y.PinkyTIPNondominantTotalDisplacement) &&
			NullableEquals(x.PinkyTIPNondominantMaximumDisplacement, y.PinkyTIPNondominantMaximumDisplacement) &&
			#endregion

			#region HandNondominant joint features
			NullableEquals(x.HandNondominantF1F2SpatialAngle, y.HandNondominantF1F2SpatialAngle) &&
			NullableEquals(x.HandNondominantFN_1FNSpatialAngle, y.HandNondominantFN_1FNSpatialAngle) &&
			NullableEquals(x.HandNondominantF1FNSpatialAngle, y.HandNondominantF1FNSpatialAngle) &&
			NullableEquals(x.HandNondominantTotalVectorAngle, y.HandNondominantTotalVectorAngle) &&
			NullableEquals(x.HandNondominantSquaredTotalVectorAngle, y.HandNondominantSquaredTotalVectorAngle) &&
			NullableEquals(x.HandNondominantTotalVectorDisplacement, y.HandNondominantTotalVectorDisplacement) &&
			NullableEquals(x.HandNondominantTotalDisplacement, y.HandNondominantTotalDisplacement) &&
			NullableEquals(x.HandNondominantMaximumDisplacement, y.HandNondominantMaximumDisplacement) &&
			NullableEquals(x.HandNondominantBoundingBoxDiagonalLength, y.HandNondominantBoundingBoxDiagonalLength) &&
			NullableEquals(x.HandNondominantBoundingBoxAngle, y.HandNondominantBoundingBoxAngle) &&
			// Turned off for now, if the results are not satisfactory then turn it on
			// HandNondominantHandStates
			#endregion

			#region WristThumbCMCDominantBone bone features
			NullableEquals(x.WristThumbCMCDominantBoneInitialAngle, y.WristThumbCMCDominantBoneInitialAngle) &&
			NullableEquals(x.WristThumbCMCDominantBoneFinalAngle, y.WristThumbCMCDominantBoneFinalAngle) &&
			NullableEquals(x.WristThumbCMCDominantBoneMeanAngle, y.WristThumbCMCDominantBoneMeanAngle) &&
			NullableEquals(x.WristThumbCMCDominantBoneMaximumAngle, y.WristThumbCMCDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbCMCThumbMCPDominantBone bone features
			NullableEquals(x.ThumbCMCThumbMCPDominantBoneInitialAngle, y.ThumbCMCThumbMCPDominantBoneInitialAngle) &&
			NullableEquals(x.ThumbCMCThumbMCPDominantBoneFinalAngle, y.ThumbCMCThumbMCPDominantBoneFinalAngle) &&
			NullableEquals(x.ThumbCMCThumbMCPDominantBoneMeanAngle, y.ThumbCMCThumbMCPDominantBoneMeanAngle) &&
			NullableEquals(x.ThumbCMCThumbMCPDominantBoneMaximumAngle, y.ThumbCMCThumbMCPDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPThumbIPDominantBone bone features
			NullableEquals(x.ThumbMCPThumbIPDominantBoneInitialAngle, y.ThumbMCPThumbIPDominantBoneInitialAngle) &&
			NullableEquals(x.ThumbMCPThumbIPDominantBoneFinalAngle, y.ThumbMCPThumbIPDominantBoneFinalAngle) &&
			NullableEquals(x.ThumbMCPThumbIPDominantBoneMeanAngle, y.ThumbMCPThumbIPDominantBoneMeanAngle) &&
			NullableEquals(x.ThumbMCPThumbIPDominantBoneMaximumAngle, y.ThumbMCPThumbIPDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbIPThumbTIPDominantBone bone features
			NullableEquals(x.ThumbIPThumbTIPDominantBoneInitialAngle, y.ThumbIPThumbTIPDominantBoneInitialAngle) &&
			NullableEquals(x.ThumbIPThumbTIPDominantBoneFinalAngle, y.ThumbIPThumbTIPDominantBoneFinalAngle) &&
			NullableEquals(x.ThumbIPThumbTIPDominantBoneMeanAngle, y.ThumbIPThumbTIPDominantBoneMeanAngle) &&
			NullableEquals(x.ThumbIPThumbTIPDominantBoneMaximumAngle, y.ThumbIPThumbTIPDominantBoneMaximumAngle) &&
			#endregion

			#region WristIndexFingerMCPDominantBone bone features
			NullableEquals(x.WristIndexFingerMCPDominantBoneInitialAngle, y.WristIndexFingerMCPDominantBoneInitialAngle) &&
			NullableEquals(x.WristIndexFingerMCPDominantBoneFinalAngle, y.WristIndexFingerMCPDominantBoneFinalAngle) &&
			NullableEquals(x.WristIndexFingerMCPDominantBoneMeanAngle, y.WristIndexFingerMCPDominantBoneMeanAngle) &&
			NullableEquals(x.WristIndexFingerMCPDominantBoneMaximumAngle, y.WristIndexFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPIndexFingerPIPDominantBone bone features
			NullableEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle, y.IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerPIPIndexFingerDIPDominantBone bone features
			NullableEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle, y.IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerDIPIndexFingerTIPDominantBone bone features
			NullableEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle, y.IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPDominantBone bone features
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle, y.MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPDominantBone bone features
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle, y.MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPDominantBone bone features
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle, y.MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPRingFingerPIPDominantBone bone features
			NullableEquals(x.RingFingerMCPRingFingerPIPDominantBoneInitialAngle, y.RingFingerMCPRingFingerPIPDominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerMCPRingFingerPIPDominantBoneFinalAngle, y.RingFingerMCPRingFingerPIPDominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerMCPRingFingerPIPDominantBoneMeanAngle, y.RingFingerMCPRingFingerPIPDominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle, y.RingFingerMCPRingFingerPIPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerPIPRingFingerDIPDominantBone bone features
			NullableEquals(x.RingFingerPIPRingFingerDIPDominantBoneInitialAngle, y.RingFingerPIPRingFingerDIPDominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerPIPRingFingerDIPDominantBoneFinalAngle, y.RingFingerPIPRingFingerDIPDominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerPIPRingFingerDIPDominantBoneMeanAngle, y.RingFingerPIPRingFingerDIPDominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle, y.RingFingerPIPRingFingerDIPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerDIPRingFingerTIPDominantBone bone features
			NullableEquals(x.RingFingerDIPRingFingerTIPDominantBoneInitialAngle, y.RingFingerDIPRingFingerTIPDominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerDIPRingFingerTIPDominantBoneFinalAngle, y.RingFingerDIPRingFingerTIPDominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerDIPRingFingerTIPDominantBoneMeanAngle, y.RingFingerDIPRingFingerTIPDominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle, y.RingFingerDIPRingFingerTIPDominantBoneMaximumAngle) &&
			#endregion

			#region WristPinkyMCPDominantBone bone features
			NullableEquals(x.WristPinkyMCPDominantBoneInitialAngle, y.WristPinkyMCPDominantBoneInitialAngle) &&
			NullableEquals(x.WristPinkyMCPDominantBoneFinalAngle, y.WristPinkyMCPDominantBoneFinalAngle) &&
			NullableEquals(x.WristPinkyMCPDominantBoneMeanAngle, y.WristPinkyMCPDominantBoneMeanAngle) &&
			NullableEquals(x.WristPinkyMCPDominantBoneMaximumAngle, y.WristPinkyMCPDominantBoneMaximumAngle) &&
			#endregion

			#region PinkyMCPPinkyPIPDominantBone bone features
			NullableEquals(x.PinkyMCPPinkyPIPDominantBoneInitialAngle, y.PinkyMCPPinkyPIPDominantBoneInitialAngle) &&
			NullableEquals(x.PinkyMCPPinkyPIPDominantBoneFinalAngle, y.PinkyMCPPinkyPIPDominantBoneFinalAngle) &&
			NullableEquals(x.PinkyMCPPinkyPIPDominantBoneMeanAngle, y.PinkyMCPPinkyPIPDominantBoneMeanAngle) &&
			NullableEquals(x.PinkyMCPPinkyPIPDominantBoneMaximumAngle, y.PinkyMCPPinkyPIPDominantBoneMaximumAngle) &&
			#endregion

			#region PinkyPIPPinkyDIPDominantBone bone features
			NullableEquals(x.PinkyPIPPinkyDIPDominantBoneInitialAngle, y.PinkyPIPPinkyDIPDominantBoneInitialAngle) &&
			NullableEquals(x.PinkyPIPPinkyDIPDominantBoneFinalAngle, y.PinkyPIPPinkyDIPDominantBoneFinalAngle) &&
			NullableEquals(x.PinkyPIPPinkyDIPDominantBoneMeanAngle, y.PinkyPIPPinkyDIPDominantBoneMeanAngle) &&
			NullableEquals(x.PinkyPIPPinkyDIPDominantBoneMaximumAngle, y.PinkyPIPPinkyDIPDominantBoneMaximumAngle) &&
			#endregion

			#region PinkyDIPPinkyTIPDominantBone bone features
			NullableEquals(x.PinkyDIPPinkyTIPDominantBoneInitialAngle, y.PinkyDIPPinkyTIPDominantBoneInitialAngle) &&
			NullableEquals(x.PinkyDIPPinkyTIPDominantBoneFinalAngle, y.PinkyDIPPinkyTIPDominantBoneFinalAngle) &&
			NullableEquals(x.PinkyDIPPinkyTIPDominantBoneMeanAngle, y.PinkyDIPPinkyTIPDominantBoneMeanAngle) &&
			NullableEquals(x.PinkyDIPPinkyTIPDominantBoneMaximumAngle, y.PinkyDIPPinkyTIPDominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPIndexFingerMCPDominantBone bone features
			NullableEquals(x.ThumbMCPIndexFingerMCPDominantBoneInitialAngle, y.ThumbMCPIndexFingerMCPDominantBoneInitialAngle) &&
			NullableEquals(x.ThumbMCPIndexFingerMCPDominantBoneFinalAngle, y.ThumbMCPIndexFingerMCPDominantBoneFinalAngle) &&
			NullableEquals(x.ThumbMCPIndexFingerMCPDominantBoneMeanAngle, y.ThumbMCPIndexFingerMCPDominantBoneMeanAngle) &&
			NullableEquals(x.ThumbMCPIndexFingerMCPDominantBoneMaximumAngle, y.ThumbMCPIndexFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPMiddleFingerMCPDominantBone bone features
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle, y.IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPRingFingerMCPDominantBone bone features
			NullableEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle, y.MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPPinkyMCPDominantBone bone features
			NullableEquals(x.RingFingerMCPPinkyMCPDominantBoneInitialAngle, y.RingFingerMCPPinkyMCPDominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerMCPPinkyMCPDominantBoneFinalAngle, y.RingFingerMCPPinkyMCPDominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerMCPPinkyMCPDominantBoneMeanAngle, y.RingFingerMCPPinkyMCPDominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerMCPPinkyMCPDominantBoneMaximumAngle, y.RingFingerMCPPinkyMCPDominantBoneMaximumAngle) &&
			#endregion

			#region WristThumbCMCNondominantBone bone features
			NullableEquals(x.WristThumbCMCNondominantBoneInitialAngle, y.WristThumbCMCNondominantBoneInitialAngle) &&
			NullableEquals(x.WristThumbCMCNondominantBoneFinalAngle, y.WristThumbCMCNondominantBoneFinalAngle) &&
			NullableEquals(x.WristThumbCMCNondominantBoneMeanAngle, y.WristThumbCMCNondominantBoneMeanAngle) &&
			NullableEquals(x.WristThumbCMCNondominantBoneMaximumAngle, y.WristThumbCMCNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbCMCThumbMCPNondominantBone bone features
			NullableEquals(x.ThumbCMCThumbMCPNondominantBoneInitialAngle, y.ThumbCMCThumbMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.ThumbCMCThumbMCPNondominantBoneFinalAngle, y.ThumbCMCThumbMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.ThumbCMCThumbMCPNondominantBoneMeanAngle, y.ThumbCMCThumbMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.ThumbCMCThumbMCPNondominantBoneMaximumAngle, y.ThumbCMCThumbMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPThumbIPNondominantBone bone features
			NullableEquals(x.ThumbMCPThumbIPNondominantBoneInitialAngle, y.ThumbMCPThumbIPNondominantBoneInitialAngle) &&
			NullableEquals(x.ThumbMCPThumbIPNondominantBoneFinalAngle, y.ThumbMCPThumbIPNondominantBoneFinalAngle) &&
			NullableEquals(x.ThumbMCPThumbIPNondominantBoneMeanAngle, y.ThumbMCPThumbIPNondominantBoneMeanAngle) &&
			NullableEquals(x.ThumbMCPThumbIPNondominantBoneMaximumAngle, y.ThumbMCPThumbIPNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbIPThumbTIPNondominantBone bone features
			NullableEquals(x.ThumbIPThumbTIPNondominantBoneInitialAngle, y.ThumbIPThumbTIPNondominantBoneInitialAngle) &&
			NullableEquals(x.ThumbIPThumbTIPNondominantBoneFinalAngle, y.ThumbIPThumbTIPNondominantBoneFinalAngle) &&
			NullableEquals(x.ThumbIPThumbTIPNondominantBoneMeanAngle, y.ThumbIPThumbTIPNondominantBoneMeanAngle) &&
			NullableEquals(x.ThumbIPThumbTIPNondominantBoneMaximumAngle, y.ThumbIPThumbTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region WristIndexFingerMCPNondominantBone bone features
			NullableEquals(x.WristIndexFingerMCPNondominantBoneInitialAngle, y.WristIndexFingerMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.WristIndexFingerMCPNondominantBoneFinalAngle, y.WristIndexFingerMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.WristIndexFingerMCPNondominantBoneMeanAngle, y.WristIndexFingerMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.WristIndexFingerMCPNondominantBoneMaximumAngle, y.WristIndexFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPIndexFingerPIPNondominantBone bone features
			NullableEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle, y.IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerPIPIndexFingerDIPNondominantBone bone features
			NullableEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle, y.IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerDIPIndexFingerTIPNondominantBone bone features
			NullableEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle, y.IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPMiddleFingerPIPNondominantBone bone features
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle, y.MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerPIPMiddleFingerDIPNondominantBone bone features
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle, y.MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerDIPMiddleFingerTIPNondominantBone bone features
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle, y.MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPRingFingerPIPNondominantBone bone features
			NullableEquals(x.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle, y.RingFingerMCPRingFingerPIPNondominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle, y.RingFingerMCPRingFingerPIPNondominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle, y.RingFingerMCPRingFingerPIPNondominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle, y.RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerPIPRingFingerDIPNondominantBone bone features
			NullableEquals(x.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle, y.RingFingerPIPRingFingerDIPNondominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle, y.RingFingerPIPRingFingerDIPNondominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle, y.RingFingerPIPRingFingerDIPNondominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle, y.RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerDIPRingFingerTIPNondominantBone bone features
			NullableEquals(x.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle, y.RingFingerDIPRingFingerTIPNondominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle, y.RingFingerDIPRingFingerTIPNondominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle, y.RingFingerDIPRingFingerTIPNondominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle, y.RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region WristPinkyMCPNondominantBone bone features
			NullableEquals(x.WristPinkyMCPNondominantBoneInitialAngle, y.WristPinkyMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.WristPinkyMCPNondominantBoneFinalAngle, y.WristPinkyMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.WristPinkyMCPNondominantBoneMeanAngle, y.WristPinkyMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.WristPinkyMCPNondominantBoneMaximumAngle, y.WristPinkyMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region PinkyMCPPinkyPIPNondominantBone bone features
			NullableEquals(x.PinkyMCPPinkyPIPNondominantBoneInitialAngle, y.PinkyMCPPinkyPIPNondominantBoneInitialAngle) &&
			NullableEquals(x.PinkyMCPPinkyPIPNondominantBoneFinalAngle, y.PinkyMCPPinkyPIPNondominantBoneFinalAngle) &&
			NullableEquals(x.PinkyMCPPinkyPIPNondominantBoneMeanAngle, y.PinkyMCPPinkyPIPNondominantBoneMeanAngle) &&
			NullableEquals(x.PinkyMCPPinkyPIPNondominantBoneMaximumAngle, y.PinkyMCPPinkyPIPNondominantBoneMaximumAngle) &&
			#endregion

			#region PinkyPIPPinkyDIPNondominantBone bone features
			NullableEquals(x.PinkyPIPPinkyDIPNondominantBoneInitialAngle, y.PinkyPIPPinkyDIPNondominantBoneInitialAngle) &&
			NullableEquals(x.PinkyPIPPinkyDIPNondominantBoneFinalAngle, y.PinkyPIPPinkyDIPNondominantBoneFinalAngle) &&
			NullableEquals(x.PinkyPIPPinkyDIPNondominantBoneMeanAngle, y.PinkyPIPPinkyDIPNondominantBoneMeanAngle) &&
			NullableEquals(x.PinkyPIPPinkyDIPNondominantBoneMaximumAngle, y.PinkyPIPPinkyDIPNondominantBoneMaximumAngle) &&
			#endregion

			#region PinkyDIPPinkyTIPNondominantBone bone features
			NullableEquals(x.PinkyDIPPinkyTIPNondominantBoneInitialAngle, y.PinkyDIPPinkyTIPNondominantBoneInitialAngle) &&
			NullableEquals(x.PinkyDIPPinkyTIPNondominantBoneFinalAngle, y.PinkyDIPPinkyTIPNondominantBoneFinalAngle) &&
			NullableEquals(x.PinkyDIPPinkyTIPNondominantBoneMeanAngle, y.PinkyDIPPinkyTIPNondominantBoneMeanAngle) &&
			NullableEquals(x.PinkyDIPPinkyTIPNondominantBoneMaximumAngle, y.PinkyDIPPinkyTIPNondominantBoneMaximumAngle) &&
			#endregion

			#region ThumbMCPIndexFingerMCPNondominantBone bone features
			NullableEquals(x.ThumbMCPIndexFingerMCPNondominantBoneInitialAngle, y.ThumbMCPIndexFingerMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.ThumbMCPIndexFingerMCPNondominantBoneFinalAngle, y.ThumbMCPIndexFingerMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.ThumbMCPIndexFingerMCPNondominantBoneMeanAngle, y.ThumbMCPIndexFingerMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle, y.ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region IndexFingerMCPMiddleFingerMCPNondominantBone bone features
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle, y.IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region MiddleFingerMCPRingFingerMCPNondominantBone bone features
			NullableEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle, y.MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region RingFingerMCPPinkyMCPNondominantBone bone features
			NullableEquals(x.RingFingerMCPPinkyMCPNondominantBoneInitialAngle, y.RingFingerMCPPinkyMCPNondominantBoneInitialAngle) &&
			NullableEquals(x.RingFingerMCPPinkyMCPNondominantBoneFinalAngle, y.RingFingerMCPPinkyMCPNondominantBoneFinalAngle) &&
			NullableEquals(x.RingFingerMCPPinkyMCPNondominantBoneMeanAngle, y.RingFingerMCPPinkyMCPNondominantBoneMeanAngle) &&
			NullableEquals(x.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle, y.RingFingerMCPPinkyMCPNondominantBoneMaximumAngle) &&
			#endregion

			#region Hands distances features
			NullableEquals(x.BetweenHandJointsDistanceMax, y.BetweenHandJointsDistanceMax) &&
			NullableEquals(x.BetweenHandJointsDistanceMean, y.BetweenHandJointsDistanceMean) &&
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
