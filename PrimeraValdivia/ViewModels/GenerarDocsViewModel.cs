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
        private ObservableCollection<Evento> Eventos;

        private Evento EModel = new Evento();
        private Voluntario VModel = new Voluntario();
        private Asistencia AModel = new Asistencia();

        private string fechaDoc = ""; 

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

        public ICommand MostrarFechaCommand
        {
            get
            {
                _GenerarAsistenciaCommand = new RelayCommand()
                {
                    CanExecuteDelegate = c => true,
                    ExecuteDelegate = c => mostrarFecha()
                };
                return _GenerarAsistenciaCommand;
            }
        }

        public string fecha
        {
            get { return fechaDoc; }
            set
            {
                fechaDoc = value;
                OnPropertyChanged("fecha");
            }
        }

        #endregion

        #region Constructor/Métodos

        public GenerarDocsViewModel()
        {
            
        }

        public string mostrarFecha() {
            return this.fecha;
        }


        private void GenerarAsistencia()
        {
            Document doc = new Document(PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"Asistencia.pdf", FileMode.Create));

            doc.AddTitle("Asistencia");
            doc.AddCreator("Primera Compañia de Valdivia");

            Voluntarios = VModel.ObtenerVoluntarios();
            Eventos = EModel.ObtenerEventos();

            doc.Open();

            Font standardFont = new Font(Font.FontFamily.HELVETICA, 6, Font.NORMAL, BaseColor.BLACK);
            
            doc.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(2+Eventos.Count+6);
            table.WidthPercentage = 100;

            float[] widths = new float[2 + Eventos.Count + 6];
            widths[0] = 160f;
            widths[1] = 30f;
            for(int i = 2;i<Eventos.Count + 2; i++)
            {
                widths[i] = 25f;
            }
            for(int i = Eventos.Count + 2;i < Eventos.Count + 2 + 6; i++)
            {
                widths[i] = 8f;
            }

            table.SetWidths(widths);

            PdfPCell header = new PdfPCell(new Phrase("COMPAÑÍA N°      1ªCia              MES DE : AGOSTO 2016"));
            header.Colspan = 2 + Eventos.Count + 6;
            header.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(header);

            PdfPTable tableVoluntarios = new PdfPTable(2);
            //tableVoluntarios.TotalWidth = 200f;
            //tableVoluntarios.LockedWidth = true;
            
            PdfPCell header1 = new PdfPCell(new Phrase("Cuerpo de Bomberos de Valdivia"));
            header1.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell header2 = new PdfPCell(new Phrase("C O M A N D A N C I A"));
            header2.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell white_space = new PdfPCell(new Phrase(" "));

            header1.Colspan = 2;
            header2.Colspan = 2;
            white_space.Colspan = 2;

            tableVoluntarios.AddCell(header1);
            tableVoluntarios.AddCell(header2);
            tableVoluntarios.AddCell(white_space);

            PdfPCell nombre = new PdfPCell(new Phrase("Nombre"));
            nombre.HorizontalAlignment = Element.ALIGN_CENTER;
            tableVoluntarios.AddCell(nombre);
            PdfPCell cargo = new PdfPCell(new Phrase("Cargo"));
            cargo.HorizontalAlignment = Element.ALIGN_CENTER;
            tableVoluntarios.AddCell(cargo);

            foreach (Voluntario voluntario in Voluntarios)
            {
                tableVoluntarios.AddCell(voluntario.nombre);
                tableVoluntarios.AddCell(voluntario.cargo);
            }

            PdfPCell cellVoluntarios = new PdfPCell(tableVoluntarios);
            cellVoluntarios.Padding = 0f;
            table.AddCell(cellVoluntarios);

            PdfPTable columna_evento;
            PdfPCell cell_columna_evento;
            int count = 0;

            PdfPTable header3 = new PdfPTable(1);
            header3.AddCell("CLAVE");
            header3.AddCell("CODIGO");
            header3.AddCell("FECHA");
            header3.AddCell("HORA");

            PdfPCell clave;
            PdfPCell codigo;
            PdfPCell dia;
            PdfPCell hora;
            PdfPCell asistencia;

            foreach (Evento evento in Eventos)
            {
                columna_evento = new PdfPTable(1);

                clave = new PdfPCell(new Phrase(evento.claveServicio));
                clave.HorizontalAlignment = Element.ALIGN_CENTER;
                columna_evento.AddCell(clave);

                codigo = new PdfPCell(new Phrase(evento.codigoServicio));
                codigo.HorizontalAlignment = Element.ALIGN_CENTER;
                columna_evento.AddCell(codigo);

                dia = new PdfPCell(new Phrase(evento.fecha.Day.ToString()));
                dia.HorizontalAlignment = Element.ALIGN_CENTER;
                columna_evento.AddCell(dia);

                hora = new PdfPCell(new Phrase(evento.fecha.ToShortTimeString()));
                hora.HorizontalAlignment = Element.ALIGN_CENTER;
                columna_evento.AddCell(hora);

                foreach (Voluntario voluntario in Voluntarios)
                {
                    header3.AddCell(" ");

                    asistencia = new PdfPCell(new Phrase(AModel.ObtenerCodigoAsistencia(evento.idEvento, voluntario.idVoluntario)));
                    asistencia.HorizontalAlignment = Element.ALIGN_CENTER;
                    columna_evento.AddCell(asistencia);
                }

                if(count == 0)
                {
                    PdfPCell cellheader3 = new PdfPCell(header3);
                    table.AddCell(cellheader3);
                }
                count++;

                cell_columna_evento = new PdfPCell(columna_evento);
                table.AddCell(cell_columna_evento);
            }

            PdfPTable columna_resumen;
            PdfPCell cell_columna_resumen;

            PdfPCell cell_resumen;

            for (int i = 0; i < 6;i++)
            {
                String head = "";
                switch (i)
                {
                    case 0:
                        head = "LISTA CORRIDA";
                        break;
                    case 1:
                        head = "LLAMADAS";
                        break;
                    case 2:
                        head = "ASISTENCIA";
                        break;
                    case 3:
                        head = "FALTAS";
                        break;
                    case 4:
                        head = "LICENCIAS";
                        break;
                    case 5:
                        head = "SUSPENCIONES";
                        break;
                }
                columna_resumen = new PdfPTable(1);
                PdfPCell headcell = new PdfPCell(new Phrase(head, standardFont));
                headcell.Rotation = 90;
                headcell.FixedHeight = 64f;
                headcell.HorizontalAlignment = Element.ALIGN_CENTER;
                headcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                columna_resumen.AddCell(headcell);

                foreach(Voluntario voluntario in Voluntarios)
                {
                    switch (i)
                    {
                        case 0:
                            columna_resumen.AddCell(" ");
                            break;
                        case 1:
                            cell_resumen = new PdfPCell(new Phrase(AModel.ObtenerNumeroLlamados(voluntario.idVoluntario).ToString()));
                            cell_resumen.HorizontalAlignment = Element.ALIGN_CENTER;
                            columna_resumen.AddCell(cell_resumen);
                            break;
                        case 2:
                            cell_resumen = new PdfPCell(new Phrase(AModel.ObtenerNumeroAsistencias(voluntario.idVoluntario).ToString()));
                            cell_resumen.HorizontalAlignment = Element.ALIGN_CENTER;
                            columna_resumen.AddCell(cell_resumen);
                            break;
                        case 3:
                            cell_resumen = new PdfPCell(new Phrase(AModel.ObtenerNumeroFaltas(voluntario.idVoluntario).ToString()));
                            cell_resumen.HorizontalAlignment = Element.ALIGN_CENTER;
                            columna_resumen.AddCell(cell_resumen);
                            break;
                        case 4:
                            cell_resumen = new PdfPCell(new Phrase(AModel.ObtenerNumeroLicencias(voluntario.idVoluntario).ToString()));
                            cell_resumen.HorizontalAlignment = Element.ALIGN_CENTER;
                            columna_resumen.AddCell(cell_resumen);
                            break;
                        case 5:
                            columna_resumen.AddCell(" ");
                            break;
                    }
                }
                cell_columna_resumen = new PdfPCell(columna_resumen);
                table.AddCell(cell_columna_resumen);
            }

            doc.Add(table);

            doc.Close();
            writer.Close();
        }

        #endregion
    }
}