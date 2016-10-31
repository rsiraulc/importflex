using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImportFlex.Models;

namespace ImportFlex.Messages.Catalogos
{
    public class UsuarioResponse:ResponseBase
    {
        public imf_usuarios_usr Usuario { get; set; }
    }
}