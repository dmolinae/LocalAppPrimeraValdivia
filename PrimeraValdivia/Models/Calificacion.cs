

using PrimeraValdivia.ViewModels;
using PrimeraValdivia.Helpers;
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
    class Calificacion : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idCalificacion;
		public int idCalificacion
		{
			get { return _idCalificacion; }
			set
			{
				_idCalificacion = value;
				OnPropertyChanged("idCalificacion");
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

		private String _anos;
		public String anos
		{
			get { return _anos; }
			set
			{
				_anos = value;
				OnPropertyChanged("anos");
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

		private String _premio;
		public String premio
		{
			get { return _premio; }
			set
			{
				_premio = value;
				OnPropertyChanged("premio");
			}
		}

		private DateTime _fecha;
		public DateTime fecha
		{
			get { return _fecha; }
			set
			{
				_fecha = value;
				OnPropertyChanged("fecha");
			}
		}


        #endregion

        #region Metodos

        public Calificacion()
        {

        }

        public Calificacion(int idCalificacion, int numero, String anos, int fk_idVoluntario, String premio, DateTime fecha)
		{
			this.idCalificacion = idCalificacion;
			this.numero = numero;
			this.anos = anos;
			this.fk_idVoluntario = fk_idVoluntario;
			this.premio = premio;
			this.fecha = fecha;
		}

        public void AgregarCalificacion(Calificacion Calificacion)
		{
			query = String.Format(
				"INSERT INTO Calificacion(idCalificacion,numero,anos,fk_idVoluntario,premio,fecha) VALUES({0},{1},'{2}',{3},'{4}','{5}')",
				Calificacion.idCalificacion,
				Calificacion.numero,
				Calificacion.anos,
				Calificacion.fk_idVoluntario,
				Calificacion.premio,
				Calificacion.fecha
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarCalificacion(Calificacion Calificacion, int idCalificacion)
		{
			query = String.Format(
				"UPDATE Calificacion SET idCalificacion = {0}, numero = {1}, anos = '{2}', fk_idVoluntario = {3}, premio = '{4}', fecha = '{5}' WHERE idCalificacion = {6}",
				Calificacion.idCalificacion,
				Calificacion.numero,
				Calificacion.anos,
				Calificacion.fk_idVoluntario,
				Calificacion.premio,
				Calificacion.fecha,
				idCalificacion
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarCalificacion(int idCalificacion)
		{
			query = String.Format(
				"DELETE FROM Calificacion WHERE idCalificacion = {0}",
				idCalificacion);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Calificacion> ObtenerCalificacions()
		{
			ObservableCollection<Calificacion> Calificacions = new ObservableCollection<Calificacion>();
			query = " SELECT * FROM Calificacion";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Calificacion Calificacion = new Calificacion(
					int.Parse(row["idCalificacion"].ToString()),
					int.Parse(row["numero"].ToString()),
					row["anos"].ToString(),
					int.Parse(row["fk_idVoluntario"].ToString()),
					row["premio"].ToString(),
					DateTime.Parse(row["fecha"].ToString())
				);
				Calificacions.Add(Calificacion);
			}
			return Calificacions;
		}

        public ObservableCollection<Calificacion> ObtenerCalificacions(int idVoluntario)
        {
            ObservableCollection<Calificacion> Calificacions = new ObservableCollection<Calificacion>();
            query = String.Format(
                " SELECT * FROM Calificacion WHERE fk_idVoluntario = {0}",
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Calificacion Calificacion = new Calificacion(
                    int.Parse(row["idCalificacion"].ToString()),
                    int.Parse(row["numero"].ToString()),
                    row["anos"].ToString(),
                    int.Parse(row["fk_idVoluntario"].ToString()),
                    row["premio"].ToString(),
                    DateTime.Parse(row["fecha"].ToString())
                );
                Calificacions.Add(Calificacion);
            }
            return Calificacions;
        }

        public ObservableCollection<Calificacion> ObtenerCalificacion()
		{
			ObservableCollection<Calificacion> Calificacions = new ObservableCollection<Calificacion>();
			query = String.Format(
				"SELECT * FROM Calificacion WHERE idCalificacion = {0}",
				idCalificacion);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Calificacion Calificacion = new Calificacion(
					int.Parse(row["idCalificacion"].ToString()),
					int.Parse(row["numero"].ToString()),
					row["anos"].ToString(),
					int.Parse(row["fk_idVoluntario"].ToString()),
					row["premio"].ToString(),
					DateTime.Parse(row["fecha"].ToString())
				);
				Calificacions.Add(Calificacion);
			}
			return Calificacions;
		}

        public int ContarRegistrosVoluntario(int idVoluntario)
        {
            int num = 0;
            query = String.Format(
                "SELECT count(*) FROM Calificacion WHERE fk_idVoluntario = {0}",
                idVoluntario);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                num = int.Parse(row[0].ToString());
            }
            return num;
        }

        public void IniciarId()
		{
			query = "SELECT * FROM Calificacion ORDER BY idCalificacion DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idCalificacion = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





