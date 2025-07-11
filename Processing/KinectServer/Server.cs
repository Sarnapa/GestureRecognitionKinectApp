using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.KinectServer.Kinect;
using GestureRecognition.Processing.KinectServer.Kinect.Events;

namespace GestureRecognition.Processing.KinectServer
{
	internal class Server
	{
		#region Private fields
		private bool isRunning = true;
		private readonly KinectManager kinectManager;
		private readonly NamedPipeServerStream pipeServer;
		#endregion

		#region Constructors
		public Server(KinectManager kinectManager)
		{
			if (kinectManager == null)
				throw new ArgumentNullException(nameof(kinectManager));

			this.kinectManager = kinectManager;
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
				Console.WriteLine($"[{methodName}] Waiting for client...");
				await this.pipeServer.WaitForConnectionAsync();
				Console.WriteLine($"[{methodName}] Client connected.");

				AttachKinectManagerEventsHandlers();
				this.isRunning = true;
				return this.pipeServer.IsConnected;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return false;
			}
		}

		public void Listen()
		{
			string methodName = $"{nameof(Server)}.{nameof(Listen)}";
			using (var pipeServerReader = new BinaryReader(this.pipeServer))
			using (var pipeServerWriter = new BinaryWriter(this.pipeServer))
			{
				Console.WriteLine($"[{methodName}] Listening for messages from the client has started.");
				while (this.isRunning)
				{
					try
					{
						var messageType = (MessageType)pipeServerReader.ReadInt32();
						switch (messageType)
						{
							case MessageType.StartRequest:
								HandleStartRequest(pipeServerReader, pipeServerWriter);
								break;
							case MessageType.StopRequest:
								this.isRunning = false;
								break;
							default:
								Console.WriteLine($"[{methodName}] Unexpected message type: {messageType}.");
								break;
						}
					}
					catch (EndOfStreamException)
					{
						Console.WriteLine($"[{methodName}] Client disconnected.");
						break;
					}
					catch (Exception ex)
					{
						Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
					}
				}
			}
		}

		public void Cleanup()
		{
			this.DetachKinectManagerEventsHandlers();
			this.pipeServer.Close();
			this.pipeServer.Dispose();
			this.isRunning = false;
		}
		#endregion

		#region Private methods

		#region Start and Stop requests handling methods
		private void HandleStartRequest(BinaryReader pipeServerReader, BinaryWriter pipeServerWriter)
		{
			string methodName = $"{nameof(Server)}.{nameof(HandleStartRequest)}";
			try
			{
				Console.WriteLine($"[{methodName}] Received Start request.");
				var parameters = new StartRequestParams
				{
					FrameSourceTypes = (FrameSourceTypes)pipeServerReader.ReadInt32(),
					ColorImageFormat = (ColorImageFormat)pipeServerReader.ReadInt32(),
					IsOneBodyTrackingEnabled = pipeServerReader.ReadBoolean()
				};
				Console.WriteLine($"[{methodName}] Start request parameters:\n{parameters}");

				var result = this.kinectManager.Start(parameters);
				Console.WriteLine($"[{methodName}] Start request result:\n{result}");

				SendStartResponse(pipeServerWriter, result);
				Console.WriteLine($"[{methodName}] Start response sent.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void SendStartResponse(BinaryWriter pipeServerWriter, StartResponseResult result)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendStartResponse)}";
			try
			{
				pipeServerWriter.Write((int)MessageType.StartResponse);
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						payloadWriter.Write(result?.IsSuccess ?? false);
						payloadWriter.Write(result?.ColorFrameWidth ?? 0);
						payloadWriter.Write(result?.ColorFrameHeight ?? 0);
						payloadWriter.Write(result?.KinectSensorIsAvailable ?? false);
					}

					SendPayload(pipeServerWriter, ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void HandleStopRequest(BinaryReader pipeServerReader, BinaryWriter pipeServerWriter)
		{
			string methodName = $"{nameof(Server)}.{nameof(HandleStopRequest)}";
			try
			{
				var parameters = new StopRequestParams();
				Console.WriteLine($"[{methodName}] Stop request parameters:\n{parameters}");

				var result = this.kinectManager.Stop(parameters);
				Console.WriteLine($"[{methodName}] Stop request result:\n{result}");

				SendStopResponse(pipeServerWriter, result);
				Console.WriteLine($"[{methodName}] Stop response sent.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void SendStopResponse(BinaryWriter pipeServerWriter, StopResponseResult result)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendStopResponse)}";
			try
			{
				pipeServerWriter.Write((int)MessageType.StopResponse);
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						payloadWriter.Write(result?.IsSuccess ?? false);
					}

					SendPayload(pipeServerWriter, ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}
		#endregion

		#region Arrived frame handling methods
		private void KinectManager_OnFrameArrived(object sender, FrameArrivedEventArgs e)
		{
			string methodName = $"{nameof(Server)}.{nameof(KinectManager_OnFrameArrived)}";
			try
			{
				using (var pipeServerWriter = new BinaryWriter(this.pipeServer))
				{
					SendFrameDataMessage(pipeServerWriter, e?.Data);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void SendFrameDataMessage(BinaryWriter pipeServerWriter, FrameData data)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendFrameDataMessage)}";
			try
			{
				// It is controlled in the KinectManager to send frames when it makes sense, but just in case.
				var colorFrame = data?.ColorFrame ?? new ColorFrame();
				var bodyFrame = data?.BodyFrame ?? new BodyFrame();
				var bodiesJointsColorSpacePointsDict =  data?.BodiesJointsColorSpacePointsDict ?? new Dictionary<ulong, BodyJointsColorSpacePointsDict>();

				pipeServerWriter.Write((int)MessageType.Frame);
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						WriteColorFrame(payloadWriter, colorFrame);
						WriteBodyFrame(payloadWriter, bodyFrame);
						WriteBodiesJointsColorSpacePointsDict(payloadWriter, bodiesJointsColorSpacePointsDict);
					}

					SendPayload(pipeServerWriter, ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
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
			foreach (var body in bodyFrame.Bodies)
			{
				WriteBodyData(payloadWriter, body);
			}
			payloadWriter.Write(bodyFrame.TooMuchUsersForOneBodyTracking);
		}

		private void WriteBodyData(BinaryWriter payloadWriter, BodyData bodyData)
		{
			payloadWriter.Write(bodyData.TrackingId);
			payloadWriter.Write(bodyData.IsTracked);
			payloadWriter.Write(bodyData.Joints.Count);
			foreach (var jointPair in bodyData.Joints)
			{
				WriteJoint(payloadWriter, jointPair.Value, jointPair.Key);
			}
			payloadWriter.Write((int)bodyData.HandLeftState);
			payloadWriter.Write((int)bodyData.HandLeftConfidence);
			payloadWriter.Write((int)bodyData.HandRightState);
			payloadWriter.Write((int)bodyData.HandRightConfidence);
		}

		private void WriteJoint(BinaryWriter payloadWriter, Joint joint, JointType jointType)
		{
			payloadWriter.Write((int)jointType);
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
		private void KinectManager_OnKinectIsAvailableChanged(object sender, KinectIsAvailableChangedEventArgs e)
		{
			string methodName = $"{nameof(Server)}.{nameof(KinectManager_OnKinectIsAvailableChanged)}";
			try
			{
				using (var pipeServerWriter = new BinaryWriter(this.pipeServer))
				{
					SendKinectIsAvailableChangedMessage(pipeServerWriter, e?.Data);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}

		private void SendKinectIsAvailableChangedMessage(BinaryWriter pipeServerWriter, KinectIsAvailableChangedData data)
		{
			string methodName = $"{nameof(Server)}.{nameof(SendKinectIsAvailableChangedMessage)}";
			try
			{
				pipeServerWriter.Write((int)MessageType.SensorIsAvailableChanged);
				using (var ms = new MemoryStream())
				{
					using (var payloadWriter = new BinaryWriter(ms))
					{
						payloadWriter.Write(data?.IsAvailable ?? false);
					}

					SendPayload(pipeServerWriter, ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
			}
		}
		#endregion

		#region Other private methods
		private void SendPayload(BinaryWriter pipeServerWriter, byte[] payload)
		{
			pipeServerWriter.Write(payload.Length);
			pipeServerWriter.Write(payload);
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
