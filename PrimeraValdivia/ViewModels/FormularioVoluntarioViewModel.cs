using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Commands;
using System.Diagnostics;
using System.Windows;

namespace PrimeraValdivia.ViewModels
{
    class FormularioVoluntarioViewModel : ViewModelBase
    {
        private ObservableCollection<Voluntario> _Voluntarios;
        private Voluntario _Voluntario;
        private ICommand _AgregarVoluntarioCommand;

        public Action CloseAction { get; set; }

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

        public ICommand AgregarVoluntarioCommand
        {
            get
            {
                _AgregarVoluntarioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarVoluntario()
                };
                return _AgregarVoluntarioCommand;
            }
        }

        public FormularioVoluntarioViewModel(ObservableCollection<Voluntario> Voluntarios)
        {
            this.Voluntarios = Voluntarios;
            Voluntario = new Voluntario();
        }

        private void AgregarVoluntario()
        {
            Voluntarios.Add(Voluntario);
            CloseAction();
        }
    }
}
