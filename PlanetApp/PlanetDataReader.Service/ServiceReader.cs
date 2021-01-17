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
		private HttpClient client = new HttpClient();
		private string baseUri = "http://localhost:49301/api/planets";

		public async Task<IReadOnlyCollection<Planet>> GetPlanets()
		{
			HttpResponseMessage response = await client.GetAsync(baseUri);
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
