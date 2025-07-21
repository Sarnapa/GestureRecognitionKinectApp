using System;
using System.Collections.Generic;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	[Serializable]
	[MessagePackObject(keyAsPropertyName: true)]
	public partial class BodyDataWithColorSpacePoints: BodyData
	{
		#region Public properties
		public BodyJointsColorSpacePointsDict JointsColorSpacePoints
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BodyDataWithColorSpacePoints()
		{}

		public BodyDataWithColorSpacePoints(ulong trackingId, bool isTracked, IReadOnlyDictionary<JointType, Joint> joints,
			HandState handLeftState, TrackingConfidence handLeftConfidence,
			HandState handRightState, TrackingConfidence handRightConfidence,
			BodyJointsColorSpacePointsDict jointsColorSpacePoints)
			: base(trackingId, isTracked, joints, handLeftState, handLeftConfidence, handRightState, handRightConfidence)
		{
			this.JointsColorSpacePoints = jointsColorSpacePoints ?? new BodyJointsColorSpacePointsDict();
		}

		public BodyDataWithColorSpacePoints(BodyData other,
			BodyJointsColorSpacePointsDict jointsColorSpacePoints)
			: base(other)
		{
			this.JointsColorSpacePoints = jointsColorSpacePoints ?? 
				(other is BodyDataWithColorSpacePoints bodyDataWithColorSpacePoints ? 
				bodyDataWithColorSpacePoints.JointsColorSpacePoints ?? new BodyJointsColorSpacePointsDict() 
				: new BodyJointsColorSpacePointsDict());
		}
		#endregion
	}
}
