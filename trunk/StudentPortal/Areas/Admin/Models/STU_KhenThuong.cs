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
    [Table("STU_KhenThuong")]
    public partial class STU_KhenThuong
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_khen_thuong { get; set; }
		
		[Display(Name = "Số qd")]
        public string So_QD { get; set; }
		
		[Display(Name = "Ngày qd")]
        public Nullable<System.DateTime> Ngay_QD { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Loại kt")]
		[ForeignKey("STU_LoaiKhenThuong")]
        public int ID_loai_kt { get; set; }
		
		[Display(Name = "Hình thức")]
        public string Hinh_thuc { get; set; }
		
		[Display(Name = "ID cấp")]
		[ForeignKey("STU_CapKhenThuongKyLuat")]
        public int ID_cap { get; set; }
		
		public virtual STU_LoaiKhenThuong STU_LoaiKhenThuong { get; set; }
		
		public virtual STU_CapKhenThuongKyLuat STU_CapKhenThuongKyLuat { get; set; }
    }
}