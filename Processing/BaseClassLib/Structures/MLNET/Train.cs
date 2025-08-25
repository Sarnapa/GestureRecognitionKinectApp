using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region TrainParameters
	public abstract class BaseTrainParameters: BaseParameters
	{
	}

	public class GestureRecognitionModelTrainParameters: BaseTrainParameters
	{
		#region Public properties
		public string[] ExcludedFeatures
		{
			get;
			set;
		} = new string[0];

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
			string exclucedFeaturesText = this.ExcludedFeatures == null ? "[]" :
				$"[{string.Join(", ", this.ExcludedFeatures)}]";

			return $"{nameof(this.ExcludedFeatures)}: {exclucedFeaturesText}\n\n" +
				$"{nameof(this.PrepareDataHyperparams)}:\n" +
				$"{this.PrepareDataHyperparams}\n\n" +
				$"{nameof(this.AlgorithmParams)}:\n" +
				$"{this.AlgorithmParams}";
		}
		#endregion
	}
	#endregion

	#region TrainResult
	public abstract class BaseTrainResult: BaseResult
	{
		#region Public properties
		public TrainErrorKind ErrorKind
		{
			get;
			set;
		} = TrainErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == TrainErrorKind.None;
			}
		}
		#endregion
	}

	public class GestureRecognitionModelTrainResult: BaseTrainResult
	{
		#region Public properties
		public int? PcaComponentsCount
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.PcaComponentsCount)}: {this.PcaComponentsCount?.ToString() ?? "NULL"}";
		}
		#endregion
	}
	#endregion

	#region TrainErrorKind
	public enum TrainErrorKind
	{
		None,
		AlreadyLoadedModel,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
