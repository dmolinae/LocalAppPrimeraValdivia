

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
    class Item : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idItem;
		public int idItem
		{
			get { return _idItem; }
			set
			{
				_idItem = value;
				OnPropertyChanged("idItem");
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

		private int _fk_idCategoria;
		public int fk_idCategoria
		{
			get { return _fk_idCategoria; }
			set
			{
				_fk_idCategoria = value;
				OnPropertyChanged("fk_idCategoria");
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

        public Item()
        {

        }

        public Item(int idItem, String nombre, int fk_idCategoria, String descripcion)
		{
			this.idItem = idItem;
			this.nombre = nombre;
			this.fk_idCategoria = fk_idCategoria;
			this.descripcion = descripcion;
		}

        public void AgregarItem(Item Item)
		{
			query = String.Format(
				"INSERT INTO Item(idItem,nombre,fk_idCategoria,descripcion) VALUES({0},'{1}',{2},'{3}')",
				Item.idItem,
				Item.nombre,
				Item.fk_idCategoria,
				Item.descripcion
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarItem(Item Item, int idItem)
		{
			query = String.Format(
				"UPDATE Item SET idItem = {0}, nombre = '{1}', fk_idCategoria = {2}, descripcion = '{3}' WHERE idItem = {4}",
				Item.idItem,
				Item.nombre,
				Item.fk_idCategoria,
				Item.descripcion,
				idItem
				);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Item> ObtenerItems()
		{
			ObservableCollection<Item> Items = new ObservableCollection<Item>();
			query = " SELECT * FROM Item";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Item Item = new Item(
					int.Parse(row["idItem"].ToString()),
					row["nombre"].ToString(),
					int.Parse(row["fk_idCategoria"].ToString()),
					row["descripcion"].ToString()
				);
				Items.Add(Item);
			}
			return Items;
		}

        public ObservableCollection<Item> ObtenerItemsCategoria(int idCategoria)
        {
            ObservableCollection<Item> Items = new ObservableCollection<Item>();
            query = String.Format(
                " SELECT * FROM Item WHERE fk_idCategoria = {0}",
                idCategoria);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Item Item = new Item(
                    int.Parse(row["idItem"].ToString()),
                    row["nombre"].ToString(),
                    int.Parse(row["fk_idCategoria"].ToString()),
                    row["descripcion"].ToString()
                );
                Items.Add(Item);
            }
            return Items;
        }

        public void IniciarId()
        {
            query = "SELECT * FROM Item ORDER BY idItem DESC LIMIT 1";
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                this.idItem = int.Parse(row[0].ToString()) + 1;
            }
        }
        #endregion
    }
}





