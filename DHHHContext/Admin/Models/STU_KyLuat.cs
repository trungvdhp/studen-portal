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
    [Table("STU_KyLuat")]
    public partial class STU_KyLuat
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_ky_luat { get; set; }
		
		[Display(Name = "Số QĐ")]
        public string So_qd { get; set; }
		
		[Display(Name = "Ngày QĐ")]
        public Nullable<System.DateTime> Ngay_qd { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Hành vi")]
		[ForeignKey("STU_HanhVi")]
        public int ID_hanh_vi { get; set; }
		
		[Display(Name = "ID Xử lý")]
		[ForeignKey("STU_XuLy")]
        public int ID_xu_ly { get; set; }
		
		[Display(Name = "Nội dung")]
        public string Noi_dung { get; set; }
		
		public virtual STU_HanhVi STU_HanhVi { get; set; }
		
		public virtual STU_XuLy STU_XuLy { get; set; }
    }
}
