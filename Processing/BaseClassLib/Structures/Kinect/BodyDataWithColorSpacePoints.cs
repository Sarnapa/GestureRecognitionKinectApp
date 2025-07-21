using System;
using MSKinect = Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Kinect
{
	[Serializable]
	public sealed class BodyDataWithColorSpacePoints: BodyData
	{
		#region Public properties
		public BodyJointsColorSpacePointsDict JointsColorSpacePoints
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BodyDataWithColorSpacePoints(MSKinect.Body body, BodyJointsColorSpacePointsDict jointsColorSpacePoints)
			: base(body)
		{
			this.JointsColorSpacePoints = jointsColorSpacePoints ?? new BodyJointsColorSpacePointsDict();
		}
		#endregion
	}
}
