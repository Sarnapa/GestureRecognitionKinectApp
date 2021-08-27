using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.Messages;
using GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService;
using static GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.ViewModelLocator;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels
{
	public class GestureFeaturesViewModel : ViewModelBase
	{
		#region Private fields
		private readonly IFrameNavigationService navigationService;
		private JointGestureFeaturesViewModel[] jointsFeatures;
		private BoneJointsAngleDataViewModel[] bonesFeatures;
		private HandJointsDistanceViewModel handJointsDistances;
		private int currentJointFeaturesIdx, currentBoneFeaturesIdx;
		#endregion

		#region Public properties
		public JointGestureFeaturesViewModel CurrentJointFeatures
		{
			get
			{
				if (this.currentJointFeaturesIdx >= 0 && this.currentJointFeaturesIdx < this.jointsFeatures.Length)
					return this.jointsFeatures[this.currentJointFeaturesIdx];

				return null;
			}
		}

		public BoneJointsAngleDataViewModel CurrentBoneFeatures
		{
			get
			{
				if (this.currentBoneFeaturesIdx >= 0 && this.currentBoneFeaturesIdx < this.bonesFeatures.Length)
					return this.bonesFeatures[this.currentBoneFeaturesIdx];

				return null;
			}
		}

		public HandJointsDistanceViewModel HandJointsDistances
		{
			get
			{
				return this.handJointsDistances;
			}
		}

		public string ReturnButtonTip
		{
			get
			{
				return Properties.Resources.BackTip;
			}
		}

		public string ReturnButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("BackIcon.png");
			}
		}

		public string PrevButtonTip
		{
			get
			{
				return Properties.Resources.BackTip;
			}
		}

		public string PrevButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("BackIcon.png");
			}
		}

		public string NextButtonTip
		{
			get
			{
				return Properties.Resources.NextTip;
			}
		}

		public string NextButtonImageUri
		{
			get
			{
				return ViewModelsUtils.GetImageUri("NextIcon.png");
			}
		}

		#region Commands
		public RelayCommand ReturnCommand
		{
			get; private set;
		}
		public RelayCommand PrevJointFeaturesCommand
		{
			get; private set;
		}
		public RelayCommand NextJointFeaturesCommand
		{
			get; private set;
		}
		public RelayCommand PrevBoneFeaturesCommand
		{
			get; private set;
		}
		public RelayCommand NextBoneFeaturesCommand
		{
			get; private set;
		}
		#endregion

		#endregion

		#region Constructors
		public GestureFeaturesViewModel(IFrameNavigationService navigationService)
		{
			this.navigationService = navigationService;
			this.ReturnCommand = new RelayCommand(this.ReturnCommandAction);
			this.PrevJointFeaturesCommand = new RelayCommand(this.PrevJointFeaturesCommandAction);
			this.NextJointFeaturesCommand = new RelayCommand(this.NextJointFeaturesCommandAction);
			this.PrevBoneFeaturesCommand = new RelayCommand(this.PrevBoneFeaturesCommandAction);
			this.NextBoneFeaturesCommand = new RelayCommand(this.NextBoneFeaturesCommandAction);
			Messenger.Default.Register<GestureFeaturesMessage>(this, m => GestureFeaturesMessageHandler(m));
		}
		#endregion

		#region Private methods

		#region Actions
		private void ReturnCommandAction()
		{
			this.navigationService.GoBack();
		}

		private void PrevJointFeaturesCommandAction()
		{
			this.currentJointFeaturesIdx = this.currentJointFeaturesIdx == 0 ? this.jointsFeatures.Length - 1 : this.currentJointFeaturesIdx - 1;
			RaisePropertyChanged(nameof(CurrentJointFeatures));
		}

		private void NextJointFeaturesCommandAction()
		{
			this.currentJointFeaturesIdx = (this.currentJointFeaturesIdx + 1) % this.jointsFeatures.Length;
			RaisePropertyChanged(nameof(CurrentJointFeatures));
		}

		private void PrevBoneFeaturesCommandAction()
		{
			this.currentBoneFeaturesIdx = this.currentBoneFeaturesIdx == 0 ? this.bonesFeatures.Length - 1 : this.currentBoneFeaturesIdx - 1;
			RaisePropertyChanged(nameof(CurrentBoneFeatures));
		}

		private void NextBoneFeaturesCommandAction()
		{
			this.currentBoneFeaturesIdx = (this.currentBoneFeaturesIdx + 1) % this.bonesFeatures.Length;
			RaisePropertyChanged(nameof(CurrentBoneFeatures));
		}
		#endregion

		#region Messages handlers
		private void GestureFeaturesMessageHandler(GestureFeaturesMessage m)
		{
			if (m != null && m.Features != null && m.Features.IsValid)
			{
				this.jointsFeatures = m.Features.JointsGestureFeaturesDict.Select(f => new JointGestureFeaturesViewModel(f.Key, f.Value)).ToArray();
				this.bonesFeatures = m.Features.BoneJointsAngleDataDict.Select(b => new BoneJointsAngleDataViewModel(b.Key, b.Value)).ToArray();
				this.handJointsDistances = new HandJointsDistanceViewModel(m.Features.BetweenHandJointsDistanceMax, m.Features.BetweenHandJointsDistanceMean);
				RaisePropertyChanged(nameof(CurrentJointFeatures));
				this.navigationService.NavigateTo(GestureFeaturesPageKey);
			}
		}
		#endregion

		#endregion
	}
}
