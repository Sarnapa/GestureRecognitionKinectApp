using System;

namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer
{
	[Flags]
	public enum FrameSourceTypes
	{
		None = 0,
		Color = 1,
		Infrared = 2,
		LongExposureInfrared = 4,
		Depth = 8,
		BodyIndex = 0x10,
		Body = 0x20,
		Audio = 0x40
	}
}
