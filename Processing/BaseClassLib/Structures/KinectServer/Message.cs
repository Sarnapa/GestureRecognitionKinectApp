namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer
{
	public class Message
	{
		public MessageHeader Header 
		{ 
			get; 
			set;
		}

		public byte[] Payload 
		{ 
			get; 
			set;
		}
	}

	public class MessageHeader
	{
		public MessageType Type
		{
			get;
			set;
		}

		public int PayloadLength
		{
			get;
			set;
		}
	}
}
