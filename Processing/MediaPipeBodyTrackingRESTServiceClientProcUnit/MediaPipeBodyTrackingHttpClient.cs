using System.Text;
using Newtonsoft.Json;
using GestureRecognition.Processing.BaseClassLib.Structures.MediaPipe;

namespace GestureRecognition.Processing.MediaPipeBodyTrackingRESTServiceClientProcUnit
{
	public class MediaPipeBodyTrackingHttpClient
	{
		#region Private fields
		private readonly HttpClient httpClient;
		private readonly string baseUrl;
		#endregion

		#region Constructors
		public MediaPipeBodyTrackingHttpClient(string baseUrl)
		{
			this.httpClient = new HttpClient();
			this.baseUrl = baseUrl;
		}
		#endregion

		#region Public methods
		public async Task<LoadPoseLandmarksModelResponse> LoadPoseLandmarksModelAsync(LoadPoseLandmarksModelRequest request)
		{
			try
			{
				var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
				var response = await this.httpClient.PostAsync($"{this.baseUrl}/load_pose_landmarks_model", jsonContent);
				string content = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<LoadPoseLandmarksModelResponse>(content) ?? 
					new LoadPoseLandmarksModelResponse()
					{
						Status = LoadPoseLandmarksModelResponseStatus.Error,
						Message = "Loading pose landmarks model - received empty response."
					};
				return result;
			}
			catch (HttpRequestException httpEx)
			{
				return new LoadPoseLandmarksModelResponse()
				{
					Status = LoadPoseLandmarksModelResponseStatus.Error,
					Message = $"Loading pose landmarks model - communication error: [{httpEx.Message}]."
				};
			}
			catch (JsonSerializationException jsonEx)
			{
				return new LoadPoseLandmarksModelResponse()
				{
					Status = LoadPoseLandmarksModelResponseStatus.Error,
					Message = $"Loading pose landmarks model - serialization error: [{jsonEx.Message}]."
				};
			}
			catch (Exception ex)
			{
				return new LoadPoseLandmarksModelResponse()
				{
					Status = LoadPoseLandmarksModelResponseStatus.Error,
					Message = $"Loading pose landmarks model - unexpected error: [{ex.Message}]."
				};
			}
		}

		public async Task<DetectPoseLandmarksResponse> DetectPoseLandmarksAsync(DetectPoseLandmarksRequest request)
		{
			try
			{
				var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
				var response = await this.httpClient.PostAsync($"{this.baseUrl}/detects_pose_landmarks", jsonContent);
				string content = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<DetectPoseLandmarksResponse>(content) ??
					new DetectPoseLandmarksResponse()
					{
						Status = DetectPoseLandmarksResponseStatus.Error,
						Message = "Detecting pose landmarks - received empty response."
					};
				return result;
			}
			catch (HttpRequestException httpEx)
			{
				return new DetectPoseLandmarksResponse()
				{
					Status = DetectPoseLandmarksResponseStatus.Error,
					Message = $"Detecting pose landmarks - communication error: [{httpEx.Message}]."
				};
			}
			catch (JsonSerializationException jsonEx)
			{
				return new DetectPoseLandmarksResponse()
				{
					Status = DetectPoseLandmarksResponseStatus.Error,
					Message = $"Detecting pose landmarks - serialization error: [{jsonEx.Message}]."
				};
			}
			catch (Exception ex)
			{
				return new DetectPoseLandmarksResponse()
				{
					Status = DetectPoseLandmarksResponseStatus.Error,
					Message = $"Detecting pose landmarks - unexpected error: [{ex.Message}]."
				};
			}
		}
		#endregion
	}
}
