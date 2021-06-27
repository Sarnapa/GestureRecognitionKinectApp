using System;
using System.Collections.Generic;
using Microsoft.Kinect;

namespace GestureRecognition.Processing.BaseClassLib.Structures.Kinect
{
	[Serializable]
	public sealed class BodyData
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
		public IReadOnlyDictionary<JointType, Joint> Joints
		{
			get;
			private set;
		}
		public BodyJointsColorSpacePointsDict JointsColorSpacePoints
		{
			get;
			private set;
		}
		public IReadOnlyDictionary<JointType, JointOrientation> JointOrientations
		{
			get;
			private set;
		}
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
		public FrameEdges ClippedEdges
		{
			get;
			private set;
		}
		public PointF Lean
		{
			get;
			private set;
		}
		public TrackingState LeanTrackingState
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public BodyData(Body body, BodyJointsColorSpacePointsDict jointsColorSpacePoints)
			: this(body)
		{
			this.JointsColorSpacePoints = jointsColorSpacePoints ?? new BodyJointsColorSpacePointsDict();
		}

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
