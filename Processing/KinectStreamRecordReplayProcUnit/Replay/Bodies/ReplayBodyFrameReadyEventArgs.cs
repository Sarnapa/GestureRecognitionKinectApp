using System;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Bodies
{
	public class ReplayBodyFrameReadyEventArgs : EventArgs
	{
		public ReplayBodyFrame BodyFrame
		{
			get; set;
		}
	}
}
