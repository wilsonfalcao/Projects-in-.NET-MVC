﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_moradaEntities : DbContext
    {
        public db_moradaEntities()
            : base("name=db_moradaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<cadastro_categoria> cadastro_categoria { get; set; }
        public DbSet<cadastro_lugar> cadastro_lugar { get; set; }
        public DbSet<cadastro_usuario> cadastro_usuario { get; set; }
        public DbSet<d_bordo_s1> d_bordo_s1 { get; set; }
        public DbSet<email> email { get; set; }
    }
}
