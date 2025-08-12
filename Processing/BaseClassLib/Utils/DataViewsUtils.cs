using System;
using System.Linq;
using System.Reflection;
using Microsoft.ML;

namespace GestureRecognition.Processing.BaseClassLib.Utils
{
	public static class DataViewsUtils
	{
		#region Public methods
		public static bool GestureFeatureEquals(float val1, float val2)
		{
			bool val1IsNaN = float.IsNaN(val1);
			bool val2IsNaN = float.IsNaN(val2);

			if (val1IsNaN && val2IsNaN)
				return true;

			if (val1IsNaN || val2IsNaN)
				return false;

			return val1 == val2;
		}

		public static string[] GetGestureFeatureColumns(Type dataType)
		{
			bool IsFloat(PropertyInfo p)
			{
				var t = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
				return t == typeof(float);
			}

			return dataType
					.GetProperties(BindingFlags.Public | BindingFlags.Instance)
					.Where(IsFloat)
					.Select(p => p.Name)
					.ToArray();
		}

		public static Type GetBestMatchingType(DataViewSchema schema, Type[] dataTypes)
		{
			var typesMatchesCount = dataTypes.Select(t => GetColumnsMatchesCount(schema, t)).ToArray();

			var best = typesMatchesCount
					.Where(p => p.matchesCount > 0)
					.OrderByDescending(p => p.matchesCount)
					.FirstOrDefault();

			return best.type;
		}
		#endregion

		#region Private methods
		private static (Type type, int matchesCount) GetColumnsMatchesCount(DataViewSchema schema, Type dataType)
		{
			string[] schemaColsNames = schema.Select(c => c.Name).ToArray();
			string[] dataTypeFeatureColumns = GetGestureFeatureColumns(dataType);

			int matchesCount = 0;
			foreach (string col in dataTypeFeatureColumns)
			{
				if (schemaColsNames.Contains(col))
				{
					matchesCount++;
				}
			}

			return (dataType, matchesCount);
		}
		#endregion
	}
}
