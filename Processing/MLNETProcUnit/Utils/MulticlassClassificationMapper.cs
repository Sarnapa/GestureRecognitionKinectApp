using Microsoft.ML.AutoML;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

namespace GestureRecognition.Processing.MLNETProcUnit.Utils
{
	public static class MulticlassClassificationMapper
	{
		#region Public methods
		public static MulticlassClassificationMetric Map(this MulticlassClassificationMetricKind metric)
		{
			switch (metric)
			{
				case MulticlassClassificationMetricKind.MicroAccuracy:
					return MulticlassClassificationMetric.MicroAccuracy;
				case MulticlassClassificationMetricKind.MacroAccuracy:
					return MulticlassClassificationMetric.MacroAccuracy;
				case MulticlassClassificationMetricKind.LogLoss:
					return MulticlassClassificationMetric.LogLoss;
				case MulticlassClassificationMetricKind.LogLossReduction:
					return MulticlassClassificationMetric.LogLossReduction;
				default:
					break;
			}

			return MulticlassClassificationMetric.MicroAccuracy;
		}

		public static MulticlassClassificationMetricKind Map(this MulticlassClassificationMetric metric)
		{
			switch (metric)
			{
				case MulticlassClassificationMetric.MicroAccuracy:
					return MulticlassClassificationMetricKind.MicroAccuracy;
				case MulticlassClassificationMetric.MacroAccuracy:
					return MulticlassClassificationMetricKind.MacroAccuracy;
				case MulticlassClassificationMetric.LogLoss:
					return MulticlassClassificationMetricKind.LogLoss;
				case MulticlassClassificationMetric.LogLossReduction:
					return MulticlassClassificationMetricKind.LogLossReduction;
				default:
					break;
			}
			return MulticlassClassificationMetricKind.MicroAccuracy;
		}
		#endregion
	}
}
