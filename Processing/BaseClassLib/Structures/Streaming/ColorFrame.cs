using System;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Streaming
{
	public class ColorFrame
	{
		#region Public properties
		public int Width
		{
			get;
			private set;
		}
		public int Height
		{
			get;
			private set;
		}
		public ColorImageFormat RawColorImageFormat
		{
			get;
			private set;
		}
		public uint BytesPerPixel
		{
			get;
			private set;
		}
		public uint LengthInPixels
		{
			get;
			private set;
		}
		public TimeSpan RelativeTime
		{
			get;
			private set;
		} = default;
		public byte[] ColorData
		{
			get;
			set;
		} = new byte[0];
		#endregion

		#region Constructors
		public ColorFrame()
		{}

		public ColorFrame(int width, int height, ColorImageFormat imageFormat, 
			uint bytesPerPixel, uint lengthInPixels, TimeSpan relativeTime, byte[] colorData = null)
		{
			this.Width = width;
			this.Height = height;
			this.RawColorImageFormat = imageFormat;
			this.BytesPerPixel = bytesPerPixel;
			this.LengthInPixels = lengthInPixels;
			this.RelativeTime = relativeTime;
			this.ColorData = colorData ?? new byte[0];
		}
		#endregion
	}
}
