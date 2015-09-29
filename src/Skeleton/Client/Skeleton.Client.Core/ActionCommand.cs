using System;
using System.Windows.Input;
using Skeleton.Client.Core.Annotations;

namespace Skeleton.Client.Core
{
	public sealed class ActionCommand : ICommand
	{
		private readonly Action<object> action;
		private readonly Predicate<object> predicate;

		public ActionCommand([NotNull] Action<object> action, Predicate<object> predicate = null)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}

			this.action = action;
			this.predicate = predicate;
		}

		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Defines the method that determines whether the command can execute in its current state.
		/// </summary>
		/// <returns>
		/// true if this command can be executed; otherwise, false.
		/// </returns>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
		public bool CanExecute(object parameter)
		{
			return predicate == null || predicate(parameter);
		}

		/// <summary>
		/// Defines the method to be called when the command is invoked.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
		public void Execute(object parameter = null)
		{
			action(parameter);
		}
	}
}