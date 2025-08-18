using System.IO;
using Microsoft.ML;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;

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

		ModelKind ModelKind
		{
			get;
		}

		ModelUsageKind ModelUsageKind
		{
			get;
		}

		bool IsLoaded
		{
			get;
		}

		bool IsTrainData
		{
			get;
		}

		bool IsTestData
		{
			get;
		}
		#endregion

		#region Methods
		SetDataResult SetData(BaseSetDataParameters parameters);
		BaseTrainResult TrainModel(BaseTrainParameters parameters);
		BasePredictResult Predict(BasePredictParameters parameters);
		BaseEvaluateResult Evaluate(BaseEvaluateParameters parameters);
		LoadModelResult LoadModel(BaseLoadModelParameters parameters);
		SaveModelResult SaveModel(BaseSaveModelParameters parameters);
		void Cleanup();
		#endregion
	}
	#endregion

	#region ModelWrapper<Input, Output>
	public abstract class ModelWrapper: IModelWrapper
	{
		#region Protected fields
		protected readonly int? seed;
		protected readonly MLContext mlContext;
		protected ITransformer model;
		protected IDataView trainData;
		protected IDataView testData;
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

		public virtual bool IsLoaded
		{
			get
			{
				return this.model != null;
			}
		}

		public bool IsTrainData
		{
			get
			{
				return this.trainData != null;
			}
		}

		public bool IsTestData
		{
			get
			{
				return this.testData != null;
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
		public abstract SetDataResult SetData(BaseSetDataParameters parameters);
		public abstract BaseTrainResult TrainModel(BaseTrainParameters parameters);
		public abstract BasePredictResult Predict(BasePredictParameters parameters);
		public abstract BaseEvaluateResult Evaluate(BaseEvaluateParameters parameters);
		public abstract LoadModelResult LoadModel(BaseLoadModelParameters parameters);
		public abstract SaveModelResult SaveModel(BaseSaveModelParameters parameters);
		public abstract void Cleanup();
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

		protected static (bool success, LoadModelResult failedResult) CheckIfSupportedModelFileExtensionToLoad(string modelPathExtension)
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

		protected static (bool success, SaveModelResult failedResult) CheckIfSupportedModelFileExtensionToSave(string modelPathExtension)
		{
			if (!Consts.SupportedModelFileExtension.Contains(modelPathExtension))
			{
				return (false, new SaveModelResult()
				{
					ErrorKind = SaveModelErrorKind.UnsupportedModelFileExtension,
					ErrorMessage = $"Unsupported model file extension: [{modelPathExtension}]. Only supported: [{string.Join(", ", Consts.SupportedModelFileExtension)}]."
				});
			}

			return (true, null);
		}
		#endregion
	}
	#endregion
}
