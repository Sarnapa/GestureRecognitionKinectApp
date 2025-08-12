using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Utils;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureData
{
	public static class GestureDataUtils
	{
		#region Public methods
		public static (T[] gesturesData, string errorMessage) GetGesturesData<T>(string filePath)
			where T : GestureDataView
		{
			string methodName = $"{nameof(GestureDataUtils)}.{nameof(GetGesturesData)}"; 

			if (string.IsNullOrEmpty(filePath))
				return ([], $"Given file path is empty.");

			if (!filePath.EndsWith(CsvHelperUtils.CsvFileExtension))
				return ([], $"Given file path is in invalid format - expected CSV format file. File path: [{filePath}].");

			if (!File.Exists(filePath))
				return ([], $"Given file doesn't exist. File path: [{filePath}].");

			var gesturesData = CsvHelperUtils.GetGesturesFromFile<T>(filePath).ToArray();
			if (gesturesData.Length == 0)
				return ([], $"Given file has no gestures data. File path: [{filePath}].");

			return (gesturesData, string.Empty);
		}
		#endregion
	}
}
