namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureDetection
{
	public class GestureRecognitionResult
	{
		#region Constructors
		public GestureRecognitionResult(bool success, string text)
		{
			this.Success = success;
			this.Text = text ?? string.Empty;
		}
		#endregion

		#region Public properties
		public bool Success
		{
			get;
			private set;
		}

		public string Text
		{
			get;
			private set;
		}
		#endregion
	}
}
