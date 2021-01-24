using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlanetApp.Common;

namespace PlanetViewer.Presentation.Tests
{
	public class FakeReader : IPlanetReader
	{
		public Task<IReadOnlyCollection<Planet>> GetPlanets()
		{
			var baseUrl = "";

			return Task.FromResult(new List<Planet> {
				new Planet {Id = 1, Name = "Mercury", ImageUri = $"{baseUrl}/images/mercury.jpg"},
				new Planet {Id = 2, Name = "Venus", ImageUri = $"{baseUrl}/images/venus.jpg"},
				new Planet {Id = 3, Name = "Earth", ImageUri = $"{baseUrl}/images/earth.jpg"}
			} as IReadOnlyCollection<Planet>);
		}
	}
}
