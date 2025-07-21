using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MSKinect = Microsoft.Kinect;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using OldStructures = GestureRecognition.Processing.BaseClassLib.Structures.Kinect;

namespace GestureRecognition.Applications.GestureRecordsServiceConsoleApp.Serialization
{
	public static class NewStructuresMapper
	{
		#region OldStructures.BodyData -> BodyData
		public static BodyData Map(this OldStructures.BodyData body)
		{
			if (body == null)
				return null;

			return new BodyData(
				body.TrackingId,
				body.IsTracked,
				body.Joints?.ToDictionary(kv => kv.Key.Map(), kv => kv.Value.Map()) ?? new Dictionary<JointType, Joint>(),
				body.HandLeftState.Map(),
				body.HandLeftConfidence.Map(),
				body.HandRightState.Map(),
				body.HandRightConfidence.Map());
		}

		public static BodyData[] Map(this IEnumerable<OldStructures.BodyData> bodies)
		{
			return bodies?.Select(b => b.Map()).ToArray() ?? new BodyData[] { };
		}
		#endregion

		#region OldStructures.BodyDataWithColorSpacePoints -> BodyDataWithColorSpacePoints
		public static BodyDataWithColorSpacePoints Map(this OldStructures.BodyDataWithColorSpacePoints body)
		{
			if (body == null)
				return null;

			return new BodyDataWithColorSpacePoints(
				body.TrackingId,
				body.IsTracked,
				body.Joints?.ToDictionary(kv => kv.Key.Map(), kv => kv.Value.Map()) ?? new Dictionary<JointType, Joint>(),
				body.HandLeftState.Map(),
				body.HandLeftConfidence.Map(),
				body.HandRightState.Map(),
				body.HandRightConfidence.Map(),
				body.JointsColorSpacePoints?.Map() ?? new BodyJointsColorSpacePointsDict()
			);
		}

		public static BodyDataWithColorSpacePoints[] Map(this IEnumerable<OldStructures.BodyDataWithColorSpacePoints> bodies)
		{
			return bodies?.Select(b => b.Map()).ToArray() ?? new BodyDataWithColorSpacePoints[] { };
		}
		#endregion

		#region OldStructures.BodyJointsColorSpacePointsDict -> BodyJointsColorSpacePointsDict
		public static BodyJointsColorSpacePointsDict Map(this OldStructures.BodyJointsColorSpacePointsDict oldDict)
		{
			if (oldDict == null)
				return null;

			var newDict = new BodyJointsColorSpacePointsDict();
			foreach (var kvp in oldDict)
			{
				newDict[kvp.Key.Map()] = kvp.Value.Map();
			}
			return newDict;
		}
		#endregion

		#region MSKinect.Joint -> Joint
		public static Joint Map(this MSKinect.Joint kinectJoint)
		{
			return new Joint(
				kinectJoint.JointType.Map(),
				kinectJoint.Position.Map(),
				kinectJoint.TrackingState.Map()
				);
		}
		#endregion

		#region MSKinect.JointType -> JointType
		public static JointType Map(this MSKinect.JointType kinectJointType)
		{
			switch (kinectJointType)
			{
				case MSKinect.JointType.SpineBase:
					return JointType.SpineBase;
				case MSKinect.JointType.SpineMid:
					return JointType.SpineMid;
				case MSKinect.JointType.Neck:
					return JointType.Neck;
				case MSKinect.JointType.Head:
					return JointType.Head;
				case MSKinect.JointType.ShoulderLeft:
					return JointType.ShoulderLeft;
				case MSKinect.JointType.ElbowLeft:
					return JointType.ElbowLeft;
				case MSKinect.JointType.WristLeft:
					return JointType.WristLeft;
				case MSKinect.JointType.HandLeft:
					return JointType.HandLeft;
				case MSKinect.JointType.ShoulderRight:
					return JointType.ShoulderRight;
				case MSKinect.JointType.ElbowRight:
					return JointType.ElbowRight;
				case MSKinect.JointType.WristRight:
					return JointType.WristRight;
				case MSKinect.JointType.HandRight:
					return JointType.HandRight;
				case MSKinect.JointType.HipLeft:
					return JointType.HipLeft;
				case MSKinect.JointType.KneeLeft:
					return JointType.KneeLeft;
				case MSKinect.JointType.AnkleLeft:
					return JointType.AnkleLeft;
				case MSKinect.JointType.FootLeft:
					return JointType.FootLeft;
				case MSKinect.JointType.HipRight:
					return JointType.HipRight;
				case MSKinect.JointType.KneeRight:
					return JointType.KneeRight;
				case MSKinect.JointType.AnkleRight:
					return JointType.AnkleRight;
				case MSKinect.JointType.FootRight:
					return JointType.FootRight;
				case MSKinect.JointType.SpineShoulder:
					return JointType.SpineShoulder;
				case MSKinect.JointType.HandTipLeft:
					return JointType.HandTipLeft;
				case MSKinect.JointType.ThumbLeft:
					return JointType.ThumbLeft;
				case MSKinect.JointType.HandTipRight:
					return JointType.HandTipRight;
				case MSKinect.JointType.ThumbRight:
					return JointType.ThumbRight;
			}

			return JointType.SpineBase;
		}
		#endregion

		#region MSKinect.HandState -> HandState
		public static HandState Map(this MSKinect.HandState kinectHandState)
		{
			switch (kinectHandState)
			{
				case MSKinect.HandState.Unknown:
					return HandState.Unknown;
				case MSKinect.HandState.Open:
					return HandState.Open;
				case MSKinect.HandState.Closed:
					return HandState.Closed;
				case MSKinect.HandState.Lasso:
					return HandState.Lasso;
			}
			return HandState.Unknown;
		}
		#endregion

		#region MSKinect.TrackingConfidence -> TrackingConfidence
		public static TrackingConfidence Map(this MSKinect.TrackingConfidence kinectTrackingConfidence)
		{
			switch (kinectTrackingConfidence)
			{
				case MSKinect.TrackingConfidence.Low:
					return TrackingConfidence.Low;
				case MSKinect.TrackingConfidence.High:
					return TrackingConfidence.High;
			}
			return TrackingConfidence.Low;
		}
		#endregion

		#region MSKinect.TrackingState -> TrackingState
		public static TrackingState Map(this MSKinect.TrackingState kinectTrackingState)
		{
			switch (kinectTrackingState)
			{
				case MSKinect.TrackingState.NotTracked:
					return TrackingState.NotTracked;
				case MSKinect.TrackingState.Inferred:
					return TrackingState.Inferred;
				case MSKinect.TrackingState.Tracked:
					return TrackingState.Tracked;
			}
			return TrackingState.NotTracked;
		}
		#endregion

		#region MSKinect.ColorSpacePoint -> Vector2
		public static Vector2 Map(this MSKinect.ColorSpacePoint point)
		{
			return new Vector2(point.X, point.Y);
		}

		public static Vector2[] Map(this IEnumerable<MSKinect.ColorSpacePoint> points)
		{
			return points?.Select(p => p.Map()).ToArray() ?? new Vector2[] { };
		}
		#endregion

		#region MSKinect.CameraSpaceJoint -> Vector3
		public static Vector3 Map(this MSKinect.CameraSpacePoint point)
		{
			return new Vector3(point.X, point.Y, point.Z);
		}

		public static Vector3[] Map(this IEnumerable<MSKinect.CameraSpacePoint> points)
		{
			return points?.Select(p => p.Map()).ToArray() ?? new Vector3[] { };
		}
		#endregion
	}
}
