﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StephenCoreMed.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CoreMedEntities : DbContext
    {
        public CoreMedEntities()
            : base("name=CoreMedEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee_Customer> Employee_Customer { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
    }
}