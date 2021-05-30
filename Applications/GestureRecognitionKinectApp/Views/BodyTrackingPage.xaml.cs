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

		private void ToolBar_Loaded(object sender, RoutedEventArgs e)
		{
			var toolBar = sender as ToolBar;
			if (toolBar.Template.FindName("OverflowGrid", toolBar) is FrameworkElement overflowGrid)
			{
				overflowGrid.Visibility = Visibility.Collapsed;
			}
			if (toolBar.Template.FindName("MainPanelBorder", toolBar) is FrameworkElement mainPanelBorder)
			{
				mainPanelBorder.Margin = new Thickness();
			}
		}
	}
}
