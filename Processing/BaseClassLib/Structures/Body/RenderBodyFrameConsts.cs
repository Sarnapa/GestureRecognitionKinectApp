// Just in case, everything is adjusted to the Kinect resolution, which is 1920 x 1080.

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	public static class KinectRenderBodyFrameConsts
	{
		public const double HAND_SIZE = 12;
		public const double JOINT_THICKNESS = 6;
		public const double GESTURE_RECOGNITION_JOINT_THICKNESS = 10;
		public const double BODY_SKELETON_THICKNESS = 8;

		public static readonly JointType[] JOINTS_TO_IGNORE = {
			JointType.KneeLeft, JointType.KneeRight, 
			JointType.AnkleLeft, JointType.AnkleRight,
			JointType.FootLeft, JointType.FootRight,
		};
	}

	public static class MediaPipePoseLandmarksRenderBodyFrameConsts
	{
		public const double HAND_SIZE = 12;
		public const double JOINT_THICKNESS = 6;
		public const double GESTURE_RECOGNITION_JOINT_THICKNESS = 10;
		public const double BODY_SKELETON_THICKNESS = 8;

		public static readonly JointType[] JOINTS_TO_IGNORE = {
			JointType.Nose,
			JointType.KneeLeft, JointType.KneeRight, 
			JointType.AnkleLeft, JointType.AnkleRight,
			JointType.FootLeft, JointType.FootRight,
			JointType.EyeInnerLeft, JointType.EyeLeft, JointType.EyeOuterLeft,
			JointType.EyeInnerRight, JointType.EyeRight, JointType.EyeOuterRight,
			JointType.EarLeft, JointType.EarRight,
			JointType.MouthLeft, JointType.MouthRight,
			JointType.HeelLeft, JointType.HeelRight,
			JointType.FootIndexLeft, JointType.FootIndexRight
			};
	}

	public static class MediaPipeHandLandmarksRenderBodyFrameConsts
	{
		public const double HAND_SIZE = 10;
		public const double JOINT_THICKNESS = 4;
		public const double GESTURE_RECOGNITION_JOINT_THICKNESS = 8;
		public const double BODY_SKELETON_THICKNESS = 6;

		public static readonly JointType[] JOINTS_TO_IGNORE = {};
	}
}
