using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class UMFsResponse:ResponseBase
    {
        public List<imf_unidadmedidafactura_umf> lstUMF { get; set; }
    }
}