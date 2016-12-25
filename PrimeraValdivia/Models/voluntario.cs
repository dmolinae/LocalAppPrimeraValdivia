

using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Voluntario : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idVoluntario;
		public int idVoluntario
		{
			get { return _idVoluntario; }
			set
			{
				_idVoluntario = value;
				OnPropertyChanged("idVoluntario");
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

		private int _nRegistroInterno;
		public int nRegistroInterno
		{
			get { return _nRegistroInterno; }
			set
			{
				_nRegistroInterno = value;
				OnPropertyChanged("nRegistroInterno");
			}
		}

		private int _nRegistroExterno;
		public int nRegistroExterno
		{
			get { return _nRegistroExterno; }
			set
			{
				_nRegistroExterno = value;
				OnPropertyChanged("nRegistroExterno");
			}
		}

		private String _codigoRadial;
		public String codigoRadial
		{
			get { return _codigoRadial; }
			set
			{
				_codigoRadial = value;
				OnPropertyChanged("codigoRadial");
			}
		}

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


        #endregion

        #region Metodos

        public Voluntario()
        {

        }

        public Voluntario(int idVoluntario, String nombre, DateTime fechaNacimiento, String ciudadNacimiento, String grupoSanguineo, String profesion, bool servicioMilitar, int insignia, String cargo, int nRegistroInterno, int nRegistroExterno, String codigoRadial, String rut)
		{
			this.idVoluntario = idVoluntario;
			this.nombre = nombre;
			this.fechaNacimiento = fechaNacimiento;
			this.ciudadNacimiento = ciudadNacimiento;
			this.grupoSanguineo = grupoSanguineo;
			this.profesion = profesion;
			this.servicioMilitar = servicioMilitar;
			this.insignia = insignia;
			this.cargo = cargo;
			this.nRegistroInterno = nRegistroInterno;
			this.nRegistroExterno = nRegistroExterno;
			this.codigoRadial = codigoRadial;
			this.rut = rut;
		}

        public void AgregarVoluntario(Voluntario Voluntario)
		{
			query = String.Format(
				"INSERT INTO Voluntario(idVoluntario,nombre,fechaNacimiento,ciudadNacimiento,grupoSanguineo,profesion,servicioMilitar,insignia,cargo,nRegistroInterno,nRegistroExterno,codigoRadial,rut) VALUES({0},'{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}',{9},{10},'{11}','{12}')",
				Voluntario.idVoluntario,
				Voluntario.nombre,
				Voluntario.fechaNacimiento,
				Voluntario.ciudadNacimiento,
				Voluntario.grupoSanguineo,
				Voluntario.profesion,
				(Voluntario.servicioMilitar)? 1 : 0,
				Voluntario.insignia,
				Voluntario.cargo,
				Voluntario.nRegistroInterno,
				Voluntario.nRegistroExterno,
				Voluntario.codigoRadial,
				Voluntario.rut
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarVoluntario(Voluntario Voluntario, int idVoluntario)
		{
			query = String.Format(
				"UPDATE Voluntario SET idVoluntario = {0}, nombre = '{1}', fechaNacimiento = '{2}', ciudadNacimiento = '{3}', grupoSanguineo = '{4}', profesion = '{5}', servicioMilitar = {6}, insignia = {7}, cargo = '{8}', nRegistroInterno = {9}, nRegistroExterno = {10}, codigoRadial = '{11}', rut = '{12}' WHERE idVoluntario = {13}",
				Voluntario.idVoluntario,
				Voluntario.nombre,
				Voluntario.fechaNacimiento,
				Voluntario.ciudadNacimiento,
				Voluntario.grupoSanguineo,
				Voluntario.profesion,
				(Voluntario.servicioMilitar)? 1 : 0,
				Voluntario.insignia,
				Voluntario.cargo,
				Voluntario.nRegistroInterno,
				Voluntario.nRegistroExterno,
				Voluntario.codigoRadial,
				Voluntario.rut,
				idVoluntario
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarVoluntario(int idVoluntario)
		{
			query = String.Format(
				"DELETE FROM Voluntario WHERE idVoluntario = {0}",
				idVoluntario);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Voluntario> ObtenerVoluntarios()
		{
			ObservableCollection<Voluntario> Voluntarios = new ObservableCollection<Voluntario>();
			query = " SELECT * FROM Voluntario";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Voluntario Voluntario = new Voluntario(
					int.Parse(row["idVoluntario"].ToString()),
					row["nombre"].ToString(),
					DateTime.Parse(row["fechaNacimiento"].ToString()),
					row["ciudadNacimiento"].ToString(),
					row["grupoSanguineo"].ToString(),
					row["profesion"].ToString(),
					bool.Parse(row["servicioMilitar"].ToString()),
					int.Parse(row["insignia"].ToString()),
					row["cargo"].ToString(),
					int.Parse(row["nRegistroInterno"].ToString()),
					int.Parse(row["nRegistroExterno"].ToString()),
					row["codigoRadial"].ToString(),
					row["rut"].ToString()
				);
				Voluntarios.Add(Voluntario);
			}
			return Voluntarios;
		}

		public ObservableCollection<Voluntario> ObtenerVoluntario(String rut)
		{
			ObservableCollection<Voluntario> Voluntarios = new ObservableCollection<Voluntario>();
			query = String.Format(
				"SELECT * FROM Voluntario WHERE rut = '{0}'",
				rut);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Voluntario Voluntario = new Voluntario(
					int.Parse(row["idVoluntario"].ToString()),
					row["nombre"].ToString(),
					DateTime.Parse(row["fechaNacimiento"].ToString()),
					row["ciudadNacimiento"].ToString(),
					row["grupoSanguineo"].ToString(),
					row["profesion"].ToString(),
					bool.Parse(row["servicioMilitar"].ToString()),
					int.Parse(row["insignia"].ToString()),
					row["cargo"].ToString(),
					int.Parse(row["nRegistroInterno"].ToString()),
					int.Parse(row["nRegistroExterno"].ToString()),
					row["codigoRadial"].ToString(),
					row["rut"].ToString()
				);
				Voluntarios.Add(Voluntario);
			}
			return Voluntarios;
		}
        public String ObtenerRutVoluntario(int idVoluntario)
        {
            String var = "";
            query = String.Format(
                "SELECT rut FROM Voluntario WHERE idVoluntario = {0}",
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var = row["rut"].ToString();
            }
            return var;
        }

        public String ObtenerNombreVoluntario(int idVoluntario)
        {
            String var = "";
            query = String.Format(
                "SELECT nombre FROM Voluntario WHERE idVoluntario = {0}",
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var = row["nombre"].ToString();
            }
            return var;
        }

        public String ObtenerCargoVoluntario(int idVoluntario)
        {
            String var = "";
            query = String.Format(
                "SELECT cargo FROM Voluntario WHERE idVoluntario = {0}",
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var = row["cargo"].ToString();
            }
            return var;
        }

        public ObservableCollection<Voluntario> ObtenerVoluntariosSinMarcarAsistencia(int fk_idEvento)
        {
            ObservableCollection<Voluntario> Voluntarios = new ObservableCollection<Voluntario>();
            query = String.Format(
                "SELECT * FROM Voluntario WHERE Voluntario.idVoluntario NOT IN (SELECT Voluntario.idVoluntario FROM Voluntario INNER JOIN Asistencia ON Voluntario.idVoluntario = Asistencia.fk_idVoluntario WHERE Asistencia.fk_idEvento = {0})",
                fk_idEvento);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Voluntario Voluntario = new Voluntario(
                    int.Parse(row["idVoluntario"].ToString()),
                    row["nombre"].ToString(),
                    DateTime.Parse(row["fechaNacimiento"].ToString()),
                    row["ciudadNacimiento"].ToString(),
                    row["grupoSanguineo"].ToString(),
                    row["profesion"].ToString(),
                    bool.Parse(row["servicioMilitar"].ToString()),
                    int.Parse(row["insignia"].ToString()),
                    row["cargo"].ToString(),
                    int.Parse(row["nRegistroInterno"].ToString()),
                    int.Parse(row["nRegistroExterno"].ToString()),
                    row["codigoRadial"].ToString(),
                    row["rut"].ToString()
                );
                Voluntarios.Add(Voluntario);
            }
            return Voluntarios;
        }

        public void IniciarId()
		{
			query = "SELECT * FROM Voluntario ORDER BY idVoluntario DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idVoluntario = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





