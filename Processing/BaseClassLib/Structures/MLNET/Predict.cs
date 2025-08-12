using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.Predictions;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region PredictParameters
	public abstract class BasePredictParameters: BaseParameters
	{ }

	// Code archived - failed attempt with mediapipe model in ONNX format
	//public abstract class BodyTrackingModelPredictParameters: BasePredictParameters
	//{
	//	#region Public properties
	//	public BaseColorFrameInput ColorFrame
	//	{
	//		get;
	//		set;
	//	}

	//	public float ConfidenceScoreThreshold
	//	{
	//		get;
	//		set;
	//	} = 0.5f;
	//	#endregion
	//}

	// Code archived - failed attempt with mediapipe model in ONNX format
	//public class PoseDetectionModelPredictParameters: BodyTrackingModelPredictParameters
	//{
	//}

	//public class PoseLandmarksDetectionModelPredictParameters: BodyTrackingModelPredictParameters
	//{
	//	#region Public properties
	//	public float NotTrackedJointVisibilityThreshold
	//	{
	//		get;
	//		set;
	//	} = 0.2f;

	//	public float InferredJointVisibilityThreshold
	//	{
	//		get;
	//		set;
	//	} = 0.5f;
	//	#endregion
	//}

	public class GestureRecognitionModelPredictParameters: BasePredictParameters
	{
		#region Public properties
		public GestureDataView GestureData
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region PredictResult
	public abstract class BasePredictResult: BaseResult
	{
		#region Public properties
		public PredictErrorKind ErrorKind
		{
			get;
			set;
		} = PredictErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == PredictErrorKind.None;
			}
		}
		#endregion
	}

	// Code archived - failed attempt with mediapipe model in ONNX format
	//public abstract class BodyTrackingModelPredictResult: BasePredictResult
	//{}

	// Code archived - failed attempt with mediapipe model in ONNX format
	//public class PoseDetectionModelPredictResult: BodyTrackingModelPredictResult
	//{
	//	#region Public properties
	//	public int DetectedPoseCount
	//	{
	//		get;
	//		set;
	//	}
	//	#endregion
	//}

	// Code archived - failed attempt with mediapipe model in ONNX format
	//public class PoseLandmarksDetectionModelPredictResult: BodyTrackingModelPredictResult
	//{
	//	#region Public properties
	//	public BodyDataWithColorSpacePoints BodyData
	//	{
	//		get;
	//		set;
	//	}

	//	public RectangleF BoundingBox
	//	{
	//		get;
	//		set;
	//	} = RectangleF.Empty;
	//	#endregion
	//}

	public class GestureRecognitionModelPredictResult: BasePredictResult
	{
		#region Public properties
		public GesturePrediction Prediction
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region PredictErrorKind
	public enum PredictErrorKind
	{
		None,
		ModelNotLoaded,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
