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
    [Table("MARK_DiemDanh_TC")]
    public partial class MARK_DiemDanh_TC
    {
        [Key]
        public int ID_diem_danh { get; set; }
		
		[Display(Name = "ID Điểm")]
        public int ID_diem { get; set; }
		
		[Display(Name = "Học kỳ DD")]
        public int Hoc_ky_DD { get; set; }
		
		[Display(Name = "Năm học DD")]
        public string Nam_hoc_DD { get; set; }
		
		[Display(Name = "Số tiết nghỉ có phép")]
        public int So_tiet_nghi_co_phep { get; set; }
		
		[Display(Name = "Số tiết nghỉ không phép")]
        public int So_tiet_nghi_khong_phep { get; set; }
		
		[Display(Name = "Số lần vi phạm")]
        public int So_lan_vi_pham { get; set; }
		
		[Display(Name = "Thiếu bài thực hành")]
        public bool Thieu_bai_thuc_hanh { get; set; }
		
		[Display(Name = "Hash_code")]
        public int Hash_code { get; set; }
		
		[Display(Name = "Locked_dd")]
        public int Locked_dd { get; set; }
		
		[Display(Name = "Ghi chú")]
        public string Ghi_chu { get; set; }
    }
}