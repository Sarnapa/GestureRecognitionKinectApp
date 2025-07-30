using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Utilities
{
	public static class MessengerUtils
	{
		public static void SendMessageInUIThread<T>(T message)
			where T : class
		{
			Application.Current?.Dispatcher.Invoke(() => SendMessage(message));
		}

		public static void SendMessageInUIThread<T, U>(T message)
			where T : class
			where U : class
		{
			Application.Current?.Dispatcher.Invoke(() => SendMessage<T, U>(message));
		}

		public static void SendMessage<T>(T message)
			where T : class
		{
			Messenger.Default.Send(message);
		}

		public static void SendMessage<T, U>(T message)
			where T : class
			where U : class
		{
			Messenger.Default.Send<T, U>(message);
		}
	}
}
