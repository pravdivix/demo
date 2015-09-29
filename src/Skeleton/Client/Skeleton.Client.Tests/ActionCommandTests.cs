using System;
using NUnit.Framework;
using Skeleton.Client.Core;

namespace Skeleton.Client.Tests
{
	[TestFixture]
	public class ActionCommandTests
	{
		[Test]
		[Category("ActionCommand")]
		public void CanExecuteIsTrueByDefault()
		{
			ActionCommand command = new ActionCommand(x => { });
			Assert.IsTrue(command.CanExecute(null));
		}

		[Test]
		[Category("ActionCommand")]
		public void CanExecuteOverloadExecutesFalsePredicate()
		{
			ActionCommand command = new ActionCommand(x => { }, y => (int)y == 1);
			Assert.IsFalse(command.CanExecute(0));
		}

		[Test]
		[Category("ActionCommand")]
		public void CanExecuteOverloadExecutesTruePredicate()
		{
			ActionCommand command = new ActionCommand(x => { }, y => (int)y == 1);
			Assert.IsTrue(command.CanExecute(1));
		}

		[Test]
		[Category("ActionCommand")]
		public void ConstructorThrowsExceptionIfActionParameterIsNull()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				ActionCommand command = new ActionCommand(null);
			});
		}

		[Test]
		[Category("ActionCommand")]
		public void ExecuteInvokesAction()
		{
			bool invoked = false;

			Action<object> action = x => invoked = true;

			ActionCommand command = new ActionCommand(action);

			command.Execute(null);

			Assert.IsTrue(invoked);
		}

		[Test]
		[Category("ActionCommand")]
		public void ExecuteOverloadInvokesActionWithParameter()
		{
			bool invoked = false;

			Action<object> action = x =>
			{
				Assert.IsNotNull(x);
				invoked = true;
			};

			ActionCommand command = new ActionCommand(action);

			command.Execute(new object());

			Assert.IsTrue(invoked);
		}
	}
}