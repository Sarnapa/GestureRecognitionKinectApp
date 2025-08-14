using GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureData;
using GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.DataPreparation;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			string methodName = $"{nameof(Main)}";
			Console.WriteLine($"[{methodName}][{DateTime.Now}] Starting GestureRecordsAndDataServiceConsoleApp...");

			// For testing purposes
			//args =
			//[
			//	ArgumentsConsts.CALCULATION_FEATURES_METHOD,
			//	ArgumentsConsts.DIRECTORY_MODE,
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\GesturesDataset\Kinect",
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\GesturesDataset\MediaPipeHandLandmarks",
			//	ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE,
			//	//GestureLabel.goodbye.ToString(),
			//];

			// For testing purposes
			//args =
			//[
			//	ArgumentsConsts.PREPARE_GESTURE_DATA_METHOD,
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\2025_08_11_MediaPipeHandLandmarks\Data",
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Models\2025_08_11_MediaPipeHandLandmarks\GesturesData.csv",
			//	ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE,
			//];

			if (args.Length < 4 || args.Length > 6)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid arguments count - given: {args.Length}, expected: 4 - 6.\n");
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.\n");
				Console.ReadKey();
				return;
			}

			string methodKindArg = args[0];

			MethodKind? methodKind = null;
			if (methodKindArg.Equals(ArgumentsConsts.CALCULATION_FEATURES_METHOD, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.CalculationGestureFeatures;
			}
			else if (methodKindArg.Equals(ArgumentsConsts.PREPARE_GESTURE_DATA_METHOD, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.PrepareGestureData;
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid method argument - given: {methodKindArg}, " +
					$"expected: [{ArgumentsConsts.CALCULATION_FEATURES_METHOD}, {ArgumentsConsts.PREPARE_GESTURE_DATA_METHOD}].\n");
			}

			if (methodKind.HasValue)
			{
				switch (methodKind)
				{
					case MethodKind.CalculationGestureFeatures:
						await ExecuteCalculationFeaturesProcess(args).ConfigureAwait(false);
						break;
					case MethodKind.PrepareGestureData:
						ExecutePrepareGesturesDataFileProcess(args);
						break;
				}
			}

			Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.");
			Console.ReadKey();
		}

		#region Private methods
		private static async Task ExecuteCalculationFeaturesProcess(string[] args)
		{
			string methodName = $"{nameof(ExecuteCalculationFeaturesProcess)}";

			string fileProcessModeArg = args[1];
			string inputPath = args[2];
			string outputPath = args[3];

			FileProcessMode? fileProcessMode = null;
			if (fileProcessModeArg.Equals(ArgumentsConsts.FILE_MODE, StringComparison.OrdinalIgnoreCase))
			{
				fileProcessMode = FileProcessMode.File;
			}
			else if (fileProcessModeArg.Equals(ArgumentsConsts.DIRECTORY_MODE, StringComparison.OrdinalIgnoreCase))
			{
				fileProcessMode = FileProcessMode.Directory;
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid file processing mode argument - given: {fileProcessModeArg}, expected: {ArgumentsConsts.FILE_MODE} or {ArgumentsConsts.DIRECTORY_MODE}.\n");
			}

			if (fileProcessMode.HasValue)
			{
				BodyTrackingMode? trackingMode = null;
				string? gestureLabel = null;

				bool validArgs = true;
				if (args.Length > 4)
				{
					string firstExtraArg = args[4].ToLower();
					switch (firstExtraArg)
					{
						case ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE:
							trackingMode = BodyTrackingMode.MediaPipeHandLandmarks;
							break;
						default:
							if (ArgumentsConsts.GESTURE_LABELS.Contains(firstExtraArg))
							{
								gestureLabel = firstExtraArg;
								validArgs = true;
							}
							else
							{
								validArgs = false;
								Console.WriteLine($"[{methodName}][{DateTime.Now}] Unsupported tracking mode as conversion output for CalculationGestureFeatures method." +
									$"Supported modes: [{BodyTrackingMode.MediaPipeHandLandmarks}]. Also not expected gesture label. Method execution abandoned.\n");
							}
							break;
					}

					if (args.Length == 6)
					{
						string secondExtraArg = args[5].ToLower();
						if (ArgumentsConsts.GESTURE_LABELS.Contains(secondExtraArg))
						{
							gestureLabel = secondExtraArg;
							validArgs = true;
						}
						else
						{
							validArgs = false;
							Console.WriteLine($"[{methodName}][{DateTime.Now}] Not expected gesture label. Method execution abandoned.\n");
						}
					}
				}

				if (validArgs)
				{
					var gestureFeaturesManager = new GestureFeaturesManager(fileProcessMode.Value, inputPath, outputPath, trackingMode, gestureLabel);
					await gestureFeaturesManager.ExecuteCalculationFeaturesProcess().ConfigureAwait(false);
				}
			}
		}

		private static void ExecutePrepareGesturesDataFileProcess(string[] args)
		{
			string methodName = $"{nameof(ExecutePrepareGesturesDataFileProcess)}";

			string inputDirectoryPath = args[1];
			string outputFilePath = args[2];
			string trackingModeArg = args[3];

			BodyTrackingMode? trackingMode = null;
			if (trackingModeArg.Equals(ArgumentsConsts.KINECT_TRACKING_MODE, StringComparison.OrdinalIgnoreCase))
			{
				trackingMode = BodyTrackingMode.Kinect;
			}
			else if (trackingModeArg.Equals(ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE, StringComparison.OrdinalIgnoreCase))
			{
				trackingMode = BodyTrackingMode.MediaPipeHandLandmarks;
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid tracking mode argument - given: {trackingModeArg}, expected: {ArgumentsConsts.KINECT_TRACKING_MODE} or {ArgumentsConsts.MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE}.\n");
			}

			if (trackingMode.HasValue)
			{
				var gestureDataManager = new GestureDataManager();
				gestureDataManager.ExecutePrepareGesturesDataFileProcess(inputDirectoryPath, outputFilePath, trackingMode.Value);
			}
		}
		#endregion
	}
}
