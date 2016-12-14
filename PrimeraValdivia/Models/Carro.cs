

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
    class Carro : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idCarro;
		public int idCarro
		{
			get { return _idCarro; }
			set
			{
				_idCarro = value;
				OnPropertyChanged("idCarro");
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

		private String _descripcion;
		public String descripcion
		{
			get { return _descripcion; }
			set
			{
				_descripcion = value;
				OnPropertyChanged("descripcion");
			}
		}

		private float _kilometraje;
		public float kilometraje
		{
			get { return _kilometraje; }
			set
			{
				_kilometraje = value;
				OnPropertyChanged("kilometraje");
			}
		}

		private float _horas_motor;
		public float horas_motor
		{
			get { return _horas_motor; }
			set
			{
				_horas_motor = value;
				OnPropertyChanged("horas_motor");
			}
		}

		private float _horas_bomba;
		public float horas_bomba
		{
			get { return _horas_bomba; }
			set
			{
				_horas_bomba = value;
				OnPropertyChanged("horas_bomba");
			}
		}


        #endregion

        #region Metodos

        public Carro()
        {

        }

        public Carro(int idCarro, String nombre, String tipo, String descripcion, float kilometraje, float horas_motor, float horas_bomba)
		{
			this.idCarro = idCarro;
			this.nombre = nombre;
			this.tipo = tipo;
			this.descripcion = descripcion;
			this.kilometraje = kilometraje;
			this.horas_motor = horas_motor;
			this.horas_bomba = horas_bomba;
		}

        public void AgregarCarro(Carro Carro)
		{
			query = String.Format(
				"INSERT INTO Carro(idCarro,nombre,tipo,descripcion,kilometraje,horas_motor,horas_bomba) VALUES({0},'{1}','{2}','{3}',{4},{5},{6})",
				Carro.idCarro,
				Carro.nombre,
				Carro.tipo,
				Carro.descripcion,
				Carro.kilometraje,
				Carro.horas_motor,
				Carro.horas_bomba
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarCarro(Carro Carro, int idCarro)
		{
			query = String.Format(
				"UPDATE Carro SET idCarro = {0}, nombre = '{1}', tipo = '{2}', descripcion = '{3}', kilometraje = {4}, horas_motor = {5}, horas_bomba = {6} WHERE idCarro = {7}",
				Carro.idCarro,
				Carro.nombre,
				Carro.tipo,
				Carro.descripcion,
				Carro.kilometraje,
				Carro.horas_motor,
				Carro.horas_bomba,
				idCarro
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarCarro(int idCarro)
		{
			query = String.Format(
				"DELETE FROM Carro WHERE idCarro = {0}",
				idCarro);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Carro> ObtenerCarros()
		{
			ObservableCollection<Carro> Carros = new ObservableCollection<Carro>();
			query = " SELECT * FROM Carro";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Carro Carro = new Carro(
					int.Parse(row["idCarro"].ToString()),
					row["nombre"].ToString(),
					row["tipo"].ToString(),
					row["descripcion"].ToString(),
					float.Parse(row["kilometraje"].ToString()),
					float.Parse(row["horas_motor"].ToString()),
					float.Parse(row["horas_bomba"].ToString())
				);
				Carros.Add(Carro);
			}
			return Carros;
		}

		public ObservableCollection<Carro> ObtenerCarro()
		{
			ObservableCollection<Carro> Carros = new ObservableCollection<Carro>();
			query = String.Format(
				"SELECT * FROM Carro WHERE idCarro = {0}",
				idCarro);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Carro Carro = new Carro(
					int.Parse(row["idCarro"].ToString()),
					row["nombre"].ToString(),
					row["tipo"].ToString(),
					row["descripcion"].ToString(),
					float.Parse(row["kilometraje"].ToString()),
					float.Parse(row["horas_motor"].ToString()),
					float.Parse(row["horas_bomba"].ToString())
				);
				Carros.Add(Carro);
			}
			return Carros;
		}

        public void IniciarId()
		{
			query = "SELECT * FROM Carro ORDER BY idCarro DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idCarro = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





