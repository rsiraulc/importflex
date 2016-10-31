using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class ImportacionResponse:ResponseBase
    {
        public imf_importaciones_imp Importacion { get; set; }
    }
}