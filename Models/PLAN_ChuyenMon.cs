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
    [Table("PLAN_ChuyenMon")]
    public partial class PLAN_ChuyenMon
    {
        [Key]
		
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_chuyen_mon { get; set; }
		
		[Display(Name = "Mã chuyên môn")]
        public string Ma_chuyen_mon { get; set; }
		
		[Display(Name = "Chuyen môn")]
        public string Chuyen_mon { get; set; }
    }
}
