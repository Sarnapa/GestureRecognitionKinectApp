namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class HandJointsDistanceViewModel
	{
		#region Private fields
		private double? betweenHandJointsDistanceMax;
		private double? betweenHandJointsDistanceMean;
		#endregion

		#region Public properties
		public string BetweenHandJointsDistanceMax
		{
			get
			{
				return ViewModelsUtils.Format(this.betweenHandJointsDistanceMax);
			}
		}

		public string BetweenHandJointsDistanceMean
		{
			get
			{
				return ViewModelsUtils.Format(this.betweenHandJointsDistanceMean);
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
