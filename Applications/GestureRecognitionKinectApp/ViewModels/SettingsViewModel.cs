using System;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.DataPreparation;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class SettingsViewModel: ViewModelBase
	{
		#region Private fields
		private readonly IFrameNavigationService navigationService;
		#endregion

		#region Public properties
	
		public string TrackingMode
		{
			get
			{
				return ConfigService.TrackingMode.ToString();
			}
			set
			{
				ConfigService.MainSettings.BodyTrackingMode = Enum.Parse<BodyTrackingMode>(value);
			}
		}

		public string[] TrackingModes
		{
			get
			{
				return Enum.GetValues<BodyTrackingMode>().Select(m => m.ToString()).ToArray();
			}
		}

		public float TrackedJointScoreThreshold
		{
			get
			{
				return ConfigService.MainSettings.TrackedJointScoreThreshold;
			}
			set
			{
				ConfigService.MainSettings.TrackedJointScoreThreshold = value;
			}
		}

		public float InferredJointScoreThreshold
		{
			get
			{
				return ConfigService.MainSettings.InferredJointScoreThreshold;
			}
			set
			{
				ConfigService.MainSettings.InferredJointScoreThreshold = value;
			}
		}

		public bool AllowBodyTrackingLostForRecordingAndRecognizingUsingMediaPipeModels
		{
			get
			{
				return ConfigService.MainSettings.AllowBodyTrackingLostForRecordingAndRecognizingUsingMediaPipeModels;
			}
			set
			{
				ConfigService.MainSettings.AllowBodyTrackingLostForRecordingAndRecognizingUsingMediaPipeModels = value;
			}
		}

		public Visibility AdminModeSettingsVisibility
		{
			get
			{
				#if ADMIN_MODE
					return Visibility.Visible;
				#else
					return Visibility.Collapsed;
				#endif
			}
		}

		public bool AllowAutomaticGestureRecordExport
		{
			get
			{
				return ConfigService.MainSettings.AllowAutomaticGestureRecordExport;
			}
			set
			{
				ConfigService.MainSettings.AllowAutomaticGestureRecordExport = value;
			}
		}

		public string DefaultGestureLabel
		{
			get
			{
				return ConfigService.MainSettings.DefaultGestureLabel.ToString();
			}
			set
			{
				ConfigService.MainSettings.DefaultGestureLabel = Enum.Parse<GestureLabel>(value);
			}
		}

		public string[] GestureLabels
		{
			get
			{
				return Enum.GetValues<GestureLabel>().Select(l => l.ToString()).ToArray();
			}
		}

		public string CurrentUser
		{
			get
			{
				return ConfigService.MainSettings.CurrentUser.ToString();
			}
			set
			{
				ConfigService.MainSettings.CurrentUser = Enum.Parse<UserName>(value);
			}
		}

		public string[] Users
		{
			get
			{
				return Enum.GetValues<UserName>().Select(l => l.ToString()).ToArray();
			}
		}

		public string GesturesDatasetPath
		{
			get
			{
				return ConfigService.MainSettings.GesturesDatasetPath;
			}
			set
			{
				ConfigService.MainSettings.GesturesDatasetPath = value;
			}
		}

		public string GestureRecordFileNameExtraLabel
		{
			get
			{
				return ConfigService.MainSettings.GestureRecordFileNameExtraLabel;
			}
			set
			{
				ConfigService.MainSettings.GestureRecordFileNameExtraLabel = value;
			}
		}

		public float MinPoseDetectionConfidence
		{
			get
			{
				return ConfigService.MediaPipePoseLandmarksSettings.MinPoseDetectionConfidence;
			}
			set
			{
				ConfigService.MediaPipePoseLandmarksSettings.MinPoseDetectionConfidence = value;
			}
		}

		public float MinPosePresenceConfidence
		{
			get
			{
				return ConfigService.MediaPipePoseLandmarksSettings.MinPosePresenceConfidence;
			}
			set
			{
				ConfigService.MediaPipePoseLandmarksSettings.MinPosePresenceConfidence = value;
			}
		}

		public float PoseLandmarksMinTrackingConfidence
		{
			get
			{
				return ConfigService.MediaPipePoseLandmarksSettings.MinTrackingConfidence;
			}
			set
			{
				ConfigService.MediaPipePoseLandmarksSettings.MinTrackingConfidence = value;
			}
		}

		public int NumHands
		{
			get
			{
				return ConfigService.MediaPipeHandLandmarksSettings.NumHands;
			}
			set
			{
				ConfigService.MediaPipeHandLandmarksSettings.NumHands = value;
			}
		}

		public float MinHandDetectionConfidence
		{
			get
			{
				return ConfigService.MediaPipeHandLandmarksSettings.MinHandDetectionConfidence;
			}
			set
			{
				ConfigService.MediaPipeHandLandmarksSettings.MinHandDetectionConfidence = value;
			}
		}

		public float MinHandPresenceConfidence
		{
			get
			{
				return ConfigService.MediaPipeHandLandmarksSettings.MinHandPresenceConfidence;
			}
			set
			{
				ConfigService.MediaPipeHandLandmarksSettings.MinHandPresenceConfidence = value;
			}
		}

		public float HandLandmarksMinTrackingConfidence
		{
			get
			{
				return ConfigService.MediaPipeHandLandmarksSettings.MinTrackingConfidence;
			}
			set
			{
				ConfigService.MediaPipeHandLandmarksSettings.MinTrackingConfidence = value;
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
		#endregion

		#region Commands
		public RelayCommand ReturnCommand
		{
			get; private set;
		}
		#endregion

		#region Constructors
		public SettingsViewModel(IFrameNavigationService navigationService)
		{
			this.navigationService = navigationService;
			this.ReturnCommand = new RelayCommand(this.ReturnCommandAction);
		}
		#endregion

		#region Private methods

		#region Actions
		private void ReturnCommandAction()
		{
			ConfigService.SaveSettings();
			this.navigationService.GoBack();
		}
		#endregion

		#endregion
	}
}
