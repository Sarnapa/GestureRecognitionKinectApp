using System.Text;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Utils;

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

		public bool IsTrainData
		{
			get
			{
				return this.TrainData != null && this.TrainData.Length > 0;
			}
		}

		public bool IsTestData
		{
			get
			{
				return this.TestData != null && this.TestData.Length > 0;
			}
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			if (this.IsData)
			{
				int examplesCount = this.Data.Length;
				string classCountsText = GetClassCountsText(this.Data);

				return $"All examples count: {examplesCount}\n" +
					$"Test fraction: {this.TestFraction}\n" +
					$"Class counts in the data set:\n" +
					$"{classCountsText}";
			}
			else if (this.IsTrainData || this.IsTestData)
			{
				int trainExamplesCount = this.TrainData?.Length ?? 0;
				string trainClassCountsText = GetClassCountsText(this.TrainData);

				int testExamplesCount = this.TestData?.Length ?? 0;
				string testClassCountsText = GetClassCountsText(this.TestData);

				return $"Training data examples count: {trainExamplesCount}\n" +
					$"Class counts in the training data set:\n" +
					$"{trainClassCountsText}" +
					$"Test data examples count: {testExamplesCount}\n" +
					$"Class counts in the test data set:\n" +
					$"{testClassCountsText}";
			}
			else
			{
				return "No data set.";
			}
		}
		#endregion

		#region Private methods
		private static string GetClassCountsText(GestureDataView[] gesturesData)
		{
			var sb = new StringBuilder();
			var classCountsDict = DataViewsUtils.GetClassCountsDict(gesturesData);
			if (classCountsDict != null)
			{
				int i = 0;
				int classCountDictCount = classCountsDict.Count;
				foreach (var classCount in classCountsDict)
				{
					string lineEnd = i < (classCountDictCount - 1) ? "\n" : "";
					sb.Append($"{classCount.Key,-9}: {classCount.Value}{lineEnd}");
					i++;
				}
			}

			return sb.ToString();
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
