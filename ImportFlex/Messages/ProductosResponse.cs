using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class ProductosResponse:ResponseBase
    {
        public List<imf_productos_prod> Productos { get; set; }
    }
}