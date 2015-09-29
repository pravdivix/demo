using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Skeleton.Client.Views;
using Skeleton.Client.ViewModels;
using Microsoft.Practices.Unity;

namespace Skeleton.Client
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			UnityContainer container = new UnityContainer();

			container.RegisterType<MainViewModel>();

			MainWindow window = new MainWindow
			{
				DataContext = container.Resolve<MainViewModel>()
			};

			window.ShowDialog();
		}
	}
}
