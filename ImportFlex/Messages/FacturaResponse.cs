using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class FacturaResponse:ResponseBase
    {
        public imf_facturas_fac Factura { get; set; }
    }
}