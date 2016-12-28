

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
    class Apoyo : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idApoyo;
		public int idApoyo
		{
			get { return _idApoyo; }
			set
			{
				_idApoyo = value;
				OnPropertyChanged("idApoyo");
			}
		}

		private String _tipo;
		public String tipo
		{
			get { return _tipo; }
			set
			{
				_tipo = value;
				OnPropertyChanged("tipo");
			}
		}

		private String _procedencia;
		public String procedencia
		{
			get { return _procedencia; }
			set
			{
				_procedencia = value;
				OnPropertyChanged("procedencia");
			}
		}

		private String _personaCargo;
		public String personaCargo
		{
			get { return _personaCargo; }
			set
			{
				_personaCargo = value;
				OnPropertyChanged("personaCargo");
			}
		}

		private String _rango;
		public String rango
		{
			get { return _rango; }
			set
			{
				_rango = value;
				OnPropertyChanged("rango");
			}
		}

		private String _patente;
		public String patente
		{
			get { return _patente; }
			set
			{
				_patente = value;
				OnPropertyChanged("patente");
			}
		}

		private String _compania;
		public String compania
		{
			get { return _compania; }
			set
			{
				_compania = value;
				OnPropertyChanged("compania");
			}
		}

		private String _municipalidad;
		public String municipalidad
		{
			get { return _municipalidad; }
			set
			{
				_municipalidad = value;
				OnPropertyChanged("municipalidad");
			}
		}

		private int _fk_idEventoApoyo;
		public int fk_idEventoApoyo
		{
			get { return _fk_idEventoApoyo; }
			set
			{
				_fk_idEventoApoyo = value;
				OnPropertyChanged("fk_idEventoApoyo");
			}
		}


        #endregion

        #region Metodos

        public Apoyo()
        {

        }

        public Apoyo(int idApoyo, String tipo, String procedencia, String personaCargo, String rango, String patente, String compania, String municipalidad, int fk_idEventoApoyo)
		{
			this.idApoyo = idApoyo;
			this.tipo = tipo;
			this.procedencia = procedencia;
			this.personaCargo = personaCargo;
			this.rango = rango;
			this.patente = patente;
			this.compania = compania;
			this.municipalidad = municipalidad;
			this.fk_idEventoApoyo = fk_idEventoApoyo;
		}

        public void AgregarApoyo(Apoyo Apoyo)
		{
			query = String.Format(
				"INSERT INTO Apoyo(idApoyo,tipo,procedencia,personaCargo,rango,patente,compania,municipalidad,fk_idEventoApoyo) VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})",
				Apoyo.idApoyo,
				Apoyo.tipo,
				Apoyo.procedencia,
				Apoyo.personaCargo,
				Apoyo.rango,
				Apoyo.patente,
				Apoyo.compania,
				Apoyo.municipalidad,
				Apoyo.fk_idEventoApoyo
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarApoyo(Apoyo Apoyo, int idApoyo)
		{
			query = String.Format(
				"UPDATE Apoyo SET idApoyo = {0}, tipo = '{1}', procedencia = '{2}', personaCargo = '{3}', rango = '{4}', patente = '{5}', compania = '{6}', municipalidad = '{7}', fk_idEventoApoyo = {8} WHERE idApoyo = {9}",
				Apoyo.idApoyo,
				Apoyo.tipo,
				Apoyo.procedencia,
				Apoyo.personaCargo,
				Apoyo.rango,
				Apoyo.patente,
				Apoyo.compania,
				Apoyo.municipalidad,
				Apoyo.fk_idEventoApoyo,
				idApoyo
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarApoyo(int idApoyo)
		{
			query = String.Format(
				"DELETE FROM Apoyo WHERE idApoyo = {0}",
				idApoyo);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Apoyo> ObtenerApoyos()
		{
			ObservableCollection<Apoyo> Apoyos = new ObservableCollection<Apoyo>();
			query = " SELECT * FROM Apoyo";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Apoyo Apoyo = new Apoyo(
					int.Parse(row["idApoyo"].ToString()),
					row["tipo"].ToString(),
					row["procedencia"].ToString(),
					row["personaCargo"].ToString(),
					row["rango"].ToString(),
					row["patente"].ToString(),
					row["compania"].ToString(),
					row["municipalidad"].ToString(),
					int.Parse(row["fk_idEventoApoyo"].ToString())
				);
				Apoyos.Add(Apoyo);
			}
			return Apoyos;
		}

		public ObservableCollection<Apoyo> ObtenerApoyo(int idApoyo)
		{
			ObservableCollection<Apoyo> Apoyos = new ObservableCollection<Apoyo>();
			query = String.Format(
				"SELECT * FROM Apoyo WHERE idApoyo = {0}",
				idApoyo);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Apoyo Apoyo = new Apoyo(
					int.Parse(row["idApoyo"].ToString()),
					row["tipo"].ToString(),
					row["procedencia"].ToString(),
					row["personaCargo"].ToString(),
					row["rango"].ToString(),
					row["patente"].ToString(),
					row["compania"].ToString(),
					row["municipalidad"].ToString(),
					int.Parse(row["fk_idEventoApoyo"].ToString())
				);
				Apoyos.Add(Apoyo);
			}
			return Apoyos;
		}

        public void IniciarId()
		{
			query = "SELECT * FROM Apoyo ORDER BY idApoyo DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idApoyo = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





