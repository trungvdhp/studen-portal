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
    [Table("Mark_DanhSachChuaTotNghiep")]
    public partial class Mark_DanhSachChuaTotNghiep
    {
        [Key]
        public int ID_sv { get; set; }
		
		[Display(Name = "TBCHT")]
        public Nullable<float> TBCHT { get; set; }
		
		[Display(Name = "ID Xếp loại")]
        public Nullable<int> ID_xep_loai { get; set; }
		
		[Display(Name = "Lý do")]
        public string Ly_do { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "ID_dt")]
        public Nullable<int> Id_dt { get; set; }
		
		[Display(Name = "Phần trăm thi lại")]
        public string Phan_tram_thi_lai { get; set; }
    }
}
