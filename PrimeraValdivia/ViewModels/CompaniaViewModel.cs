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
        private CompaniaModel _compania;

        public CompaniaModel Compania
        {
            get
            {
                return this._compania;
            }
            set
            {
                this._compania = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CompaniaModel> _companias;

        public ObservableCollection<CompaniaModel> Companias
        {
            get
            {
                if (this._companias == null)
                    this._companias = new ObservableCollection<CompaniaModel>();
                return this._companias;
            }
            set
            {
                this._companias = value;
                OnPropertyChanged();
            }
        }
        public CompaniaViewModel()
        {
            this.Companias.Add(new CompaniaModel()
            {
                idCompania = 0,
                rut = "18578070-8",
                clave = "1234", 
                calle = "General Lagos",
                numeroCalle = "1618",
                ciudad = "Valdivia",
                nombreCompania = "Los penes voladores"
            });
        }
    }
}
