using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using BonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.BonesDefinitions;
using MediaPipeBonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.MediaPipeBonesDefinitions;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public static class GestureRecognitionDefinitions
	{
		/// <summary>
		/// Joints taking part in gesture recognition processing
		/// </summary>
		public static JointType[] GestureRecognitionJoints = new JointType[] { JointType.ElbowLeft, JointType.ElbowRight,
			JointType.WristLeft, JointType.WristRight, JointType.HandLeft, JointType.HandRight, JointType.ThumbLeft, JointType.ThumbRight,
			JointType.HandTipLeft, JointType.HandTipRight,
			// From MediaPipe
			JointType.IndexLeft, JointType.IndexRight, JointType.PinkyLeft, JointType.PinkyRight };

		/// <summary>
		/// Bones taking part in gesture recognition processing
		/// </summary>
		//public static Bone[] GestureRecognitionBones = new Bone[] { ElbowLeftWristLeftBone, ElbowRightWristRightBone,
		//	WristLeftHandLeftBone, WristRightHandRightBone, HandLeftHandTipLeftBone, HandRightHandTipRightBone,
		//	};

		public static Bone[] GestureRecognitionBones = new Bone[] { MediaPipeBonesDefs.ElbowLeftWristLeftBone, MediaPipeBonesDefs.ElbowRightWristRightBone,
			MediaPipeBonesDefs.WristLeftHandLeftBone, MediaPipeBonesDefs.WristRightHandRightBone,
			MediaPipeBonesDefs.HandLeftPinkyLeftBone, MediaPipeBonesDefs.HandRightPinkyRightBone,
			MediaPipeBonesDefs.HandLeftIndexLeftBone, MediaPipeBonesDefs.HandRightIndexRightBone,
			MediaPipeBonesDefs.HandLeftThumbLeftBone, MediaPipeBonesDefs.HandRightThumbRightBone
			};
	}
}
