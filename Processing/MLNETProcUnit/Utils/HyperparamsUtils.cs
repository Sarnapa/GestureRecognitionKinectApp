using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.SearchSpace;
using Microsoft.ML.SearchSpace.Option;

namespace GestureRecognition.Processing.MLNETProcUnit.Utils
{
	public static class HyperparamsUtils
	{
		#region Public methods
		public static Dictionary<string, Parameter> TryGetParams(Parameter root, IEnumerable<string> keys)
		{
			var pending = new HashSet<string>(keys, StringComparer.OrdinalIgnoreCase);
			var found = new Dictionary<string, Parameter>(StringComparer.OrdinalIgnoreCase);

			if (pending.Count == 0 || root is null)
				return found;

			var stack = new Stack<Parameter>();
			stack.Push(root);

			while (stack.Count > 0 && found.Count < pending.Count)
			{
				var node = stack.Pop();

				foreach (var (key, child) in ChildrenOrEmpty(node))
				{
					if (pending.Contains(key) && !found.ContainsKey(key))
					{
						found[key] = child;
						if (found.Count == pending.Count)
							return found;
						continue;
					}
					if (HasChildren(child))
						stack.Push(child);
				}
			}

			return found;
		}

		public static int EstimateGridSize(Microsoft.ML.SearchSpace.SearchSpace space, int numericStep)
		{
			int Product(OptionBase o) => o switch
			{
				ChoiceOption ch => ch.Choices?.Length ?? 0,
				UniformNumericOption _ => numericStep,
				Microsoft.ML.SearchSpace.SearchSpace nested => nested.Aggregate(1, (acc, kv) => acc * Product(kv.Value)),
				_ => 1
			};
			return Product(space);
		}

		public static void NormalizeFixedNumerics(Microsoft.ML.SearchSpace.SearchSpace space, double eps = 1e-9)
		{
			string[] keys = space.Select(kv => kv.Key).ToArray();
			foreach (string key in keys)
			{
				var opt = space[key];
				switch (opt)
				{
					case UniformIntOption ui when ui.Min == ui.Max:
						space[key] = new ChoiceOption([ui.Min], defaultChoice: ui.Min);
						break;

					case UniformDoubleOption ud when Math.Abs(ud.Min - ud.Max) <= eps:
						space[key] = new ChoiceOption([ud.Min], defaultChoice: ud.Min);
						break;
				}
			}
		}

		public static int CountNumericDims(Microsoft.ML.SearchSpace.SearchSpace space)
		{
			int Count(OptionBase o) => o switch
			{
				UniformNumericOption _ => 1,
				ChoiceOption _ => 0,
				Microsoft.ML.SearchSpace.SearchSpace nested => nested.Sum(kv => Count(kv.Value)),
				_ => 0
			};
			return Count(space);
		}

		public static void DumpSearchSpaceInfo(Microsoft.ML.SearchSpace.SearchSpace space)
		{
			Console.WriteLine($"=== Search space info ===");
			foreach (var kv in space)
			{
				var opt = kv.Value;
				switch (opt)
				{
					case UniformIntOption ui:
						Console.WriteLine($"[Int]   {kv.Key}: [{ui.Min}, {ui.Max}] default={ui.Default?.FirstOrDefault() ?? double.NaN}");
						break;
					case UniformDoubleOption ud:
						Console.WriteLine($"[Double]{kv.Key}: [{ud.Min}, {ud.Max}] default={ud.Default?.FirstOrDefault() ?? double.NaN}");
						break;
					case ChoiceOption ch:
						Console.WriteLine($"[Choice]{kv.Key}: [{string.Join(", ", ch.Choices?.Select(c => c.ToString()) ?? [])}] default={ch.Default?.FirstOrDefault()}");
						break;
					default:
						break;
				}
			}

			// Console.WriteLine($"Search space dims: {CountNumericDims(space)}");
			Console.WriteLine();
		}
		#endregion

		#region Private methods
		public static IEnumerable<KeyValuePair<string, Parameter>> ChildrenOrEmpty(Parameter p)
		{
			if (p is not IEnumerable<KeyValuePair<string, Parameter>> ie)
				yield break;

			IEnumerator<KeyValuePair<string, Parameter>>? it = null;
			try 
			{ 
				it = ie.GetEnumerator(); 
			}
			catch 
			{ 
				yield break; 
			}

			using (it)
			{
				while (true)
				{
					bool ok;
					try 
					{ 
						ok = it.MoveNext(); 
					}
					catch 
					{ 
						yield break; 
					}

					if (!ok) 
						yield break;

					KeyValuePair<string, Parameter> cur;
					try 
					{ 
						cur = it.Current; 
					}
					catch 
					{ 
						yield break; 
					}

					yield return cur;
				}
			}
		}

		public static bool HasChildren(Parameter p)
		{
			foreach (var _ in ChildrenOrEmpty(p))
				return true;
			return false;
		}
		#endregion
	}
}
