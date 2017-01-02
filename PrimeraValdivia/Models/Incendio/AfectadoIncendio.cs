using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class AfectadoIncendio : ViewModelBase
    {
        private int _idAfectado;
        public int idAfectado
        {
            get { return _idAfectado; }
            set
            {
                _idAfectado = value;
                OnPropertyChanged("idAfectado");
            }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("nombre");
            }
        }
        private string _rut;
        public string rut
        {
            get { return _rut; }
            set
            {
                _rut = value;
                OnPropertyChanged("rut");
            }
        }
        private string _tipoAfectado;
        public string tipoAfectado
        {
            get { return _tipoAfectado; }
            set
            {
                _tipoAfectado = value;
                OnPropertyChanged("tipoAfectado");
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
        private int _danoVivienda;
        public int danoVivienda
        {
            get { return _danoVivienda; }
            set
            {
                _danoVivienda = value;
                OnPropertyChanged("danoVivienda");
            }
        }
        private int _danoEnseres;
        public int danoEnseres
        {
            get { return _danoEnseres; }
            set
            {
                _danoEnseres = value;
                OnPropertyChanged("danoEnseres");
            }
        }
        private int _superficie;
        public int superficie
        {
            get { return _superficie; }
            set
            {
                _superficie = value;
                OnPropertyChanged("superficie");
            }
        }
        private int _fk_idIncendioAfectado;
        public int fk_idIncendioAfectado
        {
            get { return _fk_idIncendioAfectado; }
            set
            {
                _fk_idIncendioAfectado = value;
                OnPropertyChanged("fk_idIncendioAfectado");
            }
        }
    }
}
