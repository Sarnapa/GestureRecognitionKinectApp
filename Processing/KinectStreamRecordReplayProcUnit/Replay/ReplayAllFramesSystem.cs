using System.IO;
using System.Linq;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.All;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Bodies;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Color;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay
{
	internal class ReplayAllFramesSystem : ReplayBase<ReplayAllFrames>
	{
		#region ReplayBase overriders
		internal override void AddFrame(BinaryReader reader)
		{
			var header = (RecordOptions)reader.ReadInt32();
			switch (header)
			{
				case RecordOptions.Color:
					var colorFrame = new ReplayColorFrame();
					colorFrame.CreateFromReader(reader);
					this.frames.Add(new ReplayAllFrames { ColorFrame = colorFrame });
					break;
				case RecordOptions.Bodies:
					if (this.frames.Any())
					{
						var bodyFrame = new ReplayBodyFrame();
						bodyFrame.CreateFromReader(reader);
						this.frames.Last().BodyFrame = bodyFrame;
					}
					break;
			}
		}
		#endregion
	}
}
