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
    [Table("Mark_DanhSachNgunghoc")]
    public partial class Mark_DanhSachNgunghoc
    {
        [Key]
        public int ID_ngung_hoc { get; set; }
		
		[Display(Name = "ID_sv")]
        public int ID_sv { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "Số QĐ")]
        public string So_QD { get; set; }
		
		[Display(Name = "Ngày QĐ")]
        public Nullable<System.DateTime> Ngay_QD { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
		
		[Display(Name = "ID Lớp cũ")]
        public int ID_lop_cu { get; set; }
		
		[Display(Name = "Thôi học")]
        public bool Thoi_hoc { get; set; }
		
		[Display(Name = "Nghỉ học")]
        public bool Nghi_hoc { get; set; }
		
		[Display(Name = "Chuyển trường")]
        public bool Chuyen_truong { get; set; }
    }
}
