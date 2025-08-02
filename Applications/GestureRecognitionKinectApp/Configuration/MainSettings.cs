using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class MainSettings
	{
		public required BodyTrackingMode BodyTrackingMode
		{
			get;
			set;
		}

		public required float TrackedJointScoreThreshold
		{
			get;
			set;
		}

		public required float InferredJointScoreThreshold
		{
			get;
			set;
		}
	}
}
