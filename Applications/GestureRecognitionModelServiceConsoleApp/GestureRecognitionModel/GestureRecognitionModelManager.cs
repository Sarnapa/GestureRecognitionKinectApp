using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Export;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Result;
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
		public void ExecuteModelTrainingAndEvaluationProcess(ModelTrainingAndEvaluationProcessParameters trainingAndEvaluationProcessParameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelTrainingAndEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process started.");
			ConsoleOutputUtils.WriteLine(methodName, $"\n{trainingAndEvaluationProcessParameters}");

			var modelWrapper = InitializeModelWrapper();
			var (_, isSetDataSuccess) = SetData(modelWrapper, trainingAndEvaluationProcessParameters.SetDataParams);
			if (isSetDataSuccess)
			{
				var (trainModelResult, isTrainModelSuccess) = TrainModel(modelWrapper, trainingAndEvaluationProcessParameters.TrainingParams);
				if (isTrainModelSuccess && trainModelResult != null)
				{
					var (evaluateModelResult, isEvaluateModelSuccess) = EvaluateModel(modelWrapper, trainingAndEvaluationProcessParameters.EvaluationParams);
					if (isEvaluateModelSuccess && evaluateModelResult != null)
					{
						if (!string.IsNullOrEmpty(trainingAndEvaluationProcessParameters.ModelFilePath))
						{
							if (SaveModel(modelWrapper, trainingAndEvaluationProcessParameters.ModelFilePath)
								&& !string.IsNullOrEmpty(trainingAndEvaluationProcessParameters.ModelProcessResultFilePath))
							{
								var trainingAndEvaluationProcessResult = GetModelProcessResult(trainingAndEvaluationProcessParameters.ModelProcessResultFilePath,
									trainingAndEvaluationProcessParameters.ModelFilePath, this.seed, trainingAndEvaluationProcessParameters.SetDataParams,
									trainingAndEvaluationProcessParameters.DataFilePath, trainingAndEvaluationProcessParameters.TrainDataFilePath, trainingAndEvaluationProcessParameters.TestDataFilePath,
									trainingAndEvaluationProcessParameters.TrainingParams, trainModelResult, evaluateModelResult);
								if (trainingAndEvaluationProcessResult != null)
									ExportToCsv(trainingAndEvaluationProcessParameters.ModelProcessResultFilePath, [trainingAndEvaluationProcessResult]);
							}
						}
					}
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process finished.");
		}

		public void ExecuteModelEvaluationProcess(ModelEvaluationProcessParameters evaluationProcessParameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process started.");

			ConsoleOutputUtils.WriteLine(methodName, $"\n{evaluationProcessParameters}");

			var modelWrapper = InitializeModelWrapper();
			if (LoadModel(modelWrapper, evaluationProcessParameters.ModelFilePath))
			{
				var (_, isSetDataSuccess) = SetData(modelWrapper, evaluationProcessParameters.SetTestDataParameters);
				if (isSetDataSuccess)
				{
					var (evaluateModelResult, isEvaluateModelSuccess) = EvaluateModel(modelWrapper, evaluationProcessParameters.EvaluationParams);
					if (isEvaluateModelSuccess && evaluateModelResult != null && !string.IsNullOrEmpty(evaluationProcessParameters.ModelProcessResultFilePath))
					{
						var evaluationProcessResult = GetModelProcessResult(evaluationProcessParameters.ModelProcessResultFilePath,
							evaluationProcessParameters.ModelFilePath, this.seed, evaluationProcessParameters.SetTestDataParameters,
							string.Empty, string.Empty, evaluationProcessParameters.TestDataFilePath,
							null, null, evaluateModelResult);
						if (evaluationProcessResult != null)
							ExportToCsv(evaluationProcessParameters.ModelProcessResultFilePath, [evaluationProcessResult]);
					}
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process finished.");
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

		private (GestureRecognitionModelTrainResult? result, bool isSuccess) TrainModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelTrainParameters trainParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(TrainModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model training process started...");

			var trainResult = modelWrapper.TrainModel(trainParams);
			if (trainResult is GestureRecognitionModelTrainResult gestureRecognitionModelTrainResult)
			{
				if (trainResult.IsSuccess)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"\nModel training result:\n\n{gestureRecognitionModelTrainResult}");
					ConsoleOutputUtils.WriteLine(methodName, "Model training process succeeded.");
				}
				else
					ConsoleOutputUtils.WriteLine(methodName, trainResult.ErrorMessage);

				return (gestureRecognitionModelTrainResult, trainResult.IsSuccess);
			}

			ConsoleOutputUtils.WriteLine(methodName, $"Model training process failed - unexpected result type: [{trainResult.GetType().Name}].");
			return (null, false);
		}

		private (GestureRecognitionModelEvaluateResult? result, bool isSuccess) EvaluateModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelEvaluateParameters evaluateParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(EvaluateModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process started...");

			var evaluateResult = modelWrapper.Evaluate(evaluateParams);
			if (evaluateResult is GestureRecognitionModelEvaluateResult gestureRecognitionModelEvaluateResult)
			{
				if (evaluateResult.IsSuccess)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"\nModel evaluation result:\n\n{gestureRecognitionModelEvaluateResult.MulticlassClassificationEvalResult}");
					ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process succeded.");
				}
				else
					ConsoleOutputUtils.WriteLine(methodName, evaluateResult.ErrorMessage);

				return (gestureRecognitionModelEvaluateResult, evaluateResult.IsSuccess);
			}

			ConsoleOutputUtils.WriteLine(methodName, $"Model evaluation process failed - unexpected result type: [{evaluateResult.GetType().Name}].");
			return (null, false);
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

		private ModelProcessResult? GetModelProcessResult(string modelProcessResultFilePath, string modelFilePath, int seed,
			GestureRecognitionModelSetDataParameters setDataParameters, string? dataFilePath, string? trainDataFilePath, string? testDataFilePath,
			GestureRecognitionModelTrainParameters? trainParams, GestureRecognitionModelTrainResult? trainResult,
			GestureRecognitionModelEvaluateResult evaluateResult)
		{
			if (string.IsNullOrEmpty(modelProcessResultFilePath) || !modelProcessResultFilePath.EndsWith(CsvResultsHelperUtils.CsvFileExtension))
				return null;

			if (evaluateResult == null || !evaluateResult.IsSuccess)
				return null;

			string modelProcessFileName = Path.GetFileNameWithoutExtension(modelProcessResultFilePath);
			string perClassEvalResultsFileName = $"{modelProcessFileName}_PerClassEvalResults";
			string perClassEvalResultsFilePath = modelProcessResultFilePath.Replace(modelProcessFileName, perClassEvalResultsFileName);

			return ModelProcessResultMapper.Map(modelFilePath, seed, setDataParameters, dataFilePath, trainDataFilePath, testDataFilePath,
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
		#endregion
	}
}
