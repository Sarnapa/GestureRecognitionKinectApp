using System.Windows;
using System.Windows.Controls;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views
{
	/// <summary>
	/// Interaction logic for BodyTrackingPage.xaml
	/// </summary>
	public partial class BodyTrackingPage : Page
	{
		public BodyTrackingPage()
		{
			InitializeComponent();
		}

		private void BodyTrackingPage_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is BodyTrackingViewModel bodyTrackingViewModel
				&& bodyTrackingViewModel.StartCommand.CanExecute(null))
			{
				bodyTrackingViewModel.StartCommand.Execute(null);
			}
		}

		private void BodyTrackingPage_Unloaded(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is BodyTrackingViewModel bodyTrackingViewModel
				&& bodyTrackingViewModel.CleanupCommand.CanExecute(null))
			{
				bodyTrackingViewModel.CleanupCommand.Execute(null);
			}
		}
	}
}
