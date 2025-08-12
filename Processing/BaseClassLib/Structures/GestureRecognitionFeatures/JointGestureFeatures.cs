namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public class JointGestureFeatures
	{
		#region Public properties
		public float F1F2SpatialAngle
		{
			get;
			private set;
		}

		public float FN_1FNSpatialAngle
		{
			get;
			private set;
		}

		public float F1FNSpatialAngle
		{
			get;
			private set;
		}

		public float TotalVectorAngle
		{
			get;
			private set;
		}

		public float SquaredTotalVectorAngle
		{
			get;
			private set;
		}

		public float TotalVectorDisplacement
		{
			get;
			private set;
		}

		public float TotalDisplacement
		{
			get;
			private set;
		}

		public float MaximumDisplacement
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public JointGestureFeatures(float f1F2SpatialAngle, float fN_1FNSpatialAngle, float f1FNSpatialAngle,
			float totalVectorAngle, float squaredTotalVectorAngle, float totalVectorDisplacement, float totalDisplacement,
			float maximumDisplacement)
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
		public float BoundingBoxDiagonalLength
		{
			get;
			private set;
		}

		public float BoundingBoxAngle
		{
			get;
			private set;
		}

		// Turned off for now, if the results are not satisfactory then turn it on
		//public HandState[] HandStates
		//{
		//	get;
		//	private set;
		//}
		#endregion

		#region Constructors
		public HandJointGestureFeatures(float f1F2SpatialAngle, float fN_1FNSpatialAngle, float f1FNSpatialAngle,
			float totalVectorAngle, float squaredTotalVectorAngle, float totalVectorDisplacement, float totalDisplacement,
			float maximumDisplacement, float boundingBoxDiagonalLength, float boundingBoxAngle/*, HandState[] handStates*/)
			: base(f1F2SpatialAngle, fN_1FNSpatialAngle, f1FNSpatialAngle, totalVectorAngle, squaredTotalVectorAngle,
				totalVectorDisplacement, totalDisplacement, maximumDisplacement)
		{
			this.BoundingBoxDiagonalLength = boundingBoxDiagonalLength;
			this.BoundingBoxAngle = boundingBoxAngle;
			//this.HandStates = handStates;
		}
		#endregion
	}
}
