using System;
using System.ComponentModel;
using NUnit.Framework;
using Skeleton.Client.Core;

namespace Skeleton.Client.Tests
{
	[TestFixture]
	public class ObservableObjectTest
	{
		[Test]
		[NUnit.Framework.Category("ObservableObject")]
		public void INotifyPropertyChangedIsAssignableFromObservableObject()
		{
			Type observableObjectType = typeof(ObservableObject);
			Assert.IsTrue(typeof(INotifyPropertyChanged).IsAssignableFrom(observableObjectType));
		}

		[Test]
		[NUnit.Framework.Category("ObservableObject")]
		public void ObservableObjectIsAbstract()
		{
			Type observableObjectType = typeof(ObservableObject);
			Assert.IsTrue(observableObjectType.IsAbstract);
		}

		[Test]
		[NUnit.Framework.Category("ObservableObject")]
		public void PropertyChangedEventHandlerIsRaised()
		{
			ObservableObjectStub obj = new ObservableObjectStub();

			bool raised = false;

			obj.PropertyChanged += (s, e) =>
			{
				Assert.AreEqual(e.PropertyName, "TrackingProperty");
				raised = true;
			};

			obj.TrackingProperty = "some value";

			if (!raised)
			{
				Assert.Fail("NotifyPropertyChanged event not raised");
			}
		}

		private class ObservableObjectStub : ObservableObject
		{
			private string trackingProperty;

			public string TrackingProperty
			{
				get
				{
					return trackingProperty;
				}
				set
				{
					trackingProperty = value;
					OnPropertyChanged();
				}
			}
		}
	}
}
