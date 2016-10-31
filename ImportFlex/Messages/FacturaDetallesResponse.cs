using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class FacturaDetallesResponse:ResponseBase
    {
        public List<imf_facturadetalle_fde> lstFacturaDetalle { get; set; }
    }
}