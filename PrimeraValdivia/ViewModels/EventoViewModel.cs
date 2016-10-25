using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Commands;
using PrimeraValdivia.Views;
using System.Diagnostics;

namespace PrimeraValdivia.ViewModels
{
    class EventoViewModel : ViewModelBase
    {
        #region Variables privadas

        private Evento _Evento;
        private ObservableCollection<Evento> _Eventos;
        private ICommand _AgregarEventoCommand;
        private ICommand _MostrarFormularioEventoCommand;
        private Evento model = new Evento();

        #endregion

        #region Propiedades/Comandos públicos

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

        public ICommand AgregarEventoCommand
        {
            get
            {
                _AgregarEventoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarEvento()
                };
                return _AgregarEventoCommand;
            }
        }

        public ICommand MostrarFormularioEventoCommand
        {
            get
            {
                _MostrarFormularioEventoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => MostrarEvento()
                };
                return _MostrarFormularioEventoCommand;
            }
        }

        #endregion

        #region Constructor/Métodos

        public EventoViewModel()
        {
            Eventos = model.ObtenerEventos();
        }

        private void AgregarEvento()
        {
            var viewmodel = new FormularioEventoViewModel(Eventos);
            var view = new FormularioEvento();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void MostrarEvento()
        {
            var viewmodel = new FormularioEventoViewModel(Eventos,Evento);
            var view = new FormularioEvento();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        #endregion
    }
}
