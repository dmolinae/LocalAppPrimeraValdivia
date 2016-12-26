using PrimeraValdivia.Commands;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class CarroViewModel : ViewModelBase
    {
        #region Variables privadas

        private Carro _Carro;
        private ObservableCollection<Carro> _Carros;
        private ICommand _AgregarCarroCommand;
        private ICommand _MostrarFormularioCarroCommand;
        private ICommand _EliminarCarroCommand;
        private ICommand _ActualizarCommand;
        private Utils utils = new Utils();
        private Carro model = new Carro();

        #endregion

        #region Propiedades/Comandos públicos

        public Carro Carro
        {
            get { return _Carro; }
            set
            {
                _Carro = value;
                OnPropertyChanged("Carro");
            }
        }
        public ObservableCollection<Carro> Carros
        {
            get { return _Carros; }
            set
            {
                _Carros = value;
                OnPropertyChanged("Carros");
            }
        }
        public ICommand AgregarCarroCommand
        {
            get
            {
                _AgregarCarroCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarCarro()
                };
                return _AgregarCarroCommand;
            }
        }
        public ICommand MostrarFormularioCarroCommand
        {
            get
            {
                _MostrarFormularioCarroCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => MostrarCarro()
                };
                return _MostrarFormularioCarroCommand;
            }
        }

        public ICommand EliminarCarroCommand
        {
            get
            {
                _EliminarCarroCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarCarro()
                };
                return _EliminarCarroCommand;
            }
        }
        public ICommand ActualizarCommand
        {
            get
            {
                _ActualizarCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => Actualizar()
                };
                return _ActualizarCommand;
            }
        }
        #endregion

        #region Constructor/Métodos

        public CarroViewModel()
        {
            Carros = model.ObtenerCarros();
        }

        private void AgregarCarro()
        {
            var Carro = new Carro();

            var viewmodel = new FormularioCarroViewModel(Carros);
            var view = new FormularioCarro();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void EliminarCarro()
        {
            model.EliminarCarro(Carro.idCarro);
            Carros.Remove(Carro);
        }

        private void MostrarCarro()
        {
            var viewmodel = new FormularioCarroViewModel(Carros, Carro);
            var view = new FormularioCarro();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void Actualizar()
        {
            Carros = model.ObtenerCarros();
        }

        #endregion
    }
}
