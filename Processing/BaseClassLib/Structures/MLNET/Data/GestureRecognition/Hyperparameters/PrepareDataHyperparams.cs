namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters
{
	#region PrepareDataHyperparams
	public class PrepareDataHyperparams
	{
		#region Public properties
		public int PcaRank
		{
			get;
			set;
		} = 0;
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.PcaRank)}: {this.PcaRank}";
		}
		#endregion
	}
	#endregion
}
