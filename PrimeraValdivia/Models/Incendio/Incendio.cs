using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Incendio : ViewModelBase
    {
        private int _idIncendio;
        public int idIncendio
        {
            get { return _idIncendio; }
            set
            {
                _idIncendio = value;
                OnPropertyChanged("idIncendio");
            }
        }
        private string _tipoIncendio;
        public string tipoIncendio
        {
            get { return _tipoIncendio; }
            set
            {
                _tipoIncendio = value;
                OnPropertyChanged("tipoIncendio");
            }
        }
        private string _faseIncendio;
        public string faseIncendio
        {
            get { return _faseIncendio; }
            set
            {
                _faseIncendio = value;
                OnPropertyChanged("faseIncendio");
            }
        }
        private bool _det;
        public bool det
        {
            get { return _det; }
            set
            {
                _det = value;
                OnPropertyChanged("det");
            }
        }
        private string _bomberoDet;
        public string bomberoDet
        {
            get { return _bomberoDet; }
            set
            {
                _bomberoDet = value;
                OnPropertyChanged("bomberoDet");
            }
        }
        private string _origen;
        public string origen
        {
            get { return _origen; }
            set
            {
                _origen = value;
                OnPropertyChanged("origen");
            }
        }
        private string _causa;
        public string causa
        {
            get { return _causa; }
            set
            {
                _causa = value;
                OnPropertyChanged("causa");
            }
        }
        private string _fuenteCalor;
        public string fuenteCalor
        {
            get { return _fuenteCalor; }
            set
            {
                _fuenteCalor = value;
                OnPropertyChanged("fuenteCalor");
            }
        }
        private string _tipoLugar;
        public string tipoLugar
        {
            get { return _tipoLugar; }
            set
            {
                _tipoLugar = value;
                OnPropertyChanged("tipoLugar");
            }
        }
        private string _tipoConstruccion;
        public string tipoConstruccion
        {
            get { return _tipoConstruccion; }
            set
            {
                _tipoConstruccion = value;
                OnPropertyChanged("tipoConstruccion");
            }
        }
        private int _fk_idEventoInc;
        public int fk_idEventoInc
        {
            get { return _fk_idEventoInc; }
            set
            {
                _fk_idEventoInc = value;
                OnPropertyChanged("fk_idEventoInc");
            }
        }
    }
}
