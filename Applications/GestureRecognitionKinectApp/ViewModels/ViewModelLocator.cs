using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class ViewModelLocator
	{
		#region Window keys
		public const string BodyTrackingWindow = "BodyTrackingWindow";
		#endregion

		#region ViewModels
		public BodyTrackingViewModel BodyTracking
		{
			get
			{
				return ServiceLocator.Current.GetInstance<BodyTrackingViewModel>();
			}
		}
		#endregion

		#region Constructors
		// The constructor of ViewModelLocator registers viewModels instances to the SimpleIoc service.
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
		
			var bodyTrackingViewModel = new BodyTrackingViewModel();
			if (ViewModelBase.IsInDesignModeStatic)
			{
				// Create design time view services and models.
			}
			else
			{
				// Create run time view services and models.
			}
			// Register used services.
			SimpleIoc.Default.Register<BodyTrackingViewModel>(() => bodyTrackingViewModel);
		}
		#endregion
	}
}
