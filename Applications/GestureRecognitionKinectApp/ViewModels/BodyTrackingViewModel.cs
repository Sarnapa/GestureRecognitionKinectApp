using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class BodyTrackingViewModel: ViewModelBase
	{
		#region Private fields
		private readonly BodyTrackingModel model;
		private string kinectStatusText;
		private int trackedUsersCount;
		private string fpsValueText;
		private Visibility stoppedBodyTrackingInfoVisibility = Visibility.Hidden;
		private string stoppedBodyTrackingInfoText;
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

		public string KinectStatusText
		{
			get
			{
				return this.kinectStatusText;
			}
			set
			{
				if (this.kinectStatusText != value)
				{
					this.kinectStatusText = value;
					RaisePropertyChanged("KinectStatusText");
				}
			}
		}

		public string TrackedUsersCountText
		{
			get
			{
				return $"Tracked users: {this.trackedUsersCount}";
			}
		}

		public string FPSValueText
		{
			get
			{
				return this.fpsValueText;
			}
			set
			{
				if (this.fpsValueText != value)
				{
					this.fpsValueText = value;
					RaisePropertyChanged("FPSValueText");
				}
			}
		}

		public Visibility StoppedBodyTrackingInfoVisibility
		{
			get
			{
				return this.stoppedBodyTrackingInfoVisibility;
			}
			set
			{
				if (this.stoppedBodyTrackingInfoVisibility != value)
				{
					this.stoppedBodyTrackingInfoVisibility = value;
					RaisePropertyChanged("StoppedBodyTrackingInfoVisibility");
				}
			}
		}

		public string StoppedBodyTrackingInfoText
		{
			get
			{
				return this.stoppedBodyTrackingInfoText;
			}
			set
			{
				if (this.stoppedBodyTrackingInfoText != value)
				{
					this.stoppedBodyTrackingInfoText = value;
					RaisePropertyChanged("StoppedBodyTrackingInfoText");
				}
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
			Messenger.Default.Register<DisplayImageChangedMessage>(this, m => DisplayImageChangedMessageHandler(m));
			Messenger.Default.Register<KinectStatusMessage>(this, m => KinectStatusChangedMessageHandler(m));
			Messenger.Default.Register<TrackedUsersCountChangedMessage>(this, m => TrackedUsersCountChangedMessageHandler(m));
			Messenger.Default.Register<FPSValueMessage>(this, m => FPSValueMessageHandler(m));
			Messenger.Default.Register<StoppedBodyTrackingMessage>(this, m => StoppedBodyTrackingMessageHandler(m));
		}
		#endregion

		#region Private methods

		#region Actions
		private void StartCommandAction()
		{
			this.model.Start();
		}
		
		private void CleanupCommandAction()
		{
			this.model.Cleanup();
		}
		#endregion

		#region Messages handlers
		private void DisplayImageChangedMessageHandler(DisplayImageChangedMessage m)
		{
			if (m.Changed)
			{
				RaisePropertyChanged("ColorImage");
				RaisePropertyChanged("BodyImage");
			}
		}

		private void TrackedUsersCountChangedMessageHandler(TrackedUsersCountChangedMessage m)
		{
			if (this.trackedUsersCount != m.Count)
			{
				this.trackedUsersCount = m.Count;
				RaisePropertyChanged("TrackedUsersCountText");
			}
		}

		private void KinectStatusChangedMessageHandler(KinectStatusMessage m)
		{
			this.KinectStatusText = m.Text;
		}

		private void FPSValueMessageHandler(FPSValueMessage m)
		{
			this.FPSValueText = $"{string.Format("{0:0.00}", m.Value)} FPS";
		}

		private void StoppedBodyTrackingMessageHandler(StoppedBodyTrackingMessage m)
		{
			this.StoppedBodyTrackingInfoVisibility = m.IsStopped ? Visibility.Visible : Visibility.Hidden;
			this.StoppedBodyTrackingInfoText = m.IsStopped ? m.Text : string.Empty;
		}
		#endregion

		#endregion
	}
}
