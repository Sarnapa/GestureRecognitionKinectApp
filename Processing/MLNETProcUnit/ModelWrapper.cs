using System.IO;
using Microsoft.ML;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET;
using GestureRecognition.Processing.BaseClassLib.Structures.MLNET.Data;

namespace GestureRecognition.Processing.MLNETProcUnit
{
	#region IModelWrapper
	public interface IModelWrapper<
		SetDataParamsType,
		TrainParamsType, TrainResultType,
		PredictParamsType, PredictResultType,
		EvaluateParamsType, EvaluateResultType,
		CrossValidateParamsType, CrossValidateResultType,
		LoadModelParamsType,
		SaveModelParamsType>
		where SetDataParamsType : BaseSetDataParameters
		where TrainParamsType : BaseTrainParameters
		where TrainResultType : BaseTrainResult
		where PredictParamsType : BasePredictParameters
		where PredictResultType : BasePredictResult
		where EvaluateParamsType : BaseEvaluateParameters
		where EvaluateResultType : BaseEvaluateResult
		where CrossValidateParamsType : BaseCrossValidateParameters<TrainParamsType, EvaluateParamsType>
		where CrossValidateResultType : BaseCrossValidateResult<TrainResultType, EvaluateResultType>
		where LoadModelParamsType : BaseLoadModelParameters
		where SaveModelParamsType : BaseSaveModelParameters
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
		SetDataResult SetData(SetDataParamsType parameters);
		TrainResultType TrainModel(TrainParamsType parameters);
		PredictResultType Predict(PredictParamsType parameters);
		EvaluateResultType Evaluate(EvaluateParamsType parameters);
		CrossValidateResultType CrossValidate(CrossValidateParamsType parameters);
		LoadModelResult LoadModel(LoadModelParamsType parameters);
		SaveModelResult SaveModel(SaveModelParamsType parameters);
		void Cleanup();
		#endregion
	}
	#endregion

	#region ModelWrapper<Input, Output>
	public abstract class ModelWrapper<
		SetDataParamsType,
		TrainParamsType, TrainResultType,
		PredictParamsType, PredictResultType,
		EvaluateParamsType, EvaluateResultType,
		CrossValidateParamsType, CrossValidateResultType,
		LoadModelParamsType,
		SaveModelParamsType>: IModelWrapper<
		SetDataParamsType,
		TrainParamsType, TrainResultType,
		PredictParamsType, PredictResultType,
		EvaluateParamsType, EvaluateResultType,
		CrossValidateParamsType, CrossValidateResultType,
		LoadModelParamsType,
		SaveModelParamsType>
		where SetDataParamsType : BaseSetDataParameters
		where TrainParamsType : BaseTrainParameters
		where TrainResultType : BaseTrainResult
		where PredictParamsType : BasePredictParameters
		where PredictResultType : BasePredictResult
		where EvaluateParamsType : BaseEvaluateParameters
		where EvaluateResultType : BaseEvaluateResult
		where CrossValidateParamsType : BaseCrossValidateParameters<TrainParamsType, EvaluateParamsType>
		where CrossValidateResultType : BaseCrossValidateResult<TrainResultType, EvaluateResultType>
		where LoadModelParamsType : BaseLoadModelParameters
		where SaveModelParamsType : BaseSaveModelParameters
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
		public abstract SetDataResult SetData(SetDataParamsType parameters);
		public abstract TrainResultType TrainModel(TrainParamsType parameters);
		public abstract PredictResultType Predict(PredictParamsType parameters);
		public abstract EvaluateResultType Evaluate(EvaluateParamsType parameters);
		public abstract CrossValidateResultType CrossValidate(CrossValidateParamsType parameters);
		public abstract LoadModelResult LoadModel(LoadModelParamsType parameters);
		public abstract SaveModelResult SaveModel(SaveModelParamsType parameters);
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
