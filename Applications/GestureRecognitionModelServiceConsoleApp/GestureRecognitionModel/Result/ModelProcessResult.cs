using CsvHelper.Configuration.Attributes;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Result
{
	#region ModelProcessResult
	public class ModelProcessResult
	{
		#region Public properties
		public required string ModelFilePath
		{
			get;
			set;
		}

		public int Seed
		{
			get;
			set;
		}

		public string? DataFilePath
		{
			get;
			set;
		}

		public string? TrainDataFilePath
		{
			get;
			set;
		}

		public string? TestDataFilePath
		{
			get;
			set;
		}

		public double? TestFraction
		{
			get;
			set;
		}

		public string[]? ExcludedFeatures
		{
			get;
			set;
		} = [];

		public bool? UsePca
		{
			get;
			set;
		}

		public int? PcaRank
		{
			get;
			set;
		}

		public int? PcaComponentsCount
		{
			get;
			set;
		}

		public string? AlgorithmKind
		{
			get;
			set;
		}

		public int? TreesCount
		{
			get;
			set;
		}

		public int? LeavesCount
		{
			get;
			set;
		}

		public int? MinimumExampleCountPerLeaf
		{
			get;
			set;
		}

		public double? FeatureFraction
		{
			get;
			set;
		}

		public double? BaggingExampleFraction
		{
			get;
			set;
		}

		public int NumberOfClasses
		{
			get;
			set;
		}

		public double MicroAccuracy
		{
			get;
			set;
		}

		public double MicroPrecision
		{
			get;
			set;
		}

		public double MicroRecall
		{
			get;
			set;
		}

		public double MicroF1
		{
			get;
			set;
		}

		public double LogLoss
		{
			get;
			set;
		}

		public double MacroAccuracy
		{
			get;
			set;
		}

		public double MacroPrecision
		{
			get;
			set;
		}

		public double MacroRecall
		{
			get;
			set;
		}

		public double MacroF1
		{
			get;
			set;
		}

		public double PerClassLogLossAvg
		{
			get;
			set;
		}

		public int SamplesTotalCount
		{
			get;
			set;
		}

		[Ignore]
		public PerClassEvalResult[] PerClassEvalResults
		{
			get;
			set;
		} = [];

		public required string PerClassEvalResultsFilePath
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region ModelProcessResultMapper
	public static class ModelProcessResultMapper
	{
		public static ModelProcessResult Map(string modelFilePath, int seed,
			GestureRecognitionModelSetDataParameters setDataParameters, string? dataFilePath, string? trainDataFilePath, string? testDataFilePath,
			GestureRecognitionModelTrainParameters? trainParams, GestureRecognitionModelTrainResult? trainResult,
			GestureRecognitionModelEvaluateResult evaluateResult, string perClassEvalResultsFilePath)
		{
			var ffParams = trainParams?.AlgorithmParams as FastForestParams;

			return new ModelProcessResult()
			{
				ModelFilePath = modelFilePath,
				Seed = seed,
				DataFilePath = dataFilePath,
				TrainDataFilePath = trainDataFilePath,
				TestDataFilePath = testDataFilePath,
				TestFraction = setDataParameters.TestFraction,
				ExcludedFeatures = trainParams?.ExcludedFeatures,
				UsePca = trainParams?.UsePca,
				PcaRank = trainParams?.PcaRank,
				PcaComponentsCount = trainResult?.PcaComponentsCount,
				AlgorithmKind = ffParams?.AlgorithmKind.ToString(),
				TreesCount = ffParams?.TreesCount,
				LeavesCount = ffParams?.LeavesCount,
				MinimumExampleCountPerLeaf = ffParams?.MinimumExampleCountPerLeaf,
				FeatureFraction = ffParams?.FeatureFraction,
				BaggingExampleFraction = ffParams?.BaggingExampleFraction,
				NumberOfClasses = evaluateResult.MulticlassClassificationEvalResult.NumberOfClasses,
				MicroAccuracy = evaluateResult.MulticlassClassificationEvalResult.MicroAccuracy,
				MicroPrecision = evaluateResult.MulticlassClassificationEvalResult.MicroPrecision,
				MicroRecall = evaluateResult.MulticlassClassificationEvalResult.MicroRecall,
				MicroF1 = evaluateResult.MulticlassClassificationEvalResult.MicroF1,
				LogLoss = evaluateResult.MulticlassClassificationEvalResult.LogLoss,
				MacroAccuracy = evaluateResult.MulticlassClassificationEvalResult.MacroAccuracy,
				MacroPrecision = evaluateResult.MulticlassClassificationEvalResult.MacroPrecision,
				MacroRecall = evaluateResult.MulticlassClassificationEvalResult.MacroRecall,
				MacroF1 = evaluateResult.MulticlassClassificationEvalResult.MacroF1,
				PerClassLogLossAvg = evaluateResult.MulticlassClassificationEvalResult.PerClassLogLossAvg,
				SamplesTotalCount = evaluateResult.MulticlassClassificationEvalResult.SamplesTotalCount,
				PerClassEvalResults = evaluateResult.MulticlassClassificationEvalResult.PerClassEvalResults,
				PerClassEvalResultsFilePath = perClassEvalResultsFilePath
			};
		}
	}
	#endregion
}
