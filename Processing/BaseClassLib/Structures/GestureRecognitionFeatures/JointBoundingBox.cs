namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognitionFeatures
{
	public class JointBoundingBox
	{
		#region Public properties
		public float MinX
		{
			get;
			private set;
		}

		public float MaxX
		{
			get;
			private set;
		}

		public float MinY
		{
			get;
			private set;
		}

		public float MaxY
		{
			get;
			private set;
		}

		public float MinZ
		{
			get;
			private set;
		}

		public float MaxZ
		{
			get;
			private set;
		}
		#endregion

		#region Constructors
		public JointBoundingBox(float minX, float maxX, float minY, float maxY) : this(minX, maxX, minY, maxY, 0f, 0f)
		{}

		public JointBoundingBox(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
		{
			this.MinX = minX;
			this.MaxX = maxX;
			this.MinY = minY;
			this.MaxY = maxY;
			this.MinZ = minZ;
			this.MaxZ = maxZ;
		}
		#endregion
	}
}
