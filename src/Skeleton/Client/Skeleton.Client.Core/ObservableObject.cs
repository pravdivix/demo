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
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = Volatile.Read(ref PropertyChanged);

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
