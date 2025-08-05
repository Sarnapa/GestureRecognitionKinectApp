using System;

namespace GestureRecognition.Processing.StreamRecordReplayProcUnit.Replay.Color
{
	public class ReplayColorFrameReadyEventArgs : EventArgs
	{
		public ReplayColorFrame ColorFrame
		{
			get; set;
		}
	}
}
