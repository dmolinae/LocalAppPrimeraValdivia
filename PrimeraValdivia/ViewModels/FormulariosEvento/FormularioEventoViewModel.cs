using MyToolkit.Collections;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PrimeraValdivia.Helpers;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using System.Globalization;

namespace PrimeraValdivia.ViewModels
{
    class FormularioEventoViewModel : ViewModelBase
    {
        #region Atributos privados

        private Voluntario _Voluntario;
        private VoluntarioAsistente _Asistente;
        private Voluntario _VoluntarioCargo;
        private Voluntario _VoluntarioInforme;
        private Evento _Evento;
        private Incendio _Incendio;

        private ObservableCollection<Voluntario> _Voluntarios;
        private ObservableCollection<Voluntario> _VoluntariosSinMarcar;
        private ObservableCollectionView<Voluntario> _VoluntariosSinMarcarView;

        private MaterialMayor _MaterialMayor;
        private ObservableCollection<MaterialMayor> _MaterialMayorList;

        private Apoyo _Apoyo;
        private ObservableCollection<Apoyo> _Apoyos;

        private Carro _Carro;
        private ObservableCollection<Carro> _Carros;

        private ObservableCollection<Asistencia> _Asistentes;
        private ObservableCollection<Evento> _Eventos;
        private ObservableCollection<VoluntarioAsistente> _AsistentesTabla;

        private ObservableCollection<AfectadoIncendio> _AfectadosIncendio;
        private ObservableCollection<AfectadoRescate> _AfectadosRescate;

        private AfectadoIncendio _AfectadoIncendio;
        private AfectadoRescate _AfectadoRescate;

        private ObservableCollection<Item> _TiposIncendio;
        private ObservableCollection<Item> _FasesIncendio;
        private ObservableCollection<Item> _TiposLugar;
        private ObservableCollection<Item> _TiposConstruccion;

        private ICommand _GuardarEventoCommand;

        private ICommand _ButtonSiguienteCommand;
        private ICommand _ButtonAtrasCommand;

        private ICommand _AgregarAsistenciaCommand;
        private ICommand _EditarAsistenciaCommand;
        private ICommand _MarcarRestantesCommand;
        private ICommand _MarcarCommand;

        private ICommand _AgregarMaterialMayorCommand;
        private ICommand _EditarMaterialMayorCommand;
        private ICommand _EliminarMaterialMayorCommand;

        private ICommand _AgregarApoyoCommand;
        private ICommand _EditarApoyoCommand;
        private ICommand _EliminarApoyoCommand;

        private ICommand _AgregarAfectadoIncendioCommand;
        private ICommand _EditarAfectadoIncendioCommand;
        private ICommand _EliminarAfectadoIncendioCommand;

        private ICommand _AgregarAfectadoRescateCommand;
        private ICommand _EditarAfectadoRescateCommand;
        private ICommand _EliminarAfectadoRescateCommand;

        private string _nameFilter;
        private string modo;
        private string _SiguienteButtonContent = "Siguiente";

        private string _incendioVisible;
        private string _rescateVisible;

        private bool _incendioEnabled;
        private bool _rescateEnabled;

        private bool _tab2enabled = false;
        private bool _tab3enabled = false;
        private bool _aChecked = true;
        private bool _fChecked;
        private bool _lChecked;

        private bool buttonAtrasEnabled = false;

        private bool _Loading;

        private int _tabIndex;
        private int _iCarro;

        private Asistencia AModel = new Asistencia();
        private Voluntario VModel = new Voluntario();
        private Evento EModel = new Evento();
        private Carro CModel = new Carro();
        private MaterialMayor MMModel = new MaterialMayor();
        private Incendio IModel = new Incendio();
        private Item ItModel = new Item();
        private Apoyo ApModel = new Apoyo();
        private AfectadoIncendio AIModel = new AfectadoIncendio();
        private AfectadoRescate ARModel = new AfectadoRescate();

        private AnoHistoriaAsistencia AHAModel = new AnoHistoriaAsistencia();
        private MesHistoriaAsistencia MHAModel = new MesHistoriaAsistencia();

        private FormularioEvento view;
        
        public class VoluntarioAsistente : ViewModelBase
        {
            private int _id;
            public int id
            {
                get { return _id; }
                set
                {
                    _id = value;
                    OnPropertyChanged("id");
                }
            }

            private String _rut;
            public String rut
            {
                get { return _rut; }
                set
                {
                    _rut = value;
                    OnPropertyChanged("rut");
                }
            }
            private String _nombre;
            public String nombre
            {
                get { return _nombre; }
                set
                {
                    _nombre = value;
                    OnPropertyChanged("nombre");
                }
            }
            private String _cargo;
            public String cargo
            {
                get { return _cargo; }
                set
                {
                    _cargo = value;
                    OnPropertyChanged("cargo");
                }
            }
            private String _codigo_asistencia;
            public String codigo_asistencia
            {
                get { return _codigo_asistencia; }
                set
                {
                    _codigo_asistencia = value;
                    OnPropertyChanged("codigo_asistencia");
                }
            }
            public VoluntarioAsistente(int id,String rut, String nombre, String cargo, String codigo_asistencia)
            {
                this.id = id;
                this.rut = rut;
                this.nombre = nombre;
                this.cargo = cargo;
                this.codigo_asistencia = codigo_asistencia;
            }
        }

        public CultureInfo CultureInfo = CultureInfo.CurrentCulture;
        #endregion

        #region Atributos publicos

        public Action CloseAction { get; set; }

        public string IncendioVisible
        {
            get { return _incendioVisible; }
            set
            {
                _incendioVisible = value;
                OnPropertyChanged("IncendioVisible");
            }
        }
        public string RescateVisible
        {
            get { return _rescateVisible; }
            set
            {
                _rescateVisible = value;
                OnPropertyChanged("RescateVisible");
            }
        }

        public string SiguienteButtonContent
        {
            get { return _SiguienteButtonContent; }
            set
            {
                _SiguienteButtonContent = value;
                OnPropertyChanged("SiguienteButtonContent");
            }
        }
        public int iCarro
        {
            get { return _iCarro; }
            set
            {
                _iCarro = value;
                OnPropertyChanged("iCarro");
            }
        }
        public int tabIndex
        {
            get { return _tabIndex; }
            set
            {
                _tabIndex = value;
                OnPropertyChanged("tabIndex");
            }
        }

        public string nameFilter
        {
            get { return _nameFilter; }
            set
            {
                _nameFilter = value;
                OnPropertyChanged("nameFilter");
                VoluntariosSinMarcarView.Filter = p => p.nombre.IndexOf(_nameFilter, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        public bool IncendioEnabled
        {
            get { return _incendioEnabled; }
            set
            {
                _incendioEnabled = value;
                OnPropertyChanged("IncendioEnabled");
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
        public bool RescateEnabled
        {
            get { return _rescateEnabled; }
            set
            {
                _rescateEnabled = value;
                OnPropertyChanged("RescateEnabled");
            }
        }

        public bool tab2enabled
        {
            get { return _tab2enabled; }
            set
            {
                _tab2enabled = value;
                OnPropertyChanged("tab2enabled");
            }
        }
        public bool tab3enabled
        {
            get { return _tab3enabled; }
            set
            {
                _tab3enabled = value;
                OnPropertyChanged("tab2enabled");
            }
        }
        public bool aChecked
        {
            get { return _aChecked; }
            set
            {
                _aChecked = value;
                OnPropertyChanged("aChecked");
            }
        }
        public bool fChecked
        {
            get { return _fChecked; }
            set
            {
                _fChecked = value;
                OnPropertyChanged("fChecked");
            }
        }
        public bool lChecked
        {
            get { return _lChecked; }
            set
            {
                _lChecked = value;
                OnPropertyChanged("lChecked");
            }
        }
        public Carro Carro
        {
            get { return _Carro; }
            set
            {
                _Carro = value;
                OnPropertyChanged("Carro");
            }
        }
        public Incendio Incendio
        {
            get { return _Incendio; }
            set
            {
                _Incendio = value;
                OnPropertyChanged("Incendio");
            }
        }
        public Evento Evento
        {
            get { return _Evento; }
            set
            {
                _Evento = value;
                OnPropertyChanged("Evento");
            }
        }
        public ObservableCollection<Evento> Eventos
        {
            get
            {
                return _Eventos;
            }
            set
            {
                _Eventos = value;
                OnPropertyChanged("Eventos");
            }
        }

        public Apoyo Apoyo
        {
            get { return _Apoyo; }
            set
            {
                _Apoyo = value;
                OnPropertyChanged("Apoyo");
            }
        }
        public ObservableCollection<Apoyo> Apoyos
        {
            get
            {
                return _Apoyos;
            }
            set
            {
                _Apoyos = value;
                OnPropertyChanged("Apoyos");
            }
        }
        public AfectadoIncendio AfectadoIncendio
        {
            get { return _AfectadoIncendio; }
            set
            {
                _AfectadoIncendio = value;
                OnPropertyChanged("AfectadoIncendio");
            }
        }
        public ObservableCollection<AfectadoIncendio> AfectadosIncendio
        {
            get
            {
                return _AfectadosIncendio;
            }
            set
            {
                _AfectadosIncendio = value;
                OnPropertyChanged("AfectadosIncendios");
            }
        }
        public AfectadoRescate AfectadoRescate
        {
            get { return _AfectadoRescate; }
            set
            {
                _AfectadoRescate = value;
                OnPropertyChanged("AfectadoRescate");
            }
        }
        public ObservableCollection<AfectadoRescate> AfectadosRescate
        {
            get
            {
                return _AfectadosRescate;
            }
            set
            {
                _AfectadosRescate = value;
                OnPropertyChanged("AfectadosRescate");
            }
        }
        public ObservableCollection<MaterialMayor> MaterialMayorList
        {
            get { return _MaterialMayorList; }
            set
            {
                _MaterialMayorList = value;
                OnPropertyChanged("MateriaMayorList");
            }
        }

        public ObservableCollection<Carro> Carros
        {
            get { return _Carros; }
            set
            {
                _Carros = value;
                OnPropertyChanged("Carros");
            }
        }

        public ObservableCollection<Item> TiposIncendio
        {
            get { return _TiposIncendio; }
            set
            {
                _TiposIncendio = value;
                OnPropertyChanged("TiposIncendio");
            }
        }
        public ObservableCollection<Item> FasesIncendio
        {
            get { return _FasesIncendio; }
            set
            {
                _FasesIncendio = value;
                OnPropertyChanged("FasesIncendio");
            }
        }
        public ObservableCollection<Item> TiposLugar
        {
            get { return _TiposLugar; }
            set
            {
                _TiposLugar = value;
                OnPropertyChanged("TiposLugar");
            }
        }
        public ObservableCollection<Item> TiposConstruccion
        {
            get { return _TiposConstruccion; }
            set
            {
                _TiposConstruccion = value;
                OnPropertyChanged("TiposConstruccion");
            }
        }

        public MaterialMayor MaterialMayor
        {
            get { return _MaterialMayor; }
            set
            {
                _MaterialMayor = value;
                OnPropertyChanged("MaterialMayor");
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
        public Voluntario VoluntarioCargo
        {
            get { return _VoluntarioCargo; }
            set
            {
                _VoluntarioCargo = value;
                OnPropertyChanged("VoluntarioCargo");
                this.Evento.codigoCargo = VoluntarioCargo.codigoRadial;
            }
        }
        public Voluntario VoluntarioInforme
        {
            get { return _VoluntarioInforme; }
            set
            {
                _VoluntarioInforme = value;
                OnPropertyChanged("VoluntarioInforme");
                this.Evento.codigoInforme = VoluntarioInforme.codigoRadial;
            }
        }
        public VoluntarioAsistente Asistente
        {
            get { return _Asistente; }
            set
            {
                _Asistente = value;
                OnPropertyChanged("Asistente");
            }
        }

        public ObservableCollection<Voluntario> VoluntariosSinMarcar
        {
            get
            {
                return _VoluntariosSinMarcar;
            }
            set
            {
                _VoluntariosSinMarcar = value;
                OnPropertyChanged("VoluntariosSinMarcar");
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

        public ObservableCollectionView<Voluntario> VoluntariosSinMarcarView
        {
            get { return _VoluntariosSinMarcarView; }
            set
            {
                _VoluntariosSinMarcarView = value;
                OnPropertyChanged("VoluntariosSinMarcarView");
            }
        }

        public ObservableCollection<Asistencia> Asistentes
        {
            get
            {
                return _Asistentes;
            }
            set
            {
                _Asistentes = value;
                OnPropertyChanged("Asistentes");
            }
        }

        public ObservableCollection<VoluntarioAsistente> AsistentesTabla
        {
            get
            {
                return _AsistentesTabla;
            }
            set
            {
                _AsistentesTabla = value;
                OnPropertyChanged("AsistentesTabla");
            }
        }

        public ICommand GuardarEventoCommand
        {
            get
            {
                _GuardarEventoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarEvento()
                };
                return _GuardarEventoCommand;
            }
        }
        public ICommand ButtonSiguienteCommand
        {
            get
            {
                _ButtonSiguienteCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => ValidarCampos(),
                    ExecuteDelegate = c => ActionButtonSiguiente()
                };
                return _ButtonSiguienteCommand;
            }
        }
        public ICommand ButtonAtrasCommand
        {
            get
            {
                _ButtonAtrasCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => buttonAtrasEnabled,
                    ExecuteDelegate = c => ActionButtonAtras()
                };
                return _ButtonAtrasCommand;
            }
        }
        public ICommand AgregarAsistenciaCommand
        {
            get
            {
                _AgregarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarAsistencia()
                };
                return _AgregarAsistenciaCommand;
            }
        }
        public ICommand EditarAsistenciaCommand
        {
            get
            {
                _EditarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarAsistencia()
                };
                return _EditarAsistenciaCommand;
            }
        }

        public ICommand MarcarRestantesCommand
        {
            get
            {
                _MarcarRestantesCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => MarcarRestantes()
                };
                return _MarcarRestantesCommand;
            }
        }

        public ICommand MarcarCommand
        {
            get
            {
                _MarcarCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => MarcarAsistencia()
                };
                return _MarcarCommand;
            }
        }

        public ICommand AgregarMaterialMayorCommand
        {
            get
            {
                _AgregarMaterialMayorCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarMaterialMayor()
                };
                return _AgregarMaterialMayorCommand;
            }
        }

        public ICommand EditarMaterialMayorCommand
        {
            get
            {
                _EditarMaterialMayorCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarMaterialMayor()
                };
                return _EditarMaterialMayorCommand;
            }
        }

        public ICommand EliminarMaterialMayorCommand
        {
            get
            {
                _EliminarMaterialMayorCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarMaterialMayor()
                };
                return _EliminarMaterialMayorCommand;
            }
        }

        public ICommand AgregarApoyoCommand
        {
            get
            {
                _AgregarApoyoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarApoyo()
                };
                return _AgregarApoyoCommand;
            }
        }

        public ICommand EditarApoyoCommand
        {
            get
            {
                _EditarApoyoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarApoyo()
                };
                return _EditarApoyoCommand;
            }
        }

        public ICommand EliminarApoyoCommand
        {
            get
            {
                _EliminarApoyoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarApoyo()
                };
                return _EliminarApoyoCommand;
            }
        }
        public ICommand AgregarAfectadoIncendioCommand
        {
            get
            {
                _AgregarAfectadoIncendioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarAfectadoIncendio()
                };
                return _AgregarAfectadoIncendioCommand;
            }
        }

        public ICommand EditarAfectadoIncendioCommand
        {
            get
            {
                _EditarAfectadoIncendioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarAfectadoIncendio()
                };
                return _EditarAfectadoIncendioCommand;
            }
        }

        public ICommand EliminarAfectadoIncendioCommand
        {
            get
            {
                _EliminarAfectadoIncendioCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarAfectadoIncendio()
                };
                return _EliminarAfectadoIncendioCommand;
            }
        }
        public ICommand AgregarAfectadoRescateCommand
        {
            get
            {
                _AgregarAfectadoRescateCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarAfectadoRescate()
                };
                return _AgregarAfectadoRescateCommand;
            }
        }

        public ICommand EditarAfectadoRescateCommand
        {
            get
            {
                _EditarAfectadoRescateCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarAfectadoRescate()
                };
                return _EditarAfectadoRescateCommand;
            }
        }

        public ICommand EliminarAfectadoRescateCommand
        {
            get
            {
                _EliminarAfectadoRescateCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarAfectadoRescate()
                };
                return _EliminarAfectadoRescateCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos, FormularioEvento view)
        {
            this.view = view;
            modo = "agregar";

            this.Eventos = Eventos;
            Evento = new Evento();
            Evento.IniciarId();

            VoluntariosSinMarcar = VModel.ObtenerVoluntarios();
            Voluntarios = VModel.ObtenerVoluntarios();
            VoluntariosSinMarcarView = new ObservableCollectionView<Voluntario>(VoluntariosSinMarcar);
            AsistentesTabla = new ObservableCollection<VoluntarioAsistente>();
            Carros = CModel.ObtenerCarros();
            MaterialMayorList = new ObservableCollection<MaterialMayor>();
            Apoyos = new ObservableCollection<Apoyo>();
            AfectadosIncendio = new ObservableCollection<AfectadoIncendio>();
            AfectadosRescate = new ObservableCollection<AfectadoRescate>();

            TiposIncendio = ItModel.ObtenerItemsCategoria(2);
            FasesIncendio = ItModel.ObtenerItemsCategoria(3);
            TiposLugar = ItModel.ObtenerItemsCategoria(4);
            TiposConstruccion = ItModel.ObtenerItemsCategoria(5);
        }
        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos, Evento Evento, FormularioEvento view)
        {
            this.view = view;
            modo = "editar";

            this.Evento = Evento;
            this.Eventos = Eventos;

            if (Evento.codigoServicio == "02")
            {
                IncendioVisible = "Visible";
                IncendioEnabled = true;
                RescateVisible = "Hidden";
                RescateEnabled = false;

                Incendio = IModel.ObtenerIncendioEvento(Evento.idEvento);
                AfectadosIncendio = AIModel.ObtenerAfectadosIncendio(Incendio.idIncendio);
            }
            else if (Evento.codigoServicio == "03")
            {
                IncendioVisible = "Hidden";
                IncendioEnabled = false;
                RescateVisible = "Visible";
                RescateEnabled = true;
            }

            Carros = CModel.ObtenerCarros();
            Voluntarios = VModel.ObtenerVoluntarios();
            MaterialMayorList = MMModel.ObtenerMaterialMayorEvento(Evento.idEvento);
            VoluntariosSinMarcar = VModel.ObtenerVoluntariosSinMarcarAsistencia(Evento.idEvento);
            Apoyos = ApModel.ObtenerApoyosEvento(Evento.idEvento);
            VoluntariosSinMarcarView = new ObservableCollectionView<Voluntario>(VoluntariosSinMarcar);
            Asistentes = AModel.ObtenerAsistentesEvento(Evento.idEvento);
            AsistentesTabla = new ObservableCollection<VoluntarioAsistente>();
            foreach (Asistencia asistente in Asistentes)
            {
                VoluntarioAsistente asistente_tabla = new VoluntarioAsistente(
                    asistente.fk_idVoluntario,
                    VModel.ObtenerRutVoluntario(asistente.fk_idVoluntario),
                    VModel.ObtenerNombreVoluntario(asistente.fk_idVoluntario),
                    VModel.ObtenerCargoVoluntario(asistente.fk_idVoluntario),
                    asistente.codigoAsistencia);

                AsistentesTabla.Insert(0, asistente_tabla);
            }

            TiposIncendio = ItModel.ObtenerItemsCategoria(2);
            FasesIncendio = ItModel.ObtenerItemsCategoria(3);
            TiposLugar = ItModel.ObtenerItemsCategoria(4);
            TiposConstruccion = ItModel.ObtenerItemsCategoria(5);
        }

        private void AgregarMaterialMayor()
        {
            if(!MMModel.ExisteMaterialMayor(Carro.idCarro, Evento.idEvento))
            {
                var viewmodel = new FormularioMaterialMayorViewModel(MaterialMayorList, Evento.idEvento, Carro.idCarro);
                var view = new FormularioMaterialMayor();
                view.DataContext = viewmodel;
                viewmodel.CloseAction = new Action(view.Close);
                view.Show();
            }
        }
        private void EditarMaterialMayor()
        {
            var viewmodel = new FormularioMaterialMayorViewModel(MaterialMayorList, MaterialMayor);
            var view = new FormularioMaterialMayor();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EliminarMaterialMayor()
        {
            MMModel.EliminarMaterialMayor(MaterialMayor.idCarroEvento);
            MaterialMayorList.Remove(MaterialMayor);
        }

        private void AgregarApoyo()
        {
            var viewmodel = new FormularioApoyoViewModel(Apoyos,Evento.idEvento);
            var view = new FormularioApoyo();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EditarApoyo()
        {
            var viewmodel = new FormularioApoyoViewModel(Apoyos, Apoyo);
            var view = new FormularioApoyo();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EliminarApoyo()
        {
            ApModel.EliminarApoyo(Apoyo.idApoyo);
            Apoyos.Remove(Apoyo);
        }

        private void AgregarAfectadoIncendio()
        {
            var viewmodel = new FormularioAfectadoIncendioViewModel(AfectadosIncendio, Incendio.idIncendio);
            var view = new FormularioAfectadoIncendio();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EditarAfectadoIncendio()
        {
            var viewmodel = new FormularioAfectadoIncendioViewModel(AfectadosIncendio, AfectadoIncendio);
            var view = new FormularioAfectadoIncendio();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EliminarAfectadoIncendio()
        {
            AIModel.EliminarAfectadoIncendio(AfectadoIncendio.idAfectado);
            AfectadosIncendio.Remove(AfectadoIncendio);
        }

        private void AgregarAfectadoRescate()
        {
            var viewmodel = new FormularioAfectadoRescateViewModel(AfectadosRescate, Evento.idEvento);
            var view = new FormularioAfectadoRescate();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EditarAfectadoRescate()
        {
            var viewmodel = new FormularioAfectadoRescateViewModel(AfectadosRescate, AfectadoRescate);
            var view = new FormularioAfectadoRescate();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }
        private void EliminarAfectadoRescate()
        {
            ARModel.EliminarAfectadoRescate(AfectadoRescate.idRescate);
            AfectadosRescate.Remove(AfectadoRescate);
        }

        private String obtenerCodigoAsistenciaSeleccionado(String tipo)
        {
            string codigo = "";
            if (tipo == "asistenciaMensual")
            {
                if (Evento.asistenciaObligatoria)
                {
                    if (aChecked) codigo = "A";
                    if (fChecked) codigo = "F";
                    if (lChecked) codigo = "L";
                }
                else
                {
                    if (aChecked) codigo = "a";
                    if (fChecked) codigo = " ";
                    if (lChecked) codigo = " ";
                }
            }
            else if(tipo == "hojaVida")
            {
                if (Evento.asistenciaObligatoria)
                {
                    if (aChecked) codigo = "A";
                    if (fChecked) codigo = "F";
                    if (lChecked) codigo = "null";
                }
                else
                {
                    if (aChecked) codigo = "A";
                    if (fChecked) codigo = "null";
                    if (lChecked) codigo = "null";
                }
            }
            return codigo;
        }

        private void AgregarAsistenciaHistoria(Voluntario voluntario)
        {
            if (obtenerCodigoAsistenciaSeleccionado("hojaVida") != "null")
            {
                int fk_ano = AHAModel.AgregarAnoHistoriaAsistencia(Evento.fecha.Year, voluntario.idVoluntario);

                MHAModel.AgregarMesHistoriaAsistencia(fk_ano, Evento.fecha.Month, obtenerCodigoAsistenciaSeleccionado("hojaVida"));
                if (Evento.asistenciaObligatoria)
                {
                    MHAModel.AgregarMesHistoriaAsistencia(fk_ano, Evento.fecha.Month,"LL");
                }
            }
        }

        private void AgregarAsistencia()
        {
            try
            {
                String codigo = obtenerCodigoAsistenciaSeleccionado("asistenciaMensual");

                Asistencia Asistencia = new Asistencia(Voluntario.idVoluntario, Evento.idEvento, codigo, Evento.asistenciaObligatoria);
                AModel.AgregarAsistencia(Asistencia);

                AgregarAsistenciaHistoria(Voluntario);

                VoluntarioAsistente asistente_tabla = new VoluntarioAsistente(
                    Voluntario.idVoluntario,
                    Voluntario.rut,
                    VModel.ObtenerNombreVoluntario(Voluntario.idVoluntario),
                    VModel.ObtenerCargoVoluntario(Voluntario.idVoluntario),
                    codigo);
                AsistentesTabla.Insert(0, asistente_tabla);
                VoluntariosSinMarcar.Remove(Voluntario);
            }
            catch (Exception e)
            {
                Debug.Write(e.Data);
            }
        }

        private void MarcarAsistencia()
        {

        }

        private void EditarAsistencia()
        {
            String codigo = obtenerCodigoAsistenciaSeleccionado("asistenciaMensual");
            Asistente.codigo_asistencia = codigo;
            AModel.EditarAsistencia(new Asistencia(Asistente.id,Evento.idEvento,codigo,Evento.asistenciaObligatoria));
        }

        private void MarcarRestantes()
        {
            String codigo = obtenerCodigoAsistenciaSeleccionado("asistenciaMensual");
            Asistencia Asistencia;
            Loading = true;
            foreach(Voluntario voluntario in VoluntariosSinMarcar)
            {
                Asistencia = new Asistencia(voluntario.idVoluntario, Evento.idEvento, codigo, Evento.asistenciaObligatoria);
                AModel.AgregarAsistencia(Asistencia);

                AgregarAsistenciaHistoria(voluntario);

                VoluntarioAsistente asistente_tabla = new VoluntarioAsistente(
                    voluntario.idVoluntario,
                    voluntario.rut,
                    VModel.ObtenerNombreVoluntario(voluntario.idVoluntario),
                    VModel.ObtenerCargoVoluntario(voluntario.idVoluntario),
                    codigo);
                AsistentesTabla.Insert(0, asistente_tabla);
            }
            Loading = false;
            VoluntariosSinMarcar.Clear();
        }

        private bool ValidarCampos()
        {
            if (Evento.codigoServicio == "02")
            {
                IncendioVisible = "Visible";
                IncendioEnabled = true;
                RescateVisible = "Hidden";
                RescateEnabled = false;
            }
            else if (Evento.codigoServicio == "03")
            {
                IncendioVisible = "Hidden";
                IncendioEnabled = false;
                RescateVisible = "Visible";
                RescateEnabled = true;
            }

            if (Evento.claveServicio == null || Evento.claveServicio.Length == 0) return false;
            else return true;
        }

        
        private void GuardarEvento()
        {
            Eventos.Add(Evento);
            EModel.AgregarEvento(Evento);
        }

        private void GuardarIncendio()
        {
            IModel.AgregarIncendio(Incendio);
        }

        private async void ActionButtonSiguiente()
        {
            switch (tabIndex)
            {
                case 0:
                    if (Evento.codigoServicio == "02")
                    {
                        if (modo == "agregar")
                        {
                            Incendio = new Incendio();
                            Incendio.fk_idEventoInc = Evento.idEvento;
                            Incendio.IniciarId();
                        }
                    }
                    else if (Evento.codigoServicio == "03")
                    {
                        
                    }
                    buttonAtrasEnabled = true;
                    tab2enabled = true;   
                    break;
                case 1:
                    tab3enabled = true;
                    break;
                case 2:
                    SiguienteButtonContent = "Guardar";
                    break;
                case 3:
                    if (VoluntariosSinMarcar.Count > 0)
                    {
                        MetroDialogSettings settings = new MetroDialogSettings();
                        settings.NegativeButtonText = "Cancelar";
                        settings.AffirmativeButtonText = "Continuar";
                        MessageDialogResult result = await view.ShowMessageAsync("Estas seguro?", "Quedaron voluntarios sin marcar asistencia, se les marcará falta a todos ellos, continuar?",MessageDialogStyle.AffirmativeAndNegative,settings);
                        if(result == MessageDialogResult.Affirmative)
                        {
                            fChecked = true;
                            MarcarRestantes();
                            GuardarYCerrarFormularioEvento();
                        }
                    }
                    else GuardarYCerrarFormularioEvento();
                    break;
            }
            if (tabIndex < 3) tabIndex++;
        }
        private void GuardarYCerrarFormularioEvento()
        {
            if (modo == "agregar")
            {
                GuardarEvento();
                if (Evento.codigoServicio == "02") GuardarIncendio();
            }
            else if (modo == "editar")
            {
                EModel.EditarEvento(Evento, Evento.idEvento);
                if (Evento.codigoServicio == "02") IModel.EditarIncendio(Incendio, Incendio.idIncendio);
            }
            CloseAction();
        }
        private void ActionButtonAtras()
        {
            switch (tabIndex)
            {
                case 0:
                    break;
                case 1:
                    buttonAtrasEnabled = false;
                    break;
                case 2:
                    break;
                case 3:
                    SiguienteButtonContent = "Siguiente";
                    break;
            }
            if (tabIndex > 0) tabIndex--;
        }
        #endregion

    }
}
