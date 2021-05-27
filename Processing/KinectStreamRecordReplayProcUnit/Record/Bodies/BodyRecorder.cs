using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Structures;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Bodies
{
	internal class BodyRecorder
	{
		#region Private fields
		private DateTime referenceTime;
		private readonly BinaryWriter writer;
		#endregion

		#region Constructors
		internal BodyRecorder(BinaryWriter writer)
		{
			this.writer = writer;
			this.referenceTime = DateTime.Now;
		}
		#endregion

		#region Public methods
		public void Record(BodyFrame frame, IEnumerable<(Body, BodyJointsColorSpacePointsDict)> bodies)
		{
			if (frame == null)
				throw new ArgumentNullException(nameof(frame));
			if (frame.BodyCount <= 0)
				throw new ArgumentException(nameof(frame.BodyCount));
			if (bodies == null)
				throw new ArgumentNullException(nameof(bodies));

			// Header
			this.writer.Write((int)KinectRecordOptions.Bodies);

			// Data
			var timeSpan = DateTime.Now.Subtract(referenceTime);
			this.referenceTime = DateTime.Now;
			this.writer.Write((long)timeSpan.TotalMilliseconds);
			this.writer.Write(frame.FloorClipPlane.X);
			this.writer.Write(frame.FloorClipPlane.Y);
			this.writer.Write(frame.FloorClipPlane.Z);
			this.writer.Write(frame.FloorClipPlane.W);

			var bodiesData = bodies.Map();

			var formatter = new BinaryFormatter();
			formatter.Serialize(this.writer.BaseStream, bodiesData);
		}
		#endregion
	}
}
