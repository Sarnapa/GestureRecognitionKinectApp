using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.GestureRecognitionProcUnit;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureData
{
	public class GestureDataManager
	{
		#region Constructors
		public GestureDataManager() 
		{ }
		#endregion

		#region Public methods
		public void ExecutePrepareGesturesDataFileProcess(string inputDirectoryPath, string outputFilePath, BodyTrackingMode bodyTrackingMode)
		{
			string methodName = $"{nameof(GestureDataManager)}.{nameof(ExecutePrepareGesturesDataFileProcess)}";

			if (string.IsNullOrEmpty(inputDirectoryPath) || !Directory.Exists(inputDirectoryPath))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Input directory path is empty or directory does not exist: {inputDirectoryPath}.\n");
				return;
			}

			if (string.IsNullOrEmpty(outputFilePath) || !outputFilePath.EndsWith(CsvHelperUtils.CsvFileExtension))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Output file path is empty or invalid format: {outputFilePath}.\n");
				return;
			}

			string[] gestureDataFiles = Directory.GetFiles(inputDirectoryPath, $"*{CsvHelperUtils.CsvFileExtension}");

			if (gestureDataFiles != null && gestureDataFiles.Length > 0)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Found {gestureDataFiles.Length} gesture data files in directory {inputDirectoryPath}.\n");

				Console.WriteLine($"[{methodName}][{DateTime.Now}] Starting preparing gestures data file - file path: {outputFilePath}.\n");

				var (success, errorMessage) = PrepareGesturesDataFile(gestureDataFiles, outputFilePath, bodyTrackingMode);
				if (success)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Exported new gestures data file - file path: {outputFilePath}.\n");
				}
				else
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Preparing gestures data file failed - file path: {outputFilePath}, error message: {errorMessage}\n");
				}

				Console.WriteLine($"[{methodName}][{DateTime.Now}] Finished preparing gestures data file - file path: {outputFilePath}.\n");
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Not found gesture data files in directory {inputDirectoryPath}.\n");
			}
		}
		#endregion

		#region Private methods
		private static (bool success, string errorMessage) PrepareGesturesDataFile(string[] gestureDataFilesPaths, string gesturesDataOutputFilePath, BodyTrackingMode trackingMode)
		{
			var gestureRecognitionManager = new GestureRecognitionManager();

			var parameters = new PrepareGesturesDataForRecognitionModelParameters()
			{
				GestureDataFilesPaths = gestureDataFilesPaths,
				GesturesDataOutputFilePath = gesturesDataOutputFilePath,
				TrackingMode = trackingMode
			};
			var result = gestureRecognitionManager.PrepareGesturesDataForRecognitionModel(parameters);

			return (result.Success, result.ErrorMessage);
		}
		#endregion
	}
}
