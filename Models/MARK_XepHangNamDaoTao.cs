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
    [Table("MARK_XepHangNamDaoTao")]
    public partial class MARK_XepHangNamDaoTao
    {
        [Key]
        public int ID_xep_hang { get; set; }
		
		[Display(Name = "Năm thứ")]
        public int Nam_thu { get; set; }
		
		[Display(Name = "Từ tín chỉ")]
        public int Tu_tin_chi { get; set; }
		
		[Display(Name = "Đến tín chỉ")]
        public int Den_tin_chi { get; set; }
    }
}
