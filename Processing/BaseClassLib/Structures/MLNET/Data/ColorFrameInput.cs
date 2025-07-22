using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;

namespace GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data
{
	#region BaseColorFrameInput
	public abstract class BaseColorFrameInput
	{
		public abstract MLImage Image
		{
			get;
			set;
		}
		public abstract int ImageWidth
		{
			get;
		}

		public abstract int ImageHeight
		{
			get;
		}
	}
	#endregion

	#region ColorFrameVGAInput
	public class ColorFrameVGAInput: BaseColorFrameInput
	{
		[ImageType(SupportedResolutionsConsts.VGA_RESOLUTION_WIDTH, SupportedResolutionsConsts.VGA_RESOLUTION_HEIGHT)]
		public override MLImage Image
		{
			get;
			set;
		}

		public override int ImageWidth
		{
			get
			{
				return SupportedResolutionsConsts.VGA_RESOLUTION_WIDTH;
			}
		}

		public override int ImageHeight
		{
			get
			{
				return SupportedResolutionsConsts.VGA_RESOLUTION_HEIGHT;
			}
		}
	}
	#endregion

	#region ColorFrameHDInput
	public class ColorFrameHDInput: BaseColorFrameInput
	{
		[ImageType(SupportedResolutionsConsts.HD_RESOLUTION_WIDTH, SupportedResolutionsConsts.HD_RESOLUTION_HEIGHT)]
		public override MLImage Image
		{
			get;
			set;
		}

		public override int ImageWidth
		{
			get
			{
				return SupportedResolutionsConsts.HD_RESOLUTION_WIDTH;
			}
		}

		public override int ImageHeight
		{
			get
			{
				return SupportedResolutionsConsts.HD_RESOLUTION_HEIGHT;
			}
		}
	}
	#endregion

	#region ColorFrameFullHDInput
	public class ColorFrameFullHDInput: BaseColorFrameInput
	{
		[ImageType(SupportedResolutionsConsts.FullHD_RESOLUTION_WIDTH, SupportedResolutionsConsts.FullHD_RESOLUTION_HEIGHT)]
		public override MLImage Image
		{
			get;
			set;
		}

		public override int ImageWidth
		{
			get
			{
				return SupportedResolutionsConsts.FullHD_RESOLUTION_WIDTH;
			}
		}

		public override int ImageHeight
		{
			get
			{
				return SupportedResolutionsConsts.FullHD_RESOLUTION_HEIGHT;
			}
		}
	}
	#endregion

	#region ColorFrameFullHDInput
	public class ColorFrameUltraHDInput: BaseColorFrameInput
	{
		[ImageType(SupportedResolutionsConsts.UltraHD_RESOLUTION_WIDTH, SupportedResolutionsConsts.UltraHD_RESOLUTION_HEIGHT)]
		public override MLImage Image
		{
			get;
			set;
		}

		public override int ImageWidth
		{
			get
			{
				return SupportedResolutionsConsts.UltraHD_RESOLUTION_WIDTH;
			}
		}

		public override int ImageHeight
		{
			get
			{
				return SupportedResolutionsConsts.UltraHD_RESOLUTION_HEIGHT;
			}
		}
	}
	#endregion
}
