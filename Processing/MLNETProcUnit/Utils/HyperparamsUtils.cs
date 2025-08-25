using System;
using System.Collections.Generic;
using Microsoft.ML.SearchSpace;

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
