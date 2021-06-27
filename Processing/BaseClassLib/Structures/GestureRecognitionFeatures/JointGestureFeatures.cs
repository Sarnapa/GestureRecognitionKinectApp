using Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public class JointGestureFeatures
	{
		#region Public properties
		public double? F1F2SpatialAngle
		{
			get;
			private set;
		}

		public double? FN_1FNSpatialAngle
		{
			get;
			private set;
		}

		public double? F1FNSpatialAngle
		{
			get;
			private set;
		}

		public double? TotalVectorAngle
		{
			get;
			private set;
		}

		public double? SquaredTotalVectorAngle
		{
			get;
			private set;
		}

		public double? TotalVectorDisplacement
		{
			get;
			private set;
		}

		public double? TotalDisplacement
		{
			get;
			private set;
		}

		public double? MaximumDisplacement
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public JointGestureFeatures(double? f1F2SpatialAngle, double? fN_1FNSpatialAngle, double? f1FNSpatialAngle,
			double? totalVectorAngle, double? squaredTotalVectorAngle, double? totalVectorDisplacement, double? totalDisplacement,
			double? maximumDisplacement)
		{
			this.F1F2SpatialAngle = f1F2SpatialAngle;
			this.FN_1FNSpatialAngle = fN_1FNSpatialAngle;
			this.F1FNSpatialAngle = f1FNSpatialAngle;
			this.TotalVectorAngle = totalVectorAngle;
			this.SquaredTotalVectorAngle = squaredTotalVectorAngle;
			this.TotalVectorDisplacement = totalVectorDisplacement;
			this.TotalDisplacement = totalDisplacement;
			this.MaximumDisplacement = maximumDisplacement;
		}
		#endregion
	}

	public class HandJointGestureFeatures : JointGestureFeatures
	{
		#region Public properties
		public double? BoundingBoxDiagonalLength
		{
			get;
			private set;
		}

		public double? BoundingBoxAngle
		{
			get;
			private set;
		}

		public HandState[] HandStates
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public HandJointGestureFeatures(double? f1F2SpatialAngle, double? fN_1FNSpatialAngle, double? f1FNSpatialAngle,
			double? totalVectorAngle, double? squaredTotalVectorAngle, double? totalVectorDisplacement, double? totalDisplacement,
			double? maximumDisplacement, double? boundingBoxDiagonalLength, double? boundingBoxAngle, HandState[] handStates)
			: base(f1F2SpatialAngle, fN_1FNSpatialAngle, f1FNSpatialAngle, totalVectorAngle, squaredTotalVectorAngle,
				totalVectorDisplacement, totalDisplacement, maximumDisplacement)
		{
			this.BoundingBoxDiagonalLength = boundingBoxDiagonalLength;
			this.BoundingBoxAngle = boundingBoxAngle;
			this.HandStates = handStates;
		}
		#endregion
	}
}
