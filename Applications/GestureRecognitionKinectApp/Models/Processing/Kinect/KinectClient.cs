using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Events;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using static GestureRecognition.Processing.BaseClassLib.Utils.KinectServerUtils;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Kinect
{
	public class KinectClient
	{
		#region Private fields
		private readonly NamedPipeClientStream pipeClient;
		#endregion

		#region Public properties
		public bool IsConnected
		{
			get
			{
				return this.pipeClient != null && this.pipeClient.IsConnected;
			}
		}
		#endregion

		#region Public events
		public event FrameArrivedEventHandler OnFrameArrived;
		public event KinectIsAvailableChangedEventHandler OnKinectIsAvailableChanged;
		#endregion

		#region Constructors
		public KinectClient()
		{
			this.pipeClient = new NamedPipeClientStream(".", Consts.PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
		}
		#endregion

		#region Public methods
		public bool StartKinectServer()
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(StartKinectServer)}";
			try
			{
				string kinectServerExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{Consts.ServerName}.exe");
				var kinectServerExeProcess = Process.Start(kinectServerExePath);
				return kinectServerExeProcess != null;
			}
			catch (Exception ex)
			{
				// TODO: Better way for logging
				Debug.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return false;
			}
		}

		public async Task<bool> Connect(int timeout = 60000, CancellationToken cancellationToken = default)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(Connect)}";
			try
			{
				await this.pipeClient.ConnectAsync(timeout, cancellationToken).ConfigureAwait(false);
				return this.pipeClient.IsConnected;
			}
			catch (Exception ex)
			{
				// TODO: Better way for logging
				Debug.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return false;
			}
		}

		public async Task<StartResponseResult> SendStartRequest(StartRequestParams parameters, CancellationToken token = default)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			string methodName = $"{nameof(Kinect)}.{nameof(SendStartRequest)}";
			try
			{
				await SendStartRequestInternal(parameters, token).ConfigureAwait(false);
				var response = await GetStartResponseInternal(token).ConfigureAwait(false);
				if (response != null && response.IsSuccess)
				{
					StartListenTask(token);
				}
				return response;
			}
			catch (Exception ex)
			{
				// TODO: Better way for logging
				Debug.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return new StartResponseResult
				{
					IsSuccess = false,
				};
			}
		}

		public async Task<StopResponseResult> SendStopRequest(StopRequestParams parameters, CancellationToken token = default)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			string methodName = $"{nameof(Kinect)}.{nameof(SendStopRequest)}";
			try
			{
				await SendStopRequestInternal(parameters, token).ConfigureAwait(false);
				return await GetStopResponseInternal(token).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				// TODO: Better way for logging
				Debug.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return new StopResponseResult
				{
					IsSuccess = false,
				};
			}
		}

		public void Disconnect()
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(Disconnect)}";
			try
			{
				if (this.pipeClient.IsConnected)
				{
					this.pipeClient.Close();
					this.pipeClient.Dispose();
				}
			}
			catch (Exception ex)
			{
				// TODO: Better way for logging
				Debug.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}
		#endregion

		#region Private methods

		#region Start message methods
		private async Task SendStartRequestInternal(StartRequestParams parameters, CancellationToken token)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(SendStartRequestInternal)}";
			using (var ms = new MemoryStream())
			{
				using (var payloadWriter = new BinaryWriter(ms))
				{
					payloadWriter.Write((int)parameters.FrameSourceTypes);
					payloadWriter.Write((int)parameters.ColorImageFormat);
					payloadWriter.Write(parameters.IsOneBodyTrackingEnabled);
				}
				byte[] payload = ms.ToArray();
				var message = CreateMessage(MessageType.StartRequest, payload);

				await WriteMessage(methodName, this.pipeClient, message, token).ConfigureAwait(false);
			}
		}

		private async Task<StartResponseResult> GetStartResponseInternal(CancellationToken token)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(GetStartResponseInternal)}";
			var message = await ReadMessage(methodName, this.pipeClient, token).ConfigureAwait(false);
			if (message?.Header == null || message.Header.Type != MessageType.StartResponse ||
				message.Header.PayloadLength == 0 || message.Payload == null || message.Payload.Length != message.Header.PayloadLength)
			{
				return new StartResponseResult
				{
					IsSuccess = false
				};
			}

			using (var ms = new MemoryStream(message.Payload))
			{
				using (var payloadReader = new BinaryReader(ms))
				{
					var result = new StartResponseResult
					{
						IsSuccess = payloadReader.ReadBoolean(),
						ColorFrameWidth = payloadReader.ReadInt32(),
						ColorFrameHeight = payloadReader.ReadInt32(),
						KinectSensorIsAvailable = payloadReader.ReadBoolean()
					};
					return result;
				}
			}
		}
		#endregion

		#region Stop message methods
		private async Task SendStopRequestInternal(StopRequestParams parameters, CancellationToken token)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(SendStopRequestInternal)}";
			byte[] payload = new byte[0];
			var message = CreateMessage(MessageType.StopRequest, payload);

			await WriteMessage(methodName, this.pipeClient, message, token).ConfigureAwait(false);
		}

		private async Task<StopResponseResult> GetStopResponseInternal(CancellationToken token)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(GetStopResponseInternal)}";
			var message = await ReadMessage(methodName, this.pipeClient, token).ConfigureAwait(false);
			if (message?.Header == null || message.Header.Type != MessageType.StopRequest ||
				message.Header.PayloadLength == 0 || message.Payload == null || message.Payload.Length != message.Header.PayloadLength)
			{
				return new StopResponseResult
				{
					IsSuccess = false
				};
			}

			using (var ms = new MemoryStream(message.Payload))
			{
				using (var payloadReader = new BinaryReader(ms))
				{
					var result = new StopResponseResult
					{
						IsSuccess = payloadReader.ReadBoolean(),
					};
					return result;
				}
			}
		}
		#endregion

		#region Listening for messages methods
		private void StartListenTask(CancellationToken token)
		{
			Task.Run(() => Listen(token).ConfigureAwait(false), token);
		}

		private async Task Listen(CancellationToken token)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(Listen)}";
			while (this.IsConnected && !token.IsCancellationRequested)
			{
				var message = await ReadMessage(methodName, this.pipeClient, token).ConfigureAwait(false);
				if (message?.Header == null)
				{
					// TODO: Better way for logging
					Debug.WriteLine($"[{methodName}] Failed to read message.");
					continue;
				}

				var messageType = message.Header.Type;
				switch (messageType)
				{
					case MessageType.Frame:
						HandleFrameMessage(message);
						break;
					case MessageType.KinectIsAvailableChanged:
						HandleKinectIsAvailableChangedMessage(message);
						break;
					default:
						// TODO: Better way for logging
						Debug.WriteLine($"[{methodName}] Unexpected message type: {messageType}.");
						break;
				}
			}
		}
		#endregion

		#region Frame message methods
		private void HandleFrameMessage(Message message)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(HandleFrameMessage)}";
			if (message.Header.PayloadLength == 0 || message.Payload == null 
				|| message.Payload.Length != message.Header.PayloadLength)
			{
				Debug.WriteLine($"[{methodName}] Invalid payload.");
				return;
			}

			using (var ms = new MemoryStream(message.Payload))
			{
				using (var payloadReader = new BinaryReader(ms))
				{
					var data = new FrameData()
					{
						ColorFrame = ReadColorFrame(payloadReader),
						BodyFrame = ReadBodyFrame(payloadReader),
						BodiesJointsColorSpacePointsDict = ReadBodiesJointsColorSpacePointsDict(payloadReader)
					};
					OnFrameArrived?.Invoke(this, new FrameArrivedEventArgs(data));
				}
			}
		}

		private ColorFrame ReadColorFrame(BinaryReader payloadReader)
		{
			int width = payloadReader.ReadInt32();
			int height = payloadReader.ReadInt32();
			var rawColorImageFormat = (ColorImageFormat)payloadReader.ReadInt32();
			uint bytesPerPixel = payloadReader.ReadUInt32();
			uint lengthInPixels = payloadReader.ReadUInt32();
			var relativeTime = TimeSpan.FromTicks(payloadReader.ReadInt64());
			int colorDataLength = payloadReader.ReadInt32();
			byte[] colorData = new byte[colorDataLength];
			if (colorDataLength > 0)
				colorData = payloadReader.ReadBytes(colorDataLength);

			return new ColorFrame(width, height, rawColorImageFormat, bytesPerPixel, lengthInPixels, relativeTime,
				colorData);
		}

		private BodyFrame ReadBodyFrame(BinaryReader payloadReader)
		{
			var relativeTime = TimeSpan.FromTicks(payloadReader.ReadInt64());
			int bodiesCount = payloadReader.ReadInt32();
			bool tooMuchUsersForOneBodyTracking = payloadReader.ReadBoolean();

			if (tooMuchUsersForOneBodyTracking)
				return new BodyFrame(relativeTime, bodiesCount, tooMuchUsersForOneBodyTracking);

			var bodies = new List<BodyData>(bodiesCount);
			for (int i = 0; i < bodiesCount; i++)
			{
				var bodyData = ReadBodyData(payloadReader);
				bodies.Add(bodyData);
			}

			return new BodyFrame(relativeTime, bodies.ToArray());
		}

		private BodyData ReadBodyData(BinaryReader payloadReader)
		{
			ulong trackingId = payloadReader.ReadUInt64();
			bool isTracked = payloadReader.ReadBoolean();
			int jointsCount = payloadReader.ReadInt32();
			var joints = new Dictionary<JointType, Joint>();
			for (int i = 0; i < jointsCount; i++)
			{
				var joint = ReadJoint(payloadReader);
				joints[joint.JointType] = joint;
			}
			var handLeftState = (HandState)payloadReader.ReadInt32();
			var handLeftConfidence = (TrackingConfidence)payloadReader.ReadInt32();
			var handRightState = (HandState)payloadReader.ReadInt32();
			var handRightConfidence = (TrackingConfidence)payloadReader.ReadInt32();

			return new BodyData(trackingId, isTracked, joints, handLeftState, handLeftConfidence,
				handRightState, handRightConfidence);
		}

		private Joint ReadJoint(BinaryReader payloadReader)
		{
			var jointType = (JointType)payloadReader.ReadInt32();
			var position = new Vector3
			{
				X = payloadReader.ReadSingle(),
				Y = payloadReader.ReadSingle(),
				Z = payloadReader.ReadSingle()
			};
			var trackingState = (TrackingState)payloadReader.ReadInt32();

			return new Joint(jointType, position, trackingState);
		}

		private IDictionary<ulong, BodyJointsColorSpacePointsDict> ReadBodiesJointsColorSpacePointsDict(BinaryReader payloadReader)
		{
			var result = new Dictionary<ulong, BodyJointsColorSpacePointsDict>();
			
			int bodiesCount = payloadReader.ReadInt32();
			for (int i = 0; i < bodiesCount; i++)
			{
				ulong trackingId = payloadReader.ReadUInt64();
				int jointsCount = payloadReader.ReadInt32();
				var jointsColorSpacePoints = new BodyJointsColorSpacePointsDict();
				for (int j = 0; j < jointsCount; j++)
				{
					var jointType = (JointType)payloadReader.ReadInt32();
					float x = payloadReader.ReadSingle();
					float y = payloadReader.ReadSingle();
					jointsColorSpacePoints[jointType] = new Vector2(x, y);
				}
				result[trackingId] = jointsColorSpacePoints;
			}

			return result;
		}
		#endregion

		#region KinectIsAvailableChanged message methods
		private void HandleKinectIsAvailableChangedMessage(Message message)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(HandleKinectIsAvailableChangedMessage)}";
			if (message.Header.PayloadLength == 0 || message.Payload == null 
				|| message.Payload.Length != message.Header.PayloadLength)
			{
				Debug.WriteLine($"[{methodName}] Invalid payload.");
				return;
			}

			using (var ms = new MemoryStream(message.Payload))
			{
				using (var reader = new BinaryReader(ms))
				{
					bool isAvailable = reader.ReadBoolean();
					var data = new KinectIsAvailableChangedData()
					{
						IsAvailable = isAvailable
					};
					OnKinectIsAvailableChanged?.Invoke(this, new KinectIsAvailableChangedEventArgs(data));
				}
			}
		}
		#endregion

		#endregion
	}
}
