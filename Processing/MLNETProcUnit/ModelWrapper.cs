using System.IO;
using System.Threading.Tasks;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;
using Microsoft.ML;

namespace GestureRecognition.Processing.MLNETProcUnit
{
	#region IModelWrapper
	public interface IModelWrapper
	{
		#region Properties
		string ModelPath
		{
			get;
		}

		public ModelKind ModelKind
		{
			get;
		}

		public ModelUsageKind ModelUsageKind
		{
			get;
		}

		public bool IsLoaded
		{
			get;
		}
		#endregion

		#region Methods
		LoadModelResult LoadModel(BaseLoadModelParameters parameters);
		Task<BasePredictResult> Predict(BasePredictParameters parameters);
		void Cleanup();
		#endregion
	}
	#endregion

	#region ModelWrapper<Input, Output>
	public abstract class ModelWrapper<Input, Output> : IModelWrapper
		where Input : class
		where Output : class, new()
	{
		#region Protected fields
		protected readonly int? seed;
		protected readonly MLContext mlContext;
		protected ITransformer model;
		protected PredictionEngine<Input, Output> predictionEngine;
		#endregion

		#region Public properties
		public string ModelPath
		{
			get;
			protected set;
		}

		public ModelKind ModelKind
		{
			get;
			protected set;
		}

		public ModelUsageKind ModelUsageKind
		{
			get;
			protected set;
		}

		public bool IsLoaded
		{
			get
			{
				return this.model != null && this.predictionEngine != null;
			}
		}
		#endregion

		#region Constructors
		public ModelWrapper(ModelWrapperParameters parameters)
		{
			this.seed = parameters.Seed;
			this.mlContext = new MLContext(this.seed);
		}
		#endregion

		#region Public methods
		public abstract LoadModelResult LoadModel(BaseLoadModelParameters parameters);
		public abstract Task<BasePredictResult> Predict(BasePredictParameters parameters);
		public void Cleanup()
		{
			this.model = null;
			this.predictionEngine?.Dispose();
			this.predictionEngine = null;
			this.ModelPath = null;
		}
		#endregion

		#region Protected methods
		protected static (bool success, LoadModelResult failedResult) CheckIfFileExists(string filePath)
		{
			if (!File.Exists(filePath))
			{
				return (false, new LoadModelResult()
				{
					ErrorKind = LoadModelErrorKind.FileNotExists,
					ErrorMessage = $"Not found given file: [{filePath}]."
				});
			}

			return (true, null);
		}

		protected static (bool success, LoadModelResult failedResult) CheckIfSupportedModelFileExtension(string modelPathExtension)
		{
			if (!Consts.SupportedModelFileExtension.Contains(modelPathExtension))
			{
				return (false, new LoadModelResult()
				{
					ErrorKind = LoadModelErrorKind.UnsupportedModelFileExtension,
					ErrorMessage = $"Unsupported model file extension: [{modelPathExtension}]. Only supported: [{string.Join(", ", Consts.SupportedModelFileExtension)}]."
				});
			}

			return (true, null);
		}
		#endregion
	}
	#endregion
}
