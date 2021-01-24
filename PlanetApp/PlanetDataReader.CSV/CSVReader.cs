using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetApp.Common;

namespace PlanetDataReader.CSV
{
	public class CSVReader : IPlanetReader
	{
		private ICSVLoader _csvLoader;

		public CSVReader()
		{
			var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}Data/Planets.csv";
			_csvLoader = new CSVLoader(filePath);
		}

		public void SetCSVLoader(ICSVLoader csvLoader)
		{
			_csvLoader = csvLoader;
		}

		public async Task<IReadOnlyCollection<Planet>> GetPlanets()
		{
			var fileData = await _csvLoader.LoadCSV();
			var planets = ParseCSV(fileData);
			return planets;
		}

		private IReadOnlyCollection<Planet> ParseCSV(string csvData)
		{
			var planets = new List<Planet>();
			var lines = csvData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (string line in lines)
			{
				try
				{
					planets.Add(ParsePlanetString(line));
				}
				catch (Exception)
				{
					// Skip the bad record, log it, and move to the next record
					//TODO: good practice to log them
				}
			}
			return planets;
		}

		private Planet ParsePlanetString(string planetData)
		{
			var elements = planetData.Split(',');
			var planet = new Planet
			{
				Id = int.Parse(elements[0]),
				Name = elements[1],
				ImageUri = elements[2]
			};

			return planet;
		}
	}
}
