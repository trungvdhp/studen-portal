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
    [Table("MARK_QuyetDinhThoiHoc")]
    public partial class MARK_QuyetDinhThoiHoc
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_qd { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "Số QĐ)]
        public string So_qd { get; set; }
		
		[Display(Name = "Ngày QĐ")]
        public System.DateTime Ngay_qd { get; set; }
		
		[Display(Name = "Loại QĐ")]
        public int Loai_qd { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
    }
}
