using System;
using System.Linq;

namespace GestureRecognition.Processing.BaseClassLib.Utils
{
	public static class DataViewsUtils
	{
		public static string[] GetFeatures(Type dataViewType)
		{
			return dataViewType.GetProperties()?.Select(p => p.Name).ToArray() ?? new string[0];
		}

		public static bool NullableEquals(double? val1, double? val2)
		{
			if (val1.HasValue != val2.HasValue)
				return false;

			if (!val1.HasValue) 
				return true;

			return val1.Value == val2.Value;
		}
	}
}
