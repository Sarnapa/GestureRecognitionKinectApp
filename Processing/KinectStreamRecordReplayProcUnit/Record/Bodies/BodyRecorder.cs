using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using MessagePack;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Bodies
{
	internal class BodyRecorder
	{
		#region Private fields
		private DateTime referenceTime;
		private readonly float resizingCoef = 1.0f;
		private readonly BinaryWriter writer;
		private readonly MessagePackSerializerOptions serializerOptions;
		#endregion

		#region Constructors
		internal BodyRecorder(BinaryWriter writer, MessagePackSerializerOptions serializerOptions, float resizingCoef)
		{
			this.writer = writer;
			this.serializerOptions = serializerOptions;
			this.resizingCoef = resizingCoef;
			this.referenceTime = DateTime.Now;
		}
		#endregion

		#region Public methods
		public void Record(BodyFrame bodyFrame, (BodyData, BodyJointsColorSpacePointsDict)[] bodies)
		{
			if (bodyFrame == null)
				throw new ArgumentNullException(nameof(bodyFrame));
			if (bodyFrame.Bodies == null || bodyFrame.Bodies.Length <= 0)
				throw new ArgumentException(nameof(bodyFrame.Bodies));
			if (bodies == null)
				throw new ArgumentNullException(nameof(bodies));

			bodies = GetResizingBodies(bodies);

			// Header
			this.writer.Write((int)RecordOptions.Bodies);

			// Data
			var timeSpan = DateTime.Now.Subtract(referenceTime);
			this.referenceTime = DateTime.Now;
			this.writer.Write(timeSpan.Ticks);

			var bodiesData = bodies.Map();

			byte[] bodiesDataBytes;
			if (this.serializerOptions == null)
				bodiesDataBytes = MessagePackSerializer.Serialize(bodiesData);
			else
				bodiesDataBytes = MessagePackSerializer.Serialize(bodiesData, this.serializerOptions);
			this.writer.Write(bodiesDataBytes);
		}
		#endregion

		#region Private methods
		private (BodyData, BodyJointsColorSpacePointsDict)[] GetResizingBodies((BodyData, BodyJointsColorSpacePointsDict)[] bodies)
		{
			if (bodies == null)
				throw new ArgumentNullException(nameof(bodies));

			if (this.resizingCoef != 1.0f && bodies.Any())
			{
				var newBodies = new List<(BodyData, BodyJointsColorSpacePointsDict)>();

				foreach (var kv in bodies)
				{
					var body = kv.Item1;
					var bodyJointsColorSpacePointsDict = kv.Item2;
					var newBodyJointsColorSpacePointsDict = new BodyJointsColorSpacePointsDict();
					if (bodyJointsColorSpacePointsDict != null && bodyJointsColorSpacePointsDict.Any())
					{
						foreach (var jointPoint in bodyJointsColorSpacePointsDict)
						{
							newBodyJointsColorSpacePointsDict[jointPoint.Key] = new Vector2()
							{
								X = jointPoint.Value.X * this.resizingCoef,
								Y = jointPoint.Value.Y * this.resizingCoef
							};
						}
					}

					newBodies.Add((body, newBodyJointsColorSpacePointsDict));
				}

				return newBodies.ToArray();
			}

			return bodies;
		}
		#endregion
	}
}
