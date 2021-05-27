using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.All;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class GestureRecordModel : IDisposable
	{
		#region Private / protected fields
		/// <summary>
		/// Render skeleton data
		/// </summary>
		private readonly RenderBodyFrameManager renderBodyFrameManager;

		/// <summary>
		/// Render color frame
		/// </summary>
		private readonly RenderColorFrameManager renderColorFrameManager;

		/// <summary>
		/// RGB image that will be displayed
		/// </summary>
		private WriteableBitmap colorImage;

		/// <summary>
		/// Drawing group for body rendering output
		/// </summary>
		private DrawingGroup bodyImageDrawingGroup;

		/// <summary>
		/// Drawing image that will contain body data
		/// </summary>
		private DrawingImage bodyImage;

		/// <summary>
		/// Load gesture record from file and replay it
		/// </summary>
		private KinectReplay gestureReplay;

		/// <summary>
		/// Access to file containing gesture record
		/// </summary>
		private FileStream gestureRecordFile;
		#endregion

		#region Public properties
		/// <summary>
		/// RGB image that will be displayed
		/// </summary>
		public ImageSource ColorImage
		{
			get
			{
				return this.colorImage;
			}
		}

		/// <summary>
		/// Drawing image that will contain body data
		/// </summary>
		public ImageSource BodyImage
		{
			get
			{
				return this.bodyImage;
			}
		}
		#endregion

		#region Constructors
		public GestureRecordModel()
		{
			this.renderBodyFrameManager = new RenderBodyFrameManager();
			this.renderColorFrameManager = new RenderColorFrameManager();
		}
		#endregion

		#region Public methods
		public void Start(string gestureRecordFilePath)
		{
			if (string.IsNullOrEmpty(gestureRecordFilePath))
				throw new ArgumentNullException(nameof(gestureRecordFilePath));

			CleanGestureReplay();

			try
			{
				this.gestureRecordFile = File.OpenRead(gestureRecordFilePath);
				this.gestureReplay = new KinectReplay(this.gestureRecordFile);
				this.gestureReplay.AllFramesReady += GestureReplay_AllFramesReady;
				this.gestureReplay.Start();
			}
			catch (FileNotFoundException e)
			{
				// TODO: Handle exception
			}
		}

		public void Cleanup()
		{
			CleanGestureReplay();
		}
		#endregion

		#region Private methods

		#region Events handlers
		private void GestureReplay_AllFramesReady(object sender, ReplayAllFramesReadyEventArgs e)
		{
			bool colorImageSendMessage = this.colorImage == null;

			var colorFrame = e.AllFrames.ColorFrame;
			if (colorFrame != null)
				this.renderColorFrameManager.ProcessColorFrame(colorFrame, ref this.colorImage);

			//var skeletonFrame = e.AllFrames.SkeletonFrame;
			//if (skeletonFrame != null)
			//	ProcessFrame(skeletonFrame);

			if (colorImageSendMessage && colorFrame != null)
				Messenger.Default.Send(new DisplayImageChangedMessage() { Changed = true });
		}
		#endregion

		private void CleanGestureReplay()
		{
			if (this.gestureReplay != null)
			{
				this.gestureReplay.AllFramesReady -= GestureReplay_AllFramesReady;
				this.gestureReplay.Stop();
				this.gestureReplay.Dispose();
				this.gestureReplay = null;
			}
			if (this.gestureRecordFile != null)
			{
				this.gestureRecordFile.Close();
				this.gestureRecordFile.Dispose();
				this.gestureRecordFile = null;
			}
		}

		#endregion

		#region IDisposable implementation
		public void Dispose()
		{
			CleanGestureReplay();
		}
		#endregion
	}
}
