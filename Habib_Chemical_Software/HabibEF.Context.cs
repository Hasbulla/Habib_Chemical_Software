﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Habib_Chemical_Software
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Habib_ChemicalsEntities : DbContext
    {
        public Habib_ChemicalsEntities()
            : base("name=Habib_ChemicalsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cash_Drawer> Cash_Drawer { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Company_Contact_Persons> Company_Contact_Persons { get; set; }
        public virtual DbSet<Monthly_Bill> Monthly_Bill { get; set; }
        public virtual DbSet<Monthly_Bill_Name> Monthly_Bill_Name { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Price> Product_Price { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transaction_Due> Transaction_Due { get; set; }
        public virtual DbSet<Transaction_Product> Transaction_Product { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Weight_Type> Weight_Type { get; set; }
    }
}