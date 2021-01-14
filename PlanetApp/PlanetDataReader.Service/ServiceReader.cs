using PlanetApp.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace PlanetDataReader.Service
{
	public class ServiceReader
	{
		HttpClient client = new HttpClient();
		string baseUri = "http://localhost:49301/api/planets";

		public async Task<IReadOnlyCollection<Planet>> GetPlanets()
		{
			HttpResponseMessage response = await client.GetAsync(baseUri);
			response.EnsureSuccessStatusCode();
			var responseBody = await response.Content.ReadAsStringAsync();
			var planets = JsonSerializer.Deserialize<IReadOnlyCollection<Planet>>(responseBody);
			return planets;
		}
	}
}
