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
    [Table("STU_XeploaiRenLuyen")]
    public partial class STU_XeploaiRenLuyen
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_xep_loai { get; set; }
		
		[Display(Name = "Xếp loại")]
        public string Xep_loai { get; set; }
		
		[Display(Name = "Từ điểm")]
        public Nullable<int> Tu_diem { get; set; }
		
		[Display(Name = "Đến điểm")]
        public Nullable<int> Den_diem { get; set; }
		
		[Display(Name = "Hệ số")]
        public Nullable<float> He_so { get; set; }
    }
}
