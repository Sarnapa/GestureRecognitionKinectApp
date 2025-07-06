using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

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

			this.TimeStamp = (long)frame.RelativeTime.TotalMilliseconds;
			
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
		internal override void CreateFromReader(BinaryReader reader)
		{
			this.TimeStamp = reader.ReadInt64();

			var formatter = new BinaryFormatter();
			this.Bodies = (BodyDataWithColorSpacePoints[])formatter.Deserialize(reader.BaseStream);
		}
		#endregion
	}
}
