namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	/// <summary>
	/// Points from the Kinect controller,
	/// in parentheses the equivalents in MediaPipe, 
	/// those that were not in Kinect but are in MediaPipe at the end
	/// </summary>
	public enum JointType
	{ 
		SpineBase, // without equivalents in MediaPipe Pose Landmarks Detection Model
		SpineMid, // without equivalents in MediaPipe Pose Landmarks Detection Model
		Neck, // without equivalents in MediaPipe Pose Landmarks Detection Model
		Head, // without equivalents in MediaPipe Pose Landmarks Detection Model
		ShoulderLeft, // MediaPipe Pose Landmarks Detection Model index: 11
		ElbowLeft, // MediaPipe Pose Landmarks Detection Model index: 13
		WristLeft, // MediaPipe Pose Landmarks Detection Model index: 15, MediaPipe Hand Landmarks Detection Model index: 0
		HandLeft, // without equivalents in MediaPipe Pose Landmarks Detection Model
		ShoulderRight, // MediaPipe Pose Landmarks Detection Model index: 12
		ElbowRight, // MediaPipe Pose Landmarks Detection Model index: 14
		WristRight, // MediaPipe Pose Landmarks Detection Model index: 16, MediaPipe Hand Landmarks Detection Model index: 0
		HandRight, // without equivalents in MediaPipe Pose Landmarks Detection Model
		HipLeft, // MediaPipe Pose Landmarks Detection Model index: 23
		KneeLeft, // MediaPipe Pose Landmarks Detection Model index: 25
		AnkleLeft, // MediaPipe Pose Landmarks Detection Model index: 27
		FootLeft, // without equivalents in MediaPipe Pose Landmarks Detection Model
		HipRight, // MediaPipe Pose Landmarks Detection Model index: 24
		KneeRight, // MediaPipe Pose Landmarks Detection Model index: 26
		AnkleRight, // MediaPipe Pose Landmarks Detection Model index: 28
		FootRight, // without equivalents in MediaPipe Pose Landmarks Detection Model
		SpineShoulder, // without equivalents in MediaPipe Pose Landmarks Detection Model
		HandTipLeft, // without equivalents in MediaPipe Pose Landmarks Detection Model
		ThumbLeft, // MediaPipe Pose Landmarks Detection Model index: 21
		HandTipRight, // without equivalents in MediaPipe Pose Landmarks Detection Model
		ThumbRight, // MediaPipe Pose Landmarks Detection Model index: 22
		// From MediaPipe Pose Landmarks Detection Model
		Nose, // MediaPipe Pose Landmarks Detection Model index: 0
		EyeInnerLeft, // MediaPipe Pose Landmarks Detection Model index: 1
		EyeLeft, // MediaPipe Pose Landmarks Detection Model index: 2
		EyeOuterLeft, // MediaPipe Pose Landmarks Detection Model index: 3
		EyeInnerRight, // MediaPipe Pose Landmarks Detection Model index: 4
		EyeRight, // MediaPipe Pose Landmarks Detection Model index: 5
		EyeOuterRight, // MediaPipe Pose Landmarks Detection Model index: 6
		EarLeft, // MediaPipe Pose Landmarks Detection Model index: 7
		EarRight, // MediaPipe Pose Landmarks Detection Model index: 8
		MouthLeft, // MediaPipe Pose Landmarks Detection Model index: 9
		MouthRight, // MediaPipe Pose Landmarks Detection Model index: 10
		PinkyLeft, // MediaPipe Pose Landmarks Detection Model index: 17
		PinkyRight, // MediaPipe Pose Landmarks Detection Model index: 18
		IndexLeft, // MediaPipe Pose Landmarks Detection Model index: 19
		IndexRight, // MediaPipe Pose Landmarks Detection Model index: 20
		HeelLeft, // MediaPipe Pose Landmarks Detection Model index: 29
		HeelRight, // MediaPipe Pose Landmarks Detection Model index: 30
		FootIndexLeft, // MediaPipe Pose Landmarks Detection Model index: 31
		FootIndexRight, // MediaPipe Pose Landmarks Detection Model index: 32
		// From MediaPipe Pose Landmarks Detection Model
		ThumbCMCLeft,
		ThumbCMCRight,
		ThumbMCPLeft,
		ThumbMCPRight,
		ThumbIPLeft,
		ThumbIPRight,
		ThumbTIPLeft,
		ThumbTIPRight,
		IndexFingerMCPLeft,
		IndexFingerMCPRight,
		IndexFingerPIPLeft,
		IndexFingerPIPRight,
		IndexFingerDIPLeft,
		IndexFingerDIPRight,
		IndexFingerTIPLeft,
		IndexFingerTIPRight,
		MiddleFingerMCPLeft,
		MiddleFingerMCPRight,
		MiddleFingerPIPLeft,
		MiddleFingerPIPRight,
		MiddleFingerDIPLeft,
		MiddleFingerDIPRight,
		MiddleFingerTIPLeft,
		MiddleFingerTIPRight,
		RingFingerMCPLeft,
		RingFingerMCPRight,
		RingFingerPIPLeft,
		RingFingerPIPRight,
		RingFingerDIPLeft,
		RingFingerDIPRight,
		RingFingerTIPLeft,
		RingFingerTIPRight,
		PinkyMCPLeft,
		PinkyMCPRight,
		PinkyPIPLeft,
		PinkyPIPRight,
		PinkyDIPLeft,
		PinkyDIPRight,
		PinkyTIPLeft,
		PinkyTIPRight,
	}
}
