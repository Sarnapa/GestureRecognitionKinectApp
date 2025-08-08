using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public class GestureFeatures
	{
		#region Private fields
		private readonly IEnumerable<JointType> joints;
		private readonly IEnumerable<Bone> bones;
		#endregion

		#region Public properties
		public IDictionary<JointType, JointGestureFeatures> JointsGestureFeaturesDict
		{
			get;
			private set;
		} 

		public IDictionary<Bone, BoneJointsAngleData> BoneJointsAngleDataDict
		{
			get;
			private set;
		}

		public double? BetweenHandJointsDistanceMax
		{
			get;
			set;
		}

		public double? BetweenHandJointsDistanceMean
		{
			get;
			set;
		}

		public HandDominance HandDominance
		{
			get;
			set;
		}

		public bool IsValid
		{
			get
			{
				return this.joints.All(j => this.JointsGestureFeaturesDict.ContainsKey(j) 
					&& this.JointsGestureFeaturesDict[j] != null)
					&& this.bones.All(b => this.BoneJointsAngleDataDict.ContainsKey(b)
					&& this.BoneJointsAngleDataDict[b] != null);
			}
		}
		#endregion

		#region Constructors
		public GestureFeatures(IEnumerable<JointType> joints, IEnumerable<Bone> bones)
		{
			if (joints == null)
				throw new ArgumentNullException(nameof(joints));
			if (!joints.Any())
				throw new ArgumentException(nameof(joints));
			if (bones == null)
				throw new ArgumentNullException(nameof(bones));
			if (!bones.Any())
				throw new ArgumentException(nameof(bones));

			this.joints = joints;
			this.bones = bones;

			this.JointsGestureFeaturesDict = new ConcurrentDictionary<JointType, JointGestureFeatures>();
			this.BoneJointsAngleDataDict = new ConcurrentDictionary<Bone, BoneJointsAngleData>();
		}
		#endregion

		#region Public methods
		public void AddJointGestureFeature(JointType joint, JointGestureFeatures features)
		{
			if (features == null)
				throw new ArgumentNullException(nameof(features));

			if (this.joints.Contains(joint))
			{
				if (this.JointsGestureFeaturesDict.ContainsKey(joint))
					this.JointsGestureFeaturesDict[joint] = features;
				else
					this.JointsGestureFeaturesDict.Add(joint, features);
			}
		}

		public void AddBoneJointsAngleData(Bone bone, BoneJointsAngleData angleData)
		{
			if (angleData == null)
				throw new ArgumentNullException(nameof(angleData));

			if (this.bones.Contains(bone))
			{
				if (this.BoneJointsAngleDataDict.ContainsKey(bone))
					this.BoneJointsAngleDataDict[bone] = angleData;
				else
					this.BoneJointsAngleDataDict.Add(bone, angleData);
			}
		}
		#endregion
	}
}
