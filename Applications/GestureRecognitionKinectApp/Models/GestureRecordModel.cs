using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Managers;
using GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing.Structures;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Processing.BaseClassLib.Mappers;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Utils;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;
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
		/// Calculates features for gesture recognition process
		/// </summary>
		private GestureRecognitionFeaturesManager gestureRecognitionFeaturesManager;

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
		private Replay gestureReplay;

		/// <summary>
		/// Determines time when gesture record is repeated
		/// </summary>
		private DateTime? gestureReplayStartTime;

		/// <summary>
		/// Access to file containing gesture record
		/// </summary>
		private FileStream gestureRecordFile;

		/// <summary>
		/// Loaded gesture frames
		/// </summary>
		private List<BodyData> gestureBodyFrames;

		/// <summary>
		/// Calculated gesture features
		/// </summary>
		private GestureFeatures gestureFeatures;
		#endregion

		#region Private properties
		private bool AreGestureFeaturesCalculated
		{
			get
			{
				return this.gestureFeatures != null;
			}
		}

		private bool IsGestureLabel
		{
			get
			{
				return !string.IsNullOrEmpty(this.GestureLabel);
			}
		}
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

		/// <summary>
		/// Calculated gesture features
		/// </summary>
		public GestureFeatures GestureFeatures
		{
			get
			{
				return this.gestureFeatures;
			}
		}

		/// <summary>
		/// Assigned gesture label
		/// </summary>
		public string GestureLabel
		{
			get;
			private set;
		}

		/// <summary>
		/// Determines time when gesture record is repeated
		/// </summary>
		public DateTime? GestureReplayStartTime
		{
			get
			{
				return this.gestureReplayStartTime;
			}
		}
		#endregion

		#region Constructors
		public GestureRecordModel()
		{
			this.renderColorFrameManager = new RenderColorFrameManager();
			this.renderBodyFrameManager = new RenderBodyFrameManager(Consts.GestureRecordResizingCoef);
			this.gestureRecognitionFeaturesManager = SimpleIoc.Default.GetInstance<GestureRecognitionFeaturesManager>();

			this.gestureBodyFrames = new List<BodyData>();
		}
		#endregion

		#region Public methods
		public void Start(string gestureRecordFilePath, bool tryLoadGestureData)
		{
			if (string.IsNullOrEmpty(gestureRecordFilePath))
				throw new ArgumentNullException(nameof(gestureRecordFilePath));

			CleanGestureReplay(false);
			CleanGestureBodyFrames();

			// Create the drawing group we'll use for drawing body data
			this.bodyImageDrawingGroup = new DrawingGroup();
			// Create the image with body data
			this.bodyImage = new DrawingImage(this.bodyImageDrawingGroup);

			Messenger.Default.Send(new DisplayImageChangedMessage() { ChangedDisplayImage = ImageKind.Body });

			try
			{
				this.gestureRecordFile = File.OpenRead(gestureRecordFilePath);
				if (tryLoadGestureData)
					LoadGestureData();

				this.gestureReplay = new Replay(this.gestureRecordFile);
				this.gestureReplay.AllFramesReady += GestureReplay_AllFramesReady;
				this.gestureReplay.Finished += GestureReplay_Finished;
				this.gestureReplay.Start();
			}
			catch (FileNotFoundException e)
			{
				// TODO: Handle exception
			}
		}

		public void SetGestureLabel(string label)
		{
			this.GestureLabel = label.ToLower();
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

		public bool ExportGestureData()
		{
			string gestureDataFilePath = GetGestureDataFilePath();
			if (!string.IsNullOrEmpty(gestureDataFilePath) && this.AreGestureFeaturesCalculated && this.IsGestureLabel)
			{
				try
				{
					var gestureDataView = this.gestureFeatures.Map(this.GestureLabel);
					CsvHelperUtils.WriteGesturesToFile(new List<GestureDataView>() { gestureDataView }, gestureDataFilePath);
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
			CleanGestureBodyFrames();
			CleanGestureFeatures();
			CleanGestureLabel();
		}
		#endregion

		#region Private methods

		#region Events handlers
		private void GestureReplay_AllFramesReady(object sender, ReplayAllFramesReadyEventArgs e)
		{
			bool shouldBeFirstColorFrame = this.colorImage == null;

			var colorFrame = e.AllFrames.ColorFrame;
			if (colorFrame != null)
				this.renderColorFrameManager.ProcessColorFrame(colorFrame, ref this.colorImage);

			var bodyFrame = e.AllFrames.BodyFrame;
			using (var dc = this.bodyImageDrawingGroup.Open())
			{
				if (colorFrame != null && this.colorImage != null && bodyFrame != null)
				{
					// Temporary assumption that we obtained gesture record with one user
					var userBodyFrame = bodyFrame.Bodies.FirstOrDefault();
					if (userBodyFrame != null && userBodyFrame.IsTracked && !this.AreGestureFeaturesCalculated)
						this.gestureBodyFrames.Add(userBodyFrame);

					dc.DrawRectangle(Brushes.Transparent, null, new Rect(0.0, 0.0, colorFrame.Width, colorFrame.Height));
					this.renderBodyFrameManager.ProcessBodyFrame(bodyFrame, dc);
					// Prevent drawing outside of our render area
					this.bodyImageDrawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0,
						colorFrame.Width, colorFrame.Height));
				}
			}

			if (shouldBeFirstColorFrame && colorFrame != null)
			{
				this.gestureReplayStartTime = DateTime.Now;
				Messenger.Default.Send(new DisplayImageChangedMessage() { ChangedDisplayImage = ImageKind.Color });
			}

			Messenger.Default.Send(new GestureRecordFrameProcessedMessage());
		}

		private void GestureReplay_Finished()
		{
			this.gestureReplayStartTime = null;
			if (!this.AreGestureFeaturesCalculated && this.gestureBodyFrames.Any())
			{
				Task.Factory.StartNew(async () =>
				{
					try
					{
						this.gestureFeatures = await this.gestureRecognitionFeaturesManager.CalculateFeatures(this.gestureBodyFrames.ToArray());
					}
					finally
					{
						CleanGestureBodyFrames();
						Messenger.Default.Send(new GestureRecordFinishedMessage());
					}
				});
			}
			else
				Messenger.Default.Send(new GestureRecordFinishedMessage());
		}
		#endregion

		#region Loading gestures data methods
		private bool LoadGestureData()
		{
			string gestureDataFilePath = GetGestureDataFilePath();
			if (!string.IsNullOrEmpty(gestureDataFilePath) && File.Exists(gestureDataFilePath)
				&& (!this.AreGestureFeaturesCalculated || !this.IsGestureLabel))
			{
				try
				{
					var gestureDataView = CsvHelperUtils.GetGesturesFromFile(gestureDataFilePath)?.FirstOrDefault();
					if (gestureDataView != null)
					{
						var gesturePair = gestureDataView.Map();
						var gestureFeatures = gesturePair.features;
						string gestureLabel = gesturePair.label;
						if (gestureFeatures.IsValid)
						{
							this.gestureFeatures = gestureFeatures;
							this.GestureLabel = gestureLabel;
							return true;
						}
					}
				}
				catch (Exception e)
				{
					// TODO: Handle exception in better way.
					return false;
				}
			}

			return false;
		}

		private string GetGestureDataFilePath()
		{
			return this.gestureRecordFile?.Name?.Replace(Consts.GestureRecordFileExtension,
				CsvHelperUtils.CsvFileExtension) ?? string.Empty;
		}
		#endregion

		#region Cleaning up methods
		private void CleanGestureReplay(bool deleteGestureRecordFile = true)
		{
			if (this.gestureReplay != null)
			{
				this.gestureReplay.AllFramesReady -= GestureReplay_AllFramesReady;
				this.gestureReplay.Finished -= GestureReplay_Finished;
				this.gestureReplay.Stop();
				this.gestureReplay.Dispose();
				this.gestureReplay = null;
			}

			CleanGestureRecordFileAccess(deleteGestureRecordFile);

			this.colorImage = null;
			this.bodyImage = null;
			this.bodyImageDrawingGroup = null;
			this.gestureReplayStartTime = null;
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

		private void CleanGestureBodyFrames()
		{
			if (this.gestureBodyFrames.Any())
				this.gestureBodyFrames.Clear();
		}

		private void CleanGestureFeatures()
		{
			this.gestureFeatures = null;
		}

		private void CleanGestureLabel()
		{
			this.GestureLabel = null;
		}
		#endregion

		#endregion
	}
}
