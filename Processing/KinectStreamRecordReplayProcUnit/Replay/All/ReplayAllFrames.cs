using System;
using System.IO;
using GestureRecognition.Processing.StreamRecordReplayProcUnit.Replay.Bodies;
using GestureRecognition.Processing.StreamRecordReplayProcUnit.Replay.Color;
using MessagePack;

namespace GestureRecognition.Processing.StreamRecordReplayProcUnit.Replay.All
{
	public class ReplayAllFrames : ReplayFrame
	{
		#region Public properties
		public ReplayColorFrame ColorFrame
		{
			get; set;
		}
		public ReplayBodyFrame BodyFrame
		{
			get; set;
		}

		public override long TimeStamp
		{
			get
			{
				return this.ColorFrame?.TimeStamp ?? 0;
			}
		}
		#endregion

		#region ReplayFrame overriders
		internal override void CreateFromReader(BinaryReader reader, MessagePackSerializerOptions serializerOptions)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
