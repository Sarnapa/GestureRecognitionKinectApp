using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.Predictions;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.MLNETProcUnit.Utils;

namespace GestureRecognition.Processing.MLNETProcUnit.GestureRecognition
{
	public class GestureRecognitionModelWrapper: ModelWrapper
	{
		#region Private fields
		private Type gestureDataViewType;
		private PredictionEngine<KinectGestureDataView, GesturePrediction> kinectPredictionEngine;
		private PredictionEngine<MediaPipeHandLandmarksGestureDataView, GesturePrediction> mediaPipeHandLandmarksPredictionEngine;
		#endregion

		#region Public properties
		public bool IsKinectGestureDataView
		{
			get
			{
				return this.gestureDataViewType != null && this.gestureDataViewType == typeof(KinectGestureDataView);
			}
		}

		public bool IsMediaPipeHandLandmarksGestureDataView
		{
			get
			{
				return this.gestureDataViewType != null && this.gestureDataViewType == typeof(MediaPipeHandLandmarksGestureDataView);
			}
		}

		public override bool IsLoaded
		{
			get
			{
				return this.model != null && ((this.IsKinectGestureDataView && this.kinectPredictionEngine != null)
					|| (this.IsMediaPipeHandLandmarksGestureDataView && this.mediaPipeHandLandmarksPredictionEngine != null));
			}
		}
		#endregion

		#region Constructors
		public GestureRecognitionModelWrapper(ModelWrapperParameters parameters) : base(parameters)
		{
			this.ModelUsageKind = ModelUsageKind.GestureRecognition;
		}
		#endregion

		#region Public methods
		public override SetDataResult SetData(BaseSetDataParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			SetDataResult result = null;
			if (parameters is GestureRecognitionModelSetDataParameters setDataParameters)
			{
				try
				{
					if (setDataParameters.IsData)
					{
						var (validationSuccess, errorMessage) = ValidateData(setDataParameters.Data);
						if (validationSuccess)
						{
							if (setDataParameters.TestFraction > 0d && setDataParameters.TestFraction < 1d)
							{
								var data = GetDataView(setDataParameters.Data);
								// It's a bit risky that the training may not work with some labels.
								// However, in ML.NET, you can't do it directly, you have to improvise. Maybe it's better to do it yourself at the GestureDataView level.
								var splitRes = this.mlContext.Data.TrainTestSplit(data, testFraction: setDataParameters.TestFraction, seed: this.seed);

								// For testing
								//var train = this.mlContext.Data.CreateEnumerable<KinectGestureDataView>(splitRes.TrainSet, reuseRowObject: false).ToArray();
								//var test = this.mlContext.Data.CreateEnumerable<KinectGestureDataView>(splitRes.TestSet, reuseRowObject: false).ToArray();

								this.trainData = splitRes.TrainSet;
								this.testData = splitRes.TestSet;
							}
							else
							{
								result = new SetDataResult()
								{
									ErrorKind = SetDataErrorKind.InvalidParameters,
									ErrorMessage = $"Invalid {nameof(GestureRecognitionModelSetDataParameters.TestFraction)} parameter value provided. " +
									$"Got: {setDataParameters.TestFraction}, expected: [0.0 - 1.0]."
								};
							}
						}
						else
						{
							result = new SetDataResult()
							{
								ErrorKind = SetDataErrorKind.InvalidParameters,
								ErrorMessage = $"Setting invalid data for gesture recognition model, error message - {errorMessage}."
							};
						}
					}
					else if (setDataParameters.IsTrainData || setDataParameters.IsTestData)
					{
						if (setDataParameters.IsTrainData)
						{
							var (trainDataValidationSuccess, trainDataValidationErrorMessage) = ValidateData(setDataParameters.TrainData);
							if (trainDataValidationSuccess)
							{
								this.trainData = GetDataView(setDataParameters.TrainData);
							}
							else
							{
								result = new SetDataResult()
								{
									ErrorKind = SetDataErrorKind.InvalidParameters,
									ErrorMessage = $"Setting invalid training data for gesture recognition model, error message - {trainDataValidationErrorMessage}."
								};
							}
						}

						if (result == null && setDataParameters.IsTestData)
						{
							var (testDataValidationSuccess, testDataValidationErrorMessage) = ValidateData(setDataParameters.TestData);
							if (testDataValidationSuccess)
							{
								this.testData = GetDataView(setDataParameters.TestData);
							}
							else
							{
								result = new SetDataResult()
								{
									ErrorKind = SetDataErrorKind.InvalidParameters,
									ErrorMessage = $"Setting invalid test data for gesture recognition model, error message - {testDataValidationErrorMessage}."
								};
							}
						}
					}
					else
					{
						result = new SetDataResult()
						{
							ErrorKind = SetDataErrorKind.InvalidParameters,
							ErrorMessage = $"Setting no data for gesture recognition model."
						};
					}
				}
				catch (Exception ex)
				{
					result = new SetDataResult()
					{
						ErrorKind = SetDataErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during gesture recognition model setting data, error message - {ex.Message}."
					};
				}
			}
			else
			{
				result = new SetDataResult()
				{
					ErrorKind = SetDataErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model setting data."
				};
			}

			if (this.IsTrainData || this.IsTestData)
			{
				result = new SetDataResult();
			}
			else if (result == null)
			{
				result = new SetDataResult()
				{
					ErrorKind = SetDataErrorKind.InvalidOutput,
					ErrorMessage = $"Setting training and test data for gesture recognition model failed."
				};
			}

			return result;
		}

		public override BaseTrainResult TrainModel(BaseTrainParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (this.IsLoaded)
			{
				return new GestureRecognitionModelTrainResult()
				{
					ErrorKind = TrainErrorKind.AlreadyLoadedModel,
					ErrorMessage = $"The model has already been trained. The training process has been abandoned.",
				};
			}

			BaseTrainResult result;
			if (parameters is GestureRecognitionModelTrainParameters trainParameters)
			{
				if (this.IsTrainData)
				{
					if (trainParameters.AlgorithmParams is FastForestParams fastForestParams)
					{
						try
						{
							IEstimator<ITransformer> prepareDataPipeline;
							string featuresCol;

							if (this.IsKinectGestureDataView)
								(prepareDataPipeline, featuresCol) = GestureRecognitionModelsPipelines.GetPrepareDataPipeline<KinectGestureDataView>(this.mlContext, this.seed, trainParameters);
							else
								(prepareDataPipeline, featuresCol) = GestureRecognitionModelsPipelines.GetPrepareDataPipeline<MediaPipeHandLandmarksGestureDataView>(this.mlContext, this.seed, trainParameters);

							var fastForestPipeline = GestureRecognitionModelsPipelines.GetFastForestPipeline(this.mlContext, this.seed, prepareDataPipeline, featuresCol, fastForestParams);

							this.model = fastForestPipeline.Fit(this.trainData);

							if (this.IsKinectGestureDataView)
								this.kinectPredictionEngine = this.mlContext.Model.CreatePredictionEngine<KinectGestureDataView, GesturePrediction>(this.model);
							else
								this.mediaPipeHandLandmarksPredictionEngine = this.mlContext.Model.CreatePredictionEngine<MediaPipeHandLandmarksGestureDataView, GesturePrediction>(this.model);

							result = new GestureRecognitionModelTrainResult();
						}
						catch (Exception ex)
						{
							result = new GestureRecognitionModelTrainResult()
							{
								ErrorKind = TrainErrorKind.UnexpectedError,
								ErrorMessage = $"Unexpected error during gesture recognition model training, error message - {ex.Message}."
							};
						}
					}
					else
					{
						result = new GestureRecognitionModelTrainResult()
						{
							ErrorKind = TrainErrorKind.InvalidParameters,
							ErrorMessage = $"Invalid parameters for gesture recognition model training - invalid algorithms parameters."
						};
					}
				}
				else
				{
					result = new GestureRecognitionModelTrainResult()
					{
						ErrorKind = TrainErrorKind.InvalidParameters,
						ErrorMessage = $"Invalid parameters for gesture recognition model training - no training data."
					};
				}
			}
			else
			{
				result = new GestureRecognitionModelTrainResult()
				{
					ErrorKind = TrainErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model training."
				};
			}

			return result;
		}

		public override BasePredictResult Predict(BasePredictParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (!this.IsLoaded)
			{
				return new GestureRecognitionModelPredictResult()
				{
					ErrorKind = PredictErrorKind.ModelNotLoaded,
					ErrorMessage = $"Gesture recognition model is not loaded. Prediction process has been abandoned."
				};
			}

			BasePredictResult result;
			if (parameters is GestureRecognitionModelPredictParameters predictParameters)
			{
				try
				{
					GesturePrediction gesturePrediction = null;
					if (this.IsKinectGestureDataView && predictParameters.GestureData is KinectGestureDataView kinectGestureData)
					{
						gesturePrediction = this.kinectPredictionEngine.Predict(kinectGestureData);
					}
					else if (this.IsMediaPipeHandLandmarksGestureDataView && predictParameters.GestureData is MediaPipeHandLandmarksGestureDataView mediaPipeHandLandmarksGestureData)
					{
						gesturePrediction = this.mediaPipeHandLandmarksPredictionEngine.Predict(mediaPipeHandLandmarksGestureData);
					}
					else
					{
						result = new GestureRecognitionModelPredictResult()
						{
							ErrorKind = PredictErrorKind.InvalidParameters,
							ErrorMessage = $"Invalid gesture data type for given gesture recognition model."
						};
					}

					if (!string.IsNullOrEmpty(gesturePrediction?.Label))
					{
						result = new GestureRecognitionModelPredictResult()
						{
							Prediction = gesturePrediction,
						};
					}
					else
					{
						result = new GestureRecognitionModelPredictResult()
						{
							ErrorKind = PredictErrorKind.InvalidOutput,
							ErrorMessage = $"Invalid predict result for given gesture recognition model."
						};
					}
				}
				catch (Exception ex)
				{
					result = new GestureRecognitionModelPredictResult()
					{
						ErrorKind = PredictErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during prediction process for given gesture recognition model. " +
							$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
					};
				}
			}
			else
			{
				result = new GestureRecognitionModelPredictResult()
				{
					ErrorKind = PredictErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model prediction process."
				};
			}

			return result;
		}

		public override EvaluateResult Evaluate(BaseEvaluateParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (!this.IsLoaded)
			{
				return new EvaluateResult()
				{
					ErrorKind = EvaluateErrorKind.ModelNotLoaded,
					ErrorMessage = $"Gesture recognition model is not loaded. Evaluation process has been abandoned."
				};
			}

			EvaluateResult result;
			if (parameters is GestureRecognitionModelEvaluateParameters evaluateParameters)
			{
				if (this.IsTestData)
				{
					try
					{
						var preds = this.model.Transform(this.testData);
						if (preds != null)
						{
							var evaluateRes = this.mlContext.MulticlassClassification.Evaluate(preds, 
								labelColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL,
								predictedLabelColumnName: GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_KEY_COL);
							if (evaluateRes != null)
							{
								MulticlassMetricsConsolePresenter.Print(evaluateRes, string.IsNullOrEmpty(evaluateParameters.EvaluationResultPresentationTitle) ?
									"Multiclass classifier evaluation" : evaluateParameters.EvaluationResultPresentationTitle);

								result = new EvaluateResult();
							}
							else
							{
								result = new EvaluateResult()
								{
									ErrorKind = EvaluateErrorKind.InvalidOutput,
									ErrorMessage = $"Transforming input data failed during gesture recognition model evaluation."
								};
							}
						}
						else
						{
							result = new EvaluateResult()
							{
								ErrorKind = EvaluateErrorKind.InvalidOutput,
								ErrorMessage = $"Gesture recognition model evaluation failed."
							};
						}
					}
					catch (Exception ex)
					{
						result = new EvaluateResult()
						{
							ErrorKind = EvaluateErrorKind.UnexpectedError,
							ErrorMessage = $"Unexpected error during gesture recognition model evaluation, error message - {ex.Message}."
						};
					}
				}
				else
				{
					result = new EvaluateResult()
					{
						ErrorKind = EvaluateErrorKind.InvalidParameters,
						ErrorMessage = $"Invalid parameters for gesture recognition model evaluation - no test data."
					};
				}
			}
			else
			{
				result = new EvaluateResult()
				{
					ErrorKind = EvaluateErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model evaluation process."
				};
			}

			return result;
		}

		public override LoadModelResult LoadModel(BaseLoadModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			LoadModelResult result;
			if (parameters is BaseClassLib.Structures.MLNET.LoadGestureRecognitionModelParameters loadParameters)
			{
				(bool fileExists, LoadModelResult fileNotExistResult) = CheckIfFileExists(loadParameters.Path);
				if (fileExists)
				{
					string modelFileExtension = Path.GetExtension(loadParameters.Path).ToLower();
					(bool supportedModelFileExtension, LoadModelResult unsupportedModelFileExtension)
						= CheckIfSupportedModelFileExtensionToLoad(modelFileExtension);
					if (supportedModelFileExtension)
					{
						ModelPath = loadParameters.Path;
						switch (modelFileExtension)
						{
							case Consts.ModelOnnxExtension:
								result = new LoadModelResult()
								{
									ErrorKind = LoadModelErrorKind.UnsupportedModelFileExtension,
									ErrorMessage = $"Unsupported model file extension for gesture recognition model: [{modelFileExtension}]. Only supported: [{Consts.ModelZipExtension}]]."
								};
								break;
							default:
								ModelKind = ModelKind.Standard;
								result = LoadStandardModel(loadParameters);
								break;
						}
					}
					else
					{
						result = unsupportedModelFileExtension;
					}
				}
				else
				{
					result = fileNotExistResult;
				}
			}
			else
			{
				result = new LoadModelResult()
				{
					ErrorKind = LoadModelErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model loading."
				};
			}

			return result;
		}

		public override SaveModelResult SaveModel(BaseSaveModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (!this.IsLoaded)
			{
				return new SaveModelResult()
				{
					ErrorKind = SaveModelErrorKind.ModelNotLoaded,
					ErrorMessage = $"Gesture recognition model is not loaded. Saving to file process has been abandoned."
				};
			}

			SaveModelResult result;
			if (parameters is SaveGestureRecognitionModelParameters saveParameters)
			{
				string modelFileExtension = Path.GetExtension(saveParameters.Path).ToLower();
				(bool supportedModelFileExtension, SaveModelResult unsupportedModelFileExtension)
					= CheckIfSupportedModelFileExtensionToSave(modelFileExtension);
				if (supportedModelFileExtension)
				{
					switch (modelFileExtension)
					{
						case Consts.ModelOnnxExtension:
							result = new SaveModelResult()
							{
								ErrorKind = SaveModelErrorKind.UnsupportedModelFileExtension,
								ErrorMessage = $"Unsupported model file extension for gesture recognition model: [{modelFileExtension}]. Only supported: [{Consts.ModelZipExtension}]]."
							};
							break;
						default:
							ModelKind = ModelKind.Standard;
							result = SaveStandardModel(saveParameters);
							break;
					}
				}
				else
				{
					result = unsupportedModelFileExtension;
				}
			}
			else
			{
				result = new SaveModelResult()
				{
					ErrorKind = SaveModelErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model saving to file."
				};
			}

			return result;
		}

		public override void Cleanup()
		{
			this.gestureDataViewType = null;
			this.model = null;

			this.kinectPredictionEngine?.Dispose();
			this.kinectPredictionEngine = null;

			this.mediaPipeHandLandmarksPredictionEngine?.Dispose();
			this.mediaPipeHandLandmarksPredictionEngine = null;

			this.trainData = null;
			this.testData = null;

			this.ModelPath = null;
		}
		#endregion

		#region Private methods

		#region Loading and saving gesture recognition models methods
		private LoadModelResult LoadStandardModel(BaseClassLib.Structures.MLNET.LoadGestureRecognitionModelParameters parameters)
		{
			try
			{
				this.model = this.mlContext.Model.Load(this.ModelPath, out DataViewSchema dataViewSchema);
				if (this.model == null)
				{
					return new LoadModelResult()
					{
						ErrorKind = LoadModelErrorKind.UnexpectedError,
						ErrorMessage = $"Loaded empty standard model for given model file path: [{this.ModelPath}]."
					};
				}

				var bestMatchingType = DataViewsUtils.GetBestMatchingType(dataViewSchema, [typeof(KinectGestureDataView), typeof(MediaPipeHandLandmarksGestureDataView)]);
				if (bestMatchingType == null)
				{
					return new LoadModelResult()
					{
						ErrorKind = LoadModelErrorKind.UnsupportedGestureDataViewType,
						ErrorMessage = $"Loaded standard model that does not match the supported types of GestureDataView. Model file path: [{this.ModelPath}]."
					};
				}

				this.gestureDataViewType = bestMatchingType;
				if (this.IsKinectGestureDataView)
					this.kinectPredictionEngine = this.mlContext.Model.CreatePredictionEngine<KinectGestureDataView, GesturePrediction>(this.model);
				else
					this.mediaPipeHandLandmarksPredictionEngine = this.mlContext.Model.CreatePredictionEngine<MediaPipeHandLandmarksGestureDataView, GesturePrediction>(this.model);

				return new LoadModelResult();
			}
			catch (Exception ex)
			{
				return new LoadModelResult()
				{
					ErrorKind = LoadModelErrorKind.UnexpectedError,
					ErrorMessage = $"Unexpected error during loading standard model for given model file path: [{this.ModelPath}]. " +
					$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
				};
			}
		}

		private SaveModelResult SaveStandardModel(SaveGestureRecognitionModelParameters parameters)
		{
			try
			{
				IDataView emptyData;
				if (this.IsKinectGestureDataView)
					emptyData = this.mlContext.Data.LoadFromEnumerable(new List<KinectGestureDataView>());
				else
					emptyData = this.mlContext.Data.LoadFromEnumerable(new List<MediaPipeHandLandmarksGestureDataView>());

				this.mlContext.Model.Save(this.model, emptyData.Schema, parameters.Path);
				
				if (string.IsNullOrEmpty(this.ModelPath))
					this.ModelPath = parameters.Path;

				return new SaveModelResult();
			}
			catch (Exception ex)
			{
				return new SaveModelResult()
				{
					ErrorKind = SaveModelErrorKind.UnexpectedError,
					ErrorMessage = $"Unexpected error during saving standard model to file. Model file path: [{this.ModelPath}]. " +
					$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
				};
			}
		}
		#endregion

		#region Data validating methods
		private (bool success, string errorMessage) ValidateData(GestureDataView[] data)
		{
			if (data == null || data.Length == 0)
				return (false, "No data.");

			if (!AllSameRuntimeType(data, out Type dataType))
				return (false, $"Various types of {nameof(GestureDataView)} have been provided.");

			if (this.gestureDataViewType != null)
			{
				if (dataType != this.gestureDataViewType)
					return (false, $"Invalid type of {nameof(GestureDataView)} has been provided. Got: {dataType.Name}, expected: {this.gestureDataViewType.Name}.");
			}
			else
			{
				if (dataType != typeof(KinectGestureDataView) && dataType != typeof(MediaPipeHandLandmarksGestureDataView))
					return (false, $"Invalid type of {nameof(GestureDataView)} has been provided.");

				this.gestureDataViewType = dataType;
			}

			return (true, string.Empty);
		}
		
		private static bool AllSameRuntimeType(GestureDataView[] data, out Type dataType)
		{
			dataType = null;
			if (data == null) 
				return false;

			var types = data.Select(x => x?.GetType()).Distinct().ToList();
			if (types.Count == 0) 
			{ 
				dataType = null; 
				return true; 
			} 
			if (types.Count == 1) 
			{ 
				dataType = types[0]; 
				return true; 
			}
			
			dataType = null;
			return false;
		}
		#endregion

		#region Other private methods
		private IDataView GetDataView(GestureDataView[] data)
		{
			IDataView result;
			if (this.gestureDataViewType == typeof(KinectGestureDataView))
				result = this.mlContext.Data.LoadFromEnumerable(data.Cast<KinectGestureDataView>());
			else if (this.gestureDataViewType == typeof(MediaPipeHandLandmarksGestureDataView))
				result = this.mlContext.Data.LoadFromEnumerable(data.Cast<MediaPipeHandLandmarksGestureDataView>());
			else
				result = this.mlContext.Data.LoadFromEnumerable(data);

			return result;
		}
		#endregion

		#endregion
	}
}
