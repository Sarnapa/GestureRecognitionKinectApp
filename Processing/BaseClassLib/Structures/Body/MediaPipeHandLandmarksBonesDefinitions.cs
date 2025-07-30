using System.Collections.Generic;
using System.Linq;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	public static class MediaPipeHandLandmarksBonesDefinitions
	{
		// Right Hand
		public static Bone WristThumbCMCRightBone = new Bone(JointType.WristRight, JointType.ThumbCMCRight);
		public static Bone ThumbCMCThumbMCPRightBone = new Bone(JointType.ThumbCMCRight, JointType.ThumbMCPRight);
		public static Bone ThumbMCPThumbIPRightBone = new Bone(JointType.ThumbMCPRight, JointType.ThumbIPRight);
		public static Bone ThumbIPThumbTIPRightBone = new Bone(JointType.ThumbIPRight, JointType.ThumbTIPRight);

		public static Bone WristIndexFingerMCPRightBone = new Bone(JointType.WristRight, JointType.IndexFingerMCPRight);
		public static Bone IndexFingerMCPIndexFingerPIPRightBone = new Bone(JointType.IndexFingerMCPRight, JointType.IndexFingerPIPRight);
		public static Bone IndexFingerPIPIndexFingerDIPRightBone = new Bone(JointType.IndexFingerPIPRight, JointType.IndexFingerDIPRight);
		public static Bone IndexFingerDIPIndexFingerTIPRightBone = new Bone(JointType.IndexFingerDIPRight, JointType.IndexFingerTIPRight);

		public static Bone MiddleFingerMCPMiddleFingerPIPRightBone = new Bone(JointType.MiddleFingerMCPRight, JointType.MiddleFingerPIPRight);
		public static Bone MiddleFingerPIPMiddleFingerDIPRightBone = new Bone(JointType.MiddleFingerPIPRight, JointType.MiddleFingerDIPRight);
		public static Bone MiddleFingerDIPMiddleFingerTIPRightBone = new Bone(JointType.MiddleFingerDIPRight, JointType.MiddleFingerTIPRight);

		public static Bone RingFingerMCPRingFingerPIPRightBone = new Bone(JointType.RingFingerMCPRight, JointType.RingFingerPIPRight);
		public static Bone RingFingerPIPRingFingerDIPRightBone = new Bone(JointType.RingFingerPIPRight, JointType.RingFingerDIPRight);
		public static Bone RingFingerDIPRingFingerTIPRightBone = new Bone(JointType.RingFingerDIPRight, JointType.RingFingerTIPRight);

		public static Bone WristPinkyMCPRightBone = new Bone(JointType.WristRight, JointType.PinkyMCPRight);
		public static Bone PinkyMCPPinkyPIPRightBone = new Bone(JointType.PinkyMCPRight, JointType.PinkyPIPRight);
		public static Bone PinkyPIPPinkyDIPRightBone = new Bone(JointType.PinkyPIPRight, JointType.PinkyDIPRight);
		public static Bone PinkyDIPPinkyTIPRightBone = new Bone(JointType.PinkyDIPRight, JointType.PinkyTIPRight);

		public static Bone ThumbIPIndexFingerMCPRightBone = new Bone(JointType.ThumbIPRight, JointType.IndexFingerMCPRight);
		public static Bone IndexFingerMCPMiddleFingerMCPRightBone = new Bone(JointType.IndexFingerMCPRight, JointType.MiddleFingerMCPRight);
		public static Bone MiddleFingerMCPRingFingerMCPRightBone = new Bone(JointType.MiddleFingerMCPRight, JointType.RingFingerMCPRight);
		public static Bone RingFingerMCPPinkyMCPRightBone = new Bone(JointType.RingFingerMCPRight, JointType.PinkyMCPRight);

		// Left Hand
		public static Bone WristThumbCMCLeftBone = new Bone(JointType.WristLeft, JointType.ThumbCMCLeft);
		public static Bone ThumbCMCThumbMCPLeftBone = new Bone(JointType.ThumbCMCLeft, JointType.ThumbMCPLeft);
		public static Bone ThumbMCPThumbIPLeftBone = new Bone(JointType.ThumbMCPLeft, JointType.ThumbIPLeft);
		public static Bone ThumbIPThumbTIPLeftBone = new Bone(JointType.ThumbIPLeft, JointType.ThumbTIPLeft);

		public static Bone WristIndexFingerMCPLeftBone = new Bone(JointType.WristLeft, JointType.IndexFingerMCPLeft);
		public static Bone IndexFingerMCPIndexFingerPIPLeftBone = new Bone(JointType.IndexFingerMCPLeft, JointType.IndexFingerPIPLeft);
		public static Bone IndexFingerPIPIndexFingerDIPLeftBone = new Bone(JointType.IndexFingerPIPLeft, JointType.IndexFingerDIPLeft);
		public static Bone IndexFingerDIPIndexFingerTIPLeftBone = new Bone(JointType.IndexFingerDIPLeft, JointType.IndexFingerTIPLeft);

		public static Bone MiddleFingerMCPMiddleFingerPIPLeftBone = new Bone(JointType.MiddleFingerMCPLeft, JointType.MiddleFingerPIPLeft);
		public static Bone MiddleFingerPIPMiddleFingerDIPLeftBone = new Bone(JointType.MiddleFingerPIPLeft, JointType.MiddleFingerDIPLeft);
		public static Bone MiddleFingerDIPMiddleFingerTIPLeftBone = new Bone(JointType.MiddleFingerDIPLeft, JointType.MiddleFingerTIPLeft);

		public static Bone RingFingerMCPRingFingerPIPLeftBone = new Bone(JointType.RingFingerMCPLeft, JointType.RingFingerPIPLeft);
		public static Bone RingFingerPIPRingFingerDIPLeftBone = new Bone(JointType.RingFingerPIPLeft, JointType.RingFingerDIPLeft);
		public static Bone RingFingerDIPRingFingerTIPLeftBone = new Bone(JointType.RingFingerDIPLeft, JointType.RingFingerTIPLeft);

		public static Bone WristPinkyMCPLeftBone = new Bone(JointType.WristLeft, JointType.PinkyMCPLeft);
		public static Bone PinkyMCPPinkyPIPLeftBone = new Bone(JointType.PinkyMCPLeft, JointType.PinkyPIPLeft);
		public static Bone PinkyPIPPinkyDIPLeftBone = new Bone(JointType.PinkyPIPLeft, JointType.PinkyDIPLeft);
		public static Bone PinkyDIPPinkyTIPLeftBone = new Bone(JointType.PinkyDIPLeft, JointType.PinkyTIPLeft);

		public static Bone ThumbIPIndexFingerMCPLeftBone = new Bone(JointType.ThumbIPLeft, JointType.IndexFingerMCPLeft);
		public static Bone IndexFingerMCPMiddleFingerMCPLeftBone = new Bone(JointType.IndexFingerMCPLeft, JointType.MiddleFingerMCPLeft);
		public static Bone MiddleFingerMCPRingFingerMCPLeftBone = new Bone(JointType.MiddleFingerMCPLeft, JointType.RingFingerMCPLeft);
		public static Bone RingFingerMCPPinkyMCPLeftBone = new Bone(JointType.RingFingerMCPLeft, JointType.PinkyMCPLeft);

		public static List<Bone> RightHandBones = new[] { WristThumbCMCRightBone, ThumbCMCThumbMCPRightBone, ThumbMCPThumbIPRightBone, ThumbIPThumbTIPRightBone,
			WristIndexFingerMCPRightBone, IndexFingerMCPIndexFingerPIPRightBone, IndexFingerPIPIndexFingerDIPRightBone, IndexFingerDIPIndexFingerTIPRightBone,
			MiddleFingerMCPMiddleFingerPIPRightBone, MiddleFingerPIPMiddleFingerDIPRightBone, MiddleFingerDIPMiddleFingerTIPRightBone,
			RingFingerMCPRingFingerPIPRightBone, RingFingerPIPRingFingerDIPRightBone, RingFingerDIPRingFingerTIPRightBone,
			WristPinkyMCPRightBone, PinkyMCPPinkyPIPRightBone, PinkyPIPPinkyDIPRightBone, PinkyDIPPinkyTIPRightBone,
			ThumbIPIndexFingerMCPRightBone, IndexFingerMCPMiddleFingerMCPRightBone, MiddleFingerMCPRingFingerMCPRightBone, RingFingerMCPPinkyMCPRightBone}.ToList();

		public static List<Bone> LeftHandBones = new[] { WristThumbCMCLeftBone, ThumbCMCThumbMCPLeftBone, ThumbMCPThumbIPLeftBone, ThumbIPThumbTIPLeftBone,
			WristIndexFingerMCPLeftBone, IndexFingerMCPIndexFingerPIPLeftBone, IndexFingerPIPIndexFingerDIPLeftBone, IndexFingerDIPIndexFingerTIPLeftBone,
			MiddleFingerMCPMiddleFingerPIPLeftBone, MiddleFingerPIPMiddleFingerDIPLeftBone, MiddleFingerDIPMiddleFingerTIPLeftBone,
			RingFingerMCPRingFingerPIPLeftBone, RingFingerPIPRingFingerDIPLeftBone, RingFingerDIPRingFingerTIPLeftBone,
			WristPinkyMCPLeftBone, PinkyMCPPinkyPIPLeftBone, PinkyPIPPinkyDIPLeftBone, PinkyDIPPinkyTIPLeftBone,
			ThumbIPIndexFingerMCPLeftBone, IndexFingerMCPMiddleFingerMCPLeftBone, MiddleFingerMCPRingFingerMCPLeftBone, RingFingerMCPPinkyMCPLeftBone}.ToList();

		public static List<Bone> AllBones = RightHandBones.Concat(LeftHandBones).ToList();
	}
}
