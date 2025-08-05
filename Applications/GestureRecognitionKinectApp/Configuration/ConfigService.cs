using System;
using System.IO;
using System.Windows;
using System.Xml.Linq;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Utilities;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using Microsoft.Extensions.Configuration;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Configuration
{
	public static class ConfigService
	{
		#region Private fields
		private const string CONFIG_FILE = $"GestureRecognitionKinectApp.dll.config";
		private static bool isConfigBind = false;
		#endregion

		#region Private properties
		public static IConfigurationRoot ConfigurationRoot
		{
			get; private set;
		}
		#endregion

		#region Public properties
		public static Settings Settings
		{
			get; private set;
		}

		public static MainSettings MainSettings
		{
			get
			{
				return Settings.MainSettings;
			}
		}

		public static BodyTrackingMode TrackingMode
		{
			get
			{
				return Settings.MainSettings.BodyTrackingMode;
			}
		}

		public static MediaPipePoseLandmarksBodyTrackingModeSettings MediaPipePoseLandmarksSettings
		{
			get
			{
				return Settings.MediaPipePoseLandmarksBodyTrackingModeSettings;
			}
		}

		public static MediaPipeHandLandmarksBodyTrackingModeSettings MediaPipeHandLandmarksSettings
		{
			get
			{
				return Settings.MediaPipeHandLandmarksBodyTrackingModeSettings;
			}
		}
		#endregion

		#region Public methods
		public static void LoadSettings()
		{
			if (File.Exists(CONFIG_FILE))
			{
				try
				{
					ConfigurationRoot = new ConfigurationBuilder()
							.AddXmlFile(CONFIG_FILE, optional: false, reloadOnChange: false)
							.Build();

					Settings = new Settings();
					ConfigurationRoot.GetSection(nameof(Settings)).Bind(Settings);
					isConfigBind = true;
				}
				catch (Exception ex)
				{
					MessageBoxUtils.ShowMessage($"Loading settings from configuration file failed - default setting was applied, error message: {ex.Message}.", MessageBoxButton.OK, MessageBoxImage.Error);
					Settings = new Settings();
				}
			}
			else
			{
				Settings = new Settings();
			}
		}

		public static void SaveSettings()
		{
			try
			{
				if (File.Exists(CONFIG_FILE) && isConfigBind)
				{
					var xmlDoc = XDocument.Load(CONFIG_FILE);

					var settingsElement = xmlDoc.Root.Element(nameof(Settings));
					if (settingsElement != null)
					{
						var mainSettingsElement = settingsElement.Element(nameof(Settings.MainSettings));
						if (mainSettingsElement != null && Settings.MainSettings != null)
						{
							mainSettingsElement.Element(nameof(Settings.MainSettings.BodyTrackingMode))?.SetValue(Settings.MainSettings.BodyTrackingMode);
							mainSettingsElement.Element(nameof(Settings.MainSettings.TrackedJointScoreThreshold))?.SetValue(Settings.MainSettings.TrackedJointScoreThreshold);
							mainSettingsElement.Element(nameof(Settings.MainSettings.InferredJointScoreThreshold))?.SetValue(Settings.MainSettings.InferredJointScoreThreshold);
						}

						var mediaPipePoseLandmarksSettingsElement = settingsElement.Element(nameof(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings));
						if (mediaPipePoseLandmarksSettingsElement != null && Settings.MediaPipePoseLandmarksBodyTrackingModeSettings != null)
						{
							mediaPipePoseLandmarksSettingsElement.Element(nameof(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings.MinPoseDetectionConfidence))?
								.SetValue(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings.MinPoseDetectionConfidence);
							mediaPipePoseLandmarksSettingsElement.Element(nameof(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings.MinPosePresenceConfidence))?
								.SetValue(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings.MinPosePresenceConfidence);
							mediaPipePoseLandmarksSettingsElement.Element(nameof(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings.MinTrackingConfidence))?
								.SetValue(Settings.MediaPipePoseLandmarksBodyTrackingModeSettings.MinTrackingConfidence);
						}

						var mediaPipeHandLandmarksSettingsElement = settingsElement.Element(nameof(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings));
						if (mediaPipeHandLandmarksSettingsElement != null && Settings.MediaPipeHandLandmarksBodyTrackingModeSettings != null)
						{
							mediaPipeHandLandmarksSettingsElement.Element(nameof(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.NumHands))?
								.SetValue(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.NumHands);
							mediaPipeHandLandmarksSettingsElement.Element(nameof(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.MinHandDetectionConfidence))?
								.SetValue(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.MinHandDetectionConfidence);
							mediaPipeHandLandmarksSettingsElement.Element(nameof(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.MinHandPresenceConfidence))?
								.SetValue(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.MinHandPresenceConfidence);
							mediaPipeHandLandmarksSettingsElement.Element(nameof(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.MinTrackingConfidence))?
								.SetValue(Settings.MediaPipeHandLandmarksBodyTrackingModeSettings.MinTrackingConfidence);
						}
					}

					xmlDoc.Save(CONFIG_FILE);
				}
			}
			catch (Exception ex)
			{
				MessageBoxUtils.ShowMessage($"Saving settings to configuration file failed - error message: {ex.Message}.", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		#endregion
	}
}
