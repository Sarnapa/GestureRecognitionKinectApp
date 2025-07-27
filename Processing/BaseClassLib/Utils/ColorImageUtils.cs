using System;
using System.IO;
using SkiaSharp;
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

		public static byte[] LoadPngAsBgra(string filePath, out int width, out int height)
		{
			using (var stream = File.OpenRead(filePath))
			{
				using (var skImage = SKBitmap.Decode(stream))
				{
					width = skImage.Width;
					height = skImage.Height;

					using (var converted = skImage.Copy(SKColorType.Bgra8888))
					{
						int byteCount = width * height * 4;
						byte[] bgraBytes = new byte[byteCount];

						System.Runtime.InteropServices.Marshal.Copy(converted.GetPixels(), bgraBytes, 0, byteCount);

						return bgraBytes;
					}
				}
			}
		}

		public static void SaveBgraAsPng(byte[] bgraBytes, int width, int height, string outputPath)
		{
			if (bgraBytes.Length != width * height * 4)
				throw new ArgumentException("The size of the array does not match the size of the image.");

			using (var bitmap = new SKBitmap(new SKImageInfo(width, height, SKColorType.Bgra8888, SKAlphaType.Premul)))
			{
				System.Runtime.InteropServices.Marshal.Copy(bgraBytes, 0, bitmap.GetPixels(), bgraBytes.Length);

				using (var image = SKImage.FromBitmap(bitmap))
				using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
				using (var stream = File.OpenWrite(outputPath))
				{
					data.SaveTo(stream);
				}
			}
		}

		public static string EncodeImageToBase64(byte[] imageBytes)
		{
			if (imageBytes == null || imageBytes.Length == 0)
				throw new ArgumentException("Image cannot be empty.");

			return Convert.ToBase64String(imageBytes);
		}
	}
}
