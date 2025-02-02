using System.Windows;
using System.Windows.Controls;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views
{
	/// <summary>
	/// Interaction logic for GestureFeaturesPage.xaml
	/// </summary>
	public partial class GestureFeaturesPage : Page
	{
		public GestureFeaturesPage()
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
