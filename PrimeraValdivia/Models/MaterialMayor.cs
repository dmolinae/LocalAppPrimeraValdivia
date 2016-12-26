

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
    class MaterialMayor : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idCarroEvento;
		public int idCarroEvento
		{
			get { return _idCarroEvento; }
			set
			{
				_idCarroEvento = value;
				OnPropertyChanged("idCarroEvento");
			}
		}

		private String _conductor;
		public String conductor
		{
			get { return _conductor; }
			set
			{
				_conductor = value;
				OnPropertyChanged("conductor");
			}
		}

		private String _oficialCargo;
		public String oficialCargo
		{
			get { return _oficialCargo; }
			set
			{
				_oficialCargo = value;
				OnPropertyChanged("oficialCargo");
			}
		}

		private String _horaSalidaCuartel;
		public String horaSalidaCuartel
		{
			get { return _horaSalidaCuartel; }
			set
			{
				_horaSalidaCuartel = value;
				OnPropertyChanged("horaSalidaCuartel");
			}
		}

		private String _horaLlegadaEvento;
		public String horaLlegadaEvento
		{
			get { return _horaLlegadaEvento; }
			set
			{
				_horaLlegadaEvento = value;
				OnPropertyChanged("horaLlegadaEvento");
			}
		}

		private String _horaSalidaEvento;
		public String horaSalidaEvento
		{
			get { return _horaSalidaEvento; }
			set
			{
				_horaSalidaEvento = value;
				OnPropertyChanged("horaSalidaEvento");
			}
		}

		private String _horaLlegadaCuartel;
		public String horaLlegadaCuartel
		{
			get { return _horaLlegadaCuartel; }
			set
			{
				_horaLlegadaCuartel = value;
				OnPropertyChanged("horaLlegadaCuartel");
			}
		}

		private int _fk_idCarroMaterial;
		public int fk_idCarroMaterial
		{
			get { return _fk_idCarroMaterial; }
			set
			{
				_fk_idCarroMaterial = value;
				OnPropertyChanged("fk_idCarroMaterial");
			}
		}

		private int _fk_idEventoMaterial;
		public int fk_idEventoMaterial
		{
			get { return _fk_idEventoMaterial; }
			set
			{
				_fk_idEventoMaterial = value;
				OnPropertyChanged("fk_idEventoMaterial");
			}
		}

		private float _kilometrajeSalida;
		public float kilometrajeSalida
		{
			get { return _kilometrajeSalida; }
			set
			{
				_kilometrajeSalida = value;
				OnPropertyChanged("kilometrajeSalida");
			}
		}

		private float _kilometrajeLlegada;
		public float kilometrajeLlegada
		{
			get { return _kilometrajeLlegada; }
			set
			{
				_kilometrajeLlegada = value;
				OnPropertyChanged("kilometrajeLlegada");
			}
		}


        #endregion

        #region Metodos

        public MaterialMayor()
        {

        }

        public MaterialMayor(int idCarroEvento, String conductor, String oficialCargo, String horaSalidaCuartel, String horaLlegadaEvento, String horaSalidaEvento, String horaLlegadaCuartel, int fk_idCarroMaterial, int fk_idEventoMaterial, float kilometrajeSalida, float kilometrajeLlegada)
		{
			this.idCarroEvento = idCarroEvento;
			this.conductor = conductor;
			this.oficialCargo = oficialCargo;
			this.horaSalidaCuartel = horaSalidaCuartel;
			this.horaLlegadaEvento = horaLlegadaEvento;
			this.horaSalidaEvento = horaSalidaEvento;
			this.horaLlegadaCuartel = horaLlegadaCuartel;
			this.fk_idCarroMaterial = fk_idCarroMaterial;
			this.fk_idEventoMaterial = fk_idEventoMaterial;
			this.kilometrajeSalida = kilometrajeSalida;
			this.kilometrajeLlegada = kilometrajeLlegada;
		}

        public void AgregarMaterialMayor(MaterialMayor MaterialMayor)
		{
			query = String.Format(
				"INSERT INTO MaterialMayor(idCarroEvento,conductor,oficialCargo,horaSalidaCuartel,horaLlegadaEvento,horaSalidaEvento,horaLlegadaCuartel,fk_idCarroMaterial,fk_idEventoMaterial,kilometrajeSalida,kilometrajeLlegada) VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10})",
				MaterialMayor.idCarroEvento,
				MaterialMayor.conductor,
				MaterialMayor.oficialCargo,
				MaterialMayor.horaSalidaCuartel,
				MaterialMayor.horaLlegadaEvento,
				MaterialMayor.horaSalidaEvento,
				MaterialMayor.horaLlegadaCuartel,
				MaterialMayor.fk_idCarroMaterial,
				MaterialMayor.fk_idEventoMaterial,
				MaterialMayor.kilometrajeSalida,
				MaterialMayor.kilometrajeLlegada
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarMaterialMayor(MaterialMayor MaterialMayor, int idCarroEvento)
		{
			query = String.Format(
				"UPDATE MaterialMayor SET idCarroEvento = {0}, conductor = '{1}', oficialCargo = '{2}', horaSalidaCuartel = '{3}', horaLlegadaEvento = '{4}', horaSalidaEvento = '{5}', horaLlegadaCuartel = '{6}', fk_idCarroMaterial = {7}, fk_idEventoMaterial = {8}, kilometrajeSalida = {9}, kilometrajeLlegada = {10} WHERE idCarroEvento = {11}",
				MaterialMayor.idCarroEvento,
				MaterialMayor.conductor,
				MaterialMayor.oficialCargo,
				MaterialMayor.horaSalidaCuartel,
				MaterialMayor.horaLlegadaEvento,
				MaterialMayor.horaSalidaEvento,
				MaterialMayor.horaLlegadaCuartel,
				MaterialMayor.fk_idCarroMaterial,
				MaterialMayor.fk_idEventoMaterial,
				MaterialMayor.kilometrajeSalida,
				MaterialMayor.kilometrajeLlegada,
				idCarroEvento
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarMaterialMayor(int idCarroEvento)
		{
			query = String.Format(
				"DELETE FROM MaterialMayor WHERE idCarroEvento = {0}",
				idCarroEvento);
			utils.ExecuteNonQuery(query);
            query = String.Format(
                "DELETE FROM Material_MaterialMayor WHERE fk_idMaterialMayor = {0}",
                idCarroEvento);
            utils.ExecuteNonQuery(query);
        }

        public ObservableCollection<MaterialMayor> ObtenerMaterialMayors()
		{
			ObservableCollection<MaterialMayor> MaterialMayors = new ObservableCollection<MaterialMayor>();
			query = " SELECT * FROM MaterialMayor";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				MaterialMayor MaterialMayor = new MaterialMayor(
					int.Parse(row["idCarroEvento"].ToString()),
					row["conductor"].ToString(),
					row["oficialCargo"].ToString(),
					row["horaSalidaCuartel"].ToString(),
					row["horaLlegadaEvento"].ToString(),
					row["horaSalidaEvento"].ToString(),
					row["horaLlegadaCuartel"].ToString(),
					int.Parse(row["fk_idCarroMaterial"].ToString()),
					int.Parse(row["fk_idEventoMaterial"].ToString()),
					float.Parse(row["kilometrajeSalida"].ToString()),
					float.Parse(row["kilometrajeLlegada"].ToString())
				);
				MaterialMayors.Add(MaterialMayor);
			}
			return MaterialMayors;
		}

		public ObservableCollection<MaterialMayor> ObtenerMaterialMayor(int idCarroEvento)
		{
			ObservableCollection<MaterialMayor> MaterialMayors = new ObservableCollection<MaterialMayor>();
			query = String.Format(
				"SELECT * FROM MaterialMayor WHERE idCarroEvento = {0}",
				idCarroEvento);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				MaterialMayor MaterialMayor = new MaterialMayor(
					int.Parse(row["idCarroEvento"].ToString()),
					row["conductor"].ToString(),
					row["oficialCargo"].ToString(),
					row["horaSalidaCuartel"].ToString(),
					row["horaLlegadaEvento"].ToString(),
					row["horaSalidaEvento"].ToString(),
					row["horaLlegadaCuartel"].ToString(),
					int.Parse(row["fk_idCarroMaterial"].ToString()),
					int.Parse(row["fk_idEventoMaterial"].ToString()),
					float.Parse(row["kilometrajeSalida"].ToString()),
					float.Parse(row["kilometrajeLlegada"].ToString())
				);
				MaterialMayors.Add(MaterialMayor);
			}
			return MaterialMayors;
		}

        public ObservableCollection<MaterialMayor> ObtenerMaterialMayorEvento(int idEvento)
        {
            ObservableCollection<MaterialMayor> MaterialMayors = new ObservableCollection<MaterialMayor>();
            query = String.Format(
                "SELECT * FROM MaterialMayor WHERE fk_idEventoMaterial = {0}",
                idEvento);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                MaterialMayor MaterialMayor = new MaterialMayor(
                    int.Parse(row["idCarroEvento"].ToString()),
                    row["conductor"].ToString(),
                    row["oficialCargo"].ToString(),
                    row["horaSalidaCuartel"].ToString(),
                    row["horaLlegadaEvento"].ToString(),
                    row["horaSalidaEvento"].ToString(),
                    row["horaLlegadaCuartel"].ToString(),
                    int.Parse(row["fk_idCarroMaterial"].ToString()),
                    int.Parse(row["fk_idEventoMaterial"].ToString()),
                    float.Parse(row["kilometrajeSalida"].ToString()),
                    float.Parse(row["kilometrajeLlegada"].ToString())
                );
                MaterialMayors.Add(MaterialMayor);
            }
            return MaterialMayors;
        }
        public bool ExisteMaterialMayor(int idCarro, int idEvento)
        {
            bool var = false;
            query = String.Format(
                "SELECT * FROM MaterialMayor WHERE fk_idEventoMaterial = {0} and fk_idCarroMaterial = {1}",
                idEvento,
                idCarro);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var = true;
            }
            return var;
        }
        public void IniciarId()
		{
			query = "SELECT * FROM MaterialMayor ORDER BY idCarroEvento DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idCarroEvento = int.Parse(row[0].ToString()) + 1;
			}
		}


        #endregion
    }
}





