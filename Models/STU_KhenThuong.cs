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
    
    public partial class STU_KhenThuong
    {
        [Key]
        public int ID_khen_thuong { get; set; }
        public string So_QD { get; set; }
        public Nullable<System.DateTime> Ngay_QD { get; set; }
        public int Hoc_ky { get; set; }
        public string Nam_hoc { get; set; }
        public int ID_loai_kt { get; set; }
        public string Hinh_thuc { get; set; }
        public int ID_cap { get; set; }
    }
}