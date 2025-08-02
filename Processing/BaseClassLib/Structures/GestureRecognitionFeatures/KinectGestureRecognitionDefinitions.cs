using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using static GestureRecognition.Processing.BaseClassLib.Structures.Body.KinectBonesDefinitions;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public static class KinectGestureRecognitionDefinitions
	{
		/// <summary>
		/// Joints taking part in gesture recognition processing
		/// </summary>
		public static JointType[] GestureRecognitionJoints = new JointType[] { 
			JointType.ElbowLeft, JointType.ElbowRight,
			JointType.WristLeft, JointType.WristRight, 
			JointType.HandLeft, JointType.HandRight, 
			JointType.ThumbLeft, JointType.ThumbRight,
			JointType.HandTipLeft, JointType.HandTipRight
			};

		/// <summary>
		/// Bones taking part in gesture recognition processing
		/// </summary>
		public static Bone[] GestureRecognitionBones = new Bone[] { 
			ElbowLeftWristLeftBone, ElbowRightWristRightBone,
			WristLeftHandLeftBone, WristRightHandRightBone, 
			HandLeftHandTipLeftBone, HandRightHandTipRightBone,
			};
	}
}
