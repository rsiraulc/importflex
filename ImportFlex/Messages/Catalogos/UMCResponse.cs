using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class UMCResponse:ResponseBase
    {
        public imf_unidadmedidacomercial_umc UMC { get; set; }
    }
}