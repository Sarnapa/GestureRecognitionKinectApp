using System;
using GestureRecognition.Applications.GestureRecordsServiceNetFrameworkConsoleApp.Serialization;

namespace GestureRecognition.Applications.GestureRecordsServiceNetFrameworkConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string methodName = $"{nameof(Main)}";
			Console.WriteLine($"[{methodName}][{DateTime.Now}] Starting GestureRecordsServiceNetFrameworkConsoleApp...");

			// For testing purposes
			//args = new string[]
			//{
			//	ArgumentsConsts.SERIALIZATION_MODE_DIRECTORY,
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Yes\OldData\2025_02_02",
			//	@"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Yes\2025_08_07\"
			//};

			if (args.Length < 3)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid arguments count - given: {args.Length}, expected: 3.");
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.");
				Console.ReadKey();
				return;
			}

			string mode = args[0];
			string inputPath = args[1];
			string outputPath = args[2];

			SerializationMode? serializationMode = null;
			if (mode.Equals(ArgumentsConsts.SERIALIZATION_MODE_FILE, StringComparison.OrdinalIgnoreCase))
			{
				serializationMode = SerializationMode.File;
			}
			else if (mode.Equals(ArgumentsConsts.SERIALIZATION_MODE_DIRECTORY, StringComparison.OrdinalIgnoreCase))
			{
				serializationMode = SerializationMode.Directory;
			}
			else
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Invalid serialization mode argument - given: {mode}, expected: {ArgumentsConsts.SERIALIZATION_MODE_FILE} or {ArgumentsConsts.SERIALIZATION_MODE_DIRECTORY}.");
			}

			if (serializationMode.HasValue)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Initializing {nameof(MessagePackSerializationManager)}.\n" +
					$"Input parameters:\n" +
					$"Mode: {serializationMode.Value}\n" +
					$"Input file: {inputPath}\n" +
					$"Output file: {outputPath}\n");
				var serializationManager = new MessagePackSerializationManager(serializationMode.Value, inputPath, outputPath);
				serializationManager.ExecuteReserializationProcess();
			}

			Console.WriteLine($"[{methodName}][{DateTime.Now}] Press key to close console app.");
			Console.ReadKey();
		}
	}
}
