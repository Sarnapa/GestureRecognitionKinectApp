using System;
using Microsoft.Kinect;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class JointGestureFeaturesViewModel
	{
		#region Private fields
		private JointType joint;
		private JointGestureFeatures features;
		#endregion

		#region Public properties
		public JointType Joint
		{
			get
			{
				return this.joint;
			}
		}

		public double? F1F2SpatialAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.features.F1F2SpatialAngle, 3);
			}
		}

		public double? FN_1FNSpatialAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.features.FN_1FNSpatialAngle, 3);
			}
		}

		public double? F1FNSpatialAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.features.F1F2SpatialAngle, 3);
			}
		}

		public double? TotalVectorAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.features.TotalVectorAngle, 3);
			}
		}

		public double? SquaredTotalVectorAngle
		{
			get
			{
				return ViewModelsUtils.Round(this.features.SquaredTotalVectorAngle, 3);
			}
		}

		public double? TotalVectorDisplacement
		{
			get
			{
				return ViewModelsUtils.Round(this.features.TotalVectorDisplacement, 3);
			}
		}

		public double? TotalDisplacement
		{
			get
			{
				return ViewModelsUtils.Round(this.features.TotalDisplacement, 3);
			}
		}

		public double? MaximumDisplacement
		{
			get
			{
				return ViewModelsUtils.Round(this.features.MaximumDisplacement, 3);
			}
		}
		#endregion

		#region Constructors
		public JointGestureFeaturesViewModel(JointType joint, JointGestureFeatures features)
		{
			if (features == null)
				throw new ArgumentNullException(nameof(features));

			this.joint = joint;
			this.features = features;
		}
		#endregion
	}
}
