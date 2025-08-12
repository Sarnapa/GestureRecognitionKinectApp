namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp
{
	internal class ConsoleOutputUtils
	{
		#region Public methods
		public static void WriteLine(string methodName, string message)
		{
			Console.WriteLine($"[{methodName}][{DateTime.Now}] {message}\n");
		}
		#endregion
	}
}
