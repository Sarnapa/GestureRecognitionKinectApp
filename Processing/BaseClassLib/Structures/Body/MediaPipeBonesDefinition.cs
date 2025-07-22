using System.Collections.Generic;
using System.Linq;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	public static class MediaPipesBonesDefinitions
	{
		// Head
		public static Bone MouthRightMouthLeftBone = new Bone(JointType.MouthRight, JointType.MouthLeft);
		public static Bone NoseEyeRightBone = new Bone(JointType.Nose, JointType.EyeRight);
		public static Bone EyeRightEarRightBone = new Bone(JointType.EyeRight, JointType.EarRight);
		public static Bone NoseEyeLeftBone = new Bone(JointType.Nose, JointType.EyeLeft);
		public static Bone EyeLeftEarLeftBone = new Bone(JointType.EyeLeft, JointType.EarLeft);

		// Torso
		public static Bone ShoulderRightShoulderLeftBone = new Bone(JointType.ShoulderRight, JointType.ShoulderLeft);
		public static Bone HipRightHipLeftBone = new Bone(JointType.HipLeft, JointType.HandRight);
		public static Bone ShoulderRightHipRightBone = new Bone(JointType.ShoulderRight, JointType.HipRight);
		public static Bone ShoulderLeftHipLeftBone = new Bone(JointType.ShoulderLeft, JointType.HipLeft);

		// Right Arm
		public static Bone ShoulderRightElbowRightBone = new Bone(JointType.ShoulderRight, JointType.ElbowRight);
		public static Bone ElbowRightWristRightBone = new Bone(JointType.ElbowRight, JointType.WristRight);
		public static Bone WristRightPinkyRightBone = new Bone(JointType.WristRight, JointType.PinkyRight);
		public static Bone WristRightIndexRightBone = new Bone(JointType.WristRight, JointType.IndexRight);
		public static Bone WristRightThumbRightBone = new Bone(JointType.WristRight, JointType.ThumbRight);
		public static Bone PinkyRightIndexRightBone = new Bone(JointType.PinkyRight, JointType.IndexRight);

		// Left Arm
		public static Bone ShoulderLeftElbowLeftBone = new Bone(JointType.ShoulderLeft, JointType.ElbowLeft);
		public static Bone ElbowLeftWristLeftBone = new Bone(JointType.ElbowLeft, JointType.WristLeft);
		public static Bone WristLeftPinkyLeftBone = new Bone(JointType.WristLeft, JointType.PinkyLeft);
		public static Bone WristLeftIndexLeftBone = new Bone(JointType.WristLeft, JointType.IndexLeft);
		public static Bone WristLeftThumbLeftBone = new Bone(JointType.WristLeft, JointType.ThumbLeft);
		public static Bone PinkyLeftIndexLeftBone = new Bone(JointType.PinkyLeft, JointType.IndexLeft);

		// Right Leg
		public static Bone HipRightKneeRightBone = new Bone(JointType.HipRight, JointType.KneeRight);
		public static Bone KneeRightAnkleRightBone = new Bone(JointType.KneeRight, JointType.AnkleRight);
		public static Bone AnkleRightHeelRightBone = new Bone(JointType.AnkleRight, JointType.HeelRight);
		public static Bone AnkleRightFootIndexRight = new Bone(JointType.AnkleRight, JointType.FootIndexRight);
		public static Bone HeelRightFootIndexRight = new Bone(JointType.HeelRight, JointType.FootIndexRight);

		// Left Leg
		public static Bone HipLeftKneeLeftBone = new Bone(JointType.HipLeft, JointType.KneeLeft);
		public static Bone KneeLeftAnkleLeftBone = new Bone(JointType.KneeLeft, JointType.AnkleLeft);
		public static Bone AnkleLeftHeelLeftBone = new Bone(JointType.AnkleLeft, JointType.HeelLeft);
		public static Bone AnkleLeftFootIndexLeft = new Bone(JointType.AnkleLeft, JointType.FootIndexLeft);
		public static Bone HeelLeftFootIndexLeft = new Bone(JointType.HeelLeft, JointType.FootIndexLeft);

		public static List<Bone> HeadBones = new[] { MouthRightMouthLeftBone, NoseEyeRightBone, EyeRightEarRightBone,
			NoseEyeLeftBone, EyeLeftEarLeftBone }.ToList();
		public static List<Bone> TorsoBones = new[] { ShoulderRightShoulderLeftBone, HipRightHipLeftBone,
			ShoulderRightHipRightBone, ShoulderLeftHipLeftBone }.ToList();
		public static List<Bone> RightArmBones = new[] { ShoulderRightElbowRightBone, ElbowRightWristRightBone,
			WristRightPinkyRightBone, WristRightIndexRightBone, WristRightThumbRightBone, PinkyRightIndexRightBone }.ToList();
		public static List<Bone> LeftArmBones = new[] { ShoulderLeftElbowLeftBone, ElbowLeftWristLeftBone,
			WristLeftPinkyLeftBone, WristLeftIndexLeftBone, WristLeftThumbLeftBone, PinkyLeftIndexLeftBone }.ToList();
		public static List<Bone> RightLegBones = new[] { HipRightKneeRightBone, KneeRightAnkleRightBone,
			AnkleRightHeelRightBone, AnkleRightFootIndexRight, HeelRightFootIndexRight }.ToList();
		public static List<Bone> LeftLegBones = new[] { HipLeftKneeLeftBone, KneeLeftAnkleLeftBone,
			AnkleLeftHeelLeftBone, AnkleLeftFootIndexLeft, HeelLeftFootIndexLeft }.ToList();
		public static List<Bone> AllBonesWithoutHeadAndLegs = TorsoBones.Concat(RightArmBones).Concat(LeftArmBones).ToList();
		public static List<Bone> AllBones = AllBonesWithoutHeadAndLegs.Concat(HeadBones).Concat(RightLegBones).Concat(LeftLegBones).ToList();
	}
}
