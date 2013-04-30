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
    [Table("MARK_MonHoc")]
    public partial class MARK_MonHoc
    {
        public MARK_MonHoc()
        {
            this.PLAN_MonTinChi_TC = new HashSet<PLAN_MonTinChi_TC>();
            this.MARK_Diem_TC = new HashSet<MARK_Diem_TC>();
            this.PLAN_MonDangKy_TC = new HashSet<PLAN_MonDangKy_TC>();
        }
		[Key]
        public int ID_mon { get; set; }
		
		[Display(Name = "Ký hiệu")]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Tên môn")]
        public string Ten_mon { get; set; }
		
		[Display(Name = "Tên tiếng anh")]
        public string Ten_tieng_anh { get; set; }
		
		[Display(Name = "ID_bm")]
        public int ID_bm { get; set; }
		
		[Display(Name = "ID Hệ đt")]
        public Nullable<int> ID_he_dt { get; set; }
		
		[Display(Name = "ID Nhóm hp")]
        public Nullable<int> ID_nhom_hp { get; set; }
    
        public virtual ICollection<PLAN_MonTinChi_TC> PLAN_MonTinChi_TC { get; set; }
        public virtual ICollection<MARK_Diem_TC> MARK_Diem_TC { get; set; }
        public virtual ICollection<PLAN_MonDangKy_TC> PLAN_MonDangKy_TC { get; set; }
    }
}