using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class ProveedorResponse:ResponseBase
    {
        public imf_proveedores_prv Proveedor { get; set; }
    }
}