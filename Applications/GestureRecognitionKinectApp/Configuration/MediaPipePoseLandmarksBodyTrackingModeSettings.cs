namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class MediaPipePoseLandmarksBodyTrackingModeSettings
	{
		#region Public properties
		public float MinPoseDetectionConfidence
		{
			get;
			set;
		} = 0.6f;

		public float MinPosePresenceConfidence
		{
			get;
			set;
		} = 0.6f;

		public float MinTrackingConfidence
		{
			get;
			set;
		} = 0.6f;
		#endregion
	}
}
