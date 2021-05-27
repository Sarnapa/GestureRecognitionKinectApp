using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class ViewModelLocator
	{
		#region Page keys
		public const string BodyTrackingPageKey = "BodyTrackingPage";
		public const string GestureRecordPageKey = "GestureRecordPage";
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
		#endregion

		#region Constructors
		// The constructor of ViewModelLocator registers viewModels instances to the SimpleIoc service.
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			var navigationService = new FrameNavigationService();
			navigationService.Configure(BodyTrackingPageKey, new Uri("../Views/BodyTrackingPage.xaml", UriKind.Relative));
			navigationService.Configure(GestureRecordPageKey, new Uri("../Views/GestureRecordPage.xaml", UriKind.Relative));
			SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<BodyTrackingViewModel>(true);
			SimpleIoc.Default.Register<GestureRecordViewModel>(true);
		}
		#endregion
	}
}
