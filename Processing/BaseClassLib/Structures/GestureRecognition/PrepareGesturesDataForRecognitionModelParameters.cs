using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition
{
	public class PrepareGesturesDataForRecognitionModelParameters
	{
		public BodyTrackingMode TrackingMode
		{
			get;
			set;
		}

		public string[] GestureDataFilesPaths
		{
			get;
			set;
		}

		public string GesturesDataOutputFilePath
		{
			get; set;
		}
	}
}
