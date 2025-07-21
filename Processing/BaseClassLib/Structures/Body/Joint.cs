using System;
using System.Numerics;
using MessagePack;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Body
{
	[MessagePackObject(keyAsPropertyName: true)]
	public partial struct Joint: IEquatable<Joint>
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
