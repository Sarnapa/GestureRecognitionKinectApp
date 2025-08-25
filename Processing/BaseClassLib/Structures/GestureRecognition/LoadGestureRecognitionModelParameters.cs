using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition
{
	public class LoadGestureRecognitionModelParameters
	{
		#region Constructors
		public LoadGestureRecognitionModelParameters(string path, BodyTrackingMode trackingMode)
		{
			this.Path = path;
			this.TrackingMode = trackingMode;
		}
		#endregion

		#region Public properties
		public string Path
		{
			get;
			private set;
		}

		public BodyTrackingMode TrackingMode
		{
			get;
			private set;
		}
		#endregion
	}
}
