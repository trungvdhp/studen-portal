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
    [Table("PLAN_DangKyMonTinChi_TC")]
    public partial class PLAN_DangKyMonTinChi_TC
    {
		[Key]
        public int ID { get; set; }
		
		[Display(Name = "Học kỳ")]
        public int Hoc_ky { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID_sv")]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID Môn")]
        public int ID_mon { get; set; }
		
		[Display(Name = "Số tín chỉ")]
        public int So_tin_chi { get; set; }
    }
}
