namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data
{
	public class StartResponseResult
	{
		#region Public properties
		public bool IsSuccess
		{
			get; 
			set;
		}

		public int ColorFrameWidth
		{
			get;
			set;
		}

		public int ColorFrameHeight
		{
			get;
			set;
		}

		public bool KinectSensorIsAvailable
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return "========================\n" +
						 $"{nameof(this.IsSuccess)}: {this.IsSuccess}\n" +
						 $"{nameof(this.ColorFrameWidth)}: {this.ColorFrameWidth}\n" +
						 $"{nameof(this.ColorFrameHeight)}: {this.ColorFrameHeight}\n" +
						 $"{nameof(this.KinectSensorIsAvailable)}: {this.KinectSensorIsAvailable}\n" +
						 "========================";
		}
		#endregion
	}
}
