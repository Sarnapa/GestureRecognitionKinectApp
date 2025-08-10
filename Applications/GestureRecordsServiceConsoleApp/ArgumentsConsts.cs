namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp
{
	internal static class ArgumentsConsts
	{
		public static readonly string[] GESTURE_LABELS = [HELLO_GESTURE_LABEL, GOODBYE_GESTURE_LABEL,
		PLEASE_GESTURE_LABEL, SORRY_GESTURE_LABEL, THANK_YOU_GESTURE_LABEL, YES_GESTURE_LABEL, NO_GESTURE_LABEL,
		DONT_KNOW_GESTURE_LABEL, HOUSE_GESTURE_LABEL, BOOK_GESTURE_LABEL];

		public const string FILE_MODE = "-f";
		public const string DIRECTORY_MODE = "-d";
		public const string KINECT_TRACKING_MODE = "-kinect";
		public const string MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE = "-hand";

		public const string HELLO_GESTURE_LABEL = "hello";
		public const string GOODBYE_GESTURE_LABEL = "goodbye";
		public const string PLEASE_GESTURE_LABEL = "please";
		public const string SORRY_GESTURE_LABEL = "sorry";
		public const string THANK_YOU_GESTURE_LABEL = "thank you";
		public const string YES_GESTURE_LABEL = "yes";
		public const string NO_GESTURE_LABEL = "no";
		public const string DONT_KNOW_GESTURE_LABEL = "don't know";
		public const string HOUSE_GESTURE_LABEL = "house";
		public const string BOOK_GESTURE_LABEL = "book";

		public const string CALCULATION_FEATURES_METHOD = "-calcFeatures";
		public const string PREPARE_GESTURE_DATA_METHOD = "-prepGestureData";
	}
}
