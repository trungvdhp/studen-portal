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
    [Table("STU_DanhSach")]
    public partial class STU_DanhSach
    {
        [Key]
		[ForeignKey("STU_HoSoSinhVien")]
        public int ID_sv { get; set; }
		
		[Display(Name = "ID Lớp")]
		[ForeignKey("STU_Lop")]
        public int ID_lop { get; set; }
		
		[Display(Name = "Mật khẩu")]
        public string Mat_khau { get; set; }
		
		[Display(Name = "Active")]
        public bool Active { get; set; }
		
		[Display(Name = "Đã tốt nghiệp")]
        public bool Da_tot_nghiep { get; set; }
		
		[Display(Name = "Ngoài ngân sách")]
        public Nullable<bool> Ngoai_ngan_sach { get; set; }
		
		[Display(Name = "Lớp chất lượng cao")]
        public Nullable<bool> Lop_chat_luong_cao { get; set; }
		
		[Display(Name = "ID Xếp hạng học lực")]
        public Nullable<int> ID_xep_hang_hoc_luc { get; set; }
		
		[Display(Name = "Trạng thái")]
        public int Trang_thai { get; set; }
		
		public virtual STU_Lop STU_Lop { get; set; }
		public virtual STU_HoSoSinhVien STU_HoSoSinhVien { get; set; }
    }
}