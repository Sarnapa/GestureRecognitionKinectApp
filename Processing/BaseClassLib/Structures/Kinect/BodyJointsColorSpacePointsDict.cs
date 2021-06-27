using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Kinect
{
	[Serializable]
	public class BodyJointsColorSpacePointsDict : IDictionary<JointType, ColorSpacePoint>
	{
		#region Private fields
		private IDictionary<JointType, ColorSpacePoint> internalDict;
		#endregion

		#region Constructors
		public BodyJointsColorSpacePointsDict()
		{
			this.internalDict = new Dictionary<JointType, ColorSpacePoint>();
		}
		#endregion

		#region IDictionary implementation
		public ColorSpacePoint this[JointType key]
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

		public ICollection<JointType> Keys
		{
			get
			{
				return this.internalDict.Keys;
			}
		}

		public ICollection<ColorSpacePoint> Values
		{
			get
			{
				return this.internalDict.Values;
			}
		}

		public int Count
		{
			get
			{
				return this.internalDict.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return this.internalDict.IsReadOnly;
			}
		}

		public void Add(JointType key, ColorSpacePoint value)
		{
			this.internalDict.Add(key, value);
		}

		public void Add(KeyValuePair<JointType, ColorSpacePoint> item)
		{
			this.internalDict.Add(item);
		}

		public void Clear()
		{
			this.internalDict.Clear();
		}

		public bool Contains(KeyValuePair<JointType, ColorSpacePoint> item)
		{
			return this.internalDict.Contains(item);
		}

		public bool ContainsKey(JointType key)
		{
			return this.ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<JointType, ColorSpacePoint>[] array, int arrayIndex)
		{
			this.internalDict.CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<JointType, ColorSpacePoint>> GetEnumerator()
		{
			return this.internalDict.GetEnumerator();
		}

		public bool Remove(JointType key)
		{
			return this.internalDict.Remove(key);
		}

		public bool Remove(KeyValuePair<JointType, ColorSpacePoint> item)
		{
			return this.internalDict.Remove(item);
		}

		public bool TryGetValue(JointType key, out ColorSpacePoint value)
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
