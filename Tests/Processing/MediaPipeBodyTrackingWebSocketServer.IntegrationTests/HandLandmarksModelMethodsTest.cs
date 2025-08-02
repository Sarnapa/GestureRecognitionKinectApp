using System.Diagnostics;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.MediaPipeBodyTrackingWebSocketClientProcUnit;

namespace GestureRecognition.Tests.Processing.MediaPipeBodyTrackingWebSocketServer.IntegrationTests
{
	[TestClass]
	public sealed class HandLandmarksModelMethodsTest
	{
		#region Private fields & constants
		private const string SERVICE_URL = "ws://localhost:5555";

		private MediaPipeBodyTrackingWebSocketClient? client;

		private int handLandmarksModelNumHands = 2;
		private float handLandmarksModelMinHandDetectionConfidence = 0.6f;
		private float handLandmarksModelMinHandPresenceConfidence = 0.6f;
		private float handLandmarksModelMinTrackingConfidence = 0.6f;
		private float trackedJointScoreThreshold = 0.6f;
		private float inferredJointScoreThreshold = 0.5f;

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
		public async Task LoadHandLandmarksModelTest()
		{
			await LoadHandLandmarksModel().ConfigureAwait(false);
		}

		[TestMethod]
		public async Task DetectsHandLandmarksTest()
		{
			await LoadHandLandmarksModel().ConfigureAwait(false);

			string[] colorFrameImageFilePaths = Directory.GetFiles(@"../../../Input", "*.png").ToArray();
			foreach (string filePath in colorFrameImageFilePaths)
			{
				//string filePath = @"C:\Users\Michal\source\repos\GestureRecognitionKinectApp\Tests\Processing\MediaPipeBodyTrackingWebSocketServer.IntegrationTests\Input\ColorFrame_6.png";
				await DetectsHandLandmarks(filePath).ConfigureAwait(false);
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

		#region Loading hand landmarks model methods
		private async Task LoadHandLandmarksModel()
		{
			Assert.IsNotNull(this.client);

			var request = GetLoadHandLandmarksModelRequest(this.handLandmarksModelNumHands, this.handLandmarksModelMinHandDetectionConfidence,
				this.handLandmarksModelMinHandPresenceConfidence, this.handLandmarksModelMinTrackingConfidence);

			var response = await this.client.LoadHandLandmarksModelAsync(request, CancellationToken.None).ConfigureAwait(false);
			Assert.IsNotNull(response);
			Assert.AreEqual(LoadHandLandmarksModelResponseStatus.OK, response.Status);
		}

		private static LoadHandLandmarksModelRequest GetLoadHandLandmarksModelRequest(int numHands,
			float minHandDetectionConfidence, float minHandPresenceConfidence, float minTrackingConfidence)
		{
			return new LoadHandLandmarksModelRequest()
			{
				NumHands = numHands,
				MinHandDetectionConfidence = minHandDetectionConfidence,
				MinHandPresenceConfidence = minHandPresenceConfidence,
				MinTrackingConfidence = minTrackingConfidence,
			};
		}
		#endregion

		#region Detecting hand landmarks methods
		private static DetectHandLandmarksRequest GetDetectHandLandmarksRequest(string filePath)
		{
			byte[] imageData = ColorImageUtils.LoadPngAsBgra(filePath, out int currentImageWidth, out int currentImageHeight);
			Assert.IsNotNull(imageData);
			Assert.AreEqual(currentImageWidth * currentImageHeight * 4, imageData.Length);

			int scaledImageWidth = ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_WIDTH;
			int scaledImageHeight = ModelConsts.HAND_LANDMARKS_MODEL_IMAGE_INPUT_HEIGHT;

			if (currentImageWidth != scaledImageWidth || currentImageHeight != scaledImageHeight)
			{
				imageData = ColorImageUtils.PrepareBgraImageForMediaPipeModel(imageData, currentImageWidth, currentImageHeight, scaledImageWidth, scaledImageHeight);
			}

			Assert.IsNotNull(imageData);

			return new DetectHandLandmarksRequest()
			{
				Image = imageData,
				ImageWidth = scaledImageWidth,
				ImageHeight = scaledImageHeight,
				ImageTargetWidth = currentImageWidth,
				ImageTargetHeight = currentImageHeight,
				IsOneBodyTrackingEnabled = true
			};
		}

		private async Task DetectsHandLandmarks(string filePath)
		{
			Assert.IsNotNull(this.client);

			var request = GetDetectHandLandmarksRequest(filePath);

			var start = DateTime.Now;
			var response = await this.client.DetectHandLandmarksAsync(request, CancellationToken.None).ConfigureAwait(false);
			var finish = DateTime.Now;
			Debug.WriteLine($"[{DateTime.Now}] Detects duration: {(finish - start).Milliseconds}");
			Assert.IsNotNull(response);
			Assert.AreNotEqual(DetectHandLandmarksResponseStatus.Error, response.Status);

			if (response.Status == DetectHandLandmarksResponseStatus.OK)
			{
				Assert.AreEqual(1, response.BodiesCount);

				Assert.IsNotNull(response.Handedness);
				Assert.IsNotEmpty(response.Handedness);
				Assert.IsNotNull(response.Landmarks);
				Assert.IsNotEmpty(response.Landmarks);
				Assert.IsNotNull(response.WorldLandmarks);
				Assert.IsNotEmpty(response.WorldLandmarks);
				Assert.AreEqual(response.Landmarks.Count, response.Handedness.Count);
				Assert.AreEqual(response.Landmarks.Count, response.WorldLandmarks.Count);
				Assert.IsTrue(response.Landmarks.Count <= this.handLandmarksModelNumHands);

				var bodyData = response.Map(this.trackedJointScoreThreshold, this.inferredJointScoreThreshold);
				Assert.IsNotNull(bodyData);

				Utils.CheckBodiesData(new[] { bodyData }, ModelKind.HandLandmarks, filePath, "Output/Hand");
			}
		}
		#endregion

		#endregion
	}
}
