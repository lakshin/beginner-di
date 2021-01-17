using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetApp.Common;

namespace PlanetDataReader.Caching
{
	public class CachingDecorator : IPlanetReader
	{
		private IPlanetReader _wrappedPlanetReader;
		private TimeSpan _cacheDuration = new TimeSpan(0, 0, 20);

		private IReadOnlyCollection<Planet> _cachedPlanets;
		private DateTime _dataSetDateTime;

		public CachingDecorator(IPlanetReader wrappedPlanetReader)
		{
			_wrappedPlanetReader = wrappedPlanetReader;
		}

		public async Task<IReadOnlyCollection<Planet>> GetPlanets()
		{
			await ValidateCache();
			return _cachedPlanets;		
		}

		#region Private Methods
		private bool IsCacheValid()
		{
			if (_cachedPlanets == null) return false;

			var _cacheAge = DateTime.Now - _dataSetDateTime;
			return _cacheAge < _cacheDuration;
		}

		private void InvalidateCache()
		{
			_dataSetDateTime = DateTime.MinValue;
		}

		private async Task ValidateCache()
		{
			if (IsCacheValid()) return;

			try
			{
				_cachedPlanets = await _wrappedPlanetReader.GetPlanets();
				_dataSetDateTime = DateTime.Now;
			}
			catch
			{
				InvalidateCache();
				throw;
			}
		}
		#endregion
	}
}
