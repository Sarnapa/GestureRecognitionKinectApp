namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	public class ConnectAsyncResult
	{
		#region Public properties
		public ConnectAsyncResultStatus Status 
		{
			get; 
			set;
		}

		public string ErrorMessage
		{
			get;
			set;
		} = string.Empty;

		public bool IsSuccess
		{
			get
			{
				return this.Status == ConnectAsyncResultStatus.OK;
			}
		}
		#endregion
	}

	public enum ConnectAsyncResultStatus
	{
		OK,
		OperationCanceled,
		Error,
	}
}
