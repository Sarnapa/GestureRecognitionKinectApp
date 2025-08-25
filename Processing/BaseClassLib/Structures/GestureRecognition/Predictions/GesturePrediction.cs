using Microsoft.ML.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.Predictions
{
	public class GesturePrediction
	{
		[ColumnName(GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_KEY_COL)]
		public uint LabelKey
		{
			get;
			set;
		}

		[ColumnName(GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_COL)]
		public string Label
		{
			get;
			set;
		}

		[ColumnName(GestureRecognitionModelColumnsConsts.SCORE_COL)]
		public float[] Scores
		{
			get; set;
		}
	}
}
