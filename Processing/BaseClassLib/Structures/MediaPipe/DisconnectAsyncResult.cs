namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	public class DisconnectAsyncResult
	{
		#region Public properties
		public DisconnectAsyncResultStatus Status
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
				return this.Status == DisconnectAsyncResultStatus.OK;
			}
		}
		#endregion
	}

	public enum DisconnectAsyncResultStatus
	{
		OK,
		OperationCanceled,
		Error,
	}
}
