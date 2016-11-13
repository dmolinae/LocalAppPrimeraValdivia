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
        #region Atributos Privados

        private ObservableCollection<Voluntario> _Voluntarios;
        private Voluntario _Voluntario;
        private CompaniaVoluntario _CompaniaVoluntario;
        private ICommand _GuardarVoluntarioCommand;
        private string modo;
        private string rutVoluntarioActual;

        private CompaniaVoluntario CVModel = new CompaniaVoluntario();
        private Voluntario VModel = new Voluntario();
        private Item IModel = new Item();

        private ObservableCollection<Item> _Cargos;

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public ObservableCollection<Item> Cargos
        {
            get { return _Cargos; }
            set
            {
                _Cargos = value;
                OnPropertyChanged("Cargos");
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

        public CompaniaVoluntario CompaniaVoluntario
        {
            get { return _CompaniaVoluntario; }
            set
            {
                _CompaniaVoluntario = value;
                OnPropertyChanged("CompaniaVoluntario");
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

        public ICommand GuardarVoluntarioCommand
        {
            get
            {
                _GuardarVoluntarioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarVoluntario()
                };
                return _GuardarVoluntarioCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioVoluntarioViewModel(ObservableCollection<Voluntario> Voluntarios)
        {
            this.Cargos = IModel.ObtenerItemsCategoria(0);

            this.modo = "agregar";
            this.Voluntarios = Voluntarios;
            this.Voluntario = new Voluntario();

            this.CompaniaVoluntario = new CompaniaVoluntario();
            this.CompaniaVoluntario.IniciarId();
        }
        public FormularioVoluntarioViewModel(ObservableCollection<Voluntario> Voluntarios, Voluntario Voluntario)
        {
            this.Cargos = IModel.ObtenerItemsCategoria(0);

            this.rutVoluntarioActual = Voluntario.rut;
            this.modo = "editar";
            this.Voluntarios = Voluntarios;
            this.Voluntario = Voluntario;

            this.CompaniaVoluntario = CVModel.ObtenerCompaniaVoluntario(Voluntario.rut,0);
        }

        private void GuardarVoluntario()
        {
            this.CompaniaVoluntario.fk_voluntario = Voluntario.rut;
            this.CompaniaVoluntario.fk_compania = 0; //cambiar para implementar mas companias

            if (this.modo.Equals("agregar"))
            {
                VModel.AgregarVoluntario(Voluntario);
                CVModel.AgregarCompaniaVoluntario(this.CompaniaVoluntario);
                Voluntarios.Add(Voluntario);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                VModel.EditarVoluntario(Voluntario, this.rutVoluntarioActual);
                CVModel.EditarCompaniaVoluntario(this.CompaniaVoluntario, this.CompaniaVoluntario.idCompaniaVoluntario);
                CloseAction();
            }
        }

        #endregion
    }
}
