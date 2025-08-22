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
				if (trainingAndEvaluationProcessParameters.UseCv)
				{
					var crossValidateParams = new GestureRecognitionModelCrossValidateParameters()
					{
						FoldsCount = trainingAndEvaluationProcessParameters.CvFoldsCount,
						TrainParams = trainingAndEvaluationProcessParameters.TrainingParams,
						EvaluateParams = trainingAndEvaluationProcessParameters.EvaluationParams
					};

					CrossValidateModel(modelWrapper, crossValidateParams, trainingAndEvaluationProcessParameters.ModelCvProcessResultFilePath, this.seed,
						trainingAndEvaluationProcessParameters.SetDataParams, trainingAndEvaluationProcessParameters.DataFilePath, trainingAndEvaluationProcessParameters.TrainDataFilePath);
				}

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
									trainingAndEvaluationProcessParameters.ModelFilePath, null, this.seed, trainingAndEvaluationProcessParameters.SetDataParams,
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
							evaluationProcessParameters.ModelFilePath, null, this.seed, evaluationProcessParameters.SetTestDataParameters,
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
		#endregion
	}
}
