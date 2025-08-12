using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.ML.Data;

namespace GestureRecognition.Processing.MLNETProcUnit.Utils
{
	public static class MulticlassMetricsConsolePresenter
	{
		#region Public methods
		public static void Print(MulticlassClassificationMetrics m, string title)
		{
			Console.WriteLine($"===== {title} =====");

			// 1) Basic metrics
			Console.WriteLine($"Number of classes: {m.ConfusionMatrix?.NumberOfClasses ?? 0}");
			Console.WriteLine($"Micro-accuracy   : {m.MicroAccuracy,6:F4}");
			Console.WriteLine($"Macro-accuracy   : {m.MacroAccuracy,6:F4}");
			Console.WriteLine($"Log-loss         : {m.LogLoss,6:F4}");

			// 2) Confusion matrix
			if (m.ConfusionMatrix != null)
				Console.WriteLine(m.ConfusionMatrix.GetFormattedConfusionTable());
			else
				Console.WriteLine("Got empty confusion matrix\n");

			// 3) Per-class log-loss
			if (m.PerClassLogLoss != null && m.PerClassLogLoss.Any())
			{
				Console.WriteLine($"Per-class Log - loss:");
				for (int i = 0; i < m.PerClassLogLoss.Count; i++)
				{
					Console.WriteLine($"	Class idx: {i}, value: {m.PerClassLogLoss[i],6:F4}");
				}
				Console.WriteLine($"Per-class Log - loss (avg): {m.PerClassLogLoss.Average(),6:F4}\n");
			}
			else
				Console.WriteLine("No information concerning Per-class Log - loss.\n");

			if (m.ConfusionMatrix?.Counts != null && m.ConfusionMatrix.Counts.Count > 0)
			{
				// 4) Micro-averaged Precision / Recall / F1
				var micro = ComputeMicro(m.ConfusionMatrix.Counts);
				Console.WriteLine($"Micro Precision: {micro.Precision,6:F4}");
				Console.WriteLine($"Micro Recall   : {micro.Recall,6:F4}");
				Console.WriteLine($"Micro F1       : {micro.F1,6:F4}\n");

				// 5) Macro-averaged Precision / Recall / F1
				var macro = ComputeMacro(m.ConfusionMatrix.Counts);
				Console.WriteLine($"Macro Precision: {macro.Precision.Average(),6:F4}");
				Console.WriteLine($"Macro Recall   : {macro.Recall.Average(),6:F4}");
				Console.WriteLine($"Macro F1       : {macro.F1.Average(),6:F4}\n");

				// 6) Precision / Recall / F1 per class (calculated directly from confusion matrix)
				Console.WriteLine("Per-class Real count examples / Predicted count examples / Precision / Recall / F1:");
				Console.WriteLine($"|{"Class idx"}|{"Real",-6}|{"Pred",-6}|{"Prec",-6}|{"Rec",-6}|{"F1",-6}|");
				for (int i = 0; i < m.ConfusionMatrix.Counts.Count; i++)
				{
					Console.WriteLine($"|{i,-9}|{macro.RealCount[i],-6}|{macro.PredictedCount[i],-6}|{macro.Precision[i],-6:F4}|{macro.Recall[i],-6:F4}|{macro.F1[i],-6:F4}|");
				}
				Console.WriteLine("");

				// 7) Total samples
				double total = Convert.ToInt32(m.ConfusionMatrix.Counts.Sum(r => r.Sum()));
				Console.WriteLine($"Total samples: {total}\n");
			}

			Console.WriteLine("");
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
