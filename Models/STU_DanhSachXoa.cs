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
    [Table("STU_DanhSachXoa")]
    public partial class STU_DanhSachXoa
    {
        [Key]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID Lớp")]
        public int ID_lop { get; set; }
		
		[Display(Name = "Mật khẩu")]
        public string mat_khau { get; set; }
		
		[Display(Name = "Active")]
        public bool Active { get; set; }
    }
}
