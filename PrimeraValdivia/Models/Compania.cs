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
