using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET
{
	#region SetDataParameters
	public abstract class BaseSetDataParameters: BaseParameters
	{
		#region Public properties
		public double TestFraction
		{
			get;
			set;
		} = 0.2d;
		#endregion
	}

	public class GestureRecognitionModelSetDataParameters: BaseSetDataParameters
	{
		#region Public properties
		public GestureDataView[] Data
		{
			get;
			set;
		} = new GestureDataView[0];

		public GestureDataView[] TrainData
		{
			get;
			set;
		} = new GestureDataView[0];

		public GestureDataView[] TestData
		{
			get;
			set;
		} = new GestureDataView[0];

		public bool IsData
		{
			get
			{
				return this.Data != null && this.Data.Length > 0;
			}
		}

		public bool IsTrainTestData
		{
			get
			{
				return this.TrainData != null && this.TrainData.Length > 0
					&& this.TestData != null && this.TestData.Length > 0;
			}
		}
		#endregion
	}
	#endregion

	#region SetDataResult
	public class SetDataResult: BaseResult
	{
		#region Public properties
		public SetDataErrorKind ErrorKind
		{
			get;
			set;
		} = SetDataErrorKind.None;

		public override bool IsSuccess
		{
			get
			{
				return this.ErrorKind == SetDataErrorKind.None;
			}
		}
		#endregion
	}
	#endregion

	#region SetDataErrorKind
	public enum SetDataErrorKind
	{
		None,
		InvalidParameters,
		InvalidOutput,
		UnexpectedError,
	}
	#endregion
}
