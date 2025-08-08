using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using MessagePack;
using GestureRecognition.Processing.BaseClassLib.Serialization.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using OldStructures = GestureRecognition.Processing.BaseClassLib.Structures.Kinect;

namespace GestureRecognition.Applications.GestureRecordsServiceNetFrameworkConsoleApp.Serialization
{
	internal class MessagePackSerializationManager
	{
		#region Private fields
		private readonly SerializationMode mode;
		private readonly string inputFilePath;
		private readonly string outputFilePath;
		private readonly MessagePackSerializerOptions serializerOptions;
		private DateTime previousFlushDate;
		#endregion

		#region Constructors
		public MessagePackSerializationManager(SerializationMode mode, string inputFilePath, string outputFilePath)
		{
			this.mode = mode;
			this.inputFilePath = inputFilePath;
			this.outputFilePath = outputFilePath;
			this.serializerOptions = MessagePackSerializerOptions.Standard.WithResolver(BodyDataResolver.Instance);
		}
		#endregion

		#region Public methods
		public void ExecuteReserializationProcess()
		{
			string methodName = $"{nameof(MessagePackSerializationManager)}.{nameof(ExecuteReserializationProcess)}";

			if (string.IsNullOrEmpty(this.inputFilePath) || 
				(this.mode == SerializationMode.File && !File.Exists(this.inputFilePath)) || 
				(this.mode == SerializationMode.Directory && !Directory.Exists(this.inputFilePath)))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Input file path is empty or file does not exist: {this.inputFilePath}.");
				return;
			}

			if (string.IsNullOrEmpty(this.outputFilePath) ||
				(this.mode == SerializationMode.File && !this.outputFilePath.EndsWith(".record")))
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Output file path is empty or invalid format: {this.outputFilePath}.");
				return;
			}

			try
			{
				if (this.mode == SerializationMode.File)
				{
					ProcessFile(this.inputFilePath, this.outputFilePath);
				}
				else if (this.mode == SerializationMode.Directory)
				{
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing directory started - input directory: {this.inputFilePath}, output directory: {this.outputFilePath}.");
					string[] inputFiles = Directory.GetFiles(this.inputFilePath, "*.record");

					foreach (string inputFile in inputFiles)
					{
						string outputFile = Path.Combine(this.outputFilePath, Path.GetFileName(inputFile));
						ProcessFile(inputFile, outputFile);
					}
					Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing directory finished - input directory: {this.inputFilePath}, output directory: {this.outputFilePath}.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
			}
		}
		#endregion

		#region Private methods
		private void ProcessFile(string inputFilePath, string outputFilePath)
		{
			string methodName = $"{nameof(MessagePackSerializationManager)}.{nameof(ProcessFile)}";
			try
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing file started - input file: {inputFilePath}, output file: {outputFilePath}.");
				using (var inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
				using (var outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
				using (var reader = new BinaryReader(inputStream))
				using (var writer = new BinaryWriter(outputStream))
				{
					this.previousFlushDate = DateTime.Now;
					ProcessFile(reader, writer);
				}
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Processing file finished - input file: {inputFilePath}, output file: {outputFilePath}.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
			}
		}

		private void ProcessFile(BinaryReader reader, BinaryWriter writer)
		{
			string methodName = $"{nameof(MessagePackSerializationManager)}.{nameof(ProcessFile)}";

			RecordOptions? header = null;
			try
			{
				var options = (RecordOptions)reader.ReadInt32();
				Console.WriteLine($"[{methodName}][{DateTime.Now}] Record options: {options}.");
				writer.Write((int)options);
				writer.Write((byte)BodyTrackingMode.Kinect);

				while (reader.BaseStream.Position != reader.BaseStream.Length)
				{
					header = (RecordOptions)reader.ReadInt32();
					switch (header)
					{
						case RecordOptions.Color:
							var colorFrame = ReadColorFrame(reader);
							WriteColorFrame(writer, colorFrame);
							Flush(writer);
							break;
						case RecordOptions.Bodies:
							var bodyFrame = ReadBodyFrame(reader);
							WriteBodyFrame(writer, bodyFrame);
							Flush(writer);
							break;
					}
				}
			}
			catch (Exception ex)
			{
				string headerValue = header.HasValue ? header.Value.ToString() : "null";
				Console.WriteLine($"[{methodName}][Current frame kind: {headerValue}][{DateTime.Now}] Exception type: {ex.GetType()}, exception message: {ex.Message}");
			}
		}

		#region Read methods
		private ColorFrame ReadColorFrame(BinaryReader reader)
		{
			var relativeTime = TimeSpan.FromMilliseconds(reader.ReadInt64());
			uint bytesPerPixel = reader.ReadUInt32();
			var imageFormat = (ColorImageFormat)reader.ReadInt32();
			int width = reader.ReadInt32();
			int height = reader.ReadInt32();
			uint lengthInPixels = reader.ReadUInt32();

			uint bytesCount = lengthInPixels * bytesPerPixel;
			byte[] colorData = reader.ReadBytes((int)bytesCount);

			return new ColorFrame(width, height, imageFormat, bytesPerPixel, lengthInPixels, relativeTime, colorData);
		}

		private BodyFrame ReadBodyFrame(BinaryReader reader)
		{
			var relativeTime = TimeSpan.FromMilliseconds(reader.ReadInt64());
			
			var formatter = new BinaryFormatter();
			var bodiesData = (OldStructures.BodyDataWithColorSpacePoints[])formatter.Deserialize(reader.BaseStream);
			return new BodyFrame(relativeTime, bodiesData?.Map());
		}
		#endregion

		#region Write methods
		private void WriteColorFrame(BinaryWriter writer, ColorFrame frame)
		{
			writer.Write((int)RecordOptions.Color);

			// Switch from milliseconds to ticks
			writer.Write(frame.RelativeTime.Ticks);
			writer.Write(frame.BytesPerPixel);
			writer.Write((int)frame.RawColorImageFormat);
			writer.Write(frame.Width);
			writer.Write(frame.Height);
			writer.Write(frame.LengthInPixels);

			writer.Write(frame.ColorData);
		}

		private void WriteBodyFrame(BinaryWriter writer, BodyFrame frame)
		{
			writer.Write((int)RecordOptions.Bodies);

			// Switch from milliseconds to ticks
			writer.Write(frame.RelativeTime.Ticks);

			var bodiesData = frame.Bodies?.Cast<BodyDataWithColorSpacePoints>().ToArray() ?? new BodyDataWithColorSpacePoints[0];
			byte[] bodiesDataBytes = MessagePackSerializer.Serialize(bodiesData, this.serializerOptions);
			writer.Write(bodiesDataBytes);
		}
		#endregion

		#region Other private methods
		private void Flush(BinaryWriter writer)
		{
			var now = DateTime.Now;

			if (now.Subtract(this.previousFlushDate).TotalSeconds > 60)
			{
				this.previousFlushDate = now;
				writer.Flush();
			}
		}
		#endregion

		#endregion
	}
}
