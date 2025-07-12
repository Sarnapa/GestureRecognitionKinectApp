using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;
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
				// TODO: Better way to log the exception
				Debug.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
				return false;
			}
		}

		public async Task<bool> Connect(int timeout = 60000, CancellationToken cancellationToken = default)
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(Connect)}";
			try
			{
				await this.pipeClient.ConnectAsync(timeout, cancellationToken);
				return this.pipeClient.IsConnected;
			}
			catch (Exception ex)
			{
				// TODO: Better way to log the exception
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
				return await GetStartResponseInternal(token).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
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
				Console.WriteLine($"[{methodName}] Exception type: {ex.GetType()}, exception message: {ex.Message}.");
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
				// TODO: Better way to log the exception
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

		#region Frame message methods
		#endregion

		#region KinectIsAvailableChanged message methods
		#endregion

		#region Other private methods
		#endregion

		#endregion
	}
}
