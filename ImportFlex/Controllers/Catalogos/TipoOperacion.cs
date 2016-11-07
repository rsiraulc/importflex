using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportFlex.Controllers.Enums
{
    public class TipoOperacion
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }

        public static List<TipoOperacion> GetTipoOperaciones()
        {
            return new List<TipoOperacion>
            {
                new TipoOperacion {Clave = 1, Descripcion = "Importación"},
                new TipoOperacion {Clave = 2, Descripcion = "Exportación"},
                new TipoOperacion {Clave = 3, Descripcion = "Reexpedición"}
            };
        }
    }
}