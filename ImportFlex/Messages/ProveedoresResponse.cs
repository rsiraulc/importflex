using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class ProveedoresResponse:ResponseBase
    {
        public List<imf_proveedores_prv> lstProveedores { get; set; }
    }
}