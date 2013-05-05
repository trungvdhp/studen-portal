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
    [Table("PLAN_ChuongTrinhDaoTaoMonTuongDuong")]
    public partial class PLAN_ChuongTrinhDaoTaoMonTuongDuong
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_tuong_duong { get; set; }
		
		[Display(Name = "ID_dt")]
		[ForeignKey("STU_DoiTuong")]
        public int ID_dt { get; set; }
		
		[Display(Name = "ID Môn")]
		[ForeignKey("MARK_MonHoc")]
        public int ID_mon { get; set; }
		
		[Display(Name = "ID Môn tương đương")]
        public int ID_mon_tuong_duong { get; set; }
		
		public virtual STU_DoiTuong STU_DoiTuong { get; set; }
		
		public virtual MARK_monHoc MARK_MonHoc { get; set; }
    }
}
