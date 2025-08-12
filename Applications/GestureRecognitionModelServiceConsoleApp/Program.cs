using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureData;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string methodName = $"{nameof(Program)}.{nameof(Main)}";
			ConsoleOutputUtils.WriteLine(methodName, "Starting GestureRecognitionModelServiceConsoleApp...");

			// For testing purposes
			args =
			[
				ArgumentsConsts.MODEL_TRAINING_AND_EVALUATION,
				@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\2025_08_11_MediaPipeHandLandmarks\GesturesData.csv",
				ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE,
			];

			if (args.Length != 3)
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Invalid arguments count - got: {args.Length}, expected: 3.");
				ConsoleOutputUtils.WriteLine(methodName, $"Press key to close console app.");
				Console.ReadKey();
				return;
			}

			string methodKindArg = args[0];

			MethodKind? methodKind = null;
			if (methodKindArg.Equals(ArgumentsConsts.MODEL_TRAINING_AND_EVALUATION, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.ModelTrainingAndEvaluation;
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
					case MethodKind.ModelTrainingAndEvaluation:
						ExecuteModelTrainingAndEvaluationProcess(args);
						break;
				}
			}

			ConsoleOutputUtils.WriteLine(methodName, $"Press key to close console app.");
			Console.ReadKey();
		}

		#region Private methods
		private static void ExecuteModelTrainingAndEvaluationProcess(string[] args)
		{
			string methodName = $"{nameof(Program)}.{nameof(ExecuteModelTrainingAndEvaluationProcess)}";

			string gesturesDataFilePath = args[1];
			string gestureDataViewTypeArg = args[2];

			Type? gestureDataViewType = null;
			if (gestureDataViewTypeArg.Equals(ArgumentsConsts.KINECT_GESTURE_DATA_VIEW_TYPE, StringComparison.OrdinalIgnoreCase))
			{
				gestureDataViewType = typeof(KinectGestureDataView);
			}
			else if (gestureDataViewTypeArg.Equals(ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE, StringComparison.OrdinalIgnoreCase))
			{
				gestureDataViewType = typeof(MediaPipeHandLandmarksGestureDataView);
			}
			else
			{
				ConsoleOutputUtils.WriteLine(methodName, $"Invalid {nameof(GestureDataView)} type argument - got: {gestureDataViewTypeArg}, " +
					$"expected: [{ArgumentsConsts.KINECT_GESTURE_DATA_VIEW_TYPE}, {ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_GESTURE_DATA_VIEW_TYPE}].");
			}

			if (gestureDataViewType != null)
			{
				GestureDataView[] gesturesData;
				string errorMessage;
				if (gestureDataViewType == typeof(KinectGestureDataView))
				{
					(gesturesData, errorMessage) = GestureDataUtils.GetGesturesData<KinectGestureDataView>(gesturesDataFilePath);
				}
				else
				{
					(gesturesData, errorMessage) = GestureDataUtils.GetGesturesData<MediaPipeHandLandmarksGestureDataView>(gesturesDataFilePath);
				}

				if (!string.IsNullOrEmpty(errorMessage))
				{
					ConsoleOutputUtils.WriteLine(methodName, errorMessage);
					return;
				}
				
				var gestureRecognitionModelManager = new GestureRecognitionModelManager(42);
				gestureRecognitionModelManager.ExecuteModelTrainingAndEvaluationProcess(gesturesData, gestureDataViewType);
			}
		}
		#endregion
	}
}
