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
    
    public partial class MARK_TochucThi_TC
    {
        [Key]
        public int ID_thi { get; set; }
        public int Hoc_ky { get; set; }
        public string Nam_hoc { get; set; }
        public int ID_he { get; set; }
        public int ID_khoa { get; set; }
        public int ID_mon { get; set; }
        public int Lan_thi { get; set; }
        public int Dot_thi { get; set; }
        public System.DateTime Ngay_thi { get; set; }
        public Nullable<int> Ca_thi { get; set; }
        public Nullable<int> Nhom_tiet { get; set; }
        public string Gio_thi { get; set; }
    }
}