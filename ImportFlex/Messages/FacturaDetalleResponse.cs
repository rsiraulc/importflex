using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class FacturaDetalleResponse:ResponseBase
    {
        public imf_facturadetalle_fde FacturaDetalle { get; set; }
    }
}