using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.ML.AutoML;
using Microsoft.ML.SearchSpace;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;

public sealed class ConsoleAutoMLMonitor: IMonitor
{
	#region Private fields
	private readonly string[] allHyperparamsKeys = [
		nameof(PrepareDataHyperparams.PcaRank),
		nameof(FastForestHyperparams.TreesCount),
		nameof(FastForestHyperparams.LeavesCount),
		nameof(FastForestHyperparams.MinimumExampleCountPerLeaf),
		nameof(FastForestHyperparams.FeatureFraction),
		nameof(FastForestHyperparams.BaggingExampleFraction)
		];
	private readonly MulticlassClassificationMetricKind mainMetric;
	private readonly int? targetModelsCount;
	private int completed, failed;
	private TrialResult best;
	#endregion

	#region Public properties
	public int AllAttemptsToTrainModelCount
	{
		get
		{
			return this.completed + failed;
		}
	}

	private string TargetOrUnknown
	{
		get
		{
			return this.targetModelsCount?.ToString() ?? "?";
		}
	}
	#endregion

	#region Constructors
	public ConsoleAutoMLMonitor(MulticlassClassificationMetricKind mainMetric, int? targetModels = null)
	{
		this.mainMetric = mainMetric;
		this.targetModelsCount = targetModels;
	}
	#endregion

	#region IMonitor implementation
	public void ReportRunningTrial(TrialSettings settings)
	{
		WriteLine("RUNNING", $"Trial=[{settings.TrialId}]\n");
	}

	public void ReportCompletedTrial(TrialResult result)
	{
		Interlocked.Increment(ref this.completed);

		var trialParams = TryGetParams(result.TrialSettings.Parameter, this.allHyperparamsKeys);
		WriteLine("DONE", $"Trial=[{result.TrialSettings.TrialId}] Metric=[{this.mainMetric}] MetricValue=[{result.Metric:G4}] Loss=[{result.Loss:G4}] " +
			$"Duration=[{result.DurationInMilliseconds} ms] [#{this.AllAttemptsToTrainModelCount}/{this.TargetOrUnknown}]");
		WriteLine("DONE", $"Trial=[{result.TrialSettings.TrialId}] Hyperparams=[{ParamsToString(trialParams)}]\n");

		if (this.best == null || result.Metric > this.best.Metric) 
			this.best = result;
	}

	public void ReportBestTrial(TrialResult result)
	{
		this.best = result;

		var trialParams = TryGetParams(result.TrialSettings.Parameter, this.allHyperparamsKeys);
		WriteLine("BEST", $"Trial=[{result.TrialSettings.TrialId}] Metric=[{this.mainMetric}] MetricValue=[{result.Metric:G4}] Loss=[{result.Loss:G4}]");
		WriteLine("BEST", $"Trial=[{result.TrialSettings.TrialId}] Hyperparams=[{ParamsToString(trialParams)}]\n");
	}

	public void ReportFailTrial(TrialSettings settings, Exception ex)
	{
		Interlocked.Increment(ref this.failed);

		var trialParams = TryGetParams(settings.Parameter, this.allHyperparamsKeys);
		WriteLine("FAIL", $"Trial=[{settings.TrialId}] Ex=[{ex.GetType().Name}] [{this.AllAttemptsToTrainModelCount}/{this.TargetOrUnknown}]");
		WriteLine("FAIL", $"Trial=[{settings.TrialId}] Hyperparams=[{ParamsToString(trialParams)}]\n");
	}
	#endregion

	#region Private methods
	public static Dictionary<string, Parameter> TryGetParams(
		Parameter root,
		IEnumerable<string> keys)
	{
		var pending = new HashSet<string>(keys, StringComparer.OrdinalIgnoreCase);
		var found = new Dictionary<string, Parameter>(StringComparer.OrdinalIgnoreCase);

		if (pending.Count == 0 || root is null)
			return found;

		var stack = new Stack<Parameter>();
		stack.Push(root);

		while (stack.Count > 0 && found.Count < pending.Count)
		{
			var node = stack.Pop();

			if (node.Keys != null)
			{
				foreach (var kv in node)
				{
					string key = kv.Key;
					var child = kv.Value;

					if (pending.Contains(key) && !found.ContainsKey(key))
					{
						found[key] = child;
						if (found.Count == pending.Count)
							return found;
						continue;
					}

					stack.Push(child);
				}
			}
		}

		return found;
	}

	public static string ParamsToString(Dictionary<string, Parameter> parameters)
	{
		if (parameters == null || parameters.Count == 0)
			return string.Empty;

		var sb = new StringBuilder();
		foreach (var kv in parameters)
		{
			if (sb.Length > 0)
				sb.Append(", ");
			sb.Append(kv.Key);
			sb.Append('=');
			if (kv.Key == nameof(PrepareDataHyperparams.PcaRank) && kv.Value.ParameterType == ParameterType.Integer)
			{
				int pcaRank = kv.Value.AsType<int>();
				sb.Append(pcaRank);
			}
			else
				sb.Append(kv.Value.ToString());
		}

		return sb.ToString();
	}

	private static void WriteLine(string reportKind, string message)
	{
		Console.WriteLine($"[{reportKind}][{DateTime.Now}] {message}");
	}
	#endregion
}
