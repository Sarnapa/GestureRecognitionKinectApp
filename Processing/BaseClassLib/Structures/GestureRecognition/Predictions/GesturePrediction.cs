using Microsoft.ML.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.Predictions
{
	public class GesturePrediction
	{
		[ColumnName("PredictedLabel")]
		public string Label
		{
			get;
			set;
		}
	}
}
