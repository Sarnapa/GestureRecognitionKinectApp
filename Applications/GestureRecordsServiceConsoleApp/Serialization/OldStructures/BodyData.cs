using System;
using System.Collections.Generic;
using MSKinect = Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Kinect
{
	[Serializable]
	public class BodyData
	{
		#region Public properties
		public bool IsTracked
		{
			get;
			private set;
		}
		public ulong TrackingId
		{
			get;
			private set;
		}
		public bool IsRestricted
		{
			get;
			private set;
		}
		public IReadOnlyDictionary<MSKinect.JointType, MSKinect.Joint> Joints
		{
			get;
			private set;
		}
		public IReadOnlyDictionary<MSKinect.JointType, MSKinect.JointOrientation> JointOrientations
		{
			get;
			private set;
		}
		public MSKinect.HandState HandLeftState
		{
			get;
			private set;
		}
		public MSKinect.TrackingConfidence HandLeftConfidence
		{
			get;
			private set;
		}
		public MSKinect.HandState HandRightState
		{
			get;
			private set;
		}
		public MSKinect.TrackingConfidence HandRightConfidence
		{
			get;
			private set;
		}
		public MSKinect.FrameEdges ClippedEdges
		{
			get;
			private set;
		}
		public MSKinect.PointF Lean
		{
			get;
			private set;
		}
		public MSKinect.TrackingState LeanTrackingState
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BodyData(MSKinect.Body body)
		{
			this.IsTracked = body.IsTracked;
			this.TrackingId = body.TrackingId;
			this.IsRestricted = body.IsRestricted;
			this.Joints = body.Joints;
			this.JointOrientations = body.JointOrientations;
			this.HandLeftState = body.HandLeftState;
			this.HandLeftConfidence = body.HandLeftConfidence;
			this.HandRightState = body.HandRightState;
			this.HandRightConfidence = body.HandRightConfidence;
			this.ClippedEdges = body.ClippedEdges;
			this.Lean = body.Lean;
			this.LeanTrackingState = body.LeanTrackingState;
		}
		#endregion
	}
}
