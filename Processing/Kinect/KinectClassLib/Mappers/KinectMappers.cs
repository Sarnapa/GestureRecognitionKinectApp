using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using GestureRecognition.Processing.Kinect.KinectClassLib.Structures;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.Kinect.KinectClassLib.Mappers
{
	public static class KinectMappers
	{
		#region BodyData
		public static BodyData Map(this Body body)
		{
			return new BodyData(body);
		}

		public static BodyData[] Map(this IEnumerable<Body> bodies)
		{
			return bodies.Select(b => b.Map()).ToArray();
		}

		public static BodyDataWithColorSpacePoints Map(this Body body, BodyJointsColorSpacePointsDict jointsColorSpacePoints)
		{
			return new BodyDataWithColorSpacePoints(body, jointsColorSpacePoints);
		}

		public static BodyDataWithColorSpacePoints[] Map(this IEnumerable<(Body, BodyJointsColorSpacePointsDict)> bodies)
		{
			return bodies.Select(b => b.Item1.Map(b.Item2)).ToArray();
		}
		#endregion

		#region CameraSpaceJoint -> Vector3
		public static Vector3 Map(this CameraSpacePoint point)
		{
			return new Vector3(point.X, point.Y, point.Z);
		}

		public static IEnumerable<Vector3> Map(this IEnumerable<CameraSpacePoint> points)
		{
			return points.Select(p => p.Map());
		}
		#endregion
	}
}
