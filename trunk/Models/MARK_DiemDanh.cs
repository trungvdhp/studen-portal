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
    [Table("MARK_DiemDanh")]
    public partial class MARK_DiemDanh
    {
        [Key]
        public int ID_diem_danh { get; set; }
		
		[Display(Name = "ID Điểm")]
        public int ID_diem { get; set; }
		
		[Display(Name = "Lần học")]
        public int Lan_hoc { get; set; }
		
		[Display(Name = "Số tiết nghỉ")]
        public int So_tiet_nghi { get; set; }
		
		[Display(Name = "Hash_code")]
        public int Hash_code { get; set; }
		
		[Display(Name = "Locked_dd")]
        public int Locked_dd { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
		
		[Display(Name = "Thiếu bài thực hành")]
        public Nullable<bool> Thieu_bai_thuc_hanh { get; set; }
    }
}
