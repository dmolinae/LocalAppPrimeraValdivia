using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PrimeraValdivia.ViewModels;

namespace PrimeraValdivia.Models
{
    class Voluntario : ViewModelBase
    {
        
        #region Atributos

        private String _rut;
        public String rut
        {
            get { return _rut; }
            set
            {
                _rut = value;
                OnPropertyChanged("rut");
            }
        }

        private String _nombre;
        public String nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("nombre");
            }
        }

        private String _fechaNacimiento;
        public String fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                _fechaNacimiento = value;
                OnPropertyChanged("fechaNacimiento");
            }
        }

        private String _ciudadNacimiento;
        public String ciudadNacimiento
        {
            get { return _ciudadNacimiento; }
            set
            {
                _ciudadNacimiento = value;
                OnPropertyChanged("ciudadNacimiento");
            }
        }

        private String _grupoSanguineo;
        public String grupoSanguineo
        {
            get { return _grupoSanguineo; }
            set
            {
                _grupoSanguineo = value;
                OnPropertyChanged("grupoSanguineo");
            }
        }

        private String _profesion;
        public String profesion
        {
            get { return _profesion; }
            set
            {
                _profesion = value;
                OnPropertyChanged("profesion");
            }
        }

        private String _fechaIngreso;
        public String fechaIngreso
        {
            get { return _fechaIngreso; }
            set
            {
                _fechaIngreso = value;
                OnPropertyChanged("fechaIngreso");
            }
        }

        private String _fechaReincorporacion;
        public String fechaReincorporacion
        {
            get { return _fechaReincorporacion; }
            set
            {
                _fechaReincorporacion = value;
                OnPropertyChanged("fechaReincorporacion");
            }
        }

        private String _servicioCompania;
        public String servicioCompania
        {
            get { return _servicioCompania; }
            set
            {
                _servicioCompania = value;
                OnPropertyChanged("servicioCompania");
            }
        }

        private String _servicioMilitar;
        public String servicioMilitar
        {
            get { return _servicioMilitar; }
            set
            {
                _servicioMilitar = value;
                OnPropertyChanged("servicioMilitar");
            }
        }

        private int _insignia;
        public int insignia
        {
            get { return _insignia; }
            set
            {
                _insignia = value;
                OnPropertyChanged("insignia");
            }
        }

        private int _registroCompania;
        public int registroCompania
        {
            get { return _registroCompania; }
            set
            {
                _registroCompania = value;
                OnPropertyChanged("registroCompania");
            }
        }

        private String _cargo;
        public String cargo
        {
            get { return _cargo; }
            set
            {
                _cargo = value;
                OnPropertyChanged("cargo");
            }
        }

        private String _calificacion;
        public String calificacion
        {
            get { return _calificacion; }
            set
            {
                _calificacion = value;
                OnPropertyChanged("calificacion");
            }
        }

        private int _fk_idCompania;
        public int fk_idCompania
        {
            get { return _fk_idCompania; }
            set
            {
                _fk_idCompania = value;
                OnPropertyChanged("fk_idCompania");
            }
        }
        #endregion
    }
}
