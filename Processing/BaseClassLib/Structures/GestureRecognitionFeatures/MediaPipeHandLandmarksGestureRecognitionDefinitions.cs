using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using static GestureRecognition.Processing.BaseClassLib.Structures.Body.MediaPipeHandLandmarksBonesDefinitions;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public static class MediaPipeHandLandmarksGestureRecognitionDefinitions
	{
		/// <summary>
		/// Joints taking part in gesture recognition processing
		/// </summary>
		public static JointType[] GestureRecognitionJoints = new JointType[] {
			JointType.WristLeft, JointType.WristRight,
			JointType.ThumbCMCLeft, JointType.ThumbCMCRight, 
			JointType.ThumbMCPLeft, JointType.ThumbMCPRight,
			JointType.ThumbIPLeft, JointType.ThumbIPRight, 
			JointType.ThumbTIPLeft, JointType.ThumbTIPRight,
			JointType.IndexFingerMCPLeft, JointType.IndexFingerMCPRight, 
			JointType.IndexFingerPIPLeft, JointType.IndexFingerPIPRight,
			JointType.IndexFingerDIPLeft, JointType.IndexFingerDIPRight, 
			JointType.IndexFingerTIPLeft, JointType.IndexFingerTIPRight,
			JointType.MiddleFingerMCPLeft, JointType.MiddleFingerMCPRight,
			JointType.MiddleFingerPIPLeft, JointType.MiddleFingerPIPRight,
			JointType.MiddleFingerDIPLeft, JointType.MiddleFingerDIPRight, 
			JointType.MiddleFingerTIPLeft, JointType.MiddleFingerTIPRight,
			JointType.RingFingerMCPLeft, JointType.RingFingerMCPRight, 
			JointType.RingFingerPIPLeft, JointType.RingFingerPIPRight,
			JointType.RingFingerDIPLeft, JointType.RingFingerDIPRight, 
			JointType.RingFingerTIPLeft, JointType.RingFingerTIPRight,
			JointType.PinkyMCPLeft, JointType.PinkyMCPRight, 
			JointType.PinkyPIPLeft, JointType.PinkyPIPRight,
			JointType.PinkyDIPLeft, JointType.PinkyDIPRight, 
			JointType.PinkyTIPLeft, JointType.PinkyTIPRight,
			JointType.HandLeft, JointType.HandRight
			};

		/// <summary>
		/// Bones taking part in gesture recognition processing
		/// </summary>
		public static Bone[] GestureRecognitionBones = AllBones.ToArray();
	}
}
