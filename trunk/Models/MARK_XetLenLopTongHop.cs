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
    [Table("MARK_XetLenLopTongHop")]
    public partial class MARK_XetLenLopTongHop
    {
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Lớp")]
        public int ID_lop { get; set; }
		
		[Display(Name = "Học tiếp")]
        public Nullable<int> Hoc_tiep { get; set; }
		
		[Display(Name = "Thôi học 1")]
        public Nullable<int> Thoi_hoc1 { get; set; }
		
		[Display(Name = "Thôi học 2")]
        public Nullable<int> Thoi_hoc2 { get; set; }
		
		[Display(Name = "Thôi học 3")]
        public Nullable<int> Thoi_hoc3 { get; set; }
		
		[Display(Name = "Thôi học 4")]
        public Nullable<int> Thoi_hoc4 { get; set; }
		
		[Display(Name = "Thôi học 5")]
        public Nullable<int> Thoi_hoc5 { get; set; }
		
		[Display(Name = "Ngừng học 1")]
        public Nullable<int> Ngung_hoc1 { get; set; }
		
		[Display(Name = "Ngừng học 2")]
        public Nullable<int> Ngung_hoc2 { get; set; }
		
		[Display(Name = "Ngừng học 3")]
        public Nullable<int> Ngung_hoc3 { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
    }
}