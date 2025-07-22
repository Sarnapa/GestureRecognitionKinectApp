using Microsoft.ML.Data;

namespace GestureRecognition.Processing.MLNETProcUnit.BodyTrackingModels.PoseDetection
{
	public class PoseDetectionOutput
	{
		[ColumnName(PoseDetectionModelInfo.OUTPUT_COORDINATES_COLUMN_NAME)]
		public float[] Coordinates
		{
			get; set;
		}

		[ColumnName(PoseDetectionModelInfo.OUTPUT_CONFIDENCE_SCORES_COLUMN_NAME)]
		public float[] ConfidenceScores
		{
			get; set;
		}
	}
}
