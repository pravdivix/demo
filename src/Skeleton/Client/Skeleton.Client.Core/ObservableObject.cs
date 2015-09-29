using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Skeleton.Client.Core.Annotations;

namespace Skeleton.Client.Core
{
	public abstract class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value))
			{
				return false;
			}

			field = value;

			OnPropertyChanged(propName);

			return true;
		}

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = Volatile.Read(ref PropertyChanged);

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
