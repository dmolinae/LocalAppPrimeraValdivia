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
            Eventos = new ObservableCollection<Evento>();
            Eventos.Add(new Evento
            {
                idEvento = 0,
                correlativoLlamado = 2,
                correlativoCBV = 1,
                claveServicio = "02",
                fecha = DateTime.Now,
                calle = "General Lagos",
                numeroCalle = "1618",
                resumen = "Perro ladra todo el puto dia y no deja dormir ni estudiar a nadie"
            });
            Eventos.Add(new Evento
            {
                idEvento = 1,
                correlativoLlamado = 2,
                correlativoCBV = 2,
                claveServicio = "02",
                fecha = DateTime.Now,
                calle = "General Lagos",
                numeroCalle = "1618",
                resumen = "Perro ladra todo el puto dia y no deja dormir ni estudiar a nadie"
            });
            Eventos.Add(new Evento
            {
                idEvento = 2,
                correlativoLlamado = 1,
                correlativoCBV = 3,
                claveServicio = "03",
                fecha = DateTime.Now,
                calle = "General Lagos",
                numeroCalle = "1618",
                resumen = "Perro ladra todo el puto dia y no deja dormir ni estudiar a nadie"
            });
        }

        private void AgregarEvento()
        {
            var Evento = new Evento();
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
