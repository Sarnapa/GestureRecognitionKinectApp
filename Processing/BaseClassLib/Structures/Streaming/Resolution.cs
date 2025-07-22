namespace GestureRecognition.Processing.BaseClassLib.Structures.Streaming
{
	#region SupportedResolutionsConsts
	public static class SupportedResolutionsConsts
	{
		public const int VGA_RESOLUTION_WIDTH = 640;
		public const int VGA_RESOLUTION_HEIGHT = 480;
		public const int HD_RESOLUTION_WIDTH = 1280;
		public const int HD_RESOLUTION_HEIGHT = 720;
		public const int FullHD_RESOLUTION_WIDTH = 1920;
		public const int FullHD_RESOLUTION_HEIGHT = 1080;
		public const int UltraHD_RESOLUTION_WIDTH = 3840;
		public const int UltraHD_RESOLUTION_HEIGHT = 2160;
	}
	#endregion

	#region ResolutionType
	// Supported resolutions - important for using AI models to track user movement
	public enum ResolutionType
	{
		Unknown,
		// 640x480
		VGA,
		// 1280x720
		HD,
		// 1920x1080
		FullHD,
		// 3840x2160
		UltraHD
	}
	#endregion
}
