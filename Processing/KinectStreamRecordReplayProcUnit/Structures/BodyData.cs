using System;
using System.Collections.Generic;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Structures
{
	[Serializable]
	public sealed class BodyData
	{
		#region Public properties
		public bool IsTracked
		{
			get;
		}
		public ulong TrackingId
		{
			get;
		}
		public bool IsRestricted
		{
			get;
		}
		public IReadOnlyDictionary<JointType, Joint> Joints
		{
			get;
		}
		public IReadOnlyDictionary<JointType, JointOrientation> JointOrientations
		{
			get;
		}
		public HandState HandLeftState
		{
			get;
		}
		public TrackingConfidence HandLeftConfidence
		{
			get;
		}
		public HandState HandRightState
		{
			get;
		}
		public TrackingConfidence HandRightConfidence
		{
			get;
		}
		public FrameEdges ClippedEdges
		{
			get;
		}
		public PointF Lean
		{
			get;
		}
		public TrackingState LeanTrackingState
		{
			get;
		}
		#endregion

		#region Constructors
		public BodyData(Body body)
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
