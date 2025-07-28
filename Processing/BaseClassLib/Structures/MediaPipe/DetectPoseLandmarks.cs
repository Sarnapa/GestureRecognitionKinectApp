using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region DetectPoseLandmarksRequest
	//[Serializable]
	[MessagePackObject]
	public class DetectPoseLandmarksRequest/*: ISerializable*/
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
		#endregion

		//#region Constructors
		//public DetectPoseLandmarksRequest()
		//{
		//}

		//public DetectPoseLandmarksRequest(SerializationInfo info, StreamingContext context)
		//{
		//	this.Image = (byte[])info.GetValue("image", typeof(byte[]));
		//	this.ImageWidth = info.GetInt32("image_width");
		//	this.ImageHeight = info.GetInt32("image_height");
		//}
		//#endregion

		//#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("image", this.Image);
		//	info.AddValue("image_width", this.ImageWidth);
		//	info.AddValue("image_height", this.ImageHeight);
		//}
		//#endregion
	}
	#endregion

	#region PoseLandmark
	//[Serializable]
	[MessagePackObject]
	public class PoseLandmark//: ISerializable
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

		//#region Constructors
		//public PoseLandmark()
		//{
		//}

		//public PoseLandmark(SerializationInfo info, StreamingContext context)
		//{
		//	this.Idx = info.GetInt32("idx");
		//	this.X = info.GetSingle("x");
		//	this.Y = info.GetSingle("y");
		//	this.Z = info.GetSingle("z");
		//	this.Visibility = info.GetSingle("visibility");
		//	this.Presence = info.GetSingle("presence");
		//}
		//#endregion

		//#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("idx", this.Idx);
		//	info.AddValue("x", this.X);
		//	info.AddValue("y", this.Y);
		//	info.AddValue("z", this.Z);
		//	info.AddValue("visibility", this.Visibility);
		//	info.AddValue("presence", this.Presence);
		//}
		//#endregion
	}
	#endregion

	#region DetectPoseLandmarksResponseStatus
	public enum DetectPoseLandmarksResponseStatus: byte
	{
		OK = 0x00,
		NoPose = 0x01,
		Error = 0xFF,
	}

	//public static class DetectPoseLandmarksResponseStatusTexts
	//{
	//	public const string OK_STATUS_TEXT = "ok";
	//	public const string NO_POSE_STATUS_TEXT = "no_pose";
	//	public const string ERROR_STATUS_TEXT = "error";
	//}

	//public class DetectPoseLandmarksResponseStatusConverter: JsonConverter
	//{
	//	public override bool CanConvert(Type objectType)
	//	{
	//		return objectType.GetType() == typeof(DetectPoseLandmarksResponseStatus);
	//	}

	//	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	//	{
	//		if (value is DetectPoseLandmarksResponseStatus status)
	//		{
	//			string statusText = string.Empty;
	//			switch (status)
	//			{
	//				case DetectPoseLandmarksResponseStatus.OK:
	//					statusText = DetectPoseLandmarksResponseStatusTexts.OK_STATUS_TEXT;
	//					break;
	//				case DetectPoseLandmarksResponseStatus.NoPose:
	//					statusText = DetectPoseLandmarksResponseStatusTexts.NO_POSE_STATUS_TEXT;
	//					break;
	//				case DetectPoseLandmarksResponseStatus.Error:
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
	//			case DetectPoseLandmarksResponseStatusTexts.OK_STATUS_TEXT:
	//				return DetectPoseLandmarksResponseStatus.OK;
	//			case DetectPoseLandmarksResponseStatusTexts.NO_POSE_STATUS_TEXT:
	//				return DetectPoseLandmarksResponseStatus.NoPose;
	//			case DetectPoseLandmarksResponseStatusTexts.ERROR_STATUS_TEXT:
	//				return DetectPoseLandmarksResponseStatus.Error;
	//		}

	//		return null;
	//	}
	//}
	#endregion

	#region DetectPoseLandmarksResponse
	//[Serializable]
	[MessagePackObject]
	public class DetectPoseLandmarksResponse//: ISerializable
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

		[Key("status")]
		//[JsonConverter(typeof(DetectPoseLandmarksResponseStatusConverter))]
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

		//#region Constructors
		//public DetectPoseLandmarksResponse()
		//{
		//}

		//public DetectPoseLandmarksResponse(SerializationInfo info, StreamingContext context)
		//{
		//	this.Landmarks = (List<List<PoseLandmark>>)info.GetValue("landmarks", typeof(List<List<PoseLandmark>>));
		//	this.WorldLandmarks = (List<List<PoseLandmark>>)info.GetValue("world_landmarks", typeof(List<List<PoseLandmark>>));
		//	this.Status = (DetectPoseLandmarksResponseStatus)info.GetByte("status");
		//	this.Message = info.GetString("message");
		//}
		//#endregion

		//#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("landmarks", this.Landmarks);
		//	info.AddValue("world_landmarks", this.WorldLandmarks);
		//	info.AddValue("status", (byte)this.Status);
		//	info.AddValue("message", this.Message);
		//}
		//#endregion
	}
	#endregion
}
