using System;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record
{
	[Flags]
	public enum RecordOptions
	{
		Color = 1,
		Bodies = 2,
		All = 3
	}
}
