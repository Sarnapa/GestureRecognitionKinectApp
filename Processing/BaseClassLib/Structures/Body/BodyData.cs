using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	[Serializable]
	[MessagePackObject(keyAsPropertyName: true)]
	public partial class BodyData
	{
		#region Public properties
		public ulong TrackingId
		{
			get;
			private set;
		}
		public bool IsTracked
		{
			get;
			private set;
		}
		public IReadOnlyDictionary<JointType, Joint> Joints
		{
			get;
			private set;
		} = new Dictionary<JointType, Joint>();
		public HandState HandLeftState
		{
			get;
			private set;
		}
		public TrackingConfidence HandLeftConfidence
		{
			get;
			private set;
		}
		public HandState HandRightState
		{
			get;
			private set;
		}
		public TrackingConfidence HandRightConfidence
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BodyData()
		{}

		public BodyData(ulong trackingId, bool isTracked, IReadOnlyDictionary<JointType, Joint> joints,
			HandState handLeftState, TrackingConfidence handLeftConfidence,
			HandState handRightState, TrackingConfidence handRightConfidence)
		{
			this.TrackingId = trackingId;
			this.IsTracked = isTracked;
			this.Joints = joints ?? new Dictionary<JointType, Joint>();
			this.HandLeftState = handLeftState;
			this.HandLeftConfidence = handLeftConfidence;
			this.HandRightState = handRightState;
			this.HandRightConfidence = handRightConfidence;
		}

		public BodyData(BodyData other)
		{
			if (other == null)
				throw new ArgumentNullException(nameof(other));

			this.TrackingId = other.TrackingId;
			this.IsTracked = other.IsTracked;
			this.Joints = new ReadOnlyDictionary<JointType, Joint>(other.Joints?
				.ToDictionary(kv => kv.Key, kv => kv.Value) ?? new Dictionary<JointType, Joint>());
			this.HandLeftState = other.HandLeftState;
			this.HandLeftConfidence = other.HandLeftConfidence;
			this.HandRightState = other.HandRightState;
			this.HandRightConfidence = other.HandRightConfidence;
		}
		#endregion
	}
}
