using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Export;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Result;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.MLNETProcUnit.GestureRecognition;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel
{
	public class GestureRecognitionModelManager
	{
		#region Private fields
		private readonly int seed;
		#endregion

		#region Constructors
		public GestureRecognitionModelManager(int seed)
		{
			this.seed = seed;
		}
		#endregion

		#region Public methods
		public async Task ExecuteModelTuneHyperparamsTrainingAndEvaluationProcess(ModelTuneHyperparamsTrainingAndEvaluationProcessParameters parameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelTuneHyperparamsTrainingAndEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model tuning hyperparams, training and evaluation process started.");
			ConsoleOutputUtils.WriteLine(methodName, $"\n{parameters}");

			var modelWrapper = InitializeModelWrapper();
			var (_, isSetDataSuccess) = SetData(modelWrapper, parameters.SetDataParams);
			if (isSetDataSuccess)
			{
				var (tuneHyperparamsResult, isTuneHyperparamsSuccess) = await TuneModelHyperparams(modelWrapper, parameters.TuneHyperparamsParams).ConfigureAwait(false);
				if (isTuneHyperparamsSuccess)
				{
					var trainParams = new GestureRecognitionModelTrainParameters()
					{
						ExcludedFeatures = parameters.TuneHyperparamsParams.ExcludedFeatures,
						PrepareDataHyperparams = tuneHyperparamsResult.PrepareDataHyperparams,
						AlgorithmParams = tuneHyperparamsResult.AlgorithmParams
					};

					ExecuteModelTrainingAndEvaluationProcessInternal(modelWrapper, parameters.SetDataParams,
						trainParams, parameters.EvaluationParams,
						parameters.DataFilePath, parameters.TrainDataFilePath, parameters.TestDataFilePath,
						parameters.UseCv, parameters.CvFoldsCount, parameters.ModelCvProcessResultFilePath,
						parameters.ModelFilePath, parameters.ModelProcessResultFilePath);
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process finished.");
		}

		public void ExecuteModelTrainingAndEvaluationProcess(ModelTrainingAndEvaluationProcessParameters parameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelTrainingAndEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process started.");
			ConsoleOutputUtils.WriteLine(methodName, $"\n{parameters}");

			var modelWrapper = InitializeModelWrapper();
			var (_, isSetDataSuccess) = SetData(modelWrapper, parameters.SetDataParams);
			if (isSetDataSuccess)
			{
				ExecuteModelTrainingAndEvaluationProcessInternal(modelWrapper, parameters.SetDataParams,
					parameters.TrainingParams, parameters.EvaluationParams,
					parameters.DataFilePath, parameters.TrainDataFilePath, parameters.TestDataFilePath,
					parameters.UseCv, parameters.CvFoldsCount, parameters.ModelCvProcessResultFilePath,
					parameters.ModelFilePath, parameters.ModelProcessResultFilePath);
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process finished.");
		}

		public void ExecuteModelEvaluationProcess(ModelEvaluationProcessParameters parameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process started.");

			ConsoleOutputUtils.WriteLine(methodName, $"\n{parameters}");

			var modelWrapper = InitializeModelWrapper();
			if (LoadModel(modelWrapper, parameters.ModelFilePath))
			{
				var (_, isSetDataSuccess) = SetData(modelWrapper, parameters.SetTestDataParameters);
				if (isSetDataSuccess)
				{
					var (evaluateModelResult, isEvaluateModelSuccess) = EvaluateModel(modelWrapper, parameters.EvaluationParams);
					if (isEvaluateModelSuccess && evaluateModelResult != null && !string.IsNullOrEmpty(parameters.ModelProcessResultFilePath))
					{
						var evaluationProcessResult = GetModelProcessResult(parameters.ModelProcessResultFilePath,
							parameters.ModelFilePath, null, this.seed, parameters.SetTestDataParameters,
							string.Empty, string.Empty, parameters.TestDataFilePath,
							null, null, evaluateModelResult);
						if (evaluationProcessResult != null)
							ExportToCsv(parameters.ModelProcessResultFilePath, [evaluationProcessResult]);
					}
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process finished.");
		}

		public void ExecuteModelPredictionsPerformanceTest(ModelPredictionsPerformanceTestParameters parameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelPredictionsPerformanceTest)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model predictions performance test started.");

			ConsoleOutputUtils.WriteLine(methodName, $"\n{parameters}");

			var modelWrapper = InitializeModelWrapper();
			if (LoadModel(modelWrapper, parameters.ModelFilePath))
			{
				var predictionsDurations = new List<int>();
				for (int i = 0; i < parameters.TestsCount; i++)
				{
					for (int j = 0; j < parameters.GesturesData.Length; j++)
					{
						var gestureData = parameters.GesturesData[j];
						var (_, predictDuration, isSuccess) = Predict(modelWrapper, gestureData, j);
						if (isSuccess)
							predictionsDurations.Add(predictDuration);
					}
				}

				ConsoleOutputUtils.WriteLine(methodName, $"Number of successful gesture predictions: {predictionsDurations.Count}");
				if (predictionsDurations.Count > 0)
				{
					ExportPredictionPerformanceTestResultToCsv(parameters.ResultFilePath, new ModelPredictionsPerformanceTestResult()
					{
						PredictionsInfo = predictionsDurations.Select(d => new PredictionPerformanceInfo() { DurationMicroseconds = d }).ToArray()
					});
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model predictions performance test finished.");
		}
		#endregion

		#region Private methods
		private GestureRecognitionModelWrapper InitializeModelWrapper()
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(InitializeModelWrapper)}";

			ConsoleOutputUtils.WriteLine(methodName, "Initializing model wrapper started...");

			var modelWrapperParams = new ModelWrapperParameters()
			{
				Seed = this.seed,
			};
			var modelWrapper = new GestureRecognitionModelWrapper(modelWrapperParams);

			ConsoleOutputUtils.WriteLine(methodName, "Initializing model wrapper succeeded.");

			return modelWrapper;
		}

		private (SetDataResult result, bool isSuccess) SetData(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelSetDataParameters setDataParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(SetData)}";

			ConsoleOutputUtils.WriteLine(methodName, "Setting data started...");

			var setDataResult = modelWrapper.SetData(setDataParams);
			if (setDataResult.IsSuccess)
				ConsoleOutputUtils.WriteLine(methodName, "Setting data succeeded.");
			else
				ConsoleOutputUtils.WriteLine(methodName, setDataResult.ErrorMessage);

			return (setDataResult, setDataResult.IsSuccess);
		}

		private async Task<(GestureRecognitionModelTuneHyperparamsResult result, bool isSuccess)> TuneModelHyperparams(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelTuneHyperparamsParameters tuneHyperparamsParameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(TuneModelHyperparams)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model tuning hyperparams process started...");

			var tuneHyperparamsResult = await modelWrapper.TuneHyperparams(tuneHyperparamsParameters).ConfigureAwait(false);
			if (tuneHyperparamsResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"\nModel tuning hyperparams process result:\n\n{tuneHyperparamsResult}");
				ConsoleOutputUtils.WriteLine(methodName, "Model tuning hyperparams process succeeded.");
			}
			else
				ConsoleOutputUtils.WriteLine(methodName, tuneHyperparamsResult.ErrorMessage);

			return (tuneHyperparamsResult, tuneHyperparamsResult.IsSuccess);
		}

		private void ExecuteModelTrainingAndEvaluationProcessInternal(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelSetDataParameters setDataParams,
			GestureRecognitionModelTrainParameters trainParams, GestureRecognitionModelEvaluateParameters evaluateParams,
			string? dataFilePath, string? trainDataFilePath, string? testDataFilePath,
			bool useCv, int cvFoldsCount, string? modelCvProcessResultFilePath,
			string? modelFilePath, string? modelProcessResultFilePath
			)
		{
			if (useCv)
			{
				var crossValidateParams = new GestureRecognitionModelCrossValidateParameters()
				{
					FoldsCount = cvFoldsCount,
					TrainParams = trainParams,
					EvaluateParams = evaluateParams
				};

				CrossValidateModel(modelWrapper, crossValidateParams, modelCvProcessResultFilePath, this.seed,
					setDataParams, dataFilePath, trainDataFilePath);
			}

			var (trainModelResult, isTrainModelSuccess) = TrainModel(modelWrapper, trainParams);
			if (isTrainModelSuccess && trainModelResult != null)
			{
				var (evaluateModelResult, isEvaluateModelSuccess) = EvaluateModel(modelWrapper, evaluateParams);
				if (isEvaluateModelSuccess && evaluateModelResult != null)
				{
					if (!string.IsNullOrEmpty(modelFilePath))
					{
						if (SaveModel(modelWrapper, modelFilePath)
							&& !string.IsNullOrEmpty(modelProcessResultFilePath))
						{
							var trainingAndEvaluationProcessResult = GetModelProcessResult(modelProcessResultFilePath,
								modelFilePath, null, this.seed, setDataParams,
								dataFilePath, trainDataFilePath, testDataFilePath,
								trainParams, trainModelResult, evaluateModelResult);
							if (trainingAndEvaluationProcessResult != null)
								ExportToCsv(modelProcessResultFilePath, [trainingAndEvaluationProcessResult]);
						}
					}
				}
			}
		}

		private bool CrossValidateModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelCrossValidateParameters crossValidateParams,
			string? modelCvProcessResultFilePath, int seed, GestureRecognitionModelSetDataParameters setDataParameters, string? dataFilePath, string? trainDataFilePath)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(CrossValidateModel)}";

			if (string.IsNullOrEmpty(modelCvProcessResultFilePath))
			{
				ConsoleOutputUtils.WriteLine(methodName, "The cross validation process only supports saving results to a file. An empty file path was received, so the process was aborted.");
				return false;
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model cross validation process started...");

			var crossValidateResult = modelWrapper.CrossValidate(crossValidateParams);
			if (crossValidateResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Received results for {crossValidateResult.FoldsResults?.Length ?? 0} folds.");

				var foldsResults = new List<ModelProcessResult>();
				if (crossValidateResult.FoldsResults != null)
				{
					foreach (var cvResult in crossValidateResult.FoldsResults)
					{
						var foldResult = GetModelProcessResult(modelCvProcessResultFilePath, string.Empty, cvResult.FoldIdx, seed, setDataParameters, dataFilePath, trainDataFilePath, string.Empty,
							crossValidateParams.TrainParams, cvResult.TrainResult, cvResult.EvaluateResult);

						if (foldResult != null)
							foldsResults.Add(foldResult);
					}
				}

				ConsoleOutputUtils.WriteLine(methodName, $"After validating the results, attempt will be made to save the results for {foldsResults.Count} folds.");
				ExportToCsv(modelCvProcessResultFilePath, foldsResults.ToArray());

				ConsoleOutputUtils.WriteLine(methodName, "Model cross validation process finished. ");
			}
			else
				ConsoleOutputUtils.WriteLine(methodName, crossValidateResult.ErrorMessage);

			return crossValidateResult.IsSuccess;
		}

		private (GestureRecognitionModelTrainResult? result, bool isSuccess) TrainModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelTrainParameters trainParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(TrainModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model training process started...");

			var trainResult = modelWrapper.TrainModel(trainParams);
			if (trainResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"\nModel training result:\n\n{trainResult}");
				ConsoleOutputUtils.WriteLine(methodName, "Model training process succeeded.");
			}
			else
				ConsoleOutputUtils.WriteLine(methodName, trainResult.ErrorMessage);

			return (trainResult, trainResult.IsSuccess);
		}

		private (GestureRecognitionModelEvaluateResult? result, bool isSuccess) EvaluateModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelEvaluateParameters evaluateParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(EvaluateModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process started...");

			var evaluateResult = modelWrapper.Evaluate(evaluateParams);
			if (evaluateResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"\nModel evaluation result:\n\n{evaluateResult.MulticlassClassificationEvalResult}");
				ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process succeded.");
			}
			else
				ConsoleOutputUtils.WriteLine(methodName, evaluateResult.ErrorMessage);

			return (evaluateResult, evaluateResult.IsSuccess);
		}

		private (GestureRecognitionModelPredictResult result, int durationMicroseconds, bool isSuccess) Predict(GestureRecognitionModelWrapper modelWrapper, GestureDataView gestureData, int gestureIdx)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(Predict)}";

			string gestureLabel = string.Empty;
			var trackingMode = BodyTrackingMode.Kinect;
			if (gestureData is KinectGestureDataView kinectGestureData)
			{
				gestureLabel = kinectGestureData.Label ?? string.Empty;
				trackingMode = BodyTrackingMode.Kinect;
			}
			else if (gestureData is MediaPipeHandLandmarksGestureDataView mediaPipeHandLandmarksGestureData)
			{
				gestureLabel = mediaPipeHandLandmarksGestureData.Label ?? string.Empty;
				trackingMode = BodyTrackingMode.MediaPipeHandLandmarks;	
			}

			ConsoleOutputUtils.WriteLine(methodName, $"[Gesture label: {gestureLabel}, Tracking mode: {trackingMode}] Gesture prediction started ");

			var predictStart = DateTime.Now;
			var predictResult = modelWrapper.Predict(new GestureRecognitionModelPredictParameters()
			{
				GestureData = gestureData,
			});
			int durationMicroseconds =  (int)Math.Round((DateTime.Now - predictStart).TotalMicroseconds);
			if (predictResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[Gesture label: {gestureLabel}, Tracking mode: {trackingMode}] " +
					$"Predicted label: {predictResult.Prediction.Label}, Score: {predictResult.Prediction.Scores.Max()}");
			}
			else
				ConsoleOutputUtils.WriteLine(methodName, $"[Gesture label: {gestureLabel}, Tracking mode: {trackingMode}] {predictResult.ErrorMessage}");


			return (predictResult, durationMicroseconds, predictResult.IsSuccess);
		}

		private bool LoadModel(GestureRecognitionModelWrapper modelWrapper, string modelFilePath)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(LoadModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Loading model started...");

			var loadModelParams = new LoadGestureRecognitionModelParameters()
			{
				Path = modelFilePath
			};
			var loadModelResult = modelWrapper.LoadModel(loadModelParams);
			if (!loadModelResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, loadModelResult.ErrorMessage);
				return false;
			}

			ConsoleOutputUtils.WriteLine(methodName, "Loading model succeded.");

			return true;
		}

		private bool SaveModel(GestureRecognitionModelWrapper modelWrapper, string modelFilePath)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(SaveModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Saving model started...");

			var saveModelParams = new SaveGestureRecognitionModelParameters()
			{
				Path = modelFilePath
			};
			var saveModelResult = modelWrapper.SaveModel(saveModelParams);
			if (!saveModelResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, saveModelResult.ErrorMessage);
				return false;
			}

			ConsoleOutputUtils.WriteLine(methodName, "Saving model succeded.");

			return true;
		}

		private ModelProcessResult? GetModelProcessResult(string modelProcessResultFilePath, string modelFilePath, int? foldIdx, int seed,
			GestureRecognitionModelSetDataParameters setDataParameters, string? dataFilePath, string? trainDataFilePath, string? testDataFilePath,
			GestureRecognitionModelTrainParameters? trainParams, GestureRecognitionModelTrainResult? trainResult,
			GestureRecognitionModelEvaluateResult evaluateResult)
		{
			if (string.IsNullOrEmpty(modelProcessResultFilePath) || !modelProcessResultFilePath.EndsWith(CsvResultsHelperUtils.CsvFileExtension))
				return null;

			if (evaluateResult == null || !evaluateResult.IsSuccess)
				return null;

			string modelProcessFileName = Path.GetFileNameWithoutExtension(modelProcessResultFilePath);
			string perClassEvalResultsFileName;
			if (foldIdx.HasValue)
				perClassEvalResultsFileName = $"{modelProcessFileName}_Fold{foldIdx.Value}_PerClassEvalResults";
			else
				perClassEvalResultsFileName = $"{modelProcessFileName}_PerClassEvalResults";
			
			string perClassEvalResultsFilePath = modelProcessResultFilePath.Replace(modelProcessFileName, perClassEvalResultsFileName);

			return ModelProcessResultMapper.Map(modelFilePath, foldIdx, seed, setDataParameters, dataFilePath, trainDataFilePath, testDataFilePath,
					trainParams, trainResult, evaluateResult, perClassEvalResultsFilePath);
		}

		private void ExportToCsv(string modelProcessResultsFilePath, ModelProcessResult[] results)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExportToCsv)}";

			ConsoleOutputUtils.WriteLine(methodName, "Exporting results to CSV file started...");

			if (string.IsNullOrEmpty(modelProcessResultsFilePath) || !modelProcessResultsFilePath.EndsWith(CsvResultsHelperUtils.CsvFileExtension))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Exporting results to CSV file failed - invalid output file path: [{modelProcessResultsFilePath}].");
				return;
			}

			try
			{
				if (results != null && results.Length > 0)
					CsvResultsHelperUtils.WriteModelProcessResultsToFile(results, modelProcessResultsFilePath);

				ConsoleOutputUtils.WriteLine(methodName, "Exporting results to CSV file succeded.");
			}
			catch (Exception ex)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Exporting results to CSV file failed - exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void ExportPredictionPerformanceTestResultToCsv(string resultFilePath, ModelPredictionsPerformanceTestResult result)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExportPredictionPerformanceTestResultToCsv)}";

			ConsoleOutputUtils.WriteLine(methodName, "Exporting results to CSV file started...");

			if (string.IsNullOrEmpty(resultFilePath) || !resultFilePath.EndsWith(CsvResultsHelperUtils.CsvFileExtension))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Exporting results to CSV file failed - invalid output file path: [{resultFilePath}].");
				return;
			}

			try
			{
				if (result?.PredictionsInfo != null && result.PredictionsInfo.Length > 0)
					CsvResultsHelperUtils.WriteModelPredictionsPerformanceTestResultToFile(result, resultFilePath);

				ConsoleOutputUtils.WriteLine(methodName, "Exporting results to CSV file succeded.");
			}
			catch (Exception ex)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Exporting results to CSV file failed - exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}
		#endregion
	}
}
