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
    
    public partial class imf_facturadetalle_fde
    {
        public int fdeIdDetalleFactura { get; set; }
        public int fdeIdFactura { get; set; }
        public string fdeFraccion { get; set; }
        public int fdeIdProducto { get; set; }
        public Nullable<System.DateTime> fdeFecha { get; set; }
        public Nullable<decimal> fdeValor { get; set; }
        public Nullable<int> fdeIdUMC { get; set; }
        public Nullable<decimal> fdeCantidadUMC { get; set; }
        public Nullable<int> fdeIdUMF { get; set; }
        public Nullable<decimal> fdeCantidadUMF { get; set; }
        public string fdeVinculacion { get; set; }
        public string fdeMetodoValoracion { get; set; }
        public Nullable<int> fdIdPaisOrigenDestino { get; set; }
        public Nullable<int> fdeIdPaisVendedorComprador { get; set; }
        public string fdeNumeroSerieProducto { get; set; }
    
        public virtual imf_facturas_fac imf_facturas_fac { get; set; }
        public virtual imf_paises_pai imf_paises_pai { get; set; }
        public virtual imf_paises_pai imf_paises_pai1 { get; set; }
        public virtual imf_productos_prod imf_productos_prod { get; set; }
        public virtual imf_unidadmedidacomercial_umc imf_unidadmedidacomercial_umc { get; set; }
        public virtual imf_unidadmedidafactura_umf imf_unidadmedidafactura_umf { get; set; }
    }
}