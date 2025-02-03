using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Utilities;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Utils;

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
		private Visibility startStopGestureRecordButtonVisibility = Visibility.Hidden;
		private Visibility stoppedBodyTrackingInfoVisibility = Visibility.Hidden;
		private string stoppedBodyTrackingInfoText;
		private Timer countdownTimer;
		private Visibility countdownInfoVisibility = Visibility.Hidden;
		private string countdownInfoImageUri = ViewModelsUtils.GetImageUri("ZeroIcon.png");
		private double currentCountdownValue;
		private string gestureRecognizingResultText = string.Empty;
		private Visibility gestureRecognizingResultImageVisibility = Visibility.Hidden;
		private string gestureRecognizingResultImageUri = ViewModelsUtils.GetImageUri("SuccessIcon.png");
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
			private set
			{
				if (this.kinectStatusText != value)
				{
					this.kinectStatusText = value;
					RaisePropertyChanged(nameof(KinectStatusText));
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
			private set
			{
				if (this.fpsValueText != value)
				{
					this.fpsValueText = value;
					RaisePropertyChanged(nameof(FPSValueText));
				}
			}
		}

		public SolidColorBrush GestureRecordingBorderBrush
		{
			get;
			private set;
		} = Brushes.Transparent;

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

		public Visibility ImportGestureRecognitionModelButtonVisibility
		{
			get
			{
				// TODO: Change when mechanism will be ready
				//return this.model.TrackingState == BodyTrackingState.Standard
				//	? Visibility.Visible : Visibility.Hidden;
				return Visibility.Collapsed;
			}
		}

		public string ImportGestureRecognitionModelButtonTip
		{
			get
			{
				return Properties.Resources.ImportModel;
			}
		}

		public string ImportGestureRecognitionModelButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("ImportModel.png");
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

		public Visibility PrepareGesturesDataButtonVisibility
		{
			get
			{
				return this.model.TrackingState == BodyTrackingState.Standard
					? Visibility.Visible : Visibility.Hidden;
			}
		}

		public string PrepareGesturesDataButtonTip
		{
			get
			{
				return Properties.Resources.PrepareGesturesDataTip;
			}
		}

		public string PrepareGesturesDataButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("PrepareGesturesData.png");
			}
		}

		public Visibility StartStopGestureRecordButtonVisibility
		{
			get
			{
				return this.startStopGestureRecordButtonVisibility;
			}
			private set
			{
				if (this.startStopGestureRecordButtonVisibility != value)
				{
					this.startStopGestureRecordButtonVisibility = value;
					RaisePropertyChanged(nameof(StartStopGestureRecordButtonVisibility));
				}
			}
		}

		public string StartStopGestureRecordButtonTip
		{
			get
			{
				return this.StartStopGestureRecordButtonVisibility == Visibility.Visible && this.model.TrackingState == BodyTrackingState.GestureRecording ?
					Properties.Resources.StopRecordTip : Properties.Resources.StartRecordTip;
			}
		}

		public string StartStopGestureRecordButtonImageUri
		{
			get
			{
				return this.StartStopGestureRecordButtonVisibility == Visibility.Visible && this.model.TrackingState == BodyTrackingState.GestureRecording ?
					ViewModelsUtils.GetImageUri("StopRecordIcon.png") : ViewModelsUtils.GetImageUri("StartRecordIcon.png");
			}
		}

		public string GestureRecognizingResultText
		{
			get
			{
				return this.gestureRecognizingResultText;
			}
			private set
			{
				if (this.gestureRecognizingResultText != value)
				{
					this.gestureRecognizingResultText = value;
					RaisePropertyChanged(nameof(GestureRecognizingResultText));
				}
			}
		}

		public Visibility GestureRecognizingResultImageVisibility
		{
			get
			{
				return this.gestureRecognizingResultImageVisibility;
			}
			private set
			{
				if (this.gestureRecognizingResultImageVisibility != value)
				{
					this.gestureRecognizingResultImageVisibility = value;
					RaisePropertyChanged(nameof(GestureRecognizingResultImageVisibility));
				}
			}
		}

		public string GestureRecognizingResultImageUri
		{
			get
			{
				return this.gestureRecognizingResultImageUri;
			}
			private set
			{
				if (this.gestureRecognizingResultImageUri != value)
				{
					this.gestureRecognizingResultImageUri = value;
					RaisePropertyChanged(nameof(GestureRecognizingResultImageUri));
				}
			}
		}

		#region Commands
		public RelayCommand StartCommand
		{
			get; private set;
		}
		public RelayCommand ImportGestureRecognitionModelCommand
		{
			get;
			private set;
		}
		public RelayCommand ImportGestureRecordCommand
		{
			get; private set;
		}
		public RelayCommand PrepareGesturesDataCommand
		{
			get; private set;
		}
		public RelayCommand StartStopGestureRecordCommand
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
			this.ImportGestureRecognitionModelCommand = new RelayCommand(this.ImportGestureRecognitionModelCommandAction);
			this.ImportGestureRecordCommand = new RelayCommand(this.ImportGestureRecordCommandAction);
			this.PrepareGesturesDataCommand = new RelayCommand(this.PrepareGesturesDataCommandAction);
			this.StartStopGestureRecordCommand = new RelayCommand(this.StartStopGestureRecordCommandAction);
			this.CleanupCommand = new RelayCommand(this.CleanupCommandAction);
			Messenger.Default.Register<DisplayImageChangedMessage>(this, m => DisplayImageChangedMessageHandler(m));
			Messenger.Default.Register<KinectStatusMessage>(this, m => KinectStatusChangedMessageHandler(m));
			Messenger.Default.Register<TrackedUsersCountChangedMessage>(this, m => TrackedUsersCountChangedMessageHandler(m));
			Messenger.Default.Register<FPSValueMessage>(this, m => FPSValueMessageHandler(m));
			Messenger.Default.Register<BodyTrackingStoppedMessage>(this, m => BodyTrackingStoppedMessageHandler(m));
			Messenger.Default.Register<GestureRecordingFinishedMessage>(this, async m => await GestureRecordingFinishedMessageHandler(m));
			Messenger.Default.Register<TemporaryStateStartedMessage>(this, m => TemporaryStateStartedMessageHandler(m));
		}
		#endregion

		#region Private methods

		#region Actions
		private void StartCommandAction()
		{
			this.model.Start();
		}

		private void ImportGestureRecognitionModelCommandAction()
		{
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

		private void PrepareGesturesDataCommandAction()
		{
			var openFileDialog = new OpenFileDialog
			{
				Filter = $"Gesture data files (*{CsvHelperUtils.CsvFileExtension})|*{CsvHelperUtils.CsvFileExtension}",
				Multiselect = true
			};
			bool? openFileDialogRes = openFileDialog.ShowDialog();
			if (openFileDialogRes.HasValue && openFileDialogRes == true && openFileDialog.FileNames != null)
			{
				var saveFileDialog = new SaveFileDialog
				{
					Filter = $"Gesture data files (*{CsvHelperUtils.CsvFileExtension})|*{CsvHelperUtils.CsvFileExtension}",
				};
				bool? saveFileDialogRes = saveFileDialog.ShowDialog();
				if (saveFileDialogRes.HasValue && saveFileDialogRes == true && !string.IsNullOrEmpty(saveFileDialog.FileName))
				{
					var result = this.model.GestureRecognitionManager.PrepareGesturesDataForRecognitionModel(
						new PrepareGesturesDataForRecognitionModelParameters()
						{
							GestureDataFilesPaths = openFileDialog.FileNames,
							GesturesDataOutputFilePath = saveFileDialog.FileName
						});
					if (result?.Success == true)
					{
						MessageBoxUtils.ShowMessage($"Preparing gestures data succeeded.\nOutput file - {saveFileDialog.FileName}",
							"Gesture recognition", MessageBoxButton.OK, MessageBoxImage.Information);
					}
					else
					{
						MessageBoxUtils.ShowMessage($"Preparing gestures data failed", "Gesture recognition",
							MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}
		}

		private void StartStopGestureRecordCommandAction()
		{
			bool isRecording = this.model.TrackingState == BodyTrackingState.GestureRecording;
			string gestureRecordFilePath = this.model.GestureRecordFilePath;

			this.model.StartStopGestureRecording();
			UpdateStartStopGestureRecordButtonState(isRecording ? Visibility.Hidden : Visibility.Visible);

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
			if ((m.PrevState == BodyTrackingState.WaitingToStartGestureRecording || m.PrevState == BodyTrackingState.WaitingToStartGestureRecognizing)
				&& !this.IsKinectAvailable)
			{
				StopCountdown();
			}

			this.KinectStatusText = m.Text;

			if (!this.IsKinectAvailable)
			{
				UpdateGestureRecordingBorderState(false);
				UpdateStartStopGestureRecordButtonState(Visibility.Hidden);
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
			if ((m.PrevState == BodyTrackingState.WaitingToStartGestureRecording || m.PrevState == BodyTrackingState.WaitingToStartGestureRecognizing)
				&& m.IsStopped)
			{
				StopCountdown();
			}

			bool showInfo = m.IsStopped && !string.IsNullOrEmpty(m.Text);

			if ((m.PrevState == BodyTrackingState.GestureRecording || m.PrevState == BodyTrackingState.GestureToRecognizeRecording)
				&& m.IsStopped)
			{
				UpdateGestureRecordingBorderState(false);
			}

			if (!(!m.IsStopped && (m.PrevState == BodyTrackingState.GestureToRecognizeRecording || m.PrevState == BodyTrackingState.WaitingForGestureRecognizingResult)))
				UpdateStartStopGestureRecordButtonState(this.model.IsUserTracked ? Visibility.Visible : Visibility.Hidden);

			this.StoppedBodyTrackingInfoVisibility = showInfo ? Visibility.Visible : Visibility.Hidden;
			this.StoppedBodyTrackingInfoText = showInfo ? m.Text : string.Empty;
		}

		private async Task GestureRecordingFinishedMessageHandler(GestureRecordingFinishedMessage m)
		{
			if (this.model.TrackingState == BodyTrackingState.GestureToRecognizeRecording)
				await this.StartGestureRecognitionProcess();
			else
				this.StartStopGestureRecordCommandAction();
		}

		private void TemporaryStateStartedMessageHandler(TemporaryStateStartedMessage m)
		{
			this.currentCountdownValue = CountdownMaxValue;
			SetCountdownInfoImageUri();
			StartCountdown();
		}
		#endregion

		#region Gesture recognition methods
		private async Task StartGestureRecognitionProcess()
		{
			UpdateGestureRecordingBorderState(false);
			UpdateGestureRecognizingResultState(Visibility.Visible);
			var result = await this.model.ExecuteGestureRecognitionProcess();
			UpdateGestureRecognizingResultState(result);
			UpdateStartStopGestureRecordButtonState(Visibility.Visible);
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

					if (this.model.TrackingState == BodyTrackingState.WaitingToStartGestureRecording)
					{
						this.model.StartStopGestureRecording();
						UpdateGestureRecordingBorderState(true);
						RaisePropertyChanged(nameof(StartStopGestureRecordButtonImageUri));
						RaisePropertyChanged(nameof(StartStopGestureRecordButtonTip));
					}
					else if (this.model.TrackingState == BodyTrackingState.WaitingToStartGestureRecognizing)
					{
						this.model.StartGestureToRecognizeRecording();
						UpdateGestureRecordingBorderState(true);
						UpdateStartStopGestureRecordButtonState(Visibility.Hidden);
						UpdateGestureRecognizingResultState(string.Empty, Visibility.Hidden, ViewModelsUtils.GetImageUri("QuestionIcon.png"));
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

		private void UpdateGestureRecordingBorderState(bool isRecording)
		{
			var newBrush = isRecording ? Brushes.OrangeRed : Brushes.Transparent;
			if (this.GestureRecordingBorderBrush?.Color != newBrush?.Color)
			{
				this.GestureRecordingBorderBrush = newBrush;
				RaisePropertyChanged(nameof(GestureRecordingBorderBrush));
			}
		}

		private void UpdateStartStopGestureRecordButtonState(Visibility visibility)
		{
				this.StartStopGestureRecordButtonVisibility = visibility;
			RaisePropertyChanged(nameof(StartStopGestureRecordButtonImageUri));
			RaisePropertyChanged(nameof(StartStopGestureRecordButtonTip));
		}

		private void UpdateGestureRecognizingResultState(RecognizeGestureResult result)
		{
			UpdateGestureRecognizingResultState(result?.Label, Visibility.Visible, result?.Success ?? false
				? ViewModelsUtils.GetImageUri("SuccessIcon.png") : ViewModelsUtils.GetImageUri("FailedIcon.png"));
		}

		private void UpdateGestureRecognizingResultState(Visibility imageVisibility)
		{
			this.GestureRecognizingResultImageVisibility = imageVisibility;
		}

		private void UpdateGestureRecognizingResultState(string text, Visibility imageVisibility, string imageUri)
		{
			this.GestureRecognizingResultText = text ?? string.Empty;
			this.GestureRecognizingResultImageVisibility = imageVisibility;
			this.GestureRecognizingResultImageUri = imageUri ?? string.Empty;
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
