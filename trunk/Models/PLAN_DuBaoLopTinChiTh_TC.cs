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
    [Table("PLAN_DuBaoLopTinChiTh_TC")]
    public partial class PLAN_DuBaoLopTinChiTh_TC
    {
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID Môn")]
        public int ID_mon { get; set; }
		
		[Display(Name = "Số tín chỉ")]
        public int So_tin_chi { get; set; }
		
		[Display(Name = "Số sv")]
        public int So_sv { get; set; }
		
		[Display(Name = "Số lớp")]
        public Nullable<int> So_lop { get; set; }
		
		[Display(Name = "Ký hiệu lớp")]
        public string Ky_hieu_lop { get; set; }
		
		[Display(Name = "Số sv min")]
        public Nullable<int> So_sv_min { get; set; }
		
		[Display(Name = "Số sv max")]
        public Nullable<int> So_sv_max { get; set; }
    }
}
