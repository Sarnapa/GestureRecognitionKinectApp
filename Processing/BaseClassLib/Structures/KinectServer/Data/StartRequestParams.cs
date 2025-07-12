using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data
{
	public class StartRequestParams
	{
		#region Public properites
		public FrameSourceTypes FrameSourceTypes
		{
			get;
			set;
		}

		public ColorImageFormat ColorImageFormat
		{
			get;
			set;
		}

		public bool IsOneBodyTrackingEnabled
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.FrameSourceTypes)}: {this.FrameSourceTypes}\n" +
						 $"{nameof(this.ColorImageFormat)}: {this.ColorImageFormat}\n" +
						 $"{nameof(this.IsOneBodyTrackingEnabled)}: {this.IsOneBodyTrackingEnabled}";
		}
		#endregion
	}
}
