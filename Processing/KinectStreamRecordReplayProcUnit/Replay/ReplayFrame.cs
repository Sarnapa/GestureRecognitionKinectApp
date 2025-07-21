using System.IO;
using MessagePack;

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
		internal abstract void CreateFromReader(BinaryReader reader, MessagePackSerializerOptions serializerOptions);
		#endregion
	}
}
