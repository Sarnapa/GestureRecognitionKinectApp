using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace
{
	public class PrepareDataSearchSpaceValues
	{
		#region Public properties
		public SearchSpaceValues<PcaChoice> PcaValues
		{
			get;
			set;
		} = new SearchSpaceValues<PcaChoice> { Values = new PcaChoice[] { new PcaChoice() }, Default = new PcaChoice() };
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.PcaValues)}: {this.PcaValues}";
		}
		#endregion
	}
}
