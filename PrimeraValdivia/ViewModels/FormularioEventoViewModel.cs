using MyToolkit.Collections;
using PrimeraValdivia.Commands;
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

        private ObservableCollection<Voluntario> _Voluntarios;
        private ObservableCollection<Voluntario> _VoluntariosSinMarcar;
        private ObservableCollectionView<Voluntario> _VoluntariosSinMarcarView;

        private MaterialMayor _MaterialMayor;
        private ObservableCollection<MaterialMayor> _MaterialMayorList;

        private Carro _Carro;
        private ObservableCollection<Carro> _Carros;

        private ObservableCollection<Asistencia> _Asistentes;
        private ObservableCollection<Evento> _Eventos;
        private ObservableCollection<VoluntarioAsistente> _AsistentesTabla;
        private ICommand _GuardarEventoCommand;
        private ICommand _AvanzarInformeUnoCommand;
        private ICommand _AgregarAsistenciaCommand;
        private ICommand _EditarAsistenciaCommand;
        private ICommand _MarcarRestantesCommand;
        private ICommand _MarcarCommand;

        private ICommand _AgregarMaterialMayorCommand;
        private ICommand _EditarMaterialMayorCommand;
        private ICommand _EliminarMaterialMayorCommand;

        private string _tab2header = "Datos";
        private string _nameFilter; 
        private bool _tab2enabled = false;
        private bool _tab3enabled = false;
        private bool _aChecked = true;
        private bool _fChecked;
        private bool _lChecked;
        private int _tabIndex;

        private Asistencia AModel = new Asistencia();
        private Voluntario VModel = new Voluntario();
        private Evento EModel = new Evento();
        private Carro CModel = new Carro();
        private MaterialMayor MMModel = new MaterialMayor();
        
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

        #endregion

        #region Atributos publicos

        public Action CloseAction { get; set; }

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
                VoluntariosSinMarcarView.Filter = p => p.nombre.Contains(_nameFilter);
            }
        }

        public string tab2header
        {
            get { return _tab2header; }
            set
            {
                _tab2header = value;
                OnPropertyChanged("tab2header");
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

        public Evento Evento
        {
            get { return _Evento; }
            set
            {
                _Evento = value;
                OnPropertyChanged("Evento");
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
        public ICommand AvanzarInformeUnoCommand
        {
            get
            {
                _AvanzarInformeUnoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => ValidarCampos(),
                    ExecuteDelegate = c => AvanzarInformeUno()
                };
                return _AvanzarInformeUnoCommand;
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

        #endregion

        #region Metodos

        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos)
        {
            this.Eventos = Eventos;
            Evento = new Evento();
            Evento.IniciarId();
            VoluntariosSinMarcar = VModel.ObtenerVoluntarios();
            Voluntarios = VoluntariosSinMarcar;
            VoluntariosSinMarcarView = new ObservableCollectionView<Voluntario>(VoluntariosSinMarcar);
            AsistentesTabla = new ObservableCollection<VoluntarioAsistente>();
            Carros = CModel.ObtenerCarros();
            MaterialMayorList = new ObservableCollection<MaterialMayor>();
        }
        public FormularioEventoViewModel(ObservableCollection<Evento> Eventos, Evento Evento)
        {
            this.Evento = Evento;
            this.Eventos = Eventos;

            Carros = CModel.ObtenerCarros();
            Voluntarios = VModel.ObtenerVoluntarios();
            MaterialMayorList = MMModel.ObtenerMaterialMayorEvento(Evento.idEvento);
            VoluntariosSinMarcar = VModel.ObtenerVoluntariosSinMarcarAsistencia(Evento.idEvento);
            VoluntariosSinMarcarView = new ObservableCollectionView<Voluntario>(VoluntariosSinMarcar);
            tab2enabled = true;
            tab3enabled = true;
            DeterminarClaveServicio();
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
        }

        private void AgregarMaterialMayor()
        {
            var viewmodel = new FormularioMaterialMayorViewModel(MaterialMayorList, Evento.idEvento, Carro.idCarro);
            var view = new FormularioMaterialMayor();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
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

        private String obtenerCodigoAsistenciaSeleccionado()
        {
            string codigo = "";
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
            return codigo;
        }

        private void AgregarAsistencia()
        {
            String codigo = obtenerCodigoAsistenciaSeleccionado();

            Asistencia Asistencia = new Asistencia(Voluntario.idVoluntario, Evento.idEvento, codigo, Evento.asistenciaObligatoria);
            AModel.AgregarAsistencia(Asistencia);
            VoluntarioAsistente asistente_tabla = new VoluntarioAsistente(
                Voluntario.idVoluntario,
                Voluntario.rut,
                VModel.ObtenerNombreVoluntario(Voluntario.idVoluntario),
                VModel.ObtenerCargoVoluntario(Voluntario.idVoluntario),
                codigo);
            AsistentesTabla.Insert(0, asistente_tabla);
            VoluntariosSinMarcar.Remove(Voluntario);
        }

        private void MarcarAsistencia()
        {

        }

        private void EditarAsistencia()
        {
            String codigo = obtenerCodigoAsistenciaSeleccionado();
            Asistente.codigo_asistencia = codigo;
            AModel.EditarAsistencia(new Asistencia(Asistente.id,Evento.idEvento,codigo,Evento.asistenciaObligatoria));
        }

        private void MarcarRestantes()
        {
            String codigo = obtenerCodigoAsistenciaSeleccionado();
            Asistencia Asistencia;
            foreach(Voluntario voluntario in VoluntariosSinMarcar)
            {
                Asistencia = new Asistencia(voluntario.idVoluntario, Evento.idEvento, codigo, Evento.asistenciaObligatoria);
                AModel.AgregarAsistencia(Asistencia);

                VoluntarioAsistente asistente_tabla = new VoluntarioAsistente(
                    voluntario.idVoluntario,
                    voluntario.rut,
                    VModel.ObtenerNombreVoluntario(voluntario.idVoluntario),
                    VModel.ObtenerCargoVoluntario(voluntario.idVoluntario),
                    codigo);
                AsistentesTabla.Insert(0, asistente_tabla);
            }
            VoluntariosSinMarcar.Clear();
        }

        private bool ValidarCampos()
        {
            if (Evento.claveServicio == null || Evento.claveServicio.Length == 0) return false;
            else return true;
        }

        
        private void GuardarEvento()
        {
            Eventos.Add(Evento);
            CloseAction();
        }
        private void DeterminarClaveServicio()
        {
            if (Evento.codigoServicio.Equals("02"))
            {
                tab2header = "Datos Incendio";
                tab2enabled = true;
            }
            else if (Evento.codigoServicio.Equals("03"))
            {
                tab2header = "Datos Rescate";
                tab2enabled = true;
            }
        }
        private void AvanzarInformeUno()
        {
            tabIndex = 1;
            if (!Eventos.Contains(Evento))
            {
                DeterminarClaveServicio();
                Eventos.Add(Evento);
                EModel.AgregarEvento(Evento);
            }
        }

        #endregion

    }
}
