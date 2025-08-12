namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region SaveModelParameters
	public abstract class BaseSaveModelParameters: BaseParameters
	{
	}

	public class SaveGestureRecognitionModelParameters: BaseSaveModelParameters
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

	#region SaveModelResult
	public class SaveModelResult: BaseResult
	{
		#region Public properties
		public SaveModelErrorKind ErrorKind
		{
			get;
			set;
		} = SaveModelErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == SaveModelErrorKind.None;
			}
		}
		#endregion
	}
	#endregion

	#region SaveModelErrorKind
	public enum SaveModelErrorKind
	{
		None,
		ModelNotLoaded,
		InvalidParameters,
		UnsupportedModelFileExtension,
		UnexpectedError,
	}
	#endregion
}
