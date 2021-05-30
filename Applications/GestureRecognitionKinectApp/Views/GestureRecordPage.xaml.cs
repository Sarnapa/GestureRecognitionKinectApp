using System.Windows;
using System.Windows.Controls;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views
{
	/// <summary>
	/// Interaction logic for GestureRecordPage.xaml
	/// </summary>
	public partial class GestureRecordPage : Page
	{
		public GestureRecordPage()
		{
			InitializeComponent();
		}

		private void GestureRecordPage_Loaded(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is GestureRecordViewModel gestureRecordViewModel
				&& gestureRecordViewModel.StartCommand.CanExecute(null))
			{
				gestureRecordViewModel.StartCommand.Execute(null);
			}
		}

		private void GestureRecordPage_Unloaded(object sender, RoutedEventArgs e)
		{
			if (this.DataContext is GestureRecordViewModel gestureRecordViewModel
				&& gestureRecordViewModel.CleanupCommand.CanExecute(null))
			{
				gestureRecordViewModel.CleanupCommand.Execute(null);
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
