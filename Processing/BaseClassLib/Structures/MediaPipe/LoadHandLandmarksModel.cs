using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region LoadHandLandmarksModelRequest
	[MessagePackObject]
	public class LoadHandLandmarksModelRequest
	{
		#region Public properties
		[Key("action")]
		public byte Action
		{
			get
			{
				return 0x02;
			}
		}


		[Key("num_hands")]
		public int NumHands
		{
			get;
			set;
		}

		[Key("min_hand_detection_confidence")]
		public float MinHandDetectionConfidence
		{
			get;
			set;
		}

		[Key("min_hand_presence_confidence")]
		public float MinHandPresenceConfidence
		{
			get;
			set;
		}

		[Key("min_tracking_confidence")]
		public float MinTrackingConfidence
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region LoadPoseLandmarksModelResponseStatus
	public enum LoadHandLandmarksModelResponseStatus: byte
	{
		OK = 0x00,
		Error = 0xFF,
	}
	#endregion

	#region LoadHandLandmarksModelResponse
	[MessagePackObject]
	public class LoadHandLandmarksModelResponse
	{
		#region Public properties
		[Key("status")]
		public LoadHandLandmarksModelResponseStatus Status
		{
			get;
			set;
		} = LoadHandLandmarksModelResponseStatus.Error;

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
