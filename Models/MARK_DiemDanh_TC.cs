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
    
    public partial class MARK_DiemDanh_TC
    {
        [Key]
        public int ID_diem_danh { get; set; }
        public int ID_diem { get; set; }
        public int Hoc_ky_DD { get; set; }
        public string Nam_hoc_DD { get; set; }
        public int So_tiet_nghi_co_phep { get; set; }
        public int So_tiet_nghi_khong_phep { get; set; }
        public int So_lan_vi_pham { get; set; }
        public bool Thieu_bai_thuc_hanh { get; set; }
        public int Hash_code { get; set; }
        public int Locked_dd { get; set; }
        public string Ghi_chu { get; set; }
    }
}