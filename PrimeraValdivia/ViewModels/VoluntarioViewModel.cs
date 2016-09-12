using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;

namespace PrimeraValdivia.ViewModels
{
    class VoluntarioViewModel : ViewModelBase
    {
        public VoluntarioViewModel()
        {
            Voluntarios = new List<Voluntario>();
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

        private Voluntario _Voluntario;
        public Voluntario Voluntario
        {
            get { return _Voluntario; }
        }

        private List<Voluntario> _Voluntarios;
        public List<Voluntario> Voluntarios
        {
            get { return _Voluntarios; }
            set
            {
                SetProperty(ref _Voluntarios, value);
            }
        }
    }
}
