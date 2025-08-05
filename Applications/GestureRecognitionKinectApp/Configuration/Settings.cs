namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class Settings
	{
		#region Public properties
		public MainSettings MainSettings
		{
			get;
			set;
		} = new MainSettings();

		public MediaPipePoseLandmarksBodyTrackingModeSettings MediaPipePoseLandmarksBodyTrackingModeSettings
		{
			get;
			set;
		} = new MediaPipePoseLandmarksBodyTrackingModeSettings();

		public MediaPipeHandLandmarksBodyTrackingModeSettings MediaPipeHandLandmarksBodyTrackingModeSettings
		{
			get;
			set;
		} = new MediaPipeHandLandmarksBodyTrackingModeSettings();
		#endregion
	}
}
