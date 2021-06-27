using System.Collections.Generic;
using System.Linq;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Kinect
{
	public static class BonesDefinitions
	{
		// Torso
		public static Bone HeadNeckBone = new Bone(JointType.Head, JointType.Neck);
		public static Bone NeckSpineShoulderBone = new Bone(JointType.Neck, JointType.SpineShoulder);
		public static Bone SpineShoulderSpineMidBone = new Bone(JointType.SpineShoulder, JointType.SpineMid);
		public static Bone SpineMidSpineBaseBone = new Bone(JointType.SpineMid, JointType.SpineBase);
		public static Bone SpineShoulderShoulderRightBone = new Bone(JointType.SpineShoulder, JointType.ShoulderRight);
		public static Bone SpineShoulderShoulderLeftBone = new Bone(JointType.SpineShoulder, JointType.ShoulderLeft);
		public static Bone SpineBaseHipRightBone = new Bone(JointType.SpineBase, JointType.HipRight);
		public static Bone SpineBaseHipLeftBone = new Bone(JointType.SpineBase, JointType.HipLeft);

		// Right Arm
		public static Bone ShoulderRightElbowRightBone = new Bone(JointType.ShoulderRight, JointType.ElbowRight);
		public static Bone ElbowRightWristRightBone = new Bone(JointType.ElbowRight, JointType.WristRight);
		public static Bone WristRightHandRightBone = new Bone(JointType.WristRight, JointType.HandRight);
		public static Bone HandRightHandTipRightBone = new Bone(JointType.HandRight, JointType.HandTipRight);
		public static Bone WristRightThumbRightBone = new Bone(JointType.WristRight, JointType.ThumbRight);

		// Left Arm
		public static Bone ShoulderLeftElbowLeftBone = new Bone(JointType.ShoulderLeft, JointType.ElbowLeft);
		public static Bone ElbowLeftWristLeftBone = new Bone(JointType.ElbowLeft, JointType.WristLeft);
		public static Bone WristLeftHandLeftBone = new Bone(JointType.WristLeft, JointType.HandLeft);
		public static Bone HandLeftHandTipLeftBone = new Bone(JointType.HandLeft, JointType.HandTipLeft);
		public static Bone WristLeftThumbLeftBone = new Bone(JointType.WristLeft, JointType.ThumbLeft);

		// Right Leg
		public static Bone HipRightKneeRightBone = new Bone(JointType.HipRight, JointType.KneeRight);
		public static Bone KneeRightAnkleRightBone = new Bone(JointType.KneeRight, JointType.AnkleRight);
		public static Bone AnkleRightFootRightBone = new Bone(JointType.AnkleRight, JointType.FootRight);

		// Left Leg
		public static Bone HipLeftKneeLeftBone = new Bone(JointType.HipLeft, JointType.KneeLeft);
		public static Bone KneeLeftAnkleLeftBone = new Bone(JointType.KneeLeft, JointType.AnkleLeft);
		public static Bone AnkleLeftFootLeftBone = new Bone(JointType.AnkleLeft, JointType.FootLeft);

		public static List<Bone> TorsoBones = new[] { HeadNeckBone, NeckSpineShoulderBone, SpineShoulderSpineMidBone,
			SpineMidSpineBaseBone, SpineShoulderShoulderRightBone, SpineShoulderShoulderLeftBone, SpineBaseHipRightBone, SpineBaseHipLeftBone }.ToList();
		public static List<Bone> RightArmBones = new[] { ShoulderRightElbowRightBone, ElbowRightWristRightBone, WristRightHandRightBone,
			HandRightHandTipRightBone, WristRightThumbRightBone }.ToList();
		public static List<Bone> LeftArmBones = new[] { ShoulderLeftElbowLeftBone, ElbowLeftWristLeftBone, WristLeftHandLeftBone,
			HandLeftHandTipLeftBone, WristLeftThumbLeftBone }.ToList();
		public static List<Bone> RightLegBones = new[] { HipRightKneeRightBone, KneeRightAnkleRightBone, AnkleRightFootRightBone }.ToList();
		public static List<Bone> LeftLegBones = new[] { HipLeftKneeLeftBone, KneeLeftAnkleLeftBone, AnkleLeftFootLeftBone }.ToList();
		public static List<Bone> AllBonesWithoutLegs = TorsoBones.Concat(RightArmBones).Concat(LeftArmBones).ToList();
		public static List<Bone> AllBones = AllBonesWithoutLegs.Concat(RightLegBones).Concat(LeftLegBones).ToList();
	}
}
