using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class PaisResponse:ResponseBase
    {
        public imf_paises_pai Pais { get; set; }
    }
}