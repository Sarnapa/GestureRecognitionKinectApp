using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Events;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.KinectServer.Kinect;
using static GestureRecognition.Processing.BaseClassLib.Utils.KinectServerUtils;

namespace GestureRecognition.Processing.KinectServer
{
	internal class Server
	{
		#region Private fields
		private bool isRunning = true;
		private readonly KinectManager kinectManager;
		private readonly NamedPipeServerStream pipeServer;
		private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
		#endregion

		#region Constructors
		public Server()
		{
			this.kinectManager = new KinectManager();
			this.pipeServer = new NamedPipeServerStream(Consts.PipeName, PipeDirection.InOut, 1,
				PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
		}
		#endregion

		#region Public methods
		public async Task<bool> Start()
		{
			string methodName = $"{nameof(Server)}.{nameof(Start)}";
			try
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Waiting for client...");
				await this.pipeServer.WaitForConnectionAsync().ConfigureAwait(false);
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Client connected.");

				AttachKinectManagerEventsHandlers();
				this.isRunning = true;
				return this.pipeServer.IsConnected;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return false;
			}
		}

		public Task StartListenTask(CancellationToken token = default)
		{
			return Task.Run(() => Listen(token, true), token);
		}

		public async Task Listen(CancellationToken token = default, bool cleanup = false)
		{
			string methodName = $"{nameof(Server)}.{nameof(Listen)}";
			Console.WriteLine($"[{methodName}][{DateTime.Now}] Listening for messages from the client has started.");
			while (this.isRunning && !token.IsCancellationRequested)
			{
				try
				{
					var message = await ReadMessage(methodName, this.pipeServer, token).ConfigureAwait(false);
					if (message?.Header == null)
					{
						Console.WriteLine($"[{methodName}][{DateTime.Now}] Failed to read message.");
						continue;
					}

					var messageType = message.Header.Type;
					switch (messageType)
					{
						case MessageType.StartRequest:
							await HandleStartRequest(message, token).ConfigureAwait(false);
							break;
						case MessageType.StopRequest:
							await HandleStopRequest(token).ConfigureAwait(false);
							this.isRunning = false;
							break;
						default:
							Console.WriteLine($"[{methodName}][{DateTime.Now}] Unexpected message type: {messageType}.");
							break;
					}
				}
				catch (IOException ex)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] IOException: {ex.Message}, this may happen if client disconnected unexpectedly.");
					break;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				}
			}

			if (cleanup)
				Cleanup();
		}

		public void Cleanup()
		{
			string methodName = $"{nameof(Server)}.{nameof(Cleanup)}";
			this.DetachKinectManagerEventsHandlers();
			this.pipeServer.Close();
			this.pipeServer.Dispose();
			this.isRunning = false;
		}
		#endregion

		#region Private methods

		#region Start and Stop requests handling methods
		private async Task HandleStartRequest(Message message, CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(HandleStartRequest)}";
			try
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Received Start request.");
				var parameters = GetStartRequestParams(message, token);
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Start request parameters:\n{parameters}");

				var result = this.kinectManager.GetKinectSensorInfoToStart(parameters);
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Start request result:\n{result}");

				await SendStartResponse(result, token).ConfigureAwait(false);
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Start response sent.");

				if (!result.IsSuccess)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Failed to start Kinect sensor, stopping server.");
					this.isRunning = false;
					return;
				}

				this.kinectManager.StartKinectSensor();
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Kinect sensor is open.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private StartRequestParams GetStartRequestParams(Message message, CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(GetStartRequestParams)}";
			using (var ms = new MemoryStream(message.Payload))
			{
				using (var payloadReader = new BinaryReader(ms))
				{
					var parameters = new StartRequestParams
					{
						FrameSourceTypes = (FrameSourceTypes)payloadReader.ReadInt32(),
						ColorImageFormat = (ColorImageFormat)payloadReader.ReadInt32(),
						IsOneBodyTrackingEnabled = payloadReader.ReadBoolean()
					};
					return parameters;
				}
			}
		}

		private async Task SendStartResponse(StartResponseResult result, CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendStartResponse)}";
			try
			{
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						payloadWriter.Write(result?.IsSuccess ?? false);
						payloadWriter.Write(result?.ColorFrameWidth ?? 0);
						payloadWriter.Write(result?.ColorFrameHeight ?? 0);
						payloadWriter.Write(result?.KinectSensorIsAvailable ?? false);
					}
					byte[] payload = ms.ToArray();
					var message = CreateMessage(MessageType.StartResponse, payload);

					await WriteMessageWithLock(methodName, this.pipeServer, message, token).ConfigureAwait(false);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private async Task HandleStopRequest(CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(HandleStopRequest)}";
			try
			{
				var parameters = new StopRequestParams();
				var result = this.kinectManager.Stop(parameters);
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Stop request result:\n{result}");

				await SendStopResponse(result, token).ConfigureAwait(false);
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Stop response sent.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private async Task SendStopResponse(StopResponseResult result, CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendStopResponse)}";
			try
			{
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						payloadWriter.Write(result?.IsSuccess ?? false);
					}
					byte[] payload = ms.ToArray();
					var message = CreateMessage(MessageType.StopResponse, payload);

					await WriteMessageWithLock(methodName, this.pipeServer, message, token).ConfigureAwait(false);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}
		#endregion

		#region Arrived frame handling methods
		private async Task KinectManager_OnFrameArrived(object sender, FrameArrivedEventArgs e)
		{
			string methodName = $"{nameof(Server)}.{nameof(KinectManager_OnFrameArrived)}";
			try
			{
				await SendFrameDataMessage(e?.Data, CancellationToken.None).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private async Task SendFrameDataMessage(FrameData data, CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendFrameDataMessage)}";
			try
			{
				// It is controlled in the KinectManager to send frames when it makes sense, but just in case.
				var colorFrame = data?.ColorFrame ?? new ColorFrame();
				var bodyFrame = data?.BodyFrame ?? new BodyFrame();
				var bodiesJointsColorSpacePointsDict = data?.BodiesJointsColorSpacePointsDict ?? new Dictionary<ulong, BodyJointsColorSpacePointsDict>();

				Console.WriteLine($"[{methodName}][{DateTime.Now}] Frame message sending...");
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						WriteColorFrame(payloadWriter, colorFrame);
						WriteBodyFrame(payloadWriter, bodyFrame);
						WriteBodiesJointsColorSpacePointsDict(payloadWriter, bodiesJointsColorSpacePointsDict);
					}
					byte[] payload = ms.ToArray();
					var message = CreateMessage(MessageType.Frame, payload);

					await WriteMessageWithLock(methodName, this.pipeServer, message, token).ConfigureAwait(false);
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Frame message sent.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void WriteColorFrame(BinaryWriter payloadWriter, ColorFrame colorFrame)
		{
			payloadWriter.Write(colorFrame.Width);
			payloadWriter.Write(colorFrame.Height);
			payloadWriter.Write((int)colorFrame.RawColorImageFormat);
			payloadWriter.Write(colorFrame.BytesPerPixel);
			payloadWriter.Write(colorFrame.LengthInPixels);
			payloadWriter.Write(colorFrame.RelativeTime.Ticks);
			payloadWriter.Write(colorFrame.ColorData.Length);
			if (colorFrame.ColorData.Length > 0)
				payloadWriter.Write(colorFrame.ColorData);
		}

		private void WriteBodyFrame(BinaryWriter payloadWriter, BodyFrame bodyFrame)
		{
			payloadWriter.Write(bodyFrame.RelativeTime.Ticks);
			payloadWriter.Write(bodyFrame.BodiesCount);
			payloadWriter.Write(bodyFrame.TooMuchUsersForOneBodyTracking);
			if (!bodyFrame.TooMuchUsersForOneBodyTracking)
			{
				foreach (var body in bodyFrame.Bodies)
				{
					WriteBodyData(payloadWriter, body);
				}
			}
		}

		private void WriteBodyData(BinaryWriter payloadWriter, BodyData bodyData)
		{
			payloadWriter.Write(bodyData.TrackingId);
			payloadWriter.Write(bodyData.IsTracked);
			payloadWriter.Write(bodyData.Joints.Count);
			foreach (var joint in bodyData.Joints.Values)
			{
				WriteJoint(payloadWriter, joint);
			}
			payloadWriter.Write((int)bodyData.HandLeftState);
			payloadWriter.Write((int)bodyData.HandLeftConfidence);
			payloadWriter.Write((int)bodyData.HandRightState);
			payloadWriter.Write((int)bodyData.HandRightConfidence);
		}

		private void WriteJoint(BinaryWriter payloadWriter, Joint joint)
		{
			payloadWriter.Write((int)joint.JointType);
			payloadWriter.Write(joint.Position.X);
			payloadWriter.Write(joint.Position.Y);
			payloadWriter.Write(joint.Position.Z);
			payloadWriter.Write((int)joint.TrackingState);
		}

		private void WriteBodiesJointsColorSpacePointsDict(BinaryWriter payloadWriter, 
			IDictionary<ulong, BodyJointsColorSpacePointsDict> bodiesJointsColorSpacePointsDict)
		{
			payloadWriter.Write(bodiesJointsColorSpacePointsDict.Count);
			foreach (var kv in bodiesJointsColorSpacePointsDict)
			{
				payloadWriter.Write(kv.Key);
				payloadWriter.Write(kv.Value.Count);
				foreach (var jointPos in kv.Value)
				{
					payloadWriter.Write((int)jointPos.Key);
					payloadWriter.Write(jointPos.Value.X);
					payloadWriter.Write(jointPos.Value.Y);
				}
			}
		}
		#endregion

		#region Kinect availability status handling methods
		private async Task KinectManager_OnKinectIsAvailableChanged(object sender, KinectIsAvailableChangedEventArgs e)
		{
			string methodName = $"{nameof(Server)}.{nameof(KinectManager_OnKinectIsAvailableChanged)}";
			try
			{
				await SendKinectIsAvailableChangedMessage(e?.Data, CancellationToken.None).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private async Task SendKinectIsAvailableChangedMessage(KinectIsAvailableChangedData data, CancellationToken token)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendKinectIsAvailableChangedMessage)}";
			try
			{
				bool isAvailable = data?.IsAvailable ?? false;
				string currentStatusText = isAvailable ? "Available" : "Not available";
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Kinect availability has changed, current status - {currentStatusText}");
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						payloadWriter.Write(isAvailable);
					}
					byte[] payload = ms.ToArray();
					var message = CreateMessage(MessageType.KinectIsAvailableChanged, payload);

					await WriteMessageWithLock(methodName, this.pipeServer, message, token).ConfigureAwait(false);
					Console.WriteLine($"[{methodName}][{DateTime.Now}] KinectIsAvailableChanged message sent.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}
		#endregion

		#region Other private methods
		private async Task WriteMessageWithLock(string methodName, NamedPipeServerStream pipeServer, Message message, CancellationToken token)
		{
			try
			{
				await this.semaphore.WaitAsync(token).ConfigureAwait(false);	
				await WriteMessage(methodName, pipeServer, message, token).ConfigureAwait(false);
			}
			finally
			{
				this.semaphore.Release();
			}
		}

		private void AttachKinectManagerEventsHandlers()
		{
			this.kinectManager.OnFrameArrived += this.KinectManager_OnFrameArrived;
			this.kinectManager.OnKinectIsAvailableChanged += this.KinectManager_OnKinectIsAvailableChanged;
		}

		private void DetachKinectManagerEventsHandlers()
		{
			this.kinectManager.OnFrameArrived -= this.KinectManager_OnFrameArrived;
			this.kinectManager.OnKinectIsAvailableChanged -= this.KinectManager_OnKinectIsAvailableChanged;
		}
		#endregion

		#endregion
	}
}
