using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using GestureRecognition.Processing.MLNETProcUnit;

namespace GestureRecognition.Tests.Processing.MLNETProcUnit.UnitTests.UnitTests
{
	[TestClass]
	public class MLNETManagerTests
	{
		[TestMethod]
		public void LoadPoseDetectionModel()
		{
			var modelWrapperParameters = new ModelWrapperParameters() { Seed = 42 };
			var modelWrapper = new PoseDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);

			var loadModelParameters = new LoadBodyTrackingModelParameters();
			var loadModelResult = modelWrapper.LoadModel(loadModelParameters);

			Assert.IsNotNull(loadModelResult);
			Assert.IsTrue(loadModelResult.IsSuccess);
		}

		[TestMethod]
		public void LoadPoseLandmarksDetectionModel()
		{
			var modelWrapperParameters = new ModelWrapperParameters() { Seed = 42 };
			var modelWrapper = new PoseLandmarksDetectionModelWrapper<ColorFrameFullHDInput>(modelWrapperParameters);

			var loadModelParameters = new LoadBodyTrackingModelParameters();
			var loadModelResult = modelWrapper.LoadModel(loadModelParameters);

			Assert.IsNotNull(loadModelResult);
			Assert.IsTrue(loadModelResult.IsSuccess);
		}
	}
}
