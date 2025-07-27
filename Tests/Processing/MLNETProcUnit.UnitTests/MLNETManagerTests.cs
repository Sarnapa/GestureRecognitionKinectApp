using Microsoft.ML.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using GestureRecognition.Processing.BaseClassLib.Utils;

namespace GestureRecognition.Tests.Processing.MLNETProcUnit.UnitTests.UnitTests
{
	[TestClass]
	public class MLNETManagerTests
	{
		#region Public methods
		// TODO: To archive
		//[TestMethod]
		//public void LoadPoseDetectionModelTest()
		//{
		//	var (_, loadModelResult) = LoadPoseDetectionModel();

		//	Assert.IsNotNull(loadModelResult);
		//	Assert.IsTrue(loadModelResult.IsSuccess);
		//}

		// TODO: To archive
		//[TestMethod]
		//public void LoadPoseLandmarksDetectionModelTest()
		//{
		//	var (_, loadModelResult) = LoadPoseLandmarksDetectionModel();

		//	Assert.IsNotNull(loadModelResult);
		//	Assert.IsTrue(loadModelResult.IsSuccess);
		//}

		// TODO: To archive
		//[TestMethod]
		//public async Task PredictPoseLandmarksDetectionModelTest()
		//{
		//	var (model, loadModelResult) = LoadFullPoseLandmarksDetectionModel();

		//	Assert.IsNotNull(loadModelResult);
		//	Assert.IsTrue(loadModelResult.IsSuccess);

		//	string[] colorFrameImageFilePaths = Directory.GetFiles(@"../../../Input", "*.png").TakeLast(1).ToArray();
		//	foreach (string filePath in colorFrameImageFilePaths)
		//	{
		//		var colorFrame = GetColorFrameInput(filePath);
		//		Assert.IsNotNull(colorFrame);

		//		var predictResult = await model.Predict(new PoseLandmarksDetectionModelPredictParameters() { ColorFrame = colorFrame });
		//		Assert.IsNotNull(predictResult);
		//		Assert.IsInstanceOfType<PoseLandmarksDetectionModelPredictResult>(predictResult);

		//		if (predictResult.IsSuccess)
		//		{
		//			var poseLandmarksDetectionModelPredictResult = predictResult as PoseLandmarksDetectionModelPredictResult;
		//			Assert.IsNotNull(poseLandmarksDetectionModelPredictResult.BodyData);
		//			if (poseLandmarksDetectionModelPredictResult.BodyData.IsTracked)
		//			{
		//				Assert.IsNotNull(poseLandmarksDetectionModelPredictResult.BodyData.Joints);
		//				Assert.IsNotEmpty(poseLandmarksDetectionModelPredictResult.BodyData.Joints);
		//				Assert.IsNotNull(poseLandmarksDetectionModelPredictResult.BodyData.JointsColorSpacePoints);
		//				Assert.IsNotEmpty(poseLandmarksDetectionModelPredictResult.BodyData.JointsColorSpacePoints);

		//				string outputFilePath = filePath.Replace("Input", "Output");
		//				var drawBodyDataMng = new DrawBodyDataManager(filePath, outputFilePath);
		//				drawBodyDataMng.DrawBodyData(poseLandmarksDetectionModelPredictResult.BodyData,
		//					poseLandmarksDetectionModelPredictResult.BoundingBox);
		//			}
		//		}
		//	}
		//}
		#endregion

		#region Private methods
		// TODO: To archive
		//private static (IModelWrapper model, LoadModelResult result) LoadPoseDetectionModel()
		//{
		//	var modelWrapperParameters = new ModelWrapperParameters() { Seed = 42 };
		//	var modelWrapper = new PoseDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);

		//	var loadModelParameters = new LoadBodyTrackingModelParameters();
		//	var loadModelResult = modelWrapper.LoadModel(loadModelParameters);

		//	return (modelWrapper, loadModelResult);
		//}

		// TODO: To archive
		//private static (IModelWrapper model, LoadModelResult result) LoadPoseLandmarksDetectionModel()
		//{
		//	var modelWrapperParameters = new ModelWrapperParameters() { Seed = 42 };
		//	var modelWrapper = new PoseLandmarksDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);

		//	var loadModelParameters = new LoadBodyTrackingModelParameters();
		//	var loadModelResult = modelWrapper.LoadModel(loadModelParameters);

		//	return (modelWrapper, loadModelResult);
		//}

		// TODO: To archive
		//private static (IModelWrapper model, LoadModelResult result) LoadFullPoseLandmarksDetectionModel()
		//{
		//	var modelWrapperParameters = new ModelWrapperParameters() { Seed = 42 };
		//	var modelWrapper = new FullPoseLandmarksDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);

		//	var loadModelParameters = new LoadBodyTrackingModelParameters();
		//	var loadModelResult = modelWrapper.LoadModel(loadModelParameters);

		//	return (modelWrapper, loadModelResult);
		//}

		private static ColorFrameFullHDInput GetColorFrameInput(string filePath)
		{
			byte[] colorData = ColorImageUtils.LoadPngAsBgra(filePath, out int width, out int height);
			return new ColorFrameFullHDInput()
			{
				Image = MLImage.CreateFromPixels(width, height, MLPixelFormat.Bgra32, colorData)
			};
		}
		#endregion
	}
}
