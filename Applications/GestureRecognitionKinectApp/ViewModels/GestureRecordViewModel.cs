using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using static GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.ViewModelLocator;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class GestureRecordViewModel : ViewModelBase
	{
		#region Private fields
		private readonly GestureRecordModel model;
		private readonly IFrameNavigationService navigationService;
		private string gestureRecordFilePath;
		private bool isTemporaryGestureRecordFile;
		#endregion

		#region Public properties
		public ImageSource ColorImage
		{
			get
			{
				return this.model.ColorImage;
			}
		}

		public ImageSource BodyImage
		{
			get
			{
				return this.model.BodyImage;
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
		public GestureRecordViewModel(IFrameNavigationService navigationService)
		{
			this.model = new GestureRecordModel();
			this.navigationService = navigationService;
			this.StartCommand = new RelayCommand(this.StartCommandAction);
			this.CleanupCommand = new RelayCommand(this.CleanupCommandAction);
			Messenger.Default.Register<GestureRecordMessage>(this, m => GestureRecordMessageHandler(m));
			Messenger.Default.Register<DisplayImageChangedMessage>(this, m => DisplayImageChangedMessageHandler(m));
		}
		#endregion

		#region Private methods

		#region Actions
		private void StartCommandAction()
		{
			if (!string.IsNullOrEmpty(this.gestureRecordFilePath))
				this.model.Start(this.gestureRecordFilePath);
		}

		private void CleanupCommandAction()
		{
			this.model.Cleanup();
		}
		#endregion

		#region Messages handlers
		private void GestureRecordMessageHandler(GestureRecordMessage m)
		{
			this.gestureRecordFilePath = m.FilePath;
			this.isTemporaryGestureRecordFile = m.IsTemporaryFile;
			this.navigationService.NavigateTo(GestureRecordPageKey);

		}

		private void DisplayImageChangedMessageHandler(DisplayImageChangedMessage m)
		{
			if (m.Changed)
			{
				RaisePropertyChanged("ColorImage");
				RaisePropertyChanged("BodyImage");
			}
		}
		#endregion

		#endregion
	}
}
