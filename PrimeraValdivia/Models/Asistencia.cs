using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.Models
{
    class Asistencia : ViewModelBase
    {
        private Utils utils = new Utils();
        private string query;

        #region Atributos

        private int _idAsistencia;
        public int idAsistencia
        {
            get { return _idAsistencia; }
            set
            {
                _idAsistencia = value;
                OnPropertyChanged("idAsistencia");
            }
        }

        private string _fk_rut;
        public string fk_rut
        {
            get { return _fk_rut; }
            set
            {
                _fk_rut = value;
                OnPropertyChanged("fk_rut");
            }
        }
        private int _fk_idEvento;
        public int fk_idEvento
        {
            get { return _fk_idEvento; }
            set
            {
                _fk_idEvento = value;
                OnPropertyChanged("fk_idEvento");
            }
        }
        private string _codigoAsistencia;
        public string codigoAsistencia
        {
            get { return _codigoAsistencia; }
            set
            {
                _codigoAsistencia = value;
                OnPropertyChanged("codigoAsistencia");
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

        public Asistencia()
        {

        }

        public Asistencia(string rut_voluntario, int id_evento, string codigo, bool obligatoria)
        {
            this.fk_rut = rut_voluntario;
            this.fk_idEvento = id_evento;
            this.codigoAsistencia = codigo;
            this.asistenciaObligatoria = obligatoria;
        }

        public void AgregarAsistencia(Asistencia Asistencia)
        {
            query = String.Format(
                "INSERT INTO Asistencia(fk_rut,fk_idEvento,codigoAsistencia,asistenciaObligatoria) values('{0}',{1},'{2}',{3})",
                Asistencia.fk_rut,
                Asistencia.fk_idEvento,
                Asistencia.codigoAsistencia,
                (Asistencia.asistenciaObligatoria) ? 1 : 0
                );
            utils.ExecuteNonQuery(query);
        }

        public ObservableCollection<Asistencia> ObtenerAsistentesEvento(int idEvento)
        {
            ObservableCollection<Asistencia> Asistentes = new ObservableCollection<Asistencia>();
            query = String.Format(
                "SELECT * FROM Asistencia WHERE fk_idEvento = {0}",
                idEvento);
            DataTable dt = utils.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Asistencia Asistente = new Asistencia(
                    row["fk_rut"].ToString(),
                    int.Parse(row["fk_idEvento"].ToString()),
                    row["codigoAsistencia"].ToString(),
                    bool.Parse(row["asistenciaObligatoria"].ToString())
                );
                Asistentes.Add(Asistente);
            }
            return Asistentes;
        }

        #endregion
    }
}
