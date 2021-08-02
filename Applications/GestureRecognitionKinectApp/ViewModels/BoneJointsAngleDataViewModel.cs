using System;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.Kinect;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class BoneJointsAngleDataViewModel
	{
		#region Private fields
		private Bone bone;
		private BoneJointsAngleData angleData;
		#endregion

		#region Public properties
		public string BoneId
		{
			get
			{
				return this.bone.ToString();
			}
		}

		public double? InitialAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.angleData.InitialAngle, 3);
			}
		}

		public double? FinalAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.angleData.FinalAngle, 3);
			}
		}

		public double? MeanAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.angleData.MeanAngle, 3);
			}
		}

		public double? MaximumAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.angleData.MaximumAngle, 3);
			}
		}
		#endregion

		#region Constructors
		public BoneJointsAngleDataViewModel(Bone bone, BoneJointsAngleData angleData)
		{
			if (bone == null)
				throw new ArgumentNullException(nameof(bone));
			if (angleData == null)
				throw new ArgumentNullException(nameof(angleData));

			this.bone = bone;
			this.angleData = angleData;
		}
		#endregion
	}
}
