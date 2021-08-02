using System;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public static class ViewModelsUtils
	{
		#region Public methods
		public static double? Round(double? value, int decimalPlaces)
		{
			if (value.HasValue)
				return Math.Round(value.Value, decimalPlaces);

			return null;
		}
		#endregion
	}
}
