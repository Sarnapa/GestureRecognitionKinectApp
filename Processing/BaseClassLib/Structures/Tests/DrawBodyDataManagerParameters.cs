using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Tests
{
	public class DrawBodyDataManagerParameters
	{
		public string InputImagePath
		{
			get;
			set;
		}

		public string OutputImagePath
		{
			get;
			set;
		}

		public float HandSize
		{
			get;
			set;
		}

		public float JointThickness
		{
			get;
			set;
		}

		public float GestureRecognitionJointThickness
		{
			get;
			set;
		}

		public float BodySkeletonThickness
		{
			get;
			set;
		}

		public JointType[] JointsToIgnore
		{
			get;
			set;
		} = new JointType[0];

		public JointType[] GestureRecognitionJoints
		{
			get;
			set;
		} = new JointType[0];

		public Bone[] Bones
		{
			get;
			set;
		} = new Bone[0];

		public bool IsInferredMode
		{
			get;
			set;
		} = false;
	}
}
