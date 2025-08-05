namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public sealed class MediaPipeHandLandmarksBodyTrackingModeSettings
	{
		#region Public properties
		public int NumHands
		{
			get;
			set;
		} = 2;

		public float MinHandDetectionConfidence
		{
			get;
			set;
		} = 0.6f;

		public float MinHandPresenceConfidence
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
