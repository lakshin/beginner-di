using PlanetApp.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlanetDataReader.Service
{
	public class ServiceReader: IPlanetReader
	{
		private IHttpClientFactory _clientFactory;
		//private HttpClient client = new HttpClient();
		//private string baseUri = "http://localhost:5000/api/planets";

		public ServiceReader(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<IReadOnlyCollection<Planet>> GetPlanets()
		{
			HttpResponseMessage response = await _clientFactory.CreateClient("jsonService").GetAsync("planets");
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();
			var planets = JsonSerializer.Deserialize<IReadOnlyCollection<Planet>>(responseBody, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			return planets;
		}
	}
}
