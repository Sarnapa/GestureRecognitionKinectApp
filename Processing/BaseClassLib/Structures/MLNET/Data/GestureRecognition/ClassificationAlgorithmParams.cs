using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters;

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
			return $"{nameof(this.AlgorithmKind)}: {this.AlgorithmKind}";
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

		public FastForestHyperparams Hyperparams
		{
			get;
			set;
		} = new FastForestHyperparams();
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.AlgorithmKind)}: {this.AlgorithmKind}\n" +
				$"{nameof(this.Hyperparams)}:\n" +
				$"{this.Hyperparams}";
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
