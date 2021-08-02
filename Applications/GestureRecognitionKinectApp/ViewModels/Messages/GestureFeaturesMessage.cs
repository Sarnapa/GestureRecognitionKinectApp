using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages
{
	public class GestureFeaturesMessage
	{
		public GestureFeatures Features
		{
			get; set;
		}
		
		/// <summary>
		/// Indicate that gesture features will be presented in form
		/// </summary>
		public bool IsPresentation
		{
			get; set;
		}
	}
}
