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
        private string _claveServicio;
        public string claveServicio
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
        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set
            {
                _motivo = value;
                OnPropertyChanged("motivo");
            }
        }
        private string _calle;
        public string calle
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
        private string _calleProxima;
        public string calleProxima
        {
            get { return _calleProxima; }
            set
            {
                _calleProxima = value;
                OnPropertyChanged("calleProxima");
            }
        }
        private string _sector;
        public string sector
        {
            get { return _sector; }
            set
            {
                _sector = value;
                OnPropertyChanged("sector");
            }
        }
        private string _poblacion;
        public string poblacion
        {
            get { return _poblacion; }
            set
            {
                _poblacion = value;
                OnPropertyChanged("poblacion");
            }
        }
        private string _ruta;
        public string ruta
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
        private string _bomberoCargo;
        public string bomberoCargo
        {
            get { return _bomberoCargo; }
            set
            {
                _bomberoCargo = value;
                OnPropertyChanged("bomberoCargo");
            }
        }
        private string _bomberoInforme;
        public string bomberoInforme
        {
            get { return _bomberoInforme; }
            set
            {
                _bomberoInforme = value;
                OnPropertyChanged("bomberoInforme");
            }
        }
        private string _codigoCargo;
        public string codigoCargo
        {
            get { return _codigoCargo; }
            set
            {
                _codigoCargo = value;
                OnPropertyChanged("codigoCargo");
            }
        }
        private string _codigoInforme;
        public string codigoInforme
        {
            get { return _codigoInforme; }
            set
            {
                _codigoInforme = value;
                OnPropertyChanged("codigoInforme");
            }
        }
        private string _numeroDepartamento;
        public string numeroDepartamento
        {
            get { return _numeroDepartamento; }
            set
            {
                _numeroDepartamento = value;
                OnPropertyChanged("numeroDepartamento");
            }
        }
        private string _numeroBlock;
        public string numeroBlock
        {
            get { return _numeroBlock; }
            set
            {
                _numeroBlock = value;
                OnPropertyChanged("numeroBlock");
            }
        }
        private string _resumen;
        public string resumen
        {
            get { return _resumen; }
            set
            {
                _resumen = value;
                OnPropertyChanged("resumen");
            }
        }
        #endregion

        #region Metodos
        public Evento()
        {
            
        }

        public Evento(int idEvento, int correlativoLlamado, int correlativoCBV, string claveServicio, DateTime fecha, string motivo, string calle, int numeroCalle, string calleProxima, string sector, string poblacion, string ruta, int kilometroRuta, string bomberoCargo, string bomberoInforme, string codigoCargo, string codigoInforme, string numeroDepartamento, string numeroBlock, string resumen)
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
        }

        public void AgregarEvento(Evento Evento)
        {
            query = String.Format(
                "INSERT INTO Evento values({0},{1},{2},'{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
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
                Evento.resumen
                );
            utils.ExecuteNonQuery(query);
        }
        public ObservableCollection<Evento> ObtenerEventos()
        {
            ObservableCollection<Evento> Eventos = new ObservableCollection<Evento>();
            query = "SELECT * FROM Evento";
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Evento eventoActual = new Evento(
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
                    row["resumen"].ToString()
                    );
                Eventos.Add(eventoActual);
            }
            return Eventos;
        }
        public void IniciarId()
        {
            query = "SELECT count(*) FROM Evento";
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                this.idEvento = int.Parse(row[0].ToString());
            }
        }

        #endregion
    }
}
