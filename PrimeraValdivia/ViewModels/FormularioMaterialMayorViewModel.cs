using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraValdivia.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PrimeraValdivia.Commands;
using PrimeraValdivia.Views;
using System.Diagnostics;
using System.Windows;

namespace PrimeraValdivia.ViewModels
{
    class FormularioMaterialMayorViewModel : ViewModelBase
    {
        #region Atributos Privados

        private ObservableCollection<MaterialMayor> _MaterialMayorList;
        private MaterialMayor _MaterialMayor;
        private ICommand _GuardarMaterialMayorCommand;
        private string modo;
        private int idMaterialMayorActual;

        private MaterialMayor MMModel = new MaterialMayor();

        #endregion

        #region Atributos Publicos

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
            
        }
        public FormularioMaterialMayorViewModel(ObservableCollection<MaterialMayor> MaterialMayorList, MaterialMayor MaterialMayor)
        {
            this.idMaterialMayorActual = MaterialMayor.idCarroEvento;
            this.modo = "editar";
            this.MaterialMayorList = MaterialMayorList;
            this.MaterialMayor = MaterialMayor;
        }

        private void GuardarMaterialMayor()
        {
            if (this.modo.Equals("agregar"))
            {
                MMModel.AgregarMaterialMayor(MaterialMayor);
                MaterialMayorList.Add(MaterialMayor);
                CloseAction();
            }
            if (this.modo.Equals("editar"))
            {
                MMModel.EditarMaterialMayor(MaterialMayor, this.idMaterialMayorActual);
                CloseAction();
            }
        }

        #endregion
    }
}