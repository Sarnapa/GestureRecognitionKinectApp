using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Structures.Managers
{
	public class RenderBodyFrameManagerParameters
	{
		public double HandSize
		{
			get;
			set;
		}

		public double JointThickness
		{
			get;
			set;
		}

		public double GestureRecognitionJointThickness
		{
			get;
			set;
		}

		public double BodySkeletonThickness
		{
			get;
			set;
		}

		public JointType[] JointsToIgnore
		{
			get;
			set;
		} = [];

		public JointType[] GestureRecognitionJoints
		{
			get;
			set;
		} = [];

		public Bone[] Bones
		{
			get;
			set;
		} = [];

		public bool IsInferredMode
		{
			get;
			set;
		} = false;

		public float ResizingCoef
		{
			get;
			set;
		} = 1.0f;
	}
}
