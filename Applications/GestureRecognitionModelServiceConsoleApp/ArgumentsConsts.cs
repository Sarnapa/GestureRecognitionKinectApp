namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp
{
	internal static class ArgumentsConsts
	{
		public const string MODEL_TUNEHYPERPARAMS_TRAINING_AND_EVALUATION = "modelTuneHyperparamsTrainAndEval";
		public const string MODEL_TRAINING_AND_EVALUATION = "modelTrainAndEval";
		public const string MODEL_EVALUATION = "modelEval";
		public const string MODEL_PREDICTIONS_PERFORMANCE_TEST = "modelPredPerfTest";
	
		public const string DATA_FILE_PATH_ARG = "-dataFilePath";
		public const string TRAIN_DATA_FILE_PATH_ARG = "-trainDataFilePath";
		public const string TEST_DATA_FILE_PATH_ARG = "-testDataFilePath";
		public static readonly string[] DATA_FILE_PATH_ARGS = [DATA_FILE_PATH_ARG, TRAIN_DATA_FILE_PATH_ARG, TEST_DATA_FILE_PATH_ARG];
		public const string PREDICTIONS_PERFORMANCE_TEST_DATA_FILE_PATH_ARG = "-predPerfTestDataFilePath";

		public const string TEST_DATA_FRACTION_ARG = "-testFrac";

		public const string GESTURE_DATA_VIEW_TYPE_ARG = "-dataViewType";
		public const string KINECT_GESTURE_DATA_VIEW_TYPE = "kinect";
		public const string MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE = "hand";

		public const string MODEL_FILE_PATH_ARG = "-modelFilePath";

		public const string SEED_ARG = "-seed";

		public const string USE_CV_ARG = "-useCv";
		public const string CV_FOLDS_COUNT_ARG = "-foldsCount";
		public const string MODEL_CV_PROCESS_RESULT_FILE_PATH = "-cvResultFilePath";

		// Unnecessary yet, therefore no support added.
		// public const string EXCLUDED_FEATURES_ARG = "-excludedFeat";
		public const string PCA_RANK_ARG = "-pcaRank";

		public const string FAST_FOREST_ALG_ARG = "-ff";
		public const string FAST_FOREST_TREES_COUNT_ARG = "-treesCount";
		public const string FAST_FOREST_LEAVES_COUNT_ARG = "-leavesCount";
		public const string FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG = "-minExCountPerLeaf";
		public const string FAST_FOREST_FEATURE_FRACTION_ARG = "-featFrac";
		public const string FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG = "-bagExFrac";

		public const string TUNE_HYPERPARAMS_MAX_MODEL_TO_EXPLORE_COUNT_ARG = "-maxModelsCount";
		public const string TUNE_HYPERPARAMS_TRAINING_TIME_IN_SECONDS_ARG = "-trainTimeInSec";
		public const string TUNE_HYPERPARAMS_GRID_SEARCH_STEP_SIZE_ARG = "-gridSearchStepSize";
		public const string TUNE_HYPERPARAMS_FOLDS_COUNT_ARG = "-tuneFoldsCount";

		public const string TUNE_HYPERPARAMS_TUNER_ARG = "-tuner";
		public const string HYPERPARAMS_TUNER_GRIDSEARCH = "gridSearch";
		public const string HYPERPARAMS_TUNER_RANDOMSEARCH = "randomSearch";
		public const string HYPERPARAMS_TUNER_COSTFRUGAL = "costFrugal";
		public const string HYPERPARAMS_TUNER_ECICOSTFRUGAL = "eciCostFrugal";
		public const string HYPERPARAMS_TUNER_SMAC = "smac";

		public const string TUNE_HYPERPARAMS_MAIN_METRIC_ARG = "-mainMetric";
		public const string MULTICLASS_CLASSIFICATION_METRIC_MICROACCURACY = "microAccuracy";
		public const string MULTICLASS_CLASSIFICATION_METRIC_MACROACCURACY = "macroAccuracy";
		public const string MULTICLASS_CLASSIFICATION_METRIC_LOGLOSS = "logLoss";
		public const string MULTICLASS_CLASSIFICATION_METRIC_LOGGLOSSREDUCTION = "logLossReduction";

		public const string TUNE_HYPERPARAMS_PCA_RANK_ARG = "-tunePcaRank";

		public const string TUNE_HYPERPARAMS_FAST_FOREST_TREES_COUNT_ARG = "-tuneTreesCount";
		public const string TUNE_HYPERPARAMS_FAST_FOREST_LEAVES_COUNT_ARG = "-tuneLeavesCount";
		public const string TUNE_HYPERPARAMS_FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG = "-tuneMinExCountPerLeaf";
		public const string TUNE_HYPERPARAMS_FAST_FOREST_FEATURE_FRACTION_ARG = "-tuneFeatFrac";
		public const string TUNE_HYPERPARAMS_FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG = "-tuneBagExFrac";

		public const string PREDICTIONS_PERFORMANCE_TESTS_COUNT = "-predPerfTestsCount";

		public const string MODEL_PROCESS_RESULT_FILE_PATH = "-resultFilePath";
		public const string PREDICTIONS_PERFORMANCE_TEST_RESULT_FILE_PATH = "-predPerfTestResultFilePath";
	}
}
