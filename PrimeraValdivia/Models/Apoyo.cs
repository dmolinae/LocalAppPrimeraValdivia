using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Apoyo : ViewModelBase
    {
        private int _idApoyo;
        public int idApoyo
        {
            get { return _idApoyo; }
            set
            {
                _idApoyo = value;
                OnPropertyChanged("idApoyo");
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
        private string _procedencia;
        public string procedencia
        {
            get { return _procedencia; }
            set
            {
                _procedencia = value;
                OnPropertyChanged("procedencia");
            }
        }
        private string _personaCargo;
        public string personaCargo
        {
            get { return _personaCargo; }
            set
            {
                _personaCargo = value;
                OnPropertyChanged("personaCargo");
            }
        }
        private string _rango;
        public string rango
        {
            get { return _rango; }
            set
            {
                _rango = value;
                OnPropertyChanged("rango");
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
        private string _compania;
        public string compania
        {
            get { return _compania; }
            set
            {
                _compania = value;
                OnPropertyChanged("compania");
            }
        }
        private string _municipalidad;
        public string municipalidad
        {
            get { return _municipalidad; }
            set
            {
                _municipalidad = value;
                OnPropertyChanged("municipalidad");
            }
        }
        private int _fk_idEventoApoyo;
        public int fk_idEventoApoyo
        {
            get { return _fk_idEventoApoyo; }
            set
            {
                _fk_idEventoApoyo = value;
                OnPropertyChanged("fk_idEventoApoyo");
            }
        }
    }
}
