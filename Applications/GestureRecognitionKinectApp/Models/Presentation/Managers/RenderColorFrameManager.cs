using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Color;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers
{
	public class RenderColorFrameManager
	{
		#region Constructors
		public RenderColorFrameManager()
		{}
		#endregion

		#region Public methods
		public void ProcessColorFrame(ColorFrame colorFrame, int frameWidth, int frameHeight, ref WriteableBitmap colorImage)
		{
			if (colorFrame == null)
				throw new ArgumentNullException(nameof(colorFrame));
			if (colorImage == null)
				throw new ArgumentNullException(nameof(colorImage));

			// Verify data and write the new color frame data to the display bitmap
			if ((colorFrame.Width == frameWidth) && (colorFrame.Height == frameHeight))
			{
				colorImage.Lock();
				try
				{
					var rect = new Int32Rect(0, 0, frameWidth, frameHeight);
					int stride = frameWidth * Convert.ToInt32(colorFrame.BytesPerPixel);
					colorImage.WritePixels(rect, colorFrame.ColorData, stride, 0);
				}
				finally
				{
					colorImage.AddDirtyRect(new Int32Rect(0, 0, frameWidth, frameHeight));
					colorImage.Unlock();
				}
			}
			else
			{
				// TODO: Throw exception
			}
		}

		public void ProcessColorFrame(ReplayColorFrame colorFrame, ref WriteableBitmap colorImage)
		{
			if (colorFrame == null)
				throw new ArgumentNullException(nameof(colorFrame));
			if (colorFrame.RawColorImageFormat != ColorImageFormat.Bgra)
				throw new ArgumentException(nameof(colorFrame));

			int frameWidth = colorFrame.Width;
			int frameHeight = colorFrame.Height;
			uint frameBytesPerPixel = colorFrame.BytesPerPixel;

			if (colorImage == null)
				colorImage = new WriteableBitmap(frameWidth, frameHeight, 96, 96, Map(colorFrame.RawColorImageFormat), null);

			if (colorImage.PixelWidth == frameWidth && colorImage.PixelHeight == frameHeight)
			{
				byte[] data = new byte[colorFrame.LengthInPixels * colorFrame.BytesPerPixel];
				colorFrame.CopyPixelDataTo(data);

				int stride = (int)(frameWidth * frameBytesPerPixel);
				var dirtyRect = new Int32Rect(0, 0, frameWidth, frameHeight);
				colorImage.WritePixels(dirtyRect, data, stride, 0);
			}
			else
			{
				// TODO: Throw exception
			}
		}
		#endregion

		#region Private methods
		private static PixelFormat Map(ColorImageFormat format)
		{
			switch (format)
			{
				case ColorImageFormat.Bgra:
					return PixelFormats.Bgra32;
			}

			return PixelFormats.Default;
		}
		#endregion
	}
}
