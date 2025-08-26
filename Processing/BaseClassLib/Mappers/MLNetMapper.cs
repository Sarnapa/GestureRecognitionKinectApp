using Microsoft.ML.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace;

namespace GestureRecognition.Processing.BaseClassLib.Mappers
{
	public static class MLNetMapper
	{
		#region Public methods

		public static AllHyperparams Map(PrepareDataHyperparams prepareData, FastForestHyperparams fastForest)
		{
			return new AllHyperparams()
			{
				PcaRank = prepareData?.PcaRank ?? 0,
				TreesCount = fastForest?.TreesCount ?? 500,
				LeavesCount = fastForest?.LeavesCount ?? 32,
				MinimumExampleCountPerLeaf = fastForest?.MinimumExampleCountPerLeaf ?? 10,
				FeatureFraction = fastForest?.FeatureFraction ?? 0.2d,
				BaggingExampleFraction = fastForest?.BaggingExampleFraction ?? 1.0d
			};
		}

		public static AllHyperparamsSearchSpaceValues Map(PrepareDataSearchSpaceValues prepareData, FastForestSearchSpaceValues fastForest)
		{
			return new AllHyperparamsSearchSpaceValues()
			{
				PcaRankValues = prepareData?.PcaRankValues ?? new SearchSpaceIntRangeValues { Min = 0, Max = 0, Default = 0 },
				TreesCountValues = fastForest?.TreesCountValues ?? new SearchSpaceIntRangeValues() { Min = 500, Max = 500, Default = 500 },
				LeavesCountValues = fastForest?.LeavesCountValues ?? new SearchSpaceIntRangeValues() { Min = 32, Max = 32, Default = 32 },
				MinimumExampleCountPerLeafValues = fastForest?.MinimumExampleCountPerLeafValues ?? new SearchSpaceIntRangeValues() { Min = 10, Max = 10, Default = 10 },
				FeatureFractionValues = fastForest?.FeatureFractionValues ?? new SearchSpaceDoubleRangeValues() { Min = 0.2d, Max = 0.2d, Default = 0.2d },
				BaggingExampleFractionValues = fastForest?.BaggingExampleFractionValues ?? new SearchSpaceDoubleRangeValues() { Min = 1.0d, Max = 1.0d, Default = 1.0d }
			};
		}

		#region Code archived - failed attempt with mediapipe model in ONNX format
		// Code archived - failed attempt with mediapipe model in ONNX format
		//#region ColorFrame -> ColorFrameInput
		//public static BaseColorFrameInput Map(this ColorFrame colorFrame, ResolutionType resolutionType)
		//{
		//	if (colorFrame == null)
		//		return null;

		//	if (resolutionType == ResolutionType.Unknown)
		//		return null;

		//	var mlImage = MLImage.CreateFromPixels(colorFrame.Width, colorFrame.Height,
		//		colorFrame.RawColorImageFormat.Map(), colorFrame.ColorData);

		//	switch (resolutionType)
		//	{
		//		case ResolutionType.VGA:
		//			return new ColorFrameVGAInput { Image = mlImage };
		//		case ResolutionType.HD:
		//			return new ColorFrameHDInput { Image = mlImage };
		//		case ResolutionType.FullHD:
		//			return new ColorFrameFullHDInput { Image = mlImage };
		//		case ResolutionType.UltraHD:
		//			return new ColorFrameUltraHDInput { Image = mlImage };
		//	}

		//	return null;
		//}
		//#endregion

		// Code archived - failed attempt with mediapipe model in ONNX format
		//#region ColorImageFormat -> MLPixelFormat
		//public static MLPixelFormat Map(this ColorImageFormat imageFormat)
		//{
		//	switch (imageFormat)
		//	{
		//		case ColorImageFormat.Rgba:
		//			return MLPixelFormat.Rgba32;
		//		case ColorImageFormat.Bgra:
		//			return MLPixelFormat.Bgra32;
		//	}

		//	return MLPixelFormat.Unknown;
		//}
		//#endregion

		#endregion

		#endregion
	}
}
