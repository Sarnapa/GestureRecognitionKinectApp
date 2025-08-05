using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class SettingsViewModel: ViewModelBase
	{
		#region Private fields
		private readonly IFrameNavigationService navigationService;
		private ConcurrentDictionary<string, List<string>> errors = new ConcurrentDictionary<string, List<string>>();
		private object _lock = new object();
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
