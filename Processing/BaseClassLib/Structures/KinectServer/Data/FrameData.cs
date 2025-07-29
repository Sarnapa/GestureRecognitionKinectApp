using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;

namespace GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data
{
	public class FrameData
	{
		#region Public properties
		public ColorFrame ColorFrame 
		{ 
			get; 
			set;
		}

		public BodyFrame BodyFrame 
		{ 
			get; 
			set;
		}

		public IDictionary<ulong, BodyJointsColorSpacePointsDict> BodiesJointsColorSpacePointsDict
		{
			get;
			set;
		} = new Dictionary<ulong, BodyJointsColorSpacePointsDict>();

		public bool IsNewBodyData
		{
			get;
			set;
		} = true;
		#endregion
	}

	#region FrameDataRelativeTimeComparer

	// IComparer implementation for comparing FrameData based on RelativeTime
	public class FrameDataRelativeTimeComparer: IComparer<FrameData>
	{
		public int Compare(FrameData x, FrameData y)
		{
			if (x?.ColorFrame == null || y?.ColorFrame == null)
				return 0;

			return x.ColorFrame.RelativeTime.CompareTo(y.ColorFrame.RelativeTime);
		}
	}
	#endregion
}
