using Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews
{
	// TODO: Problem, że tutaj podajemy na sztywno te cechy, żeby nowy dodać punkt charakterystyczny trzeba będzie podać tutaj na sztywno do kodu.
	public class GestureDataView
	{
		#region ElbowLeft joint features
		public double? ElbowLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? ElbowLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ElbowLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ElbowLeftTotalVectorAngle
		{
			get;
			set;
		}

		public double? ElbowLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? ElbowLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? ElbowLeftTotalDisplacement
		{
			get;
			set;
		}

		public double? ElbowLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ElbowRight joint features
		public double? ElbowRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? ElbowRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ElbowRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ElbowRightTotalVectorAngle
		{
			get;
			set;
		}

		public double? ElbowRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? ElbowRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? ElbowRightTotalDisplacement
		{
			get;
			set;
		}

		public double? ElbowRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region WristLeft joint features
		public double? WristLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? WristLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? WristLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? WristLeftTotalVectorAngle
		{
			get;
			set;
		}

		public double? WristLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? WristLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? WristLeftTotalDisplacement
		{
			get;
			set;
		}

		public double? WristLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region WristRight joint features
		public double? WristRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? WristRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? WristRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? WristRightTotalVectorAngle
		{
			get;
			set;
		}

		public double? WristRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? WristRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? WristRightTotalDisplacement
		{
			get;
			set;
		}

		public double? WristRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandLeft joint features
		public double? HandLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? HandLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandLeftTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? HandLeftTotalDisplacement
		{
			get;
			set;
		}

		public double? HandLeftMaximumDisplacement
		{
			get;
			set;
		}

		public double? HandLeftBoundingBoxDiagonalLength
		{
			get;
			set;
		}

		public double? HandLeftBoundingBoxAngle
		{
			get;
			set;
		}

		public HandState[] HandLeftHandStates
		{
			get;
			set;
		}
		#endregion

		#region HandRight joint features
		public double? HandRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? HandRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandRightTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? HandRightTotalDisplacement
		{
			get;
			set;
		}

		public double? HandRightMaximumDisplacement
		{
			get;
			set;
		}

		public double? HandRightBoundingBoxDiagonalLength
		{
			get;
			set;
		}

		public double? HandRightBoundingBoxAngle
		{
			get;
			set;
		}

		public HandState[] HandRightHandStates
		{
			get;
			set;
		}
		#endregion

		#region ThumbLeft joint features
		public double? ThumbLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? ThumbLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ThumbLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ThumbLeftTotalVectorAngle
		{
			get;
			set;
		}

		public double? ThumbLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? ThumbLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? ThumbLeftTotalDisplacement
		{
			get;
			set;
		}

		public double? ThumbLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbRight joint features
		public double? ThumbRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? ThumbRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ThumbRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? ThumbRightTotalVectorAngle
		{
			get;
			set;
		}

		public double? ThumbRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? ThumbRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? ThumbRightTotalDisplacement
		{
			get;
			set;
		}

		public double? ThumbRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandTipLeft joint features
		public double? HandTipLeftF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? HandTipLeftFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandTipLeftF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandTipLeftTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandTipLeftSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandTipLeftTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? HandTipLeftTotalDisplacement
		{
			get;
			set;
		}

		public double? HandTipLeftMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandTipRight joint features
		public double? HandTipRightF1F2SpatialAngle
		{
			get;
			set;
		}

		public double? HandTipRightFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandTipRightF1FNSpatialAngle
		{
			get;
			set;
		}

		public double? HandTipRightTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandTipRightSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public double? HandTipRightTotalVectorDisplacement
		{
			get;
			set;
		}

		public double? HandTipRightTotalDisplacement
		{
			get;
			set;
		}

		public double? HandTipRightMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ElbowLeftWristLeft bone features
		public double? ElbowLeftWristLeftBoneInitialAngle
		{
			get;
			set;
		}

		public double? ElbowLeftWristLeftBoneFinalAngle
		{
			get;
			set;
		}

		public double? ElbowLeftWristLeftBoneMeanAngle
		{
			get;
			set;
		}

		public double? ElbowLeftWristLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ElbowRightWristRight bone features
		public double? ElbowRightWristRightBoneInitialAngle
		{
			get;
			set;
		}

		public double? ElbowRightWristRightBoneFinalAngle
		{
			get;
			set;
		}

		public double? ElbowRightWristRightBoneMeanAngle
		{
			get;
			set;
		}

		public double? ElbowRightWristRightBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristLeftHandLeft bone features
		public double? WristLeftHandLeftBoneInitialAngle
		{
			get;
			set;
		}

		public double? WristLeftHandLeftBoneFinalAngle
		{
			get;
			set;
		}

		public double? WristLeftHandLeftBoneMeanAngle
		{
			get;
			set;
		}

		public double? WristLeftHandLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristRightHandRight bone features
		public double? WristRightHandRightBoneInitialAngle
		{
			get;
			set;
		}

		public double? WristRightHandRightBoneFinalAngle
		{
			get;
			set;
		}

		public double? WristRightHandRightBoneMeanAngle
		{
			get;
			set;
		}

		public double? WristRightHandRightBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region HandLeftHandTipLeft bone features
		public double? HandLeftHandTipLeftBoneInitialAngle
		{
			get;
			set;
		}

		public double? HandLeftHandTipLeftBoneFinalAngle
		{
			get;
			set;
		}

		public double? HandLeftHandTipLeftBoneMeanAngle
		{
			get;
			set;
		}

		public double? HandLeftHandTipLeftBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region HandRightHandTipRight bone features
		public double? HandRightHandTipRightBoneInitialAngle
		{
			get;
			set;
		}

		public double? HandRightHandTipRightBoneFinalAngle
		{
			get;
			set;
		}

		public double? HandRightHandTipRightBoneMeanAngle
		{
			get;
			set;
		}

		public double? HandRightHandTipRightBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region Hands distances features
		public double? BetweenHandJointsDistanceMax
		{
			get;
			set;
		}

		public double? BetweenHandJointsDistanceMean
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
