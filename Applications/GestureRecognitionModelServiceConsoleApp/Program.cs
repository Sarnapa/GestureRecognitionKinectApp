using System.Globalization;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureData;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			string methodName = $"{nameof(Program)}.{nameof(Main)}";
			ConsoleOutputUtils.WriteLine(methodName, "Starting GestureRecognitionModelServiceConsoleApp...");

			// For testing purposes
			//args =
			//[
			//	ArgumentsConsts.MODEL_TUNEHYPERPARAMS_TRAINING_AND_EVALUATION,
			//	ArgumentsConsts.GESTURE_DATA_VIEW_TYPE_ARG, ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE,
			//	ArgumentsConsts.DATA_FILE_PATH_ARG, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\GesturesData.csv",
			//	ArgumentsConsts.SEED_ARG, "42",
			//	ArgumentsConsts.USE_CV_ARG, "True",
			//	ArgumentsConsts.CV_FOLDS_COUNT_ARG, "10",
			//	ArgumentsConsts.MODEL_CV_PROCESS_RESULT_FILE_PATH, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\CV_ModelResult.csv",
			//	// ArgumentsConsts.TUNE_HYPERPARAMS_MAX_MODEL_TO_EXPLORE_COUNT_ARG, "20",
			//	// ArgumentsConsts.TUNE_HYPERPARAMS_TRAINING_TIME_IN_SECONDS_ARG, "600",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_TUNER_ARG, ArgumentsConsts.HYPERPARAMS_TUNER_GRIDSEARCH,
			//	ArgumentsConsts.TUNE_HYPERPARAMS_GRID_SEARCH_STEP_SIZE_ARG, "5",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_FOLDS_COUNT_ARG, "5",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_MAIN_METRIC_ARG, ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_MACROACCURACY,
			//	ArgumentsConsts.TUNE_HYPERPARAMS_PCA_RANK_ARG, "0", "60", "30",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_TREES_COUNT_ARG, "100", "900", "500",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_LEAVES_COUNT_ARG, "16", "256", "64",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG, "5", "25", "10",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_FEATURE_FRACTION_ARG, "0.1", "0.5", "0.3",
			//	ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG, "0.8", "1.0", "0.9",
			//	ArgumentsConsts.MODEL_FILE_PATH_ARG, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\Model.zip",
			//	ArgumentsConsts.MODEL_PROCESS_RESULT_FILE_PATH, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\ModelResult.csv"
			//];

			//args =
			//[
			//	ArgumentsConsts.MODEL_TRAINING_AND_EVALUATION,
			//	ArgumentsConsts.GESTURE_DATA_VIEW_TYPE_ARG, ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE,
			//	ArgumentsConsts.DATA_FILE_PATH_ARG, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\GesturesData.csv",
			//	ArgumentsConsts.SEED_ARG, "42",
			//	ArgumentsConsts.USE_CV_ARG, "True",
			//	ArgumentsConsts.CV_FOLDS_COUNT_ARG, "10",
			//	ArgumentsConsts.MODEL_CV_PROCESS_RESULT_FILE_PATH, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\CV_ModelResult.csv",
			//	ArgumentsConsts.PCA_RANK_ARG, "30",
			//	ArgumentsConsts.FAST_FOREST_ALG_ARG,
			//	ArgumentsConsts.FAST_FOREST_TREES_COUNT_ARG, "500",
			//	ArgumentsConsts.FAST_FOREST_LEAVES_COUNT_ARG, "32",
			//	ArgumentsConsts.FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG, "10",
			//	ArgumentsConsts.FAST_FOREST_FEATURE_FRACTION_ARG, "0.2",
			//	ArgumentsConsts.FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG, "1.0",
			//	ArgumentsConsts.MODEL_FILE_PATH_ARG, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\Model.zip",
			//	ArgumentsConsts.MODEL_PROCESS_RESULT_FILE_PATH, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\ModelResult.csv"
			//];

			//args =
			//[
			//	ArgumentsConsts.MODEL_EVALUATION,
			//	ArgumentsConsts.MODEL_FILE_PATH_ARG, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\Model.zip",
			//	ArgumentsConsts.GESTURE_DATA_VIEW_TYPE_ARG, ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE,
			//	ArgumentsConsts.TEST_DATA_FILE_PATH_ARG, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\GesturesData.csv",
			//	ArgumentsConsts.SEED_ARG, "42",
			//	ArgumentsConsts.MODEL_PROCESS_RESULT_FILE_PATH, @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\Tests\2025_08_11_MediaPipeHandLandmarks\ModelResult_onlyEval.csv"
			//];

			if (args.Length < 3)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Invalid arguments count - got: {args.Length}, expected: at least 3.");
				ConsoleOutputUtils.WriteLine(methodName, $"Press key to close console app.");
				Console.ReadKey();
				return;
			}

			string methodKindArg = args[0];

			MethodKind? methodKind = null;
			if (methodKindArg.Equals(ArgumentsConsts.MODEL_TUNEHYPERPARAMS_TRAINING_AND_EVALUATION, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.ModelTuneHyperparamsTrainingAndEvaluation;
			}
			else if (methodKindArg.Equals(ArgumentsConsts.MODEL_TRAINING_AND_EVALUATION, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.ModelTrainingAndEvaluation;
			}
			else if (methodKindArg.Equals(ArgumentsConsts.MODEL_EVALUATION, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.ModelEvaluation;
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Invalid method argument - got: {methodKindArg}, " +
					$"expected: [{ArgumentsConsts.MODEL_TRAINING_AND_EVALUATION}].");
			}

			if (methodKind.HasValue)
			{
				switch (methodKind.Value)
				{
					case MethodKind.ModelTuneHyperparamsTrainingAndEvaluation:
						await ExecuteModelTuneHyperparamsTrainingAndEvaluationProcess(args).ConfigureAwait(false);
						break;
					case MethodKind.ModelTrainingAndEvaluation:
						ExecuteModelTrainingAndEvaluationProcess(args);
						break;
					case MethodKind.ModelEvaluation:
						ExecuteModelEvaluationProcess(args); 
						break;
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, $"Press key to close console app.");
			Console.ReadKey();
		}

		#region Private methods

		#region Processes methods
		private static async Task ExecuteModelTuneHyperparamsTrainingAndEvaluationProcess(string[] args)
		{
			string methodName = $"{nameof(Program)}.{nameof(ExecuteModelTuneHyperparamsTrainingAndEvaluationProcess)}";

			string[] methodArgs = args.Where(a => a.StartsWith('-')).ToArray();
			if (methodArgs.Length != methodArgs.Distinct().Count())
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Duplicates were provided among the arguments.");
				return;
			}

			var methodArgToIdx = args.Index().Where(a => methodArgs.Contains(a.Item)).ToDictionary(a => a.Item, a => a.Index);

			#region GestureDataViewType
			var gestureDataViewType = GetGestureDataViewType(methodName, args, methodArgToIdx);
			if (gestureDataViewType == null)
				return;
			#endregion

			#region SetDataParameters
			var (setDataParams, gesturesDataFilePath, gesturesTrainDataFilePath, gesturesTestDataFilePath) = GetSetDataParams(methodName, args, methodArgs, methodArgToIdx, gestureDataViewType);
			if (setDataParams == null)
				return;
			#endregion

			#region TuneHyperparamsParameters
			var tuneHyperparamsParams = new GestureRecognitionModelTuneHyperparamsParameters();

			var (maxModelToExploreCount, getMaxModelToExploreCountIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_MAX_MODEL_TO_EXPLORE_COUNT_ARG, false);
			if (getMaxModelToExploreCountIsSuccess && maxModelToExploreCount.HasValue)
			{
				tuneHyperparamsParams.MaxModelToExploreCount = maxModelToExploreCount.Value;
			}

			var (trainingTimeInSeconds, getTrainingTimeInSecondsIsSuccess) = GetArgUIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_TRAINING_TIME_IN_SECONDS_ARG, false);
			if (getTrainingTimeInSecondsIsSuccess && trainingTimeInSeconds.HasValue)
			{
				tuneHyperparamsParams.TrainingTimeInSeconds = trainingTimeInSeconds.Value;
			}

			var tuner = GetHyperparamsTuner(methodName, args, methodArgToIdx);
			if (tuner.HasValue)
			{
				tuneHyperparamsParams.HyperparamsTuner = tuner.Value;
			}

			var (gridSearchStepSize, getGridSearchStepSizeIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_GRID_SEARCH_STEP_SIZE_ARG, false);
			if (getGridSearchStepSizeIsSuccess && gridSearchStepSize.HasValue)
			{
				tuneHyperparamsParams.GridSearchStepSize = gridSearchStepSize.Value;
			}

			var (tuneFoldsCount, getTuneFoldsCountIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_FOLDS_COUNT_ARG, false);
			if (getTuneFoldsCountIsSuccess && tuneFoldsCount.HasValue)
			{
				tuneHyperparamsParams.FoldsCount = tuneFoldsCount.Value;
			}

			var mainMetric = GetMainMetric(methodName, args, methodArgToIdx);
			if (mainMetric.HasValue)
			{
				tuneHyperparamsParams.MainMetric = mainMetric.Value;
			}

			#region PrepareDataSearchSpaceValues
			var prepareDataSearchSpaceValues = new PrepareDataSearchSpaceValues();

			var (pcaRankValues, getPcaRankValuesIsSuccess) = GetSearchSpaceIntRangeValues(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_PCA_RANK_ARG, false);
			if (getPcaRankValuesIsSuccess && pcaRankValues != null)
				prepareDataSearchSpaceValues.PcaRankValues = pcaRankValues;

			tuneHyperparamsParams.PrepareDataSearchSpace = prepareDataSearchSpaceValues;
			#endregion

			#region FastForestSearchSpaceValues
			var fastForestSearchSpaceValues = new FastForestSearchSpaceValues();

			var (treesCountValues, getTreesCountValuesIsSuccess) = GetSearchSpaceIntRangeValues(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_TREES_COUNT_ARG, false);
			if (getTreesCountValuesIsSuccess && treesCountValues != null)
			{
				fastForestSearchSpaceValues.TreesCountValues = treesCountValues;
			}

			var (leavesCountValues, getLeavesCountValuesIsSuccess) = GetSearchSpaceIntRangeValues(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_LEAVES_COUNT_ARG, false);
			if (getLeavesCountValuesIsSuccess && leavesCountValues != null)
			{
				fastForestSearchSpaceValues.LeavesCountValues = leavesCountValues;
			}

			var (minimumExampleCountPerLeafValues, getMinimumExampleCountPerLeafValuesIsSuccess) = GetSearchSpaceIntRangeValues(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG, false);
			if (getMinimumExampleCountPerLeafValuesIsSuccess && minimumExampleCountPerLeafValues != null)
			{
				fastForestSearchSpaceValues.MinimumExampleCountPerLeafValues = minimumExampleCountPerLeafValues;
			}

			var (featureFractionValues, getFeatureFractionValuesIsSuccess) = GetSearchSpaceDoubleRangeValues(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_FEATURE_FRACTION_ARG, false);
			if (getFeatureFractionValuesIsSuccess && featureFractionValues != null)
			{
				fastForestSearchSpaceValues.FeatureFractionValues = featureFractionValues;
			}

			var (baggingExampleFractionValues, getBaggingExampleFractionValuesIsSuccess) = GetSearchSpaceDoubleRangeValues(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG, false);
			if (getBaggingExampleFractionValuesIsSuccess && baggingExampleFractionValues != null)
			{
				fastForestSearchSpaceValues.BaggingExampleFractionValues = baggingExampleFractionValues;
			}

			tuneHyperparamsParams.FastForestSearchSpace = fastForestSearchSpaceValues;
			#endregion

			#endregion

			#region EvaluationParameters
			var evaluationParams = GetEvaluationParams(methodName, args, methodArgToIdx);
			#endregion

			#region Cross validation
			int? cvFoldsCount = null;
			string modelCvProcessResultFilePath = string.Empty;
			var (useCv, getUseCvIsSuccess) = GetArgBoolValue(methodName, args, methodArgToIdx, ArgumentsConsts.USE_CV_ARG, false);
			if (useCv.HasValue && getUseCvIsSuccess)
			{
				(cvFoldsCount, _) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.CV_FOLDS_COUNT_ARG, false);
				(modelCvProcessResultFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_CV_PROCESS_RESULT_FILE_PATH, false);
			}
			#endregion

			#region ModelFilePath
			var (modelFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_FILE_PATH_ARG, false);
			#endregion

			#region ModelProcessResultFilePath
			var (modelProcessResultFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_PROCESS_RESULT_FILE_PATH, false);
			#endregion

			#region Seed
			int seed = GetSeed(methodName, args, methodArgToIdx);
			#endregion

			var gestureRecognitionModelManager = new GestureRecognitionModelManager(seed);
			await gestureRecognitionModelManager.ExecuteModelTuneHyperparamsTrainingAndEvaluationProcess(new ModelTuneHyperparamsTrainingAndEvaluationProcessParameters()
			{
				SetDataParams = setDataParams,
				DataFilePath = gesturesDataFilePath,
				TrainDataFilePath = gesturesTrainDataFilePath,
				TestDataFilePath = gesturesTestDataFilePath,
				UseCv = useCv ?? false,
				CvFoldsCount = cvFoldsCount ?? (useCv.HasValue && useCv.Value ? 5 : 0),
				ModelCvProcessResultFilePath = modelCvProcessResultFilePath,
				TuneHyperparamsParams = tuneHyperparamsParams,
				EvaluationParams = evaluationParams,
				ModelFilePath = modelFilePath,
				ModelProcessResultFilePath = modelProcessResultFilePath,
			}).ConfigureAwait(false);
		}

		private static void ExecuteModelTrainingAndEvaluationProcess(string[] args)
		{
			string methodName = $"{nameof(Program)}.{nameof(ExecuteModelTrainingAndEvaluationProcess)}";

			string[] methodArgs = args.Where(a => a.StartsWith('-')).ToArray();
			if (methodArgs.Length != methodArgs.Distinct().Count())
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Duplicates were provided among the arguments.");
				return;
			}

			var methodArgToIdx = args.Index().Where(a => methodArgs.Contains(a.Item)).ToDictionary(a => a.Item, a => a.Index);

			#region GestureDataViewType
			var gestureDataViewType = GetGestureDataViewType(methodName, args, methodArgToIdx);
			if (gestureDataViewType == null)
				return;
			#endregion

			#region SetDataParameters
			var (setDataParams, gesturesDataFilePath, gesturesTrainDataFilePath, gesturesTestDataFilePath) = GetSetDataParams(methodName, args, methodArgs, methodArgToIdx, gestureDataViewType);
			if (setDataParams == null)
				return;
			#endregion

			#region TrainingParameters
			var trainParams = new GestureRecognitionModelTrainParameters();

			var (pcaRank, getPcaRankIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.PCA_RANK_ARG, false);
			if (getPcaRankIsSuccess && pcaRank.HasValue)
			{
				trainParams.PrepareDataHyperparams.PcaRank = pcaRank.Value;
			}

			#region FastForestParams
			if (methodArgs.Contains(ArgumentsConsts.FAST_FOREST_ALG_ARG))
			{
				var ffParams = new FastForestParams();

				var (treesCount, getTreesCountIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.FAST_FOREST_TREES_COUNT_ARG, false);
				if (getTreesCountIsSuccess && treesCount.HasValue)
				{
					ffParams.Hyperparams.TreesCount = treesCount.Value;
				}

				var (leavesCount, getLeavesCountIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.FAST_FOREST_LEAVES_COUNT_ARG, false);
				if (getLeavesCountIsSuccess && leavesCount.HasValue)
				{
					ffParams.Hyperparams.LeavesCount = leavesCount.Value;
				}

				var (minimumExampleCountPerLeaf, getMinimumExampleCountPerLeafIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG, false);
				if (getMinimumExampleCountPerLeafIsSuccess && minimumExampleCountPerLeaf.HasValue)
				{
					ffParams.Hyperparams.MinimumExampleCountPerLeaf = minimumExampleCountPerLeaf.Value;
				}

				var (featureFraction, getFeatureFractionIsSuccess) = GetArgDoubleValue(methodName, args, methodArgToIdx, ArgumentsConsts.FAST_FOREST_FEATURE_FRACTION_ARG, false);
				if (getFeatureFractionIsSuccess)
				{
					ffParams.Hyperparams.FeatureFraction = featureFraction;
				}

				var (baggingExampleFraction, getBaggingExampleFractionIsSuccess) = GetArgDoubleValue(methodName, args, methodArgToIdx, ArgumentsConsts.FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG, false);
				if (getBaggingExampleFractionIsSuccess)
				{
					ffParams.Hyperparams.BaggingExampleFraction = baggingExampleFraction;
				}

				trainParams.AlgorithmParams = ffParams;
			}
			#endregion

			#endregion

			#region EvaluationParameters
			var evaluationParams = GetEvaluationParams(methodName, args, methodArgToIdx);
			#endregion

			#region Cross validation
			int? cvFoldsCount = null;
			string modelCvProcessResultFilePath = string.Empty;
			var (useCv, getUseCvIsSuccess) = GetArgBoolValue(methodName, args, methodArgToIdx, ArgumentsConsts.USE_CV_ARG, false);
			if (useCv.HasValue && getUseCvIsSuccess)
			{
				(cvFoldsCount, _) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.CV_FOLDS_COUNT_ARG, false);
				(modelCvProcessResultFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_CV_PROCESS_RESULT_FILE_PATH, false);
			}	
			#endregion

			#region ModelFilePath
			var (modelFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_FILE_PATH_ARG, false);
			#endregion

			#region ModelProcessResultFilePath
			var (modelProcessResultFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_PROCESS_RESULT_FILE_PATH, false);
			#endregion

			#region Seed
			int seed = GetSeed(methodName, args, methodArgToIdx);
			#endregion

			var gestureRecognitionModelManager = new GestureRecognitionModelManager(seed);
			gestureRecognitionModelManager.ExecuteModelTrainingAndEvaluationProcess(new ModelTrainingAndEvaluationProcessParameters()
			{
				SetDataParams = setDataParams,
				DataFilePath = gesturesDataFilePath,
				TrainDataFilePath = gesturesTrainDataFilePath,
				TestDataFilePath = gesturesTestDataFilePath,
				UseCv = useCv ?? false,
				CvFoldsCount = cvFoldsCount ?? (useCv.HasValue && useCv.Value ? 5 : 0),
				ModelCvProcessResultFilePath = modelCvProcessResultFilePath,
				TrainingParams = trainParams,
				EvaluationParams = evaluationParams,
				ModelFilePath = modelFilePath,
				ModelProcessResultFilePath = modelProcessResultFilePath,
			});
		}

		private static void ExecuteModelEvaluationProcess(string[] args)
		{
			string methodName = $"{nameof(Program)}.{nameof(ExecuteModelEvaluationProcess)}";

			string[] methodArgs = args.Where(a => a.StartsWith('-')).ToArray();
			if (methodArgs.Length != methodArgs.Distinct().Count())
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Duplicates were provided among the arguments.");
				return;
			}

			var methodArgToIdx = args.Index().Where(a => methodArgs.Contains(a.Item)).ToDictionary(a => a.Item, a => a.Index);

			#region ModelFilePath
			var (modelFilePath, getModelFilePathIsSuccess) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_FILE_PATH_ARG, true);
			if (!getModelFilePathIsSuccess)
				return;
			#endregion

			#region GestureDataViewType
			var gestureDataViewType = GetGestureDataViewType(methodName, args, methodArgToIdx);
			if (gestureDataViewType == null)
				return;
			#endregion

			#region SetTestDataParameters
			var (gesturesTestData, gesturesTestDataFilePath, getGesturesTestDataIsSuccess) = GetGesturesData(methodName, args, methodArgToIdx, ArgumentsConsts.TEST_DATA_FILE_PATH_ARG, gestureDataViewType, true);
			if (!getGesturesTestDataIsSuccess)
				return;

			var setTestDataParameters = new GestureRecognitionModelSetDataParameters()
			{
				TestData = gesturesTestData
			};
			#endregion

			#region EvaluationParameters
			var evaluationParams = GetEvaluationParams(methodName, args, methodArgToIdx);
			#endregion

			#region ModelProcessResultFilePath
			var (modelProcessResultFilePath, _) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.MODEL_PROCESS_RESULT_FILE_PATH, false);
			#endregion

			#region Seed
			int seed = GetSeed(methodName, args, methodArgToIdx);
			#endregion

			var gestureRecognitionModelManager = new GestureRecognitionModelManager(seed);
			gestureRecognitionModelManager.ExecuteModelEvaluationProcess(new ModelEvaluationProcessParameters()
			{
				ModelFilePath = modelFilePath,
				TestDataFilePath = gesturesTestDataFilePath,
				SetTestDataParameters = setTestDataParameters,
				EvaluationParams = evaluationParams,
				ModelProcessResultFilePath = modelProcessResultFilePath,
			});
		}
		#endregion

		#region Get parameters method
		private static Type? GetGestureDataViewType(string methodName, string[] args, Dictionary<string, int> methodArgToIdx)
		{
			var (gestureDataViewTypeValue, getGestureDataViewTypeIsSuccess) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.GESTURE_DATA_VIEW_TYPE_ARG, true);
			if (!getGestureDataViewTypeIsSuccess)
				return null;

			Type? gestureDataViewType = null;
			if (gestureDataViewTypeValue.Equals(ArgumentsConsts.KINECT_GESTURE_DATA_VIEW_TYPE, StringComparison.OrdinalIgnoreCase))
			{
				gestureDataViewType = typeof(KinectGestureDataView);
			}
			else if (gestureDataViewTypeValue.Equals(ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE, StringComparison.OrdinalIgnoreCase))
			{
				gestureDataViewType = typeof(MediaPipeHandLandmarksGestureDataView);
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Invalid value for argument {ArgumentsConsts.GESTURE_DATA_VIEW_TYPE_ARG} - got: {gestureDataViewTypeValue}, " +
					$"expected: [{ArgumentsConsts.KINECT_GESTURE_DATA_VIEW_TYPE}, {ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE}].");
			}

			return gestureDataViewType;
		}

		private static MulticlassClassificationMetricKind? GetMainMetric(string methodName, string[] args, Dictionary<string, int> methodArgToIdx)
		{
			var (mainMetricValue, getMainMetricValueIsSuccess) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_MAIN_METRIC_ARG, false);
			if (!getMainMetricValueIsSuccess)
				return null;

			MulticlassClassificationMetricKind? mainMetric = null;
			if (mainMetricValue.Equals(ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_MICROACCURACY, StringComparison.OrdinalIgnoreCase))
			{
				mainMetric = MulticlassClassificationMetricKind.MicroAccuracy;
			}
			else if (mainMetricValue.Equals(ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_MACROACCURACY, StringComparison.OrdinalIgnoreCase))
			{
				mainMetric = MulticlassClassificationMetricKind.MacroAccuracy;
			}
			else if (mainMetricValue.Equals(ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_LOGLOSS, StringComparison.OrdinalIgnoreCase))
			{
				mainMetric = MulticlassClassificationMetricKind.LogLoss;
			}
			else if (mainMetricValue.Equals(ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_LOGGLOSSREDUCTION, StringComparison.OrdinalIgnoreCase))
			{
				mainMetric = MulticlassClassificationMetricKind.LogLossReduction;
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Invalid value for argument {ArgumentsConsts.TUNE_HYPERPARAMS_MAIN_METRIC_ARG} - got: {mainMetricValue}, " +
					$"expected: [{ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_MICROACCURACY}, {ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_MACROACCURACY}" +
					$"{ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_LOGLOSS}, {ArgumentsConsts.MULTICLASS_CLASSIFICATION_METRIC_LOGGLOSSREDUCTION}].");
			}

			return mainMetric;
		}

		private static HyperparamsTunerKind? GetHyperparamsTuner(string methodName, string[] args, Dictionary<string, int> methodArgToIdx)
		{
			var (tunerValue, getTunerIsSuccess) = GetArgValue(methodName, args, methodArgToIdx, ArgumentsConsts.TUNE_HYPERPARAMS_TUNER_ARG, false);
			if (!getTunerIsSuccess)
				return null;

			HyperparamsTunerKind? tuner = null;
			if (tunerValue.Equals(ArgumentsConsts.HYPERPARAMS_TUNER_GRIDSEARCH, StringComparison.OrdinalIgnoreCase))
			{
				tuner = HyperparamsTunerKind.GridSearch;
			}
			else if (tunerValue.Equals(ArgumentsConsts.HYPERPARAMS_TUNER_RANDOMSEARCH, StringComparison.OrdinalIgnoreCase))
			{
				tuner = HyperparamsTunerKind.RandomSearch;
			}
			else if (tunerValue.Equals(ArgumentsConsts.HYPERPARAMS_TUNER_COSTFRUGAL, StringComparison.OrdinalIgnoreCase))
			{
				tuner = HyperparamsTunerKind.CostFrugal;
			}
			else if (tunerValue.Equals(ArgumentsConsts.HYPERPARAMS_TUNER_ECICOSTFRUGAL, StringComparison.OrdinalIgnoreCase))
			{
				tuner = HyperparamsTunerKind.EciCostFrugal;
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Invalid value for argument {ArgumentsConsts.TUNE_HYPERPARAMS_TUNER_ARG} - got: {tunerValue}, " +
					$"expected: [{ArgumentsConsts.HYPERPARAMS_TUNER_GRIDSEARCH}, {ArgumentsConsts.HYPERPARAMS_TUNER_RANDOMSEARCH}" +
					$"{ArgumentsConsts.HYPERPARAMS_TUNER_COSTFRUGAL}, {ArgumentsConsts.HYPERPARAMS_TUNER_ECICOSTFRUGAL}].");
			}

			return tuner;
		}

		private static int GetSeed(string methodName, string[] args, Dictionary<string, int> methodArgToIdx)
		{
			int seed = 42;
			var (seedValue, getSeedIsSuccess) = GetArgIntValue(methodName, args, methodArgToIdx, ArgumentsConsts.SEED_ARG, false);
			if (getSeedIsSuccess && seedValue.HasValue)
			{
				seed = seedValue.Value;
			}

			return seed;
		}

		private static (GestureRecognitionModelSetDataParameters? parameters, string? dataFilePath, string? trainDataFilePath, string? testDataFilePath) 
			GetSetDataParams(string methodName, string[] args, string[] methodArgs, Dictionary<string, int> methodArgToIdx, Type gestureDataViewType)
		{
			GestureRecognitionModelSetDataParameters? setDataParams = null;
			string? gesturesDataFilePath = string.Empty, gesturesTrainDataFilePath = string.Empty, gesturesTestDataFilePath = string.Empty;

			string[] dataArgs = methodArgs.Intersect(ArgumentsConsts.DATA_FILE_PATH_ARGS).ToArray();
			if (dataArgs.Length == 0 || dataArgs.Length > 2)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Invalid arguments count regarding files providing with data for training and/or testing - " +
					$"got: {args.Length}, expected: 1-2.");
			}
			else if (dataArgs.Length == 1 && dataArgs.Contains(ArgumentsConsts.DATA_FILE_PATH_ARG))
			{
				(var gesturesData, gesturesDataFilePath, bool getGesturesDataIsSuccess) = GetGesturesData(methodName, args, methodArgToIdx, ArgumentsConsts.DATA_FILE_PATH_ARG, gestureDataViewType, true);
				if (getGesturesDataIsSuccess)
				{
					var (testFraction, getTestFractionIsSuccess) = GetArgDoubleValue(methodName, args, methodArgToIdx, ArgumentsConsts.TEST_DATA_FRACTION_ARG, false);

					setDataParams = new GestureRecognitionModelSetDataParameters()
					{
						Data = gesturesData,
						TestFraction = getTestFractionIsSuccess ? testFraction : 0.2d
					};
				}
			}
			else if (dataArgs.Length == 2 && dataArgs.Contains(ArgumentsConsts.TRAIN_DATA_FILE_PATH_ARG) && dataArgs.Contains(ArgumentsConsts.TEST_DATA_FILE_PATH_ARG))
			{
				(var gesturesTrainData, gesturesTrainDataFilePath, bool getGesturesTrainDataIsSuccess) = GetGesturesData(methodName, args, methodArgToIdx, ArgumentsConsts.TRAIN_DATA_FILE_PATH_ARG, gestureDataViewType, true);
				if (getGesturesTrainDataIsSuccess)
				{
					(var gesturesTestData, gesturesTestDataFilePath, bool getGesturesTestDataIsSuccess) = GetGesturesData(methodName, args, methodArgToIdx, ArgumentsConsts.TEST_DATA_FILE_PATH_ARG, gestureDataViewType, true);
					if (getGesturesTestDataIsSuccess)
					{
						setDataParams = new GestureRecognitionModelSetDataParameters()
						{
							TrainData = gesturesTrainData,
							TestData = gesturesTestData
						};
					}
				}
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"[{methodName}] Invalid arguments regarding files providing with data for training and/or testing.");
			}

			return (setDataParams, gesturesDataFilePath, gesturesTrainDataFilePath, gesturesTestDataFilePath);
		}

		private static GestureRecognitionModelEvaluateParameters GetEvaluationParams(string methodName, string[] args, Dictionary<string, int> methodArgToIdx)
		{
			return new GestureRecognitionModelEvaluateParameters();
		}
		#endregion

		#region Get argument value methods
		private static (int? value, bool isSuccess) GetArgIntValue(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			var (stringValue, isSuccess) = GetArgValue(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return (null, false);

			if (int.TryParse(stringValue, CultureInfo.InvariantCulture, out int value))
				return (value, true);

			ConsoleOutputUtils.WriteLine(methodName, $"The int type was expected for argument {argName}.");
			return (null, false);
		}

		private static (uint? value, bool isSuccess) GetArgUIntValue(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			var (stringValue, isSuccess) = GetArgValue(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return (null, false);

			if (uint.TryParse(stringValue, CultureInfo.InvariantCulture, out uint value))
				return (value, true);

			ConsoleOutputUtils.WriteLine(methodName, $"The int type was expected for argument {argName}.");
			return (null, false);
		}

		private static (double value, bool isSuccess) GetArgDoubleValue(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			var (stringValue, isSuccess) = GetArgValue(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return (double.NaN, false);

			if (double.TryParse(stringValue, CultureInfo.InvariantCulture, out double value))
				return (value, true);

			ConsoleOutputUtils.WriteLine(methodName, $"The double type was expected for argument {argName}.");
			return (double.NaN, false);
		}

		private static (bool? value, bool isSuccess) GetArgBoolValue(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			var (stringValue, isSuccess) = GetArgValue(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return (null, false);

			if (bool.TryParse(stringValue, out bool value))
				return (value, true);

			ConsoleOutputUtils.WriteLine(methodName, $"The bool type was expected for argument {argName}.");
			return (null, false);
		}

		private static (string value, bool isSuccess) GetArgValue(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			if (!methodArgToIdx.TryGetValue(argName, out int argIdx))
			{
				if (argIsRequired)
					ConsoleOutputUtils.WriteLine(methodName, $"No argument named {argName} provided.");
				
				return (string.Empty, false);
			}

			if (args.Length <= argIdx + 1)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"No value provided for argument {argName}.");
				return (string.Empty, false);
			}

			string argValue = args[argIdx + 1];

			if (string.IsNullOrEmpty(argValue))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Empty value provided for argument {argName}.");
				return (string.Empty, false);
			}

			return (argValue, true);	
		}

		private static (SearchSpaceIntRangeValues? values, bool isSuccess) GetSearchSpaceIntRangeValues(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			var (minValue, maxValue, defValue, isSuccess) = GetSearchSpaceRangeValues(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return (null, false);

			if (int.TryParse(minValue, CultureInfo.InvariantCulture, out int min) &&
				int.TryParse(maxValue, CultureInfo.InvariantCulture, out int max) &&
				int.TryParse(defValue, CultureInfo.InvariantCulture, out int def))
			{
				if (min > max)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"The minimum value should be less than the maximum value for argument {argName} - got: min={min}, max={max}.");
					return (null, false);
				}
				else if (min == max && min != def)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"The minimum and maximum values are equal, so the default value should be equal to them for argument {argName} - got: min={min}, max={max}, default={def}.");
					return (null, false);
				}
				else if (def < min || def > max)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"The default value should be between the minimum and maximum values for argument {argName} - got: min={min}, max={max}, default={def}.");
					return (null, false);
				}

				return (new SearchSpaceIntRangeValues() { Min = min, Max = max, Default = def}, true);
			}

			ConsoleOutputUtils.WriteLine(methodName, $"The int type was expected for argument {argName}.");
			return (null, false);
		}

		private static (SearchSpaceDoubleRangeValues? values, bool isSuccess) GetSearchSpaceDoubleRangeValues(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			var (minValue, maxValue, defValue, isSuccess) = GetSearchSpaceRangeValues(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return (null, false);

			if (double.TryParse(minValue, CultureInfo.InvariantCulture, out double min) &&
				double.TryParse(maxValue, CultureInfo.InvariantCulture, out double max) &&
				double.TryParse(defValue, CultureInfo.InvariantCulture, out double def))
			{
				if (min > max)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"The minimum value should be less than the maximum value for argument {argName} - got: min={min}, max={max}.");
					return (null, false);
				}
				else if (min == max && min != def)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"The minimum and maximum values are equal, so the default value should be equal to them for argument {argName} - got: min={min}, max={max}, default={def}.");
					return (null, false);
				}
				else if (def < min || def > max)
				{
					ConsoleOutputUtils.WriteLine(methodName, $"The default value should be between the minimum and maximum values for argument {argName} - got: min={min}, max={max}, default={def}.");
					return (null, false);
				}

				return (new SearchSpaceDoubleRangeValues() { Min = min, Max = max, Default = def }, true);
			}

			ConsoleOutputUtils.WriteLine(methodName, $"The double type was expected for argument {argName}.");
			return (null, false);
		}

		private static (SearchSpaceValues<bool>? values, bool isSuccess) GetSearchSpaceBoolValues(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName, bool argIsRequired)
		{
			if (!methodArgToIdx.TryGetValue(argName, out int argIdx))
			{
				if (argIsRequired)
					ConsoleOutputUtils.WriteLine(methodName, $"No argument named {argName} provided.");

				return (null, false);
			}

			if (args.Length <= argIdx + 2)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Not enough values provided for argument {argName} - got: {args.Length - (argIdx + 1)}, expected: 2.");
				return (null, false);
			}

			if (!bool.TryParse(args[argIdx + 2], out bool defValue))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"The bool type was expected for default value for argument {argName}.");
				return (null, false);
			}

			bool[] boolValues;
			if (int.TryParse(args[argIdx + 1], CultureInfo.InvariantCulture, out int boolValuesCount) && (boolValuesCount == 1 || boolValuesCount == 2))
			{
				if (boolValuesCount == 1)
					boolValues = [defValue];
				else
					boolValues = [true, false];
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Incorrect value indicating how many bool values there should be for argument {argName} - " +
					$"got: {args[argIdx + 1]}, expected: 1 or 2.");
				return (null, false);
			}

			return (new SearchSpaceValues<bool>() { Values = boolValues, Default = defValue }, true);
		}

		private static (string min, string max, string def, bool isSuccess) GetSearchSpaceRangeValues(string methodName, string[] args, Dictionary<string, int> methodArgToIdx,
			string argName, bool argIsRequired)
		{
			if (!methodArgToIdx.TryGetValue(argName, out int argIdx))
			{
				if (argIsRequired)
					ConsoleOutputUtils.WriteLine(methodName, $"No argument named {argName} provided.");

				return (string.Empty, string.Empty, string.Empty, false);
			}

			if (args.Length <= argIdx + 3)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Not enough values provided for argument {argName} - got: {args.Length - (argIdx + 1)}, expected: 3.");
				return (string.Empty, string.Empty, string.Empty, false);
			}

			string minValue = args[argIdx + 1];
			if (string.IsNullOrEmpty(minValue))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Empty minimum value provided for argument {argName}.");
				return (string.Empty, string.Empty, string.Empty, false);
			}

			string maxValue = args[argIdx + 2];
			if (string.IsNullOrEmpty(maxValue))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Empty maximum value provided for argument {argName}.");
				return (string.Empty, string.Empty, string.Empty, false);
			}

			string defValue = args[argIdx + 3];
			if (string.IsNullOrEmpty(defValue))
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Empty default value provided for argument {argName}.");
				return (string.Empty, string.Empty, string.Empty, false);
			}

			return (minValue, maxValue, defValue, true);
		}
		#endregion

		#region Get gestures data methods
		private static (GestureDataView[] data, string dataFilePath, bool isSuccess) GetGesturesData(string methodName, string[] args, Dictionary<string, int> methodArgToIdx, string argName,
			Type gestureDataViewType, bool argIsRequired)
		{
			var (dataFilePath, isSuccess) = GetArgValue(methodName, args, methodArgToIdx, argName, argIsRequired);
			if (!isSuccess)
				return ([], dataFilePath, false);

			return GetGesturesData(methodName, dataFilePath, gestureDataViewType);
		}

		private static (GestureDataView[] data, string dataFilePath, bool isSuccess) GetGesturesData(string methodName, string gesturesDataFilePath, Type gestureDataViewType)
		{
			GestureDataView[] gesturesData = [];
			if (gestureDataViewType == typeof(KinectGestureDataView))
			{
				(gesturesData, string getGesturesDataErrorMsg) = GestureDataUtils.GetGesturesData<KinectGestureDataView>(gesturesDataFilePath);

				if (!string.IsNullOrEmpty(getGesturesDataErrorMsg))
				{
					ConsoleOutputUtils.WriteLine(methodName, getGesturesDataErrorMsg);
					return ([], gesturesDataFilePath, false);
				}

			}
			else if (gestureDataViewType == typeof(MediaPipeHandLandmarksGestureDataView))
			{
				(gesturesData, string getGesturesDataErrorMsg) = GestureDataUtils.GetGesturesData<MediaPipeHandLandmarksGestureDataView>(gesturesDataFilePath);

				if (!string.IsNullOrEmpty(getGesturesDataErrorMsg))
				{
					ConsoleOutputUtils.WriteLine(methodName, getGesturesDataErrorMsg);
					return ([], gesturesDataFilePath, false);
				}
			}

			return (gesturesData, gesturesDataFilePath, true);
		}
		#endregion

		#endregion
	}
}
