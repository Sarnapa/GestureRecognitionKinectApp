using System.Diagnostics;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.MediaPipeBodyTrackingWebSocketClientProcUnit;

namespace GestureRecognition.Tests.Processing.MediaPipeBodyTrackingWebSocketServer.IntegrationTests
{
	[TestClass]
	public sealed class PoseLandmarksModelMethodsTest
	{
		#region Private fields & constants
		private const string SERVICE_URL = "ws://localhost:5555";

		private MediaPipeBodyTrackingWebSocketClient? client;

		private ModelKind poseLandmarksModelKind = ModelKind.PoseLandmarksLite;
		private int poseLandmarksModelNumPoses = 1;
		private float poseLandmarksModelMinPoseDetectionConfidence = 0.2f;
		private float poseLandmarksModelMinPosePresenceConfidence = 0.5f;
		private float poseLandmarksModelMinTrackingConfidence = 0.5f;
		private float trackedJointVisibilityThreshold = 0.2f;
		private float inferredJointVisibilityThreshold = 0.1f;
		#endregion

		#region Tests methods
		[TestInitialize]
		public async Task TestInitialize()
		{
			this.client = new MediaPipeBodyTrackingWebSocketClient(SERVICE_URL);
			var result = await this.client.ConnectAsync(CancellationToken.None).ConfigureAwait(false);
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccess);
		}

		[TestMethod]
		public async Task LoadPoseLandmarksModelTest()
		{
			await LoadPoseLandmarksModel(true).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task DetectsPoseLandmarksTest()
		{
			await LoadPoseLandmarksModel(true).ConfigureAwait(false);

			string[] colorFrameImageFilePaths = Directory.GetFiles(@"../../../Input", "*.png").ToArray();
			foreach (string filePath in colorFrameImageFilePaths)
			{
				await DetectsPoseLandmarks(filePath).ConfigureAwait(false);
			}
		}

		[TestCleanup]
		public async Task TestCleanup()
		{
			if (this.client != null)
			{
				var result = await this.client.DisconnectAsync(CancellationToken.None).ConfigureAwait(false);
				Assert.IsNotNull(result);
				Assert.IsTrue(result.IsSuccess);
			}
		}
		#endregion

		#region Private methods

		#region Loading pose landmarks model methods
		private async Task LoadPoseLandmarksModel(bool forceReload)
		{
			Assert.IsNotNull(this.client);

			var request = GetLoadPoseLandmarksModelRequest(forceReload, this.poseLandmarksModelKind, this.poseLandmarksModelNumPoses,
				this.poseLandmarksModelMinPoseDetectionConfidence, this.poseLandmarksModelMinPosePresenceConfidence,
				this.poseLandmarksModelMinTrackingConfidence);

			var response = await this.client.LoadPoseLandmarksModelAsync(request, CancellationToken.None).ConfigureAwait(false);
			Assert.IsNotNull(response);
			Assert.AreEqual(LoadPoseLandmarksModelResponseStatus.OK, response.Status);
		}

		private static LoadPoseLandmarksModelRequest GetLoadPoseLandmarksModelRequest(bool forceReload, ModelKind kind, int numPoses,
			float minPoseDetectionConfidence, float minPosePresenceConfidence, float minTrackingConfidence)
		{
			return new LoadPoseLandmarksModelRequest()
			{
				ForceReload = forceReload,
				Kind = kind,
				NumPoses = numPoses,
				MinPoseDetectionConfidence = minPoseDetectionConfidence,
				MinPosePresenceConfidence = minPosePresenceConfidence,
				MinTrackingConfidence = minTrackingConfidence,
			};
		}
		#endregion

		#region Detecting pose landmarks methods
		private static DetectPoseLandmarksRequest GetDetectPoseLandmarksRequest(string filePath)
		{
			byte[] imageData = ColorImageUtils.LoadPngAsBgra(filePath, out int currentImageWidth, out int currentImageHeight);
			Assert.IsNotNull(imageData);
			Assert.AreEqual(currentImageWidth * currentImageHeight * 4, imageData.Length);

			int scaledImageWidth = ModelConsts.POSE_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH;
			int scaledImageHeight = ModelConsts.POSE_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT;

			if (currentImageWidth != scaledImageWidth || currentImageHeight != scaledImageHeight)
			{
				imageData = ColorImageUtils.PrepareBgraImageForMediaPipeModel(imageData, currentImageWidth, currentImageHeight, scaledImageWidth, scaledImageHeight);
			}

			Assert.IsNotNull(imageData);

			return new DetectPoseLandmarksRequest()
			{
				Image = imageData,
				ImageWidth = scaledImageWidth,
				ImageHeight = scaledImageHeight,
				ImageTargetWidth = currentImageWidth,
				ImageTargetHeight = currentImageHeight,
				IsOneBodyTrackingEnabled = true
			};
		}

		private async Task DetectsPoseLandmarks(string filePath)
		{
			Assert.IsNotNull(this.client);

			var request = GetDetectPoseLandmarksRequest(filePath);

			var start = DateTime.Now;
			var response = await this.client.DetectPoseLandmarksAsync(request, CancellationToken.None).ConfigureAwait(false);
			var finish = DateTime.Now;
			Debug.WriteLine($"[{DateTime.Now}] Detects duration: {(finish - start).Milliseconds}");
			Assert.IsNotNull(response);
			Assert.AreNotEqual(DetectPoseLandmarksResponseStatus.Error, response.Status);

			if (response.Status == DetectPoseLandmarksResponseStatus.OK)
			{
				Assert.AreEqual(1, response.BodiesCount);

				Assert.IsNotNull(response.Landmarks);
				Assert.IsNotEmpty(response.Landmarks);
				Assert.IsNotNull(response.WorldLandmarks);
				Assert.IsNotEmpty(response.WorldLandmarks);
				Assert.AreEqual(response.Landmarks.Count, response.WorldLandmarks.Count);

				Assert.IsNotNull(response.HandLeftStates);
				Assert.IsNotEmpty(response.HandLeftStates);
				Assert.IsNotNull(response.HandRightStates);
				Assert.IsNotEmpty(response.HandRightStates);
				Assert.AreEqual(response.HandLeftStates.Count, response.HandRightStates.Count);

				Assert.AreEqual(response.Landmarks.Count, response.HandLeftStates.Count);

				var bodiesData = await response.Map(this.trackedJointVisibilityThreshold, this.inferredJointVisibilityThreshold).ConfigureAwait(false);
				Assert.IsNotNull(bodiesData);
				Assert.AreEqual(response.Landmarks.Count, bodiesData.Length);

				Utils.CheckBodiesData(bodiesData, this.poseLandmarksModelKind, filePath, "Output/Pose");
			}
		}
		#endregion

		#endregion
	}
}
