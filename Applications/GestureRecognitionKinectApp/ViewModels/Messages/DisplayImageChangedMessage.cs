using System;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages
{
	public class DisplayImageChangedMessage
	{
		public ImageKind ChangedDisplayImage
		{
			get; set;
		}
	}

	[Flags]
	public enum ImageKind
	{
		None = 0,
		Color = 1,
		Body = 2,
		All = 3,
	}
}
