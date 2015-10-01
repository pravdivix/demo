using System;
using NUnit.Framework;
using Skeleton.Client.Core.Commands;

namespace Skeleton.Client.Tests
{
	[TestFixture]
	public class ActionCommandTests
	{
		[Test]
		[Category("RelayCommand")]
		public void CanExecuteIsTrueByDefault()
		{
			RelayCommand command = new RelayCommand(x => { });
			Assert.IsTrue(command.CanExecute(null));
		}

		[Test]
		[Category("RelayCommand")]
		public void CanExecuteOverloadExecutesFalsePredicate()
		{
			RelayCommand command = new RelayCommand(x => { }, y => (int)y == 1);
			Assert.IsFalse(command.CanExecute(0));
		}

		[Test]
		[Category("RelayCommand")]
		public void CanExecuteOverloadExecutesTruePredicate()
		{
			RelayCommand command = new RelayCommand(x => { }, y => (int)y == 1);
			Assert.IsTrue(command.CanExecute(1));
		}

		[Test]
		[Category("RelayCommand")]
		public void ConstructorThrowsExceptionIfActionParameterIsNull()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				RelayCommand command = new RelayCommand(null);
			});
		}

		[Test]
		[Category("RelayCommand")]
		public void ExecuteInvokesAction()
		{
			bool invoked = false;

			Action<object> action = x => invoked = true;

			RelayCommand command = new RelayCommand(action);

			command.Execute(null);

			Assert.IsTrue(invoked);
		}

		[Test]
		[Category("RelayCommand")]
		public void ExecuteOverloadInvokesActionWithParameter()
		{
			bool invoked = false;

			Action<object> action = x =>
			{
				Assert.IsNotNull(x);
				invoked = true;
			};

			RelayCommand command = new RelayCommand(action);

			command.Execute(new object());

			Assert.IsTrue(invoked);
		}
	}
}