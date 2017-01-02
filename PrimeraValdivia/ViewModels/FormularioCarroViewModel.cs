using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Helpers;
using PrimeraValdivia.Views;
using System.Diagnostics;
using System.Windows;

namespace PrimeraValdivia.ViewModels
{
    class FormularioCarroViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<Carro> _Carros;
        private ObservableCollection<Material> _Materiales;
        private Material _Material;
        private Carro _Carro;
        private ICommand _GuardarCarroCommand;
        private ICommand _AgregarMaterialCommand;
        private ICommand _GuardarMaterialCommand;
        private ICommand _MostrarFormularioMaterialCommand;
        private ICommand _EliminarMaterialCommand;
        private string modo;
        private int idCarroActual;

        private Carro model = new Carro();
        private Material MModel = new Material();

        #endregion

        #region Atributos Publicos

        public Action CloseAction { get; set; }

        public Material Material
        {
            get { return _Material; }
            set
            {
                _Material = value;
                OnPropertyChanged("Material");
            }
        }

        public ObservableCollection<Material> Materiales
        {
            get { return _Materiales; }
            set
            {
                _Materiales = value;
                OnPropertyChanged("Materiales");
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

        public ObservableCollection<Carro> Carros
        {
            get
            {
                return _Carros;
            }
            set
            {
                _Carros = value;
                OnPropertyChanged("Carros");
            }
        }

        public ICommand GuardarCarroCommand
        {
            get
            {
                _GuardarCarroCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarCarro()
                };
                return _GuardarCarroCommand;
            }
        }

        public ICommand AgregarMaterialCommand
        {
            get
            {
                _AgregarMaterialCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarMaterial()
                };
                return _AgregarMaterialCommand;
            }
        }

        public ICommand MostrarFormularioMaterialCommand
        {
            get
            {
                _MostrarFormularioMaterialCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EditarMaterial()
                };
                return _MostrarFormularioMaterialCommand;
            }
        }

        public ICommand GuardarMaterialCommand
        {
            get
            {
                _GuardarMaterialCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarMaterial()
                };
                return _GuardarMaterialCommand;
            }
        }

        public ICommand EliminarMaterialCommand
        {
            get
            {
                _EliminarMaterialCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarMaterial()
                };
                return _EliminarMaterialCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioCarroViewModel(ObservableCollection<Carro> Carros)
        {
            this.modo = "agregar";
            this.Carros = Carros;
            Carro = new Carro();
            Carro.IniciarId();

            Materiales = MModel.ObtenerMaterials(Carro.idCarro); //ver si hay algun material asociado al ID, iniciar 'Materiales'
        }
        public FormularioCarroViewModel(ObservableCollection<Carro> Carros, Carro Carro)
        {
            Materiales = MModel.ObtenerMaterials(Carro.idCarro);

            this.idCarroActual = Carro.idCarro;
            this.modo = "editar";
            this.Carros = Carros;
            this.Carro = Carro;
        }

        private void AgregarMaterial()
        {
            var viewmodel = new FormularioMaterialViewModel(Materiales, this.Carro.idCarro);
            var view = new FormularioMaterial();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
            
        }

        private void EliminarMaterial()
        {
            MModel.EliminarMaterial(Material.idMaterial);
            Materiales.Remove(Material);
        }

        private void EditarMaterial()
        {
            var viewmodel = new FormularioMaterialViewModel(Materiales, Material);
            var view = new FormularioMaterial();
            view.DataContext = viewmodel;
            viewmodel.CloseAction = new Action(view.Close);
            view.Show();
        }

        private void GuardarMaterial()
        {
            MModel.AgregarMaterial(this.Material);
            Materiales.Add(this.Material);
        }

        private void GuardarCarro()
        {
            if (this.modo.Equals("agregar"))
            {
                model.AgregarCarro(Carro);
                Carros.Add(Carro);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                model.EditarCarro(Carro, this.idCarroActual);
                CloseAction();
            }
        }

        #endregion
    }
}
