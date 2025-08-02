using System.Drawing;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using GestureRecognition.Processing.BaseClassLib.Structures.Tests;
using GestureRecognition.Processing.BaseClassLib.Tests;

namespace GestureRecognition.Tests.Processing.MediaPipeBodyTrackingWebSocketServer.IntegrationTests
{
	public class Utils
	{
		#region Validating bodies data methods
		public static void CheckBodiesData(BodyDataWithColorSpacePoints[] bodiesData, ModelKind modelKind, string filePath, string outputReplacement)
		{
			string outputFilePath = filePath.Replace("Input", outputReplacement);

			DrawBodyDataManagerParameters parameters = new DrawBodyDataManagerParameters();
			if (modelKind == ModelKind.HandLandmarks)
			{
				parameters = new DrawBodyDataManagerParameters()
				{
					InputImagePath = filePath,
					OutputImagePath = outputFilePath,
					HandSize = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.HAND_SIZE,
					JointThickness = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.JOINT_THICKNESS,
					GestureRecognitionJointThickness = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS,
					BodySkeletonThickness = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.BODY_SKELETON_THICKNESS,
					JointsToIgnore = MediaPipeHandLandmarksRenderBodyFrameConsts.JOINTS_TO_IGNORE,
					GestureRecognitionJoints = MediaPipeHandLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints,
					Bones = MediaPipeHandLandmarksBonesDefinitions.AllBones.ToArray(),
					IsInferredMode = false,
				};
			}
			else
			{
				parameters = new DrawBodyDataManagerParameters()
				{
					InputImagePath = filePath,
					OutputImagePath = outputFilePath,
					HandSize = (float)MediaPipePoseLandmarksRenderBodyFrameConsts.HAND_SIZE,
					JointThickness = (float)MediaPipePoseLandmarksRenderBodyFrameConsts.JOINT_THICKNESS,
					GestureRecognitionJointThickness = (float)MediaPipePoseLandmarksRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS,
					BodySkeletonThickness = (float)MediaPipePoseLandmarksRenderBodyFrameConsts.BODY_SKELETON_THICKNESS,
					JointsToIgnore = MediaPipePoseLandmarksRenderBodyFrameConsts.JOINTS_TO_IGNORE,
					GestureRecognitionJoints = MediaPipePoseLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints,
					Bones = MediaPipePoseLandmarksBonesDefinitions.AllBonesWithoutHeadAndLegs.ToArray(),
					IsInferredMode = false,
				};
			}

			var drawBodyDataMng = new DrawBodyDataManager(parameters);

			foreach (var bodyData in bodiesData)
			{
				Assert.IsNotNull(bodyData);

				if (bodyData.IsTracked)
				{
					Assert.IsNotNull(bodyData.Joints);
					Assert.IsNotEmpty(bodyData.Joints);
					Assert.IsTrue(bodyData.Joints.Any(kv => kv.Value.TrackingState == TrackingState.Tracked));
					Assert.IsNotNull(bodyData.JointsColorSpacePoints);
					Assert.IsNotEmpty(bodyData.JointsColorSpacePoints);
					Assert.AreEqual(bodyData.Joints.Count, bodyData.JointsColorSpacePoints.Count);
					drawBodyDataMng.DrawBodyData(bodyData, RectangleF.Empty);
				}
			}
		}
		#endregion
	}
}
