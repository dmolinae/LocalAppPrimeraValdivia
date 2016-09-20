using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Input;
using PrimeraValdivia.Commands;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PrimeraValdivia.ViewModels
{
    class VoluntarioViewModel : ViewModelBase
    {
        #region Variables privadas

        private Voluntario _Voluntario;
        private ObservableCollection<Voluntario> _Voluntarios;
        private ICommand _AgregarVoluntarioCommand;

        #endregion

        #region Propiedades/Comandos públicos
        
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

        #endregion

        #region Constructor/Métodos

        public VoluntarioViewModel()
        {
            Voluntarios = new ObservableCollection<Voluntario>();
            Voluntarios.Add(new Voluntario
            {
                rut = "18578070-8",
                nombre = "Daniel Molina",
                fechaNacimiento = "17/11/1993",
                ciudadNacimiento = "Osorno",
                grupoSanguineo = "A",
                profesion = "Estudiante",
                fechaIngreso = "01/04/1993",
                fechaReincorporacion = "9999",
                servicioCompania = "servicioCompania",
                servicioMilitar = "True",
                insignia = 1,
                registroCompania = 123,
                cargo = "Bombero",
                calificacion = "Good"
            });
        }

        private void AgregarVoluntario()
        {
            var voluntario = new Voluntario();

            var viewmodel = new FormularioVoluntarioViewModel(Voluntarios);
            var view = new FormularioVoluntario();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        #endregion
    }
}
