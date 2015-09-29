using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Skeleton.Client.Core;

namespace Skeleton.Client.Tests
{
	[TestFixture]
	public class ViewModelTests
	{
		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void IDataErrorInfoErrorPropertyIsNotSupported()
		{
			Assert.Throws<NotSupportedException>(() =>
			{
				ViewModelStub viewModel = new ViewModelStub();
				string value = viewModel.Error;
			});
		}

		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void IDataErrorInfoIsAssignableFromViewModel()
		{
			Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
		}

		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void IndexerReturnsErrorMessageForRequestedInvalidProperty()
		{
			ViewModelStub viewModel = new ViewModelStub
			{
				RequiredProperty = null,
				SomeOtherProperty = null
			};

			string errorMessage = viewModel["SomeOtherProperty"];

			Assert.AreEqual("The SomeOtherProperty field is required.", errorMessage);
		}

		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void IndexerValidatesPropertyNameWithInvalidValue()
		{
			ViewModelStub viewModel = new ViewModelStub();
			Assert.IsNotNull(viewModel["RequiredProperty"]);
		}

		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void IndexerValidatesPropertyNameWithValidValue()
		{
			ViewModelStub viewModel = new ViewModelStub
			{
				RequiredProperty = "Some Value"
			};

			Assert.IsNull(viewModel["RequiredProperty"]);
		}

		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void IsObservableObject()
		{
			Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
		}

		[Test]
		[NUnit.Framework.Category("ViewModel")]
		public void ViewModelIsAbstract()
		{
			Assert.IsTrue(typeof(ViewModel).IsAbstract);
		}

		private class ViewModelStub : ViewModel
		{
			[Required]
			public string RequiredProperty { get; set; }

			[Required]
			public string SomeOtherProperty { get; set; }
		}
	}
}
