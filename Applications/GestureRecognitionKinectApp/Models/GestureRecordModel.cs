using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay;
using GestureRecognition.Processing.KinectStreamRecordReplayProcUnit.Replay.All;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models
{
	public class GestureRecordModel
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

			CleanGestureReplay(false);

			// Create the drawing group we'll use for drawing body data
			this.bodyImageDrawingGroup = new DrawingGroup();
			// Create the image with body data
			this.bodyImage = new DrawingImage(this.bodyImageDrawingGroup);

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

		public bool ExportGestureRecord(string filePath)
		{
			if (!string.IsNullOrEmpty(filePath) && this.gestureRecordFile != null)
			{
				try
				{
					string temporaryGestureRecordFileName = this.gestureRecordFile.Name;
					CleanGestureRecordFileAccess(false);
					File.Move(temporaryGestureRecordFileName, filePath);
					File.SetAttributes(filePath, File.GetAttributes(filePath) ^ FileAttributes.Hidden);
					this.gestureRecordFile = File.OpenRead(filePath);
					return true;
				}
				catch (Exception e)
				{
					// TODO: Handle exception in better way.
					return false;
				}
			}

			return false;
		}

		public void Cleanup(bool deleteGestureRecordFile = true)
		{
			CleanGestureReplay(deleteGestureRecordFile);
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

			var bodyFrame = e.AllFrames.BodyFrame;
			using (var dc = this.bodyImageDrawingGroup.Open())
			{
				if (colorFrame != null && this.colorImage != null && bodyFrame != null)
				{
					dc.DrawRectangle(Brushes.Transparent, null, new Rect(0.0, 0.0, colorFrame.Width, colorFrame.Height));
					this.renderBodyFrameManager.ProcessBodyFrame(bodyFrame, dc);
					// prevent drawing outside of our render area
					this.bodyImageDrawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0,
						colorFrame.Width, colorFrame.Height));
				}
			}

			if (colorImageSendMessage && colorFrame != null)
				Messenger.Default.Send(new DisplayImageChangedMessage() { Changed = true });
		}
		#endregion

		private void CleanGestureReplay(bool deleteGestureRecordFile = true)
		{
			if (this.gestureReplay != null)
			{
				this.gestureReplay.AllFramesReady -= GestureReplay_AllFramesReady;
				this.gestureReplay.Stop();
				this.gestureReplay.Dispose();
				this.gestureReplay = null;
			}

			CleanGestureRecordFileAccess(deleteGestureRecordFile);

			this.colorImage = null;
			this.bodyImage = null;
			this.bodyImageDrawingGroup = null;
		}

		private void CleanGestureRecordFileAccess(bool deleteGestureRecordFile = true)
		{
			if (this.gestureRecordFile != null)
			{
				this.gestureRecordFile.Close();
				if (deleteGestureRecordFile)
					File.Delete(this.gestureRecordFile.Name);
				this.gestureRecordFile.Dispose();
				this.gestureRecordFile = null;
			}
		}
		#endregion
	}
}
