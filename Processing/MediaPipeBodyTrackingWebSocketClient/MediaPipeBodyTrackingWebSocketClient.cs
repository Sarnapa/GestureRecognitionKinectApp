using System.Net.WebSockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;
using MessagePack;
using Newtonsoft.Json;

namespace GestureRecognition.Processing.MediaPipeBodyTrackingWebSocketClientProcUnit
{
	public class MediaPipeBodyTrackingWebSocketClient
	{
		#region Private fields
		private readonly ClientWebSocket wsClient;
		private readonly Uri serviceUri;
		#endregion

		#region Constructors
		public MediaPipeBodyTrackingWebSocketClient(string serviceUri)
		{
			this.wsClient = new ClientWebSocket();
			this.serviceUri = new Uri(serviceUri);
		}
		#endregion

		#region Public properties
		public bool IsConnected
		{
			get
			{
				return this.wsClient != null && this.wsClient.State == WebSocketState.Open;
			}
		}
		#endregion

		#region Public methods
		public async Task<ConnectAsyncResult> ConnectAsync(CancellationToken token)
		{
			try
			{
				if (this.wsClient.State != WebSocketState.Open)
				{
					await this.wsClient.ConnectAsync(this.serviceUri, token).ConfigureAwait(false);
				}

				return new ConnectAsyncResult()
				{
					Status = ConnectAsyncResultStatus.OK
				};
			}
			catch (OperationCanceledException ex)
			{
				return new ConnectAsyncResult()
				{
					Status = ConnectAsyncResultStatus.OperationCanceled,
					ErrorMessage = ex.Message
				};
			}
			catch (Exception ex)
			{
				return new ConnectAsyncResult()
				{
					Status = ConnectAsyncResultStatus.Error,
					ErrorMessage = ex.Message
				};
			}
		}

		public async Task<LoadPoseLandmarksModelResponse> LoadPoseLandmarksModelAsync(LoadPoseLandmarksModelRequest request, CancellationToken token)
		{
			try
			{
				byte[] requestBytes = SerializeToByteArray(request);
				var response = await SendRequestAndWaitForResponse<LoadPoseLandmarksModelResponse>(requestBytes, token).ConfigureAwait(false);
				if (response.Status == LoadPoseLandmarksModelResponseStatus.Error && string.IsNullOrEmpty(response.Message))
				{
					response.Message = "Loading pose landmarks model - received empty response.";
				}
				return response;
			}
			catch (WebSocketException wsEx)
			{
				return new LoadPoseLandmarksModelResponse()
				{
					Status = LoadPoseLandmarksModelResponseStatus.Error,
					Message = $"Loading pose landmarks model - communication error: [{wsEx.Message}]."
				};
			}
			catch (JsonException jsonEx)
			{
				return new LoadPoseLandmarksModelResponse()
				{
					Status = LoadPoseLandmarksModelResponseStatus.Error,
					Message = $"Loading pose landmarks model - serialization error: [{jsonEx.Message}]."
				};
			}
			catch (Exception ex)
			{
				return new LoadPoseLandmarksModelResponse()
				{
					Status = LoadPoseLandmarksModelResponseStatus.Error,
					Message = $"Loading pose landmarks model - unexpected error: [{ex.Message}]."
				};
			}
		}

		public async Task<DetectPoseLandmarksResponse> DetectPoseLandmarksAsync(DetectPoseLandmarksRequest request, CancellationToken token)
		{
			try
			{
				byte[] requestBytes = SerializeToByteArray(request);
				var response = await SendRequestAndWaitForResponse<DetectPoseLandmarksResponse>(requestBytes, token).ConfigureAwait(false);
				if (response.Status == DetectPoseLandmarksResponseStatus.Error && string.IsNullOrEmpty(response.Message))
				{
					response.Message = "Detecting pose landmarks - received empty response.";
				}
				return response;
			}
			catch (WebSocketException wsEx)
			{
				return new DetectPoseLandmarksResponse()
				{
					Status = DetectPoseLandmarksResponseStatus.Error,
					Message = $"Detecting pose landmarks - communication error: [{wsEx.Message}]."
				};
			}
			catch (JsonException jsonEx)
			{
				return new DetectPoseLandmarksResponse()
				{
					Status = DetectPoseLandmarksResponseStatus.Error,
					Message = $"Detecting pose landmarks - serialization error: [{jsonEx.Message}]."
				};
			}
			catch (Exception ex)
			{
				return new DetectPoseLandmarksResponse()
				{
					Status = DetectPoseLandmarksResponseStatus.Error,
					Message = $"Detecting pose landmarks - unexpected error: [{ex.Message}]."
				};
			}
		}

		public async Task<DisconnectAsyncResult> DisconnectAsync(CancellationToken token)
		{
			try
			{
				if (this.wsClient.State == WebSocketState.Open)
				{
					await this.wsClient.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token).ConfigureAwait(false);
				}

				this.wsClient?.Dispose();

				return new DisconnectAsyncResult()
				{
					Status = DisconnectAsyncResultStatus.OK
				};
			}
			catch (OperationCanceledException ex)
			{
				return new DisconnectAsyncResult()
				{
					Status = DisconnectAsyncResultStatus.OperationCanceled,
					ErrorMessage = ex.Message
				};
			}
			catch (Exception ex)
			{
				return new DisconnectAsyncResult()
				{
					Status = DisconnectAsyncResultStatus.Error,
					ErrorMessage = ex.Message
				};
			}
		}
		#endregion

		#region Private methods
		private static byte[] SerializeToByteArray(object obj)
		{
			return MessagePackSerializer.Serialize(obj);
		}

		private T DeserializeFromByteArray<T>(byte[] byteArray)
		{
			return MessagePackSerializer.Deserialize<T>(byteArray);
		}

		private async Task<T> SendRequestAndWaitForResponse<T>(byte[] messageBytes, CancellationToken token)
			where T : class, new()
		{
			var buffer = new ArraySegment<byte>(messageBytes);

			// TODO: In the case of an image, we should make sure to check the message size, otherwise the message will not be sent.
			// For now, there is an increased limit on the server side.
			// Send JSON request over WebSocket
			await this.wsClient.SendAsync(buffer, WebSocketMessageType.Binary, endOfMessage: true, token).ConfigureAwait(false);

			// Receive the response (loop until full JSON message is received)
			var receiveBuffer = new ArraySegment<byte>(new byte[8192]);
			using var ms = new MemoryStream();
			WebSocketReceiveResult result;
			do
			{
				result = await this.wsClient.ReceiveAsync(receiveBuffer, token).ConfigureAwait(false);
				ms.Write(receiveBuffer.Array!, receiveBuffer.Offset, result.Count);
			}
			while (!result.EndOfMessage);

			// Convert accumulated bytes to string
			ms.Seek(0, SeekOrigin.Begin);
			byte[] responseBytes = ms.ToArray();

			return DeserializeFromByteArray<T>(responseBytes) ?? new T();
		}
		#endregion
	}
}
