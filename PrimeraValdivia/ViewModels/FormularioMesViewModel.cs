using PrimeraValdivia.Models;
using PrimeraValdivia.DataModels;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class FormularioMesViewModel : ViewModelBase
    {
        #region Atributos Privados
        
        private MesAsistencia _Mes;
        private ICommand _GuardarMesCommand;

        private int fk_year;
        private int month;

        private MesHistoriaAsistencia MHAModel = new MesHistoriaAsistencia();
        
        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public MesAsistencia Mes
        {
            get { return _Mes; }
            set
            {
                _Mes = value;
                OnPropertyChanged("Mes");
            }
        }

        public ICommand GuardarMesCommand
        {
            get
            {
                _GuardarMesCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarMes()
                };
                return _GuardarMesCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioMesViewModel(MesAsistencia Mes, int fk_year)
        {
            this.Mes = Mes;
            this.fk_year = fk_year;

            switch (Mes.nombreMes)
            {
                case "Enero":
                    this.month = 1;
                    break;
                case "Febrero":
                    this.month = 2;
                    break;
                case "Marzo":
                    this.month = 3;
                    break;
                case "Abril":
                    this.month = 4;
                    break;
                case "Mayo":
                    this.month = 5;
                    break;
                case "Junio":
                    this.month = 6;
                    break;
                case "Julio":
                    this.month = 7;
                    break;
                case "Agosto":
                    this.month = 8;
                    break;
                case "Septiembre":
                    this.month = 9;
                    break;
                case "Octubre":
                    this.month = 10;
                    break;
                case "Noviembre":
                    this.month = 11;
                    break;
                case "Diciembre":
                    this.month = 12;
                    break;
            }
        }

        private void GuardarMes()
        {
            ObservableCollection<String> tipos = new ObservableCollection<string>();
            tipos.Add("LL");
            tipos.Add("A");
            tipos.Add("F");

            foreach(String tipo in tipos)
            {
                MesHistoriaAsistencia mesHA = new MesHistoriaAsistencia();
                mesHA = MHAModel.ObtenerMesHistoriaAsistencia(fk_year, month, tipo);
                switch (tipo)
                {
                    case "LL":
                        mesHA.numero = Mes.LL;
                        break;
                    case "A":
                        mesHA.numero = Mes.A;
                        break;
                    case "F":
                        mesHA.numero = Mes.F;
                        break;
                }
                MHAModel.EditarMesHistoriaAsistencia(mesHA, mesHA.idMesHistoriaAsistencia);
            }
            
            CloseAction();
        }


        #endregion
    }
}
