using System;
using System.Threading.Tasks;
using GestureRecognition.Processing.KinectServer.Kinect;

namespace GestureRecognition.Processing.KinectServer
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			string methodName = $"{nameof(Main)}";
			var kinectManager = new KinectManager();
			var server = new Server(kinectManager);
			
			bool startSuccess = await server.Start();
			if (startSuccess)
				server.Listen();
			else
				Console.WriteLine($"[{methodName}] Failed to start the server.");

			server.Cleanup();
			Console.WriteLine($"[{methodName}] The server has terminated.");
		}
	}

}
