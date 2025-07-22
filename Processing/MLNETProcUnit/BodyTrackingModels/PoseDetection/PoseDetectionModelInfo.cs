namespace GestureRecognition.Processing.MLNETProcUnit.BodyTrackingModels.PoseDetection
{
	public static class PoseDetectionModelInfo
	{
		public const string MODEL_FILE_NAME = "pose_detection.onnx";
		public const string MODEL_FILE_PATH = $@"BodyTrackingModels/PoseDetection/{MODEL_FILE_NAME}";
		public const int INPUT_IMAGE_WIDTH = 224;
		public const int INPUT_IMAGE_HEIGHT = 224;
		public const string INPUT_IMAGE_COLUMN_NAME = "input_1";
		public const string OUTPUT_COORDINATES_COLUMN_NAME = "Identity";
		public const string OUTPUT_CONFIDENCE_SCORES_COLUMN_NAME = "Identity_1";
	}
}
