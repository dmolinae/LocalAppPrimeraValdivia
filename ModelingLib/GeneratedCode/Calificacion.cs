

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

		private String _fk_rutVoluntario;
		public String fk_rutVoluntario
		{
			get { return _fk_rutVoluntario; }
			set
			{
				_fk_rutVoluntario = value;
				OnPropertyChanged("fk_rutVoluntario");
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


        #endregion

        #region Metodos

        public Calificacion()
        {

        }

        public Calificacion(int idCalificacion, int numero, String anos, String fk_rutVoluntario, String premio)
		{
			this.idCalificacion = idCalificacion;
			this.numero = numero;
			this.anos = anos;
			this.fk_rutVoluntario = fk_rutVoluntario;
			this.premio = premio;
		}

        public void AgregarCalificacion(Calificacion Calificacion)
		{
			query = String.Format(
				"INSERT INTO Calificacion(idCalificacion,numero,anos,fk_rutVoluntario,premio) VALUES({0},{1},'{2}','{3}','{4}')",
				Calificacion.idCalificacion,
				Calificacion.numero,
				Calificacion.anos,
				Calificacion.fk_rutVoluntario,
				Calificacion.premio
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarCalificacion(Calificacion Calificacion, int idCalificacion)
		{
			query = String.Format(
				"UPDATE Calificacion SET idCalificacion = {0}, numero = {1}, anos = '{2}', fk_rutVoluntario = '{3}', premio = '{4}' WHERE idCalificacion = {5}",
				Calificacion.idCalificacion,
				Calificacion.numero,
				Calificacion.anos,
				Calificacion.fk_rutVoluntario,
				Calificacion.premio,
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
					row["fk_rutVoluntario"].ToString(),
					row["premio"].ToString()
				);
				Calificacions.Add(Calificacion);
			}
			return Calificacions;
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





