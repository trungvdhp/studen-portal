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
    [Table("PLAN_ChuongTrinhDaoTaoRangBuoc")]
    public partial class PLAN_ChuongTrinhDaoTaoRangBuoc
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_rb { get; set; }
		
		[Display(Name = "ID_dt")]
		[ForeignKey("STU_DoiTuong")]
        public Nullable<int> ID_dt { get; set; }
		
		[Display(Name = "ID Môn")]
		[ForeignKey("MARK_MonHoc")]
        public int ID_mon { get; set; }
		
		[Display(Name = "ID môn RB")]
        [ForeignKey("Mon_Rang_Buoc")]
        public int ID_mon_rb { get; set; }
		
		[Display(Name = "Loại ràng buộc")]
        [ForeignKey("PLAN_LoaiRangBuoc")]
        public int Loai_rang_buoc { get; set; }

        [Display(Name = "Diểm ràng buộc")]
        public double? Diem_rang_buoc { get; set; }
		
		public virtual STU_DoiTuong STU_DoiTuong { get; set; }
		
		public virtual MARK_MonHoc MARK_MonHoc { get; set; }

        public virtual MARK_MonHoc Mon_Rang_Buoc { get; set; }

        public virtual PLAN_LoaiRangBuoc PLAN_LoaiRangBuoc { get; set; }
    }
}
