using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class FacturasResponse:ResponseBase
    {
        public List<imf_facturas_fac> lstFacturas { get; set; }
    }
}