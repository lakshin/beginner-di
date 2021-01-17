using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDataReader.CSV
{
	public class CSVLoader : ICSVLoader
	{
		private string _csvPath;

		public CSVLoader(string csvPath)
		{
			if (string.IsNullOrEmpty(csvPath)) throw new ArgumentNullException(nameof(csvPath));
			_csvPath = csvPath;
		}

		public async Task<string> LoadCSV()
		{
			using (var reader = new StreamReader(_csvPath))
			{
				return await reader.ReadToEndAsync();
			}
		}
	}
}
