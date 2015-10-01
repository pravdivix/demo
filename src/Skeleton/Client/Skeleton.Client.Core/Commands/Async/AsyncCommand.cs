using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Skeleton.Client.Core.Commands.Async
{
	public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
	{
		private readonly CancelAsyncCommand cancelCommand;
		private readonly Func<CancellationToken, Task<TResult>> command;
		private NotifyTaskCompletion<TResult> execution;

		public AsyncCommand(Func<CancellationToken, Task<TResult>> command)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			this.command = command;
			cancelCommand = new CancelAsyncCommand();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand CancelCommand
		{
			get { return cancelCommand; }
		}

		public NotifyTaskCompletion<TResult> Execution
		{
			get
			{
				return execution;
			}

			private set
			{
				execution = value;
				OnPropertyChanged();
			}
		}

		public override bool CanExecute(object parameter)
		{
			return Execution == null || Execution.IsCompleted;
		}

		public override async Task ExecuteAsync(object parameter)
		{
			cancelCommand.NotifyCommandStarting();
			Execution = new NotifyTaskCompletion<TResult>(command(cancelCommand.Token));
			RaiseCanExecuteChanged();
			await Execution.TaskCompletion;
			cancelCommand.NotifyCommandFinished();
			RaiseCanExecuteChanged();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = Volatile.Read(ref PropertyChanged);

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private sealed class CancelAsyncCommand : ICommand
		{
			private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

			private bool commandExecuting;

			public event EventHandler CanExecuteChanged
			{
				add { CommandManager.RequerySuggested += value; }
				remove { CommandManager.RequerySuggested -= value; }
			}

			public CancellationToken Token
			{
				get { return cancellationTokenSource.Token; }
			}

			public bool CanExecute(object parameter)
			{
				return commandExecuting && !cancellationTokenSource.IsCancellationRequested;
			}

			public void Execute(object parameter)
			{
				cancellationTokenSource.Cancel();
				RaiseCanExecuteChanged();
			}

			public void NotifyCommandFinished()
			{
				commandExecuting = false;
				RaiseCanExecuteChanged();
			}

			public void NotifyCommandStarting()
			{
				commandExecuting = true;

				if (!cancellationTokenSource.IsCancellationRequested)
				{
					return;
				}

				cancellationTokenSource = new CancellationTokenSource();

				RaiseCanExecuteChanged();
			}

			private void RaiseCanExecuteChanged()
			{
				CommandManager.InvalidateRequerySuggested();
			}
		}
	}
}