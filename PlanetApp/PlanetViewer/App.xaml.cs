using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PlanetDataReader.Service;
using PlanetViewer.Presentation;

namespace PlanetViewer
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
			var reader = new ServiceReader();
			var viewModel = new PlanetViewModel(reader);
			Application.Current.MainWindow = new MainWindow(viewModel);
		}
	}
}
