using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using System.Collections.ObjectModel;

namespace PrimeraValdivia.ViewModels
{
    class CompaniaViewModel : ViewModelBase
    {
        public CompaniaViewModel()
        {
            Companias = new List<Compania>();
            Companias.Add(new Compania
            {
                idCompania = 0,
                nombre = "Primera Valdivia",
                clave = "1234",
                calle = "...",
                numeroCalle = 1234,
                ciudad = "Valdivia",
                registroCompania = 0,
            }
            );
        }

        private Compania _Compania;
        public Compania Compania
        {
            get { return _Compania; }
        }

        private List<Compania> _Companias;
        public List<Compania> Companias
        {
            get { return _Companias; }
            set
            {
                SetProperty(ref _Companias, value);
            }
        }
    }
}
