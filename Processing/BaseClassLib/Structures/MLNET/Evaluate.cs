namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region EvaluateParameters
	public abstract class BaseEvaluateParameters: BaseParameters
	{
		#region Public properties
		public string EvaluationResultPresentationTitle
		{
			get;
			set;
		}
		#endregion
	}

	public class GestureRecognitionModelEvaluateParameters: BaseEvaluateParameters
	{
		#region Public methods
		public override string ToString()
		{
			return $"Evaluation result presentation title: {this.EvaluationResultPresentationTitle}";
		}
		#endregion
	}
	#endregion

	#region EvaluateResult
	public class EvaluateResult: BaseResult
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
