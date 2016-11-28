using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ImportFlex.Controllers.Enums;
using ImportFlex.Messages;
using ImportFlex.Models;
using Telerik.Charting.Styles;

namespace ImportFlex.Controllers.Export
{
    public class HojaTraduccion
    {
        protected Font LetraTituloReporte = FontFactory.GetFont(FontFactory.HELVETICA, 16, Font.BOLD);
        protected Font LetraTituloTabla = FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD);
        protected Font LetraTituloTablaWhite = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD, BaseColor.WHITE);
        protected Font LetraTituloTablaBlack = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD, BaseColor.WHITE);
        protected Font LetraTituloRojo = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.BOLD, BaseColor.RED);
        protected Font LetraTituloTablaGrande = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);
        protected Font LetraCeldaTabla = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.NORMAL);
        protected Font LetraCeldaSmallBold = FontFactory.GetFont(FontFactory.HELVETICA, 5, Font.BOLD);
        protected Font LetraCeldaSmall = FontFactory.GetFont(FontFactory.HELVETICA, 5, Font.NORMAL);
        protected Font LetraLinks = FontFactory.GetFont(FontFactory.HELVETICA, 9, Font.NORMAL, BaseColor.BLUE);
        protected BaseColor colorRow;

        public ArchivoResponse CrearHojaTraduccion(imf_importaciones_imp p)
        {
            var response = new ArchivoResponse();

            try
            {
                var dir = HttpContext.Current.Server.MapPath("~/Controllers/Archivos/");
                var nombreArchivo = $"{p.impNumeroPedimento}_{p.impParte}.pdf";
                var path = dir +nombreArchivo;
                var doc = new Document(PageSize.LETTER, 20, 20, 20, 20);
                var pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.OpenOrCreate));
                var eh = new PdfPageEventHelper();
                pdfWriter.PageEvent = eh;
                doc.AddTitle($"HojaTraduccion_{p.impNumeroPedimento}_{p.impParte}");
                doc.Open();

                /***** ENCABEZADO *********************/
                #region Encabezado
                var tableEncabezado = new PdfPTable(3)
                {
                    SpacingAfter = 10,
                    WidthPercentage = 100,
                };

                tableEncabezado.SetWidths(new float[] { 150f, 350f, 100f });

                var logoRSI = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/Logo_RSI_40px.png"));
                logoRSI.ScaleAbsolute(50f, 20f);

                tableEncabezado.AddCell(new PdfPCell(logoRSI)
                {
                    Border = Rectangle.NO_BORDER
                });

                tableEncabezado.AddCell(new PdfPCell(new Phrase("HOJA DE TRADUCCIÓN", LetraTituloReporte))
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

                /**** TABLAS INTERMEDIAS **************/
                #region Intermedias
                var tableDatos = new PdfPTable(3);
                tableDatos.WidthPercentage = 100;
                var declaracion =
                    "BAJO PROTESTA DE DECIR LA VERDAD Y DE CONFORMIDAD CON LA REGLA 3.1.5 DE CARACTER GENERAL EN MATERI DE COMERCIO EXTERIOR VIGENTES DECLARO QUE LA INFORMACIÓN DECLARADA EN LA PRESENTE HOJA ES LA CORRECTA POR EL AGENTE ADUANAL: 3479. \r\r CONFORME A LO DISPUESTO EN EL ART. 36-A FRACCION I INCISO A) DE LA LEY ADUANERA Y R.G.C.E., ASUMO BAJO PROTESTA DE DECIR LA VERDAD LOS DERECHOS DE ESTE DOCUMENTO";

                var destinatario =
                    "RSI MEXICO S DE RL DE CV \r JUAN MANUEL SALVATIERRA 1A \r GARITA DE OTAY, TIJUANA B.C. 22430 \r R.F.C. RME1201231S7";

                var tramite = $"{TipoOperacion.GetTipoOperacionById(p.impTipoOperacion.Value)} DEFINITIVA {RegionPedimento.GetRegionById(Convert.ToInt32(p.impRegion))}";

                tableDatos.AddCell(new PdfPCell(new Phrase("DECLARACIÓN", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDatos.AddCell(new PdfPCell(new Phrase("DESTINATARIO", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDatos.AddCell(new PdfPCell(new Phrase("TRAMITE", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });

                tableDatos.AddCell(new PdfPCell(new Phrase(declaracion, LetraCeldaSmall)) { HorizontalAlignment = 1, VerticalAlignment = 1 });
                tableDatos.AddCell(new PdfPCell(new Phrase(destinatario, LetraCeldaSmall)) { HorizontalAlignment = 1, VerticalAlignment = 1 });
                tableDatos.AddCell(new PdfPCell(new Phrase(tramite, LetraCeldaSmall)) { HorizontalAlignment = 1, VerticalAlignment = 1 });

                doc.Add(tableDatos);
                #endregion

                /**** DETALLE ************************/
                #region Detalle
                var tableDetalle = new PdfPTable(13);
                tableDetalle.SpacingBefore = 10f;
                tableDetalle.WidthPercentage = 100;

                // ENCABEZADO DETALLE
                tableDetalle.SetWidths(new float[] {15f, 25f, 25f, 95f, 20f, 20f, 20f, 80f, 20f, 30f, 25f, 25f, 30f});
                tableDetalle.AddCell(new PdfPCell(new Phrase("NO.", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("ENTRADA", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("NO. FACTURA", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("DESCRIPCIÓN", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("PIEZAS", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("BULTOS", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("PESO KGS", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("PROVEEDOR", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("ORIGEN", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("VALOR USA", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("FLETE", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("OTROS", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });
                tableDetalle.AddCell(new PdfPCell(new Phrase("TOTAL", LetraCeldaSmallBold)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = 1 });

                // DETALLE
                var num = 0;
                foreach (var f in p.imf_facturas_fac)
                {
                    foreach (var d in f.imf_facturadetalle_fde)
                    {
                        num++;
                        var total = d.fdeValor + p.impTotalFlete;
                        var peso = d.fdeCantidadUMC*d.imf_productos_prod.prodPeso;
                        var bultos = d.fdeCantidadUMC*d.imf_productos_prod.prodPiezasPorBulto;

                        tableDetalle.AddCell(new PdfPCell(new Phrase(num.ToString(), LetraCeldaSmall)) {HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(f.facNumeroEntrada, LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(f.facNumeroFactura, LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(d.imf_productos_prod.imf_traducciones_trad.tradTraduccion, LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(d.fdeCantidadUMC.ToString(), LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(bultos.ToString(), LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("0", LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(f.imf_proveedores_prv.prvDescripcion, LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(d.imf_productos_prod.imf_paises_pai.paiClavePais, LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(d.fdeValor.ToString(), LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(f.facFlete.ToString(), LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("0", LetraCeldaSmall)) { HorizontalAlignment = 1 });
                        tableDetalle.AddCell(new PdfPCell(new Phrase(total.ToString(), LetraCeldaSmall)) { HorizontalAlignment = 1 });
                    }
                }

                doc.Add(tableDetalle);
                #endregion

                var tableFirma = new PdfPTable(2);
                tableFirma.SpacingBefore = 10f;
                tableFirma.WidthPercentage = 100;
                tableFirma.SetWidths(new float[] {750f, 150f});
                var imgFirma = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/firma_enriquecohen.png"));
                imgFirma.ScaleAbsolute(40f, 40f);

                tableFirma.AddCell(new PdfPCell(new Phrase("")) { Border = Rectangle.NO_BORDER});
                tableFirma.AddCell(new PdfPCell(imgFirma)
                {
                    Border = Rectangle.NO_BORDER
                });
                doc.Add(tableFirma);

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