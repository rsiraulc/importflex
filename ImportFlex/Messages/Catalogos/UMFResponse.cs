using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class UMFResponse:ResponseBase
    {
        public imf_unidadmedidafactura_umf UMF { get; set; }
    }
}