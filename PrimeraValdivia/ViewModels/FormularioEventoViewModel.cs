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
        private Voluntario _Voluntario;
        private ObservableCollection<Voluntario> _Voluntarios;
        private ObservableCollection<Voluntario> _Asistentes;
        private ObservableCollection<Evento> _Eventos;
        private Evento _Evento;
        private ICommand _GuardarEventoCommand;
        private ICommand _AvanzarInformeUnoCommand;
        private string _tab2header = "Datos";
        private bool _tab2enabled = false;
        private bool _tab3enabled = false;
        private int _tabIndex;
        private CollectionViewSource CVS { get; set; }


        private Voluntario voluntarioModel = new Voluntario();

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

        public ObservableCollection<Voluntario> Asistentes
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
            Voluntarios = voluntarioModel.ObtenerVoluntarios();
        }
        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos, Evento Evento)
        {
            this.Evento = Evento;
            Voluntarios = voluntarioModel.ObtenerVoluntarios();
            tab2enabled = true;
            tab3enabled = true;
            DeterminarClaveServicio();
        }
        private void GuardarEvento()
        {
            Eventos.Add(Evento);
            CloseAction();
        }
        private void DeterminarClaveServicio()
        {
            if (Evento.claveServicio.Equals("02"))
            {
                tab2header = "Datos Incendio";
                tab2enabled = true;
            }
            else if (Evento.claveServicio.Equals("03"))
            {
                tab2header = "Datos Rescate";
                tab2enabled = true;
            }
        }
        private void AvanzarInformeUno()
        {
            DeterminarClaveServicio();
            tabIndex = 1;
            Debug.Write(tabIndex);
        }

    }
}
