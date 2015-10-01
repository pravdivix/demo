using System.Threading.Tasks;
using System.Windows.Input;

namespace Skeleton.Client.Core.Commands.Async
{
	public interface IAsyncCommand : ICommand
	{
		Task ExecuteAsync(object parameter);
	}
}