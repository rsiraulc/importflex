﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ImportFlexEntities : DbContext
    {
        public ImportFlexEntities()
            : base("name=ImportFlexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<imf_paises_pai> imf_paises_pai { get; set; }
        public virtual DbSet<imf_proveedores_prv> imf_proveedores_prv { get; set; }
        public virtual DbSet<imf_usuarios_usr> imf_usuarios_usr { get; set; }
        public virtual DbSet<imf_unidadmedidacomercial_umc> imf_unidadmedidacomercial_umc { get; set; }
        public virtual DbSet<imf_unidadmedidafactura_umf> imf_unidadmedidafactura_umf { get; set; }
        public virtual DbSet<imf_facturadetalle_fde> imf_facturadetalle_fde { get; set; }
        public virtual DbSet<imf_facturas_fac> imf_facturas_fac { get; set; }
        public virtual DbSet<imf_roles_rls> imf_roles_rls { get; set; }
        public virtual DbSet<imf_importaciones_imp> imf_importaciones_imp { get; set; }
        public virtual DbSet<imf_productos_prod> imf_productos_prod { get; set; }
    }
}
