using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class TraduccionResponse:ResponseBase
    {
        public imf_traducciones_trad Traduccion { get; set; }
    }
}