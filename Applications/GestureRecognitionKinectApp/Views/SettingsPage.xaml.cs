using System.Windows;
using System.Windows.Controls;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views
{
	/// <summary>
	/// Interaction logic for SettingsPage.xaml
	/// </summary>
	public partial class SettingsPage: Page
	{
		public SettingsPage()
		{
			InitializeComponent();
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
