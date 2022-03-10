using System;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public static class ViewModelsUtils
	{
		#region Public methods
		public static string Format(double? value)
		{
			if (value.HasValue)
				return string.Format("{0:0.###}", value.Value);

			return string.Empty;
		}

		public static double? Round(double? value, int decimalPlaces)
		{
			if (value.HasValue)
				return Math.Round(value.Value, decimalPlaces);

			return null;
		}

		public static string GetImageUri(string imageName)
		{
			if (string.IsNullOrEmpty(imageName))
				throw new ArgumentNullException(nameof(imageName));

			return $"pack://application:,,,/Resources/{imageName}";
		}
		#endregion
	}
}
