using System;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public static class ViewModelsUtils
	{
		#region Public methods
		public static string Format(float value)
		{
			if (!float.IsNaN(value))
				return string.Format("{0:0.###}", value);

			return string.Empty;
		}

		public static float Round(float value, int decimalPlaces)
		{
			if (!float.IsNaN(value))
				return Convert.ToSingle(Math.Round(value, decimalPlaces));

			return float.NaN;
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
