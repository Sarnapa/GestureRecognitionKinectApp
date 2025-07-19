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

			while (server.IsRunning)
			{
				bool startSuccess = server.Start().GetAwaiter().GetResult();
				if (startSuccess)
					server.Listen().GetAwaiter().GetResult();
				else
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Failed to start the server.");
					break;
				}
			}

			Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.");
			Console.ReadKey();
		}
	}

}
