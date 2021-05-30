using System;
using System.Windows.Media;
using Microsoft.Win32;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using static GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.ViewModelLocator;
using System.Windows;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class GestureRecordViewModel: ViewModelBase, IDisposable
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

		public Visibility ExportGestureRecordButtonVisibility
		{
			get
			{
				return this.isTemporaryGestureRecordFile ? Visibility.Visible : Visibility.Hidden;
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
				return "pack://application:,,,/Resources/ExportRecordIcon.png";
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
				return "pack://application:,,,/Resources/BackIcon.png";
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
			this.ExportGestureRecordCommand = new RelayCommand(this.ExportGestureRecordCommandAction);
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

		private void ReturnCommandAction()
		{
			this.navigationService.GoBack();
		}

		private void ExportGestureRecordCommandAction()
		{
			var saveFileDialog = new SaveFileDialog
			{
				Filter = $"Gesture record files (*{Consts.GestureRecordFileExtension})|*{Consts.GestureRecordFileExtension}"
			};
			bool? saveFileDialogRes = saveFileDialog.ShowDialog();
			if (saveFileDialogRes.HasValue && saveFileDialogRes == true && !string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				bool res = this.model.ExportGestureRecord(saveFileDialog.FileName);
				if (res)
				{
					this.isTemporaryGestureRecordFile = false;
					RaisePropertyChanged(nameof(ExportGestureRecordButtonVisibility));
				}
			}
		}

		private void CleanupCommandAction()
		{
			this.model.Cleanup(this.isTemporaryGestureRecordFile);
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
				RaisePropertyChanged(nameof(ColorImage));
				RaisePropertyChanged(nameof(BodyImage));
			}
		}
		#endregion

		#endregion

		public void Dispose()
		{
			if (this.model != null)
				this.model.Cleanup(this.isTemporaryGestureRecordFile);
		}
	}
}
