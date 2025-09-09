namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Result
{
	public class ModelPredictionsPerformanceTestResult
	{
		public PredictionPerformanceInfo[] PredictionsInfo
		{
			get;
			set;
		} = [];
	}

	public class PredictionPerformanceInfo
	{
		public int DurationMicroseconds
		{
			get;
			set;
		}
	}
}
