using System.Windows;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Utilities
{
	public static class MessageBoxUtils
	{
		public static MessageBoxResult ShowMessage(string message, string caption, MessageBoxButton button,
			MessageBoxImage image)
		{
			return MessageBox.Show(message, caption, button, image);
		}
	}
}
