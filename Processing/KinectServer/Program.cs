using System;

namespace GestureRecognition.Processing.KinectServer
{
	public class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			string methodName = $"{nameof(Main)}";
			var server = new Server();
			
			bool startSuccess = server.Start().GetAwaiter().GetResult();
			if (startSuccess)
				server.Listen(cleanup: false).GetAwaiter().GetResult();
			else
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Failed to start the server.");

			server.Cleanup();
			Console.ReadKey();
		}
	}

}
