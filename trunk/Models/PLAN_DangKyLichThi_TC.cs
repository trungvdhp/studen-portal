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
    [Table("PLAN_DangKyLichThi_TC")]
    public partial class PLAN_DangKyLichThi_TC
    {
        [Key]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID lịch thi")]
        public int ID_lich_thi { get; set; }
    }
}