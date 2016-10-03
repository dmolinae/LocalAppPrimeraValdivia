using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class AseguradoraViviendaAfectado : ViewModelBase
    {
        private int _idaseguradora_afectado;
        public int idaseguradora_afectado
        {
            get { return _idaseguradora_afectado; }
            set
            {
                _idaseguradora_afectado = value;
                OnPropertyChanged("idaseguradora_afectado");
            }
        }
        private string _poliza;
        public string poliza
        {
            get { return _poliza; }
            set
            {
                _poliza = value;
                OnPropertyChanged("poliza");
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
        private string _especie;
        public string especie
        {
            get { return _especie; }
            set
            {
                _especie = value;
                OnPropertyChanged("especie");
            }
        }
        private int _fk_idAfectado;
        public int fk_idAfectado
        {
            get { return _fk_idAfectado; }
            set
            {
                _fk_idAfectado = value;
                OnPropertyChanged("fk_idAfectado");
            }
        }
    }
}
