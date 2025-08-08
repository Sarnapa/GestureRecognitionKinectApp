using System;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

namespace GestureRecognition.Processing.GestureRecognitionProcUnit.Models.TGM1
{
	public static class Mapper
	{
		#region Public methods
		public static TGM1.ModelInput MapToModelInput(this KinectGestureDataView data)
		{
			if (data == null)
				return null;

			return new TGM1.ModelInput()
			{
				#region ElbowRight joint features
				ElbowRightF1F2SpatialAngle = data.ElbowRightF1F2SpatialAngle.MapToFloat(),
				ElbowRightFN_1FNSpatialAngle = data.ElbowRightFN_1FNSpatialAngle.MapToFloat(),
				ElbowRightF1FNSpatialAngle = data.ElbowRightF1FNSpatialAngle.MapToFloat(),
				ElbowRightTotalVectorAngle = data.ElbowRightTotalVectorAngle.MapToFloat(),
				ElbowRightSquaredTotalVectorAngle = data.ElbowRightSquaredTotalVectorAngle.MapToFloat(),
				ElbowRightTotalVectorDisplacement = data.ElbowRightTotalVectorDisplacement.MapToFloat(),
				ElbowRightTotalDisplacement = data.ElbowRightTotalDisplacement.MapToFloat(),
				ElbowRightMaximumDisplacement = data.ElbowRightMaximumDisplacement.MapToFloat(),
				#endregion

				#region WristRight joint features
				WristRightF1F2SpatialAngle = data.WristRightF1F2SpatialAngle.MapToFloat(),
				WristRightFN_1FNSpatialAngle = data.WristRightFN_1FNSpatialAngle.MapToFloat(),
				WristRightF1FNSpatialAngle = data.WristRightF1FNSpatialAngle.MapToFloat(),
				WristRightTotalVectorAngle = data.WristRightTotalVectorAngle.MapToFloat(),
				WristRightSquaredTotalVectorAngle = data.WristRightSquaredTotalVectorAngle.MapToFloat(),
				WristRightTotalVectorDisplacement = data.WristRightTotalVectorDisplacement.MapToFloat(),
				WristRightTotalDisplacement = data.WristRightTotalDisplacement.MapToFloat(),
				WristRightMaximumDisplacement = data.WristRightMaximumDisplacement.MapToFloat(),
				#endregion

				#region HandRight joint features
				HandRightF1F2SpatialAngle = data.HandRightF1F2SpatialAngle.MapToFloat(),
				HandRightFN_1FNSpatialAngle = data.HandRightFN_1FNSpatialAngle.MapToFloat(),
				HandRightF1FNSpatialAngle = data.HandRightF1FNSpatialAngle.MapToFloat(),
				HandRightTotalVectorAngle = data.HandRightTotalVectorAngle.MapToFloat(),
				HandRightSquaredTotalVectorAngle = data.HandRightSquaredTotalVectorAngle.MapToFloat(),
				HandRightTotalVectorDisplacement = data.HandRightTotalVectorDisplacement.MapToFloat(),
				HandRightTotalDisplacement = data.HandRightTotalDisplacement.MapToFloat(),
				HandRightMaximumDisplacement = data.HandRightMaximumDisplacement.MapToFloat(),
				HandRightBoundingBoxDiagonalLength = data.HandRightBoundingBoxDiagonalLength.MapToFloat(),
				HandRightBoundingBoxAngle = data.HandRightBoundingBoxAngle.MapToFloat(),
				#endregion

				#region ThumbRight joint features
				ThumbRightF1F2SpatialAngle = data.ThumbRightF1F2SpatialAngle.MapToFloat(),
				ThumbRightFN_1FNSpatialAngle = data.ThumbRightFN_1FNSpatialAngle.MapToFloat(),
				ThumbRightF1FNSpatialAngle = data.ThumbRightF1FNSpatialAngle.MapToFloat(),
				ThumbRightTotalVectorAngle = data.ThumbRightTotalVectorAngle.MapToFloat(),
				ThumbRightSquaredTotalVectorAngle = data.ThumbRightSquaredTotalVectorAngle.MapToFloat(),
				ThumbRightTotalVectorDisplacement = data.ThumbRightTotalVectorDisplacement.MapToFloat(),
				ThumbRightTotalDisplacement = data.ThumbRightTotalDisplacement.MapToFloat(),
				ThumbRightMaximumDisplacement = data.ThumbRightMaximumDisplacement.MapToFloat(),
				#endregion

				#region HandTipRight joint features
				HandTipRightF1F2SpatialAngle = data.HandTipRightF1F2SpatialAngle.MapToFloat(),
				HandTipRightFN_1FNSpatialAngle = data.HandTipRightFN_1FNSpatialAngle.MapToFloat(),
				HandTipRightF1FNSpatialAngle = data.HandTipRightF1FNSpatialAngle.MapToFloat(),
				HandTipRightTotalVectorAngle = data.HandTipRightTotalVectorAngle.MapToFloat(),
				HandTipRightSquaredTotalVectorAngle = data.HandTipRightSquaredTotalVectorAngle.MapToFloat(),
				HandTipRightTotalVectorDisplacement = data.HandTipRightTotalVectorDisplacement.MapToFloat(),
				HandTipRightTotalDisplacement = data.HandTipRightTotalDisplacement.MapToFloat(),
				HandTipRightMaximumDisplacement = data.HandTipRightMaximumDisplacement.MapToFloat(),
				#endregion

				#region ElbowRightWristRight bone features
				ElbowRightWristRightBoneInitialAngle = data.ElbowRightWristRightBoneInitialAngle.MapToFloat(),
				ElbowRightWristRightBoneFinalAngle = data.ElbowRightWristRightBoneFinalAngle.MapToFloat(),
				ElbowRightWristRightBoneMeanAngle = data.ElbowRightWristRightBoneMeanAngle.MapToFloat(),
				ElbowRightWristRightBoneMaximumAngle = data.ElbowRightWristRightBoneMaximumAngle.MapToFloat(),
				#endregion

				#region WristRightHandRight bone features
				WristRightHandRightBoneInitialAngle = data.WristRightHandRightBoneInitialAngle.MapToFloat(),
				WristRightHandRightBoneFinalAngle = data.WristRightHandRightBoneFinalAngle.MapToFloat(),
				WristRightHandRightBoneMeanAngle = data.WristRightHandRightBoneMeanAngle.MapToFloat(),
				WristRightHandRightBoneMaximumAngle = data.WristRightHandRightBoneMaximumAngle.MapToFloat(),
				#endregion

				#region HandRightHandTipRight bone features
				HandRightHandTipRightBoneInitialAngle = data.HandRightHandTipRightBoneInitialAngle.MapToFloat(),
				HandRightHandTipRightBoneFinalAngle = data.HandRightHandTipRightBoneFinalAngle.MapToFloat(),
				HandRightHandTipRightBoneMeanAngle = data.HandRightHandTipRightBoneMeanAngle.MapToFloat(),
				HandRightHandTipRightBoneMaximumAngle = data.HandRightHandTipRightBoneMaximumAngle.MapToFloat(),
				#endregion
			};
		}
		#endregion

		#region Private methods
		private static float MapToFloat(this double? val)
		{
			if (val == null)
				return float.NaN;

			return Convert.ToSingle(val.Value);
		}
		#endregion
	}
}
