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
    [Table("MARK_NoKhacKhiXetTotNghiep")]
    public partial class MARK_NoKhacKhiXetTotNghiep
    {
        [Key]
        public int ID_sv { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
    }
}
