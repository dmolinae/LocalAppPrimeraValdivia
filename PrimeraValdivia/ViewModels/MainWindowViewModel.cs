using PrimeraValdivia.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private bool _Loading = false;
        private string _Title;

        
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
        public bool Loading
        {
            get { return _Loading; }
            set
            {
                _Loading = value;
                OnPropertyChanged("Loading");
            }
        }

        public MainWindowViewModel()
        {
            _Title = "Primera Valdivia";
            var utils = new Utils();
            utils.crearBD();
            //utils.cargarBD();
        }

    }
}
