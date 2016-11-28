using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ImportFlex.Messages;
using ImportFlex.Models;

namespace ImportFlex.Controllers.Export
{
    public class FormatoImportacionFrontera : HojaTraduccion
    {
        public ArchivoResponse GetFormatoImportacion(imf_importaciones_imp p)
        {
            var response = new ArchivoResponse();

            try
            {
                var dir = HttpContext.Current.Server.MapPath("~/Controllers/Archivos/");
                var nombreArchivo = $"FIP_{p.impNumeroPedimento}_{p.impParte}.pdf";
                var path = dir + nombreArchivo;
                var doc = new Document(PageSize.LETTER, 20, 20, 20, 20);
                var pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.OpenOrCreate));
                var eh = new PdfPageEventHelper();
                pdfWriter.PageEvent = eh;
                doc.AddTitle($"FormatoImportacion{p.impNumeroPedimento}_{p.impParte}");
                doc.Open();

                /***** ENCABEZADO *********************/
                #region Encabezado
                var tableEncabezado = new PdfPTable(3)
                {
                    SpacingAfter = 10,
                    WidthPercentage = 100
                };

                tableEncabezado.SetWidths(new float[] { 150f, 350f, 100f });
                tableEncabezado.DefaultCell.FixedHeight = 20f;

                var logoRSI = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/Logo_RSI_40px.png"));
                logoRSI.ScaleAbsolute(50f, 20f);

                tableEncabezado.AddCell(new PdfPCell(logoRSI)
                {
                    Border = Rectangle.NO_BORDER
                });

                tableEncabezado.AddCell(new PdfPCell(new Phrase("FRONTERA", LetraTituloReporte))
                {
                    HorizontalAlignment = 1,
                    Border = Rectangle.NO_BORDER
                });

                tableEncabezado.AddCell(new PdfPCell(new Phrase($"Fecha {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}", LetraCeldaTabla))
                {
                    Border = Rectangle.NO_BORDER
                });
                doc.Add(tableEncabezado);
                #endregion

                /**** DETALLE ************************/
                #region Detalle
                var tableDetalle = new PdfPTable(7);
                tableDetalle.SpacingBefore = 10f;
                tableDetalle.WidthPercentage = 100;

                // ENCABEZADO DETALLE
                tableDetalle.SetWidths(new float[] { 20f, 25f, 35f, 30f, 40f, 40f, 40f});
                tableDetalle.AddCell(new PdfPCell(new Phrase("BULTO", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f});
                tableDetalle.AddCell(new PdfPCell(new Phrase("CANTIDAD", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f });
                tableDetalle.AddCell(new PdfPCell(new Phrase("NO. PARTE", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f });
                tableDetalle.AddCell(new PdfPCell(new Phrase("PO", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f });
                tableDetalle.AddCell(new PdfPCell(new Phrase("NOTA", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f });
                tableDetalle.AddCell(new PdfPCell(new Phrase("CONFIRMACION DE LLEGADA", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f });
                tableDetalle.AddCell(new PdfPCell(new Phrase("LOCALIDAD ASIGNADA", LetraTituloTablaGrande)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1, FixedHeight = 30f });

                // DETALLE
                var num = 0;
                foreach (var f in p.imf_facturas_fac)
                {
                    foreach (var d in f.imf_facturadetalle_fde)
                    {
                        num++;
                        var peso = d.fdeCantidadUMC * d.imf_productos_prod.prodPeso;
                        var bultos = d.fdeCantidadUMC * d.imf_productos_prod.prodPiezasPorBulto;

                        tableDetalle.AddCell(new PdfPCell(new Phrase(bultos.ToString(), LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(d.fdeCantidadUMC.ToString(), LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(d.imf_productos_prod.prodNumeroParte, LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(f.facOrdenCompra, LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("", LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("", LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("", LetraCeldaTabla)) { HorizontalAlignment = 1, FixedHeight = 30f });
                    }
                }

                doc.Add(tableDetalle);
                #endregion

                doc.Close();
                response.NombreArchivo = nombreArchivo;
                response.RutaArchivo = path;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            


            return response;
        }

        public void EliminarArchivo(string path)
        {
            File.Delete(path);
        }
    }
}