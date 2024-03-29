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
    [Table("STU_LoaiRenLuyen")]
    public partial class STU_LoaiRenLuyen
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_loai_rl { get; set; }
		
		[Display(Name = "ID Cấp rèn luyện")]
		[ForeignKey("STU_CapRenLuyen")]
        public int ID_cap_rl { get; set; }
		
		[Display(Name = "Ký hiệu")]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Tên loại")]
        public string Ten_loai { get; set; }
		
		[Display(Name = "Điểm")]
        public int Diem { get; set; }
		
		public virtual STU_CapRenLuyen STU_CapRenLuyen { get; set; }
    }
}
