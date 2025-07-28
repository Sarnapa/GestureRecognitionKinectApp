using System.Drawing;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using GestureRecognition.Processing.BaseClassLib.Tests;
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
		private float poseLandmarksModelMinPoseDetectionConfidence = 0.8f;
		private float poseLandmarksModelMinPosePresenceConfidence = 0.8f;
		private float poseLandmarksModelMinTrackingConfidence = 0.8f;
		private float notTrackedJointVisibilityThreshold = 0.5f;
		private float inferredJointVisibilityThreshold = 0.8f;
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
			await LoadPoseLandmarksModel().ConfigureAwait(false);
		}

		[TestMethod]
		public async Task DetectsPoseLandmarksTest()
		{
			await LoadPoseLandmarksModel().ConfigureAwait(false);

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
		private async Task LoadPoseLandmarksModel()
		{
			Assert.IsNotNull(this.client);

			var request = GetLoadPoseLandmarksModelRequest(this.poseLandmarksModelKind, this.poseLandmarksModelNumPoses,
				this.poseLandmarksModelMinPoseDetectionConfidence, poseLandmarksModelMinPosePresenceConfidence,
				this.poseLandmarksModelMinTrackingConfidence);

			var response = await this.client.LoadPoseLandmarksModelAsync(request, CancellationToken.None).ConfigureAwait(false);
			Assert.IsNotNull(response);
			Assert.AreEqual(LoadPoseLandmarksModelResponseStatus.OK, response.Status);
		}

		private static LoadPoseLandmarksModelRequest GetLoadPoseLandmarksModelRequest(ModelKind kind, int numPoses,
			float minPoseDetectionConfidence, float minPosePresenceConfidence, float minTrackingConfidence)
		{
			return new LoadPoseLandmarksModelRequest()
			{
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
			byte[] imageData = ColorImageUtils.LoadPngAsBgra(filePath, out int width, out int height);
			Assert.IsNotNull(imageData);
			Assert.AreEqual(width * height * 4, imageData.Length);
			
			string imageBase64 = ColorImageUtils.EncodeImageToBase64(imageData);
			Assert.IsNotNull(imageBase64);
			Assert.IsNotEmpty(imageBase64);
			
			return new DetectPoseLandmarksRequest()
			{
				Image = imageBase64,
				ImageWidth = width,
				ImageHeight = height
			};
		}

		private async Task DetectsPoseLandmarks(string filePath)
		{
			Assert.IsNotNull(this.client);

			var request = GetDetectPoseLandmarksRequest(filePath);

			var response = await this.client.DetectPoseLandmarksAsync(request, CancellationToken.None).ConfigureAwait(false);
			Assert.IsNotNull(response);
			Assert.AreNotEqual(DetectPoseLandmarksResponseStatus.Error, response.Status);

			if (response.Status == DetectPoseLandmarksResponseStatus.OK)
			{
				Assert.IsNotNull(response.Landmarks);
				Assert.IsNotEmpty(response.Landmarks);
				Assert.IsNotNull(response.WorldLandmarks);
				Assert.IsNotEmpty(response.WorldLandmarks);
				Assert.AreEqual(response.Landmarks.Count, response.WorldLandmarks.Count);

				var bodiesData = response.Map(this.notTrackedJointVisibilityThreshold, this.inferredJointVisibilityThreshold);
				Assert.IsNotNull(bodiesData);
				Assert.AreEqual(response.Landmarks.Count, bodiesData.Length);

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

						string outputFilePath = filePath.Replace("Input", "Output");
						var drawBodyDataMng = new DrawBodyDataManager(filePath, outputFilePath);
						drawBodyDataMng.DrawBodyData(bodyData, RectangleF.Empty);
					}
				}
			}
		}
		#endregion

		#endregion
	}
}
