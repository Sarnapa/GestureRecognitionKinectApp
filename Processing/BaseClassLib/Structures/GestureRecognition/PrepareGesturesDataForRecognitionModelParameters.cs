using System.Collections.Generic;

namespace GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition
{
	public class PrepareGesturesDataForRecognitionModelParameters
	{
		public string[] GestureDataFilesPaths
		{
			get;
			set;
		}

		public string GesturesDataOutputFilePath
		{
			get; set;
		}
	}
}
