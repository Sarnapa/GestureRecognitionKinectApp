using System.Collections.Generic;
using System.Linq;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Mappers
{
	public static class BodyMapper
	{
		#region BodyData -> BodyDataWithColorSpacePoints
		public static BodyDataWithColorSpacePoints Map(this BodyData body, BodyJointsColorSpacePointsDict jointsColorSpacePoints)
		{
			return new BodyDataWithColorSpacePoints(body, jointsColorSpacePoints);
		}

		public static BodyDataWithColorSpacePoints[] Map(this IEnumerable<(BodyData, BodyJointsColorSpacePointsDict)> bodies)
		{
			return bodies.Select(b => new BodyDataWithColorSpacePoints(b.Item1, b.Item2)).ToArray();
		}
		#endregion
	}
}
