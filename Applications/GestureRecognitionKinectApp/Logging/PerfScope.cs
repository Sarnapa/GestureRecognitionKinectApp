using System;
using System.Diagnostics;
using Serilog;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Logging
{
	public sealed class PerfScope: IDisposable
	{
		#region Private methods
		private readonly string operation;
		private readonly Stopwatch sw;
		private readonly object? props;
		private bool completed;
		#endregion

		#region Constructors
		private PerfScope(string operation, object? props)
		{
			this.operation = operation;
			this.props = props;
			this.sw = Stopwatch.StartNew();
			// Log.Information("Started {Operation} {@Props}", this.operation, this.props);
		}
		#endregion

		#region Public methods
		public static PerfScope Measure(string operation, object props = null)
		{
			return new PerfScope(operation, props);
		}

		public void Complete(object resultProps = null)
		{
			if (this.completed) 
				return;
			
			this.completed = true;
			this.sw.Stop();
			Log.Information("Completed {Operation} in {durationMs} ms {@StartProps} {@ResultProps}",
				this.operation, this.sw.ElapsedMilliseconds, this.props, resultProps);
		}

		/// <summary>Wywoła się automatycznie, gdy zapomnisz o Complete().</summary>
		public void Dispose()
		{
			Complete();
		}
		#endregion
	}
}
