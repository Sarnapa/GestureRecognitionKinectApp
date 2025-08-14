namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews
{
	// TODO: Problem, że tutaj podajemy na sztywno te cechy, żeby nowy dodać punkt charakterystyczny trzeba będzie podać tutaj na sztywno do kodu.
	public class KinectGestureDataView : GestureDataView
	{
		#region ElbowDominant joint features
		public float ElbowDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ElbowDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ElbowDominantTotalDisplacement
		{
			get;
			set;
		}

		public float ElbowDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ElbowNondominant joint features
		public float ElbowNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ElbowNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ElbowNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ElbowNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ElbowNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float ElbowNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

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

		#region ThumbDominant joint features
		public float ThumbDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbDominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ThumbNondominant joint features
		public float ThumbNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float ThumbNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float ThumbNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float ThumbNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float ThumbNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float ThumbNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandTipDominant joint features
		public float HandTipDominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandTipDominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipDominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipDominantTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipDominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipDominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandTipDominantTotalDisplacement
		{
			get;
			set;
		}

		public float HandTipDominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region HandTipNondominant joint features
		public float HandTipNondominantF1F2SpatialAngle
		{
			get;
			set;
		}

		public float HandTipNondominantFN_1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipNondominantF1FNSpatialAngle
		{
			get;
			set;
		}

		public float HandTipNondominantTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipNondominantSquaredTotalVectorAngle
		{
			get;
			set;
		}

		public float HandTipNondominantTotalVectorDisplacement
		{
			get;
			set;
		}

		public float HandTipNondominantTotalDisplacement
		{
			get;
			set;
		}

		public float HandTipNondominantMaximumDisplacement
		{
			get;
			set;
		}
		#endregion

		#region ElbowWristDominant bone features
		public float ElbowWristDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ElbowWristDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ElbowWristDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ElbowWristDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region ElbowWristNondominant bone features
		public float ElbowWristNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float ElbowWristNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float ElbowWristNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float ElbowWristNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristHandDominant bone features
		public float WristHandDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristHandDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristHandDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristHandDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristHandNondominant bone features
		public float WristHandNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristHandNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristHandNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristHandNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region HandHandTipDominant bone features
		public float HandHandTipDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float HandHandTipDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float HandHandTipDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float HandHandTipDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region HandHandTipNondominant bone features
		public float HandHandTipNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float HandHandTipNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float HandHandTipNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float HandHandTipNondominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristThumbDominant bone features
		public float WristThumbDominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristThumbDominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristThumbDominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristThumbDominantBoneMaximumAngle
		{
			get;
			set;
		}
		#endregion

		#region WristThumbNondominant bone features
		public float WristThumbNondominantBoneInitialAngle
		{
			get;
			set;
		}

		public float WristThumbNondominantBoneFinalAngle
		{
			get;
			set;
		}

		public float WristThumbNondominantBoneMeanAngle
		{
			get;
			set;
		}

		public float WristThumbNondominantBoneMaximumAngle
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
