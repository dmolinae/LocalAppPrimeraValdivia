

using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;

namespace PrimeraValdivia.Models
{
    class HistoriaAsistencia : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idHistoriaAsistencia;
		public int idHistoriaAsistencia
		{
			get { return _idHistoriaAsistencia; }
			set
			{
				_idHistoriaAsistencia = value;
				OnPropertyChanged("idHistoriaAsistencia");
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


        #endregion

        #region Metodos

        public HistoriaAsistencia()
        {

        }

        public HistoriaAsistencia(int idHistoriaAsistencia, int numero, int fk_idVoluntarioH, String tipo, int mes, int ano)
		{
			this.idHistoriaAsistencia = idHistoriaAsistencia;
			this.numero = numero;
			this.fk_idVoluntarioH = fk_idVoluntarioH;
			this.tipo = tipo;
			this.mes = mes;
			this.ano = ano;
		}
        public HistoriaAsistencia(int fk_idVoluntarioH, String tipo, int mes, int ano, int numero)
        {
            this.fk_idVoluntarioH = fk_idVoluntarioH;
            this.tipo = tipo;
            this.mes = mes;
            this.ano = ano;
            this.numero = numero;
        }

        public void AgregarAsistenciaHistoria(int idVoluntario, int month, int year, String tipo)
        {
            if(ExisteHistoriaAsistencia(year, month, idVoluntario, tipo))
            {
                HistoriaAsistencia hAsistencia = ObtenerHistoriaAsistencia(year, month, idVoluntario, tipo);
                hAsistencia.numero = hAsistencia.numero + 1;

                EditarHistoriaAsistencia(hAsistencia, hAsistencia.idHistoriaAsistencia);
            }
            else
            {
                HistoriaAsistencia HistoriaAsistencia = new HistoriaAsistencia(idVoluntario,tipo,month,year,1);
                query = String.Format(
                "INSERT INTO HistoriaAsistencia(numero,fk_idVoluntarioH,tipo,mes,ano) VALUES({0},{1},'{2}',{3},{4})",
                HistoriaAsistencia.numero,
                HistoriaAsistencia.fk_idVoluntarioH,
                HistoriaAsistencia.tipo,
                HistoriaAsistencia.mes,
                HistoriaAsistencia.ano
                );
                utils.ExecuteNonQuery(query);
            }
        }

        public void EditarHistoriaAsistencia(HistoriaAsistencia HistoriaAsistencia, int idHistoriaAsistencia)
		{
			query = String.Format(
				"UPDATE HistoriaAsistencia SET idHistoriaAsistencia = {0}, numero = {1}, fk_idVoluntarioH = {2}, tipo = '{3}', mes = {4}, ano = {5} WHERE idHistoriaAsistencia = {6}",
				HistoriaAsistencia.idHistoriaAsistencia,
				HistoriaAsistencia.numero,
				HistoriaAsistencia.fk_idVoluntarioH,
				HistoriaAsistencia.tipo,
				HistoriaAsistencia.mes,
				HistoriaAsistencia.ano,
				idHistoriaAsistencia
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarHistoriaAsistencia(int idHistoriaAsistencia)
		{
			query = String.Format(
				"DELETE FROM HistoriaAsistencia WHERE idHistoriaAsistencia = {0}",
				idHistoriaAsistencia);
			utils.ExecuteNonQuery(query);
		}


        public HistoriaAsistencia ObtenerHistoriaAsistencia(int year, int month, int idVoluntario, String tipo)
        {
            HistoriaAsistencia HistoriaAsistencia = new HistoriaAsistencia();
            query = String.Format(
                "SELECT * FROM HistoriaAsistencia WHERE ano = {0} and mes = {1} and fk_idVoluntarioH = {2} and tipo = '{3}'",
                year,
                month,
                idVoluntario,
                tipo);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                HistoriaAsistencia = new HistoriaAsistencia(
                    int.Parse(row["idHistoriaAsistencia"].ToString()),
                    int.Parse(row["numero"].ToString()),
                    int.Parse(row["fk_idVoluntarioH"].ToString()),
                    row["tipo"].ToString(),
                    int.Parse(row["mes"].ToString()),
                    int.Parse(row["ano"].ToString())
                );
            }
            return HistoriaAsistencia;
        }

        public bool ExisteHistoriaAsistencia(int year, int month, int idVoluntario, String tipo)
        {
            bool existe = false;
            query = String.Format(
                "SELECT * FROM HistoriaAsistencia WHERE ano = {0} and mes = {1} and fk_idVoluntarioH = {2} and tipo = '{3}'",
                year,
                month,
                idVoluntario,
                tipo);
            DataTable dt = utils.ExecuteQuery(query);
            Debug.Write(query);
            foreach (DataRow row in dt.Rows)
            {
                existe = true;
            }
            return existe;
        }

        public void IniciarId()
		{
			query = "SELECT * FROM HistoriaAsistencia ORDER BY idHistoriaAsistencia DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idHistoriaAsistencia = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





