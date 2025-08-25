namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace
{
	public class PrepareDataSearchSpaceValues
	{
		#region Public properties
		public SearchSpaceIntRangeValues PcaRankValues
		{
			get;
			set;
		} = new SearchSpaceIntRangeValues { Min = 0, Max = 0, Default = 0 };
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.PcaRankValues)}: {this.PcaRankValues}";
		}
		#endregion
	}
}
