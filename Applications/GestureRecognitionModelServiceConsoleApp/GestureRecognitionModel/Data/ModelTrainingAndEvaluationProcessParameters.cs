using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data
{
	public class ModelTrainingAndEvaluationProcessParameters
	{
		#region Public properties
		public string? DataFilePath
		{
			get;
			set;
		}

		public string? TrainDataFilePath
		{
			get;
			set;
		}

		public string? TestDataFilePath
		{
			get;
			set;
		}

		public required GestureRecognitionModelSetDataParameters SetDataParams 
		{ 
			get; 
			set; 
		}

		public required GestureRecognitionModelTrainParameters TrainingParams
		{
			get;
			set;
		}

		public required GestureRecognitionModelEvaluateParameters EvaluationParams
		{
			get;
			set;
		}

		public string? ModelFilePath
		{
			get;
			set;
		}

		public string? ModelProcessResultFilePath
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.DataFilePath)}: {this.DataFilePath ?? string.Empty}\n" +
				$"{nameof(this.TrainDataFilePath)}: {this.TrainDataFilePath ?? string.Empty}\n" +
				$"{nameof(this.TestDataFilePath)}: {this.TestDataFilePath ?? string.Empty}\n\n" +
				$"{nameof(this.SetDataParams)}:\n" +
				$"{this.SetDataParams}\n\n" +
				$"{nameof(this.TrainingParams)}:\n" +
				$"{this.TrainingParams}\n\n" +
				$"{nameof(this.EvaluationParams)}:\n" +
				$"{this.EvaluationParams}\n\n" +
				$"Model file path: {this.ModelFilePath ?? string.Empty}\n" +
				$"Result file path: {this.ModelProcessResultFilePath ?? string.Empty}";
		}
		#endregion
	}
}
