using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Asistencia : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos

        private int _idAsistencia;
        public int idAsistencia
        {
            get { return _idAsistencia; }
            set
            {
                _idAsistencia = value;
                OnPropertyChanged("idAsistencia");
            }
        }

        private int _fk_rut;
        public int fk_rut
        {
            get { return _fk_rut; }
            set
            {
                _fk_rut = value;
                OnPropertyChanged("fk_rut");
            }
        }
        private int _fk_idEvento;
        public int fk_idEvento
        {
            get { return _fk_idEvento; }
            set
            {
                _fk_idEvento = value;
                OnPropertyChanged("fk_idEvento");
            }
        }
        private int _codigoAsistencia;
        public int codigoAsistencia
        {
            get { return _codigoAsistencia; }
            set
            {
                _codigoAsistencia = value;
                OnPropertyChanged("codigoAsistencia");
            }
        }
        private int _asistenciaObligatoria;
        public int asistenciaObligatoria
        {
            get { return _asistenciaObligatoria; }
            set
            {
                _asistenciaObligatoria = value;
                OnPropertyChanged("asistenciaObligatoria");
            }
        }

        #endregion
    }
}
