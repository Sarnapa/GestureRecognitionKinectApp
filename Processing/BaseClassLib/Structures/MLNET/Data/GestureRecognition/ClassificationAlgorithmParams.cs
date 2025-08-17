namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition
{
	#region BaseClassificationAlgorithmParams
	public abstract class BaseClassificationAlgorithmParams
	{
		#region Public properties
		public virtual ClassificationAlgorithmKind AlgorithmKind
		{
			get
			{
				return ClassificationAlgorithmKind.Unknown;
			}
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"Algoritm kind: {this.AlgorithmKind}";
		}
		#endregion
	}
	#endregion

	#region FastForestParams
	public class FastForestParams: BaseClassificationAlgorithmParams
	{
		#region Public properties
		public override ClassificationAlgorithmKind AlgorithmKind
		{
			get
			{
				return ClassificationAlgorithmKind.FastForest;
			}
		}

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
			return $"Algoritm kind: {this.AlgorithmKind}\n" +
				$"Trees count: {this.TreesCount}\n" +
				$"Leaves count: {this.LeavesCount}\n" +
				$"Minimum examples count per leaf: {this.MinimumExampleCountPerLeaf}\n" +
				$"Features fraction: {this.FeatureFraction}\n" +
				$"Bagging examples fraction: {this.BaggingExampleFraction}";
		}
		#endregion
	}
	#endregion

	#region ClassificationAlgorithmKind
	public enum ClassificationAlgorithmKind
	{
		Unknown,
		FastForest,
	}
	#endregion
}
