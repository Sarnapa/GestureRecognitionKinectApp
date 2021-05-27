using System.Collections.Generic;
using System.Linq;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Structures
{
	public static class Mappers
	{
		public static BodyData Map(this Body body)
		{
			return new BodyData(body);
		}

		public static BodyData[] Map(this IEnumerable<Body> bodies)
		{
			return bodies.Select(b => b.Map()).ToArray();
		}

		public static BodyData Map(this Body body, BodyJointsColorSpacePointsDict jointsColorSpacePoints)
		{
			return new BodyData(body, jointsColorSpacePoints);
		}

		public static BodyData[] Map(this IEnumerable<(Body, BodyJointsColorSpacePointsDict)> bodies)
		{
			return bodies.Select(b => b.Item1.Map(b.Item2)).ToArray();
		}
	}
}
