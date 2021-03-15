using System.ComponentModel;
using System.Windows;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class BodyTrackingWindow: Window
	{
		public BodyTrackingWindow()
		{
			InitializeComponent();
		}

		private void BodyTrackingWindow_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is BodyTrackingViewModel bodyTrackingViewModel
				&& bodyTrackingViewModel.StartCommand.CanExecute(null))
			{
				bodyTrackingViewModel.StartCommand.Execute(null);
			}
		}

		private void BodyTrackingWindow_Closing(object sender, CancelEventArgs e)
		{
			if (this.DataContext is BodyTrackingViewModel bodyTrackingViewModel
				&& bodyTrackingViewModel.CleanupCommand.CanExecute(null))
			{
				bodyTrackingViewModel.CleanupCommand.Execute(null);
			}
		}
	}
}
