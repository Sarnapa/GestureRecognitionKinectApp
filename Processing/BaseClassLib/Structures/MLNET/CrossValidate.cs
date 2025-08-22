namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region CrossValidateParameters
	public abstract class BaseCrossValidateParameters<TrainParamsType, EvaluateParamsType>: BaseParameters
		where TrainParamsType : BaseTrainParameters
		where EvaluateParamsType : BaseEvaluateParameters
	{
		#region Public properties
		public int FoldsCount
		{
			get;
			set;
		}

		public TrainParamsType TrainParams
		{
			get;
			set;
		}

		public EvaluateParamsType EvaluateParams
		{
			get;
			set;
		}
		#endregion
	}

	public class GestureRecognitionModelCrossValidateParameters: BaseCrossValidateParameters<GestureRecognitionModelTrainParameters, GestureRecognitionModelEvaluateParameters>
	{}
	#endregion

	#region CrossValidateResult
	public abstract class BaseCrossValidateResult<TrainResultType, EvaluateResultType>: BaseResult
		where TrainResultType : BaseTrainResult
		where EvaluateResultType : BaseEvaluateResult
	{
		#region Public properties
		public CrossValidateErrorKind ErrorKind
		{
			get;
			set;
		} = CrossValidateErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == CrossValidateErrorKind.None;
			}
		}

		public CrossValidationFoldResult<TrainResultType, EvaluateResultType>[] FoldsResults
		{
			get;
			set;
		} = new CrossValidationFoldResult<TrainResultType, EvaluateResultType>[0]; 
		#endregion
	}

	public class GestureRecognitionModelCrossValidateResult: BaseCrossValidateResult<GestureRecognitionModelTrainResult, GestureRecognitionModelEvaluateResult>
	{}

	public class CrossValidationFoldResult<TrainResultType, EvaluateResultType>
	{
		#region Public properties
		public int FoldIdx
		{
			get;
			set;
		}

		public TrainResultType TrainResult
		{
			get;
			set;
		}

		public EvaluateResultType EvaluateResult
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region CrossValidateErrorKind
	public enum CrossValidateErrorKind
	{
		None,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
