namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data
{
	public class StopRequestParams
	{
		#region Public properites
		public bool StopServerRunning
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return "========================\n" +
						 $"{nameof(this.StopServerRunning)}: {this.StopServerRunning}\n" +
						 "========================";
		}
		#endregion
	}
}
