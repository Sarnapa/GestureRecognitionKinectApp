using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ML;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Utils;

namespace GestureRecognition.Processing.GestureRecognitionProcUnit
{
  public class GestureRecognitionManager
	{
		#region Private fields
		private Random rand = new Random();
		private MLContext mlContext;
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
		{
			this.mlContext = new MLContext(0);
		}
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

		public async Task<RecognizeGestureResult> RecognizeGesture(RecognizeGestureParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			bool success;
			string gestureText;

			if (rand.Next(2) > 0)
			{
				success = true;
				gestureText = "Gesture";
			}
			else
			{
				success = false;
				gestureText = "Failed";
			}

			await Task.Delay(3000);

			return new RecognizeGestureResult(success, gestureText);
		}
		#endregion

		#region Private methods

		#region Gestures from / to .csv files methods
		private List<GestureDataView> LoadGesturesDataFromFiles(string[] filesPaths)
		{
			if (filesPaths == null)
				throw new ArgumentNullException(nameof(filesPaths));

			var result = new List<GestureDataView>();

			foreach (string filePath in filesPaths) 
			{
				if (filePath.EndsWith(CsvHelperUtils.CsvFileExtension) && File.Exists(filePath))
				{
					var fileGestureData = CsvHelperUtils.GetGesturesFromFile(filePath);
					if (fileGestureData != null)
						result.AddRange(fileGestureData);
				}
			}

			return result;
		}

		private bool SaveGesturesData(List<GestureDataView> gestures, string filePath)
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
