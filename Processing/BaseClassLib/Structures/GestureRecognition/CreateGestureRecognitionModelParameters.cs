using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition
{
	public class CreateGestureRecognitionModelParameters
	{
		public KinectGestureDataView[] TrainData
		{
			get;
			set;
		}
	}
}
