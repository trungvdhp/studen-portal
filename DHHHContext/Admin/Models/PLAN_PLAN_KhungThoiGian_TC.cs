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
    [Table("PLAN_PLAN_KhungThoiGian_TC")]
    public partial class PLAN_PLAN_KhungThoiGian_TC
    {
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
		
		[Display(Name = "Thứ")]
        public string Thu { get; set; }
		
		[Display(Name = "Ca")]
        public string Ca { get; set; }
		
		[Display(Name = "Tiết")]
        public string Tiet { get; set; }
		
		[Display(Name = "Số tiết")]
        public Nullable<int> So_tiet { get; set; }
    }
}
