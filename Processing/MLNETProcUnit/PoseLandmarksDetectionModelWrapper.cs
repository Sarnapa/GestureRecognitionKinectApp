using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.ML;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using GestureRecognition.Processing.MLNETProcUnit.BodyTrackingModels.PoseLandmarksDetection;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.MLNETProcUnit
{
	public class PoseLandmarksDetectionModelWrapper<ColorFrameInputType>: ModelWrapper<ColorFrameInputType, PoseLandmarksDetectionOutput>
			where ColorFrameInputType : BaseColorFrameInput
	{
		#region Constructors
		public PoseLandmarksDetectionModelWrapper(ModelWrapperParameters parameters) : base(parameters)
		{
			this.ModelPath = PoseLandmarksDetectionModelInfo.FULL_MODEL_FILE_PATH;
			this.ModelKind = ModelKind.ONNX;
			this.ModelUsageKind = ModelUsageKind.PoseLandmarksDetection;
		}
		#endregion

		#region Public methods
		public override LoadModelResult LoadModel(BaseLoadModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (parameters is LoadBodyTrackingModelParameters bodyTrackingModelParameters)
				return LoadModel(bodyTrackingModelParameters);

			return new LoadModelResult()
			{
				ErrorKind = LoadModelErrorKind.InvalidParameters,
				ErrorMessage = $"Invalid parameters for loading given pose landmarks detection model (file path: [{this.ModelPath}])."
			};
		}

		public LoadModelResult LoadModel(LoadBodyTrackingModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			(bool fileExists, LoadModelResult fileNotExistResult) = CheckIfFileExists(this.ModelPath);
			if (fileExists)
			{
				try
				{
					var detectionPipeline = this.mlContext.Transforms.ResizeImages(
						outputColumnName: "resized_image",
						imageWidth: PoseLandmarksDetectionModelInfo.INPUT_IMAGE_WIDTH,
						imageHeight: PoseLandmarksDetectionModelInfo.INPUT_IMAGE_HEIGHT,
						inputColumnName: nameof(BaseColorFrameInput.Image))
						.Append(this.mlContext.Transforms.ExtractPixels(
							outputColumnName: PoseLandmarksDetectionModelInfo.INPUT_IMAGE_COLUMN_NAME,
							inputColumnName: "resized_image",
							scaleImage: 1.0f / 255.0f))
						.Append(this.mlContext.Transforms.ApplyOnnxModel(
							outputColumnNames: [PoseLandmarksDetectionModelInfo.OUTPUT_LANDMARKS_COLUMN_NAME, PoseLandmarksDetectionModelInfo.OUTPUT_CONFIDENCE_SCORE_COLUMN_NAME],
							inputColumnNames: [PoseLandmarksDetectionModelInfo.INPUT_IMAGE_COLUMN_NAME],
							modelFile: this.ModelPath));

					this.model = detectionPipeline.Fit(this.mlContext.Data.LoadFromEnumerable(new List<ColorFrameInputType>()));
					this.predictionEngine = this.mlContext.Model.CreatePredictionEngine<ColorFrameInputType, PoseLandmarksDetectionOutput>(this.model);

					return new LoadModelResult();
				}
				catch (Exception ex)
				{
					return new LoadModelResult()
					{
						ErrorKind = LoadModelErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during loading ONNX model for given pose landmarks detection model file path: [{this.ModelPath}]. " +
							$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
					};
				}
			}

			return fileNotExistResult;
		}

		public override BasePredictResult Predict(BasePredictParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (parameters is PoseLandmarksDetectionModelPredictParameters poseLandmarksDetectionModelPredictParameters)
				return Predict(poseLandmarksDetectionModelPredictParameters);

			return new PoseLandmarksDetectionModelPredictResult()
			{
				ErrorKind = PredictErrorKind.InvalidParameters,
				ErrorMessage = $"Invalid parameters for prediction process for given pose landmarks detection model (file path: [{this.ModelPath}])."
			};
		}

		public PoseLandmarksDetectionModelPredictResult Predict(PoseLandmarksDetectionModelPredictParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));
			if (parameters.ColorFrame == null)
				throw new ArgumentNullException(nameof(parameters.ColorFrame));

			var colorFrame = parameters.ColorFrame;
			float confidenceScoreThreshold = parameters.ConfidenceScoreThreshold;
			float notTrackedJointVisibilityThreshold = parameters.NotTrackedJointVisibilityThreshold;
			float inferredJointVisibilityThreshold = parameters.InferredJointVisibilityThreshold;

			if (colorFrame is ColorFrameInputType colorFrameInput)
			{
				try
				{
					var predResult = this.predictionEngine.Predict(colorFrameInput);
					float? confidenceScore = predResult?.ConfidenceScore != null && predResult.ConfidenceScore.Length > 0 ?
						predResult.ConfidenceScore[0] : null;
					if (!confidenceScore.HasValue || confidenceScore.Value <= confidenceScoreThreshold)
					{
						return new PoseLandmarksDetectionModelPredictResult()
						{
							BodyData = GetNotTrackedBodyData()
						};
					}

					if (predResult.Landmarks == null || predResult.Landmarks.Length != PoseLandmarksDetectionModelInfo.LANDMARKS_COLUMN_LENGTH)
					{
						return new PoseLandmarksDetectionModelPredictResult()
						{
							ErrorKind = PredictErrorKind.InvalidOutput,
							ErrorMessage = $"Invalid output concerning pose landmarks that was returned by given pose landmarks detection model (file path: [{this.ModelPath}])."
						};
					}

					var poseLandmarks = GetPoseLandmarks(predResult.Landmarks);

					return new PoseLandmarksDetectionModelPredictResult()
					{
						BodyData = GetBodyData(poseLandmarks, colorFrame.ImageWidth, colorFrame.ImageHeight,
							notTrackedJointVisibilityThreshold, inferredJointVisibilityThreshold)
					};
				}
				catch (Exception ex)
				{
					return new PoseLandmarksDetectionModelPredictResult()
					{
						ErrorKind = PredictErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during prediction process for given pose landmarks detection model file path: [{this.ModelPath}]. " +
							$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
					};
				}
			}

			return new PoseLandmarksDetectionModelPredictResult()
			{
				ErrorKind = PredictErrorKind.InvalidParameters,
				ErrorMessage = $"Given pose landmarks detection model (file path: [{this.ModelPath}]) doesn't support provided image resolution."
			};
		}
		#endregion

		#region Private methods

		#region Getting pose landmarks methods
		private static PoseLandmark[] GetPoseLandmarks(float[] landmarksOutput)
		{
			var result = new List<PoseLandmark>
			{
				GetPoseLandmark(landmarksOutput, 0, JointType.Nose),
				GetPoseLandmark(landmarksOutput, 1, JointType.EyeInnerLeft),
				GetPoseLandmark(landmarksOutput, 2, JointType.EyeLeft),
				GetPoseLandmark(landmarksOutput, 3, JointType.EyeOuterLeft),
				GetPoseLandmark(landmarksOutput, 4, JointType.EyeInnerRight),
				GetPoseLandmark(landmarksOutput, 5, JointType.EyeRight),
				GetPoseLandmark(landmarksOutput, 6, JointType.EyeOuterRight),
				GetPoseLandmark(landmarksOutput, 7, JointType.EarLeft),
				GetPoseLandmark(landmarksOutput, 8, JointType.EarRight),
				GetPoseLandmark(landmarksOutput, 9, JointType.MouthLeft),
				GetPoseLandmark(landmarksOutput, 10, JointType.MouthRight),
				GetPoseLandmark(landmarksOutput, 11, JointType.ShoulderLeft),
				GetPoseLandmark(landmarksOutput, 12, JointType.ShoulderRight),
				GetPoseLandmark(landmarksOutput, 13, JointType.ElbowLeft),
				GetPoseLandmark(landmarksOutput, 14, JointType.ElbowRight),
				GetPoseLandmark(landmarksOutput, 15, JointType.WristLeft),
				GetPoseLandmark(landmarksOutput, 16, JointType.WristRight),
				GetPoseLandmark(landmarksOutput, 17, JointType.PinkyLeft),
				GetPoseLandmark(landmarksOutput, 18, JointType.PinkyRight),
				GetPoseLandmark(landmarksOutput, 19, JointType.IndexLeft),
				GetPoseLandmark(landmarksOutput, 20, JointType.IndexRight),
				GetPoseLandmark(landmarksOutput, 21, JointType.ThumbLeft),
				GetPoseLandmark(landmarksOutput, 22, JointType.ThumbRight),
				GetPoseLandmark(landmarksOutput, 23, JointType.HipLeft),
				GetPoseLandmark(landmarksOutput, 24, JointType.HipRight),
				GetPoseLandmark(landmarksOutput, 25, JointType.KneeLeft),
				GetPoseLandmark(landmarksOutput, 26, JointType.KneeRight),
				GetPoseLandmark(landmarksOutput, 27, JointType.AnkleLeft),
				GetPoseLandmark(landmarksOutput, 28, JointType.AnkleRight),
				GetPoseLandmark(landmarksOutput, 29, JointType.HeelLeft),
				GetPoseLandmark(landmarksOutput, 30, JointType.HeelRight),
				GetPoseLandmark(landmarksOutput, 31, JointType.FootIndexLeft),
				GetPoseLandmark(landmarksOutput, 32, JointType.FootIndexRight),
			};

			return result.ToArray();
		}
		
		private static PoseLandmark GetPoseLandmark(float[] landmarksOutput, int landmarkIdx, JointType jointType)
		{
			int stride = landmarkIdx * 5;
			return new PoseLandmark()
			{
				Index = landmarkIdx,
				JointType = jointType,
				X = landmarksOutput[stride],
				Y = landmarksOutput[stride + 1],
				Z = landmarksOutput[stride + 2],
				Visibility = landmarksOutput[stride + 3],
				Presence = landmarksOutput[stride + 4]
			};
		}
		#endregion

		#region Getting body data methods
		private static BodyDataWithColorSpacePoints GetBodyData(PoseLandmark[] poseLandmarks, int imageWidth, int imageHeight,
			float notTrackedJointVisibilityThreshold, float inferredJointVisibilityThreshold)
		{
			var jointsDict = new Dictionary<JointType, Joint>();
			var jointsColorSpacePointsDict = new BodyJointsColorSpacePointsDict();

			foreach (var poseLandmark in poseLandmarks)
			{
				var jointPosition = new Vector3(poseLandmark.X, poseLandmark.Y, poseLandmark.Z);
				var jointColorSpacePoint = GetColorSpacePoint(poseLandmark, imageWidth, imageHeight);
				var jointTrackingState = GetTrackingState(poseLandmark.Visibility, notTrackedJointVisibilityThreshold,
					inferredJointVisibilityThreshold);
				var joint = new Joint(poseLandmark.JointType, jointPosition, jointTrackingState);

				jointsDict.Add(joint.JointType, joint);
				jointsColorSpacePointsDict.Add(joint.JointType, jointColorSpacePoint);
			}

			// TODO: Analysis whether we can detect whether the hand is open or closed
			return new BodyDataWithColorSpacePoints(0, true, jointsDict, HandState.Unknown, TrackingConfidence.Low,
				HandState.Unknown, TrackingConfidence.Low, jointsColorSpacePointsDict);
		}

		private static BodyDataWithColorSpacePoints GetNotTrackedBodyData()
		{
			return new BodyDataWithColorSpacePoints(0, false, null, HandState.Unknown, TrackingConfidence.Low,
				HandState.Unknown, TrackingConfidence.Low, null);
		}
		#endregion

		#region Other private methods
		private static TrackingState GetTrackingState(float visibility, float notTrackedJointVisibilityThreshold,
			float inferredJointVisibilityThreshold)
		{
			if (visibility <= notTrackedJointVisibilityThreshold)
				return TrackingState.NotTracked;
			else if (visibility <= inferredJointVisibilityThreshold)
				return TrackingState.Inferred;

			return TrackingState.Tracked;
		}

		private static Vector2 GetColorSpacePoint(PoseLandmark landmark, int imageWidth, int imageHeight)
		{
			float scaledX = landmark.X * imageWidth / 256.0f;
			float scaledY = landmark.Y * imageHeight / 256.0f;

			return new Vector2(scaledX, scaledY);
		}
		#endregion

		#endregion
	}
}
