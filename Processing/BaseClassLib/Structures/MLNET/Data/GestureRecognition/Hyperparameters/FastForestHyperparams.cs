namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters
{
	public class FastForestHyperparams
	{
		#region Public properties
		public int TreesCount
		{
			get;
			set;
		} = 500;

		public int LeavesCount
		{
			get;
			set;
		} = 32;

		public int MinimumExampleCountPerLeaf
		{
			get;
			set;
		} = 10;

		public double FeatureFraction
		{
			get;
			set;
		} = 0.2d;

		public double BaggingExampleFraction
		{
			get;
			set;
		} = 1.0d;
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.TreesCount)}: {this.TreesCount}\n" +
				$"{nameof(this.LeavesCount)}: {this.LeavesCount}\n" +
				$"{nameof(this.MinimumExampleCountPerLeaf)}: {this.MinimumExampleCountPerLeaf}\n" +
				$"{nameof(this.FeatureFraction)}: {this.FeatureFraction}\n" +
				$"{nameof(this.BaggingExampleFraction)}: {this.BaggingExampleFraction}";
		}
		#endregion
	}
}
