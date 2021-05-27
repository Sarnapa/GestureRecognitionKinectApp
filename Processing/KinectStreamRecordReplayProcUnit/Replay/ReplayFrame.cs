using System.IO;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay
{
	public abstract class ReplayFrame
	{
		#region Public properties
		public virtual long TimeStamp
		{
			get; protected set;
		}
		#endregion

		#region Internal methods
		internal abstract void CreateFromReader(BinaryReader reader);
		#endregion
	}
}
