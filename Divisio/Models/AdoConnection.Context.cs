﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Divisio.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DivisioEntities : DbContext
    {
        public DivisioEntities()
            : base("name=DivisioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accounts> accounts { get; set; }
        public virtual DbSet<accountType> accountType { get; set; }
        public virtual DbSet<algemene_groepen> algemene_groepen { get; set; }
        public virtual DbSet<categorie> categorie { get; set; }
        public virtual DbSet<contactlijst> contactlijst { get; set; }
        public virtual DbSet<groepen> groepen { get; set; }
        public virtual DbSet<items> items { get; set; }
        public virtual DbSet<land> land { get; set; }
        public virtual DbSet<lening> lening { get; set; }
        public virtual DbSet<postcodeGemeente> postcodeGemeente { get; set; }
        public virtual DbSet<provincie> provincie { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<toestand> toestand { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}
