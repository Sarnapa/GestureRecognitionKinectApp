using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data;
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

			ConsoleOutputUtils.WriteLine(methodName, trainingAndEvaluationProcessParameters.ToString());

			var modelWrapper = InitializeModelWrapper();
			if (SetData(modelWrapper, trainingAndEvaluationProcessParameters.SetDataParams))
			{
				if (TrainModel(modelWrapper, trainingAndEvaluationProcessParameters.TrainingParams))
				{
					if (EvaluateModel(modelWrapper, trainingAndEvaluationProcessParameters.EvaluationParams))
					{
						if (!string.IsNullOrEmpty(trainingAndEvaluationProcessParameters.ModelFilePath))
							SaveModel(modelWrapper, trainingAndEvaluationProcessParameters.ModelFilePath);
					}
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process finished.");
		}

		public void ExecuteModelEvaluationProcess(ModelEvaluationProcessParameters evaluationProcessParameters)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process started.");

			ConsoleOutputUtils.WriteLine(methodName, evaluationProcessParameters.ToString());

			var modelWrapper = InitializeModelWrapper();
			if (LoadModel(modelWrapper, evaluationProcessParameters.ModelFilePath))
			{
				if (SetData(modelWrapper, evaluationProcessParameters.SetTestDataParameters))
				{
					EvaluateModel(modelWrapper, evaluationProcessParameters.EvaluationParams);
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

		private bool SetData(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelSetDataParameters setDataParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(SetData)}";

			ConsoleOutputUtils.WriteLine(methodName, "Setting data started...");

			var setDataResult = modelWrapper.SetData(setDataParams);
			if (!setDataResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, setDataResult.ErrorMessage);
				return false;
			}

			ConsoleOutputUtils.WriteLine(methodName, "Setting data succeeded.");

			return true;
		}

		private bool TrainModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelTrainParameters trainParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(TrainModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model training process started...");

			var trainResult = modelWrapper.TrainModel(trainParams);
			if (!trainResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, trainResult.ErrorMessage);
				return false;
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model training process succeeded.");

			return true;
		}

		private bool EvaluateModel(GestureRecognitionModelWrapper modelWrapper, GestureRecognitionModelEvaluateParameters evaluateParams)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(EvaluateModel)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process started...");

			var evaluateResult = modelWrapper.Evaluate(evaluateParams);
			if (!evaluateResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, evaluateResult.ErrorMessage);
				return false;
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process succeded.");

			return true;
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
		#endregion
	}
}
