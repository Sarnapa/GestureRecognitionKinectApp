namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	public abstract class BaseResult
	{
		#region Public properties
		public string ErrorMessage
		{
			get;
			set;
		}

		public abstract bool IsSuccess
		{
			get;
		}
		#endregion
	}
}
