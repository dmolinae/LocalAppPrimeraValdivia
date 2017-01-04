using PrimeraValdivia.Models;
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
    public class AnoVoluntarioTabItemViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<MesAsistencia> _Meses;
        private MesAsistencia _Mes;
        private ICommand _EditarNumeroCommand;
        private string modo;
        private int _Year;

        private HistoriaAsistencia HAModel = new HistoriaAsistencia();
        
        public class MesAsistencia : ViewModelBase
        {
            private String _nombreMes;
            public String nombreMes
            {
                get { return _nombreMes; }
                set
                {
                    _nombreMes = value;
                    OnPropertyChanged("nombreMes");
                }
            }
            private int _LL;
            public int LL
            {
                get { return _LL; }
                set
                {
                    _LL = value;
                    OnPropertyChanged("LL");
                }
            }
            private int _A;
            public int A
            {
                get { return _A; }
                set
                {
                    _A = value;
                    OnPropertyChanged("A");
                }
            }
            private int _F;
            public int F
            {
                get { return _F; }
                set
                {
                    _F = value;
                    OnPropertyChanged("F");
                }
            }
            public MesAsistencia(String nombreMes, int LL, int A, int F)
            {
                this.nombreMes = nombreMes;
                this.LL = LL;
                this.A = A;
                this.F = F;
            }
            public MesAsistencia()
            {

            }
        }

        #endregion

        #region Atributos Publicos

        public int Year
        {
            get { return _Year; }
            set
            {
                _Year = value;
                OnPropertyChanged("Year");
            }
        }

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

        public ObservableCollection<MesAsistencia> Meses
        {
            get { return _Meses; }
            set
            {
                _Meses = value;
                OnPropertyChanged("Meses");
            }
        }

        public ICommand EditarNumeroCommand
        {
            get
            {
                _EditarNumeroCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarNumero()
                };
                return _EditarNumeroCommand;
            }
        }

        #endregion

        #region Metodos

        public AnoVoluntarioTabItemViewModel(int Year, int idVoluntario)
        {
            this.Year = Year;

            ObservableCollection<String> tipos = new ObservableCollection<string>();
            tipos.Add("LL");
            tipos.Add("A");
            tipos.Add("F");

            Meses = new ObservableCollection<MesAsistencia>();

            for(int i = 1;i < 13; i++)
            {
                MesAsistencia nuevoMes = new MesAsistencia();
                foreach(String tipo in tipos)
                {
                    HistoriaAsistencia historiaAsistencia = HAModel.ObtenerHistoriaAsistencia(Year, i, idVoluntario, tipo);
                    switch (historiaAsistencia.tipo)
                    {
                        case "LL":
                            nuevoMes.LL = historiaAsistencia.numero;
                            break;
                        case "A":
                            nuevoMes.A = historiaAsistencia.numero;
                            break;
                        case "F":
                            nuevoMes.F = historiaAsistencia.numero;
                            break;
                    }
                }
                switch (i)
                {
                    case 1:
                        nuevoMes.nombreMes = "Enero";
                        break;
                    case 2:
                        nuevoMes.nombreMes = "Febrero";
                        break;
                    case 3:
                        nuevoMes.nombreMes = "Marzo";
                        break;
                    case 4:
                        nuevoMes.nombreMes = "Abril";
                        break;
                    case 5:
                        nuevoMes.nombreMes = "Mayo";
                        break;
                    case 6:
                        nuevoMes.nombreMes = "Junio";
                        break;
                    case 7:
                        nuevoMes.nombreMes = "Julio";
                        break;
                    case 8:
                        nuevoMes.nombreMes = "Agosto";
                        break;
                    case 9:
                        nuevoMes.nombreMes = "Septiembre";
                        break;
                    case 10:
                        nuevoMes.nombreMes = "Octubre";
                        break;
                    case 11:
                        nuevoMes.nombreMes = "Noviembre";
                        break;
                    case 12:
                        nuevoMes.nombreMes = "Diciembre";
                        break;
                }
                Meses.Add(nuevoMes);
            }
        }

        private void EditarNumero()
        {
            
        }
        #endregion
    }
}
