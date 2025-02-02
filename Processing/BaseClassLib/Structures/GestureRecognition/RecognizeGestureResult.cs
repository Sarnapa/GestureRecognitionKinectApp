namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition
{
	public class RecognizeGestureResult
	{
		#region Constructors
		public RecognizeGestureResult(bool success, string label)
		{
			this.Success = success;
			this.Label = label ?? string.Empty;
		}
		#endregion

		#region Public properties
		public bool Success
		{
			get;
			private set;
		}

		public string Label
		{
			get;
			private set;
		}
		#endregion
	}
}
