using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Helpers;
using System.Diagnostics;
using System.Windows;

namespace PrimeraValdivia.ViewModels
{
    class FormularioVoluntarioViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<Voluntario> _Voluntarios;
        private ObservableCollection<Calificacion> _Calificaciones;
        private Voluntario _Voluntario;
        private Calificacion _Calificacion;
        private CompaniaVoluntario _CompaniaVoluntario;
        private ICommand _GuardarVoluntarioCommand;
        private ICommand _AgregarCalificacionCommand;
        private ICommand _GuardarCalificacionCommand;
        private ICommand _MostrarFormularioCalificacionCommand;
        private ICommand _EliminarCalificacionCommand;
        private string modo;
        private int idVoluntarioActual;

        private CompaniaVoluntario CVModel = new CompaniaVoluntario();
        private Voluntario VModel = new Voluntario();
        private Item IModel = new Item();
        private Calificacion CModel = new Calificacion();

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
        public Calificacion Calificacion
        {
            get { return _Calificacion; }
            set
            {
                _Calificacion = value;
                OnPropertyChanged("Calificacion");
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

        public ObservableCollection<Calificacion> Calificaciones
        {
            get
            {
                return _Calificaciones;
            }
            set
            {
                _Calificaciones = value;
                OnPropertyChanged("Calificaciones");
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

        public ICommand AgregarCalificacionCommand
        {
            get
            {
                _AgregarCalificacionCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarCalificacion()
                };
                return _AgregarCalificacionCommand;
            }
        }

        public ICommand MostrarFormularioCalificacionCommand
        {
            get
            {
                _MostrarFormularioCalificacionCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarCalificacion()
                };
                return _MostrarFormularioCalificacionCommand;
            }
        }

        public ICommand GuardarCalificacionCommand
        {
            get
            {
                _GuardarCalificacionCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarCalificacion()
                };
                return _GuardarCalificacionCommand;
            }
        }

        public ICommand EliminarCalificacionCommand
        {
            get
            {
                _EliminarCalificacionCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarCalificacion()
                };
                return _EliminarCalificacionCommand;
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
            this.Voluntario.IniciarId();
            this.Voluntario.nRegistroInterno = this.Voluntario.idVoluntario;

            this.CompaniaVoluntario = new CompaniaVoluntario();
            this.CompaniaVoluntario.IniciarId();

            this.Calificaciones = CModel.ObtenerCalificacions(Voluntario.idVoluntario);
        }
        public FormularioVoluntarioViewModel(ObservableCollection<Voluntario> Voluntarios, Voluntario Voluntario)
        {
            this.Calificaciones = CModel.ObtenerCalificacions(Voluntario.idVoluntario);
            this.Cargos = IModel.ObtenerItemsCategoria(0);

            this.idVoluntarioActual = Voluntario.idVoluntario;
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
                VModel.EditarVoluntario(Voluntario, this.idVoluntarioActual);
                CVModel.EditarCompaniaVoluntario(this.CompaniaVoluntario, this.CompaniaVoluntario.idCompaniaVoluntario);
                CloseAction();
            }
        }

        private void AgregarCalificacion()
        {
            var viewmodel = new FormularioCalificacionViewModel(Calificaciones, this.Voluntario.idVoluntario);
            var view = new FormularioCalificacion();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void EliminarCalificacion()
        {
            CModel.EliminarCalificacion(Calificacion.idCalificacion);
            Calificaciones.Remove(Calificacion);
        }

        private void EditarCalificacion()
        {
            var viewmodel = new FormularioCalificacionViewModel(Calificaciones, Calificacion);
            var view = new FormularioCalificacion();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void GuardarCalificacion()
        {
            CModel.AgregarCalificacion(this.Calificacion);
            Calificaciones.Add(this.Calificacion);
        }
        #endregion
    }
}
