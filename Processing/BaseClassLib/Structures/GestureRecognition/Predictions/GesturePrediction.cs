using Microsoft.ML.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.Predictions
{
	public class GesturePrediction
	{
		[ColumnName(GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_COL)]
		public string Label
		{
			get;
			set;
		}
	}
}
