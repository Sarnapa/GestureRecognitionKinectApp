using System;
using System.IO;
using System.Threading;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.All;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Bodies;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.Color;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay
{
	public class KinectReplay : IDisposable
	{
		#region Private fields
		private BinaryReader reader;
		private Stream stream;
		private readonly SynchronizationContext synchronizationContext;

		private ReplaySystem<ReplayColorFrame> colorReplay;
		private ReplaySystem<ReplayBodyFrame> bodyReplay;
		private ReplayAllFramesSystem allReplay;
		#endregion

		#region Public properties
		public bool Started
		{
			get; internal set;
		}

		public bool IsFinished
		{
			get
			{
				if (this.colorReplay != null && !this.colorReplay.IsFinished)
					return false;

				if (this.bodyReplay != null && !this.bodyReplay.IsFinished)
					return false;

				if (this.allReplay != null && !this.allReplay.IsFinished)
					return false;

				return true;
			}
		}
		#endregion

		#region Events
		public event EventHandler<ReplayColorFrameReadyEventArgs> ColorFrameReady;
		public event EventHandler<ReplayBodyFrameReadyEventArgs> BodyFrameReady;
		public event EventHandler<ReplayAllFramesReadyEventArgs> AllFramesReady;
		public event Action Finished;
		#endregion

		#region Constructors
		public KinectReplay(Stream stream)
		{
			this.stream = stream;
			this.reader = new BinaryReader(stream);

			this.synchronizationContext = SynchronizationContext.Current;

			var options = (KinectRecordOptions)reader.ReadInt32();

			if ((options & KinectRecordOptions.All) != 0)
			{
				this.allReplay = new ReplayAllFramesSystem();
				while (this.reader.BaseStream.Position != this.reader.BaseStream.Length)
					this.allReplay.AddFrame(reader);
			}
			else
			{
				if ((options & KinectRecordOptions.Color) != 0)
					this.colorReplay = new ReplaySystem<ReplayColorFrame>();
				if ((options & KinectRecordOptions.Bodies) != 0)
					this.bodyReplay = new ReplaySystem<ReplayBodyFrame>();

				while (this.reader.BaseStream.Position != this.reader.BaseStream.Length)
				{
					var header = (KinectRecordOptions)reader.ReadInt32();
					switch (header)
					{
						case KinectRecordOptions.Color:
							this.colorReplay.AddFrame(this.reader);
							break;
						case KinectRecordOptions.Bodies:
							this.bodyReplay.AddFrame(this.reader);
							break;
					}
				}
			}
		}
		#endregion

		#region Public methods
		public void Start()
		{
			if (this.Started)
				throw new Exception("KinectReplay already started");

			this.Started = true;

			if (this.colorReplay != null)
			{
				this.colorReplay.Start();
				this.colorReplay.FrameReady += frame => this.synchronizationContext.Send(state =>
				{
					if (this.ColorFrameReady != null)
						this.ColorFrameReady(this, new ReplayColorFrameReadyEventArgs { ColorFrame = frame });
				}, null);
				this.colorReplay.Finished += ReplaySystem_Finished;
			}

			if (this.bodyReplay != null)
			{
				this.bodyReplay.Start();
				this.bodyReplay.FrameReady += frame => this.synchronizationContext.Send(state =>
				{
					if (this.BodyFrameReady != null)
						this.BodyFrameReady(this, new ReplayBodyFrameReadyEventArgs { BodyFrame = frame });
				}, null);
				this.bodyReplay.Finished += ReplaySystem_Finished;
			}

			if (allReplay != null)
			{
				this.allReplay.Start();
				this.allReplay.FrameReady += frame => this.synchronizationContext.Send(state =>
				{
					if (this.AllFramesReady != null)
						this.AllFramesReady(this, new ReplayAllFramesReadyEventArgs { AllFrames = frame });
				}, null);
				this.allReplay.Finished += ReplaySystem_Finished;
			}
		}

		public void Stop()
		{
			if (this.colorReplay != null)
			{
				this.colorReplay.Stop();
				this.colorReplay.Finished -= ReplaySystem_Finished;
			}

			if (this.bodyReplay != null)
			{
				this.bodyReplay.Stop();
				this.bodyReplay.Finished -= ReplaySystem_Finished;
			}

			if (this.allReplay != null)
			{
				this.allReplay.Stop();
				this.allReplay.Finished -= ReplaySystem_Finished;
			}

			this.Started = false;
		}
		#endregion

		#region Private methods

		#region Events handlers
		private void ReplaySystem_Finished()
		{
			Finished();
		}
		#endregion

		#endregion

		#region IDisposable implementation
		public void Dispose()
		{
			Stop();

			this.colorReplay = null;
			this.bodyReplay = null;
			this.allReplay = null;

			if (this.reader != null)
			{
				this.reader.Dispose();
				this.reader = null;
			}

			if (this.stream != null)
			{
				this.stream.Dispose();
				this.stream = null;
			}
			#endregion
		}
	}
}
