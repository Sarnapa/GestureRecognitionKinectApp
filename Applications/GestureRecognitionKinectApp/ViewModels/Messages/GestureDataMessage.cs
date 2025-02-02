using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages
{
	public class GestureDataMessage
	{
		public GestureFeatures Features
		{
			get; set;
		}

		public string Label
		{
			get; set;
		}
	}
}
