using System.Windows;
using Skeleton.SimpleAsyncDemo.ViewModels;
using Skeleton.SimpleAsyncDemo.Views;

namespace Skeleton.SimpleAsyncDemo
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainWindow mainWindow = new MainWindow
			{
				DataContext = new MainViewModel()
			};

			mainWindow.ShowDialog();
		}
	}
}
