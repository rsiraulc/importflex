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
    
    public partial class imf_proveedores_prv
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public imf_proveedores_prv()
        {
            this.imf_facturas_fac = new HashSet<imf_facturas_fac>();
        }
    
        public int prvIdProveedor { get; set; }
        public string prvCodigo { get; set; }
        public string prvDescripcion { get; set; }
        public string prvIdTax { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imf_facturas_fac> imf_facturas_fac { get; set; }
    }
}
