using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

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

		public bool UsePca
		{
			get;
			set;
		} = false;

		public int PcaRank
		{
			get;
			set;
		} = 30;

		public BaseClassificationAlgorithmParams AlgorithmParams
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			string exclucedFeaturesText = this.ExcludedFeatures == null ? "[]" :
				$"[{string.Join(", ", this.ExcludedFeatures)}]";

			return $"Excluded features: {exclucedFeaturesText}\n" +
				$"Use PCA: {this.UsePca}\n" +
				$"PCA rank: {this.PcaRank}\n" +
				$"Algorithm params: \n" +
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
		UnexpectedError,
	}
	#endregion
}
