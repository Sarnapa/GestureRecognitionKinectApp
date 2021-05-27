using System;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Color
{
	public class ReplayColorFrameReadyEventArgs : EventArgs
	{
		public ReplayColorFrame ColorFrame
		{
			get; set;
		}
	}
}
