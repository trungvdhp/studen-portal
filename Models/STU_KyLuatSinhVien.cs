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
    [Table("STU_KyLuatSinhVien")]
    public partial class STU_KyLuatSinhVien
    {
        [Key]
        public int ID_ky_luat { get; set; }
		
		[Display(Name = "ID Sinh vien")]
        public int ID_sv { get; set; }
		
		[Display (Name = "Xóa kỷ luật")]
        public bool Xoa_ky_luat { get; set; }
		
		[Display(Name = "Ngày xóa")]
        public Nullable<System.DateTime> Ngay_Xoa { get; set; }
		
		[Display(Name = "Lý do xóa")]
        public string Lydo_Xoa { get; set; }
    }
}
