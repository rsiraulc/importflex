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
    
    public partial class imf_unidadmedidacomercial_umc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public imf_unidadmedidacomercial_umc()
        {
            this.imf_facturadetalle_fde = new HashSet<imf_facturadetalle_fde>();
            this.imf_productos_prod = new HashSet<imf_productos_prod>();
        }
    
        public int umcIdClave { get; set; }
        public string umcDescripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imf_facturadetalle_fde> imf_facturadetalle_fde { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imf_productos_prod> imf_productos_prod { get; set; }
    }
}
