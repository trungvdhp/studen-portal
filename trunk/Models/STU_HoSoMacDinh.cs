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
    [Table("STU_HoSoMacDinh")]
    public partial class STU_HoSoMacDinh
    {
		[Key]
        public int ID { get; set; }
		
		[Display(Name = "UserName")]
        public string UserName { get; set; }
		
		[Display(Name = "ID Tỉnh ns")]
        public string ID_tinh_ns { get; set; }
		
		[Display(Name = "ID Tỉnh TT")]
        public string ID_Tinh_tt { get; set; }
		
		[Display(Name = "ID Huyện TT")]
        public string ID_Huyen_tt { get; set; }
		
		[Display(Name = "ID Dân tộc")]
        public Nullable<int> ID_Dan_toc { get; set; }
		
		[Display(Name = "Tôn giáo")]
        public string Ton_giao { get; set; }
		
		[Display(Name = "Mã dt")]
        public string Ma_dt { get; set; }
		
		[Display(Name = "ID nhóm dt")]
        public Nullable<int> ID_nhom_dt { get; set; }
		
		[Display(Name = "Mã KV")]
        public string Ma_kv { get; set; }
		
		[Display(Name = "ID Giới tính")]
        public Nullable<bool> ID_gioi_tinh { get; set; }
		
		[Display(Name = "Khối thi")]
        public string Khoi_thi { get; set; }
		
		[Display(Name = "Đoàn")]
        public Nullable<bool> Doan { get; set; }
		
		[Display(Name = "Đảng")]
        public Nullable<bool> Dang { get; set; }
    }
}