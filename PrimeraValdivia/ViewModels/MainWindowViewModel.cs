using PrimeraValdivia.Helpers;
using PrimeraValdivia.Views;
using System.Windows.Input;

namespace PrimeraValdivia.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private bool _Loading = false;
        private string _Title;

        private ICommand _GenerarDocumentosCommand;
        
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
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
        
        public ICommand GenerarDocumentosCommand
        {
            get
            {
                _GenerarDocumentosCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GenerarDocumentoButtonAction()
                };
                return _GenerarDocumentosCommand;
            }
        }

        public MainWindowViewModel()
        {
            _Title = "Primera Valdivia";
            var utils = new Utils();
            utils.crearBD();
            //utils.cargarBD();
        }

        private void GenerarDocumentoButtonAction()
        {
            Loading = true;
            var view = new GenerarDocs();
            var viewmodel = new GenerarDocsViewModel();
            view.DataContext = viewmodel;
            view.Show();
            Loading = false;
        }

    }
}
