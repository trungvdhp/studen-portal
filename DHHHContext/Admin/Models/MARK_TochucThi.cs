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
    [Table("MARK_ToChucThi")]
    public partial class MARK_TochucThi
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_thi { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Hệ")]
		[ForeignKey("STU_He")]
        public int ID_he { get; set; }
		
		[Display(Name = "ID Khoa")]
		[ForeignKey("STU_Khoa")]
        public int ID_khoa { get; set; }
		
		[Display(Name = "ID Môn")]
		[ForeignKey("MARK_MonHoc")]
        public int ID_mon { get; set; }
		
		[Display(Name = "Lần thi")]
        public int Lan_thi { get; set; }
		
		[Display(Name = "Đợt thi")]
        public int Dot_thi { get; set; }
		
		[Display(Name = "Ngày thi")]
        public System.DateTime Ngay_thi { get; set; }
		
		[Display(Name = "Ca thi")]
        public Nullable<int> Ca_thi { get; set; }
		
		[Display(Name = "Nhóm tiết")]
        public Nullable<int> Nhom_tiet { get; set; }
		
		[Display(Name = "Thời gian")]
        public string Thoi_gian { get; set; }
		
		public virtual STU_He STU_He { get; set; }
		
		public virtual STU_Khoa STU_Khoa { get; set; }
		
		public virtual MARK_MonHoc MARK_MonHoc { get; set; }
    }
}
