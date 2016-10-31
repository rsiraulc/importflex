using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class UMCsResponse:ResponseBase
    {
        public List<imf_unidadmedidacomercial_umc> lstUMC { get; set; }
    }
}