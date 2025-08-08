using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.GestureRecognitionProcUnit.Models.TGM1;

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

			var gesturesData = LoadGesturesDataFromFiles(parameters.GestureDataFilesPaths);
			bool success = SaveGesturesData(gesturesData, parameters.GesturesDataOutputFilePath);
			return new PrepareGesturesDataForRecognitionModelResult() { Success = success };
		}

		public CreateGestureRecognitionModelResult CreateGestureRecognitionModel(CreateGestureRecognitionModelParameters parameters)
		{
			return new CreateGestureRecognitionModelResult();
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

			if (parameters.Features.IsValid)
			{
				var gestureDataView = parameters.Features.MapToKinectGestureDataView(string.Empty);
				var modelInput = gestureDataView.MapToModelInput();
				try
				{
					var modelOutput = TGM1.Predict(modelInput);
					if (modelOutput != null && !string.IsNullOrEmpty(modelOutput.PredictedLabel))
					{
						float score = modelOutput.Score?.Max() ?? float.NaN;
						if (!float.IsNaN(score) && score > 0.5f)
						{
							success = true;
							gestureLabel = modelOutput.PredictedLabel;
						}
						else
						{
							gestureLabel = "Gesture unknown";
						}
					}
					else
					{
						gestureLabel = "Model return empty result";
					}
				}
				catch (Exception ex)
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
		#endregion

		#region Private methods

		#region Gestures from / to .csv files methods
		private List<KinectGestureDataView> LoadGesturesDataFromFiles(string[] filesPaths)
		{
			if (filesPaths == null)
				throw new ArgumentNullException(nameof(filesPaths));

			var result = new List<KinectGestureDataView>();

			foreach (string filePath in filesPaths) 
			{
				if (filePath.EndsWith(CsvHelperUtils.CsvFileExtension) && File.Exists(filePath))
				{
					var fileGestureData = CsvHelperUtils.GetGesturesFromFile<KinectGestureDataView>(filePath);
					if (fileGestureData != null)
						result.AddRange(fileGestureData);
				}
			}

			return result;
		}

		private bool SaveGesturesData(List<KinectGestureDataView> gestures, string filePath)
		{
			if (gestures == null) 
				throw new ArgumentNullException(nameof(gestures));
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException(nameof(filePath));

			try
			{
				CsvHelperUtils.WriteGesturesToFile(gestures, filePath);
				return true;
			}
			catch (Exception e)
			{
				// TODO: Handle exception in better way.
				return false;
			}
		}
		#endregion

		#endregion
	}
}
