using System;
using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;

namespace GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit
{
	public static class MathHelper
	{
		#region Public methods
		public static double CalculateSpatialAngle(Vector3 v1, Vector3 v2)
		{
			if (v1 == null)
				throw new ArgumentNullException(nameof(v1));
			if (v2 == null)
				throw new ArgumentNullException(nameof(v2));

			// TODO: MP: Do pomyślenia, czy zastosować, gdyby były jakieś problemy.
			//var convertedV1 = v1.ToVector2();
			//var convertedV2 = v2.ToVector2();

			double val = Vector3.Dot(v2, v1) / (v2.Length() * v1.Length());
			val = Math.Max(-1d, val);
			val = Math.Min(1d, val);

			return ConvertRadiansToDegrees(Math.Acos(val));
		}

		public static double ConvertRadiansToDegrees(double radians)
		{
			return radians == 0d ? 0d : 180d / Math.PI * radians;
		}

		public static double Distance(Vector3 v1, Vector3 v2)
		{
			if (v1 == null)
				throw new ArgumentNullException(nameof(v1));
			if (v2 == null)
				throw new ArgumentNullException(nameof(v2));

			// TODO: MP: Do pomyślenia, czy zastosować, gdyby były jakieś problemy.
			//var convertedV1 = v1.ToVector2();
			//var convertedV2 = v2.ToVector2();

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
		#endregion

		#region Private methods
		private static Vector2 ToVector2(this Vector3 vec)
		{
			if (vec == null)
				return Vector2.Zero;

			return new Vector2(vec.X, vec.Y);
		}
		#endregion
	}
}
