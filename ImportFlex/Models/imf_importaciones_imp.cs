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
    
    public partial class imf_importaciones_imp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public imf_importaciones_imp()
        {
            this.imf_facturas_fac = new HashSet<imf_facturas_fac>();
        }
    
        public int impIdImportacion { get; set; }
        public string impNumeroPedimento { get; set; }
        public System.DateTime impFecha { get; set; }
        public Nullable<int> impTotalArticulos { get; set; }
        public Nullable<decimal> impTotal { get; set; }
        public string impStatus { get; set; }
        public string impClave { get; set; }
        public string impCodigoImportador { get; set; }
        public Nullable<decimal> impTotalFlete { get; set; }
        public Nullable<int> impTransporteEntradaSalida { get; set; }
        public Nullable<int> impTransporteArribo { get; set; }
        public Nullable<int> impTransporteSalidaAduana { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imf_facturas_fac> imf_facturas_fac { get; set; }
    }
}