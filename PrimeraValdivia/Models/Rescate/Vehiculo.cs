using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models.Rescate
{
    class Vehiculo : ViewModelBase
    {
        private int _idVehiculo;
        public int idVehiculo
        {
            get { return _idVehiculo; }
            set
            {
                _idVehiculo = value;
                OnPropertyChanged("idVehiculo");
            }
        }
        private string _tipo;
        public string tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
                OnPropertyChanged("tipo");
            }
        }
        private string _marca;
        public string marca
        {
            get { return _marca; }
            set
            {
                _marca = value;
                OnPropertyChanged("marca");
            }
        }
        private string _modelo;
        public string modelo
        {
            get { return _modelo; }
            set
            {
                _modelo = value;
                OnPropertyChanged("modelo");
            }
        }
        private string _patente;
        public string patente
        {
            get { return _patente; }
            set
            {
                _patente = value;
                OnPropertyChanged("patente");
            }
        }
        private string _dano;
        public string dano
        {
            get { return _dano; }
            set
            {
                _dano = value;
                OnPropertyChanged("dano");
            }
        }
        private int _numeroAdultos;
        public int numeroAdultos
        {
            get { return _numeroAdultos; }
            set
            {
                _numeroAdultos = value;
                OnPropertyChanged("numeroAdultos");
            }
        }
        private int _numeroNinos;
        public int numeroNinos
        {
            get { return _numeroNinos; }
            set
            {
                _numeroNinos = value;
                OnPropertyChanged("numeroNinos");
            }
        }
        private int _fk_idRescate;
        public int fk_idRescate
        {
            get { return _fk_idRescate; }
            set
            {
                _fk_idRescate = value;
                OnPropertyChanged("fk_idRescate");
            }
        }
    }
}
