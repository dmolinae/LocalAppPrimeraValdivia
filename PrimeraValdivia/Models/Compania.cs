

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
    class Compania : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idCompania;
		public int idCompania
		{
			get { return _idCompania; }
			set
			{
				_idCompania = value;
				OnPropertyChanged("idCompania");
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

		private String _clave;
		public String clave
		{
			get { return _clave; }
			set
			{
				_clave = value;
				OnPropertyChanged("clave");
			}
		}

		private String _calle;
		public String calle
		{
			get { return _calle; }
			set
			{
				_calle = value;
				OnPropertyChanged("calle");
			}
		}

		private int _numeroCalle;
		public int numeroCalle
		{
			get { return _numeroCalle; }
			set
			{
				_numeroCalle = value;
				OnPropertyChanged("numeroCalle");
			}
		}

		private String _ciudad;
		public String ciudad
		{
			get { return _ciudad; }
			set
			{
				_ciudad = value;
				OnPropertyChanged("ciudad");
			}
		}

		private int _registroCompania;
		public int registroCompania
		{
			get { return _registroCompania; }
			set
			{
				_registroCompania = value;
				OnPropertyChanged("registroCompania");
			}
		}


        #endregion

        #region Metodos

        public Compania()
        {

        }

        public Compania(int idCompania, String nombre, String clave, String calle, int numeroCalle, String ciudad, int registroCompania)
		{
			this.idCompania = idCompania;
			this.nombre = nombre;
			this.clave = clave;
			this.calle = calle;
			this.numeroCalle = numeroCalle;
			this.ciudad = ciudad;
			this.registroCompania = registroCompania;
		}

        public void AgregarCompania(Compania Compania)
		{
			query = String.Format(
				"INSERT INTO Compania(idCompania,nombre,clave,calle,numeroCalle,ciudad,registroCompania) VALUES({0},'{1}','{2}','{3}',{4},'{5}',{6})",
				Compania.idCompania,
				Compania.nombre,
				Compania.clave,
				Compania.calle,
				Compania.numeroCalle,
				Compania.ciudad,
				Compania.registroCompania
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarCompania(Compania Compania, int idCompania)
		{
			query = String.Format(
				"UPDATE Compania SET idCompania = {0}, nombre = '{1}', clave = '{2}', calle = '{3}', numeroCalle = {4}, ciudad = '{5}', registroCompania = {6} WHERE idCompania = {7}",
				Compania.idCompania,
				Compania.nombre,
				Compania.clave,
				Compania.calle,
				Compania.numeroCalle,
				Compania.ciudad,
				Compania.registroCompania,
				idCompania
				);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Compania> ObtenerCompanias()
		{
			ObservableCollection<Compania> Companias = new ObservableCollection<Compania>();
			query = " SELECT * FROM Compania";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Compania Compania = new Compania(
					int.Parse(row["idCompania"].ToString()),
					row["nombre"].ToString(),
					row["clave"].ToString(),
					row["calle"].ToString(),
					int.Parse(row["numeroCalle"].ToString()),
					row["ciudad"].ToString(),
					int.Parse(row["registroCompania"].ToString())
				);
				Companias.Add(Compania);
			}
			return Companias;
		}

        public void IniciarId()
		{
			query = "SELECT count(*) FROM Compania";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idCompania = int.Parse(row[0].ToString());
			}
		}
        #endregion
    }
}





