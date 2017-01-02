

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
    class Incendio : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idIncendio;
		public int idIncendio
		{
			get { return _idIncendio; }
			set
			{
				_idIncendio = value;
				OnPropertyChanged("idIncendio");
			}
		}

		private String _tipoIncendio;
		public String tipoIncendio
		{
			get { return _tipoIncendio; }
			set
			{
				_tipoIncendio = value;
				OnPropertyChanged("tipoIncendio");
			}
		}

		private String _faseIncendio;
		public String faseIncendio
		{
			get { return _faseIncendio; }
			set
			{
				_faseIncendio = value;
				OnPropertyChanged("faseIncendio");
			}
		}

		private bool _det;
		public bool det
		{
			get { return _det; }
			set
			{
				_det = value;
				OnPropertyChanged("det");
			}
		}

		private String _bomberoDet;
		public String bomberoDet
		{
			get { return _bomberoDet; }
			set
			{
				_bomberoDet = value;
				OnPropertyChanged("bomberoDet");
			}
		}

		private String _origen;
		public String origen
		{
			get { return _origen; }
			set
			{
				_origen = value;
				OnPropertyChanged("origen");
			}
		}

		private String _causa;
		public String causa
		{
			get { return _causa; }
			set
			{
				_causa = value;
				OnPropertyChanged("causa");
			}
		}

		private String _fuenteCalor;
		public String fuenteCalor
		{
			get { return _fuenteCalor; }
			set
			{
				_fuenteCalor = value;
				OnPropertyChanged("fuenteCalor");
			}
		}

		private String _tipoLugar;
		public String tipoLugar
		{
			get { return _tipoLugar; }
			set
			{
				_tipoLugar = value;
				OnPropertyChanged("tipoLugar");
			}
		}

		private String _tipoConstruccion;
		public String tipoConstruccion
		{
			get { return _tipoConstruccion; }
			set
			{
				_tipoConstruccion = value;
				OnPropertyChanged("tipoConstruccion");
			}
		}

		private int _fk_idEventoInc;
		public int fk_idEventoInc
		{
			get { return _fk_idEventoInc; }
			set
			{
				_fk_idEventoInc = value;
				OnPropertyChanged("fk_idEventoInc");
			}
		}

		private int _numeroPisos;
		public int numeroPisos
		{
			get { return _numeroPisos; }
			set
			{
				_numeroPisos = value;
				OnPropertyChanged("numeroPisos");
			}
		}


        #endregion

        #region Metodos

        public Incendio()
        {

        }

        public Incendio(int idIncendio, String tipoIncendio, String faseIncendio, bool det, String bomberoDet, String origen, String causa, String fuenteCalor, String tipoLugar, String tipoConstruccion, int fk_idEventoInc, int numeroPisos)
		{
			this.idIncendio = idIncendio;
			this.tipoIncendio = tipoIncendio;
			this.faseIncendio = faseIncendio;
			this.det = det;
			this.bomberoDet = bomberoDet;
			this.origen = origen;
			this.causa = causa;
			this.fuenteCalor = fuenteCalor;
			this.tipoLugar = tipoLugar;
			this.tipoConstruccion = tipoConstruccion;
			this.fk_idEventoInc = fk_idEventoInc;
			this.numeroPisos = numeroPisos;
		}

        public void AgregarIncendio(Incendio Incendio)
		{
			query = String.Format(
				"INSERT INTO Incendio(idIncendio,tipoIncendio,faseIncendio,det,bomberoDet,origen,causa,fuenteCalor,tipoLugar,tipoConstruccion,fk_idEventoInc,numeroPisos) VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}',{10},{11})",
				Incendio.idIncendio,
				Incendio.tipoIncendio,
				Incendio.faseIncendio,
				(Incendio.det)? 1 : 0,
				Incendio.bomberoDet,
				Incendio.origen,
				Incendio.causa,
				Incendio.fuenteCalor,
				Incendio.tipoLugar,
				Incendio.tipoConstruccion,
				Incendio.fk_idEventoInc,
				Incendio.numeroPisos
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarIncendio(Incendio Incendio, int idIncendio)
		{
			query = String.Format(
				"UPDATE Incendio SET idIncendio = {0}, tipoIncendio = '{1}', faseIncendio = '{2}', det = {3}, bomberoDet = '{4}', origen = '{5}', causa = '{6}', fuenteCalor = '{7}', tipoLugar = '{8}', tipoConstruccion = '{9}', fk_idEventoInc = {10}, numeroPisos = {11} WHERE idIncendio = {12}",
				Incendio.idIncendio,
				Incendio.tipoIncendio,
				Incendio.faseIncendio,
				(Incendio.det)? 1 : 0,
				Incendio.bomberoDet,
				Incendio.origen,
				Incendio.causa,
				Incendio.fuenteCalor,
				Incendio.tipoLugar,
				Incendio.tipoConstruccion,
				Incendio.fk_idEventoInc,
				Incendio.numeroPisos,
				idIncendio
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarIncendio(int idIncendio)
		{
			query = String.Format(
				"DELETE FROM Incendio WHERE idIncendio = {0}",
				idIncendio);
			utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Incendio> ObtenerIncendios()
		{
			ObservableCollection<Incendio> Incendios = new ObservableCollection<Incendio>();
			query = " SELECT * FROM Incendio";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Incendio Incendio = new Incendio(
					int.Parse(row["idIncendio"].ToString()),
					row["tipoIncendio"].ToString(),
					row["faseIncendio"].ToString(),
					bool.Parse(row["det"].ToString()),
					row["bomberoDet"].ToString(),
					row["origen"].ToString(),
					row["causa"].ToString(),
					row["fuenteCalor"].ToString(),
					row["tipoLugar"].ToString(),
					row["tipoConstruccion"].ToString(),
					int.Parse(row["fk_idEventoInc"].ToString()),
					int.Parse(row["numeroPisos"].ToString())
				);
				Incendios.Add(Incendio);
			}
			return Incendios;
		}

		public ObservableCollection<Incendio> ObtenerIncendio(int idIncendio)
		{
			ObservableCollection<Incendio> Incendios = new ObservableCollection<Incendio>();
			query = String.Format(
				"SELECT * FROM Incendio WHERE idIncendio = {0}",
				idIncendio);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Incendio Incendio = new Incendio(
					int.Parse(row["idIncendio"].ToString()),
					row["tipoIncendio"].ToString(),
					row["faseIncendio"].ToString(),
					bool.Parse(row["det"].ToString()),
					row["bomberoDet"].ToString(),
					row["origen"].ToString(),
					row["causa"].ToString(),
					row["fuenteCalor"].ToString(),
					row["tipoLugar"].ToString(),
					row["tipoConstruccion"].ToString(),
					int.Parse(row["fk_idEventoInc"].ToString()),
					int.Parse(row["numeroPisos"].ToString())
				);
				Incendios.Add(Incendio);
			}
			return Incendios;
		}

        public Incendio ObtenerIncendioEvento(int idEvento)
        {
            Incendio Incendio = new Incendio();
            query = String.Format(
                "SELECT * FROM Incendio WHERE fk_idEventoInc = {0}",
                idEvento);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Incendio = new Incendio(
                    int.Parse(row["idIncendio"].ToString()),
                    row["tipoIncendio"].ToString(),
                    row["faseIncendio"].ToString(),
                    bool.Parse(row["det"].ToString()),
                    row["bomberoDet"].ToString(),
                    row["origen"].ToString(),
                    row["causa"].ToString(),
                    row["fuenteCalor"].ToString(),
                    row["tipoLugar"].ToString(),
                    row["tipoConstruccion"].ToString(),
                    int.Parse(row["fk_idEventoInc"].ToString()),
                    int.Parse(row["numeroPisos"].ToString())
                );
            }
            return Incendio;
        }

        public void IniciarId()
		{
			query = "SELECT * FROM Incendio ORDER BY idIncendio DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idIncendio = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





