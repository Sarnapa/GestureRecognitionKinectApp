using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data
{
	public class ModelPredictionsPerformanceTestParameters
	{
		#region Public properties
		public required string ModelFilePath
		{
			get;
			set;
		} = string.Empty;

		public required string ResultFilePath
		{
			get;
			set;
		} = string.Empty;

		public required GestureDataView[] GesturesData
		{
			get;
			set;
		} = [];

		public int TestsCount
		{
			get;
			set;
		} = 1;
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.ModelFilePath)}: {this.ModelFilePath ?? string.Empty}\n" +
				$"{nameof(this.ResultFilePath)}: {this.ResultFilePath ?? string.Empty}\n" +
				$"Gestures examples count: {this.GesturesData?.Length ?? 0}\n" +
				$"{nameof(this.TestsCount)}: {this.TestsCount}";
		}
		#endregion
	}
}
