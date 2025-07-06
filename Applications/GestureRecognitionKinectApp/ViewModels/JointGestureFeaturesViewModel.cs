using System;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
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

		public string F1F2SpatialAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.features.F1F2SpatialAngle);
			}
		}

		public string FN_1FNSpatialAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.features.FN_1FNSpatialAngle);
			}
		}

		public string F1FNSpatialAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.features.F1FNSpatialAngle);
			}
		}

		public string TotalVectorAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.features.TotalVectorAngle);
			}
		}

		public string SquaredTotalVectorAngle
		{
			get
			{
				return ViewModelsUtils.Format(this.features.SquaredTotalVectorAngle);
			}
		}

		public string TotalVectorDisplacement
		{
			get
			{
				return ViewModelsUtils.Format(this.features.TotalVectorDisplacement);
			}
		}

		public string TotalDisplacement
		{
			get
			{
				return ViewModelsUtils.Format(this.features.TotalDisplacement);
			}
		}

		public string MaximumDisplacement
		{
			get
			{
				return ViewModelsUtils.Format(this.features.MaximumDisplacement);
			}
		}

		public string BoundingBoxDiagonalLength
		{
			get
			{
				return (this.joint == JointType.HandLeft || this.joint == JointType.HandRight) && this.features is HandJointGestureFeatures handJointGestureFeatures
					? ViewModelsUtils.Format(handJointGestureFeatures.BoundingBoxDiagonalLength) : Properties.Resources.JointGestureFeatureNotSupportedText;
			}
		}

		public string BoundingBoxAngle
		{
			get
			{
				return (this.joint == JointType.HandLeft || this.joint == JointType.HandRight) && this.features is HandJointGestureFeatures handJointGestureFeatures
					? ViewModelsUtils.Format(handJointGestureFeatures.BoundingBoxAngle) : Properties.Resources.JointGestureFeatureNotSupportedText;
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
