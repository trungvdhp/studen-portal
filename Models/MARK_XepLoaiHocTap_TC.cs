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
    [Table("MARK_XepLoaiHocTap_TC")]
    public partial class MARK_XepLoaiHocTap_TC
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_xep_loai { get; set; }
		
		[Display(Name = "Xếp loại")]
        public string Xep_loai { get; set; }
		
		[Display(Name = "Từ điểm")]
        public float Tu_diem { get; set; }
		
		[Display(Name = "Đến điểm")]
        public float Den_diem { get; set; }
		
		[Display(Name = "Xếp loại EN")]
        public string Xep_loai_en { get; set; }
    }
}
