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
    
    public partial class MARK_ThanhPhanMon
    {
        [Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID_thanh_phan { get; set; }
		
		[Display(Name = "ID Hệ")]
		[ForeignKey("STU_He")]
        public int ID_he { get; set; }
		
		[Display(Name = "STT")]
        public int STT { get; set; }
		
		[Display(Name = "Ký hiệu")]
        public string Ky_hieu { get; set; }
		
		[Display(Name = "Tên thành phần")]
        public string Ten_thanh_phan { get; set; }
		
		[Display(Name = "Tỷ lệ")]
        public int Ty_le { get; set; }
		
		[Display(Name = "Chọn mặc định")]
        public int Chon_mac_dinh { get; set; }
		
		[Display(Name = "Chuyên cần")]
        public bool Chuyencan { get; set; }
		
		public virtual STU_He STU_He { get; set; }
    }
}
