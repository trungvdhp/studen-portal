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
    [Table("STU_DoiTuongGiayto")]
    public partial class STU_DoiTuongGiayto
    {
		[Display(Name = "Mã ĐT")]
        public string Ma_dt { get; set; }
		
		[Display(Name = "ID Giấy tờ")]
        public int ID_giay_to { get; set; }
    }
}
