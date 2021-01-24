using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlanetViewer.Presentation.Tests
{
	[TestClass]
	public class PlanetViewModelUnitTests
	{
		[TestMethod]
		public async Task Planet_OnGet_IsPopulated()
		{
			//Arrange
			var fakeReader = new FakeReader();
			var viewModel = new PlanetViewModel(fakeReader);

			//Act
			await viewModel.GetPlanets();

			//Assert
			Assert.IsNotNull(viewModel.Planets, "Planets is null in view model");
			Assert.AreEqual(3, viewModel.Planets.Count, "Planets count is incorrect");
		}

		[TestMethod]
		public async Task Planet_OnClear_IsEmpty()
		{
			//Arrange
			var fakeReader = new FakeReader();
			var viewModel = new PlanetViewModel(fakeReader);
			await viewModel.GetPlanets();
			Assert.AreEqual(3, viewModel.Planets.Count, "Arrange Failure");

			//Act
			viewModel.Clear();

			//Assert
			Assert.AreEqual(0, viewModel.Planets.Count, "Planets have not been cleared");
		}
	}
}
