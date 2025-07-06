using System;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.Kinect.KinectClassLib.Structures
{
	public class Bone: IEquatable<Bone>
	{
		#region Public properties
		public JointType ParentJoint
		{
			get;
		}

		public JointType ChildJoint
		{
			get;
		}
		#endregion

		#region Constructors
		public Bone(JointType parent, JointType child)
		{
			this.ParentJoint = parent;
			this.ChildJoint = child;
		}
		#endregion

		#region Overrides
		public override bool Equals(object obj)
		{
			return Equals(obj as Bone);
		}

		public override int GetHashCode()
		{
			return (this.ParentJoint.GetHashCode()) ^ (this.ChildJoint.GetHashCode());
		}

		public override string ToString()
		{
			return $"{this.ParentJoint} -> {this.ChildJoint}";
		}
		#endregion

		#region IEquatable implementation
		public bool Equals(Bone other)
		{
			if (other == null)
				return false;

			return this.ParentJoint == other.ParentJoint
				&& this.ChildJoint == other.ChildJoint;
		}
		#endregion
	}
}
