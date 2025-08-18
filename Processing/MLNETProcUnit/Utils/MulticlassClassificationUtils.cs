using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

namespace GestureRecognition.Processing.MLNETProcUnit.Utils
{
	public static class MulticlassClassificationUtils
	{
		#region Public methods
		public static MulticlassClassificationEvalResult PrepareResult(MulticlassClassificationMetrics m, Dictionary<int, string> classLabelsDict)
		{
			var result = new MulticlassClassificationEvalResult();

			result.NumberOfClasses = m.ConfusionMatrix?.NumberOfClasses ?? 0;
			result.MicroAccuracy = m.MicroAccuracy;
			result.MacroAccuracy = m.MacroAccuracy;
			result.LogLoss = m.LogLoss;
			result.FormattedConfusionTable = m.ConfusionMatrix?.GetFormattedConfusionTable() ?? string.Empty;

			var perClassEvalResults = new List<PerClassEvalResult>();
			if (m.ConfusionMatrix?.Counts != null && m.ConfusionMatrix.Counts.Count > 0)
			{
				var micro = ComputeMicro(m.ConfusionMatrix.Counts);
				result.MicroPrecision = micro.Precision;
				result.MicroRecall = micro.Recall;
				result.MicroF1 = micro.F1;

				var macro = ComputeMacro(m.ConfusionMatrix.Counts);
				result.MacroPrecision = macro.Precision.Average();
				result.MacroRecall = macro.Recall.Average();
				result.MacroF1 = macro.F1.Average();
				result.PerClassLogLossAvg = m.PerClassLogLoss?.Average() ?? 0d;

				for (int i = 0; i < m.ConfusionMatrix.Counts.Count; i++)
				{
					if (classLabelsDict.TryGetValue(i, out string classLabel))
					{
						var perClassEvalResult = new PerClassEvalResult();

						perClassEvalResult.ClassKey = i;
						perClassEvalResult.ClassLabel = classLabel;
						perClassEvalResult.SamplesRealCount = macro.RealCount[i];
						perClassEvalResult.SamplesPredictedCount = macro.PredictedCount[i];
						perClassEvalResult.Precision = macro.Precision[i];
						perClassEvalResult.Recall = macro.Recall[i];
						perClassEvalResult.F1 = macro.F1[i];
						perClassEvalResult.LogLoss = m.PerClassLogLoss != null && i < m.PerClassLogLoss.Count ? m.PerClassLogLoss[i] : 0d;

						perClassEvalResults.Add(perClassEvalResult);
					}
				}

				result.SamplesTotalCount = Convert.ToInt32(m.ConfusionMatrix.Counts.Sum(r => r.Sum()));
			}
			result.PerClassEvalResults = perClassEvalResults.ToArray();

			return result;
		}
		#endregion

		#region Private methods
		private static (double Precision, double Recall, double F1) ComputeMicro(IReadOnlyList<IReadOnlyList<double>> counts)
		{
			int k = counts.Count;
			double tp = 0, fp = 0, fn = 0;

			for (int i = 0; i < k; i++)
			{
				double tpi = counts[i][i];
				double fni = counts[i].Sum() - tpi;
				double fpi = 0;
				for (int r = 0; r < k; r++)
					if (r != i)
						fpi += counts[r][i];

				tp += tpi;
				fp += fpi;
				fn += fni;
			}

			double prec = (tp + fp) > 0 ? tp / (tp + fp) : 0.0;
			double rec = (tp + fn) > 0 ? tp / (tp + fn) : 0.0;
			double f1 = (prec + rec) > 0 ? 2 * prec * rec / (prec + rec) : 0.0;
			return (prec, rec, f1);
		}

		private static (int[] RealCount, int[] PredictedCount, double[] Precision, double[] Recall, double[] F1) ComputeMacro(IReadOnlyList<IReadOnlyList<double>> counts)
		{
			int k = counts.Count;
			double[] tp = new double[k];
			double[] rowSum = new double[k]; // actual
			double[] colSum = new double[k]; // predicted

			for (int r = 0; r < k; r++)
			{
				rowSum[r] = counts[r].Sum();
				for (int c = 0; c < k; c++)
				{
					colSum[c] += counts[r][c];
					if (r == c) 
						tp[r] += counts[r][c];
				}
			}

			double[] precision = new double[k];
			double[] recall = new double[k];
			double[] f1 = new double[k];
			int[] realCount = new int[k];
			int[] predictedCount = new int[k];

			for (int i = 0; i < k; i++)
			{
				realCount[i] = Convert.ToInt32(rowSum[i]);
				predictedCount[i] = Convert.ToInt32(colSum[i]);
				precision[i] = colSum[i] > 0 ? tp[i] / colSum[i] : 0.0;
				recall[i] = rowSum[i] > 0 ? tp[i] / rowSum[i] : 0.0;
				f1[i] = (precision[i] + recall[i]) > 0 ? 2 * precision[i] * recall[i] / (precision[i] + recall[i]) : 0.0;
			}

			return (realCount, predictedCount, precision, recall, f1);
		}
		#endregion
	}
}
