using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	[Serializable]
	[MessagePackObject]
	public class BodyJointsColorSpacePointsDict: IDictionary<JointType, Vector2>/*, ISerializable*/
	{
		#region Private fields
		private IDictionary<JointType, Vector2> internalDict;
		#endregion

		#region Constructors
		public BodyJointsColorSpacePointsDict()
		{
			this.internalDict = new Dictionary<JointType, Vector2>();
		}
		//protected BodyJointsColorSpacePointsDict(SerializationInfo info, StreamingContext context)
		//{
		//	this.internalDict = new Dictionary<JointType, Vector2>();
		//	int count = info.GetInt32("Count");

		//	for (int i = 0; i < count; i++)
		//	{
		//		JointType key = (JointType)info.GetValue($"Key_{i}", typeof(JointType));
		//		float x = info.GetSingle($"Value_{i}_X");
		//		float y = info.GetSingle($"Value_{i}_Y");
		//		Vector2 value = new Vector2(x, y);
		//		this.internalDict[key] = value;
		//	}
		//}
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

		#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("Count", this.internalDict.Count);

		//	int i = 0;
		//	foreach (var kv in this.internalDict)
		//	{
		//		info.AddValue($"Key_{i}", kv.Key);
		//		info.AddValue($"Value_{i}_X", kv.Value.X);
		//		info.AddValue($"Value_{i}_Y", kv.Value.Y);
		//		i++;
		//	}
		//}
		#endregion
	}
}
