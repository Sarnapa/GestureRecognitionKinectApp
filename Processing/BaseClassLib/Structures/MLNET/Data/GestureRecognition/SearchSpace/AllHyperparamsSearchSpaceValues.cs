namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace
{
	public class AllHyperparamsSearchSpaceValues
	{
		#region Public properties
		public SearchSpaceIntRangeValues PcaRankValues
		{
			get;
			set;
		} = new SearchSpaceIntRangeValues { Min = 0, Max = 0, Default = 0 };

		public SearchSpaceIntRangeValues TreesCountValues
		{
			get;
			set;
		} = new SearchSpaceIntRangeValues() { Min = 500, Max = 500, Default = 500 };

		public SearchSpaceIntRangeValues LeavesCountValues
		{
			get;
			set;
		} = new SearchSpaceIntRangeValues() { Min = 32, Max = 32, Default = 32 };

		public SearchSpaceIntRangeValues MinimumExampleCountPerLeafValues
		{
			get;
			set;
		} = new SearchSpaceIntRangeValues() { Min = 10, Max = 10, Default = 10 };

		public SearchSpaceDoubleRangeValues FeatureFractionValues
		{
			get;
			set;
		} = new SearchSpaceDoubleRangeValues() { Min = 0.2d, Max = 0.2d, Default = 0.2d };

		public SearchSpaceDoubleRangeValues BaggingExampleFractionValues
		{
			get;
			set;
		} = new SearchSpaceDoubleRangeValues() { Min = 1.0d, Max = 1.0d, Default = 1.0d };
		#endregion
	}
}
