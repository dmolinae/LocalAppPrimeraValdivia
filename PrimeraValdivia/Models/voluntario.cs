using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PrimeraValdivia.ViewModels;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Models
{
    class Voluntario : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

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

        private DateTime _fechaNacimiento;
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                
                _fechaNacimiento = value;
                OnPropertyChanged("fechaNacimiento");
                Debug.Write(_fechaNacimiento);
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

        private DateTime _fechaIngreso = DateTime.Now;
        public DateTime fechaIngreso
        {
            get { return _fechaIngreso; }
            set
            {
                _fechaIngreso = value;
                OnPropertyChanged("fechaIngreso");
            }
        }

        private DateTime _fechaReincorporacion = DateTime.Now;
        public DateTime fechaReincorporacion
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

        private bool _servicioMilitar;
        public bool servicioMilitar
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

        #region Métodos
        public Voluntario()
        {

        }
        public Voluntario(string rut, string nombre, DateTime fechaNacimiento, string ciudadNacimiento, string grupoSanguineo, string profesion, DateTime fechaIngreso, DateTime fechaReincorporacion, string servicioCompania, bool servicioMilitar, int insignia, int registroCompania, string cargo, string calificacion, int fk_idCompania)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.ciudadNacimiento = ciudadNacimiento;
            this.grupoSanguineo = grupoSanguineo;
            this.profesion = profesion;
            this.fechaIngreso = fechaIngreso;
            this.fechaReincorporacion = fechaReincorporacion;
            this.servicioCompania = servicioCompania;
            this.servicioMilitar = servicioMilitar;
            this.insignia = insignia;
            this.registroCompania = registroCompania;
            this.cargo = cargo;
            this.calificacion = calificacion;
            this.fk_idCompania = fk_idCompania;
        }

        public void AgregarVoluntario(Voluntario Voluntario)
        {
            query = String.Format(
                "INSERT INTO Voluntario values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},'{12}','{13}',{14})",
                Voluntario.rut,
                Voluntario.nombre,
                Voluntario.fechaNacimiento,
                Voluntario.ciudadNacimiento,
                Voluntario.grupoSanguineo,
                Voluntario.profesion,
                Voluntario.fechaIngreso,
                Voluntario.fechaReincorporacion,
                Voluntario.servicioCompania,
                (Voluntario.servicioMilitar)? 1 : 0,
                Voluntario.insignia,
                Voluntario.registroCompania,
                Voluntario.cargo,
                Voluntario.calificacion,
                Voluntario.fk_idCompania
                );
            utils.ExecuteNonQuery(query);
        }

        public ObservableCollection<Voluntario> ObtenerVoluntarios()
        {
            ObservableCollection<Voluntario> Voluntarios = new ObservableCollection<Voluntario>();
            query = "SELECT * FROM Voluntario";
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Voluntario voluntarioActual = new Voluntario(
                    row["rut"].ToString(),
                    row["nombre"].ToString(),
                    DateTime.Parse(row["fechaNacimiento"].ToString()),
                    row["ciudadNacimiento"].ToString(),
                    row["grupoSanguineo"].ToString(),
                    row["profesion"].ToString(),
                    DateTime.Parse(row["fechaIngreso"].ToString()),
                    DateTime.Parse(row["fechaReincorporacion"].ToString()),
                    row["servicioCompañia"].ToString(),
                    bool.Parse(row["servicioMilitar"].ToString()),
                    int.Parse(row["insignia"].ToString()),
                    int.Parse(row["registroCompañia"].ToString()),
                    row["cargo"].ToString(),
                    row["calificacion"].ToString(),
                    int.Parse(row["fk_idCompañia"].ToString())
                    );
                Voluntarios.Add(voluntarioActual);
            }
            return Voluntarios;
        }

        #endregion
    }
}
