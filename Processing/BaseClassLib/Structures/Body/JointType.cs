namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	/// <summary>
	/// Points from the Kinect controller,
	/// in parentheses the equivalents in MediaPipe, 
	/// those that were not in Kinect but are in MediaPipe at the end
	/// </summary>
	public enum JointType
	{ 
		SpineBase, // without equivalents in MediaPipe
		SpineMid, // without equivalents in MediaPipe
		Neck, // without equivalents in MediaPipe
		Head, // without equivalents in MediaPipe
		ShoulderLeft, // MediaPipe index: 11
		ElbowLeft, // MediaPipe index: 13
		WristLeft, // MediaPipe index: 15
		HandLeft, // without equivalents in MediaPipe
		ShoulderRight, // MediaPipe index: 12
		ElbowRight, // MediaPipe index: 14
		WristRight, // MediaPipe index: 16
		HandRight, // without equivalents in MediaPipe
		HipLeft, // MediaPipe index: 23
		KneeLeft, // MediaPipe index: 25
		AnkleLeft, // MediaPipe index: 27
		FootLeft, // without equivalents in MediaPipe
		HipRight, // MediaPipe index: 24
		KneeRight, // MediaPipe index: 26
		AnkleRight, // MediaPipe index: 28
		FootRight, // without equivalents in MediaPipe
		SpineShoulder, // without equivalents in MediaPipe
		HandTipLeft, // without equivalents in MediaPipe
		ThumbLeft, // MediaPipe index: 21
		HandTipRight, // without equivalents in MediaPipe
		ThumbRight, // MediaPipe index: 22
		// From MediaPipe's pose landmarks model
		Nose, // MediaPipe index: 0
		EyeInnerLeft, // MediaPipe index: 1
		EyeLeft, // MediaPipe index: 2
		EyeOuterLeft, // MediaPipe index: 3
		EyeInnerRight, // MediaPipe index: 4
		EyeRight, // MediaPipe index: 5
		EyeOuterRight, // MediaPipe index: 6
		EarLeft, // MediaPipe index: 7
		EarRight, // MediaPipe index: 8
		MouthLeft, // MediaPipe index: 9
		MouthRight, // MediaPipe index: 10
		PinkyLeft, // MediaPipe index: 17
		PinkyRight, // MediaPipe index: 18
		IndexLeft, // MediaPipe index: 19
		IndexRight, // MediaPipe index: 20
		HeelLeft, // MediaPipe index: 29
		HeelRight, // MediaPipe index: 30
		FootIndexLeft, // MediaPipe index: 31
		FootIndexRight, // MediaPipe index: 32
	}
}
