using System.Drawing;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region PredictParameters
	public abstract class BasePredictParameters: BaseParameters
	{}

	public abstract class BodyTrackingModelPredictParameters: BasePredictParameters
	{
		#region Public properties
		public BaseColorFrameInput ColorFrame
		{
			get;
			set;
		}

		public float ConfidenceScoreThreshold
		{
			get;
			set;
		} = 0.5f;
		#endregion
	}

	public class PoseDetectionModelPredictParameters: BodyTrackingModelPredictParameters
	{
	}

	public class PoseLandmarksDetectionModelPredictParameters: BodyTrackingModelPredictParameters
	{
		#region Public properties
		public float NotTrackedJointVisibilityThreshold
		{
			get;
			set;
		} = 0.2f;

		public float InferredJointVisibilityThreshold
		{
			get;
			set;
		} = 0.5f;
		#endregion
	}

	public class GestureRecognitionModelPredictParameters: BasePredictParameters
	{}
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

	public abstract class BodyTrackingModelPredictResult: BasePredictResult
	{}

	public class PoseDetectionModelPredictResult: BodyTrackingModelPredictResult
	{
		#region Public properties
		public int DetectedPoseCount
		{
			get;
			set;
		}
		#endregion
	}

	public class PoseLandmarksDetectionModelPredictResult: BodyTrackingModelPredictResult
	{
		#region Public properties
		public BodyDataWithColorSpacePoints BodyData
		{
			get;
			set;
		}

		public RectangleF BoundingBox
		{
			get;
			set;
		} = RectangleF.Empty;
		#endregion
	}

	public class GestureRecognitionModelPredictResult: BasePredictResult
	{
	}
	#endregion

	#region PredictErrorKind
	public enum PredictErrorKind
	{
		None,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
