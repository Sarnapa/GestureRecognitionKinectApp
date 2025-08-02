using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using static GestureRecognition.Processing.BaseClassLib.Structures.Body.MediaPipePoseLandmarksBonesDefinitions;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public static class MediaPipePoseLandmarksGestureRecognitionDefinitions
	{
		/// <summary>
		/// Joints taking part in gesture recognition processing
		/// </summary>
		public static JointType[] GestureRecognitionJoints = new JointType[] { 
			JointType.ElbowLeft, JointType.ElbowRight,
			JointType.WristLeft, JointType.WristRight, 
			JointType.HandLeft, JointType.HandRight, 
			JointType.ThumbLeft, JointType.ThumbRight,
			JointType.IndexLeft, JointType.IndexRight, 
			JointType.PinkyLeft, JointType.PinkyRight, 
			};

		/// <summary>
		/// Bones taking part in gesture recognition processing
		/// </summary>
		public static Bone[] GestureRecognitionBones = new Bone[] { 
			ElbowLeftWristLeftBone, ElbowRightWristRightBone,
			WristLeftHandLeftBone, WristRightHandRightBone,
			HandLeftPinkyLeftBone, HandRightPinkyRightBone,
			HandLeftIndexLeftBone, HandRightIndexRightBone,
			HandLeftThumbLeftBone, HandRightThumbRightBone
			};
	}
}
