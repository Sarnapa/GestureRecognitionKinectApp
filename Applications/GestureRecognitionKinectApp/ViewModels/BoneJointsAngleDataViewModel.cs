using System;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

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

		public string InitialAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.angleData.InitialAngle);
			}
		}

		public string FinalAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.angleData.FinalAngle);
			}
		}

		public string MeanAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.angleData.MeanAngle);
			}
		}

		public string MaximumAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.angleData.MaximumAngle);
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
