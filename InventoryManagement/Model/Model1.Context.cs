﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagement.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INVENTORY_MANAGEMENTEntities : DbContext
    {
        public INVENTORY_MANAGEMENTEntities()
            : base("name=INVENTORY_MANAGEMENTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DON_VI_TINH> DON_VI_TINH { get; set; }
        public virtual DbSet<LOAI_MAT_HANG> LOAI_MAT_HANG { get; set; }
        public virtual DbSet<LOAI_TAI_KHOAN> LOAI_TAI_KHOAN { get; set; }
        public virtual DbSet<MAT_HANG> MAT_HANG { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAI_KHOAN> TAI_KHOAN { get; set; }
    }
}
