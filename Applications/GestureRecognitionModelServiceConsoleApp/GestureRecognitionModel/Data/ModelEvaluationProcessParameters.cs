using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data
{
	public class ModelEvaluationProcessParameters
	{
		#region Public properties
		public required string ModelFilePath
		{
			get;
			set;
		}

		public required string TestDataFilePath
		{
			get;
			set;
		}

		public required GestureRecognitionModelSetDataParameters SetTestDataParameters
		{
			get;
			set;
		}

		public required GestureRecognitionModelEvaluateParameters EvaluationParams
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

		public override string ToString()
		{
			return $"Model file path: {this.ModelFilePath ?? string.Empty}\n" +
				$"{nameof(this.TestDataFilePath)}: {this.TestDataFilePath ?? string.Empty}\n\n" +
				$"{nameof(this.SetTestDataParameters)}:\n" +
				$"{this.SetTestDataParameters}\n\n" +
				$"{nameof(this.EvaluationParams)}:\n" +
				$"{this.EvaluationParams}\n\n" +
				$"Result file path: {this.ModelProcessResultFilePath ?? string.Empty}";
		}
	}
}
