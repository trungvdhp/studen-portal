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
    [Table("PLAN_ChucVu")]
    public partial class PLAN_ChucVu
    {
        [Key]
        public int ID_chuc_vu { get; set; }
		
		[Display(Name = "Mã chức vụ")]
        public string Ma_chuc_vu { get; set; }
		
		[Display(Name = "Chức vụ")]
        public string Chuc_vu { get; set; }
    }
}
