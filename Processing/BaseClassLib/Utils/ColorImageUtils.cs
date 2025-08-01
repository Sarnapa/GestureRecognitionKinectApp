using System;
using System.IO;
using System.Runtime.InteropServices;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using SkiaSharp;

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


		public static byte[] PrepareBgraImageForMediaPipeModel(byte[] imageBytes, int currentImageWidth, int currentImageHeight, int targetWidth, int targetHeight)
		{
			using (var originalImage = new SKBitmap(new SKImageInfo(currentImageWidth, currentImageHeight, SKColorType.Bgra8888, SKAlphaType.Premul)))
			{
				Marshal.Copy(imageBytes, 0, originalImage.GetPixels(), imageBytes.Length);
				using (SKBitmap scaledImage = originalImage.Resize(new SKImageInfo(targetWidth, targetHeight), SKFilterQuality.High))
				{
					if (scaledImage == null)
						throw new Exception("Error resizing image.");

					byte[] rawBitmap = GetRawBitmap(scaledImage);

					int pixelsCount = scaledImage.Pixels.Length;
					byte[] rgbRawBitamp = new byte[pixelsCount * 3];
					for (int i = 0; i < pixelsCount; i++)
					{
						int rgbIdx = i * 3;
						int bgraIdx = i * 4;
						rgbRawBitamp[rgbIdx] = rawBitmap[bgraIdx + 2];
						rgbRawBitamp[rgbIdx + 1] = rawBitmap[bgraIdx + 1];
						rgbRawBitamp[rgbIdx + 2] = rawBitmap[bgraIdx];
					}

					return rgbRawBitamp;
				}
			}
		}

		public static byte[] GetRawBitmap(SKBitmap image)
		{
			if (image == null)
				throw new ArgumentNullException(nameof(image));

			int width = image.Width;
			int height = image.Height;
			int bytesCount = width * height * image.BytesPerPixel;
			byte[] rawData = new byte[bytesCount];

      Marshal.Copy(image.GetPixels(), rawData, 0, bytesCount);

			return rawData;
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
