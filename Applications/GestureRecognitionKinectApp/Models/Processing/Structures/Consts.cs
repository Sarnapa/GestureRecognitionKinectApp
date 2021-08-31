using System;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures
{
	public static class Consts
	{
		public const string GestureRecordFileExtension = ".record";
		// TODO: This should be set in user options
		public const float GestureRecordResizingCoef = 0.4f;

		public static readonly TimeSpan DefaultBodyTrackingStoppedTime = TimeSpan.FromSeconds(3);
		public static readonly TimeSpan GestureRecordTimeLimit = TimeSpan.FromSeconds(15);
		public static readonly TimeSpan GestureToStartRecordingTimeLimit = TimeSpan.FromSeconds(3);
	}
}
