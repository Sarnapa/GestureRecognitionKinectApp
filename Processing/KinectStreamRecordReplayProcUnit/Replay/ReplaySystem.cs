using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay
{
	#region ReplaySystem
	internal class ReplaySystem<T> : ReplayBase<T> where T : ReplayFrame, new()
	{
		#region ReplayBase overriders
		internal override void AddFrame(BinaryReader reader)
		{
			T frame = new T();

			frame.CreateFromReader(reader);

			this.frames.Add(frame);
		}
		#endregion
	}
	#endregion

	#region ReplayBase
	internal abstract class ReplayBase<T> where T : ReplayFrame, new()
	{
		#region Private / protected fields
		private CancellationTokenSource cancellationTokenSource;
		protected readonly List<T> frames = new List<T>();
		#endregion

		#region Public properties
		public bool IsFinished
		{
			get; private set;
		}
		#endregion

		#region Events
		internal virtual event Action<T> FrameReady;
		#endregion

		#region Public methods
		public void Start()
		{
			Stop();

			this.IsFinished = false;

			this.cancellationTokenSource = new CancellationTokenSource();
			var token = cancellationTokenSource.Token;

			Task.Factory.StartNew(() =>
			{
				foreach (T frame in this.frames)
				{
					Thread.Sleep(TimeSpan.FromMilliseconds(frame.TimeStamp));

					if (token.IsCancellationRequested)
						break;

					if (this.FrameReady != null)
						this.FrameReady(frame);
				}

				this.IsFinished = true;
			}, token);
		}

		public void Stop()
		{
			if (this.cancellationTokenSource == null)
				return;

			this.cancellationTokenSource.Cancel();
		}
		#endregion

		#region Abstract methods
		internal abstract void AddFrame(BinaryReader reader);
		#endregion
	}
	#endregion
}
