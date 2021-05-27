using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.ViewModels.NavigationService
{
	public class FrameNavigationService: IFrameNavigationService, INotifyPropertyChanged
	{
		#region Private fields
		private readonly Dictionary<string, Uri> pagesByKey;
		private readonly List<string> historic;
		private string _currentPageKey;
		#endregion

		#region Private properties                                              
		public string CurrentPageKey
		{
			get
			{
				return _currentPageKey;
			}

			private set
			{
				if (_currentPageKey == value)
				{
					return;
				}

				_currentPageKey = value;
				OnPropertyChanged("CurrentPageKey");
			}
		}
		public object Parameter
		{
			get; private set;
		}
		#endregion

		#region Constructors
		public FrameNavigationService()
		{
			this.pagesByKey = new Dictionary<string, Uri>();
			this.historic = new List<string>();
		}
		#endregion

		#region Public methods

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		public void GoBack()
		{
			if (this.historic.Count > 1)
			{
				this.historic.RemoveAt(this.historic.Count - 1);
				NavigateTo(this.historic.Last(), null);
			}
		}

		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		public virtual void NavigateTo(string pageKey, object parameter)
		{
			lock (this.pagesByKey)
			{
				if (!this.pagesByKey.ContainsKey(pageKey))
				{
					throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
				}


				if (GetDescendantFromName(Application.Current.MainWindow, "MainFrame") is Frame frame)
				{
					frame.Source = this.pagesByKey[pageKey];
				}

				this.Parameter = parameter;
				this.historic.Add(pageKey);
				this.CurrentPageKey = pageKey;
			}
		}

		public void Configure(string key, Uri pageType)
		{
			lock (this.pagesByKey)
			{
				if (this.pagesByKey.ContainsKey(key))
				{
					this.pagesByKey[key] = pageType;
				}
				else
				{
					this.pagesByKey.Add(key, pageType);
				}
			}
		}
		#endregion

		#region Protected methods
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		#region Private methods
		private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
		{
			int count = VisualTreeHelper.GetChildrenCount(parent);

			if (count < 1)
			{
				return null;
			}

			for (int i = 0; i < count; i++)
			{
				if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
				{
					if (frameworkElement.Name == name)
					{
						return frameworkElement;
					}

					frameworkElement = GetDescendantFromName(frameworkElement, name);
					if (frameworkElement != null)
					{
						return frameworkElement;
					}
				}
			}
			return null;
		}
		#endregion
	}
}
