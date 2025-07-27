using Microsoft.ML.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

namespace GestureRecognition.Processing.BaseClassLib.Mappers
{
	public static class MLNetMapper
	{
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
	}
}
