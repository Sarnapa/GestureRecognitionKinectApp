using System;
using System.Collections.Generic;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.Hyperparameters
{
	public class AllHyperparams : IEqualityComparer<AllHyperparams>
	{
		#region Public properties
		public int PcaRank
		{
			get;
			set;
		} = 0;

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

		#region IEqualityComparer implementation
		public bool Equals(AllHyperparams x, AllHyperparams y)
		{
			if (x == null && y == null)
				return true;
			if (x == null || y == null)
				return false;

			return x.PcaRank == y.PcaRank &&
				x.TreesCount == y.TreesCount &&
				x.LeavesCount == y.LeavesCount &&
				x.MinimumExampleCountPerLeaf == y.MinimumExampleCountPerLeaf &&
				Math.Abs(x.FeatureFraction - y.FeatureFraction) < 1e-9 &&
				Math.Abs(x.BaggingExampleFraction - y.BaggingExampleFraction) < 1e-9;
		}

		public int GetHashCode(AllHyperparams obj)
		{
			if (obj == null)
				return 0;

			int hash = 17;
			hash = hash * 23 + obj.PcaRank.GetHashCode();
			hash = hash * 23 + obj.TreesCount.GetHashCode();
			hash = hash * 23 + obj.LeavesCount.GetHashCode();
			hash = hash * 23 + obj.MinimumExampleCountPerLeaf.GetHashCode();
			hash = hash * 23 + obj.FeatureFraction.GetHashCode();
			hash = hash * 23 + obj.BaggingExampleFraction.GetHashCode();
			return hash;
		}
		#endregion

		#region Public methods
		public override bool Equals(object obj)
		{
			return Equals(this, obj as AllHyperparams);
		}

		public override int GetHashCode()
		{
			return GetHashCode(this);
		}
		#endregion
	}
}
