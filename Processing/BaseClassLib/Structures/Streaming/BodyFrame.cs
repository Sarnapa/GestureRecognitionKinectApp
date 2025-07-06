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
		public BodyData[] Bodies
		{
			get;
			private set;
		} = new BodyData[] { };

		public int BodyCount
		{
			get 
			{ 
				return this.Bodies?.Length ?? 0; 
			}
		}
		#endregion

		#region Constructors
		public BodyFrame(TimeSpan relativeTime, BodyData[] bodies)
		{			
			this.RelativeTime = relativeTime;
			this.Bodies = bodies ?? new BodyData[] { };
		}
		#endregion
	}
}
