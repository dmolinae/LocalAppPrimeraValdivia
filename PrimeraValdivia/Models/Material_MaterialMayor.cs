

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
    class Material_MaterialMayor : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idMaterialEvento;
		public int idMaterialEvento
		{
			get { return _idMaterialEvento; }
			set
			{
				_idMaterialEvento = value;
				OnPropertyChanged("idMaterialEvento");
			}
		}

		private int _fk_idMaterial;
		public int fk_idMaterial
		{
			get { return _fk_idMaterial; }
			set
			{
				_fk_idMaterial = value;
				OnPropertyChanged("fk_idMaterial");
			}
		}

		private int _fk_idMaterialMayor;
		public int fk_idMaterialMayor
		{
			get { return _fk_idMaterialMayor; }
			set
			{
				_fk_idMaterialMayor = value;
				OnPropertyChanged("fk_idMaterialMayor");
			}
		}


        #endregion

        #region Metodos

        public Material_MaterialMayor()
        {

        }

        public Material_MaterialMayor(int idMaterialEvento, int fk_idMaterial, int fk_idMaterialMayor)
		{
			this.idMaterialEvento = idMaterialEvento;
			this.fk_idMaterial = fk_idMaterial;
			this.fk_idMaterialMayor = fk_idMaterialMayor;
		}

        public void AgregarMaterial_MaterialMayor(Material_MaterialMayor Material_MaterialMayor)
		{
			query = String.Format(
				"INSERT INTO Material_MaterialMayor(fk_idMaterial,fk_idMaterialMayor) VALUES({0},{1})",
				Material_MaterialMayor.fk_idMaterial,
				Material_MaterialMayor.fk_idMaterialMayor
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarMaterial_MaterialMayor(Material_MaterialMayor Material_MaterialMayor, int idMaterialEvento)
		{
			query = String.Format(
				"UPDATE Material_MaterialMayor SET idMaterialEvento = {0}, fk_idMaterial = {1}, fk_idMaterialMayor = {2} WHERE idMaterialEvento = {3}",
				Material_MaterialMayor.idMaterialEvento,
				Material_MaterialMayor.fk_idMaterial,
				Material_MaterialMayor.fk_idMaterialMayor,
				idMaterialEvento
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarMaterial_MaterialMayor(int idMaterialEvento)
		{
			query = String.Format(
				"DELETE FROM Material_MaterialMayor WHERE idMaterialEvento = {0}",
				idMaterialEvento);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Material_MaterialMayor> ObtenerMateriales(int idMaterialMayor)
		{
			ObservableCollection<Material_MaterialMayor> Material_MaterialMayors = new ObservableCollection<Material_MaterialMayor>();
			query = String.Format(
                "SELECT * FROM Material_MaterialMayor WHERE fk_idMaterialMayor = {0}",
                idMaterialMayor);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Material_MaterialMayor Material_MaterialMayor = new Material_MaterialMayor(
					int.Parse(row["idMaterialEvento"].ToString()),
					int.Parse(row["fk_idMaterial"].ToString()),
					int.Parse(row["fk_idMaterialMayor"].ToString())
				);
				Material_MaterialMayors.Add(Material_MaterialMayor);
			}
			return Material_MaterialMayors;
		}

		public ObservableCollection<Material_MaterialMayor> ObtenerMaterial_MaterialMayor(int idMaterialEvento)
		{
			ObservableCollection<Material_MaterialMayor> Material_MaterialMayors = new ObservableCollection<Material_MaterialMayor>();
			query = String.Format(
				"SELECT * FROM Material_MaterialMayor WHERE idMaterialEvento = {0}",
				idMaterialEvento);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Material_MaterialMayor Material_MaterialMayor = new Material_MaterialMayor(
					int.Parse(row["idMaterialEvento"].ToString()),
					int.Parse(row["fk_idMaterial"].ToString()),
					int.Parse(row["fk_idMaterialMayor"].ToString())
				);
				Material_MaterialMayors.Add(Material_MaterialMayor);
			}
			return Material_MaterialMayors;
		}

        public void IniciarId()
		{
			query = "SELECT * FROM Material_MaterialMayor ORDER BY idMaterialEvento DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idMaterialEvento = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





