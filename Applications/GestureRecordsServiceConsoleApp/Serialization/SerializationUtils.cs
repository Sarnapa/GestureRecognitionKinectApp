using MessagePack;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp.Serialization
{
	internal static class SerializationUtils
	{
		#region Read methods
		public static ColorFrame ReadColorFrame(BinaryReader reader)
		{
			var relativeTime = TimeSpan.FromTicks(reader.ReadInt64());
			uint bytesPerPixel = reader.ReadUInt32();
			var imageFormat = (ColorImageFormat)reader.ReadInt32();
			int width = reader.ReadInt32();
			int height = reader.ReadInt32();
			uint lengthInPixels = reader.ReadUInt32();

			uint bytesCount = lengthInPixels * bytesPerPixel;
			byte[] colorData = reader.ReadBytes((int)bytesCount);

			return new ColorFrame(width, height, imageFormat, bytesPerPixel, lengthInPixels, relativeTime, colorData);
		}

		public static void SkipColorFrame(BinaryReader reader)
		{
			// Skipping relativeTime
			reader.BaseStream.Position += 8;
			uint bytesPerPixel = reader.ReadUInt32();
			// Skipping imageFormat, width, height
			reader.BaseStream.Position += 12;
			uint lengthInPixels = reader.ReadUInt32();

			// Skipping colorData
			uint bytesCount = lengthInPixels * bytesPerPixel;
			reader.BaseStream.Position += bytesCount;
		}

		public static BodyFrame ReadBodyFrame(BinaryReader reader, MessagePackSerializerOptions serializerOptions)
		{
			var relativeTime = TimeSpan.FromTicks(reader.ReadInt64());

			BodyDataWithColorSpacePoints[] bodiesData;
			if (serializerOptions == null)
				bodiesData = MessagePackSerializer.Deserialize<BodyDataWithColorSpacePoints[]>(reader.BaseStream);
			else
				bodiesData = MessagePackSerializer.Deserialize<BodyDataWithColorSpacePoints[]>(reader.BaseStream, serializerOptions);

			return new BodyFrame(relativeTime, bodiesData);
		}
		#endregion

		#region Write methods
		public static void WriteColorFrame(BinaryWriter writer, ColorFrame frame)
		{
			writer.Write((int)RecordOptions.Color);

			writer.Write(frame.RelativeTime.Ticks);
			writer.Write(frame.BytesPerPixel);
			writer.Write((int)frame.RawColorImageFormat);
			writer.Write(frame.Width);
			writer.Write(frame.Height);
			writer.Write(frame.LengthInPixels);

			writer.Write(frame.ColorData);
		}

		public static void WriteBodyFrame(BinaryWriter writer, BodyFrame frame, MessagePackSerializerOptions serializerOptions)
		{
			writer.Write((int)RecordOptions.Bodies);
			writer.Write(frame.RelativeTime.Ticks);

			var bodiesData = frame.Bodies?.Cast<BodyDataWithColorSpacePoints>().ToArray() ?? [];
			byte[] bodiesDataBytes;
			if (serializerOptions == null)
				bodiesDataBytes = MessagePackSerializer.Serialize(bodiesData);
			else
				bodiesDataBytes = MessagePackSerializer.Serialize(bodiesData, serializerOptions);
			writer.Write(bodiesDataBytes);
		}
		#endregion
	}
}
