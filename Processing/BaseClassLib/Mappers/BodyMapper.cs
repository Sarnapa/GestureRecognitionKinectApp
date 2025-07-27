using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;

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

		#region DetectPoseLandmarksResponse -> BodyDataWithColorSpacePoints
		public static BodyDataWithColorSpacePoints[] Map(this DetectPoseLandmarksResponse response,
			float notTrackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			var result = new List<BodyDataWithColorSpacePoints>();
			if (response.Status == DetectPoseLandmarksResponseStatus.OK && response.Landmarks != null & response.WorldLandmarks != null
				&& response.Landmarks.Count == response.WorldLandmarks.Count)
			{
				for (int i = 0; i < response.Landmarks.Count; i++)
				{
					result.Add(Map((ulong)i, response.Landmarks[i], response.WorldLandmarks[i],
						notTrackedJointVisibilityThreshold, inferredJointVisibilityThreshold));
				}
			}

			return result.ToArray();
		}

		private static BodyDataWithColorSpacePoints Map(ulong trackingId, List<PoseLandmark> poseLandmarks, List<PoseLandmark> worldPoseLandmarks,
			float notTrackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			var joints = new Dictionary<JointType, Joint>();
			foreach (var landmark in worldPoseLandmarks)
			{
				var joint = Map(landmark, notTrackedJointVisibilityThreshold, inferredJointVisibilityThreshold);
				if (joint.HasValue)
					joints.Add(joint.Value.JointType, joint.Value);
			}

			var jointsColorSpacePoints = new BodyJointsColorSpacePointsDict();
			foreach (var landmark in poseLandmarks)
			{
				var (jointType, colorSpacePoint) = Map(landmark);
				if (jointType.HasValue && colorSpacePoint.HasValue && joints.ContainsKey(jointType.Value))
					jointsColorSpacePoints.Add(jointType.Value, colorSpacePoint.Value);
			}

			bool isTracked = joints.Count > 0 && joints.Count == jointsColorSpacePoints.Count
				&& joints.Any(j => j.Value.TrackingState == TrackingState.Tracked);

			return new BodyDataWithColorSpacePoints(trackingId, isTracked, joints, HandState.Unknown, TrackingConfidence.Low,
				HandState.Unknown, TrackingConfidence.Low, jointsColorSpacePoints);
		}

		private static (JointType? jointType, Vector2? colorSpacePoint) Map(PoseLandmark landmark)
		{
			if (landmark == null)
				return (null, null);

			var jointType = Map(landmark.Idx);
			if (!jointType.HasValue)
				return (null, null);

			return (jointType.Value, new Vector2(landmark.X, landmark.Y));
		}

		private static Joint? Map(PoseLandmark landmark, float notTrackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			if (landmark == null)
				return null;

			var jointType = Map(landmark.Idx);
			if (!jointType.HasValue)
				return null;

			return new Joint(jointType.Value, new Vector3(landmark.X, landmark.Y, landmark.Z),
				GetTrackingState(landmark.Visibility, notTrackedJointVisibilityThreshold, inferredJointVisibilityThreshold));
		}

		private static JointType? Map(int idx)
		{
			switch (idx)
			{
				case 0:
					return JointType.Nose;
				case 1:
					return JointType.EyeInnerLeft;
				case 2:
					return JointType.EyeLeft;
				case 3:
					return JointType.EyeOuterLeft;
				case 4:
					return JointType.EyeInnerRight;
				case 5:
					return JointType.EyeRight;
				case 6:
					return JointType.EyeOuterRight;
				case 7:
					return JointType.EarLeft;
				case 8:
					return JointType.EarRight;
				case 9:
					return JointType.MouthLeft;
				case 10:
					return JointType.MouthRight;
				case 11:
					return JointType.ShoulderLeft;
				case 12:
					return JointType.ShoulderRight;
				case 13:
					return JointType.ElbowLeft;
				case 14:
					return JointType.ElbowRight;
				case 15:
					return JointType.WristLeft;
				case 16:
					return JointType.WristRight;
				case 17:
					return JointType.PinkyLeft;
				case 18:
					return JointType.PinkyRight;
				case 19:
					return JointType.IndexLeft;
				case 20:
					return JointType.IndexRight;
				case 21:
					return JointType.ThumbLeft;
				case 22:
					return JointType.ThumbRight;
				case 23:
					return JointType.HipLeft;
				case 24:
					return JointType.HipRight;
				case 25:
					return JointType.KneeLeft;
				case 26:
					return JointType.KneeRight;
				case 27:
					return JointType.AnkleLeft;
				case 28:
					return JointType.AnkleRight;
				case 29:
					return JointType.HeelLeft;
				case 30:
					return JointType.HeelRight;
				case 31:
					return JointType.FootIndexLeft;
				case 32:
					return JointType.FootIndexRight;
			}

			return null;
		}

		private static TrackingState GetTrackingState(float visibility, float notTrackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			if (visibility <= notTrackedJointVisibilityThreshold)
				return TrackingState.NotTracked;
			else if (visibility <= inferredJointVisibilityThreshold)
				return TrackingState.Inferred;

			return TrackingState.Tracked;
		}
		#endregion
	}
}
