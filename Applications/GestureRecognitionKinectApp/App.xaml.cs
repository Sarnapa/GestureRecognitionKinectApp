using System.Windows;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App: Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
				.WriteTo.File(
						new CompactJsonFormatter(),
						path: "logs/app-.clef",
						rollingInterval: RollingInterval.Day,
						retainedFileCountLimit: 10,
						fileSizeLimitBytes: 20_000_000,
						buffered: true)
				.CreateLogger();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);

			ConfigService.SaveSettings();

			if (this.TryFindResource("Locator") is ViewModelLocator viewModelLocator)
			{
				viewModelLocator.BodyTracking.Dispose();
				viewModelLocator.GestureRecord.Dispose();
			}

			Log.CloseAndFlush();
		}
	}
}
