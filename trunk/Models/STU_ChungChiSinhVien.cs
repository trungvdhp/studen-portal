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
    [Table("STU_ChungChiSinhVien")]
    public partial class STU_ChungChiSinhVien
    {
        [Key]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID_đt")]
        public int ID_dt { get; set; }
		
		[Display(Name = "ID Chứng chỉ")]
        public int ID_chung_chi { get; set; }
		
		[Display(Name = "Lần xét")]
        public int Lan_xet { get; set; }
		
		[Display(Name = "ID Xếp loại")]
        public Nullable<int> ID_xep_loai { get; set; }
		
		[Display(Name = "TBCHT")]
        public Nullable<float> TBCHT { get; set; }
    }
}
