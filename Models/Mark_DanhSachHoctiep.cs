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
    [Table("Mark_DanhSachHocTiep")]
    public partial class Mark_DanhSachHoctiep
    {
        [Key]
        public int ID_hoc_tiep { get; set; }
		
		[Display(Name = "ID Ngừng học")]
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
		
		[Display(Name = "ID Lớp mới")]
        public int ID_lop_moi { get; set; }
    }
}
