namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class HandJointsDistanceViewModel
	{
		#region Private fields
		private double? betweenHandJointsDistanceMax;
		private double? betweenHandJointsDistanceMean;
		#endregion

		#region Public properties
		public double? BetweenHandJointsDistanceMax
		{
			get
			{
				return ViewModelsUtils.Round(this.betweenHandJointsDistanceMax, 3);
			}
		}

		public double? BetweenHandJointsDistanceMean
		{
			get
			{
				return ViewModelsUtils.Round(this.betweenHandJointsDistanceMean, 3);
			}
		}
		#endregion

		#region Constructors
		public HandJointsDistanceViewModel(double? betweenHandJointsDistanceMax, double? betweenHandJointsDistanceMean)
		{
			this.betweenHandJointsDistanceMax = betweenHandJointsDistanceMax;
			this.betweenHandJointsDistanceMean = betweenHandJointsDistanceMean;
		}
		#endregion
	}
}
