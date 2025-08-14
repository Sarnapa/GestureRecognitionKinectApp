using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Utils;

namespace GestureRecognition.Processing.GestureRecognitionProcUnit
{
  public class GestureRecognitionManager
	{
		#region Private fields
		#endregion

		#region Public properties
		public bool IsGestureRecognitionModelLoaded
		{
			get
			{
				return true;
			}
		}
		#endregion

		#region Constructors
		public GestureRecognitionManager()
		{}
		#endregion

		#region Public methods
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
				message = $"Preparing gestures data file failed - reason: incompatible user tracking mode, expected: [{BodyTrackingMode.Kinect}, {BodyTrackingMode.MediaPipeHandLandmarks}]";
			}
			return new PrepareGesturesDataForRecognitionModelResult() { Success = success, ErrorMessage = message };
		}

		public LoadGestureRecognitionModelResult LoadGestureRecognitionModel(LoadGestureRecognitionModelParameters parameters)
		{
			return new LoadGestureRecognitionModelResult();
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

			//if (parameters.Features.IsValid)
			//{
			//	var gestureDataView = parameters.Features.MapToKinectGestureDataView(string.Empty);
			//	var modelInput = gestureDataView.MapToModelInput();
			//	try
			//	{
			//		var modelOutput = TGM1.Predict(modelInput);
			//		if (modelOutput != null && !string.IsNullOrEmpty(modelOutput.PredictedLabel))
			//		{
			//			float score = modelOutput.Score?.Max() ?? float.NaN;
			//			if (!float.IsNaN(score) && score > 0.5f)
			//			{
			//				success = true;
			//				gestureLabel = modelOutput.PredictedLabel;
			//			}
			//			else
			//			{
			//				gestureLabel = "Gesture unknown";
			//			}
			//		}
			//		else
			//		{
			//			gestureLabel = "Model return empty result";
			//		}
			//	}
			//	catch (Exception ex)
			//	{
			//		gestureLabel = "Error during gesture prediction";
			//	}
			//}
			//else
			//{
			//	gestureLabel = "Invalid features";
			//}

			return new RecognizeGestureResult(success, gestureLabel);
		}
		#endregion

		#region Private methods

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
