using System;
using System.Windows;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Views.Dialogs
{
	/// <summary>
	/// Interaction logic for GestureLabelInputDialog.xaml
	/// </summary>
	public partial class GestureLabelInputDialog: Window
	{
		public GestureLabelInputDialog()
		{
			InitializeComponent();
		}

		private void GestureLabelInputDialog_ContentRendered(object sender, EventArgs e)
		{
			this.GestureLabelTextBox.SelectAll();
			this.GestureLabelTextBox.Focus();
		}

		private void DialogButtonOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		public string GestureLabel
		{
			get
			{
				return this.GestureLabelTextBox.Text;
			}
		}
	}
}
