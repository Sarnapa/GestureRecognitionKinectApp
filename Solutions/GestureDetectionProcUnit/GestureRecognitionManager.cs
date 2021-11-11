using System;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureDetection;

namespace GestureRecognition.Processing.GestureRecognitionProcUnit
{
  public class GestureRecognitionManager
	{
		#region Private fields
		private Random rand = new Random();
		#endregion

		#region Constructors
		public GestureRecognitionManager()
		{}
		#endregion

		#region Public methods
		public async Task<GestureRecognitionResult> RecognizeGesture(GestureRecognitionParameters parameters)
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

			return new GestureRecognitionResult(success, gestureText);
		}
		#endregion
	}
}
