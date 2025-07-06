using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using GestureRecognition.Processing.BaseClassLib.Structures.Streaming;
using Kinect = Microsoft.Kinect;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Processing
{
	internal static class Mappers
	{
		#region Kinect.ColorFrame -> ColorFrame
		public static ColorFrame Map(this Kinect.ColorFrame kinectColorFrame, ColorImageFormat destinationFormat)
		{
			if (kinectColorFrame == null)
				return null;

			var kinectDestinationFormat = destinationFormat.Map();
			bool isNecessaryToConvert = kinectColorFrame.RawColorImageFormat != kinectDestinationFormat;
			uint bytesPerPixel = isNecessaryToConvert ? GetBytesPerPixel(destinationFormat) : kinectColorFrame.FrameDescription.BytesPerPixel;

			byte[] colorData = new byte[kinectColorFrame.FrameDescription.LengthInPixels * bytesPerPixel];
			if (isNecessaryToConvert)
				kinectColorFrame.CopyConvertedFrameDataToArray(colorData, kinectDestinationFormat);
			else
				kinectColorFrame.CopyRawFrameDataToArray(colorData);

			return new ColorFrame(
				kinectColorFrame.FrameDescription.Width,
				kinectColorFrame.FrameDescription.Height,
				destinationFormat,
				bytesPerPixel,
				kinectColorFrame.FrameDescription.LengthInPixels,
				kinectColorFrame.RelativeTime,
				colorData
				);
		}

		private static uint GetBytesPerPixel(ColorImageFormat format)
		{
			switch (format)
			{
				case ColorImageFormat.Rgba:
					return 4;
				case ColorImageFormat.Yuv:
					return 2;
				case ColorImageFormat.Bgra:
					return 4;
				case ColorImageFormat.Bayer:
					return 1;
				case ColorImageFormat.Yuy2:
					return 2;
			}

			return 0;
		}
		#endregion


		#region Kinect.ColorImageFormat -> ColorImageFormat
		public static ColorImageFormat Map(this Kinect.ColorImageFormat kinectColorImageFormat)
		{
			switch (kinectColorImageFormat)
			{
				case Kinect.ColorImageFormat.Rgba:
					return ColorImageFormat.Rgba;
				case Kinect.ColorImageFormat.Yuv:
					return ColorImageFormat.Yuv;
				case Kinect.ColorImageFormat.Bgra:
					return ColorImageFormat.Bgra;
				case Kinect.ColorImageFormat.Bayer:
					return ColorImageFormat.Bayer;
				case Kinect.ColorImageFormat.Yuy2:
					return ColorImageFormat.Yuy2;
			}

			return ColorImageFormat.None;
		}
		#endregion

		#region ColorImageFormat -> Kinect.ColorImageFormat
		public static Kinect.ColorImageFormat Map(this ColorImageFormat colorImageFormat)
		{
			switch (colorImageFormat)
			{
				case ColorImageFormat.Rgba:
					return Kinect.ColorImageFormat.Rgba;
				case ColorImageFormat.Yuv:
					return Kinect.ColorImageFormat.Yuv;
				case ColorImageFormat.Bgra:
					return Kinect.ColorImageFormat.Bgra;
				case ColorImageFormat.Bayer:
					return Kinect.ColorImageFormat.Bayer;
				case ColorImageFormat.Yuy2:
					return Kinect.ColorImageFormat.Yuy2;
			}

			return Kinect.ColorImageFormat.None;
		}
		#endregion

		#region Kinect.BodyFrame -> BodyFrame
		public static BodyFrame Map(this Kinect.BodyFrame kinectBodyFrame)
		{
			if (kinectBodyFrame == null)
				return null;

			var bodies = new Kinect.Body[kinectBodyFrame.BodyCount];
			// The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
			// As long as those body objects are not disposed and not set to null in the array,
			// those body objects will be re-used.
			kinectBodyFrame.GetAndRefreshBodyData(bodies);

			return new BodyFrame(
				kinectBodyFrame.RelativeTime,
				bodies.Map() ?? new BodyData[] { }
				);
		}
		#endregion

		#region Kinect.Body -> BodyData
		public static BodyData Map(this Kinect.Body body)
		{
			if (body == null)
				return null;

			return new BodyData(
				body.IsTracked,
				body.Joints?.ToDictionary(kv => kv.Key.Map(), kv => kv.Value.Map()) ?? new Dictionary<JointType, Joint>(),
				body.HandLeftState.Map(),
				body.HandLeftConfidence.Map(),
				body.HandRightState.Map(),
				body.HandRightConfidence.Map());
		}

		public static BodyData[] Map(this IEnumerable<Kinect.Body> bodies)
		{
			return bodies?.Select(b => b.Map()).ToArray() ?? new BodyData[] { };
		}
		#endregion

		#region Kinect.Body -> BodyDataWithColorSpacePoints
		public static BodyDataWithColorSpacePoints Map(this Kinect.Body body, BodyJointsColorSpacePointsDict jointsColorSpacePoints)
		{
			if (body == null)
				return null;

			return new BodyDataWithColorSpacePoints(
				body.IsTracked,
				body.Joints?.ToDictionary(kv => kv.Key.Map(), kv => kv.Value.Map()) ?? new Dictionary<JointType, Joint>(),
				body.HandLeftState.Map(),
				body.HandLeftConfidence.Map(),
				body.HandRightState.Map(),
				body.HandRightConfidence.Map(),
				jointsColorSpacePoints
				);
		}

		public static BodyDataWithColorSpacePoints[] Map(this IEnumerable<(Kinect.Body, BodyJointsColorSpacePointsDict)> bodies)
		{
			return bodies?.Select(b => b.Item1.Map(b.Item2)).ToArray() ?? new BodyDataWithColorSpacePoints[] { };
		}
		#endregion

		#region Kinect.Joint -> Joint
		public static Joint Map(this Kinect.Joint kinectJoint)
		{
			return new Joint(
				kinectJoint.JointType.Map(),
				kinectJoint.Position.Map(),
				kinectJoint.TrackingState.Map()
				);
		}
		#endregion

		#region Kinect.JointType -> JointType
		public static JointType Map(this Kinect.JointType kinectJointType)
		{
			switch (kinectJointType)
			{
				case Kinect.JointType.SpineBase:
					return JointType.SpineBase;
				case Kinect.JointType.SpineMid:
					return JointType.SpineMid;
				case Kinect.JointType.Neck:
					return JointType.Neck;
				case Kinect.JointType.Head:
					return JointType.Head;
				case Kinect.JointType.ShoulderLeft:
					return JointType.ShoulderLeft;
				case Kinect.JointType.ElbowLeft:
					return JointType.ElbowLeft;
				case Kinect.JointType.WristLeft:
					return JointType.WristLeft;
				case Kinect.JointType.HandLeft:
					return JointType.HandLeft;
				case Kinect.JointType.ShoulderRight:
					return JointType.ShoulderRight;
				case Kinect.JointType.ElbowRight:
					return JointType.ElbowRight;
				case Kinect.JointType.WristRight:
					return JointType.WristRight;
				case Kinect.JointType.HandRight:
					return JointType.HandRight;
				case Kinect.JointType.HipLeft:
					return JointType.HipLeft;
				case Kinect.JointType.KneeLeft:
					return JointType.KneeLeft;
				case Kinect.JointType.AnkleLeft:
					return JointType.AnkleLeft;
				case Kinect.JointType.FootLeft:
					return JointType.FootLeft;
				case Kinect.JointType.HipRight:
					return JointType.HipRight;
				case Kinect.JointType.KneeRight:
					return JointType.KneeRight;
				case Kinect.JointType.AnkleRight:
					return JointType.AnkleRight;
				case Kinect.JointType.FootRight:
					return JointType.FootRight;
				case Kinect.JointType.SpineShoulder:
					return JointType.SpineShoulder;
				case Kinect.JointType.HandTipLeft:
					return JointType.HandTipLeft;
				case Kinect.JointType.ThumbLeft:
					return JointType.ThumbLeft;
				case Kinect.JointType.HandTipRight:
					return JointType.HandTipRight;
				case Kinect.JointType.ThumbRight:
					return JointType.ThumbRight;
			}

			return JointType.SpineBase;
		}
		#endregion

		#region Kinect.HandState -> HandState
		public static HandState Map(this Kinect.HandState kinectHandState)
		{
			switch (kinectHandState)
			{
				case Kinect.HandState.Unknown:
					return HandState.Unknown;
				case Kinect.HandState.Open:
					return HandState.Open;
				case Kinect.HandState.Closed:
					return HandState.Closed;
				case Kinect.HandState.Lasso:
					return HandState.Lasso;
			}
			return HandState.Unknown;
		}
		#endregion

		#region Kinect.TrackingConfidence -> TrackingConfidence
		public static TrackingConfidence Map(this Kinect.TrackingConfidence kinectTrackingConfidence)
		{
			switch (kinectTrackingConfidence)
			{
				case Kinect.TrackingConfidence.Low:
					return TrackingConfidence.Low;
				case Kinect.TrackingConfidence.High:
					return TrackingConfidence.High;
			}
			return TrackingConfidence.Low;
		}
		#endregion

		#region Kinect.TrackingState -> TrackingState
		public static TrackingState Map(this Kinect.TrackingState kinectTrackingState)
		{
			switch (kinectTrackingState)
			{
				case Kinect.TrackingState.NotTracked:
					return TrackingState.NotTracked;
				case Kinect.TrackingState.Inferred:
					return TrackingState.Inferred;
				case Kinect.TrackingState.Tracked:
					return TrackingState.Tracked;
			}
			return TrackingState.NotTracked;
		}
		#endregion

		#region Kinect.ColorSpacePoint -> Vector2
		public static Vector2 Map(this Kinect.ColorSpacePoint point)
		{
			return new Vector2(point.X, point.Y);
		}

		public static Vector2[] Map(this IEnumerable<Kinect.ColorSpacePoint> points)
		{
			return points?.Select(p => p.Map()).ToArray() ?? new Vector2[] { };
		}
		#endregion

		#region Kinect.CameraSpaceJoint -> Vector3
		public static Vector3 Map(this Kinect.CameraSpacePoint point)
		{
			return new Vector3(point.X, point.Y, point.Z);
		}

		public static Vector3[] Map(this IEnumerable<Kinect.CameraSpacePoint> points)
		{
			return points?.Select(p => p.Map()).ToArray() ?? new Vector3[] { };
		}
		#endregion
	}
}
