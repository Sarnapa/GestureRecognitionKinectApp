using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;

namespace GestureRecognition.Processing.BaseClassLib.Utils
{
	public static class CsvHelperUtils
	{
		#region Consts
		public const string CsvFileExtension = ".csv";
		#endregion

		#region Public methods
		public static void WriteGesturesToFile(List<GestureDataView> gestures, string filePath)
		{
			if (gestures == null)
				throw new ArgumentNullException(nameof(gestures));
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentException(filePath);
			if (!filePath.EndsWith(CsvFileExtension))
				throw new ArgumentException(filePath);

			if (File.Exists(filePath))
			{
				using (var writer = new StreamWriter(filePath))
				{
					WriteGesturesToFile(gestures, writer);
				}
			}
			else
			{
				using (var file = File.Create(filePath))
				{
					using (var writer = new StreamWriter(file))
					{
						WriteGesturesToFile(gestures, writer);
					}
				}
			}
		}

		public static List<GestureDataView> GetGesturesFromFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentException(filePath);
			if (!filePath.EndsWith(CsvFileExtension))
				throw new ArgumentException(filePath);
			if (!File.Exists(filePath))
				throw new ArgumentException(filePath);

			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				return csv.GetRecords<GestureDataView>()?.ToList() ?? new List<GestureDataView>();
			}
		}
		#endregion

		#region Private methods
		public static void WriteGesturesToFile(List<GestureDataView> gestures, StreamWriter writer)
		{
			using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(gestures);
			}
		}
		#endregion
	}
}
