namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data
{
	public class StopResponseResult
	{
		#region Public properties
		public bool IsSuccess
		{
			get; 
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.IsSuccess)}: {this.IsSuccess}";
		}
		#endregion
	}
}
