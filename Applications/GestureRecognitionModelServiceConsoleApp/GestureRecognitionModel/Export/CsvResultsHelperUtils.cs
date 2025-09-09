using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Result;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data.GestureRecognition;

namespace GestureRecognition.Applications.GestureRecognitionModelServiceConsoleApp.GestureRecognitionModel.Export
{
	internal class CsvResultsHelperUtils
	{
		#region Consts
		public const string CsvFileExtension = ".csv";
		#endregion

		#region Public methods
		public static void WriteModelProcessResultsToFile(ModelProcessResult[] modelProcessResults, string modelProcessResultsFilePath)
		{
			if (modelProcessResults == null)
				throw new ArgumentNullException(nameof(modelProcessResults));
			if (string.IsNullOrEmpty(modelProcessResultsFilePath))
				throw new ArgumentException(modelProcessResultsFilePath);
			if (!modelProcessResultsFilePath.EndsWith(CsvFileExtension))
				throw new ArgumentException(modelProcessResultsFilePath);

			if (File.Exists(modelProcessResultsFilePath))
			{
				// TODO: To reconsider if appending or overwriting.
				using (var writer = new StreamWriter(modelProcessResultsFilePath, true))
				{
					WriteModelProcessResultsToFile(modelProcessResults, writer, true);
				}
			}
			else
			{
				using (var file = File.Create(modelProcessResultsFilePath))
				{
					using (var writer = new StreamWriter(file, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)))
					{
						WriteModelProcessResultsToFile(modelProcessResults, writer, false);
					}
				}
			}

			foreach (var modelProcessResult in modelProcessResults)
			{
				if (modelProcessResult.PerClassEvalResults != null && modelProcessResult.PerClassEvalResults.Length > 0
					&& !string.IsNullOrEmpty(modelProcessResult.PerClassEvalResultsFilePath) && modelProcessResult.PerClassEvalResultsFilePath.EndsWith(CsvFileExtension))
				{
					if (File.Exists(modelProcessResult.PerClassEvalResultsFilePath))
					{
						// TODO: To reconsider if appending or overwriting.
						using (var writer = new StreamWriter(modelProcessResult.PerClassEvalResultsFilePath, true))
						{
							WritePerClassEvalResultsToFile(modelProcessResult.PerClassEvalResults, writer, true);
						}
					}
					else
					{
						using (var file = File.Create(modelProcessResult.PerClassEvalResultsFilePath))
						{
							using (var writer = new StreamWriter(file, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)))
							{
								WritePerClassEvalResultsToFile(modelProcessResult.PerClassEvalResults, writer, false);
							}
						}
					}
				}
			}
		}

		public static void WriteModelPredictionsPerformanceTestResultToFile(ModelPredictionsPerformanceTestResult result, string resultFile)
		{
			if (result == null)
				throw new ArgumentNullException(nameof(result));
			if (string.IsNullOrEmpty(resultFile))
				throw new ArgumentException(resultFile);
			if (!resultFile.EndsWith(CsvFileExtension))
				throw new ArgumentException(resultFile);

			if (File.Exists(resultFile))
			{
				// TODO: To reconsider if appending or overwriting.
				using (var writer = new StreamWriter(resultFile, true))
				{
					WritePredictionsDurationsMs(writer, result.PredictionsInfo, true);
				}
			}
			else
			{
				using (var file = File.Create(resultFile))
				{
					using (var writer = new StreamWriter(file, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)))
					{
						WritePredictionsDurationsMs(writer, result.PredictionsInfo, false);
					}
				}
			}
		}
		#endregion

		#region Private methods
		private static void WriteModelProcessResultsToFile(ModelProcessResult[] results, StreamWriter writer, bool append)
		{
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = !append }))
			{
				if (!append)
				{
					csv.WriteHeader<ModelProcessResult>();
					csv.NextRecord();
				}

				foreach (var r in results)
				{
					csv.WriteRecord(r);
					csv.NextRecord();
				}
			}
		}

		private static void WritePerClassEvalResultsToFile(PerClassEvalResult[] perClassEvalResults, StreamWriter writer, bool append)
		{
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = !append }))
			{
				if (!append)
				{
					csv.WriteHeader<PerClassEvalResult>();
					csv.NextRecord();
				}

				foreach (var r in perClassEvalResults)
				{
					csv.WriteRecord(r);
					csv.NextRecord();
				}
			}
		}

		private static void WritePredictionsDurationsMs(StreamWriter writer, PredictionPerformanceInfo[] predictionsInfo, bool append)
		{
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = !append }))
			{
				if (!append)
				{
					csv.WriteHeader<PredictionPerformanceInfo>();
					csv.NextRecord();
				}

				foreach (var i in predictionsInfo)
				{
					csv.WriteRecord(i);
					csv.NextRecord();
				}
			}
		}
		#endregion
	}
}
