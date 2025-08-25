using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.DataPreparation;

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

		public bool AllowBodyTrackingLostForRecordingAndRecognizingUsingMediaPipeModels
		{
			get;
			set;
		} = false;

		public float GesturePredictionScoreThreshold
		{
			get;
			set;
		} = 0.5f;

		public bool AllowAutomaticGestureRecordExport
		{
			get;
			set;
		}

		public GestureLabel DefaultGestureLabel
		{
			get;
			set;
		}

		public UserName CurrentUser
		{
			get;
			set;
		}

		public string GesturesDatasetPath
		{
			get;
			set;
		} = string.Empty;

		public string GestureRecordFileNameExtraLabel
		{
			get;
			set;
		} = string.Empty;
		#endregion
	}
}
