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
    [Table("PLAN_KeHoachKyHieu_TC")]
    public partial class PLAN_KeHoachKyHieu_TC
    {
		[Key]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Tên ký hiệu")]
        public string Ten_ky_hieu { get; set; }
		
		[Display(Name = "BgColor")]
        public Nullable<int> bgColor { get; set; }
		
		[Display(Name = "TxtColor")]
        public Nullable<int> txtColor { get; set; }
    }
}
