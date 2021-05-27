using System;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.All
{
	public class ReplayAllFramesReadyEventArgs : EventArgs
	{
		public ReplayAllFrames AllFrames
		{
			get; set;
		}
	}
}