

using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Models
{
    class AfectadoRescate : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
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

		private String _estado;
		public String estado
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


        #endregion

        #region Metodos

        public AfectadoRescate()
        {

        }

        public AfectadoRescate(int idRescate, String nombre, String rut, String tipoAfectado, String estado, int fk_idEventoRescate)
		{
			this.idRescate = idRescate;
			this.nombre = nombre;
			this.rut = rut;
			this.tipoAfectado = tipoAfectado;
			this.estado = estado;
			this.fk_idEventoRescate = fk_idEventoRescate;
		}

        public void AgregarAfectadoRescate(AfectadoRescate AfectadoRescate)
		{
			query = String.Format(
				"INSERT INTO AfectadoRescate(idRescate,nombre,rut,tipoAfectado,estado,fk_idEventoRescate) VALUES({0},'{1}','{2}','{3}','{4}',{5})",
				AfectadoRescate.idRescate,
				AfectadoRescate.nombre,
				AfectadoRescate.rut,
				AfectadoRescate.tipoAfectado,
				AfectadoRescate.estado,
				AfectadoRescate.fk_idEventoRescate
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarAfectadoRescate(AfectadoRescate AfectadoRescate, int idRescate)
		{
			query = String.Format(
				"UPDATE AfectadoRescate SET idRescate = {0}, nombre = '{1}', rut = '{2}', tipoAfectado = '{3}', estado = '{4}', fk_idEventoRescate = {5} WHERE idRescate = {6}",
				AfectadoRescate.idRescate,
				AfectadoRescate.nombre,
				AfectadoRescate.rut,
				AfectadoRescate.tipoAfectado,
				AfectadoRescate.estado,
				AfectadoRescate.fk_idEventoRescate,
				idRescate
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarAfectadoRescate(int idRescate)
		{
			query = String.Format(
				"DELETE FROM AfectadoRescate WHERE idRescate = {0}",
				idRescate);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<AfectadoRescate> ObtenerAfectadoRescates()
		{
			ObservableCollection<AfectadoRescate> AfectadoRescates = new ObservableCollection<AfectadoRescate>();
			query = " SELECT * FROM AfectadoRescate";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				AfectadoRescate AfectadoRescate = new AfectadoRescate(
					int.Parse(row["idRescate"].ToString()),
					row["nombre"].ToString(),
					row["rut"].ToString(),
					row["tipoAfectado"].ToString(),
					row["estado"].ToString(),
					int.Parse(row["fk_idEventoRescate"].ToString())
				);
				AfectadoRescates.Add(AfectadoRescate);
			}
			return AfectadoRescates;
		}

		public ObservableCollection<AfectadoRescate> ObtenerAfectadoRescate(int idRescate)
		{
			ObservableCollection<AfectadoRescate> AfectadoRescates = new ObservableCollection<AfectadoRescate>();
			query = String.Format(
				"SELECT * FROM AfectadoRescate WHERE idRescate = {0}",
				idRescate);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				AfectadoRescate AfectadoRescate = new AfectadoRescate(
					int.Parse(row["idRescate"].ToString()),
					row["nombre"].ToString(),
					row["rut"].ToString(),
					row["tipoAfectado"].ToString(),
					row["estado"].ToString(),
					int.Parse(row["fk_idEventoRescate"].ToString())
				);
				AfectadoRescates.Add(AfectadoRescate);
			}
			return AfectadoRescates;
		}

        public void IniciarId()
		{
			query = "SELECT * FROM AfectadoRescate ORDER BY idRescate DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idRescate = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





