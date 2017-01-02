

using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Models
{
    class AfectadoIncendio : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idAfectado;
		public int idAfectado
		{
			get { return _idAfectado; }
			set
			{
				_idAfectado = value;
				OnPropertyChanged("idAfectado");
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

		private String _tipoAfectado;
		public String tipoAfectado
		{
			get { return _tipoAfectado; }
			set
			{
				_tipoAfectado = value;
				OnPropertyChanged("tipoAfectado");
			}
		}

		private int _numeroAdultos;
		public int numeroAdultos
		{
			get { return _numeroAdultos; }
			set
			{
				_numeroAdultos = value;
				OnPropertyChanged("numeroAdultos");
			}
		}

		private int _numeroNinos;
		public int numeroNinos
		{
			get { return _numeroNinos; }
			set
			{
				_numeroNinos = value;
				OnPropertyChanged("numeroNinos");
			}
		}

		private int _danoVivienda;
		public int danoVivienda
		{
			get { return _danoVivienda; }
			set
			{
				_danoVivienda = value;
				OnPropertyChanged("danoVivienda");
			}
		}

		private int _danoEnseres;
		public int danoEnseres
		{
			get { return _danoEnseres; }
			set
			{
				_danoEnseres = value;
				OnPropertyChanged("danoEnseres");
			}
		}

		private int _superficie;
		public int superficie
		{
			get { return _superficie; }
			set
			{
				_superficie = value;
				OnPropertyChanged("superficie");
			}
		}

		private String _prioridad;
		public String prioridad
		{
			get { return _prioridad; }
			set
			{
				_prioridad = value;
				OnPropertyChanged("prioridad");
			}
		}

		private int _fk_idIncendioAfectado;
		public int fk_idIncendioAfectado
		{
			get { return _fk_idIncendioAfectado; }
			set
			{
				_fk_idIncendioAfectado = value;
				OnPropertyChanged("fk_idIncendioAfectado");
			}
		}


        #endregion

        #region Metodos

        public AfectadoIncendio()
        {

        }

        public AfectadoIncendio(int idAfectado, String nombre, String rut, String tipoAfectado, int numeroAdultos, int numeroNinos, int danoVivienda, int danoEnseres, int superficie, String prioridad, int fk_idIncendioAfectado)
		{
			this.idAfectado = idAfectado;
			this.nombre = nombre;
			this.rut = rut;
			this.tipoAfectado = tipoAfectado;
			this.numeroAdultos = numeroAdultos;
			this.numeroNinos = numeroNinos;
			this.danoVivienda = danoVivienda;
			this.danoEnseres = danoEnseres;
			this.superficie = superficie;
			this.prioridad = prioridad;
			this.fk_idIncendioAfectado = fk_idIncendioAfectado;
		}

        public void AgregarAfectadoIncendio(AfectadoIncendio AfectadoIncendio)
		{
			query = String.Format(
				"INSERT INTO AfectadoIncendio(idAfectado,nombre,rut,tipoAfectado,numeroAdultos,numeroNinos,danoVivienda,danoEnseres,superficie,prioridad,fk_idIncendioAfectado) VALUES({0},'{1}','{2}','{3}',{4},{5},{6},{7},{8},'{9}',{10})",
				AfectadoIncendio.idAfectado,
				AfectadoIncendio.nombre,
				AfectadoIncendio.rut,
				AfectadoIncendio.tipoAfectado,
				AfectadoIncendio.numeroAdultos,
				AfectadoIncendio.numeroNinos,
				AfectadoIncendio.danoVivienda,
				AfectadoIncendio.danoEnseres,
				AfectadoIncendio.superficie,
				AfectadoIncendio.prioridad,
				AfectadoIncendio.fk_idIncendioAfectado
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarAfectadoIncendio(AfectadoIncendio AfectadoIncendio, int idAfectado)
		{
			query = String.Format(
				"UPDATE AfectadoIncendio SET idAfectado = {0}, nombre = '{1}', rut = '{2}', tipoAfectado = '{3}', numeroAdultos = {4}, numeroNinos = {5}, danoVivienda = {6}, danoEnseres = {7}, superficie = {8}, prioridad = '{9}', fk_idIncendioAfectado = {10} WHERE idAfectado = {11}",
				AfectadoIncendio.idAfectado,
				AfectadoIncendio.nombre,
				AfectadoIncendio.rut,
				AfectadoIncendio.tipoAfectado,
				AfectadoIncendio.numeroAdultos,
				AfectadoIncendio.numeroNinos,
				AfectadoIncendio.danoVivienda,
				AfectadoIncendio.danoEnseres,
				AfectadoIncendio.superficie,
				AfectadoIncendio.prioridad,
				AfectadoIncendio.fk_idIncendioAfectado,
				idAfectado
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarAfectadoIncendio(int idAfectado)
		{
			query = String.Format(
				"DELETE FROM AfectadoIncendio WHERE idAfectado = {0}",
				idAfectado);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<AfectadoIncendio> ObtenerAfectadosIncendio(int idIncendio)
        {
            ObservableCollection<AfectadoIncendio> AfectadoIncendios = new ObservableCollection<AfectadoIncendio>();
            query = String.Format(
                "SELECT * FROM AfectadoIncendio WHERE fk_idIncendioAfectado = {0}",
                idIncendio);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                AfectadoIncendio AfectadoIncendio = new AfectadoIncendio(
                    int.Parse(row["idAfectado"].ToString()),
                    row["nombre"].ToString(),
                    row["rut"].ToString(),
                    row["tipoAfectado"].ToString(),
                    int.Parse(row["numeroAdultos"].ToString()),
                    int.Parse(row["numeroNinos"].ToString()),
                    int.Parse(row["danoVivienda"].ToString()),
                    int.Parse(row["danoEnseres"].ToString()),
                    int.Parse(row["superficie"].ToString()),
                    row["prioridad"].ToString(),
                    int.Parse(row["fk_idIncendioAfectado"].ToString())
                );
                AfectadoIncendios.Add(AfectadoIncendio);
            }
            return AfectadoIncendios;
        }

        public ObservableCollection<AfectadoIncendio> ObtenerAfectadoIncendio(int idAfectado)
		{
			ObservableCollection<AfectadoIncendio> AfectadoIncendios = new ObservableCollection<AfectadoIncendio>();
			query = String.Format(
				"SELECT * FROM AfectadoIncendio WHERE idAfectado = {0}",
				idAfectado);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				AfectadoIncendio AfectadoIncendio = new AfectadoIncendio(
					int.Parse(row["idAfectado"].ToString()),
					row["nombre"].ToString(),
					row["rut"].ToString(),
					row["tipoAfectado"].ToString(),
					int.Parse(row["numeroAdultos"].ToString()),
					int.Parse(row["numeroNinos"].ToString()),
					int.Parse(row["danoVivienda"].ToString()),
					int.Parse(row["danoEnseres"].ToString()),
					int.Parse(row["superficie"].ToString()),
					row["prioridad"].ToString(),
					int.Parse(row["fk_idIncendioAfectado"].ToString())
				);
				AfectadoIncendios.Add(AfectadoIncendio);
			}
			return AfectadoIncendios;
		}

        public void IniciarId()
		{
			query = "SELECT * FROM AfectadoIncendio ORDER BY idAfectado DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idAfectado = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





