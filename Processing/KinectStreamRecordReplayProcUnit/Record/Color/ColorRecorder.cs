using System;
using System.IO;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Color
{
	internal class ColorRecorder
	{
		#region Private fields
		private DateTime referenceTime;
		private readonly BinaryWriter writer;
		#endregion

		#region Constructors
		internal ColorRecorder(BinaryWriter writer)
		{
			this.writer = writer;
			this.referenceTime = DateTime.Now;
		}
		#endregion

		#region Public methods
		public void Record(ColorFrame frame, ColorImageFormat destinationFormat = ColorImageFormat.Bgra)
		{
			if (frame == null)
				throw new ArgumentNullException(nameof(frame));
			if (frame.FrameDescription == null)
				throw new ArgumentNullException(nameof(frame.FrameDescription));

			var frameDescription = frame.FrameDescription;
			bool isNecessaryToConvert = frame.RawColorImageFormat != destinationFormat;
			uint bytesPerPixel = isNecessaryToConvert ? GetBytesPerPixel(destinationFormat) : frameDescription.BytesPerPixel;

			// Header
			this.writer.Write((int)KinectRecordOptions.Color);

			// Data
			var timeSpan = DateTime.Now.Subtract(referenceTime);
			this.referenceTime = DateTime.Now;
			this.writer.Write((long)timeSpan.TotalMilliseconds);
			this.writer.Write(bytesPerPixel);
			this.writer.Write((int)destinationFormat);
			this.writer.Write(frameDescription.Width);
			this.writer.Write(frameDescription.Height);

			// Bytes
			this.writer.Write(frameDescription.LengthInPixels);
			byte[] bytes = new byte[frameDescription.LengthInPixels * bytesPerPixel];
			if (isNecessaryToConvert)
				frame.CopyConvertedFrameDataToArray(bytes, destinationFormat);
			else
				frame.CopyRawFrameDataToArray(bytes);
			this.writer.Write(bytes);
		}
		#endregion

		#region Private methods
		private uint GetBytesPerPixel(ColorImageFormat format)
		{
			switch (format)
			{
				case ColorImageFormat.Rgba:
					return 4;
				case ColorImageFormat.Yuv:
					return 2;
				case ColorImageFormat.Bgra:
					return 4;
				case ColorImageFormat.Bayer:
					return 1;
				case ColorImageFormat.Yuy2:
					return 2;
			}

			return 0;
		}
		#endregion
	}
}
