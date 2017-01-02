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
using MyToolkit.Collections;

namespace PrimeraValdivia.ViewModels
{
    class FormularioMaterialMayorViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<MaterialMayor> _MaterialMayorList;
        private MaterialMayor _MaterialMayor;

        private ObservableCollection<Material> _MaterialesCarro;
        private ObservableCollectionView<Material> _MaterialesCarroView;
        private Material _MaterialCarro;

        private ObservableCollection<MaterialEventoClass> _MaterialesEvento;
        private MaterialEventoClass _MaterialEvento;

        private ICommand _GuardarMaterialMayorCommand;
        private ICommand _AgregarMaterialEventoCommand;
        private ICommand _EliminarMaterialEventoCommand;

        private string _Filter;
        private string modo;
        private int idMaterialMayorActual;
        private float kms;

        private MaterialMayor MMModel = new MaterialMayor();
        private Material MModel = new Material();
        private Material_MaterialMayor MMMModel = new Material_MaterialMayor();
        private Carro CModel = new Carro();

        public class MaterialEventoClass : ViewModelBase
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

            private String _descripcion;
            public String descripcion
            {
                get { return _descripcion; }
                set
                {
                    _descripcion = value;
                    OnPropertyChanged("descripcion");
                }
            }
            
            public MaterialEventoClass(int id, String nombre, String descripcion)
            {
                this.id = id;
                this.nombre = nombre;
                this.descripcion = descripcion;
            }
        }

        #endregion

        #region Atributos Publicos

        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                OnPropertyChanged("Filter");
                MaterialesCarroView.Filter = p => p.nombre.IndexOf(_Filter, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        public Action CloseAction { get; set; }

        public MaterialMayor MaterialMayor
        {
            get { return _MaterialMayor; }
            set
            {
                _MaterialMayor = value;
                OnPropertyChanged("MaterialMayor");
            }
        }

        public ObservableCollection<MaterialMayor> MaterialMayorList
        {
            get
            {
                return _MaterialMayorList;
            }
            set
            {
                _MaterialMayorList = value;
                OnPropertyChanged("MaterialMayorList");
            }
        }

        public Material MaterialCarro
        {
            get { return _MaterialCarro; }
            set
            {
                _MaterialCarro = value;
                OnPropertyChanged("MaterialCarro");
            }
        }

        public ObservableCollection<Material> MaterialesCarro
        {
            get { return _MaterialesCarro; }
            set
            {
                _MaterialesCarro = value;
                OnPropertyChanged("MaterialesCarro");
            }
        }

        public ObservableCollectionView<Material> MaterialesCarroView
        {
            get { return _MaterialesCarroView; }
            set
            {
                _MaterialesCarroView = value;
                OnPropertyChanged("MaterialesCarroView");
            }
        }

        public MaterialEventoClass MaterialEvento
        {
            get { return _MaterialEvento; }
            set
            {
                _MaterialEvento = value;
                OnPropertyChanged("MaterialEvento");
            }
        }

        public ObservableCollection<MaterialEventoClass> MaterialesEvento
        {
            get { return _MaterialesEvento; }
            set
            {
                _MaterialesEvento = value;
                OnPropertyChanged("MaterialesEvento");
            }
        }

        public ICommand GuardarMaterialMayorCommand
        {
            get
            {
                _GuardarMaterialMayorCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GuardarMaterialMayor()
                };
                return _GuardarMaterialMayorCommand;
            }
        }

        public ICommand AgregarMaterialEventoCommand
        {
            get
            {
                _AgregarMaterialEventoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => AgregarMaterialEvento()
                };
                return _AgregarMaterialEventoCommand;
            }
        }

        public ICommand EliminarMaterialEventoCommand
        {
            get
            {
                _EliminarMaterialEventoCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => EliminarMaterialEvento()
                };
                return _EliminarMaterialEventoCommand;
            }
        }

        #endregion

        #region Metodos

        public FormularioMaterialMayorViewModel(ObservableCollection<MaterialMayor> MaterialMayorList, int idEvento, int idCarro)
        {
            this.modo = "agregar";
            this.MaterialMayorList = MaterialMayorList;
            MaterialMayor = new MaterialMayor();
            MaterialMayor.IniciarId();
            MaterialMayor.fk_idCarroMaterial = idCarro;
            MaterialMayor.fk_idEventoMaterial = idEvento;

            MaterialesCarro = MModel.ObtenerMaterials(idCarro);
            MaterialesCarroView = new ObservableCollectionView<Material>(MaterialesCarro);
            MaterialesEvento = new ObservableCollection<MaterialEventoClass>();
        }
        public FormularioMaterialMayorViewModel(ObservableCollection<MaterialMayor> MaterialMayorList, MaterialMayor MaterialMayor)
        {
            this.idMaterialMayorActual = MaterialMayor.idCarroEvento;
            this.modo = "editar";
            this.kms = MaterialMayor.kilometrajeLlegada - MaterialMayor.kilometrajeSalida;
            this.MaterialMayorList = MaterialMayorList;
            this.MaterialMayor = MaterialMayor;

            MaterialesCarro = MModel.ObtenerMaterialsSinOcupar(MaterialMayor.idCarroEvento,MaterialMayor.fk_idCarroMaterial);
            MaterialesCarroView = new ObservableCollectionView<Material>(MaterialesCarro);

            var MaterialesMatMayor = MMMModel.ObtenerMateriales(MaterialMayor.idCarroEvento);
            MaterialesEvento = new ObservableCollection<MaterialEventoClass>();
            foreach(Material_MaterialMayor material in MaterialesMatMayor)
            {
                MaterialEventoClass MaterialEvento_tabla = new MaterialEventoClass(
                    material.fk_idMaterial,
                    MModel.ObtenerNombreMaterial(material.fk_idMaterial),
                    MModel.ObtenerDescripcionMaterial(material.fk_idMaterial));
                MaterialesEvento.Insert(0, MaterialEvento_tabla);
            }
        }
        private void GuardarMaterialMayor()
        {
            float kmRecorridos = MaterialMayor.kilometrajeLlegada - MaterialMayor.kilometrajeSalida;
            if (this.modo.Equals("agregar"))
            {
                MMModel.AgregarMaterialMayor(MaterialMayor);
                MaterialMayorList.Add(MaterialMayor);

                CModel.SumarKilometraje(MaterialMayor.fk_idCarroMaterial, kmRecorridos);

                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                kmRecorridos = kmRecorridos - this.kms;

                MMModel.EditarMaterialMayor(MaterialMayor, this.idMaterialMayorActual);
                CModel.SumarKilometraje(MaterialMayor.fk_idCarroMaterial, kmRecorridos);
                CloseAction();
            }
        }
        private void AgregarMaterialEvento()
        {
            Material_MaterialMayor materialCarro = new Material_MaterialMayor();
            materialCarro.fk_idMaterialMayor = MaterialMayor.idCarroEvento;
            materialCarro.fk_idMaterial = MaterialCarro.idMaterial;
            materialCarro.IniciarId();

            MMMModel.AgregarMaterial_MaterialMayor(materialCarro);

            MaterialEventoClass MaterialEvento_tabla = new MaterialEventoClass(
                    MaterialCarro.idMaterial,
                    MModel.ObtenerNombreMaterial(MaterialCarro.idMaterial),
                    MModel.ObtenerDescripcionMaterial(MaterialCarro.idMaterial));
            MaterialesEvento.Insert(0, MaterialEvento_tabla);

            MaterialesCarro.Remove(MaterialCarro);
        }

        private void EliminarMaterialEvento()
        {
            Material_MaterialMayor materialCarro = new Material_MaterialMayor();
            materialCarro.fk_idMaterialMayor = MaterialMayor.idCarroEvento;
            materialCarro.fk_idMaterial = MaterialEvento.id;

            MMMModel.EliminarMaterial_MaterialMayor(materialCarro);

            Material MaterialCarro_tabla = new Material();
            MaterialCarro_tabla.fk_idCarro = MaterialMayor.fk_idCarroMaterial;
            MaterialCarro_tabla.idMaterial = MaterialEvento.id;
            MaterialCarro_tabla.nombre = MModel.ObtenerNombreMaterial(MaterialEvento.id);

            MaterialesCarro.Insert(0, MaterialCarro_tabla);

            MaterialesEvento.Remove(MaterialEvento);

        }

        #endregion
    }
}