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
			CalculateSpatialAngleTest(new Vector3(1, 0, 0), new Vector3(0, 1, 0), 90d);
		}

		[TestMethod]
		public void CalculateSpatialAngle_ParallelVectors()
		{
			CalculateSpatialAngleTest(new Vector3(2, 0, 0), new Vector3(1, 0, 0), 0d);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors1()
		{
			CalculateSpatialAngleTest(new Vector3(1, 1, 0), new Vector3(1, 0, 0), 45d);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors2()
		{
			CalculateSpatialAngleTest(new Vector3(1, -1, 0), new Vector3(1, 0, 0), 45d);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors3()
		{
			CalculateSpatialAngleTest(new Vector3(-1, 0, 1), new Vector3(1, 0, 1), 90d);
		}

		[TestMethod]
		public void CalculateSpatialAngle_CustomVectors4()
		{
			CalculateSpatialAngleTest(new Vector3(-1, 1, 2), new Vector3(1, -1, 3), 60.504d);
		}
		#endregion

		#region Distance method tests
		[TestMethod]
		public void Distance_ConcurrentVectors()
		{
			DistanceTest(new Vector3(1, 1, 1), new Vector3(1, 1, 1), 0d);
		}

		[TestMethod]
		public void Distance_ParallelVectorsX()
		{
			DistanceTest(new Vector3(2, 0, 0), new Vector3(1, 0, 0), 1d);
		}

		[TestMethod]
		public void Distance_ParallelVectorsY()
		{
			DistanceTest(new Vector3(0, 2, 0), new Vector3(0, 1, 0), 1d);
		}

		[TestMethod]
		public void Distance_ParallelVectorsZ()
		{
			DistanceTest(new Vector3(0, 0, 2), new Vector3(0, 0, 1), 1d);
		}

		[TestMethod]
		public void Distance_CustomVectors1()
		{
			DistanceTest(new Vector3(1, 2, 1), new Vector3(2, -1, 2), 3.317d);
		}
		#endregion

		#region GetDiagonalLength methods tests
		[TestMethod]
		public void GetDiagonalLength_EmptyJointBoundingBox()
		{
			GetDiagonalLengthTest(new JointBoundingBox(0, 0, 0, 0, 0, 0), 0d);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox1()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-1, 1, -1, 1, 0, 0), 2.828d);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox2()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-1, 1, -1, 1, 0, 2), 2.828d);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox3()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-1, 1, 0, 0, 0, 0), 2d);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox4()
		{
			GetDiagonalLengthTest(new JointBoundingBox(0, 0, -1, 1, 0, 0), 2d);
		}

		[TestMethod]
		public void GetDiagonalLength_CustomJointBoundingBox5()
		{
			GetDiagonalLengthTest(new JointBoundingBox(-3.2f, 5.2f, 1.1f, 1.4f, 3.1f, 4.4f), 8.405d);
		}
		#endregion

		#region GetAngle methods tests
		public void GetAngle_EmptyJointBoundingBox()
		{
			GetAngleTest(new JointBoundingBox(0, 0, 0, 0, 0, 0), 0d);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox1()
		{
			GetAngleTest(new JointBoundingBox(-1, 1, -1, 1, 0, 0), 45d);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox2()
		{
			GetAngleTest(new JointBoundingBox(-1, 1, -1, 1, 0, 2), 45d);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox3()
		{
			GetAngleTest(new JointBoundingBox(-1, 1, 0, 0, 0, 0), 0d);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox4()
		{
			GetAngleTest(new JointBoundingBox(0, 0, -1, 1, 0, 0), 90d);
		}

		[TestMethod]
		public void GetAngle_CustomJointBoundingBox5()
		{
			GetAngleTest(new JointBoundingBox(-3.2f, 5.2f, 1.1f, 1.4f, 3.1f, 4.4f), 2.045d);
		}
		#endregion

		#endregion

		#region Private methods
		private void CalculateSpatialAngleTest(Vector3 v1, Vector3 v2, double expectedRes, int fractionalDigits = 3)
		{
			double res = MathHelper.CalculateSpatialAngle(v1, v2);
			Assert.AreEqual(expectedRes, Math.Round(res, fractionalDigits));
		}

		private void DistanceTest(Vector3 v1, Vector3 v2, double expectedRes, int fractionalDigits = 3)
		{
			double res = MathHelper.Distance(v1, v2);
			Assert.AreEqual(expectedRes, Math.Round(res, fractionalDigits));
		}

		private void GetDiagonalLengthTest(JointBoundingBox boundingBox, double expectedRes, int fractionalDigits = 3)
		{
			double res = MathHelper.GetDiagonalLength(boundingBox);
			Assert.AreEqual(expectedRes, Math.Round(res, fractionalDigits));
		}

		private void GetAngleTest(JointBoundingBox boundingBox, double expectedRes, int fractionalDigits = 3)
		{
			double res = MathHelper.GetAngle(boundingBox);
			Assert.AreEqual(expectedRes, Math.Round(res, fractionalDigits));
		}
		#endregion
	}
}
