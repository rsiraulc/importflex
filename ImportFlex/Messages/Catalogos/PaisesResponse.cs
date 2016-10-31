using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class PaisesResponse:ResponseBase
    {
        public List<imf_paises_pai> lstPaises { get; set; }
    }
}