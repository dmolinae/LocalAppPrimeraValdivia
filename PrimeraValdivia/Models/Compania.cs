using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrimeraValdivia.Models
{
    class Compania : INotifyPropertyChanged
    {
        
        private int _idCompania;
        public int idCompania
        {
            get { return _idCompania; }
            set
            {
                _idCompania = value;
                OnPropertyChanged("idCompania");
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
        private string _clave;
        public string clave
        {
            get { return _clave; }
            set
            {
                _clave = value;
                OnPropertyChanged("clave");
            }
        }

        private string _nombreCompania;
        public string nombreCompania
        {
            get { return _nombreCompania; }
            set
            {
                _nombreCompania = value;
                OnPropertyChanged("nombre");
            }
        }

        private string _calle;
        public string calle
        {
            get { return _calle; }
            set
            {
                _calle = value;
                OnPropertyChanged("nombre");
            }
        }

        private string _numeroCalle;
        public string numeroCalle
        {
            get { return _numeroCalle; }
            set
            {
                _numeroCalle = value;
                OnPropertyChanged("nombre");
            }
        }

        private string _ciudad;
        public string ciudad
        {
            get { return _ciudad; }
            set
            {
                _ciudad = value;
                OnPropertyChanged("nombre");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
