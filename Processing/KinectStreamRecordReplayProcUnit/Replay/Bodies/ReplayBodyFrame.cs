using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Kinect;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Bodies
{
	public class ReplayBodyFrame : ReplayFrame
	{
		#region Public properties
		public Vector4 FloorClipPlane
		{
			get; private set;
		}
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
			this.FloorClipPlane = frame.FloorClipPlane;
			
			// Without color space coordinations for bodies joints
			var bodies = new Body[frame.BodyCount];
			frame.GetAndRefreshBodyData(bodies);

			var bodiesWithJointsColorSpacePoints = bodies.Select(b => (b, new BodyJointsColorSpacePointsDict()));
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
			// This is not necessary
			//this.FloorClipPlane = new Vector4 {
			//	X = reader.ReadSingle(),
			//	Y = reader.ReadSingle(),
			//	Z = reader.ReadSingle(),
			//	W = reader.ReadSingle()
			//};

			var formatter = new BinaryFormatter();
			this.Bodies = (BodyDataWithColorSpacePoints[])formatter.Deserialize(reader.BaseStream);
		}
		#endregion
	}
}
