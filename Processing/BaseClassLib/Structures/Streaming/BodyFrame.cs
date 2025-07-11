using System;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Streaming
{
	public class BodyFrame
	{
		#region Public properties
		public TimeSpan RelativeTime
		{
			get;
			private set;
		}
		public int BodiesCount
		{
			get;
			private set;
		} = 0;
		public BodyData[] Bodies
		{
			get;
			private set;
		} = new BodyData[] { };
		public bool TooMuchUsersForOneBodyTracking
		{
			get;
			private set;
		} = false;
		#endregion

		#region Constructors
		public BodyFrame()
		{}

		public BodyFrame(TimeSpan relativeTime, BodyData[] bodies)
		{			
			this.RelativeTime = relativeTime;
			this.Bodies = bodies ?? new BodyData[] { };
			this.BodiesCount = this.Bodies.Length;
		}

		public BodyFrame(TimeSpan relativeTime, int bodiesCount, bool tooMuchUsersForOneBodyTracking)
		{
			this.RelativeTime = relativeTime;
			this.Bodies = new BodyData[] { };
			this.BodiesCount = bodiesCount;
			this.TooMuchUsersForOneBodyTracking = tooMuchUsersForOneBodyTracking;
		}
		#endregion
	}
}
