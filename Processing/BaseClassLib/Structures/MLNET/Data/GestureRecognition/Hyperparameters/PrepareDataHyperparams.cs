using System;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters
{
	#region PrepareDataHyperparams
	public class PrepareDataHyperparams
	{
		#region Public properties
		public PcaChoice Pca
		{
			get;
			set;
		} = new PcaChoice();

		public bool UsePca
		{
			get
			{
				return this.Pca?.UsePca ?? false;
			}
		}

		public int PcaRank
		{
			get
			{
				return this.Pca?.PcaRank ?? 0;
			}
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.UsePca)}: {this.UsePca}\n" +
				$"{nameof(this.PcaRank)}: {this.PcaRank}";
		}
		#endregion
	}
	#endregion

	#region PcaChoice
	public class PcaChoice: IEquatable<PcaChoice>
	{
		#region Constructors
		public PcaChoice()
		{}

		public PcaChoice(bool usePca, int pcaRank)
		{
			this.UsePca = usePca;
			this.PcaRank = pcaRank;
		}
		#endregion

		#region Public properties
		public bool UsePca
		{
			get;
			set;
		} = false;

		public int PcaRank
		{
			get;
			set;
		}
		#endregion

		#region IEquatable implementation
		public bool Equals(PcaChoice other)
		{
			if (other == null)
				return false;

			return this.UsePca == other.UsePca && this.PcaRank == other.PcaRank;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as PcaChoice);
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = hash * 23 + this.UsePca.GetHashCode();
			hash = hash * 23 + this.PcaRank.GetHashCode();
			return hash;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"({nameof(this.UsePca)}: {this.UsePca}, {nameof(this.PcaRank)}: {this.PcaRank})";
		}
		#endregion
	}
	#endregion
}
