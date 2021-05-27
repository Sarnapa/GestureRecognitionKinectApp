using System.Threading.Tasks;
using System.Windows.Input;

namespace GestureRecognition.Applications.GestureRecognitionKinectApp.Models.Presentation.Interfaces.Base
{
	public interface IAsyncCommand : ICommand
	{
		Task ExecuteAsync(object parameter);
	}
}
