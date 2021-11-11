namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures
{
	public enum BodyTrackingState
	{
		Standard,
		GestureToStartGestureRecording,
		WaitingToStartGestureRecording,
		GestureRecording,
		GestureToStartGestureRecognizing,
		WaitingToStartGestureRecognizing,
		GestureToRecognizeRecording,
		WaitingForGestureRecognizingResult
	}
}
