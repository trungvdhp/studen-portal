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
    [Table("STU_LoaiHocBong")]
    public partial class STU_LoaiHocBong
    {
		[Display(Name = "Mã đối tượng")]
        public string Ma_dt { get; set; }
		
		[Display(Name = "ID Hệ")]
        public int ID_he { get; set; }
		
		[Display(Name = "ID Xếp loại hb")]
        public int ID_xep_loai_hb { get; set; }
		
		[Display(Name = "HB_HT")]
        public int HB_HT { get; set; }
    }
}