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
    [Table("STU_CapKhenThuongKyLuat")]
    public partial class STU_CapKhenThuongKyLuat
    {
        [Key]
        public int ID_cap { get; set; }
		
		[Display(Name = "Tên cấp")]
        public string Ten_cap { get; set; }
    }
}
