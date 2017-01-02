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

        private ObservableCollection<AfectadoRescate> _AfectadosRescate;
        private AfectadoRescate _AfectadoRescate;
        private ICommand _GuardarAfectadoRescateCommand;
        private string modo;
        private int idAfectadoRescateActual;

        private AfectadoRescate MModel = new AfectadoRescate();

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
            AfectadoRescate = new AfectadoRescate();
            AfectadoRescate.IniciarId();
            AfectadoRescate.fk_idEventoRescate = idEvento;
            this.AfectadosRescate = AfectadoRescates;
        }
        public FormularioAfectadoRescateViewModel(ObservableCollection<AfectadoRescate> AfectadoRescates, AfectadoRescate AfectadoRescate)
        {
            this.idAfectadoRescateActual = AfectadoRescate.idRescate;
            this.AfectadosRescate = AfectadoRescates;
            this.modo = "editar";
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
