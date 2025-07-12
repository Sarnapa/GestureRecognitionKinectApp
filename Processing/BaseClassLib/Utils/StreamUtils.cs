using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GestureRecognition.Processing.BaseClassLib.Utils
{
	public static class StreamUtils
	{
		public static async Task ReadExactlyAsync(string methodName, Stream stream, byte[] buffer, int offset,
			int count, CancellationToken token)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));

			int total = 0;
			while (total < count)
			{
				int read = await stream.ReadAsync(buffer, offset + total, count - total, token).ConfigureAwait(false);
				if (read == 0) 
					throw new IOException($"[{methodName}] Stream closed before expected data was received");
				total += read;
			}
		}
	}
}
