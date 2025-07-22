// TODO

//using System;
//using System.IO;
//using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
//using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
//using Microsoft.ML;

//namespace GestureRecognition.Processing.MLNETProcUnit
//{
//	public class GestureRecognitionModelWrapper : ModelWrapper<>
//	{

//		#region Constructors
//		#endregion

//		#region Public methods
//		public LoadModelResult LoadModel(BaseLoadModelParameters parameters)
//		{
//			if (parameters == null)
//				throw new ArgumentNullException(nameof(parameters));

//			this.ModelUsageKind = parameters.UsageKind;

//			LoadModelResult result;
//			switch (this.ModelUsageKind)
//			{
//				case ModelUsageKind.PoseDetection:
//				case ModelUsageKind.PoseLandmarksDetection:
//					this.ModelKind = ModelKind.ONNX;
//					if (parameters is LoadBodyTrackingModelParameters bodyTrackingModelParameters)
//						result = LoadOnnxModel(bodyTrackingModelParameters);
//					else
//					{
//						result = new LoadModelResult()
//						{
//							ErrorKind = LoadModelErrorKind.InvalidParameters,
//							ErrorMessage = $"Invalid parameters for loading external body tracking model."
//						};
//					}
//					break;
//				default:
//					if (parameters is LoadGestureRecognitionModelParameters gestureRecognitionModelParameters)
//					{
//						(bool fileExists, LoadModelResult fileNotExistResult) = CheckIfFileExists(gestureRecognitionModelParameters.Path);
//						if (fileExists)
//						{
//							string modelFileExtension = Path.GetExtension(gestureRecognitionModelParameters.Path).ToLower();
//							(bool supportedModelFileExtension, LoadModelResult unsupportedModelFileExtension)
//								= CheckIfSupportedModelFileExtension(modelFileExtension);
//							if (supportedModelFileExtension)
//							{
//								this.ModelPath = gestureRecognitionModelParameters.Path;
//								switch (modelFileExtension)
//								{
//									case Consts.ModelOnnxExtension:
//										result = new LoadModelResult()
//										{
//											ErrorKind = LoadModelErrorKind.UnsupportedModelFileExtension,
//											ErrorMessage = $"Unsupported model file extension for gesture recognition model: [{modelFileExtension}]. Only supported: [{Consts.ModelZipExtension}]]."
//										};
//										break;
//									default:
//										this.ModelKind = ModelKind.Standard;
//										result = LoadStandardModel(gestureRecognitionModelParameters);
//										break;
//								}
//							}
//							else
//							{
//								result = unsupportedModelFileExtension;
//							}
//						}
//						else
//						{
//							result = fileNotExistResult;
//						}
//					}
//					else
//					{
//						result = new LoadModelResult()
//						{
//							ErrorKind = LoadModelErrorKind.InvalidParameters,
//							ErrorMessage = $"Invalid parameters for loading gesture recognition model."
//						};
//					}
//					break;
//			}

//			return result;
//		}
//		#endregion

//		#region Protected methods

//		#region Loading gesture recognition models methods
//		private LoadModelResult LoadStandardModel(LoadGestureRecognitionModelParameters parameters)
//		{
//			try
//			{
//				this.model = this.mlContext.Model.Load(this.ModelPath, out DataViewSchema modelSchema);
//				if (this.model == null)
//				{
//					return new LoadModelResult()
//					{
//						ErrorKind = LoadModelErrorKind.UnexpectedError,
//						ErrorMessage = $"Loaded empty standard model for given model file path: [{this.ModelPath}]."
//					};
//				}

//				return new LoadModelResult();
//			}
//			catch (Exception ex)
//			{
//				return new LoadModelResult()
//				{
//					ErrorKind = LoadModelErrorKind.UnexpectedError,
//					ErrorMessage = $"Unexpected error during loading standard model for given model file path: [{this.ModelPath}]. " +
//					$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
//				};
//			}
//		}
//		#endregion

//		#endregion
//	}
//}
