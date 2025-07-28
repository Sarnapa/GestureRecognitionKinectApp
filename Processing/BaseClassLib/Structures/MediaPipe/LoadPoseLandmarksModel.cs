using System;
using Newtonsoft.Json;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe
{
	#region LoadPoseLandmarksModelRequest
	public class LoadPoseLandmarksModelRequest
	{
		#region Public properties
		[JsonProperty("action")]
		public string Action
		{
			get
			{
				return "load_pose_landmarks_model";
			}
		}

		[JsonProperty("model_kind")]
		public ModelKind Kind
		{
			get;
			set;
		}

		[JsonProperty("num_poses")]
		public int NumPoses
		{
			get;
			set;
		}

		[JsonProperty("min_pose_detection_confidence")]
		public float MinPoseDetectionConfidence
		{
			get;
			set;
		}

		[JsonProperty("min_pose_presence_confidence")]
		public float MinPosePresenceConfidence
		{
			get;
			set;
		}

		[JsonProperty("min_tracking_confidence")]
		public float MinTrackingConfidence
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region LoadPoseLandmarksModelResponseStatus
	public enum LoadPoseLandmarksModelResponseStatus
	{
		OK,
		Error,
	}

	public static class LoadPoseLandmarksModelResponseStatusTexts
	{
		public const string OK_STATUS_TEXT = "ok";
		public const string ERROR_STATUS_TEXT = "error";
	}

	public class LoadPoseLandmarksModelResponseStatusConverter: JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType.GetType() == typeof(LoadPoseLandmarksModelResponseStatus);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is LoadPoseLandmarksModelResponseStatus status)
			{
				string statusText = string.Empty;
				switch (status)
				{
					case LoadPoseLandmarksModelResponseStatus.OK:
						statusText = LoadPoseLandmarksModelResponseStatusTexts.OK_STATUS_TEXT;
						break;
					case LoadPoseLandmarksModelResponseStatus.Error:
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
				case LoadPoseLandmarksModelResponseStatusTexts.OK_STATUS_TEXT:
					return LoadPoseLandmarksModelResponseStatus.OK;
				case LoadPoseLandmarksModelResponseStatusTexts.ERROR_STATUS_TEXT:
					return LoadPoseLandmarksModelResponseStatus.Error;
			}

			return null;
		}
	}
	#endregion

	#region LoadPoseLandmarksModelResponse
	public class LoadPoseLandmarksModelResponse
	{
		#region Public properties
		[JsonProperty("status")]
		[JsonConverter(typeof(LoadPoseLandmarksModelResponseStatusConverter))]
		public LoadPoseLandmarksModelResponseStatus Status
		{
			get;
			set;
		} = LoadPoseLandmarksModelResponseStatus.Error;

		[JsonProperty("message")]
		public string Message
		{
			get;
			set;
		} = string.Empty;
		#endregion
	}
	#endregion
}
