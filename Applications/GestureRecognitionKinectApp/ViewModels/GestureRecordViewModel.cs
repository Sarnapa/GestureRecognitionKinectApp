using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Utilities;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Views.Dialogs;
using static GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.ViewModelLocator;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class GestureRecordViewModel : ViewModelBase, IDisposable
	{
		#region Private fields
		private readonly GestureRecordModel model;
		private readonly IFrameNavigationService navigationService;
		private string gestureRecordFilePath;
		private bool isTemporaryGestureRecordFile;
		private bool isGestureRecordFinished;
		private bool isCleanupPermission = true;
		#endregion

		#region Private properties
		private bool IsGestureFeaturesValid
		{
			get
			{
				return this.model.GestureFeatures != null && this.model.GestureFeatures.IsValid;
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

		public string GestureReplayCurrentTime
		{
			get
			{
				string currentTimeText = this.model.GestureReplayStartTime.HasValue ? 
					$"{DateTime.Now - this.model.GestureReplayStartTime.Value:ss\\:ff}" : "00:00";

				return $"Time: {currentTimeText}";
			}
		}

		public string ReturnButtonTip
		{
			get
			{
				return Properties.Resources.BackTip;
			}
		}

		public string ReturnButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("BackIcon.png");
			}
		}

		public Visibility ReplayGestureRecordButtonVisibility
		{
			get
			{
				return this.isGestureRecordFinished ? Visibility.Visible : Visibility.Hidden;
			}
		}

		public string ReplayGestureRecordButtonTip
		{
			get
			{
				return Properties.Resources.ReplayRecordTip;
			}
		}

		public string ReplayGestureRecordImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("ReplayRecordIcon.png");
			}
		}

		public Visibility ShowGestureFeaturesInformationButtonVisibility
		{
			get
			{
				return this.isGestureRecordFinished ? Visibility.Visible : Visibility.Hidden;
			}
		}

		public string ShowGestureFeaturesInformationButtonTip
		{
			get
			{
				return this.IsGestureFeaturesValid ? Properties.Resources.GestureFeaturesInformation
					: Properties.Resources.NoGestureFeatures;
			}
		}

		public string ShowGestureFeaturesInformationButtonImageUri
		{
			get
			{
				return this.IsGestureFeaturesValid ? ViewModelsUtils.GetImageUri("SuccessIcon.png")
					: ViewModelsUtils.GetImageUri("FailedIcon.png");
			}
		}

		public Visibility ExportGestureRecordButtonVisibility
		{
			get
			{
				return this.isTemporaryGestureRecordFile && this.isGestureRecordFinished && this.IsGestureFeaturesValid
					? Visibility.Visible : Visibility.Hidden;
			}
		}

		public string ExportGestureRecordButtonTip
		{
			get
			{
				return Properties.Resources.ExportRecordTip;
			}
		}

		public string ExportGestureRecordButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("ExportRecordIcon.png");
			}
		}

		#region Commands
		public RelayCommand StartCommand
		{
			get; private set;
		}
		public RelayCommand ReturnCommand
		{
			get; private set;
		}
		public RelayCommand ShowGestureInformationCommand
		{
			get; private set;
		}
		public RelayCommand ExportGestureRecordCommand
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
			this.ReturnCommand = new RelayCommand(this.ReturnCommandAction);
			this.ShowGestureInformationCommand = new RelayCommand(this.ShowGestureInformationCommandAction);
			this.ExportGestureRecordCommand = new RelayCommand(this.ExportGestureRecordCommandAction);
			this.CleanupCommand = new RelayCommand(this.CleanupCommandAction);
			Messenger.Default.Register<GestureRecordMessage>(this, m => GestureRecordMessageHandler(m));
			Messenger.Default.Register<DisplayImageChangedMessage>(this, m => DisplayImageChangedMessageHandler(m));
			Messenger.Default.Register<GestureRecordFrameProcessedMessage>(this, m => GestureRecordFrameProcessedMessageHandler(m));
			Messenger.Default.Register<GestureRecordFinishedMessage>(this, m => GestureRecordFinishedMessageHandler(m));
		}
		#endregion

		#region Private methods

		#region Actions
		private void StartCommandAction()
		{
			if (!string.IsNullOrEmpty(this.gestureRecordFilePath))
			{
				this.isCleanupPermission = true;
				this.isGestureRecordFinished = false;
				RaisePropertyChanged(nameof(ReplayGestureRecordButtonVisibility));
				RaisePropertyChanged(nameof(ShowGestureFeaturesInformationButtonVisibility));
				RaisePropertyChanged(nameof(ExportGestureRecordButtonVisibility));
				this.model.Start(this.gestureRecordFilePath, !isTemporaryGestureRecordFile);
			}
		}

		private void ReturnCommandAction()
		{
			this.navigationService.GoBack();
		}

		private void ExportGestureRecordCommandAction()
		{
			var gestureLabelInputDialog = new GestureLabelInputDialog();
			if (gestureLabelInputDialog.ShowDialog() == true)
			{
				this.model.SetGestureLabel(gestureLabelInputDialog.GestureLabel);

				var saveFileDialog = new SaveFileDialog
				{
					Filter = $"Gesture record files (*{Consts.GestureRecordFileExtension})|*{Consts.GestureRecordFileExtension}"
				};
				bool? saveFileDialogRes = saveFileDialog.ShowDialog();
				if (saveFileDialogRes.HasValue && saveFileDialogRes == true && !string.IsNullOrEmpty(saveFileDialog.FileName))
				{
					bool exportGestureRecordRes = this.model.ExportGestureRecord(saveFileDialog.FileName);
					if (exportGestureRecordRes)
					{
						this.isTemporaryGestureRecordFile = false;
						this.gestureRecordFilePath = saveFileDialog.FileName;
						// TODO: Exporting gesture data failure handling.
						this.model.ExportGestureData();
						RaisePropertyChanged(nameof(ExportGestureRecordButtonVisibility));
					}
				}
			}
		}

		private void ShowGestureInformationCommandAction()
		{
			if (this.IsGestureFeaturesValid)
			{
				this.isCleanupPermission = false;
				MessengerUtils.SendMessage(new GestureDataMessage() { Features = this.model.GestureFeatures,
					Label = this.model.GestureLabel });
			}
		}

		private void CleanupCommandAction()
		{
			if (this.isCleanupPermission)
			{
				this.model.Cleanup(this.isTemporaryGestureRecordFile);
				this.isGestureRecordFinished = false;
			}
		}
		#endregion

		#region Messages handlers
		private void GestureRecordMessageHandler(GestureRecordMessage m)
		{
			this.gestureRecordFilePath = m.FilePath;
			this.isTemporaryGestureRecordFile = m.IsTemporaryFile;
			Application.Current?.Dispatcher.Invoke(() =>
			{
				this.navigationService.NavigateTo(GestureRecordPageKey);
			});
		}

		private void DisplayImageChangedMessageHandler(DisplayImageChangedMessage m)
		{
			if ((m.ChangedDisplayImage & ImageKind.Color) != 0)
				RaisePropertyChanged(nameof(ColorImage));
			if ((m.ChangedDisplayImage & ImageKind.Body) != 0)
				RaisePropertyChanged(nameof(BodyImage));
		}

		private void GestureRecordFrameProcessedMessageHandler(GestureRecordFrameProcessedMessage m)
		{
			RaisePropertyChanged(nameof(GestureReplayCurrentTime));
		}

		private void GestureRecordFinishedMessageHandler(GestureRecordFinishedMessage m)
		{
			this.isGestureRecordFinished = true;
			RaisePropertyChanged(nameof(ReplayGestureRecordButtonVisibility));
			RaisePropertyChanged(nameof(ShowGestureFeaturesInformationButtonVisibility));
			RaisePropertyChanged(nameof(ShowGestureFeaturesInformationButtonTip));
			RaisePropertyChanged(nameof(ShowGestureFeaturesInformationButtonImageUri));
			RaisePropertyChanged(nameof(ExportGestureRecordButtonVisibility));
		}
		#endregion

		#endregion

		#region IDisposable implementation
		public void Dispose()
		{
			if (this.model != null)
				this.model.Cleanup(this.isTemporaryGestureRecordFile);
		}
		#endregion
	}
}
