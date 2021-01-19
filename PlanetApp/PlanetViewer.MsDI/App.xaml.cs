using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PlanetApp.Common;
using PlanetDataReader.Caching;
using PlanetDataReader.Service;
using PlanetViewer.Presentation;

namespace PlanetViewer.MsDI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ComposeObjects();

			Application.Current.MainWindow.Title = "Planet Application";
			Application.Current.MainWindow.Show();
		}

		private static void ComposeObjects()
		{
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddHttpClient("jsonService", client =>
			{
				client.BaseAddress = new Uri("http://localhost:5000/api/");
			});
			serviceCollection.AddTransient<MainWindow>();
			serviceCollection.AddTransient<PlanetViewModel>();
			serviceCollection.AddSingleton<ServiceReader>();
			serviceCollection.AddSingleton<IPlanetReader>(provider => new CachingDecorator(provider.GetRequiredService<ServiceReader>()));

			var provider = serviceCollection.BuildServiceProvider();
			Application.Current.MainWindow = provider.GetService<MainWindow>();
		}
	}
}
