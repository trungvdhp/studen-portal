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
    [Table("STU_CapRenLuyen")]
    public partial class STU_CapRenLuyen
    {
        [Key]
        public int ID_cap_rl { get; set; }
		
		[Display(Name = "Ký hiệu")]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Tên cấp")]
        public string Ten_cap { get; set; }
		
		[Display(Name = "Điểm")]
        public int Diem { get; set; }
    }
}
