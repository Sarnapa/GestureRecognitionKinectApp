using System;
using System.IO;
using Microsoft.ML;

namespace GestureRecognition.Processing.MLNETProcUnit
{
	public class MLNETManager
	{
		#region Private fields
		#endregion

		#region Public properties
		#endregion

		#region Constructors
		public MLNETManager()
		{
		}
		#endregion

		#region Public methods
		public void LoadModel(string modelPath)
		{
			if (!File.Exists(modelPath))
				throw new ArgumentException(nameof(modelPath));

			var mlContext = new MLContext();
			var onnxModel = mlContext.Transforms.ApplyOnnxModel(modelPath);
		}
		#endregion
	}
}
