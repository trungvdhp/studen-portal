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
    [Table("MARK_DanhSachTotNghiep")]
    public partial class MARK_DanhSachTotNghiep
    {
        [Key]
        public int ID_sv { get; set; }
		
		[Display(Name = "Lần thứ")]
        public int Lan_thu { get; set; }
		
		[Display(Name = "Số bằng")]
        public int So_bang { get; set; }
		
		[Display(Name = "TBCHT10")]
        public float TBCHT10 { get; set; }
		
		[Display(Name = "TBCHT")]
        public float TBCHT { get; set; }
		
		[Display(Name = "ID Xếp loại")]
        public int ID_xep_loai { get; set; }
		
		[Display(Name = "Năm học")]
        public string Nam_hoc { get; set; }
		
		[Display(Name = "Số bằng(txt)")]
        public string So_bang_txt { get; set; }
		
		[Display(Name = "Số Serial(txt)")]
        public string So_serial_txt { get; set; }
		
		[Display(Name = "ID_dt")]
        public Nullable<int> Id_dt { get; set; }
		
		[Display(Name = "Phần trăm thi lại")]
        public float phantram_thilai { get; set; }
		
		[Display(Name = "Số QĐ")]
        public string So_QD { get; set; }
		
		[Display(Name = "Ngày QĐ")]
        public Nullable<System.DateTime> Ngay_QD { get; set; }
    }
}
