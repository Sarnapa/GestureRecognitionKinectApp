using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class BodyTrackingViewModel : ViewModelBase
	{
		#region Private fields
		private BodyTrackingModel model;
		#endregion

		#region Public properties
		public DrawingImage Image
		{
			get
			{
				return model.Image;
			}
		}

		public string StatusText
		{
			get
			{
				return model.StatusText;
			}
		}

		#region Commands
		public RelayCommand StartCommand
		{
			get; private set;
		}
		public RelayCommand CleanupCommand
		{
			get; private set;
		}
		#endregion

		#endregion

		#region Constructors
		public BodyTrackingViewModel()
		{
			this.model = new BodyTrackingModel();
			this.StartCommand = new RelayCommand(this.StartCommandAction);
			this.CleanupCommand = new RelayCommand(this.CleanupCommandAction);
			Messenger.Default.Register<DrawingImageChangedMessage>(this, e => RaisePropertyChanged("Image"));
			Messenger.Default.Register<KinectStatusChangedMessage>(this, e => RaisePropertyChanged("StatusText"));
		}
		#endregion

		#region Private methods

		#region Actions
		private void StartCommandAction()
		{
			model.Start();
		}
		
		private void CleanupCommandAction()
		{
			model.Cleanup();
		}
		#endregion

		#endregion
	}
}
