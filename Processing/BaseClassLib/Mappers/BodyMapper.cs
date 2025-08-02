using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
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
		public static async Task<BodyDataWithColorSpacePoints[]> Map(this DetectPoseLandmarksResponse response,
			float trackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			var tasks = new List<Task<BodyDataWithColorSpacePoints>>();
			if (response.Status == DetectPoseLandmarksResponseStatus.OK && response.Landmarks != null & response.WorldLandmarks != null
				&& response.HandLeftStates != null && response.HandRightStates != null && response.Landmarks.Count == response.WorldLandmarks.Count
				&& response.HandLeftStates.Count == response.HandRightStates.Count && response.Landmarks.Count == response.HandLeftStates.Count)
			{
				for (int i = 0; i < response.Landmarks.Count; i++)
				{
					tasks.Add(MapAsync((ulong)i, response.Landmarks[i], response.WorldLandmarks[i], response.HandLeftStates[i], response.HandRightStates[i],
						trackedJointVisibilityThreshold, inferredJointVisibilityThreshold));
				}
			}

			var results = await Task.WhenAll(tasks).ConfigureAwait(false);
			results = results.OrderBy(r => r.TrackingId).ToArray();

			return results;
		}

		private static async Task<BodyDataWithColorSpacePoints> MapAsync(ulong trackingId, List<PoseLandmark> poseLandmarks, List<PoseLandmark> worldPoseLandmarks,
			HandState handLeftState, HandState handRightState, float trackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			return await Task.Run(() => Map(trackingId, poseLandmarks, worldPoseLandmarks, handLeftState, handRightState,
				trackedJointVisibilityThreshold, inferredJointVisibilityThreshold)).ConfigureAwait(false);
		}

		private static BodyDataWithColorSpacePoints Map(ulong trackingId, List<PoseLandmark> poseLandmarks, List<PoseLandmark> worldPoseLandmarks,
			HandState handLeftState, HandState handRightState, float trackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			var joints = new Dictionary<JointType, Joint>();

			foreach (var landmark in worldPoseLandmarks)
			{
				var joint = Map(landmark, trackedJointVisibilityThreshold, inferredJointVisibilityThreshold);
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

			var handLeftJoints = joints.Where(kv => IsHandLeftPartJointForPoseLandmarksModel(kv.Key)).Select(kv => kv.Value).ToArray();
			var handRightJoints = joints.Where(kv => IsHandRightPartJointForPoseLandmarksModel(kv.Key)).Select(kv => kv.Value).ToArray();

			var handLeftTrackingConfidence = GetHandTrackingConfidenceForPoseLandmarksModel(handLeftJoints);
			var handRightTrackingConfidence = GetHandTrackingConfidenceForPoseLandmarksModel(handRightJoints);

			bool isTracked = joints.Count > 0 && joints.Count == jointsColorSpacePoints.Count
				&& joints.Any(j => j.Value.TrackingState == TrackingState.Tracked);

			return new BodyDataWithColorSpacePoints(trackingId, isTracked, joints, handLeftState, handLeftTrackingConfidence,
				handRightState, handRightTrackingConfidence, jointsColorSpacePoints);
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

		private static Joint? Map(PoseLandmark landmark, float trackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			if (landmark == null)
				return null;

			var jointType = Map(landmark.Idx);
			if (!jointType.HasValue)
				return null;

			return new Joint(jointType.Value, new Vector3(landmark.X, landmark.Y, landmark.Z),
				GetTrackingState(landmark.Visibility, trackedJointVisibilityThreshold, inferredJointVisibilityThreshold));
		}

		private static bool IsHandLeftPartJointForPoseLandmarksModel(JointType joint)
		{
			return joint == JointType.WristLeft || joint == JointType.PinkyLeft 
				|| joint == JointType.IndexLeft || joint == JointType.ThumbLeft;
		}

		private static bool IsHandRightPartJointForPoseLandmarksModel(JointType joint)
		{
			return joint == JointType.WristRight || joint == JointType.PinkyRight
				|| joint == JointType.IndexRight || joint == JointType.ThumbRight;
		}

		private static TrackingConfidence GetHandTrackingConfidenceForPoseLandmarksModel(Joint[] handJoints)
		{
			if (handJoints == null || handJoints.Length != 4 || handJoints.Any(j => j.TrackingState == TrackingState.NotTracked))
				return TrackingConfidence.Low;

			return TrackingConfidence.High;
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
				case 33:
					return JointType.HandLeft;
				case 34:
					return JointType.HandRight;
			}

			return null;
		}
		#endregion

		#region DetectHandLandmarksResponse -> BodyDataWithColorSpacePoints
		public static BodyDataWithColorSpacePoints Map(this DetectHandLandmarksResponse response, float trackedJointScoreThreshold,
			float inferredJointScoreThreshold)
		{
			var result = new BodyDataWithColorSpacePoints();
			// The case where there are a maximum of two hands is supported, but there is no way to distinguish which hand belongs to whom.
			if (response.Status == DetectHandLandmarksResponseStatus.OK && response.Handedness != null && response.Landmarks != null & response.WorldLandmarks != null
				&& response.Landmarks.Count == response.Handedness.Count && response.Landmarks.Count == response.WorldLandmarks.Count
				&& response.Landmarks.Count > 0 && response.Landmarks.Count <= 2)
			{
				var (handLeftData, handLeftLandmarks, handLeftWorldLandmarks) = TryToGetHandData(response.Handedness, response.Landmarks, response.WorldLandmarks, true);
				var (handRightData, handRightLandmarks, handRightWorldLandmarks) = TryToGetHandData(response.Handedness, response.Landmarks, response.WorldLandmarks, false);
				if (handLeftData != null || handRightData != null)
				{
					result = Map(0, handLeftData, handLeftLandmarks, handLeftWorldLandmarks, handRightData, handRightLandmarks, handRightWorldLandmarks,
						trackedJointScoreThreshold, inferredJointScoreThreshold);
				}
			}

			return result;
		}

		private static (HandData handData, List<HandLandmark> landmarks, List<HandLandmark> worldLandmarks) TryToGetHandData(List<HandData> handsData,
			List<List<HandLandmark>> handsLandmarks, List<List<HandLandmark>> handsWorldLandmarks, bool isLeft)
		{
			HandData handData;
			List<HandLandmark> landmarks = null, worldLandmarks = null;

			// MediaPipe has them reversed, which is right and which is left.
			string categoryName = isLeft ? "right" : "left";

			handData = handsData?.FirstOrDefault(h => h.CategoryName.ToLower() == categoryName);
			if (handData != null)
			{
				int idx = handsData.IndexOf(handData);
				landmarks = handsLandmarks[idx];
				worldLandmarks = handsWorldLandmarks[idx];
			}

			return (handData, landmarks, worldLandmarks);
		}

		private static BodyDataWithColorSpacePoints Map(ulong trackingId, HandData handLeftData, List<HandLandmark> handLeftLandmarks, List<HandLandmark> handLeftWorldLandmarks,
			HandData handRightData, List<HandLandmark> handRightLandmarks, List<HandLandmark> handRightWorldLandmarks, float trackedJointScoreThreshold, float inferredJointScoreThreshold)
		{
			int initialJointsCount = handLeftWorldLandmarks?.Count ?? 0 + handRightWorldLandmarks?.Count ?? 0;
			var joints = new Dictionary<JointType, Joint>(initialJointsCount);
			var jointsColorSpacePoints = new BodyJointsColorSpacePointsDict(initialJointsCount);

			bool isHandLeft = handLeftData != null;
			bool isHandRight = handRightData != null;

			var handLeftTrackingState = TrackingState.NotTracked;
			var handRightTrackingState = TrackingState.NotTracked;
			var handLeftTrackingConfidence = TrackingConfidence.Low;
			var handRightTrackingConfidence = TrackingConfidence.Low;

			if (isHandLeft)
				handLeftTrackingState = GetTrackingState(handLeftData.Score, trackedJointScoreThreshold, inferredJointScoreThreshold);
			if (isHandRight)
				handRightTrackingState = GetTrackingState(handRightData.Score, trackedJointScoreThreshold, inferredJointScoreThreshold);

			AddJoints(ref joints, handLeftWorldLandmarks, handLeftTrackingState, true);
			AddJoints(ref joints, handRightWorldLandmarks, handRightTrackingState, false);

			AddColorSpacePoints(ref jointsColorSpacePoints, joints, handLeftLandmarks, true);
			AddColorSpacePoints(ref jointsColorSpacePoints, joints, handRightLandmarks, false);

			if (isHandLeft)
				handLeftTrackingConfidence = GetHandTrackingConfidenceForHandLandmarksModel(handLeftData.Score, inferredJointScoreThreshold);
			if (isHandRight)	
				handRightTrackingConfidence = GetHandTrackingConfidenceForHandLandmarksModel(handRightData.Score, inferredJointScoreThreshold);

			bool isTracked = joints.Count > 0 && joints.Count == jointsColorSpacePoints.Count
				&& (handLeftTrackingState == TrackingState.Tracked || handRightTrackingState == TrackingState.Tracked);

			return new BodyDataWithColorSpacePoints(trackingId, isTracked, joints, handLeftData?.HandState ?? HandState.Unknown, handLeftTrackingConfidence,
				handRightData?.HandState ?? HandState.Unknown, handRightTrackingConfidence, jointsColorSpacePoints);
		}

		private static void AddJoints(ref Dictionary<JointType, Joint> joints, List<HandLandmark> worldHandLandmarks, TrackingState handTrackingState,
			bool isLeft)
		{
			if (worldHandLandmarks != null)
			{
				foreach (var landmark in worldHandLandmarks)
				{
					var joint = MapWorldLandmark(landmark, handTrackingState, isLeft);
					if (joint.HasValue)
						joints.Add(joint.Value.JointType, joint.Value);
				}
			}
		}

		private static void AddColorSpacePoints(ref BodyJointsColorSpacePointsDict jointsColorSpacePoints, Dictionary<JointType, Joint> joints, List<HandLandmark> handLandmarks, bool isLeft)
		{
			if (handLandmarks != null)
			{
				foreach (var landmark in handLandmarks)
				{
					var (jointType, colorSpacePoint) = MapLandmark(landmark, isLeft);
					if (jointType.HasValue && colorSpacePoint.HasValue && joints.ContainsKey(jointType.Value))
						jointsColorSpacePoints.Add(jointType.Value, colorSpacePoint.Value);
				}
			}
		}

		private static Joint? MapWorldLandmark(HandLandmark landmark, TrackingState handTrackingState, bool isLeft)
		{
			if (landmark == null)
				return null;

			var jointType = MapHandJointType(landmark.Idx, isLeft);
			if (!jointType.HasValue)
				return null;

			return new Joint(jointType.Value, new Vector3(landmark.X, landmark.Y, landmark.Z), handTrackingState);
		}

		private static (JointType? jointType, Vector2? colorSpacePoint) MapLandmark(HandLandmark landmark, bool isLeft)
		{
			if (landmark == null)
				return (null, null);

			var jointType = MapHandJointType(landmark.Idx, isLeft);
			if (!jointType.HasValue)
				return (null, null);

			return (jointType.Value, new Vector2(landmark.X, landmark.Y));
		}

		private static TrackingConfidence GetHandTrackingConfidenceForHandLandmarksModel(float score, float inferredJointScoreThreshold)
		{
			return score > inferredJointScoreThreshold ? TrackingConfidence.High : TrackingConfidence.Low;
		}

		private static JointType? MapHandJointType(int idx, bool isLeft)
		{
			switch (idx)
			{
				case 0:
					return isLeft ? JointType.WristLeft : JointType.WristRight;
				case 1:
					return isLeft ? JointType.ThumbCMCLeft : JointType.ThumbCMCRight;
				case 2:
					return isLeft ? JointType.ThumbMCPLeft : JointType.ThumbMCPRight;
				case 3:
					return isLeft ? JointType.ThumbIPLeft : JointType.ThumbIPRight;
				case 4:
					return isLeft ? JointType.ThumbTIPLeft : JointType.ThumbTIPRight;
				case 5:
					return isLeft ? JointType.IndexFingerMCPLeft : JointType.IndexFingerMCPRight;
				case 6:
					return isLeft ? JointType.IndexFingerPIPLeft : JointType.IndexFingerPIPRight;
				case 7:
					return isLeft ? JointType.IndexFingerDIPLeft : JointType.IndexFingerDIPRight;
				case 8:
					return isLeft ? JointType.IndexFingerTIPLeft : JointType.IndexFingerTIPRight;
				case 9:
					return isLeft ? JointType.MiddleFingerMCPLeft : JointType.MiddleFingerMCPRight;
				case 10:
					return isLeft ? JointType.MiddleFingerPIPLeft : JointType.MiddleFingerPIPRight;
				case 11:
					return isLeft ? JointType.MiddleFingerDIPLeft : JointType.MiddleFingerDIPRight;
				case 12:
					return isLeft ? JointType.MiddleFingerTIPLeft : JointType.MiddleFingerTIPRight;
				case 13:
					return isLeft ? JointType.RingFingerMCPLeft : JointType.RingFingerMCPRight;
				case 14:
					return isLeft ? JointType.RingFingerPIPLeft : JointType.RingFingerPIPRight;
				case 15:
					return isLeft ? JointType.RingFingerDIPLeft : JointType.RingFingerDIPRight;
				case 16:
					return isLeft ? JointType.RingFingerTIPLeft : JointType.RingFingerTIPRight;
				case 17:
					return isLeft ? JointType.PinkyMCPLeft : JointType.PinkyMCPRight;
				case 18:
					return isLeft ? JointType.PinkyPIPLeft : JointType.PinkyPIPRight;
				case 19:
					return isLeft ? JointType.PinkyDIPLeft : JointType.PinkyDIPRight;
				case 20:
					return isLeft ? JointType.PinkyTIPLeft : JointType.PinkyTIPRight;
				case 21:
					return isLeft ? JointType.HandLeft : JointType.HandRight;
			}

			return null;
		}
		#endregion

		#region Private methods
		private static TrackingState GetTrackingState(float score, float trackedJointScoreThreshold, float inferredJointScoreThreshold)
		{
			if (score >= trackedJointScoreThreshold)
				return TrackingState.Tracked;
			else if (score >= inferredJointScoreThreshold)
				return TrackingState.Inferred;

			return TrackingState.NotTracked;
		}
		#endregion
	}
}
