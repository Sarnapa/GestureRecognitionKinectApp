using System;
using System.Runtime.Serialization;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region LoadPoseLandmarksModelRequest
	//[Serializable]
	[MessagePackObject]
	public class LoadPoseLandmarksModelRequest/*: ISerializable*/
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

		//#region Constructors
		//public LoadPoseLandmarksModelRequest()
		//{
		//}

		//public LoadPoseLandmarksModelRequest(SerializationInfo info, StreamingContext context)
		//{
		//	this.Kind = (ModelKind)info.GetByte("model_kind");
		//	this.NumPoses = info.GetInt32("num_poses");
		//	this.MinPoseDetectionConfidence = info.GetSingle("min_pose_detection_confidence");
		//	this.MinPosePresenceConfidence = info.GetSingle("min_pose_presence_confidence");
		//	this.MinTrackingConfidence = info.GetSingle("min_tracking_confidence");
		//}
		//#endregion

		//#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("model_kind", (byte)this.Kind);
		//	info.AddValue("num_poses", this.NumPoses);
		//	info.AddValue("min_pose_detection_confidence", (byte)this.MinPoseDetectionConfidence);
		//	info.AddValue("min_pose_presence_confidence", this.MinPosePresenceConfidence);
		//	info.AddValue("min_tracking_confidence", this.MinTrackingConfidence);
		//}
		//#endregion
	}
	#endregion

	#region LoadPoseLandmarksModelResponseStatus
	public enum LoadPoseLandmarksModelResponseStatus: byte
	{
		OK = 0x00,
		Error = 0xFF,
	}

	//public static class LoadPoseLandmarksModelResponseStatusTexts
	//{
	//	public const string OK_STATUS_TEXT = "ok";
	//	public const string ERROR_STATUS_TEXT = "error";
	//}

	//public class LoadPoseLandmarksModelResponseStatusConverter: JsonConverter
	//{
	//	public override bool CanConvert(Type objectType)
	//	{
	//		return objectType.GetType() == typeof(LoadPoseLandmarksModelResponseStatus);
	//	}

	//	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	//	{
	//		if (value is LoadPoseLandmarksModelResponseStatus status)
	//		{
	//			string statusText = string.Empty;
	//			switch (status)
	//			{
	//				case LoadPoseLandmarksModelResponseStatus.OK:
	//					statusText = LoadPoseLandmarksModelResponseStatusTexts.OK_STATUS_TEXT;
	//					break;
	//				case LoadPoseLandmarksModelResponseStatus.Error:
	//					statusText = LoadPoseLandmarksModelResponseStatusTexts.ERROR_STATUS_TEXT;
	//					break;
	//			}
	//			writer.WriteValue(statusText);
	//		}
	//		else
	//			writer.WriteValue(string.Empty);
	//	}

	//	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	//	{
	//		if (reader.TokenType == JsonToken.Null)
	//			return null;

	//		string statusText = reader.Value.ToString();
	//		switch (statusText)
	//		{
	//			case LoadPoseLandmarksModelResponseStatusTexts.OK_STATUS_TEXT:
	//				return LoadPoseLandmarksModelResponseStatus.OK;
	//			case LoadPoseLandmarksModelResponseStatusTexts.ERROR_STATUS_TEXT:
	//				return LoadPoseLandmarksModelResponseStatus.Error;
	//		}

	//		return null;
	//	}
	//}
	#endregion

	#region LoadPoseLandmarksModelResponse
	//[Serializable]
	[MessagePackObject]
	public class LoadPoseLandmarksModelResponse/*: ISerializable*/
	{
		#region Public properties
		[Key("status")]
		//[JsonConverter(typeof(LoadPoseLandmarksModelResponseStatusConverter))]
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

		//#region Constructors
		//public LoadPoseLandmarksModelResponse()
		//{
		//}

		//public LoadPoseLandmarksModelResponse(SerializationInfo info, StreamingContext context)
		//{
		//	this.Status = (LoadPoseLandmarksModelResponseStatus)info.GetByte("status");
		//	this.Message = info.GetString("message");
		//}
		//#endregion

		//#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("status", (byte)this.Status);
		//	info.AddValue("message", this.Message);
		//}
		//#endregion
	}
	#endregion
}
