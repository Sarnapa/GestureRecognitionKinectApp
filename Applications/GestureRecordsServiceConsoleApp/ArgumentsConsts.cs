using GestureRecognition.Processing.BaseClassLib.Structures.DataPreparation;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp
{
	internal static class ArgumentsConsts
	{
		public static readonly string[] GESTURE_LABELS = [GestureLabel.hello.ToString(), GestureLabel.goodbye.ToString(),
		GestureLabel.please.ToString(), GestureLabel.sorry.ToString(), GestureLabel.thank_you.ToString(), GestureLabel.yes.ToString(), GestureLabel.no.ToString(),
		GestureLabel.dont_know.ToString(), GestureLabel.house.ToString(), GestureLabel.book.ToString()];

		public const string FILE_MODE = "-f";
		public const string DIRECTORY_MODE = "-d";
		public const string KINECT_TRACKING_MODE = "-kinect";
		public const string MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE = "-hand";

		public const string CALCULATION_FEATURES_METHOD = "-calcFeatures";
		public const string PREPARE_GESTURE_DATA_METHOD = "-prepGestureData";
	}
}
