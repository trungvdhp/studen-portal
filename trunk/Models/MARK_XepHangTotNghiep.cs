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
    [Table("MARK_XepHangTotNghiep")]
    public partial class MARK_XepHangTotNghiep
    {
        [Key]
        public int ID_xep_hang { get; set; }
		
		[Display(Name = "Từ điểm")]
        public float Tu_diem { get; set; }
		
		[Display(Name = "Đến điểm")]
        public float Den_diem { get; set; }
		
		[Display(Name = "Xếp hạng")]
        public string Xep_hang { get; set; }
    }
}
