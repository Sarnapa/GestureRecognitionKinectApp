using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Transforms;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;
using GestureRecognition.Processing.BaseClassLib.Utils;

namespace GestureRecognition.Processing.MLNETProcUnit.GestureRecognition
{
	public static class GestureRecognitionModelsPipelines
	{
		#region Prepare data pipeline
		public static (IEstimator<ITransformer> pipeline, string featuresCol) GetPrepareDataPipeline<T>(MLContext context, int? seed, GestureRecognitionModelTrainParameters parameters)
			where T : GestureDataView
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			string[] gestureFeatureColumns = DataViewsUtils.GetGestureFeatureColumns(typeof(T));

			IEstimator<ITransformer> pipeline = context.Transforms.Conversion.MapValueToKey(
													inputColumnName: GestureRecognitionModelColumnsConsts.LABEL_COL, outputColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL);

			string[] gestureFeatureColumnsToUse;
			if (parameters.ExcludedFeatures != null && parameters.ExcludedFeatures.Length > 0)
			{
				gestureFeatureColumnsToUse = gestureFeatureColumns.Where(c => !parameters.ExcludedFeatures.Contains(c, StringComparer.OrdinalIgnoreCase)).ToArray();
				pipeline = pipeline.Append(context.Transforms.DropColumns(parameters.ExcludedFeatures));
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

			string featuresCol = GestureRecognitionModelColumnsConsts.FEATURES_COL;
			if (parameters.UsePca)
			{
				pipeline = pipeline.Append(
						context.Transforms.ProjectToPrincipalComponents(
								inputColumnName: GestureRecognitionModelColumnsConsts.FEATURES_COL,
								outputColumnName: GestureRecognitionModelColumnsConsts.FEATURES_PCA_COL,
								rank: parameters.PcaRank,
								seed: seed
						)
				);
				featuresCol = GestureRecognitionModelColumnsConsts.FEATURES_PCA_COL;
			}

			return (pipeline, featuresCol);
		}
		#endregion

		#region FastForest pipeline
		public static IEstimator<ITransformer> GetFastForestPipeline(MLContext context, int? seed, IEstimator<ITransformer> prepareDataPipeline, string featuresCol,
			FastForestParams fastForestParams)
		{
			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (prepareDataPipeline == null)
				throw new ArgumentNullException(nameof(prepareDataPipeline));
			if (string.IsNullOrEmpty(featuresCol))
				throw new ArgumentNullException(nameof(featuresCol));
			if (fastForestParams == null)
				throw new ArgumentNullException(nameof(fastForestParams));

			IEstimator<ITransformer> pipeline = prepareDataPipeline.AppendCacheCheckpoint(context);

			var ff = context.BinaryClassification.Trainers.FastForest(new FastForestBinaryTrainer.Options
			{
				FeatureColumnName = featuresCol,
				LabelColumnName = GestureRecognitionModelColumnsConsts.LABEL_KEY_COL,
				NumberOfTrees = fastForestParams.TreesCount,
				NumberOfLeaves = fastForestParams.LeavesCount,
				MinimumExampleCountPerLeaf = fastForestParams.MinimumExampleCountPerLeaf,
				FeatureFraction = fastForestParams.FeatureFraction,
				BaggingExampleFraction = fastForestParams.BaggingExampleFraction,
				Seed = seed ?? 42
			});

			pipeline = pipeline.Append(
					context.MulticlassClassification.Trainers.OneVersusAll(
							binaryEstimator: ff,
							labelColumnName: GestureRecognitionModelColumnsConsts.LABEL_KEY_COL
					)
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
	}
}
