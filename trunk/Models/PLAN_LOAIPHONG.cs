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
    [Table("PLAN_LOAIPHONG")]
    public partial class PLAN_LOAIPHONG
    {
        [Key]
        public int ID_loai_phong { get; set; }
		
		[Display(Name = "Mã loại")]
        public string Ma_loai { get; set; }
		
		[Display(Name = "Tên loại phòng")]
        public string Ten_loai_phong { get; set; }
		
		[Display(Name = "Thực hành")]
        public bool Thuc_hanh { get; set; }
    }
}