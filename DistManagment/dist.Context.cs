﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistManagment
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DistManEntities : DbContext
    {
        public DistManEntities()
            : base("name=DistManEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<order> order { get; set; }
        public DbSet<order_agent> order_agent { get; set; }
        public DbSet<order_product> order_product { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<user> users { get; set; }
    }
}
