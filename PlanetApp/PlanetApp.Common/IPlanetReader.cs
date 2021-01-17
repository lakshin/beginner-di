using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanetApp.Common
{
	public interface IPlanetReader
	{
		Task<IReadOnlyCollection<Planet>> GetPlanets();
	}
}
