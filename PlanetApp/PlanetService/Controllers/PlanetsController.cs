using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanetService.Models;
using PlanetApp.Common;

namespace PlanetService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlanetsController : ControllerBase
	{
		private IPlanetProvider _provider;

		public PlanetsController(IPlanetProvider provider)
		{
			_provider = provider;
		}

		[HttpGet]
		public IReadOnlyCollection<Planet> Get()
		{
			var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}";
			return _provider.GetPlanets(baseUrl);
		}
	}
}
