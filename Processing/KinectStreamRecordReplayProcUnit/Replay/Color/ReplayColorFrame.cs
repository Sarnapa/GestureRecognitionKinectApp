using System;
using System.IO;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Color
{
	public class ReplayColorFrame : ReplayFrame
	{
		#region Private fields
		private readonly ColorFrame internalFrame;
		private long streamPosition;
		private Stream stream;
		#endregion

		#region Public methods
		public uint BytesPerPixel
		{
			get; private set;
		}
		public ColorImageFormat RawColorImageFormat
		{
			get; private set;
		}
		public int Width
		{
			get; private set;
		}
		public int Height
		{
			get; private set;
		}
		public uint LengthInPixels
		{
			get; set;
		}
		#endregion

		#region Constructors
		public ReplayColorFrame()
		{}

		public ReplayColorFrame(ColorFrame frame)
		{
			if (frame == null)
				throw new ArgumentNullException(nameof(frame));
			if (frame.FrameDescription == null)
				throw new ArgumentNullException(nameof(frame.FrameDescription));

			var frameDescription = frame.FrameDescription;

			this.TimeStamp = (long)frame.RelativeTime.TotalMilliseconds;
			this.BytesPerPixel = frameDescription.BytesPerPixel;
			this.RawColorImageFormat = frame.RawColorImageFormat;
			this.Width = frameDescription.Width;
			this.Height = frameDescription.Height;

			this.LengthInPixels = frameDescription.LengthInPixels;
			this.internalFrame = frame;
		}
		#endregion

		#region Operators
		public static implicit operator ReplayColorFrame(ColorFrame frame)
		{
			return new ReplayColorFrame(frame);
		}
		#endregion

		#region Public methods
		public void CopyPixelDataTo(byte[] pixelData)
		{
			if (this.internalFrame != null)
			{
				this.internalFrame.CopyRawFrameDataToArray(pixelData);
				return;
			}

			long savedPosition = stream.Position;
			this.stream.Position = streamPosition;

			this.stream.Read(pixelData, 0, (int)(this.LengthInPixels * this.BytesPerPixel));

			this.stream.Position = savedPosition;
		}
		#endregion

		#region ReplayFrame overriders
		internal override void CreateFromReader(BinaryReader reader)
		{
			this.TimeStamp = reader.ReadInt64();
			this.BytesPerPixel = reader.ReadUInt32();
			this.RawColorImageFormat = (ColorImageFormat)reader.ReadInt32();
			this.Width = reader.ReadInt32();
			this.Height = reader.ReadInt32();
			this.LengthInPixels = reader.ReadUInt32();

			this.stream = reader.BaseStream;
			this.streamPosition = stream.Position;

			this.stream.Position += this.LengthInPixels * this.BytesPerPixel;
		}
		#endregion
	}
}
