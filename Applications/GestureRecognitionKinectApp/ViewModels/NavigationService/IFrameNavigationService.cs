using GalaSoft.MvvmLight.Views;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService
{
	public interface IFrameNavigationService : INavigationService
	{
		object Parameter
		{
			get;
		}
	}
}
