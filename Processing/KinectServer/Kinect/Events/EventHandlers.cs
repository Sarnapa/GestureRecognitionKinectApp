using System.Threading.Tasks;

namespace GestureRecognition.Processing.KinectServer.Kinect.Events
{
	public delegate Task FrameArrivedEventHandler(object sender, FrameArrivedEventArgs e);
	public delegate Task KinectIsAvailableChangedEventHandler(object sender, KinectIsAvailableChangedEventArgs e);
}
