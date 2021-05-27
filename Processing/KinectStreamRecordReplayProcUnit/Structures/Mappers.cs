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

		public static BodyData[] Map(this Body[] bodies)
		{
			return bodies.Select(b => b.Map()).ToArray();
		}
	}
}
