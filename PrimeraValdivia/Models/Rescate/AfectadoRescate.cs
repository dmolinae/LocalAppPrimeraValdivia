using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models.Rescate
{
    class AfectadoRescate : ViewModelBase
    {
        private int _idRescate;
        public int idRescate
        {
            get { return _idRescate; }
            set
            {
                _idRescate = value;
                OnPropertyChanged("idRescate");
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
        private string _estado;
        public string estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged("estado");
            }
        }
        private int _fk_idEventoRescate;
        public int fk_idEventoRescate
        {
            get { return _fk_idEventoRescate; }
            set
            {
                _fk_idEventoRescate = value;
                OnPropertyChanged("fk_idEventoRescate");
            }
        }
    }
}
