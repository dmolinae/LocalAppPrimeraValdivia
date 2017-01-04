using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Helpers;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace PrimeraValdivia.ViewModels
{
    class FormularioVoluntarioViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<TabItem> _TabItems;

        private ObservableCollection<Voluntario> _Voluntarios;
        private ObservableCollection<Calificacion> _Calificaciones;
        private Voluntario _Voluntario;
        private Calificacion _Calificacion;
        private CompaniaVoluntario _CompaniaVoluntario;
        private ICommand _GuardarVoluntarioCommand;
        private ICommand _AgregarCalificacionCommand;
        private ICommand _GuardarCalificacionCommand;
        private ICommand _MostrarFormularioCalificacionCommand;
        private ICommand _EliminarCalificacionCommand;
        private ICommand _WindowClosingCommand;
        private ICommand _AgregarAnoCommand;
        private ICommand _EditarFotoCommand;
        private BitmapImage _ImageSource;
        private String _NuevoAno;
        private bool _Loading;

        private string modo;
        private bool salir = false;
        private int idVoluntarioActual;
        private String rutVoluntarioActual;

        private FormularioVoluntario view;

        private CompaniaVoluntario CVModel = new CompaniaVoluntario();
        private Voluntario VModel = new Voluntario();
        private Item IModel = new Item();
        private Calificacion CModel = new Calificacion();
        private AnoHistoriaAsistencia AHAModel = new AnoHistoriaAsistencia();
        private MesHistoriaAsistencia MHAModel = new MesHistoriaAsistencia();

        private ObservableCollection<Item> _Cargos;

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public String NuevoAno
        {
            get { return _NuevoAno; }
            set
            {
                _NuevoAno = value;
                OnPropertyChanged("NuevoAno");
            }
        }
        public BitmapImage ImageSource
        {
            get { return _ImageSource; }
            set
            {
                _ImageSource = value;
                OnPropertyChanged("ImageSource");
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
        public ObservableCollection<Item> Cargos
        {
            get { return _Cargos; }
            set
            {
                _Cargos = value;
                OnPropertyChanged("Cargos");
            }
        }
        public ObservableCollection<TabItem> TabItems
        {
            get { return _TabItems; }
            set
            {
                _TabItems = value;
                OnPropertyChanged("TabItems");
            }
        }

        public Voluntario Voluntario
        {
            get { return _Voluntario; }
            set
            {
                _Voluntario = value;
                OnPropertyChanged("Voluntario");
            }
        }
        public Calificacion Calificacion
        {
            get { return _Calificacion; }
            set
            {
                _Calificacion = value;
                OnPropertyChanged("Calificacion");
            }
        }

        public CompaniaVoluntario CompaniaVoluntario
        {
            get { return _CompaniaVoluntario; }
            set
            {
                _CompaniaVoluntario = value;
                OnPropertyChanged("CompaniaVoluntario");
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

        public ObservableCollection<Calificacion> Calificaciones
        {
            get
            {
                return _Calificaciones;
            }
            set
            {
                _Calificaciones = value;
                OnPropertyChanged("Calificaciones");
            }
        }

        public ICommand GuardarVoluntarioCommand
        {
            get
            {
                _GuardarVoluntarioCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarVoluntario()
                };
                return _GuardarVoluntarioCommand;
            }
        }

        public ICommand AgregarCalificacionCommand
        {
            get
            {
                _AgregarCalificacionCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarCalificacion()
                };
                return _AgregarCalificacionCommand;
            }
        }

        public ICommand MostrarFormularioCalificacionCommand
        {
            get
            {
                _MostrarFormularioCalificacionCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarCalificacion()
                };
                return _MostrarFormularioCalificacionCommand;
            }
        }

        public ICommand GuardarCalificacionCommand
        {
            get
            {
                _GuardarCalificacionCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarCalificacion()
                };
                return _GuardarCalificacionCommand;
            }
        }

        public ICommand EliminarCalificacionCommand
        {
            get
            {
                _EliminarCalificacionCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarCalificacion()
                };
                return _EliminarCalificacionCommand;
            }
        }

        public ICommand WindowClosingCommand
        {
            get
            {
                _WindowClosingCommand = new RelayCommand<CancelEventArgs>(
                    (args) =>{
                        if (!salir)
                        {
                            args.Cancel = true;
                            WindowClosingEvent();
                        }
                });
                return _WindowClosingCommand;
            }
        }
        public ICommand AgregarAnoCommand
        {
            get
            {
                _AgregarAnoCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarAno()
                };
                return _AgregarAnoCommand;
            }
        }
        public ICommand EditarFotoCommand
        {
            get
            {
                _EditarFotoCommand = new Helpers.RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarFoto()
                };
                return _EditarFotoCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioVoluntarioViewModel(ObservableCollection<Voluntario> Voluntarios, FormularioVoluntario view)
        {
            this.view = view;

            this.Cargos = IModel.ObtenerItemsCategoria(0);

            this.modo = "agregar";
            this.Voluntarios = Voluntarios;
            this.Voluntario = new Voluntario();
            this.Voluntario.IniciarId();
            this.Voluntario.nRegistroInterno = this.Voluntario.idVoluntario;

            this.CompaniaVoluntario = new CompaniaVoluntario();
            this.CompaniaVoluntario.IniciarId();

            this.Calificaciones = CModel.ObtenerCalificacions(Voluntario.idVoluntario);

            TabItems = new ObservableCollection<TabItem>();
        }
        public FormularioVoluntarioViewModel(ObservableCollection<Voluntario> Voluntarios, Voluntario Voluntario, FormularioVoluntario view)
        {
            this.view = view;

            this.Calificaciones = CModel.ObtenerCalificacions(Voluntario.idVoluntario);
            this.Cargos = IModel.ObtenerItemsCategoria(0);

            this.idVoluntarioActual = Voluntario.idVoluntario;
            this.rutVoluntarioActual = Voluntario.rut;
            this.modo = "editar";
            this.Voluntarios = Voluntarios;
            this.Voluntario = Voluntario;

            this.CompaniaVoluntario = CVModel.ObtenerCompaniaVoluntario(Voluntario.rut,0);

            ObservableCollection<AnoHistoriaAsistencia> anos = AHAModel.ObtenerAnosHistoriaVoluntario(Voluntario.idVoluntario);

            TabItems = new ObservableCollection<TabItem>();
            foreach (AnoHistoriaAsistencia ano in anos)
            {
                var tabItemViewModel = new AnoVoluntarioTabItemViewModel(ano.ano, Voluntario.idVoluntario);
                var tabItem = new AnoVoluntarioTabItem();
                tabItem.DataContext = tabItemViewModel;
                TabItems.Add(tabItem);
            }

            String path = AppDomain.CurrentDomain.BaseDirectory;
            String destFile = System.IO.Path.Combine("ProfileImages", Voluntario.rut + ".png");

            destFile = System.IO.Path.Combine(path, destFile);

            try
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(destFile);
                b.EndInit();

                ImageSource = b;
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
            }
        }
        private async void EditarFoto()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            BitmapImage b = new BitmapImage();
            openFile.Title = "Seleccione la Imagen a Mostrar";
            openFile.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp";
            if (openFile.ShowDialog() == true)
            {
                try
                {
                    if (!System.IO.Directory.Exists("ProfileImages"))
                    {
                        System.IO.Directory.CreateDirectory("ProfileImages");
                    }
                    String path = AppDomain.CurrentDomain.BaseDirectory;
                    String destFile = System.IO.Path.Combine("ProfileImages", Voluntario.rut + ".png");

                    destFile = System.IO.Path.Combine(path, destFile);

                    System.IO.File.Copy(openFile.FileName, destFile, true);

                    b.BeginInit();
                    b.UriSource = new Uri(destFile);
                    b.EndInit();

                    ImageSource = b;
                }
                catch(Exception e)
                {
                    MetroDialogSettings settings = new MetroDialogSettings();
                    settings.AffirmativeButtonText = "OK";
                    MessageDialogResult result = await view.ShowMessageAsync("No se puedo acceder a esa imagen", "Inténtalo nuevamente utilizando otra imagen.", MessageDialogStyle.Affirmative, settings);
                }
            }
        }
        private void GuardarVoluntario()
        {
            this.salir = true;
            this.CompaniaVoluntario.fk_voluntario = Voluntario.rut;
            this.CompaniaVoluntario.fk_compania = 0; //cambiar para implementar mas companias

            if (this.modo.Equals("agregar"))
            {
                VModel.AgregarVoluntario(Voluntario);
                CVModel.AgregarCompaniaVoluntario(this.CompaniaVoluntario);
                Voluntarios.Add(Voluntario);
            }
            else if (this.modo.Equals("editar"))
            {
                VModel.EditarVoluntario(Voluntario, this.idVoluntarioActual);
                CVModel.EditarCompaniaVoluntario(this.CompaniaVoluntario, this.CompaniaVoluntario.idCompaniaVoluntario);
            }
            CloseAction();
        }
        private void AgregarAno()
        {
            Loading = true;

            try
            {
                AHAModel.AgregarAnoHistoriaAsistencia(int.Parse(NuevoAno), Voluntario.idVoluntario);

                ObservableCollection<AnoHistoriaAsistencia> anos = AHAModel.ObtenerAnosHistoriaVoluntario(Voluntario.idVoluntario);
                TabItems = new ObservableCollection<TabItem>();
                foreach (AnoHistoriaAsistencia ano in anos)
                {
                    var tabItemViewModel = new AnoVoluntarioTabItemViewModel(ano.ano, Voluntario.idVoluntario);
                    var tabItem = new AnoVoluntarioTabItem();
                    tabItem.DataContext = tabItemViewModel;
                    TabItems.Add(tabItem);
                }
                Loading = false;
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
                Loading = false;
            }
        }

        private void AgregarCalificacion()
        {
            var viewmodel = new FormularioCalificacionViewModel(Calificaciones, this.Voluntario.idVoluntario);
            var view = new FormularioCalificacion();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void EliminarCalificacion()
        {
            CModel.EliminarCalificacion(Calificacion.idCalificacion);
            Calificaciones.Remove(Calificacion);
        }

        private void EditarCalificacion()
        {
            var viewmodel = new FormularioCalificacionViewModel(Calificaciones, Calificacion);
            var view = new FormularioCalificacion();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void GuardarCalificacion()
        {
            CModel.AgregarCalificacion(this.Calificacion);
            Calificaciones.Add(this.Calificacion);
        }

        private async void WindowClosingEvent()
        {
            MetroDialogSettings settings = new MetroDialogSettings();
            settings.NegativeButtonText = "Cancelar";
            settings.AffirmativeButtonText = "Salir";
            settings.FirstAuxiliaryButtonText = "Guardar y Salir";
            MessageDialogResult result = await view.ShowMessageAsync("Seguro que deseas salir?", "Los cambios realizados no se guardarán", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, settings);
            if (result == MessageDialogResult.Affirmative)
            {
                //Mapear valores sin efectuar cambio
                Voluntario oldVolunt = VModel.ObtenerVoluntario(this.idVoluntarioActual);

                Voluntario.nombre = oldVolunt.nombre;
                Voluntario.fechaNacimiento = oldVolunt.fechaNacimiento;
                Voluntario.ciudadNacimiento = oldVolunt.ciudadNacimiento;
                Voluntario.grupoSanguineo = oldVolunt.grupoSanguineo;
                Voluntario.profesion = oldVolunt.profesion;
                Voluntario.servicioMilitar = oldVolunt.servicioMilitar;
                Voluntario.insignia = oldVolunt.insignia;
                Voluntario.cargo = oldVolunt.cargo;
                Voluntario.nRegistroInterno = oldVolunt.nRegistroInterno;
                Voluntario.nRegistroExterno = oldVolunt.nRegistroExterno;
                Voluntario.codigoRadial = oldVolunt.codigoRadial;
                Voluntario.rut = oldVolunt.rut;

                this.salir = true;
                CloseAction();
            }
            else if(result == MessageDialogResult.FirstAuxiliary)
            {
                GuardarVoluntario();
            }
        }
        #endregion
    }
}
