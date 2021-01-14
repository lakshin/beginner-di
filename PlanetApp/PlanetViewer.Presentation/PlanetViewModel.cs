using PlanetApp.Common;
using PlanetDataReader.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlanetViewer.Presentation
{
	public class PlanetViewModel: INotifyPropertyChanged
	{
		private ServiceReader _dataReader;

		private IReadOnlyCollection<Planet> _planets;

        public IReadOnlyCollection<Planet> Planets
        {
            get { return _planets; }
            set
            {
                if (_planets == value)
                    return;
                _planets = value;
                RaisePropertyChanged();
            }
        }

        public string DataReaderType
        {
            get { return _dataReader.GetType().ToString(); }
        }

        public PlanetViewModel()
        {
            _dataReader = new ServiceReader();
        }

        public async GetPlanets()
        {
            Planets = await _dataReader.GetPlanets();
        }

        public void Clear()
        {
            Planets = new List<Planet>();
        }
               

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
