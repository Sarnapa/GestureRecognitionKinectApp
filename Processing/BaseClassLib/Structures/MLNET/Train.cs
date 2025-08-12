using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region TrainParameters
	public abstract class BaseTrainParameters: BaseParameters
	{
	}

	public class GestureRecognitionModelTrainParameters: BaseTrainParameters
	{
		public string[] ExcludedFeatures
		{
			get;
			set;
		} = new string[0];

		public bool UsePca
		{
			get;
			set;
		}

		public int PcaRank
		{
			get;
			set;
		}

		public BaseClassificationAlgorithmParams AlgorithmParams
		{
			get;
			set;
		}
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
