

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
    class Material : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idMaterial;
		public int idMaterial
		{
			get { return _idMaterial; }
			set
			{
				_idMaterial = value;
				OnPropertyChanged("idMaterial");
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

		private int _fk_idCarro;
		public int fk_idCarro
		{
			get { return _fk_idCarro; }
			set
			{
				_fk_idCarro = value;
				OnPropertyChanged("fk_idCarro");
			}
		}


        #endregion

        #region Metodos

        public Material()
        {

        }

        public Material(int idMaterial, String nombre, String descripcion, int fk_idCarro)
		{
			this.idMaterial = idMaterial;
			this.nombre = nombre;
			this.descripcion = descripcion;
			this.fk_idCarro = fk_idCarro;
		}

        public void AgregarMaterial(Material Material)
		{
			query = String.Format(
				"INSERT INTO Material(idMaterial,nombre,descripcion,fk_idCarro) VALUES({0},'{1}','{2}',{3})",
				Material.idMaterial,
				Material.nombre,
				Material.descripcion,
				Material.fk_idCarro
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarMaterial(Material Material, int idMaterial)
		{
			query = String.Format(
				"UPDATE Material SET idMaterial = {0}, nombre = '{1}', descripcion = '{2}', fk_idCarro = {3} WHERE idMaterial = {4}",
				Material.idMaterial,
				Material.nombre,
				Material.descripcion,
				Material.fk_idCarro,
				idMaterial
				);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Material> ObtenerMaterials()
		{
			ObservableCollection<Material> Materials = new ObservableCollection<Material>();
			query = " SELECT * FROM Material";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Material Material = new Material(
					int.Parse(row["idMaterial"].ToString()),
					row["nombre"].ToString(),
					row["descripcion"].ToString(),
					int.Parse(row["fk_idCarro"].ToString())
				);
				Materials.Add(Material);
			}
			return Materials;
		}

        public void IniciarId()
		{
			query = "SELECT count(*) FROM Material";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idMaterial = int.Parse(row["idMaterial"].ToString());
			}
		}
        #endregion
    }
}





