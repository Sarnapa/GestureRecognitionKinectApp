namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public class BoneJointsAngleData
	{
		#region Public properties
		public float InitialAngle
		{
			get;
			private set;
		}

		public float FinalAngle
		{
			get;
			private set;
		}

		public float MeanAngle
		{
			get;
			private set;
		}

		public float MaximumAngle
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BoneJointsAngleData(float initialAngle, float finalAngle, float meanAngle, float maximumAngle)
		{
			this.InitialAngle = initialAngle;
			this.FinalAngle = finalAngle;
			this.MeanAngle = meanAngle;
			this.MaximumAngle = maximumAngle;
		}
		#endregion
	}
}
