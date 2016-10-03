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
using PrimeraValdivia.Helpers;
using MySql.Data.MySqlClient;

namespace PrimeraValdivia.ViewModels
{
    class VoluntarioViewModel : ViewModelBase
    {
        #region Variables privadas

        private Voluntario _Voluntario;
        private ObservableCollection<Voluntario> _Voluntarios;
        private ICommand _AgregarVoluntarioCommand;
        private ICommand _MostrarFormularioVoluntarioCommand;
        private Utils utils = new Utils();
        private Voluntario model = new Voluntario();

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

        public ICommand MostrarFormularioVoluntarioCommand
        {
            get
            {
                _MostrarFormularioVoluntarioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => MostrarVoluntario()
                };
                return _MostrarFormularioVoluntarioCommand;
            }
        }

        #endregion

        #region Constructor/Métodos

        public VoluntarioViewModel()
        {
            /*
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "primeravaldivia$default";
            if (dbCon.IsConnect())
            {
                string query = "SELECT nombre,cargo FROM Voluntario";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Debug.Write(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
            }*/
            Voluntarios = model.ObtenerVoluntarios();
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

        private void MostrarVoluntario()
        {
            var viewmodel = new FormularioVoluntarioViewModel(Voluntarios, Voluntario);
            var view = new FormularioVoluntario();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        #endregion
    }
}
