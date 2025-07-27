namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region LoadModelParameters
	public abstract class BaseLoadModelParameters: BaseParameters
	{}

	// Code archived - failed attempt with mediapipe model in ONNX format
	//public class LoadBodyTrackingModelParameters: BaseLoadModelParameters
	//{}

	public class LoadGestureRecognitionModelParameters: BaseLoadModelParameters
	{
		#region Public properties
		public string Path
		{
			get;
			set;
		}
		#endregion
	}
	#endregion

	#region LoadModelResult
	public class LoadModelResult: BaseResult
	{
		#region Public properties
		public LoadModelErrorKind ErrorKind
		{
			get;
			set;
		} = LoadModelErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == LoadModelErrorKind.None;
			}
		}
		#endregion
	}
	#endregion

	#region LoadModelErrorKind
	public enum LoadModelErrorKind
	{
		None,
		InvalidParameters,
		FileNotExists,
		UnsupportedModelFileExtension,
		UnexpectedError,
		// Code archived - failed attempt with mediapipe model in ONNX format
		//UnsupportedBodyTrackingModelUsageKind,
	}
	#endregion
}
