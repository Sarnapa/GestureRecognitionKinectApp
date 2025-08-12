using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
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
		public void ExecuteModelTrainingAndEvaluationProcess(GestureDataView[] data, Type gestureDataType)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(ExecuteModelTrainingAndEvaluationProcess)}";

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process started.");

			var modelWrapper = InitializeModelWrapper();
			if (SetData(modelWrapper, data, gestureDataType))
			{
				if (TrainModel(modelWrapper))
				{
					EvaluateModel(modelWrapper);
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, "Model training and evaluation process finished.");
		}
		#endregion

		#region Private methods
		private GestureRecognitionModelWrapper InitializeModelWrapper()
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(InitializeModelWrapper)}";

			var modelWrapperParams = new ModelWrapperParameters()
			{
				Seed = this.seed,
			};
			var modelWrapper = new GestureRecognitionModelWrapper(modelWrapperParams);
			ConsoleOutputUtils.WriteLine(methodName, "Initializing model wrapper succeeded.");

			return modelWrapper;
		}

		private bool SetData(GestureRecognitionModelWrapper modelWrapper, GestureDataView[] data, Type gestureDataType)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(SetData)}";

			if (!ValidateData(methodName, data, gestureDataType))
				return false;

			var setDataParams = new GestureRecognitionModelSetDataParameters()
			{
				Data = data,
				TestFraction = 0.2d
			};
			var setDataResult = modelWrapper.SetData(setDataParams);
			if (!setDataResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, setDataResult.ErrorMessage);
				return false;
			}
			ConsoleOutputUtils.WriteLine(methodName, "Setting data succeeded.");

			return true;
		}

		private bool TrainModel(GestureRecognitionModelWrapper modelWrapper)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(TrainModel)}";
			
			var trainParameters = new GestureRecognitionModelTrainParameters()
			{
				ExcludedFeatures = [],
				UsePca = true,
				PcaRank = 30,
				AlgorithmParams = new FastForestParams()
				{
					TreesCount = 5,
					LeavesCount = 4,
				}
			};
			var trainResult = modelWrapper.TrainModel(trainParameters);
			if (!trainResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, trainResult.ErrorMessage);
				return false;
			}
			ConsoleOutputUtils.WriteLine(methodName, "Model training process succeeded.");

			return true;
		}

		private bool EvaluateModel(GestureRecognitionModelWrapper modelWrapper)
		{
			string methodName = $"{nameof(GestureRecognitionModelManager)}.{nameof(EvaluateModel)}";

			var evaluateParams = new GestureRecognitionModelEvaluateParameters()
			{
				EvaluationResultPresentationTitle = "Fast Forest classifier evaluation"
			};
			var evaluateResult = modelWrapper.Evaluate(evaluateParams);
			if (!evaluateResult.IsSuccess)
			{
				ConsoleOutputUtils.WriteLine(methodName, evaluateResult.ErrorMessage);
				return false;
			}
			ConsoleOutputUtils.WriteLine(methodName, "Model evaluation process succeded.");

			return true;
		}

		private bool ValidateData(string methodName, GestureDataView[] data, Type gestureDataType)
		{
			if (data == null || data.Length == 0)
			{
				ConsoleOutputUtils.WriteLine(methodName, "Got no data. Training process has been abandoned.");
				return false;
			}

			if (gestureDataType == null || (gestureDataType != typeof(KinectGestureDataView)
				&& gestureDataType != typeof(MediaPipeHandLandmarksGestureDataView)))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Got invalid {nameof(GestureDataView)} type - got: {gestureDataType?.Name}, " +
					$"expected: [{typeof(KinectGestureDataView).Name}, {typeof(MediaPipeHandLandmarksGestureDataView).Name}]");
				return false;
			}

			return true;
		}
		#endregion
	}
}
