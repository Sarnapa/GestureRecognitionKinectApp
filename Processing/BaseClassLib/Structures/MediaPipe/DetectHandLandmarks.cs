using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region DetectHandLandmarksRequest
	[MessagePackObject]
	public class DetectHandLandmarksRequest
	{
		#region Public properties
		[Key("action")]
		public byte Action
		{
			get
			{
				return 0x03;
			}
		}

		[Key("image")]
		public byte[] Image
		{
			get;
			set;
		}

		[Key("image_width")]
		public int ImageWidth
		{
			get;
			set;
		}

		[Key("image_height")]
		public int ImageHeight
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region HandData
	[MessagePackObject]
	public class HandData
	{
		#region Public properties
		[Key("idx")]
		public int Idx
		{
			get;
			set;
		}

		[Key("score")]
		public float Score
		{
			get;
			set;
		}

		[Key("category_name")]
		public string CategoryName
		{
			get;
			set;
		}

		[Key("hand_state")]
		public HandState HandState
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region HandLandmark
	[MessagePackObject]
	public class HandLandmark
	{
		#region Public properties
		[Key("idx")]
		public int Idx
		{
			get;
			set;
		}

		[Key("x")]
		public float X
		{
			get;
			set;
		}

		[Key("y")]
		public float Y
		{
			get;
			set;
		}

		[Key("z")]
		public float Z
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region DetectHandLandmarksResponseStatus
	public enum DetectHandLandmarksResponseStatus: byte
	{
		OK = 0x00,
		NoHand = 0x01,
		Error = 0xFF,
	}
	#endregion

	#region DetectHandLandmarksResponse
	[MessagePackObject]
	public class DetectHandLandmarksResponse
	{
		#region Public properties
		[Key("handedness")]
		public List<List<HandData>> Handedness
		{
			get;
			set;
		} = new List<List<HandData>>();

		[Key("landmarks")]
		public List<List<HandLandmark>> Landmarks
		{
			get; 
			set;
		} = new List<List<HandLandmark>>();

		[Key("world_landmarks")]
		public List<List<HandLandmark>> WorldLandmarks
		{
			get;
			set;
		} = new List<List<HandLandmark>>();

		[Key("status")]
		public DetectHandLandmarksResponseStatus Status
		{
			get; 
			set;
		} = DetectHandLandmarksResponseStatus.Error;

		[Key("message")]
		public string Message
		{
			get; 
			set;
		} = string.Empty;
		#endregion
	}
	#endregion
}
