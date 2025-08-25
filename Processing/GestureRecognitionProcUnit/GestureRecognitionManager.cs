using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.MLNETProcUnit.GestureRecognition;
using LoadGestureRecognitionModelParameters = GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.LoadGestureRecognitionModelParameters;
using MLNETLoadGestureRecognitionModelParameters = GestureRecognition.Processing.BaseClassLib.Structures.MLNET.LoadGestureRecognitionModelParameters;

namespace GestureRecognition.Processing.GestureRecognitionProcUnit
{
  public class GestureRecognitionManager
	{
		#region Private fields
		private GestureRecognitionModelWrapper modelWrapper;
		#endregion

		#region Public properties
		public bool IsGestureRecognitionModelLoaded
		{
			get
			{
				return this.modelWrapper != null && this.modelWrapper.IsLoaded;
			}
		}

		public string GestureRecognitionModelPath
		{
			get
			{
				return this.modelWrapper?.ModelPath ?? string.Empty;
			}
		}

		public BodyTrackingMode? CompatibleTrackingMode
		{
			get
			{
				if (this.modelWrapper != null)
				{
					if (this.modelWrapper.IsKinectGestureDataView)
						return BodyTrackingMode.Kinect;
					else if (this.modelWrapper.IsMediaPipeHandLandmarksGestureDataView)
						return BodyTrackingMode.MediaPipeHandLandmarks;
				}

				return null;
			}
		}
		#endregion

		#region Constructors
		public GestureRecognitionManager()
		{}
		#endregion

		#region Public methods
		// Unnecessary, possibly to be sorted out later.
		public PrepareGesturesDataForRecognitionModelResult PrepareGesturesDataForRecognitionModel(PrepareGesturesDataForRecognitionModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			bool success = false;
			string message = string.Empty;

			if (parameters.TrackingMode == BodyTrackingMode.Kinect || parameters.TrackingMode == BodyTrackingMode.MediaPipeHandLandmarks)
			{
				if (parameters.TrackingMode == BodyTrackingMode.Kinect)
				{
					(success, message) = LoadAndSaveGesturesData<KinectGestureDataView>(parameters);
				}
				else
				{
					(success, message) = LoadAndSaveGesturesData<MediaPipeHandLandmarksGestureDataView>(parameters);
				}
			}
			else
			{
				message = $"Preparing gestures data file failed - reason: incompatible user tracking mode, expected: [{BodyTrackingMode.Kinect}, {BodyTrackingMode.MediaPipeHandLandmarks}].";
			}
			return new PrepareGesturesDataForRecognitionModelResult() { Success = success, ErrorMessage = message };
		}

		public LoadGestureRecognitionModelResult LoadGestureRecognitionModel(LoadGestureRecognitionModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			bool success = false;
			string message = string.Empty;

			var (supportedTrackingModeSuccess, supportedTrackingModeMessage) = CheckIfSupportedTrackingMode(parameters.TrackingMode);
			if (!supportedTrackingModeSuccess)
			{
				message = $"Loading gesture recognition model failed - reason: {supportedTrackingModeMessage}.";
				return new LoadGestureRecognitionModelResult() { Success = success, ErrorMessage = message };
			}

			var newModelWrapper = new GestureRecognitionModelWrapper(new ModelWrapperParameters() { Seed = 42 });
			var loadResult = newModelWrapper.LoadModel(new MLNETLoadGestureRecognitionModelParameters()
			{
				Path = parameters.Path,
			});

			if (loadResult.IsSuccess)
			{
				var (modelDataTypeCompatibilitySuccess, modelDataTypeCompatibilityMessage) = CheckModelDataTypeCompatibility(newModelWrapper, parameters.TrackingMode);
				if (!modelDataTypeCompatibilitySuccess)
				{
					message = $"Loading gesture recognition model failed - reason: {modelDataTypeCompatibilityMessage}.";
					newModelWrapper.Cleanup();
				}
				else
				{
					if (this.modelWrapper != null)
					{
						this.modelWrapper.Cleanup();
						this.modelWrapper = null;
					}

					this.modelWrapper = newModelWrapper;
					success = true;
				}
			}
			else
			{
				message = loadResult.ErrorMessage;
			}

			return new LoadGestureRecognitionModelResult() { Success = success, ErrorMessage = message };
		}

		public async Task<RecognizeGestureResult> RecognizeGestureAsync(RecognizeGestureParameters parameters)
		{
			return await Task.Run(() => RecognizeGesture(parameters));
		}

		public RecognizeGestureResult RecognizeGesture(RecognizeGestureParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));
			if (parameters.Features == null)
				throw new ArgumentNullException(nameof(parameters.Features));

			bool success = false;
			string gestureLabel = string.Empty;

			if (!this.IsGestureRecognitionModelLoaded)
			{
				gestureLabel = "Gesture recognition model is not loaded";
				return new RecognizeGestureResult(success, gestureLabel);
			}

			var (supportedTrackingModeSuccess, supportedTrackingModeMessage) = CheckIfSupportedTrackingMode(parameters.TrackingMode);
			if (!supportedTrackingModeSuccess)
			{
				gestureLabel = supportedTrackingModeMessage;
				return new RecognizeGestureResult(success, gestureLabel);
			}

			var (modelDataTypeCompatibilitySuccess, modelDataTypeCompatibilityMessage) = CheckModelDataTypeCompatibility(this.modelWrapper, parameters.TrackingMode);
			if (!modelDataTypeCompatibilitySuccess)
			{
				gestureLabel = modelDataTypeCompatibilityMessage;
				return new RecognizeGestureResult(success, gestureLabel);
			}

			if (parameters.Features.IsValid)
			{
				try
				{
					GestureDataView gestureDataView = null;
					if (parameters.TrackingMode == BodyTrackingMode.Kinect)
						gestureDataView = parameters.Features.MapToKinectGestureDataView(string.Empty);
					else
						gestureDataView = parameters.Features.MapToMediaPipeHandLandmarksGestureDataView(string.Empty);

					var predictParameters = new GestureRecognitionModelPredictParameters()
					{
						GestureData = gestureDataView
					};

					var predictResult = this.modelWrapper.Predict(predictParameters);
					if (predictResult.IsSuccess && predictResult.Prediction != null)
					{
						var prediction = predictResult.Prediction;

						if (prediction.Scores != null && prediction.LabelKey <= prediction.Scores.Length)
						{
							float score = prediction.Scores[prediction.LabelKey - 1];
							if (!float.IsNaN(score) && score >= parameters.ScoreThreshold)
							{
								success = true;
								gestureLabel = prediction.Label;
							}
							else
							{
								gestureLabel = "Gesture unknown";
							}
						}
						else
						{
							gestureLabel = "Gesture unknown";
						}
					}
					else
					{
						gestureLabel = "Gesture prediction failed";
					}
				}
				catch (Exception)
				{
					gestureLabel = "Error during gesture prediction";
				}
			}
			else
			{
				gestureLabel = "Invalid features";
			}

			return new RecognizeGestureResult(success, gestureLabel);
		}

		public void UnloadGestureRecognitionModel()
		{
			if (this.modelWrapper != null)
			{
				this.modelWrapper.Cleanup();
				this.modelWrapper = null;
			}
		}
		#endregion

		#region Private methods

		#region Validation methods
		private (bool success, string message) CheckIfSupportedTrackingMode(BodyTrackingMode trackingMode)
		{
			bool success = false;
			string message = string.Empty;
			if (trackingMode == BodyTrackingMode.Kinect || trackingMode == BodyTrackingMode.MediaPipeHandLandmarks)
				success = true;
			else
				message = $"Incompatible user tracking mode, expected: [{BodyTrackingMode.Kinect}, {BodyTrackingMode.MediaPipeHandLandmarks}]";
			return (success, message);
		}

		private (bool success, string message) CheckModelDataTypeCompatibility(GestureRecognitionModelWrapper modelWrapper, BodyTrackingMode trackingMode)
		{
			bool success = true;
			string message = string.Empty;
			if (trackingMode == BodyTrackingMode.Kinect && !modelWrapper.IsKinectGestureDataView)
			{
				success = false;
				message = $"Incompatible model data type with body tracking mode, expected: {BodyTrackingMode.Kinect}";
			}
			else if (trackingMode == BodyTrackingMode.MediaPipeHandLandmarks && !modelWrapper.IsMediaPipeHandLandmarksGestureDataView)
			{
				success = false;
				message = $"Incompatible model data type with body tracking mode, expected: {BodyTrackingMode.MediaPipeHandLandmarks}";
			}

			return (success, message);
		}
		#endregion

		#region Gestures from / to .csv files methods
		private static (bool success, string message) LoadAndSaveGesturesData<T>(PrepareGesturesDataForRecognitionModelParameters parameters)
			where T : GestureDataView
		{
			bool success = false;
			string message = string.Empty;

			T[] gesturesData = null;
			try
			{
				gesturesData = LoadGesturesDataFromFiles<T>(parameters.GestureDataFilesPaths);
			}
			catch (Exception ex)
			{
				message = $"Preparing gestures data file failed - reason: error during reading gestures data from file, error message: {ex.Message}";
			}

			if (gesturesData != null)
			{
				try
				{
					SaveGesturesData(gesturesData, parameters.GesturesDataOutputFilePath);
					success = true;
				}
				catch (Exception ex)
				{
					message = $"Preparing gestures data file failed - reason: error during saving gestures data to file, error message: {ex.Message}";
				}
			}

			return (success, message);
		}

		private static T[] LoadGesturesDataFromFiles<T>(string[] filesPaths)
			where T: GestureDataView
		{
			if (filesPaths == null)
				throw new ArgumentNullException(nameof(filesPaths));

			var result = new List<T>();

			foreach (string filePath in filesPaths) 
			{
				if (filePath.EndsWith(CsvHelperUtils.CsvFileExtension) && File.Exists(filePath))
				{
					var fileGestureData = CsvHelperUtils.GetGesturesFromFile<T>(filePath);
					if (fileGestureData != null)
						result.AddRange(fileGestureData);
				}
			}

			return result.ToArray();
		}

		private static void SaveGesturesData<T>(T[] gestures, string filePath)
			where T : GestureDataView
		{
			if (gestures == null) 
				throw new ArgumentNullException(nameof(gestures));
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException(nameof(filePath));

			CsvHelperUtils.WriteGesturesToFile(gestures, filePath);
		}
		#endregion

		#endregion
	}
}
