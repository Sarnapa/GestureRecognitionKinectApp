namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer
{
	public enum MessageType: byte
	{
		StartRequest = 0x01,
		StartResponse = 0x02,
		KinectIsAvailableChanged = 0x04,
		Frame = 0x08,
		StopRequest = 0x10,
	}
}
