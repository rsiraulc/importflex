//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImportFlex.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class imf_usuarios_usr
    {
        public int usrIdUsuario { get; set; }
        public string usrUserName { get; set; }
        public string usrPassword { get; set; }
        public string userNombre { get; set; }
        public string usrApellidoPaterno { get; set; }
        public string usrApellidoMaterno { get; set; }
        public string usrEmail { get; set; }
        public Nullable<System.DateTime> usrFechaRegistro { get; set; }
    }
}