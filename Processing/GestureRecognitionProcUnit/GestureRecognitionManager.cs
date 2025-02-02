using System;
using System.Threading.Tasks;
using Microsoft.ML;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition;

namespace GestureRecognition.Processing.GestureRecognitionProcUnit
{
  public class GestureRecognitionManager
	{
		#region Private fields
		private Random rand = new Random();
		private MLContext mlContext;
		#endregion

		#region Public properties
		public bool IsGestureRecognitionModelLoaded
		{
			get
			{
				return true;
			}
		}
		#endregion

		#region Constructors
		public GestureRecognitionManager()
		{
			this.mlContext = new MLContext(0);
		}
		#endregion

		#region Public methods
		public CreateGestureRecognitionModelResult CreateGestureRecognitionModel(CreateGestureRecognitionModelParameters parameters)
		{
			return new CreateGestureRecognitionModelResult();
		}

		public LoadGestureRecognitionModelResult LoadGestureRecognitionModel(LoadGestureRecognitionModelParameters parameters)
		{
			return new LoadGestureRecognitionModelResult();
		}

		public async Task<RecognizeGestureResult> RecognizeGesture(RecognizeGestureParameters parameters)
		{
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			bool success;
			string gestureText;

			if (rand.Next(2) > 0)
			{
				success = true;
				gestureText = "Gesture";
			}
			else
			{
				success = false;
				gestureText = "Failed";
			}

			await Task.Delay(3000);

			return new RecognizeGestureResult(success, gestureText);
		}
		#endregion

		#region Private methods
		#endregion
	}
}
