using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region EvaluateParameters
	public abstract class BaseEvaluateParameters: BaseParameters
	{
	}

	public class GestureRecognitionModelEvaluateParameters: BaseEvaluateParameters
	{
		#region Public methods
		public override string ToString()
		{
			return string.Empty;
		}
		#endregion
	}
	#endregion

	#region EvaluateResult
	public abstract class BaseEvaluateResult: BaseResult
	{
		#region Public properties
		public EvaluateErrorKind ErrorKind
		{
			get;
			set;
		} = EvaluateErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == EvaluateErrorKind.None;
			}
		}
		#endregion
	}

	public class GestureRecognitionModelEvaluateResult: BaseEvaluateResult
	{
		#region Public properties
		public MulticlassClassificationEvalResult MulticlassClassificationEvalResult
		{
			get;
			set;
		} = new MulticlassClassificationEvalResult();
		#endregion
	}
	#endregion

	#region EvaluateErrorKind
	public enum EvaluateErrorKind
	{
		None,
		ModelNotLoaded,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
