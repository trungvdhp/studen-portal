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
    [Table("PLAN_LopTinChi")]
    public partial class PLAN_LopTinChi_TC
    {
        public PLAN_LopTinChi_TC()
        {
            this.PLAN_SukiensTinChi_TC = new HashSet<PLAN_SukiensTinChi_TC>();
        }
		
		[Key]
        public int ID_lop_tc { get; set; }
		
		[Display(Name = "ID Lớp LT")]
        public int ID_lop_lt { get; set; }
		
		[Display(Name = "ID Môn TC")]
        public int ID_mon_tc { get; set; }
		
		[Display(Name = "STT Lớp")]
        public int STT_lop { get; set; }
		
		[Display(Name = "Số sv min")]
        public int So_sv_min { get; set; }
		
		[Display(Name = "Số sv max")]
        public int So_sv_max { get; set; }
		
		[Display(Name = "Từ ngày")]
        public System.DateTime Tu_ngay { get; set; }
		
		[Display(Name = "Đến ngày")]
        public System.DateTime Den_ngay { get; set; }
		
		[Display(Name = "Ca học")]
        public int Ca_hoc { get; set; }
		
		[Display(Name = "Số tiết / tuần")]
        public int So_tiet_tuan { get; set; }
		
		[Display(Name = "ID Phòng")]
        public int ID_phong { get; set; }
		
		[Display(Name = "ID_cb")]
        public int ID_cb { get; set; }
		
		[Display(Name = "Hủy lớp")]
        public bool Huy_lop { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
		
		[Display(Name = "Nhóm đăg ký")]
        public string Nhom_dang_ky { get; set; }
		
		[Display(Name = "Ngày thi")]
        public Nullable<System.DateTime> Ngay_thi { get; set; }
		
		[Display(Name = "Chỗ trống")]
        public Nullable<int> Cho_trong { get; set; }
    
        public virtual PLAN_MonTinChi_TC PLAN_MonTinChi_TC { get; set; }
        public virtual ICollection<PLAN_SukiensTinChi_TC> PLAN_SukiensTinChi_TC { get; set; }
    }
}
