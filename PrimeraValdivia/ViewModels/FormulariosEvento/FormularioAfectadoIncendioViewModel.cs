using PrimeraValdivia.Helpers;
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
    class FormularioAfectadoIncendioViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<Item> _TiposAfectadoIncendio;
        private ObservableCollection<Item> _Prioridades;

        private ObservableCollection<AfectadoIncendio> _AfectadosIncendio;
        private AfectadoIncendio _AfectadoIncendio;
        private ICommand _GuardarAfectadoIncendioCommand;
        private string modo;
        private int idAfectadoIncendioActual;

        private AfectadoIncendio MModel = new AfectadoIncendio();
        private Item IModel = new Item();

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public AfectadoIncendio AfectadoIncendio
        {
            get { return _AfectadoIncendio; }
            set
            {
                _AfectadoIncendio = value;
                OnPropertyChanged("AfectadoIncendio");
            }
        }

        public ObservableCollection<AfectadoIncendio> AfectadosIncendio
        {
            get { return _AfectadosIncendio; }
            set
            {
                _AfectadosIncendio = value;
                OnPropertyChanged("AfectadosIncendio");
            }
        }

        public ObservableCollection<Item> TiposAfectadoIncendio
        {
            get { return _TiposAfectadoIncendio; }
            set
            {
                _TiposAfectadoIncendio = value;
                OnPropertyChanged("TiposAfectadoIncendio");
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

        public ICommand GuardarAfectadoIncendioCommand
        {
            get
            {
                _GuardarAfectadoIncendioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarAfectadoIncendio()
                };
                return _GuardarAfectadoIncendioCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioAfectadoIncendioViewModel(ObservableCollection<AfectadoIncendio> AfectadoIncendios, int idIncendio)
        {
            this.modo = "agregar";

            TiposAfectadoIncendio = IModel.ObtenerItemsCategoria(8);
            Prioridades = IModel.ObtenerItemsCategoria(7);

            AfectadoIncendio = new AfectadoIncendio();
            AfectadoIncendio.IniciarId();
            AfectadoIncendio.fk_idIncendioAfectado = idIncendio;
            this.AfectadosIncendio = AfectadoIncendios;
        }
        public FormularioAfectadoIncendioViewModel(ObservableCollection<AfectadoIncendio> AfectadoIncendios, AfectadoIncendio AfectadoIncendio)
        {
            this.modo = "editar";

            TiposAfectadoIncendio = IModel.ObtenerItemsCategoria(8);
            Prioridades = IModel.ObtenerItemsCategoria(7);

            this.idAfectadoIncendioActual = AfectadoIncendio.idAfectado;
            this.AfectadosIncendio = AfectadoIncendios;
            this.AfectadoIncendio = AfectadoIncendio;
        }

        private void GuardarAfectadoIncendio()
        {
            if (this.modo.Equals("agregar"))
            {
                MModel.AgregarAfectadoIncendio(this.AfectadoIncendio);
                AfectadosIncendio.Add(AfectadoIncendio);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                MModel.EditarAfectadoIncendio(this.AfectadoIncendio, idAfectadoIncendioActual);
                CloseAction();
            }
        }


        #endregion
    }
}
