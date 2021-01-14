using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanetApp.Common;


namespace PlanetService.Models
{
	public interface IPlanetProvider
	{
		IReadOnlyCollection<Planet> GetPlanets(string baseUrl);
	}
}
