using System;
using System.Threading;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition
{
	public class RecognizeGestureParameters
	{
		#region Constructors
		public RecognizeGestureParameters(GestureFeatures features, float scoreThreshold, BodyTrackingMode trackingMode, CancellationToken token)
		{
			if (features == null)
				throw new ArgumentNullException(nameof(features));

			this.Features = features;
			this.ScoreThreshold = scoreThreshold;
			this.TrackingMode = trackingMode;
			this.Token = token;
		}
		#endregion

		#region Public properties
		public GestureFeatures Features
		{
			get;
			private set;
		}

		public float ScoreThreshold
		{
			get;
			private set;
		} = 0.5f;

		public BodyTrackingMode TrackingMode
		{
			get;
			private set;
		}

		public CancellationToken Token
		{
			get;
			private set;
		}
		#endregion
	}
}
