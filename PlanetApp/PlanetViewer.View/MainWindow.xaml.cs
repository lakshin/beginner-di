using PlanetViewer.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanetViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private PlanetViewModel _viewModel;

		public MainWindow(PlanetViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			this.DataContext = _viewModel;
		}

		private async void LoadButton_Click(object sender, RoutedEventArgs e)
		{
			await _viewModel.GetPlanets();
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			_viewModel.Clear();
		}
	}
}
