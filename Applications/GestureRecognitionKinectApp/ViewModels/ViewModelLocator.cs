using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;
using GestureRecognition.Processing.GestureRecognitionProcUnit;
using static GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures.KinectGestureRecognitionDefinitions;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class ViewModelLocator
	{
		#region Page keys
		public const string BodyTrackingPageKey = "BodyTrackingPage";
		public const string GestureRecordPageKey = "GestureRecordPage";
		public const string GestureDataPageKey = "GestureDataPage";
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
		#endregion

		#region Constructors
		// The constructor of ViewModelLocator registers viewModels instances to the SimpleIoc service.
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			var navigationService = new FrameNavigationService();
			navigationService.Configure(BodyTrackingPageKey, new Uri("../Views/BodyTrackingPage.xaml", UriKind.Relative));
			navigationService.Configure(GestureRecordPageKey, new Uri("../Views/GestureRecordPage.xaml", UriKind.Relative));
			navigationService.Configure(GestureDataPageKey, new Uri("../Views/GestureDataPage.xaml", UriKind.Relative));
			SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);

			var gestureRecognitionFeaturesManager = new GestureRecognitionFeaturesManager(Processing.BaseClassLib.Structures.Body.BodyTrackingMode.Kinect);
			SimpleIoc.Default.Register(() => gestureRecognitionFeaturesManager);

			var gestureRecognitionManager = new GestureRecognitionManager();
			SimpleIoc.Default.Register(() => gestureRecognitionManager);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<BodyTrackingViewModel>(true);
			SimpleIoc.Default.Register<GestureRecordViewModel>(true);
			SimpleIoc.Default.Register<GestureDataViewModel>(true);
		}
		#endregion
	}
}
