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
    [Table("STU_HoSoyeucau")]
    public partial class STU_HoSoYeucau
    {
        [Key]
        public int ID_giay_to { get; set; }
		
		[Display(Name = "Khóa học")]
        public int Khoa_hoc { get; set; }
		
		[Display(Name = "ID Hệ")]
        public int ID_he { get; set; }
    }
}
