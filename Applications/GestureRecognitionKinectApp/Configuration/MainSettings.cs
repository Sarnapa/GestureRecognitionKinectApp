using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class MainSettings
	{
		#region Public properties
		public BodyTrackingMode BodyTrackingMode
		{
			get;
			set;
		} = BodyTrackingMode.Kinect;

		public float TrackedJointScoreThreshold
		{
			get;
			set;
		} = 0.6f;

		public float InferredJointScoreThreshold
		{
			get;
			set;
		} = 0.5f;
		#endregion
	}
}
