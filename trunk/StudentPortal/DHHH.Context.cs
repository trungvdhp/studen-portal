﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentPortal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DHHHContext : DbContext
    {
        public DHHHContext()
            : base("name=DefaultConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PLAN_GiaoVien> PLAN_GiaoVien { get; set; }
        public DbSet<MARK_MonHoc> MARK_MonHoc { get; set; }
        public DbSet<PLAN_LopTinChi_TC> PLAN_LopTinChi_TC { get; set; }
        public DbSet<PLAN_MonTinChi_TC> PLAN_MonTinChi_TC { get; set; }
        public DbSet<PLAN_PhongHoc> PLAN_PhongHoc { get; set; }
        public DbSet<PLAN_BoMon> PLAN_BoMon { get; set; }
        public DbSet<STU_He> STU_He { get; set; }
    }
}
