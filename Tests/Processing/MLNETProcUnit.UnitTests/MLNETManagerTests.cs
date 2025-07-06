using System;
using GestureRecognition.Processing.MLNETProcUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestureRecognition.Tests.Processing.MLNETProcUnit.UnitTests.UnitTests
{
	[TestClass]
	public class MLNETManagerTests
	{
		[TestMethod]
		public void LoadMediaPipePoseLandmarkDetectionModel()
		{
			string poseDetectionModelPath = @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\BodyTrackingModels\Mediapipe\PoseLandmarkDetection\FromUnity\pose_detection.onnx";
			var manager = new MLNETManager();
			manager.LoadModel(poseDetectionModelPath);
		}
	}
}
