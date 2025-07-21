using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	[MessagePackObject]
	public class BodyJointsColorSpacePointsDict: IDictionary<JointType, Vector2>
	{
		#region Private fields
		private IDictionary<JointType, Vector2> internalDict;
		#endregion

		#region Constructors
		public BodyJointsColorSpacePointsDict()
		{
			this.internalDict = new Dictionary<JointType, Vector2>();
		}
		#endregion

		#region IDictionary implementation
		[IgnoreMember]
		public Vector2 this[JointType key]
		{
			get
			{
				return this.internalDict[key];
			}

			set
			{
				this.internalDict[key] = value;
			}
		}

		[IgnoreMember]
		public ICollection<JointType> Keys
		{
			get
			{
				return this.internalDict.Keys;
			}
		}

		[IgnoreMember]
		public ICollection<Vector2> Values
		{
			get
			{
				return this.internalDict.Values;
			}
		}

		[IgnoreMember]
		public int Count
		{
			get
			{
				return this.internalDict.Count;
			}
		}

		[IgnoreMember]
		public bool IsReadOnly
		{
			get
			{
				return this.internalDict.IsReadOnly;
			}
		}

		public void Add(JointType key, Vector2 value)
		{
			this.internalDict.Add(key, value);
		}

		public void Add(KeyValuePair<JointType, Vector2> item)
		{
			this.internalDict.Add(item);
		}

		public void Clear()
		{
			this.internalDict.Clear();
		}

		public bool Contains(KeyValuePair<JointType, Vector2> item)
		{
			return this.internalDict.Contains(item);
		}

		public bool ContainsKey(JointType key)
		{
			return this.ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<JointType, Vector2>[] array, int arrayIndex)
		{
			this.internalDict.CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<JointType, Vector2>> GetEnumerator()
		{
			return this.internalDict.GetEnumerator();
		}

		public bool Remove(JointType key)
		{
			return this.internalDict.Remove(key);
		}

		public bool Remove(KeyValuePair<JointType, Vector2> item)
		{
			return this.internalDict.Remove(item);
		}

		public bool TryGetValue(JointType key, out Vector2 value)
		{
			return this.internalDict.TryGetValue(key, out value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.internalDict.GetEnumerator();
		}
		#endregion
	}
}
