using System;
using System.Threading;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureDetection
{
	public class GestureRecognitionParameters
	{
		#region Constructors
		public GestureRecognitionParameters(GestureFeatures features, CancellationToken token)
		{
			if (features == null)
				throw new ArgumentNullException(nameof(features));

			this.Features = features;
			this.Token = token;
		}
		#endregion

		#region Public properties
		public GestureFeatures Features
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
