using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region DetectPoseLandmarksRequest
	public class DetectPoseLandmarksRequest
	{
		#region Public properties
		[JsonProperty("action")]
		public string Action
		{
			get
			{
				return "detect_pose_landmarks";
			}
		}

		[JsonProperty("image")]
		public string Image
		{
			get;
			set;
		}

		[JsonProperty("image_width")]
		public int ImageWidth
		{
			get;
			set;
		}

		[JsonProperty("image_height")]
		public int ImageHeight
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region PoseLandmark
	public class PoseLandmark
	{
		#region Public properties
		[JsonProperty("idx")]
		public int Idx
		{
			get;
			set;
		}

		[JsonProperty("x")]
		public float X
		{
			get;
			set;
		}

		[JsonProperty("y")]
		public float Y
		{
			get;
			set;
		}

		[JsonProperty("z")]
		public float Z
		{
			get;
			set;
		}

		[JsonProperty("visibility")]
		public float Visibility
		{
			get;
			set;
		}

		[JsonProperty("presence")]
		public float Presence
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region DetectPoseLandmarksResponseStatus
	public enum DetectPoseLandmarksResponseStatus
	{
		OK,
		NoPose,
		Error
	}

	public static class DetectPoseLandmarksResponseStatusTexts
	{
		public const string OK_STATUS_TEXT = "ok";
		public const string NO_POSE_STATUS_TEXT = "no_pose";
		public const string ERROR_STATUS_TEXT = "error";
	}

	public class DetectPoseLandmarksResponseStatusConverter: JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType.GetType() == typeof(DetectPoseLandmarksResponseStatus);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is DetectPoseLandmarksResponseStatus status)
			{
				string statusText = string.Empty;
				switch (status)
				{
					case DetectPoseLandmarksResponseStatus.OK:
						statusText = DetectPoseLandmarksResponseStatusTexts.OK_STATUS_TEXT;
						break;
					case DetectPoseLandmarksResponseStatus.NoPose:
						statusText = DetectPoseLandmarksResponseStatusTexts.NO_POSE_STATUS_TEXT;
						break;
					case DetectPoseLandmarksResponseStatus.Error:
						statusText = LoadPoseLandmarksModelResponseStatusTexts.ERROR_STATUS_TEXT;
						break;
				}
				writer.WriteValue(statusText);
			}
			else
				writer.WriteValue(string.Empty);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;

			string statusText = reader.Value.ToString();
			switch (statusText)
			{
				case DetectPoseLandmarksResponseStatusTexts.OK_STATUS_TEXT:
					return DetectPoseLandmarksResponseStatus.OK;
				case DetectPoseLandmarksResponseStatusTexts.NO_POSE_STATUS_TEXT:
					return DetectPoseLandmarksResponseStatus.NoPose;
				case DetectPoseLandmarksResponseStatusTexts.ERROR_STATUS_TEXT:
					return DetectPoseLandmarksResponseStatus.Error;
			}

			return null;
		}
	}
	#endregion

	#region DetectPoseLandmarksResponse
	public class DetectPoseLandmarksResponse
	{
		#region Public properties
		[JsonProperty("landmarks")]
		public List<List<PoseLandmark>> Landmarks
		{
			get; set;
		} = new List<List<PoseLandmark>>();

		[JsonProperty("world_landmarks")]
		public List<List<PoseLandmark>> WorldLandmarks
		{
			get; set;
		} = new List<List<PoseLandmark>>();

		[JsonProperty("status")]
		[JsonConverter(typeof(DetectPoseLandmarksResponseStatusConverter))]
		public DetectPoseLandmarksResponseStatus Status
		{
			get; set;
		} = DetectPoseLandmarksResponseStatus.Error;

		[JsonProperty("message")]
		public string Message
		{
			get; set;
		} = string.Empty;
		#endregion
	}
	#endregion
}
