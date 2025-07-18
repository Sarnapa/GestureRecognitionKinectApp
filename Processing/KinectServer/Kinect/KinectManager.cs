using System;
using System.Collections.Generic;
using System.Linq;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Data;
using GestureRecognition.Processing.BaseClassLib.Structures.KinectServer.Events;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using GestureRecognition.Processing.BaseClassLib.Utils;
using MSKinect = Microsoft.Kinect;

namespace GestureRecognition.Processing.KinectServer.Kinect
{
	public class KinectManager
	{
		#region Private fields
		/// <summary>
		/// Active Kinect sensor
		/// </summary>
		private MSKinect.KinectSensor kinectSensor;

		/// <summary>
		/// Reader for frames from multiple sources
		/// </summary>
		private MSKinect.MultiSourceFrameReader multiSourceReader;

		/// <summary>
		/// Coordinate mapper to map one type of point to another
		/// </summary>
		private MSKinect.CoordinateMapper coordinateMapper;

		/// <summary>
		/// Frame source types that are used to read the frames
		/// </summary>
		private MSKinect.FrameSourceTypes frameSourceTypes;

		/// <summary>
		///	Color image format that is used to read the color frames
		/// </summary>
		private MSKinect.ColorImageFormat colorImageFormat; 

		/// <summary>
		/// Flag that indicates whether single-user tracking mode is enabled
		/// </summary>
		private bool isOneBodyTrackingEnabled;

		private bool isStopped;
		#endregion

		#region Public events
		public event FrameArrivedEventHandler OnFrameArrived;
		public event KinectIsAvailableChangedEventHandler OnKinectIsAvailableChanged;
		#endregion

		#region Public methods
		public void Initialize()
		{
			//string methodName = $"{nameof(KinectManager)}.{nameof(Initialize)}";
			//Console.WriteLine($"[{methodName}] STA Thread: {Thread.CurrentThread.GetApartmentState()}");

			//this.kinectSensor = MSKinect.KinectSensor.GetDefault();
			//Console.WriteLine($"[{methodName}] Kinect sensor is null: {kinectSensor == null}");
			//this.kinectSensor.Open();
			//this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;

			//this.coordinateMapper = this.kinectSensor.CoordinateMapper;

			//this.multiSourceReader = this.kinectSensor.OpenMultiSourceFrameReader(MSKinect.FrameSourceTypes.Color | MSKinect.FrameSourceTypes.Body);
			//if (this.multiSourceReader != null)
			//	this.multiSourceReader.MultiSourceFrameArrived += this.Reader_FrameArrived;

			//this.colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(MSKinect.ColorImageFormat.Bgra);
		}

		public StartResponseResult GetKinectSensorInfoToStart(StartRequestParams parameters)
		{
			string methodName = $"{nameof(KinectManager)}.{nameof(GetKinectSensorInfoToStart)}";
			
			// TODO: Better validation and error handling
			if (parameters == null)
				throw new ArgumentNullException(nameof(parameters));

			this.frameSourceTypes = parameters.FrameSourceTypes.Map();
			this.colorImageFormat = parameters.ColorImageFormat.Map();
			this.isOneBodyTrackingEnabled = parameters.IsOneBodyTrackingEnabled;

			// One sensor is currently supported
			this.kinectSensor = MSKinect.KinectSensor.GetDefault();
			//this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;
			//if (!this.kinectSensor.IsOpen)
			//	this.kinectSensor.Open();

			//this.frameSourceTypes = frameSourceTypes;
			// Open the reader for the body frames
			//this.multiSourceReader = this.kinectSensor.OpenMultiSourceFrameReader(frameSourceTypes);

			// Get the coordinate mapper
			this.coordinateMapper = this.kinectSensor.CoordinateMapper;

			var colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(this.colorImageFormat);

			//if (this.multiSourceReader != null)
			//	this.multiSourceReader.MultiSourceFrameArrived += this.Reader_FrameArrived;

			bool isSuccess = /*this.multiSourceReader != null && */ colorFrameDescription != null 
				&& colorFrameDescription.Width > 0 && colorFrameDescription.Height > 0;

			if (!isSuccess)
				this.isOneBodyTrackingEnabled = false;

			return new StartResponseResult()
			{
				IsSuccess = isSuccess,
				ColorFrameWidth = colorFrameDescription?.Width ?? 0,
				ColorFrameHeight = colorFrameDescription?.Height ?? 0,
				KinectSensorIsAvailable = this.kinectSensor.IsAvailable,
			};
		}

		public void StartKinectSensor()
		{
			string methodName = $"{nameof(KinectManager)}.{nameof(StartKinectSensor)}";
			if (this.kinectSensor != null)
			{
				if (!this.kinectSensor.IsOpen)
					this.kinectSensor.Open();

				this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;
			}

			this.multiSourceReader = this.kinectSensor.OpenMultiSourceFrameReader(this.frameSourceTypes);
			if (this.multiSourceReader != null)
				this.multiSourceReader.MultiSourceFrameArrived += this.Reader_FrameArrived;
		}

		public StopResponseResult Stop(StopRequestParams parameters)
		{
			this.isStopped = true;

			if (this.multiSourceReader != null)
			{
				this.multiSourceReader.MultiSourceFrameArrived -= this.Reader_FrameArrived;
				this.multiSourceReader.Dispose();
				this.multiSourceReader = null;
			}

			if (this.kinectSensor != null)
			{
				this.kinectSensor.IsAvailableChanged -= this.Sensor_IsAvailableChanged;
				this.kinectSensor.Close();
				this.kinectSensor = null;
			}

			return new StopResponseResult()
			{
				IsSuccess = true
			};
		}
		#endregion

		#region Private methods

		#region Event handlers
		/// <summary>
		/// Handles the data arriving from the sensor
		/// </summary>
		/// <param name="sender">Object sending the event</param>
		/// <param name="e">Event arguments</param>
		private void Reader_FrameArrived(object sender, MSKinect.MultiSourceFrameArrivedEventArgs e)
		{
			var multiSourceFrame = e.FrameReference.AcquireFrame();

			// If the Frame has expired by the time we process this event, return.
			if (multiSourceFrame == null)
				return;

			MSKinect.ColorFrame kinectColorFrame = null;
			MSKinect.BodyFrame kinectBodyFrame = null;

			try
			{
				kinectColorFrame = multiSourceFrame.ColorFrameReference.AcquireFrame();
				kinectBodyFrame = multiSourceFrame.BodyFrameReference.AcquireFrame();
				var kinectBodies = GetBodies(kinectBodyFrame);
				int kinectBodiesCount = kinectBodies.Length;

				if (!this.isStopped && kinectColorFrame != null)
				{
					var colorFrame = GetColorFrame(kinectColorFrame, ColorImageFormat.Bgra);
					BodyFrame bodyFrame = null;
					var bodiesJointsColorSpacePointsDict = new Dictionary<ulong, BodyJointsColorSpacePointsDict>();
					if (kinectBodyFrame != null)
					{
						if (kinectBodiesCount > 0)
						{
							// Assumption: if there is a single user tracking mode enabled,
							// and we have more than one user detected,
							// we do not determine the coordinates of the joints on the RGB map.
							if (this.isOneBodyTrackingEnabled)
							{
								if (kinectBodiesCount == 1)
								{
									var trackedBody = kinectBodies.FirstOrDefault(b => b != null && b.IsTracked);
									var trackedBodyJointsColorSpacePointsDict = ConvertToColorSpace(trackedBody);
									bodiesJointsColorSpacePointsDict.Add(trackedBody.TrackingId, trackedBodyJointsColorSpacePointsDict);
									bodyFrame = kinectBodyFrame.Map(new[] { trackedBody });
								}
								else
								{
									bodyFrame = kinectBodyFrame.Map(kinectBodiesCount, true);
								}
							}
							else
							{
								bodiesJointsColorSpacePointsDict = ConvertToColorSpace(kinectBodies);
								bodyFrame = kinectBodyFrame.Map(kinectBodies);
							}
						}
						else 
						{
							bodyFrame = kinectBodyFrame.Map(0, false);
						}

						OnFrameArrived?.Invoke(this, new FrameArrivedEventArgs(
							new FrameData()
							{
								ColorFrame = colorFrame,
								BodyFrame = bodyFrame,
								BodiesJointsColorSpacePointsDict = bodiesJointsColorSpacePointsDict,
							}
						));
					}
				}
			}
			finally
			{
				kinectColorFrame?.Dispose();
				kinectBodyFrame?.Dispose();
			}
		}

		/// <summary>
		/// Handles the event which the sensor becomes unavailable (E.g. paused, closed, unplugged)
		/// </summary>
		/// <param name="sender">Object sending the event</param>
		/// <param name="e">Event arguments</param>
		private void Sensor_IsAvailableChanged(object sender, MSKinect.IsAvailableChangedEventArgs e)
		{
			OnKinectIsAvailableChanged?.Invoke(this, new KinectIsAvailableChangedEventArgs(
				new KinectIsAvailableChangedData() { IsAvailable = e.IsAvailable }));
		}
		#endregion

		#region ColorFrame methods
		private ColorFrame GetColorFrame(MSKinect.ColorFrame kinectColorFrame, ColorImageFormat destinationFormat)
		{
			if (kinectColorFrame == null)
				return null;

			var kinectDestinationFormat = destinationFormat.Map();
			bool isNecessaryToConvert = kinectColorFrame.RawColorImageFormat != kinectDestinationFormat;
			uint bytesPerPixel = isNecessaryToConvert ? ColorImageUtils.GetBytesPerPixel(destinationFormat) : kinectColorFrame.FrameDescription.BytesPerPixel;

			byte[] colorData = new byte[kinectColorFrame.FrameDescription.LengthInPixels * bytesPerPixel];
			if (isNecessaryToConvert)
				kinectColorFrame.CopyConvertedFrameDataToArray(colorData, kinectDestinationFormat);
			else
				kinectColorFrame.CopyRawFrameDataToArray(colorData);

			return kinectColorFrame.Map(destinationFormat, bytesPerPixel, colorData);
		}
		#endregion

		#region BodyFrame methods
		private MSKinect.Body[] GetBodies(MSKinect.BodyFrame kinectBodyFrame)
		{
			if (kinectBodyFrame == null)
				return new MSKinect.Body[0];

			MSKinect.Body[] bodies;
			if (kinectBodyFrame.BodyCount > 0)
			{
				bodies = new MSKinect.Body[kinectBodyFrame.BodyCount];
				kinectBodyFrame.GetAndRefreshBodyData(bodies);
			}
			else
				bodies = new MSKinect.Body[0];

			return bodies;
		}
		#endregion

		#region Convert body joints coordinations to color coordinations methods
		private BodyJointsColorSpacePointsDict ConvertToColorSpace(MSKinect.Body body)
		{
			return ConvertToColorSpace(new[] { body }).FirstOrDefault().Value;
		}

		private Dictionary<ulong, BodyJointsColorSpacePointsDict> ConvertToColorSpace(IEnumerable<MSKinect.Body> bodies)
		{
			if (bodies == null || !bodies.Any())
				return new Dictionary<ulong, BodyJointsColorSpacePointsDict>();

			return bodies.Distinct(KinectBodyEqualityComparer.Instance).ToDictionary(b => b.TrackingId, b => ConvertToColorSpace(b?.Joints));
		}

		private BodyJointsColorSpacePointsDict ConvertToColorSpace(IReadOnlyDictionary<MSKinect.JointType, MSKinect.Joint> joints)
		{
			var jointsPoints = new BodyJointsColorSpacePointsDict();

			if (joints != null)
			{
				foreach (var jointType in joints.Keys)
				{
					var position = joints[jointType].Position;
					var kinectColorSpacePosition = this.coordinateMapper.MapCameraPointToColorSpace(position);
					jointsPoints[jointType.Map()] = kinectColorSpacePosition.Map();
				}
			}

			return jointsPoints;
		}
		#endregion

		#endregion
	}

	#region KinectBodyEqualityComparer class
	public class KinectBodyEqualityComparer: IEqualityComparer<MSKinect.Body>
	{
		public static readonly KinectBodyEqualityComparer Instance = new KinectBodyEqualityComparer();

		#region Overrides
		public bool Equals(MSKinect.Body x, MSKinect.Body y)
		{
			if (x == null && y == null)
				return true;
			if (x == null || y == null)
				return false;
			return x.TrackingId == y.TrackingId;
		}
		public int GetHashCode(MSKinect.Body obj)
		{
			return obj?.TrackingId.GetHashCode() ?? 0;
		}
		#endregion
	}
	#endregion
}
