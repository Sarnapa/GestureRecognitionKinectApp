using System;

namespace GestureRecognition.Processing.StreamRecordReplayProcUnit.Replay.Bodies
{
	public class ReplayBodyFrameReadyEventArgs : EventArgs
	{
		public ReplayBodyFrame BodyFrame
		{
			get; set;
		}
	}
}
