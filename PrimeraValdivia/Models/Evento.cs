using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Evento : ViewModelBase
    {
        #region Atributos

        private int _idEvento;
        public int idEvento
        {
            get { return _idEvento; }
            set
            {
                _idEvento = value;
                OnPropertyChanged("idEvento");
            }
        }

        private string _correlativoLlamado;
        public string correlativoLlamado
        {
            get { return _correlativoLlamado; }
            set
            {
                _correlativoLlamado = value;
                OnPropertyChanged("correlativoLlamado");
            }
        }
        private string _correlativoCBV;
        public string correlativoCBV
        {
            get { return _correlativoCBV; }
            set
            {
                _correlativoCBV = value;
                OnPropertyChanged("correlativoCBV");
            }
        }
        private string _claveServicio;
        public string claveServicio
        {
            get { return _claveServicio; }
            set
            {
                _claveServicio = value;
                OnPropertyChanged("claveServicio");
            }
        }
        private string _fecha;
        public string fecha
        {
            get { return _fecha; }
            set
            {
                _fecha = value;
                OnPropertyChanged("fecha");
            }
        }
        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set
            {
                _motivo = value;
                OnPropertyChanged("motivo");
            }
        }
        private string _calle;
        public string calle
        {
            get { return _calle; }
            set
            {
                _calle = value;
                OnPropertyChanged("calle");
            }
        }
        private string _numeroCalle;
        public string numeroCalle
        {
            get { return _numeroCalle; }
            set
            {
                _numeroCalle = value;
                OnPropertyChanged("numeroCalle");
            }
        }
        private string _calleProxima;
        public string calleProxima
        {
            get { return _calleProxima; }
            set
            {
                _calleProxima = value;
                OnPropertyChanged("calleProxima");
            }
        }
        private string _sector;
        public string sector
        {
            get { return _sector; }
            set
            {
                _sector = value;
                OnPropertyChanged("sector");
            }
        }
        private string _poblacion;
        public string poblacion
        {
            get { return _poblacion; }
            set
            {
                _poblacion = value;
                OnPropertyChanged("poblacion");
            }
        }
        private string _ruta;
        public string ruta
        {
            get { return _ruta; }
            set
            {
                _ruta = value;
                OnPropertyChanged("ruta");
            }
        }
        private string _kilometroRuta;
        public string kilometroRuta
        {
            get { return _kilometroRuta; }
            set
            {
                _kilometroRuta = value;
                OnPropertyChanged("kilometroRuta");
            }
        }
        private string _bomberoCargo;
        public string bomberoCargo
        {
            get { return _bomberoCargo; }
            set
            {
                _bomberoCargo = value;
                OnPropertyChanged("bomberoCargo");
            }
        }
        private string _bomberoInforme;
        public string bomberoInforme
        {
            get { return _bomberoInforme; }
            set
            {
                _bomberoInforme = value;
                OnPropertyChanged("bomberoInforme");
            }
        }
        private string _codigoCargo;
        public string codigoCargo
        {
            get { return _codigoCargo; }
            set
            {
                _codigoCargo = value;
                OnPropertyChanged("codigoCargo");
            }
        }
        private string _codigoInforme;
        public string codigoInforme
        {
            get { return _codigoInforme; }
            set
            {
                _codigoInforme = value;
                OnPropertyChanged("codigoInforme");
            }
        }
        private string _numeroDepartamento;
        public string numeroDepartamento
        {
            get { return _numeroDepartamento; }
            set
            {
                _numeroDepartamento = value;
                OnPropertyChanged("numeroDepartamento");
            }
        }
        private string _numeroBlock;
        public string numeroBlock
        {
            get { return _numeroBlock; }
            set
            {
                _numeroBlock = value;
                OnPropertyChanged("numeroBlock");
            }
        }
        private string _resumen;
        public string resumen
        {
            get { return _resumen; }
            set
            {
                _resumen = value;
                OnPropertyChanged("resumen");
            }
        }
        #endregion

    }
}
