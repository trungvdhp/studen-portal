//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    
    public partial class PLAN_KeHoachThi_TC
    {
        [Key]
        public int ID_kh_thi { get; set; }
        public Nullable<int> ID_kh_tuan { get; set; }
        public Nullable<int> ID_mon { get; set; }
        public Nullable<int> ID_lop { get; set; }
        public Nullable<System.DateTime> Ngay_thi { get; set; }
        public Nullable<int> Ca_thi { get; set; }
        public Nullable<int> Nhom_tiet { get; set; }
        public string Mo_ta { get; set; }
    }
}
