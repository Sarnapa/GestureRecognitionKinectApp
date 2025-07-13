using System;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Events
{
	public class KinectIsAvailableChangedEventArgs: EventArgs
	{
		#region Public properties
		public KinectIsAvailableChangedData Data
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public KinectIsAvailableChangedEventArgs(KinectIsAvailableChangedData data)
		{
			this.Data = data;
		}
		#endregion
	}
}
