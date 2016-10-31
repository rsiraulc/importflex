using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class ProductoResponse:ResponseBase
    {
        public imf_productos_prod Producto { get; set; }
    }
}