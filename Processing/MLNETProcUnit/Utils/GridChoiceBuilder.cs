using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.SearchSpace.Option;

public static class GridChoiceBuilder
{
	#region Public methods
	/// <summary>
	/// Tworzy ChoiceOption dla wartości całkowitych.
	/// points = ile punktów siatki (np. tyle, ile podajesz w SetGridSearchTuner(step)).
	/// Gwarantuje: min/max w zbiorze, unikalność, obecność default.
	/// </summary>
	public static ChoiceOption IntChoice(int min, int max, int points, int defaultVal)
	{
		if (max < min) 
			(min, max) = (max, min);

		points = Math.Max(points, 1);

		if (points == 1)
			return new ChoiceOption(new int[] {defaultVal}.Cast<object>().ToArray(), defaultVal);
		else if (points == 2)
			return new ChoiceOption(new int[] { min, max}.Cast<object>().ToArray(), min);

		var values = new List<int>();

		// jeśli zakres ma <= points wartości – weź po prostu pełną listę
		long countInRange = (long)max - min + 1;
		if (countInRange <= points)
		{
			for (int v = min; v <= max; v++) 
				values.Add(v);
		}
		else
		{
			// linspace na points punktów (włącznie z końcami), zaokrąglone do int
			for (int i = 0; i < points; i++)
			{
				double t = (points == 1) ? 0.0 : (double)i / (points - 1);
				int v = min + (int)Math.Round((max - min) * t);
				values.Add(v);
			}
		}

		// dołóż default i deduplikuj
		values.Add(Clamp(defaultVal, min, max));
		values = values.Distinct().OrderBy(v => v).ToList();

		// zbuduj ChoiceOption
		object[] objs = values.Cast<object>().ToArray();
		object def = Clamp(defaultVal, min, max);
		return new ChoiceOption(objs, def);
	}

	/// <summary>
	/// Tworzy ChoiceOption dla wartości zmiennoprzecinkowych (double).
	/// eps – tolerancja do deduplikacji wartości po zaokrągleniach.
	/// </summary>
	public static ChoiceOption DoubleChoice(double min, double max, int points, double defaultVal, double eps = 1e-9)
	{
		if (max < min) (min, max) = (max, min);
		points = Math.Max(points, 1);

		if (points == 1)
			return new ChoiceOption(new double[] { defaultVal }.Cast<object>().ToArray(), defaultVal);
		else if (points == 2)
			return new ChoiceOption(new double[] { min, max }.Cast<object>().ToArray(), min);

		var values = new List<double>();
		for (int i = 0; i < points; i++)
		{
			double t = (points == 1) ? 0.0 : (double)i / (points - 1);
			double v = min + (max - min) * t;
			values.Add(v);
		}

		// dołóż default i deduplikuj z tolerancją
		values.Add(Clamp(defaultVal, min, max));
		values = DistinctWithTolerance(values, eps).OrderBy(v => v).ToList();

		object[] objs = values.Cast<object>().ToArray();
		object def = (object)Clamp(defaultVal, min, max);
		return new ChoiceOption(objs, def);
	}
	#endregion

	#region Private methods
	private static int Clamp(int v, int min, int max)
	{
		return Math.Min(max, Math.Max(min, v));
	}

	private static double Clamp(double v, double min, double max)
	{
		return Math.Min(max, Math.Max(min, v));
	}

	private static List<double> DistinctWithTolerance(IEnumerable<double> src, double eps)
	{
		var sorted = src.OrderBy(x => x).ToList();
		var outList = new List<double>();
		foreach (double x in sorted)
		{
			if (outList.Count == 0 || Math.Abs(x - outList[^1]) > eps)
				outList.Add(x);
		}
		return outList;
	}
	#endregion
}
