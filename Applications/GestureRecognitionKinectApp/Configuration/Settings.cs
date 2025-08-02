namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class Settings
	{
		public required MainSettings MainSettings
		{
			get;
			set;
		}

		public required MediaPipePoseLandmarksBodyTrackingModeSettings MediaPipePoseLandmarksBodyTrackingModeSettings
		{
			get;
			set;
		}

		public required MediaPipeHandLandmarksBodyTrackingModeSettings MediaPipeHandLandmarksBodyTrackingModeSettings
		{
			get;
			set;
		}
	}
}
