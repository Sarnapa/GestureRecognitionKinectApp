namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data
{
	public class KinectIsAvailableChangedData
	{
		#region Public properties
		public bool IsAvailable
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.IsAvailable)}: {this.IsAvailable}";
		}
		#endregion
	}
}
