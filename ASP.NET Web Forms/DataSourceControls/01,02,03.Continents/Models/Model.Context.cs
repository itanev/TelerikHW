﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.Continents.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ContinentsEntities : DbContext
    {
        public ContinentsEntities()
            : base("name=ContinentsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Continents> Continents { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Towns> Towns { get; set; }
    }
}
