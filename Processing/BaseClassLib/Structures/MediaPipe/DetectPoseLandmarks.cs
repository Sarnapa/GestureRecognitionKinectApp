using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region DetectPoseLandmarksRequest
	[MessagePackObject]
	public class DetectPoseLandmarksRequest
	{
		#region Public properties
		[Key("action")]
		public byte Action
		{
			get
			{
				return 0x01;
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

		[Key("image_target_width")]
		public int ImageTargetWidth
		{
			get;
			set;
		}

		[Key("image_target_height")]
		public int ImageTargetHeight
		{
			get;
			set;
		}

		[Key("is_one_body_tracking_enabled")]
		public bool IsOneBodyTrackingEnabled
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region PoseLandmark
	[MessagePackObject]
	public class PoseLandmark
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

		[Key("visibility")]
		public float Visibility
		{
			get;
			set;
		}

		[Key("presence")]
		public float Presence
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region DetectPoseLandmarksResponseStatus
	public enum DetectPoseLandmarksResponseStatus: byte
	{
		OK = 0x00,
		NoPose = 0x01,
		TooMuchUsersForOneBodyTracking = 0x02,
		Error = 0xFF,
	}
	#endregion

	#region DetectPoseLandmarksResponse
	[MessagePackObject]
	public class DetectPoseLandmarksResponse
	{
		#region Public properties
		[Key("landmarks")]
		public List<List<PoseLandmark>> Landmarks
		{
			get; set;
		} = new List<List<PoseLandmark>>();

		[Key("world_landmarks")]
		public List<List<PoseLandmark>> WorldLandmarks
		{
			get; set;
		} = new List<List<PoseLandmark>>();

		[Key("hand_left_states")]
		public List<HandState> HandLeftStates
		{
			get;
			set;
		} = new List<HandState>();

		[Key("hand_right_states")]
		public List<HandState> HandRightStates
		{
			get;
			set;
		} = new List<HandState>();

		[Key("bodies_count")]
		public int BodiesCount
		{
			get;
			set;
		}

		[Key("status")]
		public DetectPoseLandmarksResponseStatus Status
		{
			get; set;
		} = DetectPoseLandmarksResponseStatus.Error;

		[Key("message")]
		public string Message
		{
			get; set;
		} = string.Empty;
		#endregion
	}
	#endregion
}
