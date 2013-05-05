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
    [Table("STU_LoaiKhenThuong")]
    public partial class STU_LoaiKhenThuong
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_loai_kt { get; set; }
		
		[Display(Name = "ID Cấp")]
		[ForeignKey("STU_CapKhenThuongKyLuat")]
        public int ID_cap { get; set; }
		
		[Display(Name = "Loại khen thưởng")]
        public string Loai_khen_thuong { get; set; }
		
		[Display(Name = "Điểm thưởng")]
        public float Diem_thuong { get; set; }
		
		public virtual STU_CapKhenThuongKyLuat STU_CapKhenThuongKyLuat { get; set; }
    }
}
