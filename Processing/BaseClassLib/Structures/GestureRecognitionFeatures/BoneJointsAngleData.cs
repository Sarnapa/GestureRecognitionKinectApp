namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public class BoneJointsAngleData
	{
		#region Public properties
		public double? InitialAngle
		{
			get;
			private set;
		}

		public double? FinalAngle
		{
			get;
			private set;
		}

		public double? MeanAngle
		{
			get;
			private set;
		}

		public double? MaximumAngle
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BoneJointsAngleData(double? initialAngle, double? finalAngle, double? meanAngle, double? maximumAngle)
		{
			this.InitialAngle = initialAngle;
			this.FinalAngle = finalAngle;
			this.MeanAngle = meanAngle;
			this.MaximumAngle = maximumAngle;
		}
		#endregion
	}
}
