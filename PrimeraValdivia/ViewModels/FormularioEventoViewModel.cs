using PrimeraValdivia.Commands;
using PrimeraValdivia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class FormularioEventoViewModel : ViewModelBase
    {
        private ObservableCollection<Evento> _Eventos;
        private Evento _Evento;
        private ICommand _GuardarEventoCommand;

        public Action CloseAction { get; set; }

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

        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos)
        {
            this.Eventos = Eventos;
            Evento = new Evento();
        }

        private void GuardarEvento()
        {
            Eventos.Add(Evento);
            CloseAction();
        }
    }
}
