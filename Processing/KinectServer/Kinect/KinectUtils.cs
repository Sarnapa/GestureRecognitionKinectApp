using System.Collections.Generic;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using MSKinect = Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectServer.Kinect
{
	public static class KinectUtils
	{
		#region Public methods
		public static Dictionary<JointType, Joint> GetJointsDict(IReadOnlyDictionary<MSKinect.JointType, MSKinect.Joint> joints, MSKinect.TrackingConfidence handLeftConfidence,
			MSKinect.TrackingConfidence handRightConfidence)
		{
			var result = new Dictionary<JointType, Joint>();

			if (joints != null)
			{
				foreach (var jointPair in joints)
				{
					var jointType = jointPair.Key;
					var joint = jointPair.Value;

					bool isLeft = IsJointLeftType(jointType);
					bool isHandJointType = IsHandJointType(jointType, isLeft);

					if (isHandJointType)
					{
						if (isLeft && handLeftConfidence == MSKinect.TrackingConfidence.High)
						{
							result.Add(jointType.Map(), joint.Map());
						}
						else if (!isLeft && handRightConfidence == MSKinect.TrackingConfidence.High)
						{
							result.Add(jointType.Map(), joint.Map());
						}
					}
					else
					{
						result.Add(jointType.Map(), joint.Map());
					}
				}
			}

			return result;
		}

		public static BodyJointsColorSpacePointsDict GetFilteredBodyJointsColorSpacePointsDict(Dictionary<JointType, Joint> jointsDict,
			BodyJointsColorSpacePointsDict jointsColorSpacePoints)
		{
			var result = new BodyJointsColorSpacePointsDict();

			foreach (var colorSpacePointPair in jointsColorSpacePoints)
			{
				if (jointsDict.ContainsKey(colorSpacePointPair.Key))
					result.Add(colorSpacePointPair.Key, colorSpacePointPair.Value);
			}

			return result;
		}

		public static bool IsHandJointType(MSKinect.JointType jointType, bool isLeft)
		{
			if (isLeft)
			{
				return jointType == MSKinect.JointType.WristLeft || jointType == MSKinect.JointType.HandLeft
					|| jointType == MSKinect.JointType.ThumbLeft || jointType == MSKinect.JointType.HandTipLeft;
			}

			return jointType == MSKinect.JointType.WristRight || jointType == MSKinect.JointType.HandRight
				|| jointType == MSKinect.JointType.ThumbRight || jointType == MSKinect.JointType.HandTipRight;
		}

		private static bool IsJointLeftType(MSKinect.JointType jointType)
		{
			return jointType.ToString().Contains("Left");
		}
		#endregion
	}
}
