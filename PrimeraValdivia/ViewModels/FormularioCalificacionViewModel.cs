using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Commands;
using PrimeraValdivia.Views;
using System.Diagnostics;
using System.Windows;

namespace PrimeraValdivia.ViewModels
{
    class FormularioCalificacionViewModel : ViewModelBase
    {
        #region Atributos Privados
        
        private ObservableCollection<Calificacion> _Calificaciones;
        private Calificacion _Calificacion;
        private ICommand _GuardarCalificacionCommand;
        private string modo;
        private int idCalificacionActual;
        
        private Calificacion CModel = new Calificacion();
        private Item IModel = new Item();

        private ObservableCollection<Item> _AnosCalificaciones;

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public Calificacion Calificacion
        {
            get { return _Calificacion; }
            set
            {
                _Calificacion = value;
                OnPropertyChanged("Calificacion");
            }
        }

        public ObservableCollection<Calificacion> Calificaciones
        {
            get { return _Calificaciones; }
            set
            {
                _Calificaciones = value;
                OnPropertyChanged("Calificaciones");
            }
        }

        public ObservableCollection<Item> AnosCalificaciones
        {
            get { return _AnosCalificaciones; }
            set
            {
                _AnosCalificaciones = value;
                OnPropertyChanged("AnosCalificaciones");
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

        #endregion

        #region Metodos

        public FormularioCalificacionViewModel(ObservableCollection<Calificacion> Calificacions, int idVoluntario)
        {
            this.AnosCalificaciones = IModel.ObtenerItemsCategoria(1);

            this.modo = "agregar";
            Calificacion = new Calificacion();
            Calificacion.IniciarId();
            Calificacion.numero = CModel.ContarRegistrosVoluntario(idVoluntario);
            Calificacion.fk_idVoluntario = idVoluntario;
            this.Calificaciones = Calificacions;
        }
        public FormularioCalificacionViewModel(ObservableCollection<Calificacion> Calificacions, Calificacion Calificacion)
        {
            this.AnosCalificaciones = IModel.ObtenerItemsCategoria(1);

            this.idCalificacionActual = Calificacion.idCalificacion;
            this.Calificaciones = Calificacions;
            this.modo = "editar";
            this.Calificacion = Calificacion;
        }

        private void GuardarCalificacion()
        {
            if (this.modo.Equals("agregar"))
            {
                
                CModel.AgregarCalificacion(this.Calificacion);
                Calificaciones.Add(Calificacion);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                CModel.EditarCalificacion(this.Calificacion,idCalificacionActual);
                CloseAction();
            }
        }


        #endregion
    }
}
