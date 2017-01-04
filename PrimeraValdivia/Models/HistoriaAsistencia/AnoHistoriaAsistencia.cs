

using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Models
{
    class AnoHistoriaAsistencia : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idAnoHistoriaAsistencia;
		public int idAnoHistoriaAsistencia
		{
			get { return _idAnoHistoriaAsistencia; }
			set
			{
				_idAnoHistoriaAsistencia = value;
				OnPropertyChanged("idAnoHistoriaAsistencia");
			}
		}

		private int _ano;
		public int ano
		{
			get { return _ano; }
			set
			{
				_ano = value;
				OnPropertyChanged("ano");
			}
		}

		private int _fk_idVoluntarioH;
		public int fk_idVoluntarioH
		{
			get { return _fk_idVoluntarioH; }
			set
			{
				_fk_idVoluntarioH = value;
				OnPropertyChanged("fk_idVoluntarioH");
			}
		}


        #endregion

        #region Metodos

        public AnoHistoriaAsistencia()
        {

        }

        public AnoHistoriaAsistencia(int idAnoHistoriaAsistencia, int ano, int fk_idVoluntarioH)
		{
			this.idAnoHistoriaAsistencia = idAnoHistoriaAsistencia;
			this.ano = ano;
			this.fk_idVoluntarioH = fk_idVoluntarioH;
		}

        public int AgregarAnoHistoriaAsistencia(int ano, int idVoluntario)
		{
            AnoHistoriaAsistencia AnoHistoriaAsistencia = new AnoHistoriaAsistencia();
            if (ExisteAnoHistoriaAsistencia(ano, idVoluntario))
            {
                AnoHistoriaAsistencia = ObtenerAnoHistoriaAsistencia(ano, idVoluntario);
                return AnoHistoriaAsistencia.idAnoHistoriaAsistencia;
            }
            else
            {
                AnoHistoriaAsistencia.IniciarId();
                AnoHistoriaAsistencia.ano = ano;
                AnoHistoriaAsistencia.fk_idVoluntarioH = idVoluntario;

                query = String.Format(
                    "INSERT INTO AnoHistoriaAsistencia(idAnoHistoriaAsistencia,ano,fk_idVoluntarioH) VALUES({0},{1},{2})",
                    AnoHistoriaAsistencia.idAnoHistoriaAsistencia,
                    AnoHistoriaAsistencia.ano,
                    AnoHistoriaAsistencia.fk_idVoluntarioH
                    );
                utils.ExecuteNonQuery(query);
                return AnoHistoriaAsistencia.idAnoHistoriaAsistencia;
            }
		}

        public void EditarAnoHistoriaAsistencia(AnoHistoriaAsistencia AnoHistoriaAsistencia, int idAnoHistoriaAsistencia)
		{
			query = String.Format(
				"UPDATE AnoHistoriaAsistencia SET idAnoHistoriaAsistencia = {0}, ano = {1}, fk_idVoluntarioH = {2} WHERE idAnoHistoriaAsistencia = {3}",
				AnoHistoriaAsistencia.idAnoHistoriaAsistencia,
				AnoHistoriaAsistencia.ano,
				AnoHistoriaAsistencia.fk_idVoluntarioH,
				idAnoHistoriaAsistencia
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarAnoHistoriaAsistencia(int idAnoHistoriaAsistencia)
		{
			query = String.Format(
				"DELETE FROM AnoHistoriaAsistencia WHERE idAnoHistoriaAsistencia = {0}",
				idAnoHistoriaAsistencia);
			utils.ExecuteNonQuery(query);
		}

        public bool ExisteAnoHistoriaAsistencia(int ano, int idVoluntario)
        {
            bool existe = false;
            query = String.Format(
                "SELECT * FROM AnoHistoriaAsistencia WHERE ano = {0} and fk_idVoluntarioH = {1}",
                ano,
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                existe = true;
            }
            return existe;
        }

        public AnoHistoriaAsistencia ObtenerAnoHistoriaAsistencia(int ano, int idVoluntario)
		{
			AnoHistoriaAsistencia AnoHistoriaAsistencia = new AnoHistoriaAsistencia();
			query = String.Format(
                "SELECT * FROM AnoHistoriaAsistencia WHERE ano = {0} and fk_idVoluntarioH = {1}",
                ano,
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				AnoHistoriaAsistencia = new AnoHistoriaAsistencia(
					int.Parse(row["idAnoHistoriaAsistencia"].ToString()),
					int.Parse(row["ano"].ToString()),
					int.Parse(row["fk_idVoluntarioH"].ToString())
				);
			}
			return AnoHistoriaAsistencia;
		}
        public ObservableCollection<AnoHistoriaAsistencia> ObtenerAnosHistoriaVoluntario(int idVoluntario)
        {
            ObservableCollection<AnoHistoriaAsistencia> AnoHistoriaAsistencias = new ObservableCollection<AnoHistoriaAsistencia>();
            query = String.Format(
                "SELECT * FROM AnoHistoriaAsistencia WHERE fk_idVoluntarioH = {0} ORDER BY ano ASC",
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                AnoHistoriaAsistencia AnoHistoriaAsistencia = new AnoHistoriaAsistencia(
                    int.Parse(row["idAnoHistoriaAsistencia"].ToString()),
                    int.Parse(row["ano"].ToString()),
                    int.Parse(row["fk_idVoluntarioH"].ToString())
                );
                AnoHistoriaAsistencias.Add(AnoHistoriaAsistencia);
            }
            return AnoHistoriaAsistencias;
        }
        public void IniciarId()
		{
			query = "SELECT * FROM AnoHistoriaAsistencia ORDER BY idAnoHistoriaAsistencia DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idAnoHistoriaAsistencia = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





