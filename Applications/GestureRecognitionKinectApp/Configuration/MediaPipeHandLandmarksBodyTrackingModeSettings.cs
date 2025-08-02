namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class MediaPipeHandLandmarksBodyTrackingModeSettings
	{
		public int NumHands
		{
			get;
			set;
		}

		public float MinHandDetectionConfidence
		{
			get;
			set;
		}

		public float MinHandPresenceConfidence
		{
			get;
			set;
		}

		public float MinTrackingConfidence
		{
			get;
			set;
		}
	}
}
