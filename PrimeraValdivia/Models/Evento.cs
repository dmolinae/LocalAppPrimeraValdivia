

using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Evento : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos
        
		private int _idEvento;
		public int idEvento
		{
			get { return _idEvento; }
			set
			{
				_idEvento = value;
				OnPropertyChanged("idEvento");
			}
		}

		private int _correlativoLlamado;
		public int correlativoLlamado
		{
			get { return _correlativoLlamado; }
			set
			{
				_correlativoLlamado = value;
				OnPropertyChanged("correlativoLlamado");
			}
		}

		private int _correlativoCBV;
		public int correlativoCBV
		{
			get { return _correlativoCBV; }
			set
			{
				_correlativoCBV = value;
				OnPropertyChanged("correlativoCBV");
			}
		}

		private String _claveServicio;
		public String claveServicio
		{
			get { return _claveServicio; }
			set
			{
				_claveServicio = value;
				OnPropertyChanged("claveServicio");
			}
		}

        private DateTime _fecha = DateTime.Now;
		public DateTime fecha
		{
			get { return _fecha; }
			set
			{
				_fecha = value;
				OnPropertyChanged("fecha");
			}
		}

		private String _motivo;
		public String motivo
		{
			get { return _motivo; }
			set
			{
				_motivo = value;
				OnPropertyChanged("motivo");
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

		private String _calleProxima;
		public String calleProxima
		{
			get { return _calleProxima; }
			set
			{
				_calleProxima = value;
				OnPropertyChanged("calleProxima");
			}
		}

		private String _sector;
		public String sector
		{
			get { return _sector; }
			set
			{
				_sector = value;
				OnPropertyChanged("sector");
			}
		}

		private String _poblacion;
		public String poblacion
		{
			get { return _poblacion; }
			set
			{
				_poblacion = value;
				OnPropertyChanged("poblacion");
			}
		}

		private String _ruta;
		public String ruta
		{
			get { return _ruta; }
			set
			{
				_ruta = value;
				OnPropertyChanged("ruta");
			}
		}

		private int _kilometroRuta;
		public int kilometroRuta
		{
			get { return _kilometroRuta; }
			set
			{
				_kilometroRuta = value;
				OnPropertyChanged("kilometroRuta");
			}
		}

		private String _bomberoCargo;
		public String bomberoCargo
		{
			get { return _bomberoCargo; }
			set
			{
				_bomberoCargo = value;
				OnPropertyChanged("bomberoCargo");
			}
		}

		private String _bomberoInforme;
		public String bomberoInforme
		{
			get { return _bomberoInforme; }
			set
			{
				_bomberoInforme = value;
				OnPropertyChanged("bomberoInforme");
			}
		}

		private String _codigoCargo;
		public String codigoCargo
		{
			get { return _codigoCargo; }
			set
			{
				_codigoCargo = value;
				OnPropertyChanged("codigoCargo");
			}
		}

		private String _codigoInforme;
		public String codigoInforme
		{
			get { return _codigoInforme; }
			set
			{
				_codigoInforme = value;
				OnPropertyChanged("codigoInforme");
			}
		}

		private String _numeroDepartamento;
		public String numeroDepartamento
		{
			get { return _numeroDepartamento; }
			set
			{
				_numeroDepartamento = value;
				OnPropertyChanged("numeroDepartamento");
			}
		}

		private String _numeroBlock;
		public String numeroBlock
		{
			get { return _numeroBlock; }
			set
			{
				_numeroBlock = value;
				OnPropertyChanged("numeroBlock");
			}
		}

		private String _resumen;
		public String resumen
		{
			get { return _resumen; }
			set
			{
				_resumen = value;
				OnPropertyChanged("resumen");
			}
		}

		private String _codigoServicio;
		public String codigoServicio
		{
			get { return _codigoServicio; }
			set
			{
				_codigoServicio = value;
				OnPropertyChanged("codigoServicio");
			}
		}

		private bool _asistenciaObligatoria;
		public bool asistenciaObligatoria
		{
			get { return _asistenciaObligatoria; }
			set
			{
				_asistenciaObligatoria = value;
				OnPropertyChanged("asistenciaObligatoria");
			}
		}


        #endregion

        #region Metodos

        public Evento()
        {

        }

        public Evento(int idEvento, int correlativoLlamado, int correlativoCBV, String claveServicio, DateTime fecha, String motivo, String calle, int numeroCalle, String calleProxima, String sector, String poblacion, String ruta, int kilometroRuta, String bomberoCargo, String bomberoInforme, String codigoCargo, String codigoInforme, String numeroDepartamento, String numeroBlock, String resumen, String codigoServicio, bool asistenciaObligatoria)
		{
			this.idEvento = idEvento;
			this.correlativoLlamado = correlativoLlamado;
			this.correlativoCBV = correlativoCBV;
			this.claveServicio = claveServicio;
			this.fecha = fecha;
			this.motivo = motivo;
			this.calle = calle;
			this.numeroCalle = numeroCalle;
			this.calleProxima = calleProxima;
			this.sector = sector;
			this.poblacion = poblacion;
			this.ruta = ruta;
			this.kilometroRuta = kilometroRuta;
			this.bomberoCargo = bomberoCargo;
			this.bomberoInforme = bomberoInforme;
			this.codigoCargo = codigoCargo;
			this.codigoInforme = codigoInforme;
			this.numeroDepartamento = numeroDepartamento;
			this.numeroBlock = numeroBlock;
			this.resumen = resumen;
			this.codigoServicio = codigoServicio;
			this.asistenciaObligatoria = asistenciaObligatoria;
		}

        public void AgregarEvento(Evento Evento)
		{
			query = String.Format(
				"INSERT INTO Evento(idEvento,correlativoLlamado,correlativoCBV,claveServicio,fecha,motivo,calle,numeroCalle,calleProxima,sector,poblacion,ruta,kilometroRuta,bomberoCargo,bomberoInforme,codigoCargo,codigoInforme,numeroDepartamento,numeroBlock,resumen,codigoServicio,asistenciaObligatoria) VALUES({0},{1},{2},'{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}',{21})",
				Evento.idEvento,
				Evento.correlativoLlamado,
				Evento.correlativoCBV,
				Evento.claveServicio,
				Evento.fecha,
				Evento.motivo,
				Evento.calle,
				Evento.numeroCalle,
				Evento.calleProxima,
				Evento.sector,
				Evento.poblacion,
				Evento.ruta,
				Evento.kilometroRuta,
				Evento.bomberoCargo,
				Evento.bomberoInforme,
				Evento.codigoCargo,
				Evento.codigoInforme,
				Evento.numeroDepartamento,
				Evento.numeroBlock,
				Evento.resumen,
				Evento.codigoServicio,
				(Evento.asistenciaObligatoria)? 1 : 0
				);
			utils.ExecuteNonQuery(query);
		}

        public void EditarEvento(Evento Evento, int idEvento)
		{
			query = String.Format(
				"UPDATE Evento SET idEvento = {0}, correlativoLlamado = {1}, correlativoCBV = {2}, claveServicio = '{3}', fecha = '{4}', motivo = '{5}', calle = '{6}', numeroCalle = {7}, calleProxima = '{8}', sector = '{9}', poblacion = '{10}', ruta = '{11}', kilometroRuta = {12}, bomberoCargo = '{13}', bomberoInforme = '{14}', codigoCargo = '{15}', codigoInforme = '{16}', numeroDepartamento = '{17}', numeroBlock = '{18}', resumen = '{19}', codigoServicio = '{20}', asistenciaObligatoria = {21} WHERE idEvento = {22}",
				Evento.idEvento,
				Evento.correlativoLlamado,
				Evento.correlativoCBV,
				Evento.claveServicio,
				Evento.fecha,
				Evento.motivo,
				Evento.calle,
				Evento.numeroCalle,
				Evento.calleProxima,
				Evento.sector,
				Evento.poblacion,
				Evento.ruta,
				Evento.kilometroRuta,
				Evento.bomberoCargo,
				Evento.bomberoInforme,
				Evento.codigoCargo,
				Evento.codigoInforme,
				Evento.numeroDepartamento,
				Evento.numeroBlock,
				Evento.resumen,
				Evento.codigoServicio,
				(Evento.asistenciaObligatoria)? 1 : 0,
				idEvento
				);
			utils.ExecuteNonQuery(query);
		}

		public void EliminarEvento(int idEvento)
		{
			query = String.Format(
				"DELETE FROM Evento WHERE idEvento = {0}",
				idEvento);
			utils.ExecuteNonQuery(query);
            query = String.Format(
                "DELETE FROM Asistencia WHERE fk_idEvento = {0}",
                idEvento);
            utils.ExecuteNonQuery(query);
		}

        public ObservableCollection<Evento> ObtenerEventos()
		{
			ObservableCollection<Evento> Eventos = new ObservableCollection<Evento>();
			query = " SELECT * FROM Evento";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Evento Evento = new Evento(
					int.Parse(row["idEvento"].ToString()),
					int.Parse(row["correlativoLlamado"].ToString()),
					int.Parse(row["correlativoCBV"].ToString()),
					row["claveServicio"].ToString(),
					DateTime.Parse(row["fecha"].ToString()),
					row["motivo"].ToString(),
					row["calle"].ToString(),
					int.Parse(row["numeroCalle"].ToString()),
					row["calleProxima"].ToString(),
					row["sector"].ToString(),
					row["poblacion"].ToString(),
					row["ruta"].ToString(),
					int.Parse(row["kilometroRuta"].ToString()),
					row["bomberoCargo"].ToString(),
					row["bomberoInforme"].ToString(),
					row["codigoCargo"].ToString(),
					row["codigoInforme"].ToString(),
					row["numeroDepartamento"].ToString(),
					row["numeroBlock"].ToString(),
					row["resumen"].ToString(),
					row["codigoServicio"].ToString(),
					bool.Parse(row["asistenciaObligatoria"].ToString())
				);
				Eventos.Add(Evento);
			}
			return Eventos;
		}

		public ObservableCollection<Evento> ObtenerEvento(int idEvento)
		{
			ObservableCollection<Evento> Eventos = new ObservableCollection<Evento>();
			query = String.Format(
				"SELECT * FROM Evento WHERE idEvento = {0}",
				idEvento);
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				Evento Evento = new Evento(
					int.Parse(row["idEvento"].ToString()),
					int.Parse(row["correlativoLlamado"].ToString()),
					int.Parse(row["correlativoCBV"].ToString()),
					row["claveServicio"].ToString(),
					DateTime.Parse(row["fecha"].ToString()),
					row["motivo"].ToString(),
					row["calle"].ToString(),
					int.Parse(row["numeroCalle"].ToString()),
					row["calleProxima"].ToString(),
					row["sector"].ToString(),
					row["poblacion"].ToString(),
					row["ruta"].ToString(),
					int.Parse(row["kilometroRuta"].ToString()),
					row["bomberoCargo"].ToString(),
					row["bomberoInforme"].ToString(),
					row["codigoCargo"].ToString(),
					row["codigoInforme"].ToString(),
					row["numeroDepartamento"].ToString(),
					row["numeroBlock"].ToString(),
					row["resumen"].ToString(),
					row["codigoServicio"].ToString(),
					bool.Parse(row["asistenciaObligatoria"].ToString())
				);
				Eventos.Add(Evento);
			}
			return Eventos;
		}

        public ObservableCollection<Evento> ObtenerEventoPorFecha(string fecha,string fecha2)
        {
            ObservableCollection<Evento> Eventos = new ObservableCollection<Evento>();
            query = String.Format(
                "SELECT * FROM Evento WHERE date(substr(fecha,7,4)||substr(fecha,4,2)||substr(fecha,1,2)) between DATE('{0}') and DATE('{1}')",
                fecha,fecha2);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Evento Evento = new Evento(
                    int.Parse(row["idEvento"].ToString()),
                    int.Parse(row["correlativoLlamado"].ToString()),
                    int.Parse(row["correlativoCBV"].ToString()),
                    row["claveServicio"].ToString(),
                    DateTime.Parse(row["fecha"].ToString()),
                    row["motivo"].ToString(),
                    row["calle"].ToString(),
                    int.Parse(row["numeroCalle"].ToString()),
                    row["calleProxima"].ToString(),
                    row["sector"].ToString(),
                    row["poblacion"].ToString(),
                    row["ruta"].ToString(),
                    int.Parse(row["kilometroRuta"].ToString()),
                    row["bomberoCargo"].ToString(),
                    row["bomberoInforme"].ToString(),
                    row["codigoCargo"].ToString(),
                    row["codigoInforme"].ToString(),
                    row["numeroDepartamento"].ToString(),
                    row["numeroBlock"].ToString(),
                    row["resumen"].ToString(),
                    row["codigoServicio"].ToString(),
                    bool.Parse(row["asistenciaObligatoria"].ToString())
                );
                Eventos.Add(Evento);
            }
            return Eventos;
        }

        public void IniciarId()
		{
			query = "SELECT * FROM Evento ORDER BY idEvento DESC LIMIT 1";
			DataTable dt = utils.ExecuteQuery(query);
			foreach (DataRow row in dt.Rows)
			{
				this.idEvento = int.Parse(row[0].ToString()) + 1;
			}
		}
        #endregion
    }
}





