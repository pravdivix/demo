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
		public void IsINotifyPropertyChangedAssignableFromObservableObject()
		{
			Type observableObjectType = typeof(ObservableObject);
			Assert.IsTrue(typeof(INotifyPropertyChanged).IsAssignableFrom(observableObjectType));
		}

		[Test]
		[NUnit.Framework.Category("ObservableObject")]
		public void IsNotifyPropertyChangedEventRaised()
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

		[Test]
		[NUnit.Framework.Category("ObservableObject")]
		public void IsObservableObjectAbstract()
		{
			Type observableObjectType = typeof(ObservableObject);
			Assert.IsTrue(observableObjectType.IsAbstract);
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
