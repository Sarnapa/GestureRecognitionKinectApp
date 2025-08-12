using Microsoft.ML.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews
{
	public class MediaPipeHandLandmarksGestureDataView: GestureDataView
	{
		#region WristDominant joint features
		public float WristDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float WristDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float WristDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float WristDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float WristDominantTotalDisplacement
		{
			get;
			set;
		}

		public float WristDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbCMCDominant joint features
		public float ThumbCMCDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbCMCDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbCMCDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbCMCDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbCMCDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbCMCDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbCMCDominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbCMCDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbMCPDominant joint features
		public float ThumbMCPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbMCPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbMCPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbMCPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbMCPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbMCPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbMCPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbMCPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbIPDominant joint features
		public float ThumbIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbTIPDominant joint features
		public float ThumbTIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbTIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbTIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbTIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbTIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbTIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbTIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbTIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerMCPDominant joint features
		public float IndexFingerMCPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerMCPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerPIPDominant joint features
		public float IndexFingerPIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerPIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerDIPDominant joint features
		public float IndexFingerDIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerDIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerTIPDominant joint features
		public float IndexFingerTIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerTIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerMCPDominant joint features
		public float MiddleFingerMCPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerMCPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerPIPDominant joint features
		public float MiddleFingerPIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerPIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerDIPDominant joint features
		public float MiddleFingerDIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerDIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerTIPDominant joint features
		public float MiddleFingerTIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerTIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerMCPDominant joint features
		public float RingFingerMCPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerMCPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerMCPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerMCPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerMCPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerPIPDominant joint features
		public float RingFingerPIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerPIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerPIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerPIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerPIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerDIPDominant joint features
		public float RingFingerDIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerDIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerDIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerDIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerDIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerTIPDominant joint features
		public float RingFingerTIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerTIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerTIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerTIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerTIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerTIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerTIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerTIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyMCPDominant joint features
		public float PinkyMCPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyMCPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyMCPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyMCPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyMCPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyMCPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyMCPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyMCPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyPIPDominant joint features
		public float PinkyPIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyPIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyPIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyPIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyPIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyPIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyPIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyPIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyDIPDominant joint features
		public float PinkyDIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyDIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyDIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyDIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyDIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyDIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyDIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyDIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyTIPDominant joint features
		public float PinkyTIPDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyTIPDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyTIPDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyTIPDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyTIPDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyTIPDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyTIPDominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyTIPDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandDominant joint features
		public float HandDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float HandDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandDominantTotalDisplacement
		{
			get;
			set;
		}

		public float HandDominantMaximumDisplacement
		{
			get;
			set;
		}

		public float HandDominantBoundingBoxDiagonalLength
		{
			get;
			set;
		}

		public float HandDominantBoundingBoxAngle
		{
			get;
			set;
		}

		// Turned off for now, if the results are not satisfactory then turn it on
		//public HandState[] HandDominantHandStates
		//{
		//	get;
		//	set;
		//}
		#endregion

		#region WristNondominant joint features
		public float WristNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float WristNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float WristNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float WristNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float WristNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float WristNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbCMCNondominant joint features
		public float ThumbCMCNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbCMCNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbCMCNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbCMCNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbCMCNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbCMCNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbCMCNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbCMCNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbMCPNondominant joint features
		public float ThumbMCPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbMCPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbMCPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbMCPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbMCPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbMCPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbMCPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbMCPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbIPNondominant joint features
		public float ThumbIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbTIPNondominant joint features
		public float ThumbTIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbTIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbTIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbTIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbTIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbTIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbTIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbTIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerMCPNondominant joint features
		public float IndexFingerMCPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerMCPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerPIPNondominant joint features
		public float IndexFingerPIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerPIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerDIPNondominant joint features
		public float IndexFingerDIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerDIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerTIPNondominant joint features
		public float IndexFingerTIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float IndexFingerTIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerMCPNondominant joint features
		public float MiddleFingerMCPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerMCPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerPIPNondominant joint features
		public float MiddleFingerPIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerPIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerDIPNondominant joint features
		public float MiddleFingerDIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerDIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerTIPNondominant joint features
		public float MiddleFingerTIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float MiddleFingerTIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerMCPNondominant joint features
		public float RingFingerMCPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerMCPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerPIPNondominant joint features
		public float RingFingerPIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerPIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerDIPNondominant joint features
		public float RingFingerDIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerDIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region RingFingerTIPNondominant joint features
		public float RingFingerTIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float RingFingerTIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyMCPNondominant joint features
		public float PinkyMCPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyMCPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyMCPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyMCPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyMCPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyMCPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyMCPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyMCPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyPIPNondominant joint features
		public float PinkyPIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyPIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyPIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyPIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyPIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyPIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyPIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyPIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyDIPNondominant joint features
		public float PinkyDIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyDIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyDIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyDIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyDIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyDIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyDIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyDIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region PinkyTIPNondominant joint features
		public float PinkyTIPNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float PinkyTIPNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyTIPNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float PinkyTIPNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyTIPNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float PinkyTIPNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float PinkyTIPNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float PinkyTIPNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandNondominant joint features
		public float HandNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float HandNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float HandNondominantMaximumDisplacement
		{
			get;
			set;
		}

		public float HandNondominantBoundingBoxDiagonalLength
		{
			get;
			set;
		}

		public float HandNondominantBoundingBoxAngle
		{
			get;
			set;
		}

		// Turned off for now, if the results are not satisfactory then turn it on
		//public HandState[] HandNondominantHandStates
		//{
		//	get;
		//	set;
		//}
		#endregion

		#region WristThumbCMCDominantBone bone features
		public float WristThumbCMCDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristThumbCMCDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristThumbCMCDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristThumbCMCDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbCMCThumbMCPDominantBone bone features
		public float ThumbCMCThumbMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbCMCThumbMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbCMCThumbMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbCMCThumbMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbMCPThumbIPDominantBone bone features
		public float ThumbMCPThumbIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbMCPThumbIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbMCPThumbIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbMCPThumbIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbIPThumbTIPDominantBone bone features
		public float ThumbIPThumbTIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbIPThumbTIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbIPThumbTIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbIPThumbTIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristIndexFingerMCPDominantBone bone features
		public float WristIndexFingerMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristIndexFingerMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristIndexFingerMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristIndexFingerMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerMCPIndexFingerPIPDominantBone bone features
		public float IndexFingerMCPIndexFingerPIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPIndexFingerPIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPIndexFingerPIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPIndexFingerPIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerPIPIndexFingerDIPDominantBone bone features
		public float IndexFingerPIPIndexFingerDIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPIndexFingerDIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPIndexFingerDIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPIndexFingerDIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerDIPIndexFingerTIPDominantBone bone features
		public float IndexFingerDIPIndexFingerTIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPIndexFingerTIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPIndexFingerTIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPIndexFingerTIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerMCPMiddleFingerPIPDominantBone bone features
		public float MiddleFingerMCPMiddleFingerPIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPMiddleFingerPIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPMiddleFingerPIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPMiddleFingerPIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerPIPMiddleFingerDIPDominantBone bone features
		public float MiddleFingerPIPMiddleFingerDIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPMiddleFingerDIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPMiddleFingerDIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPMiddleFingerDIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerDIPMiddleFingerTIPDominantBone bone features
		public float MiddleFingerDIPMiddleFingerTIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPMiddleFingerTIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPMiddleFingerTIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPMiddleFingerTIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerMCPRingFingerPIPDominantBone bone features
		public float RingFingerMCPRingFingerPIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPRingFingerPIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerMCPRingFingerPIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerMCPRingFingerPIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerPIPRingFingerDIPDominantBone bone features
		public float RingFingerPIPRingFingerDIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPRingFingerDIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerPIPRingFingerDIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerPIPRingFingerDIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerDIPRingFingerTIPDominantBone bone features
		public float RingFingerDIPRingFingerTIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPRingFingerTIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerDIPRingFingerTIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerDIPRingFingerTIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristPinkyMCPDominantBone bone features
		public float WristPinkyMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristPinkyMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristPinkyMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristPinkyMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region PinkyMCPPinkyPIPDominantBone bone features
		public float PinkyMCPPinkyPIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float PinkyMCPPinkyPIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float PinkyMCPPinkyPIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float PinkyMCPPinkyPIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region PinkyPIPPinkyDIPDominantBone bone features
		public float PinkyPIPPinkyDIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float PinkyPIPPinkyDIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float PinkyPIPPinkyDIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float PinkyPIPPinkyDIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region PinkyDIPPinkyTIPDominantBone bone features
		public float PinkyDIPPinkyTIPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float PinkyDIPPinkyTIPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float PinkyDIPPinkyTIPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float PinkyDIPPinkyTIPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbMCPIndexFingerMCPDominantBone bone features
		public float ThumbMCPIndexFingerMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbMCPIndexFingerMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbMCPIndexFingerMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbMCPIndexFingerMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerMCPMiddleFingerMCPDominantBone bone features
		public float IndexFingerMCPMiddleFingerMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPMiddleFingerMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPMiddleFingerMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPMiddleFingerMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerMCPRingFingerMCPDominantBone bone features
		public float MiddleFingerMCPRingFingerMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPRingFingerMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPRingFingerMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPRingFingerMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerMCPPinkyMCPDominantBone bone features
		public float RingFingerMCPPinkyMCPDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPPinkyMCPDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerMCPPinkyMCPDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerMCPPinkyMCPDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristThumbCMCNondominantBone bone features
		public float WristThumbCMCNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristThumbCMCNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristThumbCMCNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristThumbCMCNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbCMCThumbMCPNondominantBone bone features
		public float ThumbCMCThumbMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbCMCThumbMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbCMCThumbMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbCMCThumbMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbMCPThumbIPNondominantBone bone features
		public float ThumbMCPThumbIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbMCPThumbIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbMCPThumbIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbMCPThumbIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbIPThumbTIPNondominantBone bone features
		public float ThumbIPThumbTIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbIPThumbTIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbIPThumbTIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbIPThumbTIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristIndexFingerMCPNondominantBone bone features
		public float WristIndexFingerMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristIndexFingerMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristIndexFingerMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristIndexFingerMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerMCPIndexFingerPIPNondominantBone bone features
		public float IndexFingerMCPIndexFingerPIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPIndexFingerPIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPIndexFingerPIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPIndexFingerPIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerPIPIndexFingerDIPNondominantBone bone features
		public float IndexFingerPIPIndexFingerDIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPIndexFingerDIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPIndexFingerDIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerPIPIndexFingerDIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerDIPIndexFingerTIPNondominantBone bone features
		public float IndexFingerDIPIndexFingerTIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPIndexFingerTIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPIndexFingerTIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerDIPIndexFingerTIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerMCPMiddleFingerPIPNondominantBone bone features
		public float MiddleFingerMCPMiddleFingerPIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPMiddleFingerPIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPMiddleFingerPIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPMiddleFingerPIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerPIPMiddleFingerDIPNondominantBone bone features
		public float MiddleFingerPIPMiddleFingerDIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPMiddleFingerDIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPMiddleFingerDIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerPIPMiddleFingerDIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerDIPMiddleFingerTIPNondominantBone bone features
		public float MiddleFingerDIPMiddleFingerTIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPMiddleFingerTIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPMiddleFingerTIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerDIPMiddleFingerTIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerMCPRingFingerPIPNondominantBone bone features
		public float RingFingerMCPRingFingerPIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPRingFingerPIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerMCPRingFingerPIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerMCPRingFingerPIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerPIPRingFingerDIPNondominantBone bone features
		public float RingFingerPIPRingFingerDIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerPIPRingFingerDIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerPIPRingFingerDIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerPIPRingFingerDIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerDIPRingFingerTIPNondominantBone bone features
		public float RingFingerDIPRingFingerTIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerDIPRingFingerTIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerDIPRingFingerTIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerDIPRingFingerTIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristPinkyMCPNondominantBone bone features
		public float WristPinkyMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristPinkyMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristPinkyMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristPinkyMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region PinkyMCPPinkyPIPNondominantBone bone features
		public float PinkyMCPPinkyPIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float PinkyMCPPinkyPIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float PinkyMCPPinkyPIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float PinkyMCPPinkyPIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region PinkyPIPPinkyDIPNondominantBone bone features
		public float PinkyPIPPinkyDIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float PinkyPIPPinkyDIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float PinkyPIPPinkyDIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float PinkyPIPPinkyDIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region PinkyDIPPinkyTIPNondominantBone bone features
		public float PinkyDIPPinkyTIPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float PinkyDIPPinkyTIPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float PinkyDIPPinkyTIPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float PinkyDIPPinkyTIPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ThumbMCPIndexFingerMCPNondominantBone bone features
		public float ThumbMCPIndexFingerMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ThumbMCPIndexFingerMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ThumbMCPIndexFingerMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ThumbMCPIndexFingerMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region IndexFingerMCPMiddleFingerMCPNondominantBone bone features
		public float IndexFingerMCPMiddleFingerMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPMiddleFingerMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPMiddleFingerMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float IndexFingerMCPMiddleFingerMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region MiddleFingerMCPRingFingerMCPNondominantBone bone features
		public float MiddleFingerMCPRingFingerMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPRingFingerMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPRingFingerMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float MiddleFingerMCPRingFingerMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region RingFingerMCPPinkyMCPNondominantBone bone features
		public float RingFingerMCPPinkyMCPNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float RingFingerMCPPinkyMCPNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float RingFingerMCPPinkyMCPNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float RingFingerMCPPinkyMCPNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region Hands distances features
		public float BetweenHandJointsDistanceMax
		{
			get;
			set;
		}

		public float BetweenHandJointsDistanceMean
		{
			get;
			set;
		}
		#endregion

		#region HandDominance
		public int HandDominance
		{
			get;
			set;
		}
		#endregion

		#region Label
		public string Label
		{
			get;
			set;
		}
		#endregion
	}
}
