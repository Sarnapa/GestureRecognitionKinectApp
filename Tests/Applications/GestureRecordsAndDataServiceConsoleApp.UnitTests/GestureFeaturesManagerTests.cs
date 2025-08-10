using GestureRecognition.Applications.GestureRecordsServiceConsoleApp;
using GestureRecognition.Applications.GestureRecordsServiceConsoleApp.GestureRecognitionFeatures;
using GestureRecognition.Processing.BaseClassLib.Structures.GestureRecognition.DataViews;
using GestureRecognition.Processing.BaseClassLib.Utils;

namespace GestureRecognition.Tests.Applications.GestureRecordsAndDataServiceConsoleApp.UnitTests
{
	[TestClass]
	public sealed class GestureFeaturesManagerTests
	{
		#region Private fields
		private const string KINECT_INPUT_DIR_PATH = @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Goodbye\2025_08_10\Kinect\";
		private const string KINECT_INPUT_FILE_PATH = $"{KINECT_INPUT_DIR_PATH}20250202_Goodbye1.record";
		private const string KINECT_OUTPUT_DIR_PATH = @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Goodbye\2025_08_10\Kinect\Test\";
		private const string KINECT_OUTPUT_FILE_PATH = $"{KINECT_OUTPUT_DIR_PATH}20250202_Goodbye1.record";
		private const string MEDIAPIPE_HAND_LANDMARKS_INPUT_DIR_PATH = @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Goodbye\2025_08_10\MediaPipeHandLandmarks\";
		private const string MEDIAPIPE_HAND_LANDMARKS_INPUT_FILE_PATH = $"{MEDIAPIPE_HAND_LANDMARKS_INPUT_DIR_PATH}20250202_Goodbye1.record";
		private const string MEDIAPIPE_HAND_LANDMARKS_OUTPUT_DIR_PATH = @"C:\Users\Michal\OneDrive\Studies\Praca_MGR\Project\Data\ASLGestures\Goodbye\2025_08_10\MediaPipeHandLandmarks\Test\";
		private const string MEDIAPIPE_HAND_LANDMARKS_OUTPUT_FILE_PATH = $"{MEDIAPIPE_HAND_LANDMARKS_OUTPUT_DIR_PATH}20250202_Goodbye1.record";
		#endregion

		#region Tests methods
		[TestMethod]
		public async Task CalculationKinectFeaturesProcessFileTest()
		{
			await CalculationFeaturesProcessTest<KinectGestureDataView>(FileProcessMode.File, KINECT_INPUT_FILE_PATH, KINECT_OUTPUT_FILE_PATH).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task CalculationKinectFeaturesProcessDirTest()
		{
			await CalculationFeaturesProcessTest<KinectGestureDataView>(FileProcessMode.Directory, KINECT_INPUT_DIR_PATH, KINECT_OUTPUT_DIR_PATH).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task CalculationMediaPipeHandLandmarksFeaturesProcessFileTest()
		{
			await CalculationFeaturesProcessTest<MediaPipeHandLandmarksGestureDataView>(FileProcessMode.File, MEDIAPIPE_HAND_LANDMARKS_INPUT_FILE_PATH, MEDIAPIPE_HAND_LANDMARKS_OUTPUT_FILE_PATH).ConfigureAwait(false);
		}

		[TestMethod]
		public async Task CalculationMediaPipeHandLandmarksFeaturesProcessDirTest()
		{
			await CalculationFeaturesProcessTest<MediaPipeHandLandmarksGestureDataView>(FileProcessMode.Directory, MEDIAPIPE_HAND_LANDMARKS_INPUT_DIR_PATH, MEDIAPIPE_HAND_LANDMARKS_OUTPUT_DIR_PATH).ConfigureAwait(false);
		}
		#endregion

		#region Private mmethods
		private static T LoadGestureDataFromFile<T>(string filePath)
			where T : GestureDataView
		{
			string gestureDataFilePath = filePath.Replace(".record", CsvHelperUtils.CsvFileExtension);
			Assert.IsTrue(File.Exists(gestureDataFilePath));

			var gestureData = CsvHelperUtils.GetGesturesFromFile<T>(gestureDataFilePath).FirstOrDefault();
			Assert.IsNotNull(gestureData);

			return gestureData;
		}

		private static Dictionary<string, T> LoadGestureDataFromFiles<T>(string filePath, bool isDirectory)
			where T : GestureDataView
		{
			var result = new Dictionary<string, T>();

			if (isDirectory)
			{
				string[] gestureDataFiles = Directory.GetFiles(filePath, $"*.record");
				if (gestureDataFiles != null)
				{
					foreach (string gestureDataFilePath in gestureDataFiles)
					{
						var gestureData = LoadGestureDataFromFile<T>(gestureDataFilePath);
						result.Add(Path.GetFileName(gestureDataFilePath), gestureData);
					}
				}
			}
			else
			{
				var gestureData = LoadGestureDataFromFile<T>(filePath);
				result.Add(Path.GetFileName(filePath), gestureData);
			}

			return result;
		}

		private static async Task CalculationFeaturesProcessTest<T>(FileProcessMode fileProcessMode, string inputFilePath, string outputFilePath)
			where T : GestureDataView
		{
			bool isDirectory = fileProcessMode == FileProcessMode.Directory;

			bool isKinectGestureDataView = typeof(T) == typeof(KinectGestureDataView);
			bool isMediaPipeHandLandmarksGestureDataView = typeof(T) == typeof(MediaPipeHandLandmarksGestureDataView);

			Assert.IsTrue(isKinectGestureDataView || isMediaPipeHandLandmarksGestureDataView);

			Assert.IsNotNull(inputFilePath);
			Assert.IsNotEmpty(inputFilePath);
			if (!isDirectory)
				Assert.IsTrue(inputFilePath.EndsWith(".record"));

			if (isDirectory)
				Assert.IsTrue(Directory.Exists(inputFilePath));
			else
				Assert.IsTrue(File.Exists(inputFilePath));

			Assert.IsNotNull(outputFilePath);
			Assert.IsNotEmpty(outputFilePath);
			if (isDirectory)
				Assert.IsTrue(Directory.Exists(outputFilePath));
			else
				Assert.IsTrue(outputFilePath.EndsWith(".record"));

			var inputGesturesData = LoadGestureDataFromFiles<T>(inputFilePath, isDirectory);
			
			var gestureFeaturesManager = new GestureFeaturesManager(fileProcessMode, inputFilePath, outputFilePath, null, null);
			Assert.IsNotNull(gestureFeaturesManager);

			await gestureFeaturesManager.ExecuteCalculationFeaturesProcess().ConfigureAwait(false);

			if (!isDirectory)
				Assert.IsTrue(File.Exists(outputFilePath));

			var outputGesturesData = LoadGestureDataFromFiles<T>(outputFilePath, isDirectory);

			Assert.AreEqual(inputGesturesData.Count, outputGesturesData.Count);

			if (isKinectGestureDataView)
			{
				if (isDirectory)
				{
					foreach (var inputGestureDataPair in inputGesturesData)
					{
						string inputGestureDataFileName = inputGestureDataPair.Key;
						var inputGestureData = inputGestureDataPair.Value;

						Assert.IsTrue(inputGesturesData.ContainsKey(inputGestureDataFileName));
						var outputGestureData = outputGesturesData[inputGestureDataFileName];

						Assert.IsTrue(KinectGestureDataViewComparer.Instance.Equals(inputGestureData as KinectGestureDataView,
							outputGestureData as KinectGestureDataView));
					}
				}
				else
				{
					Assert.IsTrue(KinectGestureDataViewComparer.Instance.Equals(inputGesturesData.FirstOrDefault().Value as KinectGestureDataView,
						outputGesturesData.FirstOrDefault().Value as KinectGestureDataView));
				}
			}
			else
			{
				if (isDirectory)
				{
					foreach (var inputGestureDataPair in inputGesturesData)
					{
						string inputGestureDataFileName = inputGestureDataPair.Key;
						var inputGestureData = inputGestureDataPair.Value;

						Assert.IsTrue(inputGesturesData.ContainsKey(inputGestureDataFileName));
						var outputGestureData = outputGesturesData[inputGestureDataFileName];

						Assert.IsTrue(MediaPipeHandLandmarksGestureDataViewComparer.Instance.Equals(inputGestureData as MediaPipeHandLandmarksGestureDataView,
							outputGestureData as MediaPipeHandLandmarksGestureDataView));
					}
				}
				else
				{
					Assert.IsTrue(MediaPipeHandLandmarksGestureDataViewComparer.Instance.Equals(inputGesturesData.FirstOrDefault().Value as MediaPipeHandLandmarksGestureDataView,
						outputGesturesData.FirstOrDefault().Value as MediaPipeHandLandmarksGestureDataView));
				}
			}
		}

		#endregion
	}
}
