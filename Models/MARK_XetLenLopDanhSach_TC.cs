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
    [Table("MARK_XetLenLopDanhSach_TC")]
    public partial class MARK_XetLenLopDanhSach_TC
    {
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID_sv")]
		[ForeignKey("STU_HoSoSinhVien")]
        public int ID_sv { get; set; }
		
		[Display(Name = "Trạng thái")]
        public int Trang_thai { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
		
		public virtual STU_HoSoSinhVien STU_HoSoSinhVien { get; set; }
    }
}
