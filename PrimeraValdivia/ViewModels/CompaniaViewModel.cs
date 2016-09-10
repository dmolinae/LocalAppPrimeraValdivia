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
            _Compania = new Compania
            {
                idCompania = 0,
                rut = "root",
                clave = "root",
                nombre = "Molina S.A."
            };
            Companias = new List<Compania>();
            Companias.Add(_Compania);
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
