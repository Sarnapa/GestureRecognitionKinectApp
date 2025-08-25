using System;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region TuneHyperparams parameters
	public abstract class BaseTuneHyperparamsParameters: BaseParameters
	{
		#region Public properties
		public int? MaxModelToExploreCount
		{
			get;
			set;
		}

		public uint? TrainingTimeInSeconds
		{
			get;
			set;
		}

		public HyperparamsTunerKind HyperparamsTuner
		{
			get;
			set;
		} = HyperparamsTunerKind.GridSearch;

		public int GridSearchStepSize
		{
			get;
			set;
		} = 3;

		public int FoldsCount
		{
			get;
			set;
		} = 1;
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.MaxModelToExploreCount)}: {this.MaxModelToExploreCount ?? -1}\n" +
				$"{nameof(this.TrainingTimeInSeconds)}: {this.TrainingTimeInSeconds ?? 0}\n" +
				$"{nameof(this.HyperparamsTuner)}: {this.HyperparamsTuner}\n" +
				$"{nameof(this.GridSearchStepSize)}: {this.GridSearchStepSize}\n" +
				$"{nameof(this.FoldsCount)}: {this.FoldsCount}";
		}
		#endregion
	}

	public class GestureRecognitionModelTuneHyperparamsParameters: BaseTuneHyperparamsParameters
	{
		#region Public properties
		public MulticlassClassificationMetricKind MainMetric
		{
			get;
			set;
		} = MulticlassClassificationMetricKind.MacroAccuracy;

		public string[] ExcludedFeatures
		{
			get;
			set;
		} = new string[0];

		public PrepareDataSearchSpaceValues PrepareDataSearchSpace
		{
			get;
			set;
		} = new PrepareDataSearchSpaceValues();

		// TODO: There should be a generalization
		public FastForestSearchSpaceValues FastForestSearchSpace
		{
			get;
			set;
		} = new FastForestSearchSpaceValues();
		#endregion

		#region Public methods
		public override string ToString()
		{
			string exclucedFeaturesText = this.ExcludedFeatures == null ? "[]" :
				$"[{string.Join(", ", this.ExcludedFeatures)}]";

			return $"{base.ToString()}\n" +
				$"{nameof(this.MainMetric)}: {this.MainMetric}\n" +
				$"{nameof(this.ExcludedFeatures)}: {exclucedFeaturesText}\n\n" +
				$"{nameof(this.PrepareDataSearchSpace)}:\n{this.PrepareDataSearchSpace}\n\n" +
				$"{nameof(this.FastForestSearchSpace)}:\n{this.FastForestSearchSpace}";
		}
		#endregion
	}
	#endregion

	#region TuneHyperparams result
	public abstract class BaseTuneHyperparamsResult: BaseResult
	{
		#region Public properties
		public TuneHyperparamsErrorKind ErrorKind
		{
			get;
			set;
		} = TuneHyperparamsErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == TuneHyperparamsErrorKind.None;
			}
		}

		public MulticlassClassificationMetricKind MainMetric
		{
			get;
			set;
		}

		public double MainMetricValue
		{
			get;
			set;
		}

		public double LossValue
		{
			get;
			set;
		}

		public TimeSpan Duration
		{
			get;
			set;
		}

		public double PeakCpu
		{
			get;
			set;
		}

		public double PeakMemoryInMegaByte
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.MainMetric)}: {this.MainMetric}\n" +
				$"{nameof(this.MainMetricValue)}: {this.MainMetricValue}\n" +
				$"{nameof(this.LossValue)}: {this.LossValue}\n" +
				$"{nameof(this.Duration)}: {this.Duration}\n" +
				$"{nameof(this.PeakCpu)}: {this.PeakCpu}\n" +
				$"{nameof(this.PeakMemoryInMegaByte)}: {this.PeakMemoryInMegaByte}";
		}
		#endregion
	}

	public class GestureRecognitionModelTuneHyperparamsResult: BaseTuneHyperparamsResult
	{
		#region Public properties
		public PrepareDataHyperparams PrepareDataHyperparams
		{
			get;
			set;
		} = new PrepareDataHyperparams();

		public BaseClassificationAlgorithmParams AlgorithmParams
		{
			get;
			set;
		} = new FastForestParams();
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{base.ToString()}\n\n" +
				$"{nameof(this.PrepareDataHyperparams)}:\n" +
				$"{this.PrepareDataHyperparams}\n\n" +
				$"{nameof(this.AlgorithmParams)}:\n" +
				$"{this.AlgorithmParams}";
		}
		#endregion
	}
	#endregion

	#region TuneHyperparamsErrorKind
	public enum TuneHyperparamsErrorKind
	{
		None,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
