using System;
using System.Collections.Generic;
using PlanetApp.Common;

namespace PlanetService.Models
{
	public class StaticPlanetProvider : IPlanetProvider
	{
		public IReadOnlyCollection<Planet> GetPlanets(string baseUrl)
		{
			return new List<Planet> {
				new Planet {Id = 1, Name = "Mercury", ImageUri = $"{baseUrl}/images/mercury.jpg"},
				new Planet {Id = 1, Name = "Venus", ImageUri = $"{baseUrl}/images/venus.jpg"},
				new Planet {Id = 1, Name = "Earth", ImageUri = $"{baseUrl}/images/earth.jpg"}
			};
		}
	}
}
