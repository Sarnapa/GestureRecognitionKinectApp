using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Kinect;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Bodies
{
	internal class BodyRecorder
	{
		#region Private fields
		private DateTime referenceTime;
		private readonly float resizingCoef = 1.0f;
		private readonly BinaryWriter writer;
		#endregion

		#region Constructors
		internal BodyRecorder(BinaryWriter writer, float resizingCoef)
		{
			this.writer = writer;
			this.resizingCoef = resizingCoef;
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

			bodies = GetResizingBodies(bodies);

			// Header
			this.writer.Write((int)KinectRecordOptions.Bodies);

			// Data
			var timeSpan = DateTime.Now.Subtract(referenceTime);
			this.referenceTime = DateTime.Now;
			this.writer.Write((long)timeSpan.TotalMilliseconds);
			// This is not necessary
			//this.writer.Write(frame.FloorClipPlane.X);
			//this.writer.Write(frame.FloorClipPlane.Y);
			//this.writer.Write(frame.FloorClipPlane.Z);
			//this.writer.Write(frame.FloorClipPlane.W);

			var bodiesData = bodies.Map();

			var formatter = new BinaryFormatter();
			formatter.Serialize(this.writer.BaseStream, bodiesData);
		}
		#endregion

		#region Private methods
		private IEnumerable<(Body, BodyJointsColorSpacePointsDict)> GetResizingBodies(IEnumerable<(Body, BodyJointsColorSpacePointsDict)> bodies)
		{
			if (bodies == null)
				throw new ArgumentNullException(nameof(bodies));

			if (this.resizingCoef != 1.0f && bodies.Any())
			{
				var newBodies = new List<(Body, BodyJointsColorSpacePointsDict)>();

				foreach (var kv in bodies)
				{
					var body = kv.Item1;
					var bodyJointsColorSpacePointsDict = kv.Item2;
					var newBodyJointsColorSpacePointsDict = new BodyJointsColorSpacePointsDict();
					if (bodyJointsColorSpacePointsDict != null && bodyJointsColorSpacePointsDict.Any())
					{
						foreach (var jointPoint in bodyJointsColorSpacePointsDict)
						{
							newBodyJointsColorSpacePointsDict[jointPoint.Key] = new ColorSpacePoint()
							{
								X = jointPoint.Value.X * this.resizingCoef,
								Y = jointPoint.Value.Y * this.resizingCoef
							};
						}
					}

					newBodies.Add((body, newBodyJointsColorSpacePointsDict));
				}

				return newBodies;
			}

			return bodies;
		}
		#endregion
	}
}
