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
    [Table("MARK_DiemThi_TC")]
    public partial class MARK_DiemThi_TC
    {
        [Key]
        public int ID_diem_thi { get; set; }
		
		[Display(Name = "ID Điểm")]
        public int ID_diem { get; set; }
		
		[Display(Name = "Lần thi")]
        public int Lan_thi { get; set; }
		
		[Display(Name = "Học kỳ thi")]
        public int Hoc_ky_thi { get; set; }
		
		[Display(Name = "Năm học thi")]
        public string Nam_hoc_thi { get; set; }
		
		[Display(Name = "Điểm thi")]
        public float Diem_thi { get; set; }
		
		[Display(Name = "Điểm chữ")]
        public string Diem_chu { get; set; }
		
		[Display(Name = "TBCMH")]
        public float TBCMH { get; set; }
		
		[Display(Name = "Hash_code")]
        public int Hash_code { get; set; }
		
		[Display(Name = "Locked")]
        public int Locked { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
    
        public virtual MARK_Diem_TC MARK_Diem_TC { get; set; }
    }
}
