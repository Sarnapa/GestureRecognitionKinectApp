using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.SearchSpace;
using Microsoft.ML.SearchSpace.Option;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Transforms;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace;

namespace GestureRecognition.Processing.MLNETProcUnit.GestureRecognition
{
	public static class GestureRecognitionModelsPipelines
	{
		#region Prepare data pipeline
		public static IEstimator<ITransformer> GetPrepareDataPipeline<T>(MLContext context, int? seed, PrepareDataHyperparams hyperparams, string[] excludedFeatures)
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

			if (hyperparams.Pca != null && hyperparams.Pca.UsePca)
			{
				// For now, we don't need the original column, so we overwrite it. If the need arises, unfortunately, it will be a problem for the entire hyperparameter tuning process.
				pipeline = pipeline.Append(
						context.Transforms.ProjectToPrincipalComponents(
								inputColumnName: null,
								outputColumnName: GestureRecognitionModelColumnsConsts.FEATURES_COL,
								rank: hyperparams.Pca.PcaRank,
								seed: seed
						)
				);
			}

			pipeline.AppendCacheCheckpoint(context);

			return pipeline;
		}

		public static SweepableEstimator GetPrepareDataSweepableEstimator<T>(MLContext context, int? seed, PrepareDataSearchSpaceValues searchSpaceValues, string[] excludedFeatures)
			where T : GestureDataView
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (searchSpaceValues == null)
				searchSpaceValues = new PrepareDataSearchSpaceValues();

			var pcaSearchSpace = searchSpaceValues.PcaValues;

			var searchSpace = new SearchSpace<PrepareDataHyperparams>
			{
				{ nameof(PrepareDataHyperparams.Pca), new ChoiceOption(pcaSearchSpace.Values?.ToArray() ?? [], pcaSearchSpace.Default) },
			};

			IEstimator<ITransformer> Factory(MLContext ctx, PrepareDataHyperparams hparams) { return GetPrepareDataPipeline<T>(ctx, seed, hparams, excludedFeatures); }

			return context.Auto().CreateSweepableEstimator(Factory, searchSpace);
		}
		#endregion

		#region FastForest pipeline
		public static IEstimator<ITransformer> GetFastForestPipeline(MLContext context, int? seed, FastForestHyperparams hyperparams)
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
				NumberOfThreads = Environment.ProcessorCount,
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

		public static SweepableEstimator GetFastForestSweepableEstimator(MLContext context, int? seed, FastForestSearchSpaceValues searchSpaceValues)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (searchSpaceValues == null)
				searchSpaceValues = new FastForestSearchSpaceValues();

			var treesCountSearchSpace = searchSpaceValues.TreesCountValues;
			var leavesCountSearchSpace = searchSpaceValues.LeavesCountValues;
			var minExampleCountPerLeafValuesSearchSpace = searchSpaceValues.MinimumExampleCountPerLeafValues;
			var featureFractionSearchSpace = searchSpaceValues.FeatureFractionValues;
			var baggingExampleFractionSearchSpace = searchSpaceValues.BaggingExampleFractionValues;

			var searchSpace = new SearchSpace<FastForestHyperparams>
			{
				{ nameof(FastForestHyperparams.TreesCount), new UniformIntOption(min: treesCountSearchSpace.Min, max: treesCountSearchSpace.Max, defaultValue: treesCountSearchSpace.Default) },
				{ nameof(FastForestHyperparams.LeavesCount), new UniformIntOption(min: leavesCountSearchSpace.Min, max: leavesCountSearchSpace.Max, defaultValue: leavesCountSearchSpace.Default) },
				{ nameof(FastForestHyperparams.MinimumExampleCountPerLeaf), new UniformIntOption(min: minExampleCountPerLeafValuesSearchSpace.Min, max: minExampleCountPerLeafValuesSearchSpace.Max,
					defaultValue: minExampleCountPerLeafValuesSearchSpace.Default) },
				{ nameof(FastForestHyperparams.FeatureFraction), new UniformDoubleOption(min: featureFractionSearchSpace.Min, max: featureFractionSearchSpace.Max, 
					defaultValue: featureFractionSearchSpace.Default) },
				{ nameof(FastForestHyperparams.BaggingExampleFraction), new UniformDoubleOption(min: baggingExampleFractionSearchSpace.Min, max: baggingExampleFractionSearchSpace.Max,
					defaultValue: baggingExampleFractionSearchSpace.Default) }
			};

			IEstimator<ITransformer> Factory(MLContext ctx, FastForestHyperparams hparams) { return GetFastForestPipeline(ctx, seed, hparams); }

			return context.Auto().CreateSweepableEstimator(Factory, searchSpace);
		}
		#endregion
	}
}
