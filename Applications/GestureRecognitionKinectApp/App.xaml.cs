using System.Windows;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App: Application
	{
		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);

			if (this.TryFindResource("Locator") is ViewModelLocator viewModelLocator)
			{
				viewModelLocator.BodyTracking.Dispose();
				viewModelLocator.GestureRecord.Dispose();
			}
		}
	}
}
