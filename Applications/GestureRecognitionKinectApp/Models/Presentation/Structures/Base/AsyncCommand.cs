﻿using System;
using System.Threading.Tasks;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Structures.Base
{
	public class AsyncCommand : AsyncCommandBase
	{
		private readonly Func<Task> command;
		public AsyncCommand(Func<Task> command)
		{
			this.command = command;
		}
		public override bool CanExecute(object parameter)
		{
			return true;
		}
		public override Task ExecuteAsync(object parameter)
		{
			return this.command();
		}
	}
}
