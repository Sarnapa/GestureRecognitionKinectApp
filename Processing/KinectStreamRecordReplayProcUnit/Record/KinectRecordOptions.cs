using System;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record
{
	[Flags]
	public enum KinectRecordOptions
	{
		Color = 1,
		Bodies = 2,
		All = 3
	}
}
