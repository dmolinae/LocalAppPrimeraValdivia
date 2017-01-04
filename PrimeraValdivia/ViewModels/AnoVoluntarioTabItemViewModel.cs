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
using System.Diagnostics;
using PrimeraValdivia.Views;

namespace PrimeraValdivia.ViewModels
{
    public class AnoVoluntarioTabItemViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<MesAsistencia> _Meses;
        private MesAsistencia _Mes;
        private ICommand _EditarNumeroCommand;
        private ICommand _CloseTabCommand;
        private int _Year;

        private int fk_year;
        private int idVoluntario;

        private AnoHistoriaAsistencia AHAModel = new AnoHistoriaAsistencia();
        private MesHistoriaAsistencia MHAModel = new MesHistoriaAsistencia();

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
        public ICommand CloseTabCommand
        {
            get
            {
                _CloseTabCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => CanCloseTab(),
                    ExecuteDelegate = c => CloseTab()
                };
                return _CloseTabCommand;
            }
        }

        #endregion

        #region Metodos

        public AnoVoluntarioTabItemViewModel(int Year, int idVoluntario)
        {
            this.Year = Year;
            this.idVoluntario = idVoluntario;

            ObservableCollection<String> tipos = new ObservableCollection<string>();
            tipos.Add("LL");
            tipos.Add("A");
            tipos.Add("F");

            Meses = new ObservableCollection<MesAsistencia>();

            fk_year = AHAModel.AgregarAnoHistoriaAsistencia(Year, idVoluntario);
            for (int i = 1;i < 13; i++)
            {
                MesAsistencia nuevoMes = new MesAsistencia();
                foreach(String tipo in tipos)
                {
                    MesHistoriaAsistencia historiaAsistencia = MHAModel.ObtenerMesHistoriaAsistencia(fk_year, i, tipo);
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
            var view = new FormularioMes();
            var viewmodel = new FormularioMesViewModel(Mes,fk_year);
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private bool CanCloseTab()
        {
            return !MHAModel.ExisteAnoHistoriaAsistencia(fk_year);
        }
        private void CloseTab()
        {
            AHAModel.EliminarAnoHistoriaAsistencia(this.fk_year);
        }
        #endregion
    }
}
