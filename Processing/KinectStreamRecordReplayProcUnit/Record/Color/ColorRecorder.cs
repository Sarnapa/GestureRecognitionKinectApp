using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

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
		public void Record(ColorFrame frame)
		{
			if (frame == null)
				throw new ArgumentNullException(nameof(frame));

			int frameWidth = frame.Width;
			int frameHeight = frame.Height;
			var imageFormat = frame.RawColorImageFormat;
			uint bytesPerPixel = frame.BytesPerPixel;
			uint frameLengthInPixels = frame.LengthInPixels;
			byte[] bytes = frame.ColorData;
			
			// TODO: Remove this limit concerning color image format
			if (this.resizingCoef != 1.0f && imageFormat == ColorImageFormat.Bgra)
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
			this.writer.Write((int)RecordOptions.Color);

			// Data
			var timeSpan = DateTime.Now.Subtract(referenceTime);
			this.referenceTime = DateTime.Now;
			this.writer.Write((long)timeSpan.TotalMilliseconds);
			this.writer.Write(bytesPerPixel);
			this.writer.Write((int)imageFormat);
			this.writer.Write(frameWidth);
			this.writer.Write(frameHeight);
			this.writer.Write(frameLengthInPixels);

			// Bytes
			this.writer.Write(bytes);
		}
		#endregion
	}
}
