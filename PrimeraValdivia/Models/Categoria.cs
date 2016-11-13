

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
    class Categoria : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idCategoria;
		public int idCategoria
		{
			get { return _idCategoria; }
			set
			{
				_idCategoria = value;
				OnPropertyChanged("idCategoria");
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


        #endregion

        #region Metodos

        public Categoria()
        {

        }

        public Categoria(int idCategoria, String nombre, String descripcion)
		{
			this.idCategoria = idCategoria;
			this.nombre = nombre;
			this.descripcion = descripcion;
		}

        public void AgregarCategoria(Categoria Categoria)
		{
			query = String.Format(
				"INSERT INTO Categoria(idCategoria,nombre,descripcion) VALUES({0},'{1}','{2}')",
				Categoria.idCategoria,
				Categoria.nombre,
				Categoria.descripcion
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarCategoria(Categoria Categoria, int idCategoria)
		{
			query = String.Format(
				"UPDATE Categoria SET idCategoria = {0}, nombre = '{1}', descripcion = '{2}' WHERE idCategoria = {3}",
				Categoria.idCategoria,
				Categoria.nombre,
				Categoria.descripcion,
				idCategoria
				);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Categoria> ObtenerCategorias()
		{
			ObservableCollection<Categoria> Categorias = new ObservableCollection<Categoria>();
			query = " SELECT * FROM Categoria";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Categoria Categoria = new Categoria(
					int.Parse(row["idCategoria"].ToString()),
					row["nombre"].ToString(),
					row["descripcion"].ToString()
				);
				Categorias.Add(Categoria);
			}
			return Categorias;
		}

        public void IniciarId()
		{
			query = "SELECT count(*) FROM Categoria";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idCategoria = int.Parse(row["idCategoria"].ToString());
			}
		}
        #endregion
    }
}





