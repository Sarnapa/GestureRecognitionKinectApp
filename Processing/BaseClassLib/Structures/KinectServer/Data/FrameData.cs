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
		#endregion
	}
}
