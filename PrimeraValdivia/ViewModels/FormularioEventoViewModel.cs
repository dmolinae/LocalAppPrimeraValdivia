using PrimeraValdivia.Commands;
using PrimeraValdivia.Helpers;
using PrimeraValdivia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class FormularioEventoViewModel : ViewModelBase
    {
        #region Atributos privados

        private Voluntario _Voluntario;
        private Asistencia _Asistente;
        private Voluntario _VoluntarioCargo;
        private Voluntario _VoluntarioInforme;
        private ObservableCollection<Voluntario> _Voluntarios;
        private ObservableCollection<Asistencia> _Asistentes;
        private ObservableCollection<Evento> _Eventos;
        private Evento _Evento;
        private ICommand _GuardarEventoCommand;
        private ICommand _AvanzarInformeUnoCommand;
        private ICommand _AgregarAsistenciaCommand;
        private ICommand _EditarAsistenciaCommand;
        private string _tab2header = "Datos";
        private bool _tab2enabled = false;
        private bool _tab3enabled = false;
        private bool _aChecked = true;
        private bool _fChecked;
        private bool _lChecked;
        private int _tabIndex;
        private CollectionViewSource CVS { get; set; }

        private Asistencia asistenciaModel = new Asistencia();
        private Voluntario voluntarioModel = new Voluntario();

        #endregion

        #region Atributos publicos

        public Action CloseAction { get; set; }

        public int tabIndex
        {
            get { return _tabIndex; }
            set
            {
                _tabIndex = value;
                OnPropertyChanged("tabIndex");
            }
        }

        public string tab2header
        {
            get { return _tab2header; }
            set
            {
                _tab2header = value;
                OnPropertyChanged("tab2header");
            }
        }
        

        public bool tab2enabled
        {
            get { return _tab2enabled; }
            set
            {
                _tab2enabled = value;
                OnPropertyChanged("tab2enabled");
            }
        }
        public bool tab3enabled
        {
            get { return _tab3enabled; }
            set
            {
                _tab3enabled = value;
                OnPropertyChanged("tab2enabled");
            }
        }
        public bool aChecked
        {
            get { return _aChecked; }
            set
            {
                _aChecked = value;
                OnPropertyChanged("aChecked");
            }
        }
        public bool fChecked
        {
            get { return _fChecked; }
            set
            {
                _fChecked = value;
                OnPropertyChanged("fChecked");
            }
        }
        public bool lChecked
        {
            get { return _lChecked; }
            set
            {
                _lChecked = value;
                OnPropertyChanged("lChecked");
            }
        }

        public Evento Evento
        {
            get { return _Evento; }
            set
            {
                _Evento = value;
                OnPropertyChanged("Evento");
            }
        }

        public ObservableCollection<Evento> Eventos
        {
            get
            {
                return _Eventos;
            }
            set
            {
                _Eventos = value;
                OnPropertyChanged("Eventos");
            }
        }

        public Voluntario Voluntario
        {
            get { return _Voluntario; }
            set
            {
                _Voluntario = value;
                OnPropertyChanged("Voluntario");
            }
        }
        public Voluntario VoluntarioCargo
        {
            get { return _VoluntarioCargo; }
            set
            {
                _VoluntarioCargo = value;
                OnPropertyChanged("VoluntarioCargo");
                this.Evento.codigoCargo = VoluntarioCargo.codigoRadial;
            }
        }
        public Voluntario VoluntarioInforme
        {
            get { return _VoluntarioInforme; }
            set
            {
                _VoluntarioInforme = value;
                OnPropertyChanged("VoluntarioInforme");
                this.Evento.codigoInforme = VoluntarioInforme.codigoRadial;
            }
        }
        public Asistencia Asistente
        {
            get { return _Asistente; }
            set
            {
                _Asistente = value;
                OnPropertyChanged("Asistente");
            }
        }

        public ObservableCollection<Voluntario> Voluntarios
        {
            get
            {
                return _Voluntarios;
            }
            set
            {
                _Voluntarios = value;
                OnPropertyChanged("Voluntarios");
            }
        }

        public ObservableCollection<Asistencia> Asistentes
        {
            get
            {
                return _Asistentes;
            }
            set
            {
                _Asistentes = value;
                OnPropertyChanged("Voluntarios");
            }
        }

        public ICommand GuardarEventoCommand
        {
            get
            {
                _GuardarEventoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarEvento()
                };
                return _GuardarEventoCommand;
            }
        }
        public ICommand AvanzarInformeUnoCommand
        {
            get
            {
                _AvanzarInformeUnoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => ValidarCampos(),
                    ExecuteDelegate = c => AvanzarInformeUno()
                };
                return _AvanzarInformeUnoCommand;
            }
        }
        public ICommand AgregarAsistenciaCommand
        {
            get
            {
                _AgregarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarAsistencia()
                };
                return _AgregarAsistenciaCommand;
            }
        }
        public ICommand EditarAsistenciaCommand
        {
            get
            {
                _EditarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarAsistencia()
                };
                return _EditarAsistenciaCommand;
            }
        }

        #endregion

        #region Metodos

        private void AgregarAsistencia()
        {
            string codigo = "";
            if (Evento.asistenciaObligatoria)
            {
                if (aChecked) codigo = "A";
                if (fChecked) codigo = "F";
                if (lChecked) codigo = "L";
            }
            else
            {
                if (aChecked) codigo = "a";
                if (fChecked) codigo = " ";
                if (lChecked) codigo = " ";
            }

            Asistencia Asistencia = new Asistencia(Voluntario.rut,Evento.idEvento,codigo,Evento.asistenciaObligatoria);
            if (asistenciaModel.ExisteAsistencia(Asistencia))
            {
                
            }
            else
            {
                asistenciaModel.AgregarAsistencia(Asistencia);
                Asistentes.Insert(0, Asistencia);
            }
            
        }

        private void EditarAsistencia()
        {
            string codigo = "";
            if (Evento.asistenciaObligatoria)
            {
                if (aChecked) codigo = "A";
                if (fChecked) codigo = "F";
                if (lChecked) codigo = "L";
            }
            else
            {
                if (aChecked) codigo = "a";
                if (fChecked) codigo = " ";
                if (lChecked) codigo = " ";
            }
            Asistente.codigoAsistencia = codigo;
            Asistente.asistenciaObligatoria = Evento.asistenciaObligatoria;
            asistenciaModel.EditarAsistencia(Asistente);
            
        }

        private bool ValidarCampos()
        {
            if (Evento.claveServicio == null || Evento.claveServicio.Length == 0) return false;
            else return true;
        }

        private void Handle_ViewCollectionViewSourceMessageToken(ViewCollectionViewSourceMessageToken token)
        {
            CVS = token.CVS;
        }

        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos)
        {
            this.Eventos = Eventos;
            Evento = new Evento();
            Evento.IniciarId();
            Voluntarios = voluntarioModel.ObtenerVoluntarios();
            Asistentes = new ObservableCollection<Asistencia>();
        }
        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos, Evento Evento)
        {
            this.Evento = Evento;
            Voluntarios = voluntarioModel.ObtenerVoluntarios();
            tab2enabled = true;
            tab3enabled = true;
            DeterminarClaveServicio();
            Asistentes = asistenciaModel.ObtenerAsistentesEvento(Evento.idEvento);
        }
        private void GuardarEvento()
        {
            Eventos.Add(Evento);
            CloseAction();
        }
        private void DeterminarClaveServicio()
        {
            if (Evento.codigoServicio.Equals("02"))
            {
                tab2header = "Datos Incendio";
                tab2enabled = true;
            }
            else if (Evento.codigoServicio.Equals("03"))
            {
                tab2header = "Datos Rescate";
                tab2enabled = true;
            }
        }
        private void AvanzarInformeUno()
        {
            var model = new Evento();
            DeterminarClaveServicio();
            tabIndex = 3;
            Eventos.Add(Evento);
            model.AgregarEvento(Evento);
        }

        #endregion

    }
}
