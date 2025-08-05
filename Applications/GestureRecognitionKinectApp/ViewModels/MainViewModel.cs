using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using static GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.ViewModelLocator;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		#region Private fields
		private IFrameNavigationService navigationService;
		private RelayCommand loadedCommand;
		#endregion

		#region Public properties
		public RelayCommand LoadedCommand
		{
			get
			{
				return this.loadedCommand
						?? (this.loadedCommand = new RelayCommand(
						() =>
						{
							Application.Current?.Dispatcher.Invoke(() =>
							{
								this.navigationService.NavigateTo(BodyTrackingPageKey);
							});
						}));
			}
		}
		#endregion

		#region Constructors
		public MainViewModel(IFrameNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}
		#endregion
	}
}
