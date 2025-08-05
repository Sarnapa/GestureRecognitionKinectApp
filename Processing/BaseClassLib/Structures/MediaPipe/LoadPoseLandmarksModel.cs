using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region LoadPoseLandmarksModelRequest
	[MessagePackObject]
	public class LoadPoseLandmarksModelRequest
	{
		#region Public properties
		[Key("action")]
		public byte Action
		{
			get
			{
				return 0x00;
			}
		}

		[Key("force_reload")]
		public bool ForceReload
		{
			get;
			set;
		}

		[Key("model_kind")]
		public ModelKind Kind
		{
			get;
			set;
		}

		[Key("num_poses")]
		public int NumPoses
		{
			get;
			set;
		}

		[Key("min_pose_detection_confidence")]
		public float MinPoseDetectionConfidence
		{
			get;
			set;
		}

		[Key("min_pose_presence_confidence")]
		public float MinPosePresenceConfidence
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
	public enum LoadPoseLandmarksModelResponseStatus: byte
	{
		OK = 0x00,
		Error = 0xFF,
	}
	#endregion

	#region LoadPoseLandmarksModelResponse
	[MessagePackObject]
	public class LoadPoseLandmarksModelResponse
	{
		#region Public properties
		[Key("status")]
		public LoadPoseLandmarksModelResponseStatus Status
		{
			get;
			set;
		} = LoadPoseLandmarksModelResponseStatus.Error;

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
