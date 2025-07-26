using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Transforms.Onnx;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using GestureRecognition.Processing.MLNETProcUnit.BodyTrackingModels.PoseDetection;

namespace GestureRecognition.Processing.MLNETProcUnit
{
	public class PoseDetectionModelWrapper<ColorFrameInputType>: ModelWrapper<ColorFrameInputType, PoseDetectionOutput>
		where ColorFrameInputType : BaseColorFrameInput
	{
		#region Constructors
		public PoseDetectionModelWrapper(ModelWrapperParameters parameters) : base(parameters)
		{
			this.ModelPath = PoseDetectionModelInfo.MODEL_FILE_PATH;
			this.ModelKind = ModelKind.ONNX;
			this.ModelUsageKind = ModelUsageKind.PoseDetection;
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
				ErrorMessage = $"Invalid parameters for loading external pose detection model (file path: [{this.ModelPath}])."
			};
		}

		public LoadModelResult LoadModel(LoadBodyTrackingModelParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			(bool fileExists, LoadModelResult fileNotExistResult) = CheckIfFileExists(this.ModelPath);
			if (fileExists)
			{
				var onnxModelOptions = new OnnxOptions()
				{
					InputColumns = [PoseDetectionModelInfo.INPUT_IMAGE_COLUMN_NAME],
					OutputColumns = [PoseDetectionModelInfo.OUTPUT_BOUNDING_BOXES_COLUMN_NAME, PoseDetectionModelInfo.OUTPUT_CONFIDENCE_SCORES_COLUMN_NAME],
					ModelFile = this.ModelPath,
					IntraOpNumThreads = Environment.ProcessorCount,
					InterOpNumThreads = Environment.ProcessorCount,
				};

				try
				{
					var detectionPipeline = this.mlContext.Transforms.ResizeImages(
						outputColumnName: "resized_image",
						imageWidth: PoseDetectionModelInfo.INPUT_IMAGE_WIDTH,
						imageHeight: PoseDetectionModelInfo.INPUT_IMAGE_HEIGHT,
						inputColumnName: nameof(BaseColorFrameInput.Image))
						.Append(this.mlContext.Transforms.ExtractPixels(
							outputColumnName: PoseDetectionModelInfo.INPUT_IMAGE_COLUMN_NAME,
							inputColumnName: "resized_image",
							scaleImage: 1.0f / 255.0f))
						.Append(this.mlContext.Transforms.ApplyOnnxModel(onnxModelOptions)
						);

					this.model = detectionPipeline.Fit(this.mlContext.Data.LoadFromEnumerable(new List<ColorFrameInputType>()));
					this.predictionEngine = this.mlContext.Model.CreatePredictionEngine<ColorFrameInputType, PoseDetectionOutput>(this.model);

					return new LoadModelResult();
				}
				catch (Exception ex)
				{
					return new LoadModelResult()
					{
						ErrorKind = LoadModelErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during loading ONNX model for given pose detection model file path: [{this.ModelPath}]. " +
							$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
					};
				}
			}

			return fileNotExistResult;
		}

		public override async Task<BasePredictResult> Predict(BasePredictParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			if (parameters is PoseDetectionModelPredictParameters poseDetectionModelPredictParameters)
				return await Predict(poseDetectionModelPredictParameters);

			return new PoseDetectionModelPredictResult()
			{
				ErrorKind = PredictErrorKind.InvalidParameters,
				ErrorMessage = $"Invalid parameters for prediction process for external pose detection model (file path: [{this.ModelPath}])."
			};
		}

		public Task<PoseDetectionModelPredictResult> Predict(PoseDetectionModelPredictParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));
			if (parameters.ColorFrame == null)
				throw new ArgumentNullException(nameof(parameters.ColorFrame));

			var colorFrame = parameters.ColorFrame;
			float confidenceScoreThreshold = parameters.ConfidenceScoreThreshold;

			if (colorFrame is ColorFrameInputType colorFrameInput)
			{
				try
				{
					//var predResult = this.predictionEngine.Predict(colorFrameInput);
					//int detectedPosesCount = predResult?.ConfidenceScores?.Where(s => s >= confidenceScoreThreshold).Count() ?? 0;
					return Task.FromResult(new PoseDetectionModelPredictResult()
					{
						DetectedPoseCount = 1 //detectedPosesCount
					});
				}
				catch (Exception ex)
				{
					return Task.FromResult(new PoseDetectionModelPredictResult()
					{
						ErrorKind = PredictErrorKind.UnexpectedError,
						ErrorMessage = $"Unexpected error during prediction process for given pose detection model file path: [{this.ModelPath}]. " +
							$"Exception type: {ex.GetType()}, exception message: {ex.Message}."
					});
				}
			}

			return Task.FromResult(new PoseDetectionModelPredictResult()
			{
				ErrorKind = PredictErrorKind.InvalidParameters,
				ErrorMessage = $"Given pose detection model (file path: [{this.ModelPath}]) doesn't support provided image resolution."
			});
		}
		#endregion
	}
}
