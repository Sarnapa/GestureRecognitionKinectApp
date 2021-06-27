using System;
using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit
{
	public static class MathHelper
	{
		public static double CalculateSpatialAngle(Vector3 v1, Vector3 v2)
		{
			if (v1 == null)
				throw new ArgumentNullException(nameof(v1));
			if (v2 == null)
				throw new ArgumentNullException(nameof(v2));

			return ConvertRadiansToDegrees(Math.Acos(Vector3.Dot(v2, v1) / (v2.Length() * v1.Length())));
		}

		public static double ConvertRadiansToDegrees(double radians)
		{
			return 180 / Math.PI * radians;
		}

		public static double Distance(Vector3 v1, Vector3 v2)
		{
			if (v1 == null)
				throw new ArgumentNullException(nameof(v1));
			if (v2 == null)
				throw new ArgumentNullException(nameof(v2));

			return Vector3.Distance(v2, v1);
		}

		public static double GetDiagonalLength(this JointBoundingBox boundingBox)
		{
			if (boundingBox == null)
				throw new ArgumentNullException(nameof(boundingBox));

			float a = Math.Abs(boundingBox.MaxX - boundingBox.MinX);
			float b = Math.Abs(boundingBox.MaxY - boundingBox.MinY);

			return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)); 
		}

		public static double GetAngle(this JointBoundingBox boundingBox)
		{
			if (boundingBox == null)
				throw new ArgumentNullException(nameof(boundingBox));

			float a = Math.Abs(boundingBox.MaxX - boundingBox.MinX);
			float b = Math.Abs(boundingBox.MaxY - boundingBox.MinY);

			return ConvertRadiansToDegrees(Math.Atan2(b, a));
		}
	}
}
