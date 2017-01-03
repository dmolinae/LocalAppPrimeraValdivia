using PrimeraValdivia.Models;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class FormularioAfectadoRescateViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<Item> _TiposAfectadoRescate;
        private ObservableCollection<Item> _Prioridades;
        private ObservableCollection<Item> _EstadosAfectado;

        private ObservableCollection<AfectadoRescate> _AfectadosRescate;
        private AfectadoRescate _AfectadoRescate;
        private ICommand _GuardarAfectadoRescateCommand;
        private string modo;
        private int idAfectadoRescateActual;

        private AfectadoRescate MModel = new AfectadoRescate();
        private Item IModel = new Item();

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public AfectadoRescate AfectadoRescate
        {
            get { return _AfectadoRescate; }
            set
            {
                _AfectadoRescate = value;
                OnPropertyChanged("AfectadoRescate");
            }
        }

        public ObservableCollection<AfectadoRescate> AfectadosRescate
        {
            get { return _AfectadosRescate; }
            set
            {
                _AfectadosRescate = value;
                OnPropertyChanged("AfectadosRescate");
            }
        }

        public ObservableCollection<Item> TiposAfectadoRescate
        {
            get { return _TiposAfectadoRescate; }
            set
            {
                _TiposAfectadoRescate = value;
                OnPropertyChanged("TiposAfectadoRescate");
            }
        }
        public ObservableCollection<Item> Prioridades
        {
            get { return _Prioridades; }
            set
            {
                _Prioridades = value;
                OnPropertyChanged("Prioridades");
            }
        }
        public ObservableCollection<Item> EstadosAfectado
        {
            get { return _EstadosAfectado; }
            set
            {
                _EstadosAfectado = value;
                OnPropertyChanged("EstadosAfectado");
            }
        }

        public ICommand GuardarAfectadoRescateCommand
        {
            get
            {
                _GuardarAfectadoRescateCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarAfectadoRescate()
                };
                return _GuardarAfectadoRescateCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioAfectadoRescateViewModel(ObservableCollection<AfectadoRescate> AfectadoRescates, int idEvento)
        {
            this.modo = "agregar";

            TiposAfectadoRescate = IModel.ObtenerItemsCategoria(9);
            Prioridades = IModel.ObtenerItemsCategoria(7);
            EstadosAfectado = IModel.ObtenerItemsCategoria(10);

            AfectadoRescate = new AfectadoRescate();
            AfectadoRescate.IniciarId();
            AfectadoRescate.fk_idEventoRescate = idEvento;
            this.AfectadosRescate = AfectadoRescates;
        }
        public FormularioAfectadoRescateViewModel(ObservableCollection<AfectadoRescate> AfectadoRescates, AfectadoRescate AfectadoRescate)
        {
            this.modo = "editar";

            TiposAfectadoRescate = IModel.ObtenerItemsCategoria(9);
            Prioridades = IModel.ObtenerItemsCategoria(7);
            EstadosAfectado = IModel.ObtenerItemsCategoria(10);

            this.idAfectadoRescateActual = AfectadoRescate.idRescate;
            this.AfectadosRescate = AfectadoRescates;
            this.AfectadoRescate = AfectadoRescate;
        }

        private void GuardarAfectadoRescate()
        {
            if (this.modo.Equals("agregar"))
            {
                MModel.AgregarAfectadoRescate(this.AfectadoRescate);
                AfectadosRescate.Add(AfectadoRescate);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                MModel.EditarAfectadoRescate(this.AfectadoRescate, idAfectadoRescateActual);
                CloseAction();
            }
        }


        #endregion
    }
}
