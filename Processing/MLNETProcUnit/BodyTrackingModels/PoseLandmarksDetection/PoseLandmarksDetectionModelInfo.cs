namespace GestureRecognition.Processing.MLNETProcUnit.BodyTrackingModels.PoseLandmarksDetection
{
	public static class PoseLandmarksDetectionModelInfo
	{
		public const string FULL_MODEL_FILE_NAME = "pose_landmarks_detector_full.onnx";
		public const string FULL_MODEL_FILE_PATH = $@"BodyTrackingModels/PoseLandmarksDetection/{FULL_MODEL_FILE_NAME}";
		public const int INPUT_IMAGE_WIDTH = 256;
		public const int INPUT_IMAGE_HEIGHT = 256;
		public const string INPUT_IMAGE_COLUMN_NAME = "input_1";
		public const string OUTPUT_LANDMARKS_COLUMN_NAME = "Identity";
		public const string OUTPUT_CONFIDENCE_SCORE_COLUMN_NAME = "Identity_1";
		public const int LANDMARKS_COUNT = 33;
		public const int LANDMARKS_FEATURES = 5;
		public const int LANDMARKS_COLUMN_LENGTH = 195;
	}
}
