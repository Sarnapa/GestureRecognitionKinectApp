using GestureRecognition.Processing.BaseClassLib.Structures.Body;

namespace GestureRecognition.Processing.MLNETProcUnit.BodyTrackingModels.PoseLandmarksDetection
{
	public class PoseLandmark
	{
		#region Public properties
		public int Index
		{
			get;
			set;
		}

		public JointType JointType
		{
			get;
			set;
		}

		public float X
		{
			get;
			set;
		}

		public float Y
		{
			get; 
			set;
		}

		public float Z
		{
			get;
			set;
		}

		public float Visibility
		{
			get;
			set;
		}

		public float Presence
		{
			get;
			set;
		}
		#endregion
	}
}
