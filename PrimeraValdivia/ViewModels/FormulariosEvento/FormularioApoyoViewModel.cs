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
    class FormularioApoyoViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<Apoyo> _Apoyos;
        private ObservableCollection<Item> _TiposApoyo;
        private Apoyo _Apoyo;
        private ICommand _GuardarApoyoCommand;
        private string modo;
        private int idApoyoActual;

        private Apoyo AModel = new Apoyo();
        private Item IModel = new Item();

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public Apoyo Apoyo
        {
            get { return _Apoyo; }
            set
            {
                _Apoyo = value;
                OnPropertyChanged("Apoyo");
            }
        }

        public ObservableCollection<Apoyo> Apoyos
        {
            get { return _Apoyos; }
            set
            {
                _Apoyos = value;
                OnPropertyChanged("Apoyos");
            }
        }
        public ObservableCollection<Item> TiposApoyo
        {
            get { return _TiposApoyo; }
            set
            {
                _TiposApoyo = value;
                OnPropertyChanged("TiposApoyo");
            }
        }

        public ICommand GuardarApoyoCommand
        {
            get
            {
                _GuardarApoyoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarApoyo()
                };
                return _GuardarApoyoCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioApoyoViewModel(ObservableCollection<Apoyo> Apoyos, int idEvento)
        {
            this.modo = "agregar";
            Apoyo = new Apoyo();
            Apoyo.IniciarId();
            Apoyo.fk_idEventoApoyo = idEvento;
            this.Apoyos = Apoyos;

            TiposApoyo = IModel.ObtenerItemsCategoria(6);
        }
        public FormularioApoyoViewModel(ObservableCollection<Apoyo> Apoyos, Apoyo Apoyo)
        {
            this.idApoyoActual = Apoyo.idApoyo;
            this.Apoyos = Apoyos;
            this.modo = "editar";
            this.Apoyo = Apoyo;

            TiposApoyo = IModel.ObtenerItemsCategoria(6);
        }

        private void GuardarApoyo()
        {
            if (this.modo.Equals("agregar"))
            {
                AModel.AgregarApoyo(this.Apoyo);
                Apoyos.Add(Apoyo);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                AModel.EditarApoyo(this.Apoyo, idApoyoActual);
                CloseAction();
            }
        }


        #endregion
    }
}
