

using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Models
{
    class MesHistoriaAsistencia : ViewModelBase
    {
        private Utils utils = new Utils();

        private AnoHistoriaAsistencia AHAModel = new AnoHistoriaAsistencia();

        private string query;

        #region Atributos
        
		private int _idMesHistoriaAsistencia;
		public int idMesHistoriaAsistencia
		{
			get { return _idMesHistoriaAsistencia; }
			set
			{
				_idMesHistoriaAsistencia = value;
				OnPropertyChanged("idMesHistoriaAsistencia");
			}
		}

		private int _numero;
		public int numero
		{
			get { return _numero; }
			set
			{
				_numero = value;
				OnPropertyChanged("numero");
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

		private int _mes;
		public int mes
		{
			get { return _mes; }
			set
			{
				_mes = value;
				OnPropertyChanged("mes");
			}
		}

		private int _fk_idAnoHistoriaAsistencia;
		public int fk_idAnoHistoriaAsistencia
		{
			get { return _fk_idAnoHistoriaAsistencia; }
			set
			{
				_fk_idAnoHistoriaAsistencia = value;
				OnPropertyChanged("fk_idAnoHistoriaAsistencia");
			}
		}


        #endregion

        #region Metodos

        public MesHistoriaAsistencia()
        {

        }

        public MesHistoriaAsistencia(int idMesHistoriaAsistencia, int numero, String tipo, int mes, int fk_idAnoHistoriaAsistencia)
		{
			this.idMesHistoriaAsistencia = idMesHistoriaAsistencia;
			this.numero = numero;
			this.tipo = tipo;
			this.mes = mes;
			this.fk_idAnoHistoriaAsistencia = fk_idAnoHistoriaAsistencia;
		}

        public void AgregarMesHistoriaAsistencia(int fk_year, int mes, String tipo)
		{
            if (ExisteMesHistoriaAsistencia(fk_year, mes, tipo))
            {
                MesHistoriaAsistencia mAsistencia = ObtenerMesHistoriaAsistencia(fk_year, mes, tipo);
                mAsistencia.numero = mAsistencia.numero + 1;

                EditarMesHistoriaAsistencia(mAsistencia, mAsistencia.idMesHistoriaAsistencia);
            }
            else
            {
                MesHistoriaAsistencia MesHistoriaAsistencia = new MesHistoriaAsistencia();
                MesHistoriaAsistencia.IniciarId();
                MesHistoriaAsistencia.numero = 1;
                MesHistoriaAsistencia.tipo = tipo;
                MesHistoriaAsistencia.mes = mes;
                MesHistoriaAsistencia.fk_idAnoHistoriaAsistencia = fk_year;

                query = String.Format(
                    "INSERT INTO MesHistoriaAsistencia(idMesHistoriaAsistencia,numero,tipo,mes,fk_idAnoHistoriaAsistencia) VALUES({0},{1},'{2}',{3},{4})",
                    MesHistoriaAsistencia.idMesHistoriaAsistencia,
                    MesHistoriaAsistencia.numero,
                    MesHistoriaAsistencia.tipo,
                    MesHistoriaAsistencia.mes,
                    MesHistoriaAsistencia.fk_idAnoHistoriaAsistencia
                    );
                utils.ExecuteNonQuery(query);
            }
		}
        public void DisminuirMesHistoriaAsistencia(int fk_year, int mes, String tipo)
        {
            MesHistoriaAsistencia mAsistencia = ObtenerMesHistoriaAsistencia(fk_year, mes, tipo);

            if(mAsistencia.numero > 0)
            {
                mAsistencia.numero = mAsistencia.numero - 1;
                EditarMesHistoriaAsistencia(mAsistencia, mAsistencia.idMesHistoriaAsistencia);
            }
            if(mAsistencia.numero == 0)
            {
                EliminarMesHistoriaAsistencia(mAsistencia.idMesHistoriaAsistencia);
                if (!ExisteAnoHistoriaAsistencia(fk_year))
                {
                    AHAModel.EliminarAnoHistoriaAsistencia(fk_year);
                }
            }
        }

        public void EditarMesHistoriaAsistencia(MesHistoriaAsistencia MesHistoriaAsistencia, int idMesHistoriaAsistencia)
		{
			query = String.Format(
				"UPDATE MesHistoriaAsistencia SET idMesHistoriaAsistencia = {0}, numero = {1}, tipo = '{2}', mes = {3}, fk_idAnoHistoriaAsistencia = {4} WHERE idMesHistoriaAsistencia = {5}",
				MesHistoriaAsistencia.idMesHistoriaAsistencia,
				MesHistoriaAsistencia.numero,
				MesHistoriaAsistencia.tipo,
				MesHistoriaAsistencia.mes,
				MesHistoriaAsistencia.fk_idAnoHistoriaAsistencia,
				idMesHistoriaAsistencia
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarMesHistoriaAsistencia(int idMesHistoriaAsistencia)
		{
			query = String.Format(
				"DELETE FROM MesHistoriaAsistencia WHERE idMesHistoriaAsistencia = {0}",
				idMesHistoriaAsistencia);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<MesHistoriaAsistencia> ObtenerMesHistoriaAsistencias()
		{
			ObservableCollection<MesHistoriaAsistencia> MesHistoriaAsistencias = new ObservableCollection<MesHistoriaAsistencia>();
			query = " SELECT * FROM MesHistoriaAsistencia";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				MesHistoriaAsistencia MesHistoriaAsistencia = new MesHistoriaAsistencia(
					int.Parse(row["idMesHistoriaAsistencia"].ToString()),
					int.Parse(row["numero"].ToString()),
					row["tipo"].ToString(),
					int.Parse(row["mes"].ToString()),
					int.Parse(row["fk_idAnoHistoriaAsistencia"].ToString())
				);
				MesHistoriaAsistencias.Add(MesHistoriaAsistencia);
			}
			return MesHistoriaAsistencias;
		}

        public MesHistoriaAsistencia ObtenerMesHistoriaAsistencia(int fk_year, int month, String tipo)
        {
            MesHistoriaAsistencia HistoriaAsistencia = new MesHistoriaAsistencia();
            query = String.Format(
                "SELECT * FROM MesHistoriaAsistencia WHERE fk_idAnoHistoriaAsistencia = {0} and mes = {1} and tipo = '{2}'",
                fk_year,
                month,
                tipo);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                HistoriaAsistencia = new MesHistoriaAsistencia(
                    int.Parse(row["idMesHistoriaAsistencia"].ToString()),
                    int.Parse(row["numero"].ToString()),
                    row["tipo"].ToString(),
                    int.Parse(row["mes"].ToString()),
                    int.Parse(row["fk_idAnoHistoriaAsistencia"].ToString())
                );
            }
            return HistoriaAsistencia;
        }
        public bool ExisteMesHistoriaAsistencia(int fk_year, int month, String tipo)
        {
            bool existe = false;
            query = String.Format(
                "SELECT * FROM MesHistoriaAsistencia WHERE fk_idAnoHistoriaAsistencia = {0} and mes = {1} and tipo = '{2}'",
                fk_year,
                month,
                tipo);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                existe = true;
            }
            return existe;
        }
        public bool ExisteAnoHistoriaAsistencia(int fk_year)
        {
            bool existe = false;
            query = String.Format(
                "SELECT * FROM MesHistoriaAsistencia WHERE fk_idAnoHistoriaAsistencia = {0}",
                fk_year);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                existe = true;
            }
            return existe;
        }

        public void IniciarId()
		{
			query = "SELECT * FROM MesHistoriaAsistencia ORDER BY idMesHistoriaAsistencia DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idMesHistoriaAsistencia = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





