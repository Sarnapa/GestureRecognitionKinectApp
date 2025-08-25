using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Data
{
	public class ModelTuneHyperparamsTrainingAndEvaluationProcessParameters
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

		public bool UseCv
		{
			get;
			set;
		}

		public int CvFoldsCount
		{
			get;
			set;
		}

		public string? ModelCvProcessResultFilePath
		{
			get;
			set;
		}

		public required GestureRecognitionModelSetDataParameters SetDataParams
		{
			get;
			set;
		}

		public required GestureRecognitionModelTuneHyperparamsParameters TuneHyperparamsParams
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
				$"{nameof(this.UseCv)}: {this.UseCv}\n" +
				$"{nameof(this.CvFoldsCount)}: {this.CvFoldsCount}\n" +
				$"{nameof(this.ModelCvProcessResultFilePath)}: {this.ModelCvProcessResultFilePath ?? string.Empty}\n\n" +
				$"{nameof(this.SetDataParams)}:\n" +
				$"{this.SetDataParams}\n\n" +
				$"{nameof(this.TuneHyperparamsParams)}:\n" +
				$"{this.TuneHyperparamsParams}\n\n" +
				$"{nameof(this.EvaluationParams)}:\n" +
				$"{this.EvaluationParams}\n\n" +
				$"Model file path: {this.ModelFilePath ?? string.Empty}\n" +
				$"Result file path: {this.ModelProcessResultFilePath ?? string.Empty}";
		}
		#endregion
	}
}
