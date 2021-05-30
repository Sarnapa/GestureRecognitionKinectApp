using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class BodyTrackingViewModel : ViewModelBase, IDisposable
	{
		#region Private fields
		private readonly BodyTrackingModel model;
		private readonly IFrameNavigationService navigationService;
		private string kinectStatusText;
		private int trackedUsersCount;
		private string fpsValueText;
		private Visibility stoppedBodyTrackingInfoVisibility = Visibility.Hidden;
		private string stoppedBodyTrackingInfoText;
		#endregion

		#region Private properties
		private bool IsKinectAvailable
		{
			get
			{
				return this.model.IsKinectAvailable;
			}
		}
		#endregion

		#region Public properties
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
					RaisePropertyChanged(nameof(KinectStatusText));
				}
			}
		}

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
					RaisePropertyChanged(nameof(FPSValueText));
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
					RaisePropertyChanged(nameof(StoppedBodyTrackingInfoVisibility));
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
					RaisePropertyChanged(nameof(StoppedBodyTrackingInfoText));
				}
			}
		}

		public Visibility ImportGestureRecordButtonVisibility
		{
			get
			{
				return this.model.TrackingState == BodyTrackingState.Standard
					? Visibility.Visible : Visibility.Hidden;
			}
		}

		public string ImportGestureRecordButtonTip
		{
			get
			{
				return Properties.Resources.ImportRecordTip;
			}
		}

		public string ImportGestureRecordButtonImageUri
		{
			get
			{
				return "pack://application:,,,/Resources/ImportRecordIcon.png";
			}
		}

		public Visibility StartStopRecordGestureButtonVisibility
		{
			get
			{
				return this.IsKinectAvailable ? Visibility.Visible : Visibility.Hidden;
			}
		}

		public string StartStopRecordGestureButtonTip
		{
			get
			{
				return this.model.TrackingState == BodyTrackingState.RecordingGesture ?
					Properties.Resources.StopRecordTip : Properties.Resources.StartRecordTip;
			}
		}

		public string StartStopRecordGestureButtonImageUri
		{
			get
			{
				return this.model.TrackingState == BodyTrackingState.RecordingGesture ?
					"pack://application:,,,/Resources/StopRecordIcon.png" : "pack://application:,,,/Resources/StartRecordIcon.png";
			}
		}

		#region Commands
		public RelayCommand StartCommand
		{
			get; private set;
		}
		public RelayCommand ImportGestureRecordCommand
		{
			get; private set;
		}
		public RelayCommand StartStopRecordGestureCommand
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
		public BodyTrackingViewModel(IFrameNavigationService navigationService)
		{
			this.model = new BodyTrackingModel();
			this.navigationService = navigationService;
			this.StartCommand = new RelayCommand(this.StartCommandAction);
			this.ImportGestureRecordCommand = new RelayCommand(this.ImportGestureRecordCommandAction);
			this.StartStopRecordGestureCommand = new RelayCommand(this.StartStopRecordGestureCommandAction);
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

		private void ImportGestureRecordCommandAction()
		{
			var openFileDialog = new OpenFileDialog
			{
				Filter = $"Gesture record files (*{Consts.GestureRecordFileExtension})|*{Consts.GestureRecordFileExtension}"
			};
			bool? openFileDialogRes = openFileDialog.ShowDialog();
			if (openFileDialogRes.HasValue && openFileDialogRes == true && !string.IsNullOrEmpty(openFileDialog.FileName))
			{
				Messenger.Default.Send<GestureRecordMessage, GestureRecordViewModel>(
					new GestureRecordMessage() { IsTemporaryFile = false, FilePath = openFileDialog.FileName });
			}
		}

		private void StartStopRecordGestureCommandAction()
		{
			bool isRecording = this.model.TrackingState == BodyTrackingState.RecordingGesture;
			string gestureRecordFilePath = this.model.GestureRecordFilePath;

			this.model.StartStopRecordingGesture();
			RaisePropertyChanged(nameof(StartStopRecordGestureButtonImageUri));
			RaisePropertyChanged(nameof(StartStopRecordGestureButtonTip));

			if (isRecording)
			{
				Messenger.Default.Send<GestureRecordMessage, GestureRecordViewModel>(
					new GestureRecordMessage() { IsTemporaryFile = true, FilePath = gestureRecordFilePath });
			}
		}

		private void CleanupCommandAction()
		{
			this.model.Cleanup(false);
		}
		#endregion

		#region Messages handlers
		private void KinectStatusChangedMessageHandler(KinectStatusMessage m)
		{
			RaisePropertyChanged(nameof(StartStopRecordGestureButtonVisibility));
			this.KinectStatusText = m.Text;
		}

		private void DisplayImageChangedMessageHandler(DisplayImageChangedMessage m)
		{
			if (m.Changed)
			{
				RaisePropertyChanged(nameof(ColorImage));
				RaisePropertyChanged(nameof(BodyImage));
			}
		}

		private void TrackedUsersCountChangedMessageHandler(TrackedUsersCountChangedMessage m)
		{
			if (this.trackedUsersCount != m.Count)
			{
				this.trackedUsersCount = m.Count;
				RaisePropertyChanged(nameof(TrackedUsersCountText));
			}
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

		#region IDisposable implementation
		public void Dispose()
		{
			if (this.model != null)
				this.model.Cleanup();
		}
		#endregion
	}
}
