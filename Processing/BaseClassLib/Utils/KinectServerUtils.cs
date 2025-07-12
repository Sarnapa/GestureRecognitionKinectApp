using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer;

namespace GestureRecognition.Processing.BaseClassLib.Utils
{
	public static class KinectServerUtils
	{
		#region Read methods
		public static async Task<MessageHeader> ReadHeader(string methodName, Stream stream, CancellationToken token)
		{
			if (string.IsNullOrEmpty(methodName))
				throw new ArgumentNullException(nameof(methodName));
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			byte[] header = new byte[5];
			await StreamUtils.ReadExactlyAsync(methodName, stream, header, 0, 5, token).ConfigureAwait(false);
			var type = (MessageType)header[0];
			int payloadLength = BitConverter.ToInt32(header, 1);
			return new MessageHeader
			{
				Type = type,
				PayloadLength = payloadLength
			};
		}

		public static async Task<Message> ReadMessage(string methodName, Stream stream, MessageHeader messageHeader,
			CancellationToken token)
		{
			if (string.IsNullOrEmpty(methodName))
				throw new ArgumentNullException(nameof(methodName));
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));
			if (messageHeader == null)
				throw new ArgumentNullException(nameof(messageHeader));

			byte[] payload = new byte[messageHeader.PayloadLength];
			await StreamUtils.ReadExactlyAsync(methodName, stream, payload, 0, messageHeader.PayloadLength, token).ConfigureAwait(false);
			return new Message
			{
				Header = messageHeader,
				Payload = payload
			};
		}

		public static async Task<Message> ReadMessage(string methodName, Stream stream, CancellationToken token)
		{
			if (string.IsNullOrEmpty(methodName))
				throw new ArgumentNullException(nameof(methodName));
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			var messageHeader = await ReadHeader(methodName, stream, token).ConfigureAwait(false);
			return await ReadMessage(methodName, stream, messageHeader, token).ConfigureAwait(false);
		}
		#endregion

		#region Write methods
		public static async Task WriteHeader(string methodName, Stream stream, MessageHeader messageHeader,
			CancellationToken token)
		{
			if (string.IsNullOrEmpty(methodName))
				throw new ArgumentNullException(nameof(methodName));
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));
			if (messageHeader == null)
				throw new ArgumentNullException(nameof(messageHeader));

			byte[] header = new byte[5];
			header[0] = (byte)messageHeader.Type;
			BitConverter.GetBytes(messageHeader.PayloadLength).CopyTo(header, 1);
			await stream.WriteAsync(header, 0, header.Length, token).ConfigureAwait(false);
		}

		public static async Task WriteMessage(string methodName, Stream stream, Message message,
			CancellationToken token)
		{
			if (string.IsNullOrEmpty(methodName))
				throw new ArgumentNullException(nameof(methodName));
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));
			if (message == null)
				throw new ArgumentNullException(nameof(message));

			await WriteHeader(methodName, stream, message.Header, token).ConfigureAwait(false);
			await stream.WriteAsync(message.Payload, 0, message.Payload.Length, token).ConfigureAwait(false);
		}
		#endregion

		#region Other methods
		public static Message CreateMessage(MessageType type, byte[] payload)
		{
			if (payload == null)
				throw new ArgumentNullException(nameof(payload));
			
			return new Message
			{
				Header = new MessageHeader
				{
					Type = type,
					PayloadLength = payload.Length
				},
				Payload = payload
			};
		}
		#endregion
	}
}
