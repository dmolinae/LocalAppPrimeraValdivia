using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
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
        public VoluntarioViewModel()
        {
            _Voluntarios = new ObservableCollection<Voluntario>();
            _Voluntarios.Add(new Voluntario
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
            rut = "Hola";
        }
        public string rut { get; set; }

        private ObservableCollection<Voluntario> _Voluntarios;
        public ObservableCollection<Voluntario> Voluntarios
        {
            get
            {
                return _Voluntarios;
            }
            set
            {
                SetProperty(ref _Voluntarios, value);
                Debug.Write("set voluntarios");
            }
        }
        

        private ICommand _AgregarVoluntarioCommand;
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

        private void AgregarVoluntario()
        {
            Voluntarios.Add(new Voluntario
            {
                rut = "asdlfjsf-8",
                nombre = "asdfasf Molina",
                fechaNacimiento = "17/asdfasf/1993",
                ciudadNacimiento = "Osasdfasdforno",
                grupoSanguineo = "Aasdfasf",
                profesion = "Estudiasdfasante",
                fechaIngreso = "01/04asdfasdf/1993",
                fechaReincorporacion = "99asdfasdf99",
                servicioCompania = "serasdfasdfvicioCompania",
                servicioMilitar = "Tasdfasrue",
                insignia = 12,
                registroCompania = 1233,
                cargo = "Bomdasdbero",
                calificacion = "Goasdasdod"
            });
            Debug.Write(Voluntarios.Count);
        }
    }
}
