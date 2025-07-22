using System.Collections.Generic;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	public static class Consts
	{
		public const string ModelZipExtension = ".zip";
		public const string ModelOnnxExtension = ".onnx";
		public static readonly List<string> SupportedModelFileExtension = new List<string>() 
			{ ModelZipExtension, ModelOnnxExtension };
	}
}
