using System;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Events
{
	public class FrameArrivedEventArgs: EventArgs
	{
		#region Public properties
		public FrameData Data
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public FrameArrivedEventArgs(FrameData data)
		{
			this.Data = data;
		}
		#endregion
	}
}
