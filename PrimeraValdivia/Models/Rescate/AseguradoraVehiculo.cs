using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models.Rescate
{
    class AseguradoraVehiculo : ViewModelBase
    {
        private int _idAseguradora_vehiculo;
        public int idAseguradora_vehiculo
        {
            get { return _idAseguradora_vehiculo; }
            set
            {
                _idAseguradora_vehiculo = value;
                OnPropertyChanged("idAseguradora_vehiculo");
            }
        }
        private int _poliza;
        public int poliza
        {
            get { return _poliza; }
            set
            {
                _poliza = value;
                OnPropertyChanged("poliza");
            }
        }
        private int _compania;
        public int compania
        {
            get { return _compania; }
            set
            {
                _compania = value;
                OnPropertyChanged("compania");
            }
        }
        private int _especie;
        public int especie
        {
            get { return _especie; }
            set
            {
                _especie = value;
                OnPropertyChanged("especie");
            }
        }
        private int _fk_idAseguradoraVehiculo;
        public int fk_idAseguradoraVehiculo
        {
            get { return _fk_idAseguradoraVehiculo; }
            set
            {
                _fk_idAseguradoraVehiculo = value;
                OnPropertyChanged("fk_idAseguradoraVehiculo");
            }
        }
    }
}
