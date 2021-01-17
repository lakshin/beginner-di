using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanetDataReader.CSV
{
	public interface ICSVLoader
	{
		Task<string> LoadCSV();
	}
}
