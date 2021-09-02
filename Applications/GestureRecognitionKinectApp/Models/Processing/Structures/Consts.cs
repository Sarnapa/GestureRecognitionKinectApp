using System;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures
{
	public static class Consts
	{
		public const string GestureRecordFileExtension = ".record";
		// TODO: This should be set in user options
		public const float GestureRecordResizingCoef = 0.4f;
		public const float ColorSpaceBodyJointDisplacementPositionLimit = 20f;

		public static readonly TimeSpan DefaultBodyTrackingStoppedTime = TimeSpan.FromSeconds(3d);
		public static readonly TimeSpan GestureToStartRecordingTimeLimit = TimeSpan.FromSeconds(3d);
		public static readonly TimeSpan GestureRecordTimeLimit = TimeSpan.FromSeconds(10d);
		public static readonly TimeSpan GestureRecordUserWithoutMovementTimeLimit = TimeSpan.FromSeconds(2d);
	}
}
