using PrimeraValdivia.Commands;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class GenerarDocsViewModel : ViewModelBase
    {
        #region Variables privadas
        
        private ICommand _GenerarAsistenciaCommand;

        #endregion

        #region Propiedades/Comandos públicos

        public ICommand GenerarAsistenciaCommand
        {
            get
            {
                _GenerarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GenerarAsistencia()
                };
                return _GenerarAsistenciaCommand;
            }
        }
        #endregion

        #region Constructor/Métodos

        public GenerarDocsViewModel()
        {
            
        }
        
        private void GenerarAsistencia()
        {
            
        }

        #endregion
    }
}