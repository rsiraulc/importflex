using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportFlex.Controllers.Enums
{
    //public enum RegionPedimento
    //{
    //    A1,
    //    C1,
    //    EXD,
    //    A3
    //}

    public class RegionPedimento
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }

        public static List<RegionPedimento> GetRegionPedimento()
        {
            return new List<RegionPedimento>
            {
                new RegionPedimento { Clave = "1", Descripcion = "Fronterizo"},
                new RegionPedimento { Clave = "9", Descripcion = "Interior"},
            };
        }

        public static string GetRegionById(int id)
        {
            switch (id)
            {
                case 1:
                    return "FRONTERIZO";
                case 9:
                    return "INTERIOR";
                default:
                    return "";
            }
        }
    }
}