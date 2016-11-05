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
    class FormularioCarroViewModel : ViewModelBase
    {
        private ObservableCollection<Carro> _Carros;
        private Carro _Carro;
        private ICommand _GuardarCarroCommand;
        private string modo;
        private int idCarroActual;
        private Carro model = new Carro();

        public Action CloseAction { get; set; }

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
            get
            {
                return _Carros;
            }
            set
            {
                _Carros = value;
                OnPropertyChanged("Carros");
            }
        }

        public ICommand GuardarCarroCommand
        {
            get
            {
                _GuardarCarroCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarCarro()
                };
                return _GuardarCarroCommand;
            }
        }

        public FormularioCarroViewModel(ObservableCollection<Carro> Carros)
        {
            this.modo = "agregar";
            this.Carros = Carros;
            Carro = new Carro();
            Carro.IniciarId();
        }
        public FormularioCarroViewModel(ObservableCollection<Carro> Carros, Carro Carro)
        {
            this.idCarroActual = Carro.idCarro;
            this.modo = "editar";
            this.Carros = Carros;
            this.Carro = Carro;
        }

        private void GuardarCarro()
        {
            if (this.modo.Equals("agregar"))
            {
                model.AgregarCarro(Carro);
                Carros.Add(Carro);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                model.EditarCarro(Carro, this.idCarroActual);
                CloseAction();
            }
        }
    }
}
