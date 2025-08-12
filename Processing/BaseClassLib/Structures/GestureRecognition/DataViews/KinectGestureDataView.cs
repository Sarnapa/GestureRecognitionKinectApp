using Microsoft.ML.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews
{
	// TODO: Problem, że tutaj podajemy na sztywno te cechy, żeby nowy dodać punkt charakterystyczny trzeba będzie podać tutaj na sztywno do kodu.
	public class KinectGestureDataView : GestureDataView
	{
		#region ElbowLeft joint features
		public float ElbowLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ElbowLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowLeftTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ElbowLeftTotalDisplacement
		{
			get;
			set;
		}

		public float ElbowLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ElbowRight joint features
		public float ElbowRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ElbowRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowRightTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ElbowRightTotalDisplacement
		{
			get;
			set;
		}

		public float ElbowRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region WristLeft joint features
		public float WristLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public float WristLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristLeftTotalVectorAngle
		{
			get;
			set;
		}

		public float WristLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float WristLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public float WristLeftTotalDisplacement
		{
			get;
			set;
		}

		public float WristLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region WristRight joint features
		public float WristRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public float WristRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public float WristRightTotalVectorAngle
		{
			get;
			set;
		}

		public float WristRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float WristRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public float WristRightTotalDisplacement
		{
			get;
			set;
		}

		public float WristRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandLeft joint features
		public float HandLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandLeftTotalVectorAngle
		{
			get;
			set;
		}

		public float HandLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandLeftTotalDisplacement
		{
			get;
			set;
		}

		public float HandLeftMaximumDisplacement
		{
			get;
			set;
		}

		public float HandLeftBoundingBoxDiagonalLength
		{
			get;
			set;
		}

		public float HandLeftBoundingBoxAngle
		{
			get;
			set;
		}

		// Turned off for now, if the results are not satisfactory then turn it on
		//public HandState[] HandLeftHandStates
		//{
		//	get;
		//	set;
		//}
		#endregion

		#region HandRight joint features
		public float HandRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandRightTotalVectorAngle
		{
			get;
			set;
		}

		public float HandRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandRightTotalDisplacement
		{
			get;
			set;
		}

		public float HandRightMaximumDisplacement
		{
			get;
			set;
		}

		public float HandRightBoundingBoxDiagonalLength
		{
			get;
			set;
		}

		public float HandRightBoundingBoxAngle
		{
			get;
			set;
		}

		// Turned off for now, if the results are not satisfactory then turn it on
		//public HandState[] HandRightHandStates
		//{
		//	get;
		//	set;
		//}
		#endregion

		#region ThumbLeft joint features
		public float ThumbLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbLeftTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbLeftTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbRight joint features
		public float ThumbRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbRightTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbRightTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandTipLeft joint features
		public float HandTipLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandTipLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipLeftTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandTipLeftTotalDisplacement
		{
			get;
			set;
		}

		public float HandTipLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandTipRight joint features
		public float HandTipRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandTipRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipRightTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandTipRightTotalDisplacement
		{
			get;
			set;
		}

		public float HandTipRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ElbowLeftWristLeft bone features
		public float ElbowLeftWristLeftBoneInitialAngle
		{
			get;
			set;
		}

		public float ElbowLeftWristLeftBoneFinalAngle
		{
			get;
			set;
		}

		public float ElbowLeftWristLeftBoneMeanAngle
		{
			get;
			set;
		}

		public float ElbowLeftWristLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ElbowRightWristRight bone features
		public float ElbowRightWristRightBoneInitialAngle
		{
			get;
			set;
		}

		public float ElbowRightWristRightBoneFinalAngle
		{
			get;
			set;
		}

		public float ElbowRightWristRightBoneMeanAngle
		{
			get;
			set;
		}

		public float ElbowRightWristRightBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristLeftHandLeft bone features
		public float WristLeftHandLeftBoneInitialAngle
		{
			get;
			set;
		}

		public float WristLeftHandLeftBoneFinalAngle
		{
			get;
			set;
		}

		public float WristLeftHandLeftBoneMeanAngle
		{
			get;
			set;
		}

		public float WristLeftHandLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristRightHandRight bone features
		public float WristRightHandRightBoneInitialAngle
		{
			get;
			set;
		}

		public float WristRightHandRightBoneFinalAngle
		{
			get;
			set;
		}

		public float WristRightHandRightBoneMeanAngle
		{
			get;
			set;
		}

		public float WristRightHandRightBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region HandLeftHandTipLeft bone features
		public float HandLeftHandTipLeftBoneInitialAngle
		{
			get;
			set;
		}

		public float HandLeftHandTipLeftBoneFinalAngle
		{
			get;
			set;
		}

		public float HandLeftHandTipLeftBoneMeanAngle
		{
			get;
			set;
		}

		public float HandLeftHandTipLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region HandRightHandTipRight bone features
		public float HandRightHandTipRightBoneInitialAngle
		{
			get;
			set;
		}

		public float HandRightHandTipRightBoneFinalAngle
		{
			get;
			set;
		}

		public float HandRightHandTipRightBoneMeanAngle
		{
			get;
			set;
		}

		public float HandRightHandTipRightBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristLeftThumbLeft bone features
		public float WristLeftThumbLeftBoneInitialAngle
		{
			get;
			set;
		}

		public float WristLeftThumbLeftBoneFinalAngle
		{
			get;
			set;
		}

		public float WristLeftThumbLeftBoneMeanAngle
		{
			get;
			set;
		}

		public float WristLeftThumbLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristRightThumbRight bone features
		public float WristRightThumbRightBoneInitialAngle
		{
			get;
			set;
		}

		public float WristRightThumbRightBoneFinalAngle
		{
			get;
			set;
		}

		public float WristRightThumbRightBoneMeanAngle
		{
			get;
			set;
		}

		public float WristRightThumbRightBoneMaximumAngle
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

		#region Label
		public string Label
		{
			get;
			set;
		}
		#endregion
	}
}
