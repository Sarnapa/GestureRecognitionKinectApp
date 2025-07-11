using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Windows;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Kinect
{
	public class KinectClient
	{
		#region Private fields
		private readonly NamedPipeServerStream pipeServer;
		#endregion

		#region Public properties
		public bool IsConnected
		{
			get
			{
				return this.pipeServer != null && this.pipeServer.IsConnected;
			}
		}
		#endregion

		#region Constructors
		public KinectClient()
		{
			this.pipeServer = new NamedPipeServerStream(Consts.PipeName, PipeDirection.InOut, 1,
				PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
		}
		#endregion

		#region Public methods
		public async Task<bool> Connect()
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(Connect)}";
			try
			{
				await this.pipeServer.WaitForConnectionAsync();
				return this.pipeServer.IsConnected;
			}
			catch (Exception ex)
			{
				// TODO: Log the exception
				return false;
			}
		}

		public void Disconnect()
		{
			string methodName = $"{nameof(KinectClient)}.{nameof(Disconnect)}";
			try
			{
				if (this.pipeServer.IsConnected)
				{
					this.pipeServer.Close();
					this.pipeServer.Dispose();
				}
			}
			catch (Exception ex)
			{
				// TODO: Log the exception
			}
		}
		#endregion

		#region Private methods
		#endregion
	}
}
