using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportFlex.Account
{
    public class Sesiones
    {
        public static int? UsuarioID
        {
            get
            {
                return (int?)HttpContext.Current.Session["SESSION_IDUSUARIO"];
            }
            set
            {
                HttpContext.Current.Session["SESSION_IDUSUARIO"] = value == 0 ? (int?)null : value;
            }


        }

        public static string EmailUsuario
        {
            get
            {
                return (string)HttpContext.Current.Session["SESSION_EMAILUSUARIO"];
            }
            set
            {
                HttpContext.Current.Session["SESSION_EMAILUSUARIO"] = value;
            }
        }
        public static string NombreUsuario
        {
            get
            {
                return (string)HttpContext.Current.Session["SESSION_NOMBREUSUARIO"];
            }
            set
            {
                HttpContext.Current.Session["SESSION_NOMBREUSUARIO"] = value;
            }
        }

        public static string Rol
        {
            get
            {
                return (string)HttpContext.Current.Session["SESSION_ROL"];
            }
            set
            {
                HttpContext.Current.Session["SESSION_ROL"] = value;
            }
        }

        public static void Clear()
        {
            Rol = null;
            UsuarioID = null;
            NombreUsuario = null;
            EmailUsuario = null;
        }

    }
}