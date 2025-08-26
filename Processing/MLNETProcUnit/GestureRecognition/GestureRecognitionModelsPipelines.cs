using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.SearchSpace;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Transforms;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace;
using GestureRecognition.Processing.MLNETProcUnit.Utils;

namespace GestureRecognition.Processing.MLNETProcUnit.GestureRecognition
{
	public static class GestureRecognitionModelsPipelines
	{
		#region Prepare data pipeline
		public static IEstimator<ITransformer> GetPrepareDataPipeline<T>(MLContext context, int? seed, AllHyperparams hyperparams, string[] excludedFeatures)
			where T : GestureDataView
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (hyperparams == null)
				throw new ArgumentNullException(nameof(hyperparams));

			string[] gestureFeatureColumns = DataViewsUtils.GetGestureFeatureColumns(typeof(T));

			IEstimator<ITransformer> pipeline = context.Transforms.Conversion.MapValueToKey(
													inputColumnName: GestureRecognitionModelColumnsConsts.LABEL_COL, outputColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL);

			string[] gestureFeatureColumnsToUse;
			if (excludedFeatures != null && excludedFeatures.Length > 0)
			{
				gestureFeatureColumnsToUse = gestureFeatureColumns.Where(c => !excludedFeatures.Contains(c, StringComparer.OrdinalIgnoreCase)).ToArray();
				pipeline = pipeline.Append(context.Transforms.DropColumns(excludedFeatures));
			}
			else
			{
				gestureFeatureColumnsToUse = gestureFeatureColumns;
			}

			pipeline = pipeline.Append(context.Transforms.Concatenate(GestureRecognitionModelColumnsConsts.FEATURES_COL, gestureFeatureColumnsToUse));

			pipeline = pipeline
					.Append(context.Transforms.ReplaceMissingValues(GestureRecognitionModelColumnsConsts.FEATURES_COL,
									replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean,
									imputeBySlot: true))
					.Append(context.Transforms.ReplaceMissingValues(GestureRecognitionModelColumnsConsts.FEATURES_COL,
									replacementMode: MissingValueReplacingEstimator.ReplacementMode.DefaultValue,
									imputeBySlot: true));

			pipeline = pipeline.Append(context.Transforms.NormalizeMeanVariance(GestureRecognitionModelColumnsConsts.FEATURES_COL));

			if (hyperparams.PcaRank > 0)
			{
				// For now, we don't need the original column, so we overwrite it. If the need arises, unfortunately, it will be a problem for the entire hyperparameter tuning process.
				pipeline = pipeline.Append(
						context.Transforms.ProjectToPrincipalComponents(
								inputColumnName: GestureRecognitionModelColumnsConsts.FEATURES_COL,
								outputColumnName: GestureRecognitionModelColumnsConsts.FEATURES_COL,
								rank: hyperparams.PcaRank,
								seed: seed ?? 42
						)
				);
			}

			pipeline = pipeline.AppendCacheCheckpoint(context);

			return pipeline;
		}
		#endregion

		#region FastForest pipeline
		public static IEstimator<ITransformer> GetFastForestPipeline(MLContext context, int? seed, AllHyperparams hyperparams)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (hyperparams == null)
				throw new ArgumentNullException(nameof(hyperparams));

			var ff = context.BinaryClassification.Trainers.FastForest(new FastForestBinaryTrainer.Options
			{
				FeatureColumnName = GestureRecognitionModelColumnsConsts.FEATURES_COL,
				LabelColumnName = GestureRecognitionModelColumnsConsts.LABEL_KEY_COL,
				NumberOfTrees = hyperparams.TreesCount,
				NumberOfLeaves = hyperparams.LeavesCount,
				MinimumExampleCountPerLeaf = hyperparams.MinimumExampleCountPerLeaf,
				FeatureFraction = hyperparams.FeatureFraction,
				BaggingExampleFraction = hyperparams.BaggingExampleFraction,
				Seed = seed ?? 42,
			});

			IEstimator<ITransformer> pipeline = context.MulticlassClassification.Trainers.OneVersusAll(
				binaryEstimator: ff,
				labelColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL
			);

			pipeline = pipeline
				.Append(context.Transforms.CopyColumns(
					inputColumnName: GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_COL,
					outputColumnName: GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_KEY_COL))
				.Append(context.Transforms.Conversion.MapKeyToValue(
					inputColumnName: GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_KEY_COL,
					outputColumnName: GestureRecognitionModelColumnsConsts.PREDICTED_LABEL_COL));

			return pipeline;
		}
		#endregion

		#region Model pipeline
		public static IEstimator<ITransformer> GetModelPipeline<T>(MLContext context, int? seed, AllHyperparams hyperparams, string[] excludedFeatures)
			where T : GestureDataView
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (hyperparams == null)
				throw new ArgumentNullException(nameof(hyperparams));

			var prepareDataPipeline = GetPrepareDataPipeline<T>(context, seed, hyperparams, excludedFeatures);
			var fastForestPipeline = GetFastForestPipeline(context, seed, hyperparams);
			var pipeline = prepareDataPipeline.Append(fastForestPipeline);
			return pipeline;
		}

		public static SweepableEstimator GetModelSweepableEstimator<T>(MLContext context, int? seed, int choicesCount, AllHyperparamsSearchSpaceValues searchSpaceValues, string[] excludedFeatures)
			where T : GestureDataView
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (searchSpaceValues == null)
				throw new ArgumentNullException(nameof(searchSpaceValues));

			var pcaRankSearchValues = searchSpaceValues.PcaRankValues;
			var treesCountSearchSpace = searchSpaceValues.TreesCountValues;
			var leavesCountSearchSpace = searchSpaceValues.LeavesCountValues;
			var minExampleCountPerLeafValuesSearchSpace = searchSpaceValues.MinimumExampleCountPerLeafValues;
			var featureFractionSearchSpace = searchSpaceValues.FeatureFractionValues;
			var baggingExampleFractionSearchSpace = searchSpaceValues.BaggingExampleFractionValues;

			var searchSpace = new SearchSpace<AllHyperparams>
			{
				{ nameof(AllHyperparams.PcaRank), GridChoiceBuilder.IntChoice(min: pcaRankSearchValues.Min, max: pcaRankSearchValues.Max, points: choicesCount, defaultVal: pcaRankSearchValues.Default) },
				{ nameof(AllHyperparams.TreesCount), GridChoiceBuilder.IntChoice(min: treesCountSearchSpace.Min, max: treesCountSearchSpace.Max, points: choicesCount, defaultVal: treesCountSearchSpace.Default) },
				{ nameof(AllHyperparams.LeavesCount), GridChoiceBuilder.IntChoice(min: leavesCountSearchSpace.Min, max: leavesCountSearchSpace.Max, points: choicesCount, defaultVal: leavesCountSearchSpace.Default) },
				{ nameof(AllHyperparams.MinimumExampleCountPerLeaf), GridChoiceBuilder.IntChoice(min: minExampleCountPerLeafValuesSearchSpace.Min, max: minExampleCountPerLeafValuesSearchSpace.Max,
					points: choicesCount, defaultVal: minExampleCountPerLeafValuesSearchSpace.Default) },
				{ nameof(AllHyperparams.FeatureFraction), GridChoiceBuilder.DoubleChoice(min: featureFractionSearchSpace.Min, max: featureFractionSearchSpace.Max,
					points: choicesCount, defaultVal: featureFractionSearchSpace.Default) },
				{ nameof(AllHyperparams.BaggingExampleFraction), GridChoiceBuilder.DoubleChoice(min: baggingExampleFractionSearchSpace.Min, max: baggingExampleFractionSearchSpace.Max,
					points: choicesCount, defaultVal: baggingExampleFractionSearchSpace.Default) }
			};

			// HyperparamsUtils.NormalizeFixedNumerics(searchSpace);
			HyperparamsUtils.DumpSearchSpaceInfo(searchSpace);

			IEstimator<ITransformer> Factory(MLContext ctx, AllHyperparams hparams) { return GetModelPipeline<T>(ctx, seed, hparams, excludedFeatures); }

			return context.Auto().CreateSweepableEstimator(Factory, searchSpace);
		}
		#endregion
	}
}
