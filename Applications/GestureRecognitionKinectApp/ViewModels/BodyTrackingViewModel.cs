using System;
using System.Timers;
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
		private const double CountdownInterval = 1000d;
		private const double CountdownMaxValue = 3000d;
		private readonly BodyTrackingModel model;
		private readonly IFrameNavigationService navigationService;
		private string kinectStatusText;
		private int trackedUsersCount;
		private string fpsValueText;
		private Visibility startStopRecordGestureButtonVisibility = Visibility.Hidden;
		private Visibility stoppedBodyTrackingInfoVisibility = Visibility.Hidden;
		private string stoppedBodyTrackingInfoText;
		private Timer countdownTimer;
		private Visibility countdownInfoVisibility = Visibility.Hidden;
		private string countdownInfoImageUri = ViewModelsUtils.GetImageUri("ZeroIcon.png");
		private double currentCountdownValue;
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
			private set
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
			private set
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
			private set
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
			private set
			{
				if (this.stoppedBodyTrackingInfoText != value)
				{
					this.stoppedBodyTrackingInfoText = value;
					RaisePropertyChanged(nameof(StoppedBodyTrackingInfoText));
				}
			}
		}

		public Visibility CountdownInfoVisibility
		{
			get
			{
				return this.countdownInfoVisibility;
			}
			private set
			{
				if (this.countdownInfoVisibility != value)
				{
					this.countdownInfoVisibility = value;
					RaisePropertyChanged(nameof(CountdownInfoVisibility));
				}
			}
		}

		public string CountdownInfoImageUri
		{
			get
			{
				return this.countdownInfoImageUri;
			}
			private set
			{
				if (this.countdownInfoImageUri != value)
				{
					this.countdownInfoImageUri = value;
					RaisePropertyChanged(nameof(CountdownInfoImageUri));
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
				return ViewModelsUtils.GetImageUri("ImportRecordIcon.png");
			}
		}

		public Visibility StartStopRecordGestureButtonVisibility
		{
			get
			{
				return this.startStopRecordGestureButtonVisibility;
			}
			private set
			{
				if (this.startStopRecordGestureButtonVisibility != value)
				{
					this.startStopRecordGestureButtonVisibility = value;
					RaisePropertyChanged(nameof(StartStopRecordGestureButtonVisibility));
				}
			}
		}

		public string StartStopRecordGestureButtonTip
		{
			get
			{
				return this.startStopRecordGestureButtonVisibility == Visibility.Visible && this.model.TrackingState == BodyTrackingState.RecordingGesture?
					Properties.Resources.StopRecordTip : Properties.Resources.StartRecordTip;
			}
		}

		public string StartStopRecordGestureButtonImageUri
		{
			get
			{
				return this.startStopRecordGestureButtonVisibility == Visibility.Visible && this.model.TrackingState == BodyTrackingState.RecordingGesture ?
					ViewModelsUtils.GetImageUri("StopRecordIcon.png") : ViewModelsUtils.GetImageUri("StartRecordIcon.png");
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
			this.countdownTimer = new Timer(CountdownInterval);
			this.countdownTimer.AutoReset = true;
			this.countdownTimer.Elapsed += CountdownTimerElapsedHandler;
			this.StartCommand = new RelayCommand(this.StartCommandAction);
			this.ImportGestureRecordCommand = new RelayCommand(this.ImportGestureRecordCommandAction);
			this.StartStopRecordGestureCommand = new RelayCommand(this.StartStopRecordGestureCommandAction);
			this.CleanupCommand = new RelayCommand(this.CleanupCommandAction);
			Messenger.Default.Register<DisplayImageChangedMessage>(this, m => DisplayImageChangedMessageHandler(m));
			Messenger.Default.Register<KinectStatusMessage>(this, m => KinectStatusChangedMessageHandler(m));
			Messenger.Default.Register<TrackedUsersCountChangedMessage>(this, m => TrackedUsersCountChangedMessageHandler(m));
			Messenger.Default.Register<FPSValueMessage>(this, m => FPSValueMessageHandler(m));
			Messenger.Default.Register<BodyTrackingStoppedMessage>(this, m => BodyTrackingStoppedMessageHandler(m));
			Messenger.Default.Register<GestureRecordingFinishedMessage>(this, m => GestureRecordingFinishedMessageHandler(m));
			Messenger.Default.Register<TemporaryStateStartedMessage>(this, m => TemporaryStateStartedMessageHandler(m));
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

			this.model.StartStopGestureRecording();
			this.StartStopRecordGestureButtonVisibility = isRecording ? Visibility.Hidden : Visibility.Visible; 
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
			if (m.PrevState == BodyTrackingState.WaitingToStartRecordingGesture && !this.IsKinectAvailable)
				StopCountdown();

			this.KinectStatusText = m.Text;
			if (!this.IsKinectAvailable)
			{
				UpdateStartStopRecordGestureButtonState(Visibility.Hidden);
				UpdateFPSValueText(0d);
				UpdateTrackedUsersCount(0);
			}
		}

		private void DisplayImageChangedMessageHandler(DisplayImageChangedMessage m)
		{
			if ((m.ChangedDisplayImage & ImageKind.Color) != 0)
				RaisePropertyChanged(nameof(ColorImage));
			if ((m.ChangedDisplayImage & ImageKind.Body) != 0)
				RaisePropertyChanged(nameof(BodyImage));
		}

		private void TrackedUsersCountChangedMessageHandler(TrackedUsersCountChangedMessage m)
		{
			UpdateTrackedUsersCount(m.Count);
		}

		private void FPSValueMessageHandler(FPSValueMessage m)
		{
			UpdateFPSValueText(m.Value);
		}

		private void BodyTrackingStoppedMessageHandler(BodyTrackingStoppedMessage m)
		{
			if (m.PrevState == BodyTrackingState.WaitingToStartRecordingGesture && m.IsStopped)
				StopCountdown();

			bool showInfo = m.IsStopped && !string.IsNullOrEmpty(m.Text);

			UpdateStartStopRecordGestureButtonState(this.model.IsUserTracked ? Visibility.Visible : Visibility.Hidden);
			this.StoppedBodyTrackingInfoVisibility = showInfo ? Visibility.Visible : Visibility.Hidden;
			this.StoppedBodyTrackingInfoText = showInfo ? m.Text : string.Empty;
		}

		private void GestureRecordingFinishedMessageHandler(GestureRecordingFinishedMessage m)
		{
			this.StartStopRecordGestureCommandAction();
		}

		private void TemporaryStateStartedMessageHandler(TemporaryStateStartedMessage m)
		{
			this.currentCountdownValue = CountdownMaxValue;
			SetCountdownInfoImageUri();
			StartCountdown();
		}
		#endregion

		#region Countdown timer methods
		private void CountdownTimerElapsedHandler(object sender, ElapsedEventArgs e)
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				this.currentCountdownValue -= CountdownInterval;
				SetCountdownInfoImageUri();
				if (this.currentCountdownValue < 0d)
				{
					StopCountdown();

					if (this.model.TrackingState == BodyTrackingState.WaitingToStartRecordingGesture)
					{
						this.model.StartStopGestureRecording();
						RaisePropertyChanged(nameof(StartStopRecordGestureButtonImageUri));
						RaisePropertyChanged(nameof(StartStopRecordGestureButtonTip));
					}
				}
			});
		}

		private void SetCountdownInfoImageUri()
		{
			switch (this.currentCountdownValue)
			{
				case 5000d:
					this.CountdownInfoImageUri = ViewModelsUtils.GetImageUri("FiveIcon.png");
					break;
				case 4000d:
					this.CountdownInfoImageUri = ViewModelsUtils.GetImageUri("FourIcon.png");
					break;
				case 3000d:
					this.CountdownInfoImageUri = ViewModelsUtils.GetImageUri("ThreeIcon.png");
					break;
				case 2000d:
					this.CountdownInfoImageUri = ViewModelsUtils.GetImageUri("TwoIcon.png");
					break;
				case 1000d:
					this.CountdownInfoImageUri = ViewModelsUtils.GetImageUri("OneIcon.png");
					break;
				case 0d:
					this.CountdownInfoImageUri = ViewModelsUtils.GetImageUri("ZeroIcon.png");
					break;
			}
		}

		private void StartCountdown()
		{
			this.CountdownInfoVisibility = Visibility.Visible;
			this.countdownTimer.Start();
		}

		private void StopCountdown()
		{
			this.countdownTimer.Stop();
			this.CountdownInfoVisibility = Visibility.Hidden;
			this.currentCountdownValue = CountdownMaxValue;
		}
		#endregion

		#region Other methods
		private void UpdateFPSValueText(double fpsValue)
		{
			this.FPSValueText = $"{string.Format("{0:0.00}", fpsValue)} FPS";
		}

		private void UpdateTrackedUsersCount(int currentTrackedUsersCount)
		{
			if (this.trackedUsersCount != currentTrackedUsersCount)
			{
				this.trackedUsersCount = currentTrackedUsersCount;
				RaisePropertyChanged(nameof(TrackedUsersCountText));
			}
		}

		private void UpdateStartStopRecordGestureButtonState(Visibility visibility)
		{
			if (this.StartStopRecordGestureButtonVisibility != visibility)
			{
				this.StartStopRecordGestureButtonVisibility = visibility;
				RaisePropertyChanged(nameof(StartStopRecordGestureButtonImageUri));
				RaisePropertyChanged(nameof(StartStopRecordGestureButtonTip));
			}
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
