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
    [Table("STU_HoatDongXaHoi")]
    public partial class STU_HoatDongXaHoi
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_hd_xh { get; set; }
		
		[Display(Name = "ID Sinh viên")]
		[ForeignKey("STU_HoSoSinhVien")]
        public int ID_sv { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "Ngày tháng")]
        public System.DateTime Ngay_thang { get; set; }
		
		[Display(Name = "Nội dung")]
        public string Noi_dung { get; set; }
		
		[Display(Name = "Kết quả")]
        public string Ket_qua { get; set; }
		
		[Display(Name = "Điểm thưởng")]
        public Nullable<int> Diem_thuong { get; set; }
		
		public virtual STU_HoSoSinhVien STU_HoSoSinhVien { get; set; }
    }
}
