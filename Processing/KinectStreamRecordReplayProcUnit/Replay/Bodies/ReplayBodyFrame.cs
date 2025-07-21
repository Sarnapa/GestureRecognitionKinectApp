using System;
using System.IO;
using System.Linq;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using MessagePack;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Bodies
{
	public class ReplayBodyFrame : ReplayFrame
	{
		#region Public properties
		public BodyDataWithColorSpacePoints[] Bodies
		{
			get; private set;
		}
		#endregion

		#region Constructors
		public ReplayBodyFrame(BodyFrame frame)
		{
			if (frame == null)
				throw new ArgumentNullException(nameof(frame));

			this.TimeStamp = frame.RelativeTime.Ticks;
			
			// Without color space coordinations for bodies joints
			var bodiesWithJointsColorSpacePoints = frame.Bodies.Select(b => (b, new BodyJointsColorSpacePointsDict()));
			this.Bodies = bodiesWithJointsColorSpacePoints.Map();
		}

		public ReplayBodyFrame()
		{}
		#endregion

		#region Operators
		public static implicit operator ReplayBodyFrame(BodyFrame frame)
		{
			return new ReplayBodyFrame(frame);
		}
		#endregion

		#region ReplayFrame overriders
		internal override void CreateFromReader(BinaryReader reader, MessagePackSerializerOptions serializerOptions)
		{
			this.TimeStamp = reader.ReadInt64();

			if (serializerOptions == null)
				this.Bodies = MessagePackSerializer.Deserialize<BodyDataWithColorSpacePoints[]>(reader.BaseStream);
			else
				this.Bodies = MessagePackSerializer.Deserialize<BodyDataWithColorSpacePoints[]>(reader.BaseStream, serializerOptions);
		}
		#endregion
	}
}
