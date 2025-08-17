using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data
{
	public class ModelTrainingAndEvaluationProcessParameters
	{
		#region Public properties
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
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"\n{nameof(this.SetDataParams)}:\n" +
				$"{this.SetDataParams}\n\n" +
				$"{nameof(this.TrainingParams)}:\n" +
				$"{this.TrainingParams}\n\n" +
				$"{nameof(this.EvaluationParams)}:\n" +
				$"{this.EvaluationParams}\n\n" +
				$"Model file path: {this.ModelFilePath ?? string.Empty}";
		}
		#endregion
	}
}
