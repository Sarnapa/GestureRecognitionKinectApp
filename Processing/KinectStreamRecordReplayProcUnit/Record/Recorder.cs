using System;
using System.IO;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Bodies;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record.Color;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Record
{
	public class Recorder : IDisposable
	{
		#region Private fields
		private Stream recordStream;
		private readonly BinaryWriter writer;

		private DateTime previousFlushDate;

		private readonly ColorRecorder colorRecoder;
		private readonly BodyRecorder bodyRecorder;
		#endregion

		#region Public properties
		public RecordOptions Options
		{
			get; set;
		}
		#endregion

		#region Constructors
		public Recorder(RecordOptions options, Stream recordStream) : this(options, recordStream, 1.0f)
		{}

		public Recorder(RecordOptions options, Stream recordStream, float resizingCoef)
		{
			this.Options = options;

			this.recordStream = recordStream;
			this.writer = new BinaryWriter(this.recordStream);

			this.writer.Write((int)this.Options);

			if ((this.Options & RecordOptions.Color) != 0)
			{
				this.colorRecoder = new ColorRecorder(this.writer, resizingCoef);
			}
			if ((this.Options & RecordOptions.Bodies) != 0)
			{
				this.bodyRecorder = new BodyRecorder(this.writer, resizingCoef);
			}

			this.previousFlushDate = DateTime.Now;
		}
		#endregion

		#region Public methods
		public void Record(ColorFrame frame)
		{
			if (this.writer == null)
				throw new Exception("This recorder is stopped");

			if (this.colorRecoder == null)
				throw new Exception("Color recording is not actived on this KinectRecorder");

			this.colorRecoder.Record(frame);
			Flush();
		}

		public void Record(BodyFrame frame, (BodyData, BodyJointsColorSpacePointsDict)[] bodies)
		{
			if (frame == null)
				throw new ArgumentNullException(nameof(frame));

			if (this.writer == null)
				throw new Exception("This recorder is stopped");

			if (this.bodyRecorder == null)
				throw new Exception("Body recording is not actived on this KinectRecorder");

			this.bodyRecorder.Record(frame, bodies);
			Flush();
		}

		public void Stop()
		{
			if (this.writer == null)
				throw new Exception("This recorder is already stopped");

			this.writer.Close();
			this.writer.Dispose();

			this.recordStream.Dispose();
			this.recordStream = null;
		}
		#endregion

		#region IDisposable implementation
		public void Dispose()
		{
			this.writer.Close();
			this.writer.Dispose();

			if (this.recordStream != null)
			{
				this.recordStream.Dispose();
				this.recordStream = null;
			}
		}
		#endregion

		#region Private methods
		private void Flush()
		{
			var now = DateTime.Now;

			if (now.Subtract(this.previousFlushDate).TotalSeconds > 60)
			{
				this.previousFlushDate = now;
				this.writer.Flush();
			}
		}
		#endregion
	}
}
