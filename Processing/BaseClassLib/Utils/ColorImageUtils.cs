using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

namespace GestureRecognition.Processing.BaseClassLib.Utils
{
	public static class ColorImageUtils
	{
		public static uint GetBytesPerPixel(ColorImageFormat format)
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
	}
}
