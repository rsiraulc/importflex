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
    public class HojaTraduccion
    {
        public ResponseBase CrearHojaTraduccion(imf_importaciones_imp p)
        {
            var response = new ResponseBase();

            try
            {
                var fs = new FileStream($"HT_{p.impNumeroPedimento}_{p.impParte}.pdf", FileMode.Create, FileAccess.Write,FileShare.None);

                var rec= new Rectangle(PageSize.LETTER);
                var doc = new Document(rec);
                var writer = PdfWriter.GetInstance(doc, fs);



                doc.Open();
                doc.Add(new Paragraph(p.impNumeroPedimento));
                doc.Close();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}