

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

		private int _fk_idVoluntario;
		public int fk_idVoluntario
		{
			get { return _fk_idVoluntario; }
			set
			{
				_fk_idVoluntario = value;
				OnPropertyChanged("fk_idVoluntario");
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

		private String _codigoAsistencia;
		public String codigoAsistencia
		{
			get { return _codigoAsistencia; }
			set
			{
				_codigoAsistencia = value;
				OnPropertyChanged("codigoAsistencia");
			}
		}

		private bool _asistenciaObligatoria;
		public bool asistenciaObligatoria
		{
			get { return _asistenciaObligatoria; }
			set
			{
				_asistenciaObligatoria = value;
				OnPropertyChanged("asistenciaObligatoria");
			}
		}


        #endregion

        #region Metodos

        public Asistencia()
        {

        }

        public Asistencia(int idAsistencia, int fk_idVoluntario, int fk_idEvento, String codigoAsistencia, bool asistenciaObligatoria)
		{
			this.idAsistencia = idAsistencia;
			this.fk_idVoluntario = fk_idVoluntario;
			this.fk_idEvento = fk_idEvento;
			this.codigoAsistencia = codigoAsistencia;
			this.asistenciaObligatoria = asistenciaObligatoria;
		}

        public void AgregarAsistencia(Asistencia Asistencia)
		{
			query = String.Format(
				"INSERT INTO Asistencia(idAsistencia,fk_idVoluntario,fk_idEvento,codigoAsistencia,asistenciaObligatoria) VALUES({0},{1},{2},'{3}',{4})",
				Asistencia.idAsistencia,
				Asistencia.fk_idVoluntario,
				Asistencia.fk_idEvento,
				Asistencia.codigoAsistencia,
				(Asistencia.asistenciaObligatoria)? 1 : 0
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarAsistencia(Asistencia Asistencia, int idAsistencia)
		{
			query = String.Format(
				"UPDATE Asistencia SET idAsistencia = {0}, fk_idVoluntario = {1}, fk_idEvento = {2}, codigoAsistencia = '{3}', asistenciaObligatoria = {4} WHERE idAsistencia = {5}",
				Asistencia.idAsistencia,
				Asistencia.fk_idVoluntario,
				Asistencia.fk_idEvento,
				Asistencia.codigoAsistencia,
				(Asistencia.asistenciaObligatoria)? 1 : 0,
				idAsistencia
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarAsistencia(int idAsistencia)
		{
			query = String.Format(
				"DELETE FROM Asistencia WHERE idAsistencia = {0}",
				idAsistencia);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Asistencia> ObtenerAsistencias()
		{
			ObservableCollection<Asistencia> Asistencias = new ObservableCollection<Asistencia>();
			query = " SELECT * FROM Asistencia";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Asistencia Asistencia = new Asistencia(
					int.Parse(row["idAsistencia"].ToString()),
					int.Parse(row["fk_idVoluntario"].ToString()),
					int.Parse(row["fk_idEvento"].ToString()),
					row["codigoAsistencia"].ToString(),
					bool.Parse(row["asistenciaObligatoria"].ToString())
				);
				Asistencias.Add(Asistencia);
			}
			return Asistencias;
		}

		public ObservableCollection<Asistencia> ObtenerAsistencia(int idAsistencia)
		{
			ObservableCollection<Asistencia> Asistencias = new ObservableCollection<Asistencia>();
			query = String.Format(
				"SELECT * FROM Asistencia WHERE idAsistencia = {0}",
				idAsistencia);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Asistencia Asistencia = new Asistencia(
					int.Parse(row["idAsistencia"].ToString()),
					int.Parse(row["fk_idVoluntario"].ToString()),
					int.Parse(row["fk_idEvento"].ToString()),
					row["codigoAsistencia"].ToString(),
					bool.Parse(row["asistenciaObligatoria"].ToString())
				);
				Asistencias.Add(Asistencia);
			}
			return Asistencias;
		}

        public void IniciarId()
		{
			query = "SELECT * FROM Asistencia ORDER BY idAsistencia DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idAsistencia = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





