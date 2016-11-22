using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages
{
    public class TraduccionesResponse:ResponseBase
    {
        public List<imf_traducciones_trad> Traducciones { get; set; }
    }
}