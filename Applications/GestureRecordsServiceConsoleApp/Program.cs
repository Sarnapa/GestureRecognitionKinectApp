using GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			string methodName = $"{nameof(Main)}";
			Console.WriteLine($"[{methodName}][{DateTime.Now}] Starting GestureRecordsServiceConsoleApp...");

			//// For testing purposes
			//args =
			//[
			//	ArgumentsConsts.CALCULATION_FEATURES_METHOD,
			//	ArgumentsConsts.FILE_MODE,
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Yes\OldData\2025_02_02",
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Yes\2025_08_07\"
			//];


			if (args.Length < 4 && args.Length > 5)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid arguments count - given: {args.Length}, expected: 4 - 5.");
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.");
				Console.ReadKey();
				return;
			}

			string methodKindArg = args[0];
			string fileProcessModeArg = args[1];
			string inputPath = args[2];
			string outputPath = args[3];

			MethodKind? methodKind = null;
			if (methodKindArg.Equals(ArgumentsConsts.CALCULATION_FEATURES_METHOD, StringComparison.OrdinalIgnoreCase))
			{
				methodKind = MethodKind.CalculationGestureFeatures;
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid method argument - given: {methodKindArg}, expected: {ArgumentsConsts.CALCULATION_FEATURES_METHOD}.");
			}

			if (methodKind.HasValue)
			{
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
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid file processing mode argument - given: {fileProcessModeArg}, expected: {ArgumentsConsts.FILE_MODE} or {ArgumentsConsts.DIRECTORY_MODE}.");
				}

				if (fileProcessMode.HasValue)
				{
					switch (methodKind)
					{
						case MethodKind.CalculationGestureFeatures:
							BodyTrackingMode? trackingMode = null;
							bool validArgs = true;
							if (args.Length == 5)
							{
								string trackingModeArgs = args[4];
								switch (trackingModeArgs)
								{
									case ArgumentsConsts.CALCULATION_FEATURES_KINECT_TRACKING_MODE:
										trackingMode = BodyTrackingMode.Kinect;
										break;
									case ArgumentsConsts.CALCULATION_FEATURES_MEDIAPIPE_HAND_LANDMARKS_TRACKING_MODE:
										trackingMode = BodyTrackingMode.MediaPipeHandLandmarks;
										break;
									default:
										validArgs = false;
										Console.WriteLine($"[{methodName}][{DateTime.Now}] Unsupported tracking mode for CalculationGestureFeatures method." +
											$"Supported modes: [{BodyTrackingMode.Kinect}, {BodyTrackingMode.MediaPipeHandLandmarks}]. Method execution abandoned.");
										break;
								}

								if (validArgs)
								{
									var gestureFeaturesManager = new GestureFeaturesManager(fileProcessMode.Value, inputPath, outputPath, trackingMode);
									await gestureFeaturesManager.ExecuteCalculationFeaturesProcess().ConfigureAwait(false);
								}
							}
							break;
					}
				}
			}

			Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.");
			Console.ReadKey();
		}
	}
}
