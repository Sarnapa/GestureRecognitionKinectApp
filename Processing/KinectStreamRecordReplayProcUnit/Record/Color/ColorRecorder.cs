using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Color
{
	internal class ColorRecorder
	{
		#region Private fields
		private DateTime referenceTime;
		private readonly float resizingCoef = 1.0f;
		private readonly BinaryWriter writer;
		#endregion

		#region Constructors
		internal ColorRecorder(BinaryWriter writer, float resizingCoef)
		{
			this.writer = writer;
			this.resizingCoef = resizingCoef;
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
			int frameWidth = frameDescription.Width;
			int frameHeight = frameDescription.Height;
			uint frameLengthInPixels = frameDescription.LengthInPixels;

			byte[] bytes = new byte[frameDescription.LengthInPixels * bytesPerPixel];
			if (isNecessaryToConvert)
				frame.CopyConvertedFrameDataToArray(bytes, destinationFormat);
			else
				frame.CopyRawFrameDataToArray(bytes);
			
			// TODO: Remove this limit concerning color image format
			if (this.resizingCoef != 1.0f && destinationFormat == ColorImageFormat.Bgra)
			{
				int stride = frameWidth * Convert.ToInt32(bytesPerPixel);
				var bitmap = BitmapSource.Create(frameWidth, frameHeight, 96, 96, PixelFormats.Bgra32, null, bytes, stride);
				var scale = new ScaleTransform(this.resizingCoef, this.resizingCoef);
				var tbBitmap = new TransformedBitmap(bitmap, scale);

				frameWidth = tbBitmap.PixelWidth;
				frameHeight = tbBitmap.PixelHeight;
				frameLengthInPixels = (uint)(frameWidth * frameHeight);
				byte[] newBytes = new byte[frameLengthInPixels * bytesPerPixel];
				tbBitmap.CopyPixels(newBytes, frameWidth * Convert.ToInt32(bytesPerPixel), 0);
				bytes = newBytes;
			}

			// Header
			this.writer.Write((int)KinectRecordOptions.Color);

			// Data
			var timeSpan = DateTime.Now.Subtract(referenceTime);
			this.referenceTime = DateTime.Now;
			this.writer.Write((long)timeSpan.TotalMilliseconds);
			this.writer.Write(bytesPerPixel);
			this.writer.Write((int)destinationFormat);
			this.writer.Write(frameWidth);
			this.writer.Write(frameHeight);
			this.writer.Write(frameLengthInPixels);

			// Bytes
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
