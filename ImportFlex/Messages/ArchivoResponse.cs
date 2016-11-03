using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportFlex.Messages
{
    public class ArchivoResponse:ResponseBase
    {
        public string RutaArchivo { get; set; }
        public string NombreArchivo { get; set; }
    }
}