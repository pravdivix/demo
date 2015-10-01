using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Practices.Unity;
using Skeleton.Client.Models;
using Skeleton.Client.ViewModels;
using Skeleton.Client.Views;

namespace Skeleton.Client
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
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
