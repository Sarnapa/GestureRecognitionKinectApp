using System;
using System.Threading;
using System.Threading.Tasks;
using GestureRecognition.Processing.KinectServer.Kinect;

namespace GestureRecognition.Processing.KinectServer
{
	public class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			string methodName = $"{nameof(Main)}";
			var server = new Server();
			
			//bool initializeKinectManagerSuccess = server.InitializeKinectManager();
			//if (initializeKinectManagerSuccess)
			{
				// bool startSuccess = await server.Start().ConfigureAwait(false);
				bool startSuccess = server.Start().GetAwaiter().GetResult();
				if (startSuccess)
					//server.StartListenTask().ContinueWith(_ => 
					//{
					//	Console.WriteLine($"[{methodName}][{DateTime.Now}] The server has terminated.");
					//	Console.ReadKey();
					//});
					server.Listen(cleanup: false).GetAwaiter().GetResult();
				//await server.Listen(cleanup: false).ConfigureAwait(false);
				else
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Failed to start the server.");
			}
			//else
			//	Console.WriteLine($"[{methodName}][{DateTime.Now}] Failed to initialize Kinect environment.");

			server.Cleanup();
			Console.ReadKey();
		}
	}

}
