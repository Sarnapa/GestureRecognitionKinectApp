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
		#endregion

		#region Public properties
		public bool IsStopped
		{
			get;
			private set;
		}
		#endregion

		#region Public events
		public event FrameArrivedEventHandler OnFrameArrived;
		public event KinectIsAvailableChangedEventHandler OnKinectIsAvailableChanged;
		#endregion

		#region Public methods
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

			// Get the coordinate mapper
			this.coordinateMapper = this.kinectSensor.CoordinateMapper;

			var colorFrameDescription = this.kinectSensor.ColorFrameSource.CreateFrameDescription(this.colorImageFormat);

			bool isSuccess = colorFrameDescription != null && colorFrameDescription.Width > 0 && colorFrameDescription.Height > 0;

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

			this.IsStopped = false;
		}

		public StopResponseResult Stop(StopRequestParams parameters)
		{
			this.IsStopped = true;

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
				var relativeTime = DateTime.Now.TimeOfDay;

				var kinectBodies = GetBodies(kinectBodyFrame, true);
				int kinectBodiesCount = kinectBodies.Length;

				if (!this.IsStopped && kinectColorFrame != null)
				{
					var colorFrame = GetColorFrame(kinectColorFrame, relativeTime, ColorImageFormat.Bgra);
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
									var trackedBody = kinectBodies.FirstOrDefault();
									bodyFrame = kinectBodyFrame.Map(relativeTime, new[] { trackedBody });
									var trackedBodyJointsColorSpacePointsDict = ConvertToColorSpace(trackedBody, bodyFrame.Bodies);
									bodiesJointsColorSpacePointsDict.Add(trackedBody.TrackingId, trackedBodyJointsColorSpacePointsDict);
								}
								else
								{
									bodyFrame = kinectBodyFrame.Map(relativeTime, kinectBodiesCount, true);
								}
							}
							else
							{
								bodyFrame = kinectBodyFrame.Map(relativeTime, kinectBodies);
								bodiesJointsColorSpacePointsDict = ConvertToColorSpace(kinectBodies, bodyFrame.Bodies);
							}
						}
						else 
						{
							bodyFrame = kinectBodyFrame.Map(relativeTime, 0, false);
						}
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
			if (!this.IsStopped)
			{
				OnKinectIsAvailableChanged?.Invoke(this, new KinectIsAvailableChangedEventArgs(
					new KinectIsAvailableChangedData() { IsAvailable = e.IsAvailable }));
			}
		}
		#endregion

		#region ColorFrame methods
		private ColorFrame GetColorFrame(MSKinect.ColorFrame kinectColorFrame, TimeSpan relativeTime, ColorImageFormat destinationFormat)
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

			return kinectColorFrame.Map(destinationFormat, bytesPerPixel, relativeTime, colorData);
		}
		#endregion

		#region BodyFrame methods
		private MSKinect.Body[] GetBodies(MSKinect.BodyFrame kinectBodyFrame, bool onlyTracked)
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

			return onlyTracked ? bodies.Where(b => b.IsTracked).ToArray() : bodies;
		}
		#endregion

		#region Convert body joints coordinations to color coordinations methods
		private BodyJointsColorSpacePointsDict ConvertToColorSpace(MSKinect.Body body, BodyData[] bodiesData)
		{
			return ConvertToColorSpace(new[] { body }, bodiesData).FirstOrDefault().Value;
		}

		private Dictionary<ulong, BodyJointsColorSpacePointsDict> ConvertToColorSpace(IEnumerable<MSKinect.Body> bodies, BodyData[] bodiesData)
		{
			var result = new Dictionary<ulong, BodyJointsColorSpacePointsDict>();

			if (bodies == null || !bodies.Any() || bodiesData == null || !bodiesData.Any())
				return result;

			var bodiesDataDict = bodiesData.ToDictionary(b => b.TrackingId);

			foreach (var body in bodies.Distinct(KinectBodyEqualityComparer.Instance))
			{
				if (bodiesDataDict.TryGetValue(body.TrackingId, out BodyData bodyData))
				{
					result.Add(body.TrackingId, ConvertToColorSpace(body.Joints, bodyData));
				}
			}

			return result;
		}

		private BodyJointsColorSpacePointsDict ConvertToColorSpace(IReadOnlyDictionary<MSKinect.JointType, MSKinect.Joint> joints, BodyData bodyData)
		{
			var jointsPoints = new BodyJointsColorSpacePointsDict();

			if (joints != null)
			{
				foreach (var jointType in joints.Keys)
				{
					// This comes from this more rigorous approach, we leave it just in case, because it does not reduce performance.
					if (bodyData.Joints.ContainsKey(jointType.Map()))
					{
						var position = joints[jointType].Position;
						var kinectColorSpacePosition = this.coordinateMapper.MapCameraPointToColorSpace(position);
						jointsPoints[jointType.Map()] = kinectColorSpacePosition.Map();
					}
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
