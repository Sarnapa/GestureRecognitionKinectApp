using System.Linq;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition
{
	#region MulticlassClassificationEvalResult
	public class MulticlassClassificationEvalResult
	{
		#region Public properties
		public int NumberOfClasses
		{
			get;
			set;
		}

		public double MicroAccuracy
		{
			get;
			set;
		}

		public double MicroPrecision
		{
			get;
			set;
		}

		public double MicroRecall
		{
			get;
			set;
		}

		public double MicroF1
		{
			get;
			set;
		}

		public double LogLoss
		{
			get;
			set;
		}

		public double MacroAccuracy
		{
			get;
			set;
		}

		public double MacroPrecision
		{
			get;
			set;
		}

		public double MacroRecall
		{
			get;
			set;
		}

		public double MacroF1
		{
			get;
			set;
		}

		public double PerClassLogLossAvg
		{
			get;
			set;
		}

		public int SamplesTotalCount
		{
			get;
			set;
		}

		public PerClassEvalResult[] PerClassEvalResults
		{
			get;
			set;
		} = new PerClassEvalResult[0];

		public string FormattedConfusionTable
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			string perClassEvalResultsText = string.Join("\n\n", this.PerClassEvalResults?.Select(r => r.ToString()) ?? new string[0]);

			return $"{nameof(this.NumberOfClasses),-21}: {this.NumberOfClasses}\n" +
				$"{nameof(this.MicroAccuracy),-21}: {this.MicroAccuracy,5:F4}\n" +
				$"{nameof(this.MicroPrecision),-21}: {this.MicroPrecision,5:F4}\n" +
				$"{nameof(this.MicroRecall),-21}: {this.MicroRecall,5:F4}\n" +
				$"{nameof(this.MicroF1),-21}: {this.MicroF1,5:F4}\n" +
				$"{nameof(this.LogLoss),-21}: {this.LogLoss,5:F4}\n" +
				$"{nameof(this.MacroAccuracy),-21}: {this.MacroAccuracy,5:F4}\n" +
				$"{nameof(this.MacroPrecision),-21}: {this.MacroPrecision,5:F4}\n" +
				$"{nameof(this.MacroRecall),-21}: {this.MacroRecall,5:F4}\n" +
				$"{nameof(this.MacroF1),-21}: {this.MacroF1,5:F4}\n" +
				$"{nameof(this.PerClassLogLossAvg),-21}: {this.PerClassLogLossAvg,5:F4}\n" +
				$"{nameof(this.SamplesTotalCount),-21}: {this.SamplesTotalCount}\n" +
				$"\nPer class evaluation results:\n\n{perClassEvalResultsText}\n\n" +
				$"{this.FormattedConfusionTable}";
		}
		#endregion
	}
	#endregion

	#region PerClassEvalResult
	public class PerClassEvalResult
	{
		#region Public methods
		public int ClassKey
		{
			get;
			set;
		}

		public string ClassLabel
		{
			get;
			set;
		}

		public int SamplesRealCount
		{
			get;
			set;
		}

		public int SamplesPredictedCount
		{
			get;
			set;
		}

		public double Precision
		{
			get;
			set;
		}

		public double Recall
		{
			get;
			set;
		}

		public double F1
		{
			get;
			set;
		}

		public double LogLoss
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.ClassKey),-21}: {this.ClassKey}\n" +
				$"{nameof(this.ClassLabel),-21}: {this.ClassLabel}\n" +
				$"{nameof(this.SamplesRealCount),-21}: {this.SamplesRealCount}\n" +
				$"{nameof(this.SamplesPredictedCount),-21}: {this.SamplesPredictedCount}\n" +
				$"{nameof(this.Precision),-21}: {this.Precision,5:F4}\n" +
				$"{nameof(this.Recall),-21}: {this.Recall,5:F4}\n" +
				$"{nameof(this.F1),-21}: {this.F1,5:F4}\n" +
				$"{nameof(this.LogLoss),-21}: {this.LogLoss,5:F4}";
		}
		#endregion
	}
	#endregion
}
