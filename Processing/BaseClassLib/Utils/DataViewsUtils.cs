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
	}
}
