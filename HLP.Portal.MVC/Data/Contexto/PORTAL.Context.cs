﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Portal.MVC.Data.Contexto
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PortalEntities : DbContext
    {
        public PortalEntities()
            : base("name=PortalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tb_cliente> tb_cliente { get; set; }
        public DbSet<tb_curriculum> tb_curriculum { get; set; }
        public DbSet<tb_imagem> tb_imagem { get; set; }
        public DbSet<tb_modulo> tb_modulo { get; set; }
        public DbSet<tb_modulo_item> tb_modulo_item { get; set; }
        public DbSet<tb_segmento> tb_segmento { get; set; }
        public DbSet<tb_solicitecontato> tb_solicitecontato { get; set; }
        public DbSet<tb_usuario> tb_usuario { get; set; }
        public DbSet<tb_noticias> tb_noticias { get; set; }
    }
}
