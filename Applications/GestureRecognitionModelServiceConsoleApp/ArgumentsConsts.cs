namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp
{
	internal static class ArgumentsConsts
	{
		public const string MODEL_TRAINING_AND_EVALUATION = "modelTrainAndEval";
		public const string MODEL_EVALUATION = "modelEval";
	
		public const string DATA_FILE_PATH_ARG = "-data";
		public const string TRAIN_DATA_FILE_PATH_ARG = "-trainData";
		public const string TEST_DATA_FILE_PATH_ARG = "-testData";
		public static readonly string[] DATA_FILE_PATH_ARGS = [DATA_FILE_PATH_ARG, TRAIN_DATA_FILE_PATH_ARG, TEST_DATA_FILE_PATH_ARG];

		public const string TEST_DATA_FRACTION_ARG = "-testFrac";

		public const string GESTURE_DATA_VIEW_TYPE_ARG = "-dataViewType";
		public const string KINECT_GESTURE_DATA_VIEW_TYPE = "kinect";
		public const string MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE = "hand";

		public const string MODEL_FILE_PATH_ARG = "-filePath";

		public const string SEED_ARG = "-seed";

		// Unnecessary yet, therefore no support added.
		// public const string EXCLUDED_FEATURES_ARG = "-excludedFeat";
		public const string USE_PCA_ARG = "-usePca";
		public const string PCA_RANK_ARG = "-pcaRank";

		public const string FAST_FOREST_ALG_ARG = "-ff";
		public const string FAST_FOREST_TREES_COUNT_ARG = "-treesCount";
		public const string FAST_FOREST_LEAVES_COUNT_ARG = "-leavesCount";
		public const string FAST_FOREST_MIN_EXAMPLE_COUNT_PER_LEAF_ARG = "-minExCountPerLeaf";
		public const string FAST_FOREST_FEATURE_FRACTION_ARG = "-featFrac";
		public const string FAST_FOREST_BAGGING_EXAMPLE_FRACTION_ARG = "-bagExFrac";

		public const string EVAL_RESULT_PRESENTATION_TITLE = "-evalPresTitle";
	}
}
