

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
    class CompaniaVoluntario : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idCompaniaVoluntario;
		public int idCompaniaVoluntario
		{
			get { return _idCompaniaVoluntario; }
			set
			{
				_idCompaniaVoluntario = value;
				OnPropertyChanged("idCompaniaVoluntario");
			}
		}

		private DateTime _fechaIngreso = DateTime.Now;
        public DateTime fechaIngreso
		{
			get { return _fechaIngreso; }
			set
			{
				_fechaIngreso = value;
				OnPropertyChanged("fechaIngreso");
			}
		}

		private DateTime _fechaSalida = DateTime.Now;
        public DateTime fechaSalida
		{
			get { return _fechaSalida; }
			set
			{
				_fechaSalida = value;
				OnPropertyChanged("fechaSalida");
			}
		}

		private int _fk_compania;
		public int fk_compania
		{
			get { return _fk_compania; }
			set
			{
				_fk_compania = value;
				OnPropertyChanged("fk_compania");
			}
		}

		private String _fk_voluntario;
		public String fk_voluntario
		{
			get { return _fk_voluntario; }
			set
			{
				_fk_voluntario = value;
				OnPropertyChanged("fk_voluntario");
			}
		}


        #endregion

        #region Metodos

        public CompaniaVoluntario()
        {

        }

        public CompaniaVoluntario(int idCompaniaVoluntario, DateTime fechaIngreso, DateTime fechaSalida, int fk_compania, String fk_voluntario)
		{
			this.idCompaniaVoluntario = idCompaniaVoluntario;
			this.fechaIngreso = fechaIngreso;
			this.fechaSalida = fechaSalida;
			this.fk_compania = fk_compania;
			this.fk_voluntario = fk_voluntario;
		}

        public void AgregarCompaniaVoluntario(CompaniaVoluntario CompaniaVoluntario)
		{
			query = String.Format(
				"INSERT INTO CompaniaVoluntario(idCompaniaVoluntario,fechaIngreso,fechaSalida,fk_compania,fk_voluntario) VALUES({0},'{1}','{2}',{3},'{4}')",
				CompaniaVoluntario.idCompaniaVoluntario,
				CompaniaVoluntario.fechaIngreso,
				CompaniaVoluntario.fechaSalida,
				CompaniaVoluntario.fk_compania,
				CompaniaVoluntario.fk_voluntario
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarCompaniaVoluntario(CompaniaVoluntario CompaniaVoluntario, int idCompaniaVoluntario)
		{
			query = String.Format(
				"UPDATE CompaniaVoluntario SET idCompaniaVoluntario = {0}, fechaIngreso = '{1}', fechaSalida = '{2}', fk_compania = {3}, fk_voluntario = '{4}' WHERE idCompaniaVoluntario = {5}",
				CompaniaVoluntario.idCompaniaVoluntario,
				CompaniaVoluntario.fechaIngreso,
				CompaniaVoluntario.fechaSalida,
				CompaniaVoluntario.fk_compania,
				CompaniaVoluntario.fk_voluntario,
				idCompaniaVoluntario
				);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<CompaniaVoluntario> ObtenerCompaniaVoluntarios()
		{
			ObservableCollection<CompaniaVoluntario> CompaniaVoluntarios = new ObservableCollection<CompaniaVoluntario>();
			query = " SELECT * FROM CompaniaVoluntario";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				CompaniaVoluntario CompaniaVoluntario = new CompaniaVoluntario(
					int.Parse(row["idCompaniaVoluntario"].ToString()),
					DateTime.Parse(row["fechaIngreso"].ToString()),
					DateTime.Parse(row["fechaSalida"].ToString()),
					int.Parse(row["fk_compania"].ToString()),
					row["fk_voluntario"].ToString()
				);
				CompaniaVoluntarios.Add(CompaniaVoluntario);
			}
			return CompaniaVoluntarios;
		}

        public void IniciarId()
        {
            query = "SELECT * FROM CompaniaVoluntario ORDER BY idCompaniaVoluntario DESC LIMIT 1";
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                this.idCompaniaVoluntario = int.Parse(row[0].ToString()) + 1;
            }
        }

        public CompaniaVoluntario ObtenerCompaniaVoluntario(String fk_voluntario, int fk_compania)
        {
            CompaniaVoluntario CompaniaVoluntario = new CompaniaVoluntario();
            query = String.Format(
                "SELECT * FROM CompaniaVoluntario WHERE fk_voluntario = '{0}' AND fk_compania = {1}",
                fk_voluntario,
                fk_compania);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                CompaniaVoluntario = new CompaniaVoluntario(
                    int.Parse(row["idCompaniaVoluntario"].ToString()),
                    DateTime.Parse(row["fechaIngreso"].ToString()),
                    DateTime.Parse(row["fechaSalida"].ToString()),
                    int.Parse(row["fk_compania"].ToString()),
                    row["fk_voluntario"].ToString()
                );
            }
            return CompaniaVoluntario;
        }
        #endregion
    }
}





