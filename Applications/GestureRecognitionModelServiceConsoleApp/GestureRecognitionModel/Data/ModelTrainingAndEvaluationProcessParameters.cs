namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data
{
	public class ModelTrainingAndEvaluationProcessParameters
	{
		#region Public properties
		public required ModelTrainingParameters TrainingParams
		{
			get;
			set;
		}

		public required ModelEvaluationParameters EvaluationParams
		{
			get;
			set;
		}
		#endregion
	}
}
