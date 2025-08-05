using System;

namespace GestureRecognition.Processing.StreamRecordReplayProcUnit.Replay.All
{
	public class ReplayAllFramesReadyEventArgs : EventArgs
	{
		public ReplayAllFrames AllFrames
		{
			get; set;
		}
	}
}