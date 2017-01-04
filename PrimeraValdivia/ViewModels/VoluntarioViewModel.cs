using System;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Input;
using PrimeraValdivia.Helpers;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace PrimeraValdivia.ViewModels
{
    class VoluntarioViewModel : ViewModelBase
    {
        #region Variables privadas

        private Voluntario _Voluntario;
        private ObservableCollection<Voluntario> _Voluntarios;
        private ICommand _AgregarVoluntarioCommand;
        private ICommand _MostrarFormularioVoluntarioCommand;
        private ICommand _EliminarVoluntarioCommand;
        private Utils utils = new Utils();
        private Voluntario model = new Voluntario();

        private bool _Loading = false;

        #endregion

        #region Propiedades/Comandos públicos

        public bool Loading
        {
            get { return _Loading; }
            set
            {
                _Loading = value;
                OnPropertyChanged("Loading");
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

        public ICommand MostrarFormularioVoluntarioCommand
        {
            get
            {
                _MostrarFormularioVoluntarioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => MostrarVoluntario()
                };
                return _MostrarFormularioVoluntarioCommand;
            }
        }
        public ICommand EliminarVoluntarioCommand
        {
            get
            {
                _EliminarVoluntarioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarVoluntario()
                };
                return _EliminarVoluntarioCommand;
            }
        }
        #endregion

        #region Constructor/Métodos

        public VoluntarioViewModel()
        {
            Voluntarios = model.ObtenerVoluntarios();
        }

        private void AgregarVoluntario()
        {
            var voluntario = new Voluntario();

            var view = new FormularioVoluntario();
            var viewmodel = new FormularioVoluntarioViewModel(Voluntarios, view);
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void EliminarVoluntario()
        {
            model.EliminarVoluntario(Voluntario.idVoluntario);
            Voluntarios.Remove(Voluntario);
        }

        private void MostrarVoluntario()
        {
            this.Loading = true;
            var view = new FormularioVoluntario();
            var viewmodel = new FormularioVoluntarioViewModel(Voluntarios, Voluntario, view);
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
            this.Loading = false;
        }

        #endregion
    }
}
