using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures;
using GestureRecognition.Processing.GestureRecognitionFeaturesProcUnit;

namespace GestureRecognition.Tests.Processing.GestureRecognitionFeaturesProcUnit.UnitTests
{
	[TestClass]
	public class MathHelperTests
	{
		#region Tests

		#region CalculateSpatialAngle methods tests
		[TestMethod]
		public void CalculateSpatialAngle_NormalVectors()
		{
			CalculateSpatialAngleTest(new Vector3(1, 0, 0), new Vector3(0, 1, 0), 90f);
		}

		[TestMethod]
		public void CalculateSpatialAngle_ParallelVectors()
		{
			CalculateSpatialAngleTest(new Vector3(2, 0, 0), new Vector3(1, 0, 0), 0f);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors1()
		{
			CalculateSpatialAngleTest(new Vector3(1, 1, 0), new Vector3(1, 0, 0), 45f);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors2()
		{
			CalculateSpatialAngleTest(new Vector3(1, -1, 0), new Vector3(1, 0, 0), 45f);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors3()
		{
			CalculateSpatialAngleTest(new Vector3(-1, 0, 1), new Vector3(1, 0, 1), 90f);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors4()
		{
			CalculateSpatialAngleTest(new Vector3(-1, 1, 2), new Vector3(1, -1, 3), 60.504f);
		}
		#endregion

		#region Distance method tests
		[TestMethod]
		public void Distance_ConcurrentVectors()
		{
			DistanceTest(new Vector3(1, 1, 1), new Vector3(1, 1, 1), 0f);
		}

		[TestMethod]
		public void Distance_ParallelVectorsX()
		{
			DistanceTest(new Vector3(2, 0, 0), new Vector3(1, 0, 0), 1f);
		}

		[TestMethod]
		public void Distance_ParallelVectorsY()
		{
			DistanceTest(new Vector3(0, 2, 0), new Vector3(0, 1, 0), 1f);
		}

		[TestMethod]
		public void Distance_ParallelVectorsZ()
		{
			DistanceTest(new Vector3(0, 0, 2), new Vector3(0, 0, 1), 1f);
		}

		[TestMethod]
		public void Distance_CustomVectors1()
		{
			DistanceTest(new Vector3(1, 2, 1), new Vector3(2, -1, 2), 3.317f);
		}
		#endregion

		#region GetDiagonalLength methods tests
		[TestMethod]
		public void GetDiagonalLength_EmptyJointBoundingBox()
		{
			GetDiagonalLengthTest(new JointBoundingBox(0, 0, 0, 0, 0, 0), 0f);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox1()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-1, 1, -1, 1, 0, 0), 2.828f);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox2()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-1, 1, -1, 1, 0, 2), 2.828f);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox3()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-1, 1, 0, 0, 0, 0), 2f);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox4()
		{
			GetDiagonalLengthTest(new JointBoundingBox(0, 0, -1, 1, 0, 0), 2f);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox5()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-3.2f, 5.2f, 1.1f, 1.4f, 3.1f, 4.4f), 8.405f);
		}
		#endregion

		#region GetAngle methods tests
		public void GetAngle_EmptyJointBoundingBox()
		{
			GetAngleTest(new JointBoundingBox(0, 0, 0, 0, 0, 0), 0f);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox1()
		{
			GetAngleTest(new JointBoundingBox(-1, 1, -1, 1, 0, 0), 45f);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox2()
		{
			GetAngleTest(new JointBoundingBox(-1, 1, -1, 1, 0, 2), 45f);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox3()
		{
			GetAngleTest(new JointBoundingBox(-1, 1, 0, 0, 0, 0), 0f);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox4()
		{
			GetAngleTest(new JointBoundingBox(0, 0, -1, 1, 0, 0), 90f);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox5()
		{
			GetAngleTest(new JointBoundingBox(-3.2f, 5.2f, 1.1f, 1.4f, 3.1f, 4.4f), 2.045f);
		}
		#endregion

		#endregion

		#region Private methods
		private void CalculateSpatialAngleTest(Vector3 v1, Vector3 v2, float expectedRes, int fractionalDigits = 3)
		{
			float res = MathHelper.CalculateSpatialAngle(v1, v2);
			Assert.AreEqual(expectedRes, Convert.ToSingle(Math.Round(res, fractionalDigits)));
		}

		private void DistanceTest(Vector3 v1, Vector3 v2, float expectedRes, int fractionalDigits = 3)
		{
			float res = MathHelper.Distance(v1, v2);
			Assert.AreEqual(expectedRes, Convert.ToSingle(Math.Round(res, fractionalDigits)));
		}

		private void GetDiagonalLengthTest(JointBoundingBox boundingBox, float expectedRes, int fractionalDigits = 3)
		{
			float res = MathHelper.GetDiagonalLength(boundingBox);
			Assert.AreEqual(expectedRes, Convert.ToSingle(Math.Round(res, fractionalDigits)));
		}

		private void GetAngleTest(JointBoundingBox boundingBox, float expectedRes, int fractionalDigits = 3)
		{
			float res = MathHelper.GetAngle(boundingBox);
			Assert.AreEqual(expectedRes, Convert.ToSingle(Math.Round(res, fractionalDigits)));
		}
		#endregion
	}
}
