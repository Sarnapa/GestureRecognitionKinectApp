using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.Predictions;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.MLNETProcUnit.Utils;
using GestureRecognitionModelColumnsConsts = GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.GestureRecognitionModelColumnsConsts;

namespace GestureRecognition.Processing.MLNETProcUnit.GestureRecognition
{
	public class GestureRecognitionModelWrapper: ModelWrapper
		<GestureRecognitionModelSetDataParameters,
		GestureRecognitionModelTrainParameters, GestureRecognitionModelTrainResult,
		GestureRecognitionModelPredictParameters, GestureRecognitionModelPredictResult,
		GestureRecognitionModelEvaluateParameters, GestureRecognitionModelEvaluateResult,
		GestureRecognitionModelCrossValidateParameters, GestureRecognitionModelCrossValidateResult,
		LoadGestureRecognitionModelParameters,
		SaveGestureRecognitionModelParameters>
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
		public override SetDataResult SetData(GestureRecognitionModelSetDataParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			SetDataResult result = null;
			try
			{
				if (parameters.IsData)
				{
					var (validationSuccess, errorMessage) = ValidateData(parameters.Data);
					if (validationSuccess)
					{
						if (parameters.TestFraction > 0d && parameters.TestFraction < 1d)
						{
							var data = GetDataView(parameters.Data);
							// It's a bit risky that the training may not work with some labels.
							// However, in ML.NET, you can't do it directly, you have to improvise. Maybe it's better to do it yourself at the GestureDataView level.
							var splitRes = this.mlContext.Data.TrainTestSplit(data, testFraction: parameters.TestFraction, seed: this.seed);

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
								$"Got: {parameters.TestFraction}, expected: [0.0 - 1.0]."
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
				else if (parameters.IsTrainData || parameters.IsTestData)
				{
					if (parameters.IsTrainData)
					{
						var (trainDataValidationSuccess, trainDataValidationErrorMessage) = ValidateData(parameters.TrainData);
						if (trainDataValidationSuccess)
						{
							this.trainData = GetDataView(parameters.TrainData);
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

					if (result == null && parameters.IsTestData)
					{
						var (testDataValidationSuccess, testDataValidationErrorMessage) = ValidateData(parameters.TestData);
						if (testDataValidationSuccess)
						{
							this.testData = GetDataView(parameters.TestData);
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

		public override GestureRecognitionModelTrainResult TrainModel(GestureRecognitionModelTrainParameters parameters)
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

			GestureRecognitionModelTrainResult result;
			if (this.IsTrainData)
			{
				if (parameters.AlgorithmParams is FastForestParams fastForestParams)
				{
					try
					{
						var (fastForestPipeline, featuresCol) = GetModelPipeline(parameters, fastForestParams);
						this.model = fastForestPipeline.Fit(this.trainData);						
						CreatePredictionEngine();

						result = GetModelTrainResult(this.model, parameters, featuresCol);
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

			return result;
		}

		public override GestureRecognitionModelPredictResult Predict(GestureRecognitionModelPredictParameters parameters)
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

			GestureRecognitionModelPredictResult result;
			try
			{
				GesturePrediction gesturePrediction = null;
				if (this.IsKinectGestureDataView && parameters.GestureData is KinectGestureDataView kinectGestureData)
				{
					gesturePrediction = this.kinectPredictionEngine.Predict(kinectGestureData);
				}
				else if (this.IsMediaPipeHandLandmarksGestureDataView && parameters.GestureData is MediaPipeHandLandmarksGestureDataView mediaPipeHandLandmarksGestureData)
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

			return result;
		}

		public override GestureRecognitionModelEvaluateResult Evaluate(GestureRecognitionModelEvaluateParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (!this.IsLoaded)
			{
				return new GestureRecognitionModelEvaluateResult()
				{
					ErrorKind = EvaluateErrorKind.ModelNotLoaded,
					ErrorMessage = $"Gesture recognition model is not loaded. Evaluation process has been abandoned."
				};
			}

			GestureRecognitionModelEvaluateResult result;
			if (this.IsTestData)
			{
				try
				{
					var preds = this.model.Transform(this.testData);

					MulticlassClassificationMetrics evaluateRes = null;
					if (preds != null)
					{
						evaluateRes = this.mlContext.MulticlassClassification.Evaluate(preds,
							labelColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL,
							predictedLabelColumnName: GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_KEY_COL);
					}

					result = GetModelEvaluateResult(preds, evaluateRes);
				}
				catch (Exception ex)
				{
					result = new GestureRecognitionModelEvaluateResult()
					{
						ErrorKind = EvaluateErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during gesture recognition model evaluation, error message - {ex.Message}."
					};
				}
			}
			else
			{
				result = new GestureRecognitionModelEvaluateResult()
				{
					ErrorKind = EvaluateErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model evaluation - no test data."
				};
			}

			return result;
		}

		public override GestureRecognitionModelCrossValidateResult CrossValidate(GestureRecognitionModelCrossValidateParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			GestureRecognitionModelCrossValidateResult result;
			if (this.IsTrainData)
			{
				if (parameters.TrainParams != null)
				{
					if (parameters.TrainParams.AlgorithmParams is FastForestParams fastForestParams)
					{
						try
						{
							var (fastForestPipeline, featuresCol) = GetModelPipeline(parameters.TrainParams, fastForestParams);
							var cvFoldsResults = this.mlContext.MulticlassClassification.CrossValidate(this.trainData, fastForestPipeline, parameters.FoldsCount,
								labelColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL, seed: this.seed);
							if (cvFoldsResults != null)
							{
								if (cvFoldsResults.Count > 0)
								{
									var foldsResults = new List<CrossValidationFoldResult<GestureRecognitionModelTrainResult, GestureRecognitionModelEvaluateResult>>();
									foreach (var cvFoldResult in cvFoldsResults)
									{
										var foldResult = new CrossValidationFoldResult<GestureRecognitionModelTrainResult, GestureRecognitionModelEvaluateResult>()
										{
											FoldIdx = cvFoldResult.Fold,
											TrainResult = GetModelTrainResult(cvFoldResult.Model, parameters.TrainParams, featuresCol),
											EvaluateResult = GetModelEvaluateResult(cvFoldResult.ScoredHoldOutSet, cvFoldResult.Metrics)
										};
										foldsResults.Add(foldResult);
									}

									result = new GestureRecognitionModelCrossValidateResult()
									{
										FoldsResults = foldsResults.ToArray()
									};
								}
								else
								{
									result = new GestureRecognitionModelCrossValidateResult()
									{
										ErrorKind = CrossValidateErrorKind.InvalidOutput,
										ErrorMessage = $"No fold results were obtained as a result of the cross-validation process."
									};
								}
							}
							else
							{
								result = new GestureRecognitionModelCrossValidateResult()
								{
									ErrorKind = CrossValidateErrorKind.InvalidOutput,
									ErrorMessage = $"Gesture recognition model cross validation process failed."
								};
							}
						}
						catch (Exception ex)
						{
							result = new GestureRecognitionModelCrossValidateResult()
							{
								ErrorKind = CrossValidateErrorKind.UnexpectedError,
								ErrorMessage = $"Unexpected error during gesture recognition model cross validation process, error message - {ex.Message}."
							};
						}
					}
					else
					{
						result = new GestureRecognitionModelCrossValidateResult()
						{
							ErrorKind = CrossValidateErrorKind.InvalidParameters,
							ErrorMessage = $"Invalid parameters for gesture recognition model cross validation process - invalid algorithms parameters."
						};
					}
				}
				else
				{
					result = new GestureRecognitionModelCrossValidateResult()
					{
						ErrorKind = CrossValidateErrorKind.InvalidParameters,
						ErrorMessage = $"Invalid parameters for gesture recognition model cross validation process - no training parameters."
					};
				}
			}
			else
			{
				result = new GestureRecognitionModelCrossValidateResult()
				{
					ErrorKind = CrossValidateErrorKind.InvalidParameters,
					ErrorMessage = $"Invalid parameters for gesture recognition model cross validation process - no training data."
				};
			}

			return result;
		}

		public override LoadModelResult LoadModel(LoadGestureRecognitionModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			LoadModelResult result;
			(bool fileExists, LoadModelResult fileNotExistResult) = CheckIfFileExists(parameters.Path);
			if (fileExists)
			{
				string modelFileExtension = Path.GetExtension(parameters.Path).ToLower();
				(bool supportedModelFileExtension, LoadModelResult unsupportedModelFileExtension)
					= CheckIfSupportedModelFileExtensionToLoad(modelFileExtension);
				if (supportedModelFileExtension)
				{
					ModelPath = parameters.Path;
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
							result = LoadStandardModel(parameters);
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

			return result;
		}

		public override SaveModelResult SaveModel(SaveGestureRecognitionModelParameters parameters)
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
			string modelFileExtension = Path.GetExtension(parameters.Path).ToLower();
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
						result = SaveStandardModel(parameters);
						break;
				}
			}
			else
			{
				result = unsupportedModelFileExtension;
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

		#region Model pipeline methods
		private (IEstimator<ITransformer> pipeline, string featuresCol) GetModelPipeline(GestureRecognitionModelTrainParameters parameters, FastForestParams fastForestParams)
		{
			IEstimator<ITransformer> prepareDataPipeline;
			string featuresCol;
			if (this.IsKinectGestureDataView)
				(prepareDataPipeline, featuresCol) = GestureRecognitionModelsPipelines.GetPrepareDataPipeline<KinectGestureDataView>(this.mlContext, this.seed, parameters);
			else
				(prepareDataPipeline, featuresCol) = GestureRecognitionModelsPipelines.GetPrepareDataPipeline<MediaPipeHandLandmarksGestureDataView>(this.mlContext, this.seed, parameters);

			var fastForestPipeline = GestureRecognitionModelsPipelines.GetFastForestPipeline(this.mlContext, this.seed, prepareDataPipeline, featuresCol, fastForestParams);
			return (fastForestPipeline, featuresCol);
		}
		#endregion

		#region Training methods
		private GestureRecognitionModelTrainResult GetModelTrainResult(ITransformer model, GestureRecognitionModelTrainParameters parameters, string featuresCol)
		{
			if (model == null)
			{
				return new GestureRecognitionModelTrainResult()
				{
					ErrorKind = TrainErrorKind.InvalidOutput,
					ErrorMessage = $"Gesture recognition model training failed."
				};
			}

			int? pcaComponentsCount = GetPcaComponentsCount(model, parameters, featuresCol);
			return new GestureRecognitionModelTrainResult()
			{
				PcaComponentsCount = pcaComponentsCount
			};
		}
		#endregion

		#region Prediction methods
		private void CreatePredictionEngine()
		{
			if (this.IsKinectGestureDataView)
				this.kinectPredictionEngine = this.mlContext.Model.CreatePredictionEngine<KinectGestureDataView, GesturePrediction>(this.model);
			else
				this.mediaPipeHandLandmarksPredictionEngine = this.mlContext.Model.CreatePredictionEngine<MediaPipeHandLandmarksGestureDataView, GesturePrediction>(this.model);
		}
		#endregion

		#region Evaluation methods
		private GestureRecognitionModelEvaluateResult GetModelEvaluateResult(IDataView preds, MulticlassClassificationMetrics evaluateRes)
		{
			GestureRecognitionModelEvaluateResult result;
			if (preds != null)
			{
				if (evaluateRes != null)
				{
					var labelsDict = GetLabelsDict(preds);
					if (labelsDict != null && labelsDict.Count > 0)
					{
						var multiclassClassificationEvalResult = MulticlassClassificationUtils.PrepareResult(evaluateRes, labelsDict);
						result = new GestureRecognitionModelEvaluateResult()
						{
							MulticlassClassificationEvalResult = multiclassClassificationEvalResult
						};
					}
					else
					{
						result = new GestureRecognitionModelEvaluateResult()
						{
							ErrorKind = EvaluateErrorKind.InvalidOutput,
							ErrorMessage = $"Getting labels failed during gesture recognition model evaluation."
						};
					}
				}
				else
				{
					result = new GestureRecognitionModelEvaluateResult()
					{
						ErrorKind = EvaluateErrorKind.InvalidOutput,
						ErrorMessage = $"Gesture recognition model evaluation failed."
					};
				}
			}
			else
			{
				result = new GestureRecognitionModelEvaluateResult()
				{
					ErrorKind = EvaluateErrorKind.InvalidOutput,
					ErrorMessage = $"Transforming input data failed during gesture recognition model evaluation."
				};
			}

			return result;
		}
		#endregion

		#region Loading and saving gesture recognition models methods
		private LoadModelResult LoadStandardModel(LoadGestureRecognitionModelParameters parameters)
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

		private int? GetPcaComponentsCount(ITransformer model, GestureRecognitionModelTrainParameters parameters, string featuresCol)
		{
			int? pcaComponentsCount = null;
			if (parameters.UsePca && featuresCol == GestureRecognitionModelColumnsConsts.FEATURES_PCA_COL)
			{
				var dataView = model.Transform(this.trainData);
				if (dataView.Schema != null)
				{
					var pcaComponentsCol = dataView.Schema.GetColumnOrNull(featuresCol);
					if (pcaComponentsCol.HasValue && pcaComponentsCol.Value.Type is VectorDataViewType vectorType)
						pcaComponentsCount = vectorType.Size;
				}
			}

			return pcaComponentsCount;
		}

		private Dictionary<int, string> GetLabelsDict(IDataView preds)
		{
			Dictionary<int, string> labelsDict = null;
			var predictedLabelKeyCol = preds.Schema.GetColumnOrNull(GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_KEY_COL);
			if (predictedLabelKeyCol.HasValue && predictedLabelKeyCol.Value.HasKeyValues())
			{
				VBuffer<ReadOnlyMemory<char>> kv = default;
				predictedLabelKeyCol.Value.GetKeyValues(ref kv);
				if (kv.Length > 0)
				{
					labelsDict = kv.Items().ToDictionary(kv => kv.Key, kv => kv.Value.ToString());
				}
			}
			
			return labelsDict;
		}
		#endregion

		#endregion
	}
}
