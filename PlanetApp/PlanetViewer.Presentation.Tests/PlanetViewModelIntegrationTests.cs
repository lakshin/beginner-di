using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlanetDataReader.CSV;

namespace PlanetViewer.Presentation.Tests
{
	[TestClass]
	public class PlanetViewModelIntegrationTests
	{
		[TestMethod]
		public async Task Planet_OnGet_IsPopulated()
		{
			//Arrange
			var mock = new Mock<ICSVLoader>();
			mock.Setup(loader => loader.LoadCSV()).ReturnsAsync($"4,Mars,http://localhost:5000/images/mars.jpg {Environment.NewLine} 5,Jupiter,http://localhost:5000/images/jupiter.jpg");

			var csvReader = new CSVReader();
			csvReader.SetCSVLoader(mock.Object);

			var viewModel = new PlanetViewModel(csvReader);

			//Act
			await viewModel.GetPlanets();

			//Assert
			Assert.IsNotNull(viewModel.Planets, "Planets is null in view model");
			Assert.AreEqual(2, viewModel.Planets.Count, "Planets count is incorrect");
		}
	}
}
