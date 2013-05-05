//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal
{
    using System;
    using System.Collections.Generic;
    [Table("PLAN_SuKiensTinChi_TC")]
    public partial class PLAN_SukiensTinChi_TC
    {
	
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
		
		[Display(Name = "ID Lớp TC")]
		[ForeignKey("PLAN_LopTinChi_TC")]
        public int ID_lop_tc { get; set; }
		
		[Display(Name = "ID Phòng")]
		[ForeignKey("PLAN_PhongHoc")]
        public int ID_phong { get; set; }
		
		[Display(Name = "ID_cb")]
		[ForeignKey("PLAN_GiaoVien")]
        public int ID_cb { get; set; }
		
		[Display(Name = "Ca học")]
        public int Ca_hoc { get; set; }
		
		[Display(Name = "Thứ")]
        public int Thu { get; set; }
		
		[Display(Name = "Tiết")]
        public int Tiet { get; set; }
		
		[Display(Name = "Số tiết")]
        public int So_tiet { get; set; }
		
		[Display(Name = "Loại tiết")]
        public int Loai_tiet { get; set; }
		
		[Display(Name = "Đã xếp lịch")]
        public bool Da_xep_lich { get; set; }
    
        public virtual PLAN_LopTinChi_TC PLAN_LopTinChi_TC { get; set; }
		
		public virtual PLAN_PhongHoc PLAN_PhongHoc { get; set; }
		
		public virtual PLAN_GiaoVien PLAN_GiaoVien { get; set; }
    }
}
