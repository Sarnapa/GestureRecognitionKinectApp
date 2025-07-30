using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using BonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.BonesDefinitions;
using MediaPipeHandLandmarksBonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.MediaPipeHandLandmarksBonesDefinitions;
//using MediaPipePoseLandmarksBonesDefs = GestureRecognition.Processing.BaseClassLib.Structures.Body.MediaPipePoseLandmarksBonesDefinitions;

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
			// From MediaPipe Pose Landmarks Detection Model
			JointType.IndexLeft, JointType.IndexRight, JointType.PinkyLeft, JointType.PinkyRight, 
			// From MediaPipe Hand Landmarks Detection Model
			JointType.ThumbCMCLeft, JointType.ThumbCMCRight, JointType.ThumbMCPLeft, JointType.ThumbMCPRight,
			JointType.ThumbIPLeft, JointType.ThumbIPRight, JointType.ThumbTIPLeft, JointType.ThumbTIPRight,
			JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight, 
			JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight,
			JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight, JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight,
			JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight,
			JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight,
			JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight,
			JointType.PinkyMCPLeft, JointType.PinkyMCPRight, JointType.PinkyPIPLeft, JointType.PinkyPIPRight,
			JointType.PinkyDIPLeft, JointType.PinkyDIPRight, JointType.PinkyTIPLeft, JointType.PinkyTIPRight,
			};

		/// <summary>
		/// Bones taking part in gesture recognition processing
		/// </summary>
		//public static Bone[] GestureRecognitionBones = new Bone[] { ElbowLeftWristLeftBone, ElbowRightWristRightBone,
		//	WristLeftHandLeftBone, WristRightHandRightBone, HandLeftHandTipLeftBone, HandRightHandTipRightBone,
		//	};

		//public static Bone[] GestureRecognitionBones = new Bone[] { MediaPipePoseLandmarksBonesDefs.ElbowLeftWristLeftBone, MediaPipePoseLandmarksBonesDefs.ElbowRightWristRightBone,
		//	MediaPipePoseLandmarksBonesDefs.WristLeftHandLeftBone, MediaPipePoseLandmarksBonesDefs.WristRightHandRightBone,
		//	MediaPipePoseLandmarksBonesDefs.HandLeftPinkyLeftBone, MediaPipePoseLandmarksBonesDefs.HandRightPinkyRightBone,
		//	MediaPipePoseLandmarksBonesDefs.HandLeftIndexLeftBone, MediaPipePoseLandmarksBonesDefs.HandRightIndexRightBone,
		//	MediaPipePoseLandmarksBonesDefs.HandLeftThumbLeftBone, MediaPipePoseLandmarksBonesDefs.HandRightThumbRightBone
		//	};

		public static Bone[] GestureRecognitionBones = MediaPipeHandLandmarksBonesDefs.AllBones.ToArray();
	}
}
