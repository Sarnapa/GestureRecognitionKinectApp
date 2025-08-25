namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition.SearchSpace
{
	#region SearchSpaceValues
	public abstract class SearchSpaceRangeValues<T>
	{
		#region Public properties
		public T Min
		{
			get;
			set;
		}

		public T Max
		{
			get;
			set;
		}

		public T Default
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			return $"{nameof(this.Min)}: {this.Min} | {nameof(this.Max)}: {this.Max} | {nameof(this.Default)}: {this.Default}";
		}
		#endregion
	}
	#endregion

	#region SearchSpaceIntValues
	public class SearchSpaceIntRangeValues: SearchSpaceRangeValues<int>
	{}
	#endregion

	#region SearchSpaceDoubleValues
	public class SearchSpaceDoubleRangeValues: SearchSpaceRangeValues<double>
	{}
	#endregion

	#region SearchSpaceBoolValues
	public class SearchSpaceValues<T>
	{
		#region Public properties
		public T[] Values
		{
			get;
			set;
		} = new T[0];

		public T Default
		{
			get;
			set;
		}
		#endregion

		#region Public methods
		public override string ToString()
		{
			string valuesText = this.Values == null ? string.Empty : string.Join(", ", this.Values);

			return $"{nameof(this.Values)}: [{valuesText}] | {nameof(this.Default)}: {this.Default}";
		}
		#endregion
	}
	#endregion
}
