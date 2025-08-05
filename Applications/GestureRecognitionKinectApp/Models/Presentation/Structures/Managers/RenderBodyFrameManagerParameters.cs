using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Structures.Managers
{
	public class RenderBodyFrameManagerParameters
	{
		#region Publice properties
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
		#endregion

		#region Public Methods
		public static RenderBodyFrameManagerParameters GetParameters(BodyTrackingMode trackingMode, float resizingCoef = 1.0f)
		{
			RenderBodyFrameManagerParameters parameters;
			switch (trackingMode)
			{
				case BodyTrackingMode.MediaPipePoseLandmarks:
					parameters = new RenderBodyFrameManagerParameters()
					{
						HandSize = MediaPipePoseLandmarksRenderBodyFrameConsts.HAND_SIZE,
						JointThickness = MediaPipePoseLandmarksRenderBodyFrameConsts.JOINT_THICKNESS,
						GestureRecognitionJointThickness = MediaPipePoseLandmarksRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS,
						BodySkeletonThickness = MediaPipePoseLandmarksRenderBodyFrameConsts.BODY_SKELETON_THICKNESS,
						JointsToIgnore = MediaPipePoseLandmarksRenderBodyFrameConsts.JOINTS_TO_IGNORE,
						GestureRecognitionJoints = MediaPipePoseLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints,
						Bones = MediaPipePoseLandmarksBonesDefinitions.AllBonesWithoutHeadAndLegs.ToArray(),
						IsInferredMode = false,
						ResizingCoef = resizingCoef
					};
					break;
				case BodyTrackingMode.MediaPipeHandLandmarks:
					parameters = new RenderBodyFrameManagerParameters()
					{
						HandSize = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.HAND_SIZE,
						JointThickness = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.JOINT_THICKNESS,
						GestureRecognitionJointThickness = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS,
						BodySkeletonThickness = (float)MediaPipeHandLandmarksRenderBodyFrameConsts.BODY_SKELETON_THICKNESS,
						JointsToIgnore = MediaPipeHandLandmarksRenderBodyFrameConsts.JOINTS_TO_IGNORE,
						GestureRecognitionJoints = MediaPipeHandLandmarksGestureRecognitionDefinitions.GestureRecognitionJoints,
						Bones = MediaPipeHandLandmarksBonesDefinitions.AllBones.ToArray(),
						IsInferredMode = false,
						ResizingCoef = resizingCoef
					};
					break;
				default:
					parameters = new RenderBodyFrameManagerParameters()
					{
						HandSize = (float)KinectRenderBodyFrameConsts.HAND_SIZE,
						JointThickness = (float)KinectRenderBodyFrameConsts.JOINT_THICKNESS,
						GestureRecognitionJointThickness = (float)KinectRenderBodyFrameConsts.GESTURE_RECOGNITION_JOINT_THICKNESS,
						BodySkeletonThickness = (float)KinectRenderBodyFrameConsts.BODY_SKELETON_THICKNESS,
						JointsToIgnore = KinectRenderBodyFrameConsts.JOINTS_TO_IGNORE,
						GestureRecognitionJoints = KinectGestureRecognitionDefinitions.GestureRecognitionJoints,
						Bones = KinectBonesDefinitions.AllBonesWithoutLegs.ToArray(),
						IsInferredMode = false,
						ResizingCoef = resizingCoef
					};
					break;
			}

			return parameters;
		}
		#endregion
	}
}
