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
    [Table("MARK_LoaiChungChiDanhSachMon_TC")]
    public partial class MARK_LoaiChungChiDanhSachMon_TC
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_chung_chi { get; set; }
		
		[Display(Name = "ID Môn")]
		[ForeignKey("MARK_MonHoc")]
        public int ID_mon { get; set; }
		
		[Display(Name = "ID_dt")]
		[ForeignKey("STU_DoiTuong")]
        public int ID_dt { get; set; }
		
		public virtual MARK_MonHoc MARK_MonHoc { get; set; }
		
		public virtual STU_DoiTuong STU_DoiTuong { get; set; }
    }
}
