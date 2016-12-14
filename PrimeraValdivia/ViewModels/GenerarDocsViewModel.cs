using PrimeraValdivia.Commands;
using PrimeraValdivia.Models;
using PrimeraValdivia.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PrimeraValdivia.ViewModels
{
    class GenerarDocsViewModel : ViewModelBase
    {
        #region Variables privadas
        
        private ICommand _GenerarAsistenciaCommand;
        private ObservableCollection<Voluntario> Voluntarios;

        private Evento EModel = new Evento();
        private Voluntario VModel = new Voluntario();

        #endregion

        #region Propiedades/Comandos públicos

        public ICommand GenerarAsistenciaCommand
        {
            get
            {
                _GenerarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => GenerarAsistencia()
                };
                return _GenerarAsistenciaCommand;
            }
        }
        #endregion

        #region Constructor/Métodos

        public GenerarDocsViewModel()
        {
            
        }
        
        private void GenerarAsistencia()
        {
            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"Asistencia.pdf", FileMode.Create));

            doc.AddTitle("Asistencia");
            doc.AddCreator("Primera Compañia de Valdivia");

            Voluntarios = VModel.ObtenerVoluntarios();

            doc.Open();

            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(2);

            table.AddCell("Nombre");
            table.AddCell("Cargo");

            foreach (Voluntario voluntario in Voluntarios)
            {
                table.AddCell(voluntario.nombre);
                table.AddCell(voluntario.cargo);
            }
            
            doc.Add(table);

            doc.Close();
            writer.Close();
        }

        #endregion
    }
}