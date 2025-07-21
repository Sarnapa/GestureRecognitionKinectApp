using System;
using System.Numerics;
using System.Runtime.Serialization;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	[Serializable]
	[MessagePackObject(keyAsPropertyName: true)]
	public partial struct Joint: IEquatable<Joint>/*, ISerializable*/
	{
		#region Public properties
		public JointType JointType
		{
			get;
			private set;
		}
		public Vector3 Position
		{
			get;
			private set;
		}
		public TrackingState TrackingState
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public Joint(JointType jointType, Vector3 position, TrackingState trackingState)
		{
			this.JointType = jointType;
			this.Position = position;
			this.TrackingState = trackingState;
		}

		//private Joint(SerializationInfo info, StreamingContext context)
		//{
		//	this.JointType = (JointType)info.GetValue("JointType", typeof(JointType));
		//	float x = info.GetSingle("X");
		//	float y = info.GetSingle("Y");
		//	float z = info.GetSingle("Z");
		//	this.Position = new Vector3(x, y, z);
		//	this.TrackingState = (TrackingState)info.GetValue("TrackingState", typeof(TrackingState));
		//}
		#endregion

		#region ISerializable implementation
		//public void GetObjectData(SerializationInfo info, StreamingContext context)
		//{
		//	info.AddValue("JointType", JointType);
		//	info.AddValue("X", Position.X);
		//	info.AddValue("Y", Position.Y);
		//	info.AddValue("Z", Position.Z);
		//	info.AddValue("TrackingState", TrackingState);
		//}
		#endregion

		#region Overrides
		public override int GetHashCode()
		{
			int num = this.TrackingState.GetHashCode() ^ this.JointType.GetHashCode();
			return this.Position.GetHashCode() ^ num;
		}

		public bool Equals(Joint joint)
		{
			if (joint == null)
				return false;

			if (this.JointType != joint.JointType)
				return false;

			if (!this.Position.Equals(joint.Position))
				return false;

			if (this.TrackingState != joint.TrackingState)
				return false;

			return true;
		}

		public override bool Equals(object obj)
		{
			return Equals((Joint)obj);
		}

		public static bool operator ==(Joint a, Joint b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Joint a, Joint b)
		{
			return !a.Equals(b);
		}
		#endregion
	}
}
