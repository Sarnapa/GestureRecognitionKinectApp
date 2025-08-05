using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class ViewModelLocator
	{
		#region Page keys
		public const string BodyTrackingPageKey = "BodyTrackingPage";
		public const string GestureRecordPageKey = "GestureRecordPage";
		public const string GestureDataPageKey = "GestureDataPage";
		public const string SettingsPageKey = "SettingsPage";
		#endregion

		#region ViewModels
		public MainViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		public BodyTrackingViewModel BodyTracking
		{
			get
			{
				return ServiceLocator.Current.GetInstance<BodyTrackingViewModel>();
			}
		}

		public GestureRecordViewModel GestureRecord
		{
			get
			{
				return ServiceLocator.Current.GetInstance<GestureRecordViewModel>();
			}
		}

		public GestureDataViewModel GestureData
		{
			get
			{
				return ServiceLocator.Current.GetInstance<GestureDataViewModel>();
			}
		}

		public SettingsViewModel Settings
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SettingsViewModel>();
			}
		}
		#endregion

		#region Constructors
		// The constructor of ViewModelLocator registers viewModels instances to the SimpleIoc service.
		public ViewModelLocator()
		{
			ConfigService.LoadSettings();

			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			var navigationService = new FrameNavigationService();
			navigationService.Configure(BodyTrackingPageKey, new Uri("../Views/BodyTrackingPage.xaml", UriKind.Relative));
			navigationService.Configure(GestureRecordPageKey, new Uri("../Views/GestureRecordPage.xaml", UriKind.Relative));
			navigationService.Configure(GestureDataPageKey, new Uri("../Views/GestureDataPage.xaml", UriKind.Relative));
			navigationService.Configure(SettingsPageKey, new Uri("../Views/SettingsPage.xaml", UriKind.Relative));
			SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<BodyTrackingViewModel>(true);
			SimpleIoc.Default.Register<GestureRecordViewModel>(true);
			SimpleIoc.Default.Register<GestureDataViewModel>(true);
			SimpleIoc.Default.Register<SettingsViewModel>(true);
		}
		#endregion
	}
}
