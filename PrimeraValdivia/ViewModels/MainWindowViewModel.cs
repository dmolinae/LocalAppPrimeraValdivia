using PrimeraValdivia.Commands;
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
        public MainWindowViewModel()
        {
            _Title = "Primera Valdivia";
            var utils = new Utils();
            utils.crearBD();
            //utils.cargarBD();
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }

            set
            {
                SetProperty(ref _Title, value);
            }
        }

        private ICommand _SetTextCommand;
        public ICommand SetTextCommand
        {
            get
            {
                this._SetTextCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => CanUpdateTitle(),
                    ExecuteDelegate = c => SetTitle()
                };
                return this._SetTextCommand;
            }
        }

        private bool CanUpdateTitle()
        {
            return Title.Length < 50;
        }

        private void SetTitle()
        {
            Title += "";
        }
        
    }
}
