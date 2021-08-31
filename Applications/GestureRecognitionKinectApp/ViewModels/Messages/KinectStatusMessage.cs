using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages
{
	public class KinectStatusMessage
	{
		public BodyTrackingState PrevState
		{
			get; set;
		}

		public string Text
		{
			get; set;
		}
	}
}
