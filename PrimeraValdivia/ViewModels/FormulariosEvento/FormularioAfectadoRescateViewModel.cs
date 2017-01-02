using PrimeraValdivia.Models;
using PrimeraValdivia.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels.FormulariosEvento
{
    class FormularioAfectadoRescateViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<Material> _Materiales;
        private Material _Material;
        private ICommand _GuardarMaterialCommand;
        private string modo;
        private int idMaterialActual;

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

        #endregion

        #region Metodos

        public FormularioAfectadoRescateViewModel(ObservableCollection<Material> Materials, int idCarro)
        {
            this.modo = "agregar";
            Material = new Material();
            Material.IniciarId();
            Material.fk_idCarro = idCarro;
            this.Materiales = Materials;
        }
        public FormularioAfectadoRescateViewModel(ObservableCollection<Material> Materials, Material Material)
        {
            this.idMaterialActual = Material.idMaterial;
            this.Materiales = Materials;
            this.modo = "editar";
            this.Material = Material;
        }

        private void GuardarMaterial()
        {
            if (this.modo.Equals("agregar"))
            {
                MModel.AgregarMaterial(this.Material);
                Materiales.Add(Material);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                MModel.EditarMaterial(this.Material, idMaterialActual);
                CloseAction();
            }
        }


        #endregion
    }
}
