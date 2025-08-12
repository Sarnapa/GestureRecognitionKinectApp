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
		}

		public int LeavesCount
		{
			get;
			set;
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
