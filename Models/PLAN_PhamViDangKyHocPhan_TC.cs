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
    [Table("PLAN_PhamViDangKyHocPhan_TC")]
    public partial class PLAN_PhamViDangKyHocPhan_TC
    {
        [Key]
        public int ID_lop { get; set; }
		
		[Display(Name = "ID Môn")]
        public int ID_mon { get; set; }
    }
}
