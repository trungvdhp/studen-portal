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
    [Table("STU_NhomDoiTuong")]
    public partial class STU_NhomDoiTuong
    {
        [Key]
        public int ID_nhom_dt { get; set; }
		
		[Display(Name = "Mã nhóm")]
        public string Ma_nhom { get; set; }
		
		[Display(Name = "Tên nhóm")]
        public string Ten_nhom { get; set; }
		
		[Display(Name = "Tên nhóm EN")]
        public string Ten_nhom_en { get; set; }
    }
}