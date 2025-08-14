//using System;
//using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

//namespace GestureRecognition.Processing.GestureRecognitionProcUnit.Models.TGM1
//{
//	public static class Mapper
//	{
//		#region Public methods
//		public static TGM1.ModelInput MapToModelInput(this KinectGestureDataView data)
//		{
//			if (data == null)
//				return null;

//			return new TGM1.ModelInput()
//			{
//				#region ElbowRight joint features
//				ElbowRightF1F2SpatialAngle = data.ElbowRightF1F2SpatialAngle,
//				ElbowRightFN_1FNSpatialAngle = data.ElbowRightFN_1FNSpatialAngle,
//				ElbowRightF1FNSpatialAngle = data.ElbowRightF1FNSpatialAngle,
//				ElbowRightTotalVectorAngle = data.ElbowRightTotalVectorAngle,
//				ElbowRightSquaredTotalVectorAngle = data.ElbowRightSquaredTotalVectorAngle,
//				ElbowRightTotalVectorDisplacement = data.ElbowRightTotalVectorDisplacement,
//				ElbowRightTotalDisplacement = data.ElbowRightTotalDisplacement,
//				ElbowRightMaximumDisplacement = data.ElbowRightMaximumDisplacement,
//				#endregion

//				#region WristRight joint features
//				WristRightF1F2SpatialAngle = data.WristRightF1F2SpatialAngle,
//				WristRightFN_1FNSpatialAngle = data.WristRightFN_1FNSpatialAngle,
//				WristRightF1FNSpatialAngle = data.WristRightF1FNSpatialAngle,
//				WristRightTotalVectorAngle = data.WristRightTotalVectorAngle,
//				WristRightSquaredTotalVectorAngle = data.WristRightSquaredTotalVectorAngle,
//				WristRightTotalVectorDisplacement = data.WristRightTotalVectorDisplacement,
//				WristRightTotalDisplacement = data.WristRightTotalDisplacement,
//				WristRightMaximumDisplacement = data.WristRightMaximumDisplacement,
//				#endregion

//				#region HandRight joint features
//				HandRightF1F2SpatialAngle = data.HandRightF1F2SpatialAngle,
//				HandRightFN_1FNSpatialAngle = data.HandRightFN_1FNSpatialAngle,
//				HandRightF1FNSpatialAngle = data.HandRightF1FNSpatialAngle,
//				HandRightTotalVectorAngle = data.HandRightTotalVectorAngle,
//				HandRightSquaredTotalVectorAngle = data.HandRightSquaredTotalVectorAngle,
//				HandRightTotalVectorDisplacement = data.HandRightTotalVectorDisplacement,
//				HandRightTotalDisplacement = data.HandRightTotalDisplacement,
//				HandRightMaximumDisplacement = data.HandRightMaximumDisplacement,
//				HandRightBoundingBoxDiagonalLength = data.HandRightBoundingBoxDiagonalLength,
//				HandRightBoundingBoxAngle = data.HandRightBoundingBoxAngle,
//				#endregion

//				#region ThumbRight joint features
//				ThumbRightF1F2SpatialAngle = data.ThumbRightF1F2SpatialAngle,
//				ThumbRightFN_1FNSpatialAngle = data.ThumbRightFN_1FNSpatialAngle,
//				ThumbRightF1FNSpatialAngle = data.ThumbRightF1FNSpatialAngle,
//				ThumbRightTotalVectorAngle = data.ThumbRightTotalVectorAngle,
//				ThumbRightSquaredTotalVectorAngle = data.ThumbRightSquaredTotalVectorAngle,
//				ThumbRightTotalVectorDisplacement = data.ThumbRightTotalVectorDisplacement,
//				ThumbRightTotalDisplacement = data.ThumbRightTotalDisplacement,
//				ThumbRightMaximumDisplacement = data.ThumbRightMaximumDisplacement,
//				#endregion

//				#region HandTipRight joint features
//				HandTipRightF1F2SpatialAngle = data.HandTipRightF1F2SpatialAngle,
//				HandTipRightFN_1FNSpatialAngle = data.HandTipRightFN_1FNSpatialAngle,
//				HandTipRightF1FNSpatialAngle = data.HandTipRightF1FNSpatialAngle,
//				HandTipRightTotalVectorAngle = data.HandTipRightTotalVectorAngle,
//				HandTipRightSquaredTotalVectorAngle = data.HandTipRightSquaredTotalVectorAngle,
//				HandTipRightTotalVectorDisplacement = data.HandTipRightTotalVectorDisplacement,
//				HandTipRightTotalDisplacement = data.HandTipRightTotalDisplacement,
//				HandTipRightMaximumDisplacement = data.HandTipRightMaximumDisplacement,
//				#endregion

//				#region ElbowRightWristRight bone features
//				ElbowRightWristRightBoneInitialAngle = data.ElbowRightWristRightBoneInitialAngle,
//				ElbowRightWristRightBoneFinalAngle = data.ElbowRightWristRightBoneFinalAngle,
//				ElbowRightWristRightBoneMeanAngle = data.ElbowRightWristRightBoneMeanAngle,
//				ElbowRightWristRightBoneMaximumAngle = data.ElbowRightWristRightBoneMaximumAngle,
//				#endregion

//				#region WristRightHandRight bone features
//				WristRightHandRightBoneInitialAngle = data.WristRightHandRightBoneInitialAngle,
//				WristRightHandRightBoneFinalAngle = data.WristRightHandRightBoneFinalAngle,
//				WristRightHandRightBoneMeanAngle = data.WristRightHandRightBoneMeanAngle,
//				WristRightHandRightBoneMaximumAngle = data.WristRightHandRightBoneMaximumAngle,
//				#endregion

//				#region HandRightHandTipRight bone features
//				HandRightHandTipRightBoneInitialAngle = data.HandRightHandTipRightBoneInitialAngle,
//				HandRightHandTipRightBoneFinalAngle = data.HandRightHandTipRightBoneFinalAngle,
//				HandRightHandTipRightBoneMeanAngle = data.HandRightHandTipRightBoneMeanAngle,
//				HandRightHandTipRightBoneMaximumAngle = data.HandRightHandTipRightBoneMaximumAngle,
//				#endregion
//			};
//		}
//		#endregion

//		#region Private methods
//		private static float MapToFloat(this double? val)
//		{
//			if (val == null)
//				return float.NaN;

//			return Convert.ToSingle(val.Value);
//		}
//		#endregion
//	}
//}
